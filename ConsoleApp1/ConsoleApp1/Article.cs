using System.Collections.Generic;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Article
    {
        public string Urn { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }

        private Article(ArticleJson articleJson)
        {
            Urn = articleJson.Urn;
            Id = articleJson.Id;
            Title = articleJson.Title;
        }

        public static List<Article> GetArticlesFromJson(string json)
        {
            var list = new List<Article>();

            if (json != string.Empty)
            {
                var articleContainer = Newtonsoft.Json.JsonConvert.DeserializeObject<DataJson>(json);

                foreach (var article in articleContainer.Data)
                {
                    list.Add(new Article(article));
                }
            }

            return list;
        }


        private class DataJson
        {
            [JsonProperty("data")]
            public List<ArticleJson> Data { get; set; }
        }

        //[{\"urn\":\"urn:dr:drupal:article:e1e7fbb4-6d2c-481f-8979-1f78f9358942\",\"id\":\"e1e7fbb4-6d2c-481f-8979-1f78f9358942\",\"type\":\"article\",\"published\":true,\"title\":\"Eksperter: Rikke Karlsson involveret i svindel med EU-penge \",\"summary\":\"Det var ifølge eksperter svindel, da den tidligere DF'er Rikke Karlsson udbetalte løn til DF-assistent med EU-penge\",\"url\":\"http:\\/\\/www.dr.dk\\/nyheder\\/politik\\/eksperter-rikke-karlsson-involveret-i-svindel-med-eu-penge\",\"start_date\":\"June 15, 2017 12:01\",\"end_date\":\"June 15, 2017 12:01\",\"changed_date\":\"\",\"date_hidden\":false,\"images\":[{\"id\":\"3db408d0-ea65-4f09-aa87-f35e00ac9fda\",\"title\":\"\",\"mime_type\":\"image\",\"url\":\"https:\\/\\/prod-public-files-cms-dr-dk.s3.amazonaws.com\\/images\\/crop\\/2017\\/06\\/15\\/1497517449_udland_rikke_karlsson_olaf_00005015.jpeg\",\"alt_text\":\"\"}],\"tags\":[]},

        private class ArticleJson
        {
            [JsonProperty("urn")]
            public string Urn { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("published")]
            public string Published { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("start_date")]
            public string StartDdate { get; set; }

            [JsonProperty("end_date")]
            public string EndDate { get; set; }

            [JsonProperty("changed_date")]
            public string ChangedDate { get; set; }

            [JsonProperty("date_hidden")]
            public string DateHidden { get; set; }

            //public string images;
            //public string tags;    
        }
        
    }
}