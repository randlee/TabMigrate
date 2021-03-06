﻿using System;
using System.Net;

namespace TabRESTMigrate.RESTHelpers
{
    /// <summary>
    /// Subclass of the WebClient object that allows use to set a larger/custom timout value so that longer downloads succeed
    /// </summary>
    class TableauServerWebClient : WebClient
    {
        public int WebRequestTimeout { get; }
        public const int DefaultLongRequestTimeOutMs = 15 * 60 * 1000;  //15 minutes * 60 sec/minute * 1000 ms/sec

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeoutMs"></param>
        public TableauServerWebClient(int timeoutMs = DefaultLongRequestTimeOutMs)
        {
            WebRequestTimeout = timeoutMs;
        }

        /// <summary>
        /// Returns a Web Request object (used for download operations) with
        /// our specifically set timeout
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = WebRequestTimeout;
            return request;
        }
    }
}
