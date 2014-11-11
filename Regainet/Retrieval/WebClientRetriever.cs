using System;
using System.Net;

namespace ZeroLimits.Regainet.Retrieval
{
    /// <summary>
    /// Retrieves webpages with C#'s WebClient class. 
    /// </summary>
    public class WebClientRetriever : IRetrievalMethod
    {
        /// <summary>
        /// Returns the html source code with webclient
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlSource(string url)
        {
            string source = String.Empty;

            using (WebClient client = new WebClient())
            {
                source = client.DownloadString(url);
            }

            return source;
        }
    }
}
