using System.Collections.Generic;
using Flow.Launcher.Plugin;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Flow.Launcher.Plugin.SharedCommands;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Reflection;


namespace Flow.Launcher.Plugin.FandomSearch
{
    public class FandomSearch : IAsyncPlugin, ISettingProvider, IContextMenu, IAsyncReloadable
    {
        private PluginInitContext _context;
        private Settings _settings;

        // Define variabkes for the plugin to use
        private List<string> baseUrls = new List<string>();
        private List<string> actionKeywords = new List<string>();
        private string query_url = "ben";
        private string jsonResult;
        private string finalUrl;

        // Path to config file
        public static string AssemblyDirectory { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string DataDirectory { get; } = Path.Combine(AssemblyDirectory, @"..\..\");

        // Path to icon
        private readonly string icon_path = "icon.png";

        // Initialine query url
        public async Task InitAsync(PluginInitContext context)
        {
            GetAllFandoms();
            //query_url = base_url + "api.php?action=query&list=search&srwhat=text&format=json&srsearch=";
            _context = context;
        }

        public async Task<List<Result>> QueryAsync(Query query, CancellationToken token)
        {
            var results = new List<Result>();

            results.Add(new Result
            {
                Title = actionKeywords[0]
            });

            return await Task.FromResult(results);
        } 

       // public async Task<List<Result>> QueryAsync(Query query, CancellationToken token)
       // {
       //     // Make request to terraria wiki api with the query the user has put in
       //     using (var httpClient = new HttpClient())
       //     {
       //         jsonResult = await httpClient.GetStringAsync(query_url + query.Search);
       //     }

       //     // Store the daya
       //     dynamic data = JObject.Parse(jsonResult);
       //     // Also store as a JObject so we can check if it contains the error key
       //     JObject dataObj = JObject.Parse(jsonResult);

       //     // Check if the data has error key (happens when the user has not given an input yet)
       //     if (dataObj.ContainsKey("error"))
       //     {
       //         // Make simple result 
       //         var noResults = new List<Result>
       //         {
       //             new Result
       //             {
       //                 Title = $"Start typing to search the wiki...",
       //                 IcoPath = "icon.png"
       //             }
       //         };
       //         return await Task.FromResult(noResults);
       //     }
       //     else
       //     {
       //         var results = new List<Result>();

       //         // Loop over all the results and make a result item for them all
       //         foreach (var item in data.query.search)
       //         {
       //             string itemStr = item.title;
       //             string itemWithunderscores = itemStr.Replace(" ", "_");

       //             results.Add(new Result
       //             {
       //                 Title = $"{item.title}",
       //                 SubTitle = $"https://terraria.fandom.com/wiki/" + itemWithunderscores,
       //                 Action = e =>
       //                 {
       //                     // Make final url to search
       //                     finalUrl =  "wiki/" + itemWithunderscores;
       //                     finalUrl.OpenInBrowserTab();
       //                     return true;
       //                 },
       //                 IcoPath = "icon.png"
       //             });
       //         }
       //         // Return the results
       //         return await Task.FromResult(results);
       //     }
       // }

        public Control CreateSettingPanel() => new SettingsControl(_settings);

        public List<Result> LoadContextMenus(Result selectedResult)
        {
            var results = new List<Result>
            {

            };

            return results;
        }

        private void GetAllFandoms()
        {
            // Clear all the data so we have a fresh list
            baseUrls.Clear();
            actionKeywords.Clear();

            // Get the path to the settings file
            string fullPath = Path.Combine(Environment.CurrentDirectory, "fandomSettings.json");
            string path = DataDirectory + @"Settings\fandomSettings.json";
            
            JObject jsonData = JObject.Parse(File.ReadAllText(path));
            JArray fandoms = (JArray)jsonData["Fandoms"];

            foreach (JObject fandom in fandoms)
            {
                baseUrls.Add((string)fandom["Url"]);
                actionKeywords.Add((string)fandom["ActionKeyword"]);
            }

        }

        public async Task ReloadDataAsync()
        {
            GetAllFandoms();
        }
    }
}