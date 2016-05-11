using System;
using System.Xml;
using TabRESTMigrate.FilesLogging;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a Tag
    /// </summary>
    public class SiteTag
    {
        public string Label { get; }

        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagNode"></param>
        public SiteTag(XmlNode tagNode)
        {
            if (tagNode.Name.ToLower() != "tag")
            {
                AppDiagnostics.Assert(false, "Not a tag");
                throw new Exception("Unexpected content - not tag");
            }

            Label = tagNode.Attributes["label"].Value;
        }

        public override string ToString()
        {
            return "Tag: " + Label;
        }
    }
}
