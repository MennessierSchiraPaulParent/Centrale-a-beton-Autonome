using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Projet_Centrale_Beton
{
    public class JsonConfigSQL
    {
        private string ip { get; set; }
        private string login { get; set; }


        public ArrayList ReadJsonParameters()
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader("sqltest.json"))
            using (var reader = new JsonTextReader(sr))
            {
                object retour = serializer.Deserialize(reader);
                
                return null;
            }
        }
        
    }
}