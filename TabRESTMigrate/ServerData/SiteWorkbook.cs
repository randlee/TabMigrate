﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using TabRESTMigrate.FilesLogging;
using TabRESTMigrate.RESTHelpers;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a Workbook in a Server's site
    /// </summary>
    public class SiteWorkbook : SiteDocumentBase, IEditDataConnectionsSet
    {
        public bool ShowTabs { get; }
        //Note: [2015-10-28] Datasources presently don't return this information, so we need to make this workbook specific
        public string ContentUrl { get; }


        /// <summary>
        /// If set, contains the set of data connections embedded in this workbooks
        /// </summary>
        private List<SiteConnection> _dataConnections;

        public ReadOnlyCollection<SiteConnection> DataConnections => _dataConnections?.AsReadOnly();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="workbookNode"></param>
        public SiteWorkbook(XmlNode workbookNode) : base(workbookNode)
        {
            if(workbookNode.Name.ToLower() != "workbook")
            {
                AppDiagnostics.Assert(false, "Not a workbook");
                throw new Exception("Unexpected content - not workbook");
            }

            //Note: [2015-10-28] Datasources presently don't return this information, so we need to make this workbook specific
            ContentUrl = workbookNode.Attributes["contentUrl"].Value;

            //Do we have tabs?
            ShowTabs = XmlHelper.SafeParseXmlAttribute_Bool(workbookNode, "showTabs", false);
        }


        /// <summary>
        /// Friendly text
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Workbook: " + Name + "/" + ContentUrl + "/" + Id + ", Proj: " + ProjectId;
        }

        /// <summary>
        /// Interface for inserting the set of data connections associated with this content
        /// </summary>
        /// <param name="connections"></param>
        void IEditDataConnectionsSet.SetDataConnections(IEnumerable<SiteConnection> connections)
        {
            if(connections == null)
            {
                _dataConnections = null;
            }
            _dataConnections = new List<SiteConnection>(connections);
        }
    }
}
