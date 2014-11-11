using System;
using System.Diagnostics;
using System.IO;

namespace ZeroLimits.Regainet.Retrieval
{
    /// <summary>
    /// Retrieves webpages with GNU's WGet
    /// </summary>
    public class WGetRetriever : IRetrievalMethod
    {
        // The name of the temporary file created when downloading a page. 
        private static readonly String FILENAME = "DownloadedPage.html";

        /// <summary>
        /// Returns the html source code with WGet
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlSource(string url)
        {
            string source = String.Empty;

            // Is wget in our working directory?
            if (File.Exists("wget-1.12.exe"))
            {
                // Contains the properties used to start our wget process. 
                ProcessStartInfo startInfo = new ProcessStartInfo();
                
                // Process does not create window.
                startInfo.CreateNoWindow = true;

                // Allows only use of executables in Process.Start()
                startInfo.UseShellExecute = false;
                
                // Name of the process. 
                startInfo.FileName = "wget-1.12.exe";
                
                // Make sure it's not shown. 
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                
                // Save the source to this file. 
                startInfo.Arguments = "-O " + FILENAME + " " + url;

                // Start the process and wait for it to exit. 
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }

                // Read the file line by line and then join them together with newlines. 
                source = string.Join(Environment.NewLine, File.ReadAllLines(FILENAME));
            }

            // Returns the html source code. 
            return source;
        }
    }
}
