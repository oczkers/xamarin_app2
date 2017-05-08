using System;  // String
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;  // Encoding
//using System.Threading.Tasks;
using System.Text.RegularExpressions;  // Regex


namespace App2.models
{
    class core
    {
        public static string LoadImage()
        {
            requests r = new requests();
            string rc = r.get("http://www.meteo.pl/meteorogram_um_js.php");
            string fulldate = Regex.Match(rc, "UM_FULLDATE=\"([0-9]+?)\"").Groups[1].Value;
            return String.Format("http://www.meteo.pl/um/metco/mgram_pict.php?ntype=0u&fdate={0}&row=406&col=250&lang=en", fulldate);
        }
    }
}
