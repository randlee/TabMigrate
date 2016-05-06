using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TabRESTMigrate.FilesLogging
{
    /// <summary>
    /// Paths we care about
    /// </summary>
    internal static class PathHelper
    {
        /// <summary>
        /// Path to the applicaiton
        /// </summary>
        /// <returns></returns>
        public static string GetApplicaitonPath()
        {
            //Gets the path to the application
            return System.Reflection.Assembly.GetExecutingAssembly().Location;
        }


        /// <summary>
        /// Get's the directory the application is running in
        /// </summary>
        /// <returns></returns>
        public static string GetApplicaitonDirectory()
        {
            return Path.GetDirectoryName(GetApplicaitonPath());
        }

        /// <summary>
        /// Path to the template file we want to use for the Inventory Workbook
        /// </summary>
        /// <returns></returns>
        public static string GetInventoryTwbTemplatePath()
        {
            return Path.Combine(GetApplicaitonDirectory(), "_SampleFiles\\SiteInventory.twb");
        }

        /// <summary>
        /// Inventory *.twb files are named to match the *.csv files they use.  
        /// This function generates the *.twb name/path based on the *.csv name/path
        /// </summary>
        /// <param name="pathCsv"></param>
        /// <returns></returns>
        public static string GetInventoryTwbPathMatchingCsvPath(string pathCsv)
        {
            string pathDir = Path.GetDirectoryName(pathCsv);
            string fileNameNoExtension = Path.GetFileNameWithoutExtension(pathCsv);
            string pathTwbOut = Path.Combine(pathDir, fileNameNoExtension + ".twb");
            return pathTwbOut;
        }


        public static string UserAppDataDirectory()
        {
            // GetEntryAssembly() works properly for applications, but fails unit test. Use GetCallingAssembly for unit test.
            var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
            //var attributes = AssemblyInfoAttributes.Get(assembly.Name());
            var title = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).Cast<AssemblyTitleAttribute>().FirstOrDefault()?.Title;
            var program = Path.GetFileNameWithoutExtension(assembly.Location);
            if (!string.IsNullOrWhiteSpace(title)) program = title;

            var company = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false).Cast<AssemblyCompanyAttribute>().FirstOrDefault()?.Company;
            if (!string.IsNullOrWhiteSpace(company))
            {
                var split = company.Split(',', '.');
                company = string.IsNullOrWhiteSpace(split[0]) ? null : split[0].Trim();
            }
            if (string.IsNullOrWhiteSpace(company)) { company = "Unknown"; }

            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), company, program);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            return directory;
        }
    }
}
