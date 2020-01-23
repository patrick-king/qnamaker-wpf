using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Interop;

namespace QnAMakerRuntimeAPI.Providers
{
    /// <summary>
    /// Used to resolve paths to network or locally-stored help documents.
    /// </summary>
    public class DocumentLibrary
    {

        private static string LOCAL_HELP_PATH = @"C:\Work\HelpfulInfo\";

        public DocumentLibrary(IConfiguration config)
        {
            LOCAL_HELP_PATH = config["HelpDocumentsPath"];
        }
        /// <summary>
        /// Retrieves the user-accessible document name for the given document
        /// </summary>
        /// <param name="azSearchDocName"></param>
        /// <returns></returns>
        public string GetDocumentURI(string azSearchDocName)
        {
            if (string.IsNullOrEmpty(azSearchDocName))
            {
                return null;
            }
            else
            {
                return Path.Combine(LOCAL_HELP_PATH, azSearchDocName);
            }
        }
    }
}
