using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using Swan;
using Unosquare.RaspberryIO.Peripherals;

namespace Projet_Centrale_Beton
{
    public class IHM
    {
        private static SerialPort sp;
        private static byte [] debutEcriture;
        private static byte [] finEcriture;
        

        public IHM()
        {
            sp = sp = new SerialPort("/dev/ttyUSB0", 19200, Parity.None, 8,StopBits.One);
        }

        public IHM(string port)
        {
            sp = new SerialPort(port, 9600, Parity.None, 8,StopBits.Two);
        }

        public IHM(JsonConfig config)
        {
            sp = new SerialPort(config.sp_ihm, 9600, Parity.None, 8,StopBits.Two);

        }

        
        /// <summary>
        /// Premier test d'écriture sur le LCD en Liaison série
        /// </summary>
        public void EcritureTest()
        {
            OpenConnector();

            debutEcriture = new  byte[0xA2];
            finEcriture = new byte[0x00];
            string tests = "test ecriture";

            byte[] test = Encoding.UTF8.GetBytes(tests);
            

            sp.Write(debutEcriture,0,0);
            sp.Write(Encoding.UTF8.GetBytes(tests),0,0);
            sp.Write(finEcriture,0,0);
            

            for (int i = 0; i < test.Length; i++)
            {
                /// Voir avec foray pour le code d'écriture
            }
            
            //sp.DiscardInBuffer();
            //sp.WriteLine("0xA0");
            //sp.WriteLine("test écriture");
            
            CloseConnector();
            
        }

        /// <summary>
        /// Ouverture du port série
        /// </summary>
        private void OpenConnector()
        {
            sp.Open();
        }
        
        
        /// <summary>
        /// Fermeture du port série
        /// </summary>
        private void CloseConnector()
        {
            sp.Close();
        }
    }
}