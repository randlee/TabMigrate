using System;
using System.Xml;
using TabRESTMigrate.FilesLogging;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a User in a Server's site
    /// </summary>
    public class SiteUser : IHasSiteItemId
    {
        public string Name { get; }
        public string Id { get; }
        public string SiteRole { get; }
        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userNode"></param>
        public SiteUser(XmlNode userNode)
        {
            if (userNode.Name.ToLower() != "user")
            {
                AppDiagnostics.Assert(false, "Not a user");
                throw new Exception("Unexpected content - not user");
            }

            Id = userNode.Attributes["id"].Value;
            Name = userNode.Attributes["name"].Value;
            SiteRole = userNode.Attributes["siteRole"].Value;
        }

        public override string ToString()
        {
            return "User: " + Name + "/" + Id + "/" + SiteRole;
        }

        string IHasSiteItemId.Id => Id;
    }
}
