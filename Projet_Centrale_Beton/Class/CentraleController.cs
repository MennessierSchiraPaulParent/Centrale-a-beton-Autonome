using System;
using System.IO;
using System.Threading;
using Phidget22;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace Projet_Centrale_Beton
{
    public class CentraleController
    {
        private string result;
        private RS232Controller controller;
        private IHM lcd;
        private MySQLConnector bddConnector;
        

        public CentraleController()
        {

        }

        public void Run()
        {
            string path = "sqltest.json";
            string JsonContent;

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
            
            //Construction des objets
            
            bddConnector = new MySQLConnector(config);
            controller = new RS232Controller(config.sp_scanner);
            lcd = new IHM(config.sp_ihm);
            
            int exit = 1;

            if(exit != 0)
            {
                lcd.WriteWaitScan();
                Console.WriteLine("attente de scan");
                result = controller.ReadSerialPort();

                if (bddConnector.CheckDriverUID(result))
                {
                    lcd.WriteStateScan("Production de la commande");
                    FirstStage();
                    Thread.Sleep(1000);
                    Console.WriteLine("Debut déplacement commande");
                    Thread.Sleep(1000);
                    FinishedOrder();
                }
                else
                {
                    lcd.WriteWaitScan();
                }
            }

        }


        private void FirstStage()
        {
            var port = Pi.Gpio[BcmPin.Gpio29];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);

            Thread.Sleep(100);

        }

        private void SecondStage()
        {

            var port = Pi.Gpio[BcmPin.Gpio29];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);
            
            Thread.Sleep(100);

        }

        private void ThirdStage()
        {

            var port = Pi.Gpio[BcmPin.Gpio31];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);
            
            Thread.Sleep(100);

        }

        /// <summary>
        /// Méthode indiquant la fin de la commande.
        /// Ecriture de fin et pause 10s
        /// </summary>
        private void FinishedOrder()
        {
            lcd.WriteStateScan("Fin de la commande");
            bddConnector.SwitchTables(result);
            Thread.Sleep(1000);
            
        }
    }
}