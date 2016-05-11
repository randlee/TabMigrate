using System;
using System.Xml;
using TabRESTMigrate.RESTHelpers;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Base class for information common to Workbooks and Data Sources, so we don't have lots of redundant code
    /// </summary>
    public abstract class SiteDocumentBase : IHasProjectId, ITagSetInfo, IHasSiteItemId
    {
        public string Id { get; }
        public string Name { get; }
        //Note: [2015-10-28] Datasources presently don't return this information
        //public  string ContentUrl;
        public string ProjectId { get; }
        public string ProjectName { get; }
        public string OwnerId { get; }
        public SiteTagsSet TagsSet { get; }

        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        protected SiteDocumentBase(XmlNode xmlNode)
        {
            if (xmlNode.Attributes == null) throw new NullReferenceException($"Can not create {GetType()} xmlNode is null!");
            Name = xmlNode.Attributes["name"].Value;
            Id = xmlNode.Attributes["id"].Value;

//Note: [2015-10-28] Datasources presently don't return this information
//        this.ContentUrl = xmlNode.Attributes["contentUrl"].Value;

            //Namespace for XPath queries
            var nsManager = XmlHelper.CreateTableauXmlNamespaceManager("iwsOnline");

            //Get the project attributes
            var projectNode = xmlNode.SelectSingleNode("iwsOnline:project", nsManager);
            if (projectNode != null)
            {
                ProjectId = projectNode.Attributes?["id"].Value;
                ProjectName = projectNode.Attributes?["name"].Value;
            }

            //Get the owner attributes
            var ownerNode = xmlNode.SelectSingleNode("iwsOnline:owner", nsManager);
            OwnerId = ownerNode?.Attributes?["id"].Value;

            //See if there are tags
            var tagsNode = xmlNode.SelectSingleNode("iwsOnline:tags", nsManager);
            if (tagsNode != null)
            {
                TagsSet = new SiteTagsSet(tagsNode);
            }
        }

        /// <summary>
        /// Space delimited list of tags
        /// </summary>
        public string TagSetText => TagsSet == null ? "" : TagsSet.TagSetText;

        string IHasProjectId.ProjectId => ProjectId;

        public bool IsTaggedWith(string tagText)
        {
            return TagsSet != null && TagsSet.IsTaggedWith(tagText);
        }

        string IHasSiteItemId.Id => Id;
    }
}
