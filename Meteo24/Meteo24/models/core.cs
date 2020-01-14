using System;  // String
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;  // Encoding
using System.Threading.Tasks;
using System.Text.RegularExpressions;  // Regex


namespace Meteo24.models
{
    class Core
    {
        public async Task<string> LoadImage(int row, int col, string lang = "en")
        {
            requests r = new requests();
            string rc = await r.get("https://www.meteo.pl/meteorogram_um_js.php");  // TODO: exceptions
            string fulldate = Regex.Match(rc, "UM_FULLDATE=\"([0-9]+?)\"").Groups[1].Value;  // TODO: exceptions
            return String.Format("https://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&fdate={0}&row={1}&col={2}&lang={3}", fulldate, row, col, lang);
        }
    }
}
