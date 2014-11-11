using System;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace ZeroLimits.Regainet.Retrieval
{
    /// <summary>
    /// Retrieve webpages with Selenium Web Drivers. 
    /// </summary>
    public class SeleniumRetriever : IRetrievalMethod
    {
        /// <summary>
        /// Add any scripts you would like to run javascipt 
        /// elements on the webpage.
        /// </summary>
        public List<Script> Scripts { get; set; }

        /// <summary>
        /// The amount of time to wait in between javascript 
        /// actions. 
        /// </summary>
        public int ScriptWaitTime { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SeleniumRetriever()
        {
            Scripts = new List<Script>();
        }

        /// <summary>
        /// Goes out to the webserver and fetches the html file after running
        /// the necessary javascript commands.
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlSource(string url)
        {
            // Start a firefox session
            var driver = new FirefoxDriver();
            
            // Make firefox go to the specified url. 
            driver.Navigate().GoToUrl(url);

            // Run all the scripts.
            foreach (var script in Scripts)
            {
                script.RunScript(driver);
                Thread.Sleep(ScriptWaitTime);
            }

            // Save the source code before closing the driver or
            // the source code will be unavailable. 
            String source = driver.PageSource;

            // Close firefox and return the html string
            driver.Quit();

            // Clean up resources if any. 
            driver.Dispose();

            // Return the html source code. 
            return source;
        }
    }
}
