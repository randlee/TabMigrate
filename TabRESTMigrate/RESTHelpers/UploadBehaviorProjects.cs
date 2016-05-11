namespace TabRESTMigrate.RESTHelpers
{
    /// <summary>
    /// What is the behavior during uploads when we cannot find a matching pre-existing projec
    /// </summary>
    public class UploadBehaviorProjects
    {
        public bool AttemptProjectCreate { get; }
        public bool UseDefaultProjectIfNeeded { get; }

        public UploadBehaviorProjects(bool attemptCreate, bool allowDefaultIfNeeded)
        {
            AttemptProjectCreate = attemptCreate;
            UseDefaultProjectIfNeeded = allowDefaultIfNeeded;
        }
    }
}
