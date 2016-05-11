using System;
using System.Text;
using System.Xml;
using TabRESTMigrate.FilesLogging;
using TabRESTMigrate.RESTHelpers;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a Data connection that is embedded in a Workbook or Data Source
    /// </summary>
    public class SiteConnection : IHasSiteItemId
    {
        public string Id { get; }
        public string ConnectionType { get; }
        public string ServerAddress { get; }
        public string ServerPort { get; }
        public string UserName { get; }

        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectNode"></param>
        public SiteConnection(XmlNode projectNode)
        {
            var sbDevNotes = new StringBuilder();

            if(projectNode.Name.ToLower() != "connection")
            {
                AppDiagnostics.Assert(false, "Not a connection");
                throw new Exception("Unexpected content - not connection");
            }

            Id = projectNode.Attributes["id"].Value;
            ConnectionType = projectNode.Attributes["type"].Value;

            ServerAddress = XmlHelper.SafeParseXmlAttribute(projectNode, "serverAddress", "");
            ServerPort = XmlHelper.SafeParseXmlAttribute(projectNode, "serverPort", "");
            UserName = XmlHelper.SafeParseXmlAttribute(projectNode, "userName", "");

            DeveloperNotes = sbDevNotes.ToString();
        }


        public override string ToString()
        {
            return "Connection: " + ConnectionType + "/" + ServerAddress + "/" + Id;
        }

        string IHasSiteItemId.Id => Id;
    }
}
