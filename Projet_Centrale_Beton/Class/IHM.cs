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
        private readonly byte [] debutEcriture = {0xA2};
        private readonly byte [] finEcriture = {0x00};
        private readonly byte[] clear = {0xA3, 0x01};
        

        public IHM()
        {
            sp = sp = new SerialPort("/dev/ttyUSB0", 19200, Parity.None, 8,StopBits.One);
        }

        public IHM(string port)
        {
            sp = new SerialPort(port, 19200, Parity.None, 8,StopBits.Two);
        }

        public IHM(JsonConfig config)
        {
            sp = new SerialPort(config.sp_ihm, 19200, Parity.None, 8,StopBits.Two);

        }


        /// <summary>
        /// Premier test d'écriture sur le LCD en Liaison série
        /// </summary>
        private void EcritureTest()
        {
            OpenConnector();

            

            string tests = "bonjour a vous";

            byte[] test = Encoding.UTF8.GetBytes(tests);
            
            sp.Write(clear,0,clear.Length);
            

            sp.Write(debutEcriture,0,1);
            sp.Write(test,0,test.Length);
            sp.Write(finEcriture,0,1);

            CloseConnector();
            
        }

        /// <summary>
        /// Méthode permettant l'écriture de l'attente de scan sur l'afficheur LCD
        /// </summary>
        public void WriteWaitScan()
        {
            OpenConnector();
            
            string saisie = "En attente de scan...";
            byte[] envoie = Encoding.UTF8.GetBytes(saisie);
            
            sp.Write(clear,0,clear.Length);
            sp.Write(debutEcriture,0,1);
            sp.Write(envoie,0,envoie.Length);
            sp.Write(finEcriture,0,1);

            CloseConnector();
        }

        
        /// <summary>
        /// Méthode permettant la saisie de l'état de la commande,
        /// avec un string en paramètre qui sera écris sur l'afficheur
        /// </summary>
        /// <param name="saisie"></param>
        public void WriteStateScan(string saisie)
        {
            OpenConnector();

            byte[] envoie = Encoding.UTF8.GetBytes(saisie);
            
            sp.Write(clear,0,clear.Length);
            sp.Write(debutEcriture,0,1);
            sp.Write(envoie,0,envoie.Length);
            sp.Write(finEcriture,0,1);

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