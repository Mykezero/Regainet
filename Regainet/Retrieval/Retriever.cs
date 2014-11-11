using System;
using System.IO;

namespace ZeroLimits.Regainet.Retrieval
{
    /// <summary>
    /// Provides methods to return the hmtl source code of a webpage. 
    /// </summary>
    public class Retriever
    {
        /// <summary>
        /// The retrieval method used to get the webpages html source. 
        /// </summary>
        public IRetrievalMethod RetrievalMethod { get; set; }

        /// <summary>
        /// Constructor 
        /// Sets default retrieval method to WGet. 
        /// </summary>
        public Retriever()
        {
            RetrievalMethod = new WGetRetriever();
        }

        /// <summary>
        /// Saves a webpage to file. Returns false when the webpage couldn't 
        /// be saved or the website could not be reached. 
        /// </summary>
        /// <param name="url">The webpage to save</param>
        /// <returns>True on success</returns>
        public bool SaveHtmlToFile(string url, string filename)
        {
            String source = String.Empty;

            // get the webpage source code. 
            try { source = RetrievalMethod.GetHtmlSource(url); }
            catch (Exception) { return false; }

            // write the source code to file under filename. 
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                sw.WriteLine(source);
            }

            return true;
        }
    }
}
