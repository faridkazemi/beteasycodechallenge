using dotnet_code_challenge.Helper;
using System.Collections.Generic;
using System.IO;

namespace dotnet_code_challenge.DataProvider
{
    public class SourceProvider : ISourceProvider
    {
        /// <summary>
        /// This should be a Reader set of classes that can read data from different sources, for simplicity we assume all the sources are files in a folder
        /// and their name will always have the key to distinguish the required provider
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllSources()
        {
            var result = new Dictionary<string, string>();
            foreach (var item in Directory.GetFiles(AppSettings.SourcePath))
            {
                result.Add(item, File.ReadAllText(item));
            }
            return result;
        }
    }
}
