using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Projet_Centrale_Beton
{
    public class JsonConfigSQL
    {
        private string ip;
        private string login;

        private string parametersString;
        


        public string ReadJsonParameters()
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(@"c:\temp\sqltest.json"))
            using (var reader = new JsonTextReader(sr))
            {
                
                JObject rss = JObject.Parse(reader.ReadAsString());

                parametersString.Insert(0,(string) rss["adresseIp"]);
                Console.WriteLine((string)rss["adresseIp"]);
                
                
                
                return parametersString;
            }
        }
        
    }
}