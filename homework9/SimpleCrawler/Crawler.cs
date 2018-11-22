using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace SimpleCrawler
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl1 = "http://www.conblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl1 = args[0];

            myCrawler.urls.Add(startUrl1, false); //加入初始页面
            Parallel.Invoke(myCrawler.Crawl); 
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了....");
            while (true)
            {
                string current = null;
                foreach(string url in urls.Keys) 
                {
                    if ((bool)urls[url])continue;   //已经下载过的，不再下载
                    current = url;
                }
                //找到一个还没有下载过的连接
                
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面!");

                Task<string> task1 = Task.Run(() => DownLoad(current));
                string html = task1.Result;  //下载

                urls[current] = true;
                count++;
                Parse(html);
            }
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]* =[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
             strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
             if (strRef.Length == 0) continue;

             if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
