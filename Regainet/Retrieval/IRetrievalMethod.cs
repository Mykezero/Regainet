using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroLimits.Regainet.Retrieval
{
    /// <summary>
    /// Supports html code retrieval. 
    /// </summary>
    public interface IRetrievalMethod
    {
        /// <summary>
        /// Returns a webpage's html code. 
        /// </summary>
        /// <param name="url">The url to retrieve the code from. </param>
        /// <returns>The Html Code</returns>
        String GetHtmlSource(String url);
    }
}
