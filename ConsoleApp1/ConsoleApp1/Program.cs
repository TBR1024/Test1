using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Tryk en tast for at vise resultat af delopgave 1");
            Console.ReadKey(true);
            Console.WriteLine();

            ShowLatest10Articles();

            Console.WriteLine();
            Console.WriteLine("Tryk en tast for at vise resultat af delopgave 2");
            Console.ReadKey(true);
            Console.WriteLine();

            ShowSitesManagedByFrontpageEditors();

            Console.WriteLine();
            Console.WriteLine("Tryk en tast for afslutte");
            Console.ReadKey(true);
        }

        private static void ShowLatest10Articles()
        {
            var json = ApiCommunication.GetFromMimer(ApiCommunication.ResourceTypes.LatestArticles);

            var articles = Article.GetArticlesFromJson(json);

            foreach (var article in articles.Take(10))
            {
                Console.WriteLine(article.Title);
            }
        }

        private static void ShowSitesManagedByFrontpageEditors()
        {
            var json = ApiCommunication.GetFromMimer(ApiCommunication.ResourceTypes.AllSites);

            var sites = Site.GetSitesFromJson(json);

            foreach (var site in sites.Where(c=>c.SiteInfoCollectionBody == "forside@dr.dk"))
            {
                if(!string.IsNullOrEmpty(site.Title))
                    Console.WriteLine(site.Title);
                else if (!string.IsNullOrEmpty(site.Name))
                    Console.WriteLine(site.Name);
                else 
                    Console.WriteLine("Data mangler");
            }
        }
    }
}