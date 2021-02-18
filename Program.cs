using System;
using System.Net;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;

namespace Scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> urls = new List<string>();
            urls.Add("https://www.clubic.com/");

            Script.MapingWebAsync(urls, 0);
            //List<string> newResults = new List<string>();
                
            //results.Select(r => Script.MapingWeb(r));

            //while (true)
            //{
            //    newResults.Clear();

            //    foreach (var result in results)
            //    {
            //        Console.WriteLine(result);
            //        newResults = Script.MapingWeb(result);

            //        //foreach (var newelement in newTest)
            //        //{
            //        //    Console.WriteLine(newelement);
            //        //    results.Add(newelement);
            //        //}
            //    }

            //    results = newResults;
            //}


        }
    }
}
