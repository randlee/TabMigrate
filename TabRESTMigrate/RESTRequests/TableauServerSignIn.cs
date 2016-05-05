﻿using System;
using System.Xml;
using System.Net;


/// <summary>
/// Manages the signed in session for a Tableau Server site's sign in
/// </summary>
class TableauServerSignIn : TableauServerRequestBase
{
    const string xmlLogIn = "<tsRequest>  <credentials name=\"{{iwsUserName}}\"    password=\"{{iwsPassword}}\" >  <site contentUrl=\"{{iwsSiteUrl}}\" /> </credentials></tsRequest>";

    private readonly TableauServerUrls _onlineUrls;
    private readonly string _userName;
    private readonly string _password;
    public readonly string SiteUrlSegment;
    private string _logInCookies;
    private string _logInToken;
    private string _logInSiteId;
    private string _logInUserId;
    public readonly TaskStatusLogs StatusLog;



    /// <summary>
    /// Synchronous call to test and make sure sign in works
    /// </summary>
    /// <param name="url"></param>
    /// <param name="userId"></param>
    /// <param name="userPassword"></param>
    /// <param name="statusLog"></param>
    public static void VerifySignInPossible(string url, string userId, string userPassword, TaskStatusLogs statusLog)
    {
        var urlManager = TableauServerUrls.FromContentUrl(url, TaskMasterOptions.RestApiReponsePageSizeDefault);
        var signIn = new TableauServerSignIn(urlManager, userId, userPassword, statusLog);
        bool success = signIn.ExecuteRequest();

        if(!success)
        {
            throw new Exception("Failed sign in");
        }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="onlineUrls"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="statusLog"></param>
    public TableauServerSignIn(TableauServerUrls onlineUrls, string userName, string password, TaskStatusLogs statusLog)
    {
        if (statusLog == null) { statusLog = new TaskStatusLogs(); }
        this.StatusLog = statusLog;

        _onlineUrls = onlineUrls;
        _userName = userName;
        _password = password;
        SiteUrlSegment = onlineUrls.SiteUrlSegement;
    }

    public string LogInCookies
    {
        get
        {
            return _logInCookies;
        }
    }
    public string LogInAuthToken
    {
        get
        {
            return _logInToken;
        }
    }
    public string SiteId
    {
        get
        {
            return _logInSiteId;
        }
    }
    public string UserId
    {
        get
        {
            return _logInUserId;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="serverName"></param>
    public bool ExecuteRequest()
    {
        var webRequest = WebRequest.Create(_onlineUrls.UrlLogin);
        string bodyText = xmlLogIn;
        bodyText = bodyText.Replace("{{iwsUserName}}", _userName);
        bodyText = bodyText.Replace("{{iwsPassword}}", _password);
        bodyText = bodyText.Replace("{{iwsSiteUrl}}", SiteUrlSegment);
        AssertTemplateFullyReplaced(bodyText);

        //===============================================================================================
        //Make the sign in request, trap and note, and rethrow any errors
        //===============================================================================================
        try
        {
            SendPostContents(webRequest, bodyText);
        }
        catch (Exception exSendRequest)
        {
            this.StatusLog.AddError("Error sending sign in request: " + exSendRequest.ToString());
            throw exSendRequest;
        }


        //===============================================================================================
        //Get the web response, trap and note, and rethrow any errors
        //===============================================================================================
        WebResponse response;
        try
        {
            response = webRequest.GetResponse();
        }
        catch(Exception exResponse)
        {
            this.StatusLog.AddError("Error returned from sign in response: " + exResponse.ToString());
            throw exResponse;
        }

        var allHeaders = response.Headers;
        var cookies = allHeaders["Set-Cookie"];
        _logInCookies = cookies; //Keep any cookies

        //===============================================================================================
        //Get the web response's XML payload, trap and note, and rethrow any errors
        //===============================================================================================
        XmlDocument xmlDoc;
        try
        {
            xmlDoc = GetWebResponseAsXml(response);
        }
        catch (Exception exSignInResponse)
        {
            this.StatusLog.AddError("Error returned from sign in xml response: " + exSignInResponse.ToString());
            throw exSignInResponse;
        }

        var nsManager = XmlHelper.CreateTableauXmlNamespaceManager("iwsOnline");
        var credentialNode = xmlDoc.SelectSingleNode("//iwsOnline:credentials", nsManager);
        var siteNode = xmlDoc.SelectSingleNode("//iwsOnline:site", nsManager);
        _logInSiteId = siteNode.Attributes["id"].Value;
        _logInToken = credentialNode.Attributes["token"].Value;

        //Adding the UserId to the log-in return was a feature that was added late in the product cycle.
        //For this reason this code is going to defensively look to see if hte attribute is there
        var userNode = xmlDoc.SelectSingleNode("//iwsOnline:user", nsManager);
        string userId = null;
        if(userNode != null)
        {
            var userIdAttribute =  userNode.Attributes["id"];
            if(userIdAttribute != null)
            {
                userId = userIdAttribute.Value;
            }
            _logInUserId = userId;
        }

        //Output some status text...
        if(!string.IsNullOrWhiteSpace(userId))
        {
            this.StatusLog.AddStatus("Log-in returned user id: '" + userId + "'", -10);
        }
        else
        {
            this.StatusLog.AddStatus("No User Id returned from log-in request");
            return false;  //Failed sign in
        }

        return true; //Success
    }
}
