using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ApiCommunication
    {
        //Help: https://www.dr.dk/tjenester/mimer/help/resources/v3

        private const string MimerUrl = "https://www.dr.dk/tjenester/mimer/api/v3";

        public enum ResourceTypes
        {
            LatestArticles,
            AllSites
        }

        public static string GetFromMimer(ResourceTypes resourceType)
        {
            string resourceString = GetResourceString(resourceType);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MimerUrl + resourceString);
            request.Headers["X-Application-Name"] = "kandidat123";

            return GetResponse(request);
        }

        private static string GetResourceString(ResourceTypes resourceType)
        {
            string resourceString;

            switch (resourceType)
            {
                case ResourceTypes.LatestArticles:
                    resourceString = "/articles/latest.json";
                    break;
                case ResourceTypes.AllSites:
                    resourceString = "/sites.json";
                    break;
                default:
                    resourceString = string.Empty;
                    break;
            }

            return resourceString;
        }

        private static string GetResponse(HttpWebRequest request)
        {
            Task<WebResponse> responseTask = request.GetResponseAsync();
            using (Stream responseStream = responseTask.Result.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}