using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace program1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private static int n = 0;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            myCrawler.Crawl();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了。。。");

            while (true)
            {
                string[] now = new string[urls.Count - n];
                int j = 0;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    now[j] = url;
                    j++;
                    if (j > 8) break;
                }
                n = n + j;
                if (n > 10) break;

                Parallel.For(0, j, i =>
                {
                    Console.WriteLine("爬行" + now[i] + "页面");
                    string d = DownLoad(now[i]);
                    Prase(d);
                });
                Console.WriteLine("集体爬行");

                for (int i = 0; i < j; i++)
                {
                    urls[now[i]] = true;
                }
                if (n > 10) break;

            }

            Console.WriteLine("爬行结束！");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                count++;
                string filenName = count.ToString();

                File.WriteAllText(filenName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Prase(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');

                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
