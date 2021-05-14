using System;
using System.IO;
using System.Threading;
using Org.BouncyCastle.Asn1.Cms;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace Projet_Centrale_Beton
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Pi.Init<BootstrapWiringPi>();
            
            string path = "sqltest.json";
            string JsonContent;
            int exit = 1;
            
            
            CentraleController centrale = new CentraleController();


            //Désérialisation JSON

            JsonConfig config = new JsonConfig();
            if (File.Exists(path))
            {
                JsonContent = File.ReadAllText(path);
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonConfig>(JsonContent);
            }
            else
            {
                config.Default();
            }
            
            MySQLConnector bddConnector = new MySQLConnector(config);
            RS232Controller controller = new RS232Controller(config.sp_scanner);
            IHM lcd = new IHM(config.sp_ihm);
            
            //Début programme de scan

            while (exit != 0)
            {

                Console.WriteLine("En attente de scan...");
                string result = controller.ReadSerialPort();
                
                if (bddConnector.CheckDriverUID(result))
                {
                    Console.WriteLine("Préparation de la commande...");
                    centrale.FirstStage();
                }
            
            }
        }
    }
}