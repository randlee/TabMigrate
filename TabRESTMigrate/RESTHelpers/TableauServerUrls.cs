using System;
using TabRESTMigrate.FilesLogging;
using TabRESTMigrate.RESTRequests;
using TabRESTMigrate.ServerData;

namespace TabRESTMigrate.RESTHelpers
{
    /// <summary>
    /// Creates the set of server specific URLs
    /// </summary>
    public class TableauServerUrls : ITableauServerSiteInfo
    {
        private readonly ServerVersion _serverVersion;
        /// <summary>
        /// What version of Server do we thing we are talking to? (URLs and APIs may differ)
        /// </summary>
        public ServerVersion ServerVersion => _serverVersion;

        /// <summary>
        /// Url for API login
        /// </summary>
        public string UrlLogin { get; }

        /// <summary>
        /// Template for URL to acess workbooks list
        /// </summary>
        private string _urlListWorkbooksForUserTemplate { get; }
        private string _urlListWorkbookConnectionsTemplate { get; }
        private string _urlListDatasourcesTemplate { get; }
        private string _urlListProjectsTemplate { get; }
        private string _urlListGroupsTemplate { get; }
        private string _urlListUsersTemplate { get; }
        private string _urlListUsersInGroupTemplate { get; }
        private string _urlDownloadWorkbookTemplate { get; }
        private string _urlDownloadDatasourceTemplate { get; }
        private string _urlSiteInfoTemplate { get; }
        private string _urlInitiateUploadTemplate { get; }
        private string _urlAppendUploadChunkTemplate { get; }
        private string _urlFinalizeUploadDatasourceTemplate { get; }
        private string _urlFinalizeUploadWorkbookTemplate { get; }
        private string _urlCreateProjectTemplate { get; }
        private string _urlDeleteWorkbookTagTemplate { get; }
        private string _urlDeleteDatasourceTagTemplate { get; }

        /// <summary>
        /// Server url with protocol
        /// </summary>
        public string ServerUrlWithProtocol { get; }
        public string ServerProtocol { get; }

        /// <summary>
        /// Part of the URL that designates the site id
        /// </summary>
        public string SiteUrlSegement { get; }

        public string ServerName { get; }

        public int PageSize = 1000;
        public const int UploadFileChunkSize = 8000000; //8MB

        public const string 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="serverName"></param>
        /// <param name="siteUrlSegment"></param>
        /// <param name="pageSize"></param>
        /// <param name="serverVersion"></param>
        public TableauServerUrls(string protocol, string serverName, string siteUrlSegment, int pageSize, ServerVersion serverVersion)
        {
            //Cannonicalize the protocol
            protocol = protocol.ToLower();

            ServerProtocol = protocol;

            PageSize = pageSize;
            string serverNameWithProtocol = protocol + serverName;
            _serverVersion = serverVersion;
            SiteUrlSegement = siteUrlSegment;
            ServerName = serverName;
            ServerUrlWithProtocol                 = serverNameWithProtocol;
            UrlLogin                              = $"{serverNameWithProtocol}/api/2.0/auth/signin";
            _urlListWorkbooksForUserTemplate      = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/users/{{iwsUserId}}/workbooks?pageSize={{iwsPageSize}}&pageNumber={{iwsPageNumber}}";
            _urlListWorkbookConnectionsTemplate   = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/workbooks/{{iwsWorkbookId}}/connections";
            _urlListDatasourcesTemplate           = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/datasources?pageSize={{iwsPageSize}}&pageNumber={{iwsPageNumber}}";
            _urlListProjectsTemplate              = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/projects?pageSize={{iwsPageSize}}&pageNumber={{iwsPageNumber}}";
            _urlListGroupsTemplate                = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/groups?pageSize={{iwsPageSize}}&pageNumber={{iwsPageNumber}}";
            _urlListUsersTemplate                 = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/users?pageSize={{iwsPageSize}}&pageNumber={{iwsPageNumber}}";
            _urlListUsersInGroupTemplate          = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/groups/{{iwsGroupId}}/users?pageSize={{iwsPageSize}}&pageNumber={{iwsPageNumber}}"; 
            _urlDownloadDatasourceTemplate        = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/datasources/{{iwsRepositoryId}}/content";
            _urlDownloadWorkbookTemplate          = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/workbooks/{{iwsRepositoryId}}/content";
            _urlSiteInfoTemplate                  = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}";
            _urlInitiateUploadTemplate            = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/fileUploads";
            _urlAppendUploadChunkTemplate         = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/fileUploads/{{iwsUploadSession}}";
            _urlFinalizeUploadDatasourceTemplate  = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/datasources?uploadSessionId={{iwsUploadSession}}&datasourceType={{iwsDatasourceType}}&overwrite=true";
            _urlFinalizeUploadWorkbookTemplate    = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/workbooks?uploadSessionId={{iwsUploadSession}}&workbookType={{iwsWorkbookType}}&overwrite=true";
            _urlCreateProjectTemplate             = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/projects";
            _urlDeleteWorkbookTagTemplate         = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/workbooks/{{iwsWorkbookId}}/tags/{{iwsTagText}}";
            _urlDeleteDatasourceTagTemplate       = $"{serverNameWithProtocol}/api/2.0/sites/{{iwsSiteId}}/datasources/{{iwsDatasourceId}}/tags/{{iwsTagText}}";

