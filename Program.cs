using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Microsoft.AspNetCore.Http;
using System.Net;
//using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Text.Json;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            var jsonTxt= "{\"42\":{\"extId\":{\"name\":\"External ID\",\"type\":\"text\",\"value\":\"7032acf4-3ab7-425e-8e21-38a747452714-00000b20\"},\"modifiedBy\":{\"name\":\"Gewijzigd door\",\"type\":\"text\",\"value\":\"Nic Maes\"},\"modified\":{\"name\":\"Gewijzigd op\",\"type\":\"date\",\"value\":\"2021-12-10T13:21:09.162\"},\"dateProp\":{\"name\":\"Datum veld\",\"type\":\"date\",\"value\":\"2021-12-16T00:00:00.000\"},\"tf\":{\"name\":\"Link Technische Fiche\",\"type\":\"text\",\"value\":\"https://groepvanroey.sharepoint.com/:b:/s/project_981/EY4jg2iBKTxEhmyryMknCr4BgwAYs53D_hUFjigisNclpA?e=zkNfvY\"},\"custom1\":{\"name\":\"Custom 1\",\"type\":\"text\",\"value\":\"custom waardes ingevuld\"},\"custom2\":{\"name\":\"Custom 2\",\"type\":\"text\",\"value\":\"\"}},\"43\":{\"extId\":{\"name\":\"External ID\",\"type\":\"text\",\"value\":\"7032acf4-3ab7-425e-8e21-38a747452714-00000b21\"},\"modifiedBy\":{\"name\":\"Gewijzigd door\",\"type\":\"text\",\"value\":\"Nic Maes\"},\"modified\":{\"name\":\"Gewijzigd op\",\"type\":\"date\",\"value\":\"2021-12-06T08:53:09.899\"},\"dateProp\":{\"name\":\"Datum veld\",\"type\":\"date\",\"value\":\"\"},\"tf\":{\"name\":\"Link Technische Fiche\",\"type\":\"text\",\"value\":\"https://groepvanroey.sharepoint.com/sites/Intranet\"},\"custom1\":{\"name\":\"Custom 1\",\"type\":\"text\",\"value\":\"test\"},\"custom2\":{\"name\":\"Custom 2\",\"type\":\"text\",\"value\":\"andere waarde\"}},\"44\":{\"extId\":{\"name\":\"External ID\",\"type\":\"text\",\"value\":\"7032acf4-3ab7-425e-8e21-38a747452714-00000b22\"},\"modifiedBy\":{\"name\":\"Gewijzigd door\",\"type\":\"text\",\"value\":\"Nic Maes\"},\"modified\":{\"name\":\"Gewijzigd op\",\"type\":\"date\",\"value\":\"2021-12-06T12:48:37.756\"},\"dateProp\":{\"name\":\"Datum veld\",\"type\":\"date\",\"value\":\"2021-12-16T00:00:00.000\"},\"tf\":{\"name\":\"Link Technische Fiche\",\"type\":\"text\",\"value\":\"https://groepvanroey.sharepoint.com/sites/Intranet\"},\"custom1\":{\"name\":\"Custom 1\",\"type\":\"text\",\"value\":\"test\"},\"custom2\":{\"name\":\"Custom 2\",\"type\":\"text\",\"value\":\"andere waarde\"}},\"45\":{\"extId\":{\"name\":\"External ID\",\"type\":\"text\",\"value\":\"7032acf4-3ab7-425e-8e21-38a747452714-00000b23\"},\"modifiedBy\":{\"name\":\"Gewijzigd door\",\"type\":\"text\",\"value\":\"Nic Maes\"},\"modified\":{\"name\":\"Gewijzigd op\",\"type\":\"date\",\"value\":\"2021-12-06T12:48:37.756\"},\"dateProp\":{\"name\":\"Datum veld\",\"type\":\"date\",\"value\":\"2021-12-16T00:00:00.000\"},\"tf\":{\"name\":\"Link Technische Fiche\",\"type\":\"text\",\"value\":\"https://groepvanroey.sharepoint.com/:b:/s/project_981/EY4jg2iBKTxEhmyryMknCr4BgwAYs53D_hUFjigisNclpA?e=zkNfvY\"},\"custom1\":{\"name\":\"Custom 1\",\"type\":\"text\",\"value\":\"andere data\"},\"custom2\":{\"name\":\"Custom 2\",\"type\":\"text\",\"value\":\"\"}},\"2179\":{\"extId\":{\"name\":\"External ID\",\"type\":\"text\",\"value\":\"fba68677-de11-4b76-a42c-512257f5c5cf-00000b23\"},\"modifiedBy\":{\"name\":\"Gewijzigd door\",\"type\":\"text\",\"value\":\"Nic Maes\"},\"modified\":{\"name\":\"Gewijzigd op\",\"type\":\"date\",\"value\":\"2021-12-10T11:01:43.250\"},\"dateProp\":{\"name\":\"Datum veld\",\"type\":\"date\",\"value\":\"2021-12-24T00:00:00.000\"},\"tf\":{\"name\":\"Link Technische Fiche\",\"type\":\"text\",\"value\":\"https://groepvanroey.sharepoint.com/sites/Intranet\"},\"custom1\":{\"name\":\"Custom 1\",\"type\":\"text\",\"value\":\"nog andere waardes aangepast\"},\"custom2\":{\"name\":\"Custom 2\",\"type\":\"text\",\"value\":\"\"}}}";
            var jsonNew = "{\"43\":{\"extId\":{\"name\":\"External ID\",\"type\":\"text\",\"value\":\"666\"},\"modifiedBy\":{\"name\":\"Gewijzigd door\",\"type\":\"text\",\"value\":\"Nic Maes\"},\"modified\":{\"name\":\"Gewijzigd op\",\"type\":\"date\",\"value\":\"2021-12-10T13:21:09.162\"},\"dateProp\":{\"name\":\"Datum veld\",\"type\":\"date\",\"value\":\"2021-12-16T00:00:00.000\"},\"tf\":{\"name\":\"Link Technische Fiche\",\"type\":\"text\",\"value\":\"\"},\"custom1\":{\"name\":\"Custom 1\",\"type\":\"text\",\"value\":\"custom waardes ingevuld\"},\"custom2\":{\"name\":\"Custom 2\",\"type\":\"text\",\"value\":\"\"}}}";


            
            JObject dict = JsonConvert.DeserializeObject<JObject>(jsonTxt);

            JObject dictNew = JObject.Parse(jsonNew);

            if (dict != null)
            {
                //dbIds van aangepaste 
                IList<string> dbIds = dictNew.Properties().Select(p => p.Name).ToList();
                foreach (var key in dbIds)
                {
                   Console.WriteLine(key);
                   //dbId key bestaat in dict
                   if(dict[key] != null){
                        JObject dbId = (JObject)dict[key];
                   }
                   
                }


                Dictionary<string, string> keyValueMap = new Dictionary<string, string>();
                foreach (KeyValuePair<string, JToken> keyValuePair in dict)
                {
                    keyValueMap.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                }
            }

        }
    }
}
