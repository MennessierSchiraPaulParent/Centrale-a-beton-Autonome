using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using Org.BouncyCastle.Asn1.X509;
using Renci.SshNet;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;


///TODO Discuter avec Foray de la forme du RaspBerry dans le système, avec un LCD, ou retentez NFC. 

namespace Projet_Centrale_Beton
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Pi.Init<BootstrapWiringPi>();
            
            string id, database, password, ip, saisie;
            int exit = 1;
            RS232Controller controller = new RS232Controller("/dev/ttyUSB0");
            IHM lcd = new IHM();
            

            ip = "10.0.0.5";
            id = "install";
            password = "";
            database = "centrale_beton";
            
            MySQLConnector bddConnector = new MySQLConnector(ip, database, id, password);



            while (exit != 0)
            {
                Console.WriteLine("1 : Scan code barres");
                Console.WriteLine("2 : Vérification scan BDD d'un scan");
                Console.WriteLine("4 : Test d'écriture sur LCD");
                Console.WriteLine("Voici les ports séries à dispositions :");
                controller.ListSerialPort();
                

                saisie = Console.ReadLine();
                


                switch (saisie)
                {
                    case "1":
                        Console.WriteLine(controller.ReadSerialPort());
                        break;

                    case "2":
                        Console.WriteLine("En attente d'un scan");
                        bddConnector.CheckDriverUID(controller.ReadSerialPort());
                        break;
                    case "3":
                        bddConnector.testConnexion();
                        
                        break;
                    case "4":
                        
                        lcd.EcritureTest();
                        break;


                    case "0":
                        exit = 0;
                        break;

                    default:
                        Console.WriteLine("Erreur de saisie");
                        break;
                }
            }
        }
    }
}