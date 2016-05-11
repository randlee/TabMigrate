using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TabRESTMigrate.FilesLogging;
using TabRESTMigrate.RESTHelpers;
using TabRESTMigrate.ServerData;

namespace TabRESTMigrate.RESTRequests
{
    /// <summary>
    /// The list of a Tableau Server Site's groups we have downloaded
    /// </summary>
    class DownloadGroupsList : TableauServerSignedInRequestBase
    {

        /// <summary>
        /// URL manager
        /// </summary>
        private readonly TableauServerUrls _onlineUrls;

        /// <summary>
        /// Groups we've parsed from server results
        /// </summary>
        private List<SiteGroup> _groups;
        public IEnumerable<SiteGroup> Groups => _groups?.AsReadOnly();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="onlineUrls"></param>
        /// <param name="login"></param>
        public DownloadGroupsList(TableauServerUrls onlineUrls, TableauServerSignIn login)
            : base(login)
        {
            _onlineUrls = onlineUrls;
        }

        /// <summary>
        /// Request the data from Online
        /// </summary>
        public void ExecuteRequest()
        {
            var siteGroups = new List<SiteGroup>();

            var numberPages = 1; //Start with 1 page (we will get an updated value from server)
            //Get subsequent pages
            for (var thisPage = 1; thisPage <= numberPages; thisPage++)
            {
                try
                {
                    ExecuteRequest_ForPage(siteGroups, thisPage, out numberPages);
                }
                catch (Exception exPageRequest)
                {
                    StatusLog.AddError("Groups error during page request: " + exPageRequest.Message);
                }
            }

            _groups = siteGroups;
        }

        /// <summary>
        /// Get a page's worth of Groups
        /// </summary>
        /// <param name="onlineGroups"></param>
        /// <param name="pageToRequest">Page # we are requesting (1 based)</param>
        /// <param name="totalNumberPages">Total # of pages of data that Server can return us</param>
        private void ExecuteRequest_ForPage(
            List<SiteGroup> onlineGroups, 
            int pageToRequest, 
            out int totalNumberPages)
        {
            var pageSize = _onlineUrls.PageSize;
            //Create a web request, in including the users logged-in auth information in the request headers
            var urlQuery = _onlineUrls.Url_GroupsList(OnlineSession, pageSize, pageToRequest);
            var webRequest = CreateLoggedInWebRequest(urlQuery);
            webRequest.Method = "GET";

            OnlineSession.StatusLog.AddStatus("Web request: " + urlQuery, -10);
            var response = GetWebReponseLogErrors(webRequest, "get groups list");
            var xmlDoc = GetWebResponseAsXml(response);

            //Get all the group nodes
            var nsManager = XmlHelper.CreateTableauXmlNamespaceManager("iwsOnline");
            var groups = xmlDoc.SelectNodes("//iwsOnline:group", nsManager);

            //Get information for each of the data sources
            foreach (XmlNode itemXml in groups)
            {
                SiteGroup thisGroup = null;
                try
                {
                    thisGroup = new SiteGroup(
                        itemXml, 
                        null);   //We'll get and add the list of users later (see below)
                    onlineGroups.Add(thisGroup);
                    SanityCheckGroup(thisGroup, itemXml);
                }
                catch(Exception exGetGroup)
                {
                    AppDiagnostics.Assert(false, "Group parse error");
                    OnlineSession.StatusLog.AddError("Error parsing group: " + itemXml.OuterXml + ", " + exGetGroup.Message);
                }


                //==============================================================
                //Get the set of users in the group
                //==============================================================
                if (thisGroup != null)
                {
                    try
                    {
                        var downloadUsersInGroup = new DownloadUsersListInGroup(
                            _onlineUrls, 
                            OnlineSession, 
                            thisGroup.Id);
                        downloadUsersInGroup.ExecuteRequest();
                        thisGroup.AddUsers(downloadUsersInGroup.Users);
                    }
                    catch (Exception exGetUsers)
                    {
                        OnlineSession.StatusLog.AddError("Error parsing group's users: " + exGetUsers.Message);
                    }
                }

            } //end: foreach

            //-------------------------------------------------------------------
            //Get the updated page-count
            //-------------------------------------------------------------------
            totalNumberPages = DownloadPaginationHelper.GetNumberOfPagesFromPagination(
                xmlDoc.SelectSingleNode("//iwsOnline:pagination", nsManager),
                pageSize);
        }

        /// <summary>
        /// Does sanity checking and error logging on missing data in groups
        /// </summary>
        /// <param name="group"></param>
        private void SanityCheckGroup(SiteGroup group, XmlNode xmlNode)
        {
            if(string.IsNullOrWhiteSpace(group.Id))
            {
                OnlineSession.StatusLog.AddError(group.Name + " is missing a group ID. Not returned from server! xml=" + xmlNode.OuterXml);
            }
        }


        /// <summary>
        /// Finds a group with matching name
        /// </summary>
        /// <param name="findName"></param>
        /// <returns></returns>
        public SiteGroup FindGroupWithName(string findName)
        {
            return _groups.FirstOrDefault(thisGroup => thisGroup.Name == findName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        SiteGroup FindGroupWithId(string groupId)
        {
            return _groups.FirstOrDefault(thisGroup => thisGroup.Id == groupId);
        }

        /// <summary>
        /// Adds to the list
        /// </summary>
        /// <param name="newGroup"></param>
        internal void AddGroup(SiteGroup newGroup)
        {
            _groups.Add(newGroup);
        }
    }
}
