using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    public class Site
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SiteInfoCollectionBody { get; set; }

        private Site(SiteJson siteJson)
        {
            Id = siteJson.Id;
            Name = siteJson.Name;
            Title = siteJson.Title;
            SiteInfoCollectionBody = siteJson.SiteInfoCollectionItem.Body;

            //SiteInfoCollectionBody = siteJson.SiteInfoCollection.SelectToken("body").ToString();
        }

        public static List<Site> GetSitesFromJson(string json)
        {
            var list = new List<Site>();

            if (json != string.Empty)
            {
                var siteContainer = Newtonsoft.Json.JsonConvert.DeserializeObject<DataJson>(json);

                foreach (var site in siteContainer.Data)
                {
                    list.Add(new Site(site));
                }
            }

            return list;
        }
        
        private class DataJson
        {
            [JsonProperty("data")]
            public List<SiteJson> Data { get; set; }
        }
        
        private class SiteJson
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("site_info_collection")]
            public JObject SiteInfoCollection
            {
                set => SiteInfoCollectionItem = Newtonsoft.Json.JsonConvert.DeserializeObject<SiteInfoCollectionItemJson>(value.ToString());
            }

            public SiteInfoCollectionItemJson SiteInfoCollectionItem { get; private set; }
        }

        private class SiteInfoCollectionItemJson
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }
        }

    }
}
