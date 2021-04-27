using System;
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
            
            //Pi.Init<BootstrapWiringPi>();
            
            string id, database, password, ip, saisie;
            int exit = 1;
            //RS232Controller controller = new RS232Controller("/dev/ttyUSB1");
            //IHM lcd = new IHM();
            //CentraleController centrale = new CentraleController();


            JsonConfigSQL config = new JsonConfigSQL();
            MySQLConnector connector = new MySQLConnector(config.ReadJsonParameters());
            
            

            /*/////////////
            ip = "10.0.0.111";
            id = "root";
            password = "";
            database = "test";
            
            MySQLConnector bddConnector = new MySQLConnector(ip, database, id, password);

            Thread.Sleep(Timeout.Infinite);
            
            
            
            */ ////////////





            /*
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
            */

        }

        
    }
}