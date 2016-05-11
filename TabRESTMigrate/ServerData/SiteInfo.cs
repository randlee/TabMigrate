using System;
using System.Xml;
using TabRESTMigrate.FilesLogging;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a Site in Server
    /// </summary>
    class SiteinfoSite
    {
        public string Id { get; }
        public string Name { get; }
        public string ContentUrl { get; }
        public string AdminMode { get; }
        public string State { get; }

        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        public SiteinfoSite(XmlNode content)
        {
            if(content.Name.ToLower() != "site")
            {
                AppDiagnostics.Assert(false, "Not a site");
                throw new Exception("Unexpected content - not site");
            }

            Name = content.Attributes["name"].Value;
            Id = content.Attributes["id"].Value;
            ContentUrl = content.Attributes["contentUrl"].Value;
            AdminMode = content.Attributes["adminMode"].Value;
            State = content.Attributes["state"].Value;
        }
    }
}
