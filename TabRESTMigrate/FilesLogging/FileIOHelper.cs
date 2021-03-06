﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using TabRESTMigrate.RESTHelpers;
using TabRESTMigrate.ServerData;

namespace TabRESTMigrate.FilesLogging
{
    /// <summary>
    /// Helper for file io
    /// </summary>
    public static class FileIOHelper
    {

        /// <summary>
        /// Ensures the specified path exists 
        /// </summary>
        /// <param name="localPath"></param>
        public static void CreatePathIfNeeded(string localPath)
        {
            if (Directory.Exists(localPath)) return;
            Directory.CreateDirectory(localPath);
        }


        public static string GenerateWindowsSafeFilename(string fileNameIn)
        {
            string fileNameOut = fileNameIn;
            fileNameOut = fileNameOut.Replace("\\", "-SLASH-");
            fileNameOut = fileNameOut.Replace("/", "-SLASH-");
            fileNameOut = fileNameOut.Replace("$", "-DOLLAR-");
            fileNameOut = fileNameOut.Replace("*", "STAR");
            fileNameOut = fileNameOut.Replace("?", "-QQQ-");
            fileNameOut = fileNameOut.Replace("%", "-PERCENT-");
            fileNameOut = fileNameOut.Replace(":", "-COLON-");
            fileNameOut = fileNameOut.Replace("|", "-PIPE-");
            fileNameOut = fileNameOut.Replace("\"", "-QUOTE-");
            fileNameOut = fileNameOut.Replace(">", "-GT-");
            fileNameOut = fileNameOut.Replace("<", "-LT-");
            return fileNameOut;
        }

        /// <summary>
        /// Creates a high-probabilty-unique path based on the current date-time
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static string PathDateTimeSubdirectory(string basePath, bool createDirectory, string newDirectoryPrefix = "", Nullable<DateTime> when = null)
        {
            //Subdirectory name
            DateTime now;
            if(when.HasValue)
            {
                now = when.Value;
            }
            else
            {
                now = DateTime.Now;
            }

            string subDirectory = now.Year.ToString() + "-" + now.Month.ToString("00") + "-" + now.Day.ToString("00") + "-" + now.Hour.ToString("00") + now.Minute.ToString("00") + "-" + now.Second.ToString("00");
            if(!string.IsNullOrWhiteSpace(newDirectoryPrefix))
            {
                subDirectory = newDirectoryPrefix + subDirectory;
            }

            //Combined path
            string fullPathToDateTime = Path.Combine(basePath, subDirectory);
            //Create if specified
            if (createDirectory)
            {
                CreatePathIfNeeded(fullPathToDateTime);
            }
            return fullPathToDateTime;
        }


        /// <summary>
        /// Gives us a high probability unqique file name
        /// </summary>
        /// <param name="baseName"></param>
        /// <returns></returns>
        public static string FilenameWithDateTimeUnique(string baseName, Nullable<DateTime> when = null)
        {
            string rootName = Path.GetFileNameWithoutExtension(baseName);
            string extension = Path.GetExtension(baseName);

            //Subdirectory name

            DateTime now = when ?? DateTime.Now;

            string subNameDateTime = now.Year.ToString() + "-" + now.Month.ToString("00") + "-" + now.Day.ToString("00") + "-" + now.Hour.ToString("00") + now.Minute.ToString("00") + "-" + now.Second.ToString("00");

            //Combined path
            return rootName + "_" + subNameDateTime + extension;
        }

        /// <summary>
        /// If we have Project Mapping information, generate a project based path for the download
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="projectList"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static string EnsureProjectBasedPath(string basePath, IProjectsList projectList, IHasProjectId project, TaskStatusLogs statusLog)
        {
            //If we have no project list to do lookups in then just return the base path
            if (projectList == null) return basePath;

            //Look up the project name
            var projWithId = projectList.FindProjectWithId(project.ProjectId);
            if(projWithId == null)
            {
                statusLog.AddError("Project not found with id " + project.ProjectId);
                return basePath;
            }

            //Turn the project name into a directory name
            var safeDirectoryName = GenerateWindowsSafeFilename(projWithId.Name);

            var pathWithProject = Path.Combine(basePath, safeDirectoryName);
            //If needed, create the directory
            if(!Directory.Exists(pathWithProject))
            {
                Directory.CreateDirectory(pathWithProject);
            }

            return pathWithProject;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        internal static string ReverseGenerateWindowsSafeFilename(string directoryName)
        {
            //[2015-03-20] UNDONE: Unmunge any escape characters we baked into the directory name
            return directoryName;
        }

        public static void Serialize<T>(T data, string filename, Func<object, Exception, bool> exceptionHandler)
        {
            if (data != null)
            {
                using (var writer = new StreamWriter(filename))
                {
                    try
                    {
                        // OnSerializing method call not implemented by XmlSerializer, do it manually
                        InvokeDecoratedMethods<OnSerializingAttribute>(data);

                        var serializer = new XmlSerializer(typeof(T));

                        serializer.Serialize(writer, data);

                        InvokeDecoratedMethods<OnSerializedAttribute>(data);
                    }
                    catch (Exception exc)
                    {
                        if (exceptionHandler != null) exceptionHandler.Invoke(exc.Source, exc);
                        else throw;
                    }
                }
            }
        }


        public static T Deserialize<T>(string fileName, Func<object, Exception, bool> exceptionHandler)
        {
            T data = default(T);
            try
            {
                if (File.Exists(fileName))
                {
                    using (var reader = new StreamReader(fileName))
                    {
                        var deserializer = new XmlSerializer(typeof(T));
                        data = (T)deserializer.Deserialize(reader);
                    }
                    // OnDeserialized method call not implemented by XmlSerializer, do it manually
                    InvokeDecoratedMethods<OnDeserializedAttribute>(data);
                }
            }
            catch (Exception exc)
            {
                if (exceptionHandler != null) exceptionHandler.Invoke(exc.Source, exc);
                else throw;
            }
            return data;
        }

        private static readonly object[] _context = { new StreamingContext(StreamingContextStates.File) };
        // OnDeserializing method call not implemented by XmlSerializer, do it manually
        private static void InvokeDecoratedMethods<TAttribute>(object data, bool recurse=true)
        {
            if (data == null) return;
            var type = data.GetType();
            foreach ( var method in type.GetMethods().Where(m => m.GetCustomAttributes(typeof(TAttribute), true).Length > 0))
            {
                method.Invoke(data, _context);
            }
            if (!recurse) return;
            // Call recursively on nested classes
            foreach (PropertyInfo prop in type.GetProperties().Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string)))
            {
                var value = (object) prop.GetValue(data);
                InvokeDecoratedMethods<TAttribute>(value);
            }
        }
    }
}
