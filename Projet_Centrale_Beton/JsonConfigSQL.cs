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
        public string adresseIp;
        public string login;
        public string password;
        public string databaseName;
        
        internal void Default()
        {
            adresseIp = "192.168.1.1";
            login = "test";
            password = "";
            databaseName = "test";

        }


    }
}