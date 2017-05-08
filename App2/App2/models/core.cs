using System;  // String
//using System.Collections.Generic;
//using System.Linq;
using System.Text;  // Encoding
//using System.Threading.Tasks;
using System.Text.RegularExpressions;  // Regex
using System.Net.Http;  // HttpClient

namespace App2.models
{
    class core
    {
        public static string LoadImage()
        {
            var r = new HttpClient();
            r.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            r.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.97 Safari/537.36 Viv/1.10.834.9");
            r.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            //r.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
            //string rc = r.DefaultRequestHeaders.ToString();
            // string rc = await r.GetStringAsync("http://www.meteo.pl/meteorogram_um_js.php");  // works only with utf-8 response
            var a = r.GetAsync("http://www.meteo.pl/meteorogram_um_js.php").Result;
            var buffer = a.Content.ReadAsByteArrayAsync().Result;
            string rc = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            string fulldate = Regex.Match(rc, "UM_FULLDATE=\"([0-9]+?)\"").Groups[1].Value;
            string url = String.Format("http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&fdate={0}&row=406&col=250&lang=en", fulldate);
            //image.Source = url;
            return url;
        }
    }
}
