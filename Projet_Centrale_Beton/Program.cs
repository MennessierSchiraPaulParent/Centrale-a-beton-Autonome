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
            
            string id, database, password, ip, saisie;
            string path = @"c:\temp\sqltest.json";
            string JsonContent;
            int exit = 1;
            RS232Controller controller = new RS232Controller("/dev/ttyUSB1");
            IHM lcd = new IHM();
            CentraleController centrale = new CentraleController();


            JsonConfigSQL config = new JsonConfigSQL();
            if (File.Exists(path))
            {
                JsonContent = File.ReadAllText(path);
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonConfigSQL>(JsonContent);
            }
            else
            {
                config.Default();
            }
            
            MySQLConnector bddConnector = new MySQLConnector(config);
            

            
            while (exit != 0)
            {

                Console.WriteLine("En attente de scan...");
                string result = controller.ReadSerialPort();

                if (bddConnector.CheckDriverUID(result))
                {
                    centrale.FirstStage();
                    Console.WriteLine("Préparation de la commande...");
                }
            
            }
            

        }

        
    }
}