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
    /// <summary>
    /// Classe permettant la désérialisation d'un fichier JSON et d'en récupérer ses paramètres.
    /// Ne contient que des variables typés à l'identique du fichier JSON.
    /// </summary>
    public class JsonConfig
    {
        public string adresseIp;
        public string login;
        public string password;
        public string databaseName;
        public string sp_scanner;
        public string sp_ihm;
        
        internal void Default()
        {
            adresseIp = "10.0.0.5";
            login = "install";
            password = "install";
            databaseName = "centrale_beton";
            sp_scanner = "/dev/ttyUSB0";
            sp_ihm = "/dev/ttyUSB1";

        }


    }
}