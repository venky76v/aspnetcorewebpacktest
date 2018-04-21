﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace aspnetcorewebpacktest.Webpack
{
    public static class WebpackChunkNamer
    {
        private static Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        public static void Init()
        {
            //using (var fs = File.OpenRead(@"D:\Venky's Dot Net Projects\aspnetcorewebpacktest\aspnetcorewebpacktest\Webpack\stats.json"))
            using (var fs = File.OpenRead("Webpack/stats.json"))
            using (var sr = new StreamReader(fs))
            using (var reader = new JsonTextReader(sr))
            {
                JObject obj = JObject.Load(reader);

                var chunks = obj["assetsByChunkName"];
                foreach (var chunk in chunks)
                {
                    JProperty prop = (JProperty)chunk;
                    Tags.Add(prop.Name, (string)prop.Value);
                }
            }
        }

        public static string GetJsFile(string fileName)
        {
            return Tags[fileName];
        }
    }
}