            //Any server version specific things we want to do?
            switch (serverVersion)
            {
                case ServerVersion.server8:
                    throw new Exception("This app does not support v8 Server");
                case ServerVersion.server9:
                    break;
                default:
                    AppDiagnostics.Assert(false, "Unknown server version");
                    throw new Exception("Unknown server version");
            }
        }

        //Parse out the http:// or https://
        private static string GetProtocolFromUrl(string url)
        {
            const string protocolIndicator = "://";
            var idxProtocol = url.IndexOf(protocolIndicator);
            if(idxProtocol < 1)
            {
                throw new Exception("No protocol found in " + url);
            }

            string protocol = url.Substring(0, idxProtocol + protocolIndicator.Length);

            return protocol.ToLower();
        }

        /// <summary>
        /// Parse out the server-user and site name from the content URL
        /// </summary>
        /// <param name="userContentUrl">e.g. https://online.tableausoftware.com/t/tableausupport/workbooks</param>
        /// 
        /// <returns></returns>
        public static TableauServerUrls FromContentUrl(string userContentUrl, int pageSize)
        {
            userContentUrl = userContentUrl.Trim();
            string foundProtocol = GetProtocolFromUrl(userContentUrl);

            //Find where the server name ends
            string urlAfterProtocol = userContentUrl.Substring(foundProtocol.Length);
            var urlParts = urlAfterProtocol.Split('/');
            string serverName = urlParts[0];

            string siteUrlSegment;
            ServerVersion serverVersion;
            //Check for the site specifier.  Infer the server version based on this URL
            if(urlParts[1] == "t")
            {
                siteUrlSegment = urlParts[2];
                serverVersion = ServerVersion.server8;
            }
            else if((urlParts[1] == "#") && (urlParts[2] == "site"))
            {
                siteUrlSegment = urlParts[3];
                serverVersion = ServerVersion.server9;
            }
            else if (urlParts[1] == "#")
            {
                siteUrlSegment = ""; //Default site
                serverVersion = ServerVersion.server9;
            }
            else
            {
                throw new Exception("Expected /t site splitter in url");
            }
         
            return new TableauServerUrls(foundProtocol, serverName, siteUrlSegment, pageSize, serverVersion);
        }

