using System;
using System.Text;
using System.Xml;
using TabRESTMigrate.FilesLogging;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a Project in a Server's site
    /// </summary>
    public class SiteProject : IHasSiteItemId
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectNode"></param>
        public SiteProject(XmlNode projectNode)
        {
            var sbDevNotes = new StringBuilder();

            if(projectNode.Name.ToLower() != "project")
            {
                AppDiagnostics.Assert(false, "Not a project");
                throw new Exception("Unexpected content - not project");
            }

            Id = projectNode.Attributes["id"].Value;
            Name = projectNode.Attributes["name"].Value;

            var descriptionNode = projectNode.Attributes["description"];
            if(descriptionNode != null)
            {
                Description = descriptionNode.Value;
            }
            else
            {
                Description = "";
                sbDevNotes.AppendLine("Project is missing description attribute");
            }

            DeveloperNotes = sbDevNotes.ToString();
        }

        public SiteProject(string name, string Id)
        {
            Name = name;
            this.Id = Id;
        }

        public override string ToString()
        {
            return "Project: " + Name + "/" + Id;
        }

        string IHasSiteItemId.Id => Id;
    }
}
