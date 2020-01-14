//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;  // Encoding
using System.Threading.Tasks;
using System.Net.Http;


namespace Meteo24.models
{
    class requests : HttpClient
    {
        public requests()
        {
            this.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            this.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.97 Safari/537.36 Viv/1.10.834.9");
            this.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            //this.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
        }

        public async Task<string> get(string url)
        {
            // string rc = await r.GetStringAsync("http://www.meteo.pl/meteorogram_um_js.php");  // works only with utf-8 response
            var buffer = await this.GetAsync(url);
            var rc = await buffer.Content.ReadAsByteArrayAsync();  // TODO: exceptions
            return Encoding.UTF8.GetString(rc, 0, rc.Length);
        }
    }
}
