namespace TabRESTMigrate.FilesLogging
{
    /// <summary>
    /// Records errors during runs
    /// </summary>
    public class TaskStatusLogs
    {
        public Logger StatusLog { get; } = new Logger();
        public Logger ErrorLog { get; } = new Logger();
        private int _minimumStatusLevel = 0;

        public void SetStatusLoggingLevel(int statusLevel)
        {
            _minimumStatusLevel = statusLevel;
        }

        public string StatusText => StatusLog.StatusText;

        /// <summary>
        /// Add a header/splitter line
        /// </summary>
        public void AddStatusHeader(string headerText, int statusLevel = 0)
        {
            AddStatus("****************************************************************", statusLevel);
            AddStatus(headerText, statusLevel);
            AddStatus("****************************************************************", statusLevel);
        }

        public void AddStatus(string statusText, int statusLevel = 0)
        {
            if(statusLevel >= _minimumStatusLevel)
            {
                //Indent the lower status items
                string prefixText = "";
                if (statusLevel < 0) { prefixText = "     "; }

                StatusLog.AddStatus(prefixText + statusText);
            }
        }

        public int ErrorCount => ErrorLog.Count;

        public string ErrorText => ErrorLog.StatusText;

        public void AddError(string errorText)
        {
            StatusLog.AddStatus("Error: " + errorText);
            ErrorLog.AddStatus(errorText);
        }
    }
}
