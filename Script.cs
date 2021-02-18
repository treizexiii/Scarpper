using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Scrapper
{
    public class Script
    {
        public static void MapingWebAsync(List<string> urls, int index)
        {
            Console.WriteLine(index);
            WebClient client = new WebClient();
            string datas;

            try
            {
                datas = client.DownloadString(urls[index]);
            }
            catch (Exception e)
            {
                if (index <= 0)
                {
                    index = 1;
                }
                Console.WriteLine(urls[index] + ": " + e.Message);
                datas = client.DownloadString(urls[index - 1]);
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(datas);

            var nodes = doc.DocumentNode.SelectNodes("//a");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    if (node.Attributes["href"] != null && node.Attributes["href"].Value.Length >= 5)
                    {
                        if (node.Attributes["href"].Value.Substring(0, 5) == "https")
                        {
                            string[] urlDestruct = node.Attributes["href"].Value.Split('/');
                            var newUrl = "https://" + urlDestruct[2];

                            if (!urls.Any(r => r == newUrl))
                            {
                                Console.WriteLine(newUrl);
                                urls.Add(newUrl);
                                MapingWebAsync(urls, urls.Count - 1);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(urls[index] + ": no link to follow.");
                MapingWebAsync(urls, urls.Count - 2);
            }
        }
    }
}