        /// <summary>
        /// The URL to get site info
        /// </summary>
        /// <param name="logInInfo"></param>
        /// <returns></returns>
        public string Url_SiteInfo(TableauServerSignIn logInInfo)
        {
            string workingText = _urlSiteInfoTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// The URL to start na upload
        /// </summary>
        /// <param name="logInInfo"></param>
        /// <returns></returns>
        public string Url_InitiateFileUpload(TableauServerSignIn logInInfo)
        {
            string workingText = _urlInitiateUploadTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// The URL to start a upload
        /// </summary>
        /// <param name="logInInfo"></param>
        /// <returns></returns>
        public string Url_AppendFileUploadChunk(TableauServerSignIn logInInfo, string uploadSession)
        {
            string workingText = _urlAppendUploadChunkTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            workingText = workingText.Replace("{{iwsUploadSession}}", uploadSession);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }


        /// <summary>
        /// URL to finish publishing a datasource
        /// </summary>
        /// <param name="logInInfo"></param>
        /// <param name="uploadSession"></param>
        /// <param name="datasourceType"></param>
        /// <returns></returns>
        public string Url_FinalizeDataSourcePublish(TableauServerSignIn logInInfo, string uploadSession, string datasourceType)
        {

            string workingText = _urlFinalizeUploadDatasourceTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            workingText = workingText.Replace("{{iwsUploadSession}}", uploadSession);
            workingText = workingText.Replace("{{iwsDatasourceType}}", datasourceType);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL to finish publishing a datasource
        /// </summary>
        /// <param name="logInInfo"></param>
        /// <param name="uploadSession"></param>
        /// <param name="datasourceType"></param>
        /// <returns></returns>
        public string Url_FinalizeWorkbookPublish(TableauServerSignIn logInInfo, string uploadSession, string workbookType)
        {

            string workingText = _urlFinalizeUploadWorkbookTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            workingText = workingText.Replace("{{iwsUploadSession}}", uploadSession);
            workingText = workingText.Replace("{{iwsWorkbookType}}", workbookType);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for the Workbooks list
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_WorkbooksListForUser(TableauServerSignIn session, string userId, int pageSize, int pageNumber = 1)
        {
            string workingText = _urlListWorkbooksForUserTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsUserId}}", userId);
            workingText = workingText.Replace("{{iwsPageSize}}", pageSize.ToString());
            workingText = workingText.Replace("{{iwsPageNumber}}", pageNumber.ToString());
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for the Workbook's data source connections list
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_WorkbookConnectionsList(TableauServerSignIn session, string workbookId)
        {
            string workingText = _urlListWorkbookConnectionsTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsWorkbookId}}", workbookId);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for a Datasource's connections list
        /// </summary>
        /// <param name="session"></param>
        /// <param name="datasourceId"></param>
        /// <returns></returns>
        internal string Url_DatasourceConnectionsList(TableauServerSignIn session, string datasourceId)
        {
            throw new NotImplementedException("2015-11-16, Tableau Server does not yet have a REST API to support this call");
        }


        /// <summary>
        /// URL for the Datasources list
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_DatasourcesList(TableauServerSignIn session, int pageSize, int pageNumber = 1)
        {
            string workingText = _urlListDatasourcesTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsPageSize}}", pageSize.ToString());
            workingText = workingText.Replace("{{iwsPageNumber}}", pageNumber.ToString());
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for creating a project
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_CreateProject(TableauServerSignIn session)
        {
            string workingText = _urlCreateProjectTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for deleting a tag from a workbook
        /// </summary>
        /// <param name="session"></param>
        /// <param name="workbookId"></param>
        /// <param name="tagText">Tag we want to delete</param>
        /// <returns></returns>
        public string Url_DeleteWorkbookTag(TableauServerSignIn session, string workbookId, string tagText)
        {
            string workingText = _urlDeleteWorkbookTagTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsWorkbookId}}", workbookId);
            workingText = workingText.Replace("{{iwsTagText}}", tagText);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for deleting a tag from a datasource
        /// </summary>
        /// <param name="session"></param>
        /// <param name="workbookId"></param>
        /// <param name="tagText">Tag we want to delete</param>
        /// <returns></returns>
        public string Url_DeleteDatasourceTag(TableauServerSignIn session, string datasourceId, string tagText)
        {
            string workingText = _urlDeleteDatasourceTagTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsDatasourceId}}", datasourceId);
            workingText = workingText.Replace("{{iwsTagText}}", tagText);
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }


        /// <summary>
        /// URL for the Projects list
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_ProjectsList(TableauServerSignIn session, int pageSize, int pageNumber = 1)
        {
            string workingText = _urlListProjectsTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsPageSize}}", pageSize.ToString());
            workingText = workingText.Replace("{{iwsPageNumber}}", pageNumber.ToString());
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for the Groups list
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_GroupsList(TableauServerSignIn session, int pageSize, int pageNumber = 1)
        {
            string workingText = _urlListGroupsTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsPageSize}}", pageSize.ToString());
            workingText = workingText.Replace("{{iwsPageNumber}}", pageNumber.ToString());
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL for the Users list
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_UsersList(TableauServerSignIn logInInfo, int pageSize, int pageNumber = 1)
        {
            string workingText = _urlListUsersTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            workingText = workingText.Replace("{{iwsPageSize}}", pageSize.ToString());
            workingText = workingText.Replace("{{iwsPageNumber}}", pageNumber.ToString());
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL to get the list of Users in a Group
        /// </summary>
        /// <param name="logInInfo"></param>
        /// <param name="groupId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public string Url_UsersListInGroup(TableauServerSignIn logInInfo, string groupId, int pageSize, int pageNumber = 1)
        {
            string workingText = _urlListUsersInGroupTemplate.Replace("{{iwsSiteId}}", logInInfo.SiteId);
            workingText = workingText.Replace("{{iwsGroupId}}", groupId);
            workingText = workingText.Replace("{{iwsPageSize}}", pageSize.ToString());
            workingText = workingText.Replace("{{iwsPageNumber}}", pageNumber.ToString());
            ValidateTemplateReplaceComplete(workingText);

            return workingText;
        }

        /// <summary>
        /// URL to download a workbook
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_WorkbookDownload(TableauServerSignIn session, SiteWorkbook contentInfo)
        {
            string workingText = _urlDownloadWorkbookTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsRepositoryId}}", contentInfo.Id);

            ValidateTemplateReplaceComplete(workingText);
            return workingText;
        }

        /// <summary>
        /// URL to download a datasource
        /// </summary>
        /// <param name="siteUrlSegment"></param>
        /// <returns></returns>
        public string Url_DatasourceDownload(TableauServerSignIn session, SiteDatasource contentInfo)
        {
            string workingText = _urlDownloadDatasourceTemplate;
            workingText = workingText.Replace("{{iwsSiteId}}", session.SiteId);
            workingText = workingText.Replace("{{iwsRepositoryId}}", contentInfo.Id);

            ValidateTemplateReplaceComplete(workingText);
            return workingText;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool ValidateTemplateReplaceComplete(string str)
        {
            if (str.Contains("{{iws"))
            {
                AppDiagnostics.Assert(false, "Template has incomplete parts that need to be replaced");
                return false;
            }

            return true;
        }

        string ITableauServerSiteInfo.ServerName
        {
            get 
            {
                return ServerName; 
            }
        }

        ServerProtocol ITableauServerSiteInfo.Protocol
        {
            get 
            {
                if (ServerProtocol == "https://") return RESTHelpers.ServerProtocol.https;
                if (ServerProtocol == "http://") return RESTHelpers.ServerProtocol.http;
                throw new Exception("Unknown protocol " + ServerProtocol);
            }
        }

        string ITableauServerSiteInfo.SiteId
        {
            get 
            {
                return SiteUrlSegement;
            }
        }

        string ITableauServerSiteInfo.ServerNameWithProtocol
        {
            get
            {
                return ServerUrlWithProtocol;
            }
        }

    }
}
