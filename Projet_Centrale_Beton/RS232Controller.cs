using System.IO.Ports;
using System;
using System.ComponentModel;
using System.Linq;
using Org.BouncyCastle.Utilities;

namespace Projet_Centrale_Beton
{
    public class RS232Controller
    {
        private static SerialPort sp;
        private static MySQLConnector bddConnector;
        


        public RS232Controller()
        {
        }
        
        
        
        //TODO Vérifier l'évènement DataReceived pour faire la liaison avec la BDD

        public RS232Controller(string port)
        {
            sp = new SerialPort(port, 9600, Parity.None, 8,StopBits.Two);
            sp.DataReceived +=SpOnDataReceived;
            MySQLConnector bddConnector = new MySQLConnector("10.0.0.111", "test", "root", "");
            OpenConnector();
        }

        private void SpOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp2 = (SerialPort) sender;
            string data = sp2.ReadExisting();
            Console.WriteLine(data);

            //bddConnector.CheckDriverUID(sender.ToString());

        }


        /// <summary>
        /// Ouverture du port RS232 sur le port USB0
        /// </summary>
        private void OpenConnector()
        {
            sp.Open();
        }

        /// <summary>
        /// Fermeture du port RS232
        /// </summary>
        private void CloseConnector()
        {
            sp.Close();
        }

        
        /// <summary>
        /// Méthode pour lister tous les ports disponibles sur la machine Host
        /// </summary>
        public void ListSerialPort()
        {
            OpenConnector();
            
            int length = SerialPort.GetPortNames().Length;
            for(int i = 0; i < length ; i++)
            {
                Console.WriteLine(SerialPort.GetPortNames()[i]);
            }
            
            CloseConnector();
        }
        
        /// <summary>
        /// Retourne un string à l'arrivée d'une info dans le port série
        /// </summary>
        /// <returns></returns>
        public string ReadSerialPort()
        {
            OpenConnector();
            
            string result = sp.ReadLine();
            sp.DiscardInBuffer();

            CloseConnector();
            return result;
        }
        
        
        
    }
}