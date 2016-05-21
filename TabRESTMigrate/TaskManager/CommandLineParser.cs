using System.Collections.Generic;
using TabRESTMigrate.FilesLogging;

namespace TabRESTMigrate.TaskManager
{
    /// <summary>
    /// Gives parsed values for the command line arguments
    /// </summary>
    public partial class CommandLineParser
    {
        //Example: -command inventory -fromSiteUrl https://foo.bar/123 -inventoryOutputFile "c:\some dir\some location" -fromSiteUserId test@example.com -fromSiteUserPassword "pw 123" -fromSiteIsSystemAdmin true

        private readonly List<string> _commandLineParameters;


        /// <summary>
        /// Gives the total command line arguments count
        /// </summary>
        public int Count => _commandLineParameters.Count;

        /// <summary>
        /// Constructors
        /// </summary>
        public CommandLineParser() : this (System.Environment.GetCommandLineArgs())
        {        
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commandLineArgs"></param>
        public CommandLineParser(IEnumerable<string> commandLineArgs)
        {
            //Make a copy of the array
            _commandLineParameters = new List<string>(commandLineArgs);
        }


        /// <summary>
        /// Parses a parameter value as a bookean
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool GetParameterValueAsBool(string parameterName, bool defaultValue = default(bool))
        {
            var paramValue = GetParameterValue(parameterName);

            //If it's emtpy, then return the default
            if(string.IsNullOrWhiteSpace(paramValue))
            {
                return defaultValue;
            }

            //Parse the text value
            paramValue = paramValue.Trim().ToLower();
            return paramValue == CommandLineParser.ParameterValue_True;
        }

        /// <summary>
        /// Looks for the command line parameter "-[parameterName]" and returns the next text item after it 
        ///
        ///     Example: -command inventory -fromSiteUrl https://foo.bar/123 -inventoryOutputFile "c:\some dir\some location" -fromSiteId test@example.com -fromSitePassword "pw 123" -fromSiteIsSystemAdmin true
        ///   GetParameterValue("command")             --> "inventory"
        ///   GetParameterValue("fromSiteUrl")         --> "https://foo.bar/123"
        ///   GetParameterValue("inventoryOutputFile") -->  "c:\some dir\some location"
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string GetParameterValue(string parameterName)
        {
            var parameters = _commandLineParameters;
            AppDiagnostics.Assert(!string.IsNullOrWhiteSpace(parameterName), "Blank parameter name");
            parameterName = parameterName.Trim();
            //Stick a '-' in front of the parameter name
            if(parameterName[0] != '-')
            {
                parameterName = "-" + parameterName;
            }


            if(parameters == null) return null;

            var idxSeek = 0;
            while((idxSeek < parameters.Count) &&
                  (parameters[idxSeek] != parameterName))
            {
                idxSeek++;
            }

            //Did we go off the end of the array?
            if(idxSeek >= parameters.Count)
            {
                return null; //No such parameter
            }

            //The paramter value comes right after the parameter itself
            var paramValueIdx = idxSeek + 1;
            //Parameter was found but has no value, since it is the last thing in the array
            if(paramValueIdx >= parameters.Count)
            {
                return "";
            }

            return parameters[paramValueIdx];
        }

    }
}
