using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace Projet_Centrale_Beton
{
    public class CentraleController
    {
        public CentraleController()
        {
            Pi.Init<BootstrapWiringPi>();
            IHM ihm = new IHM();

        }


        public void FirstStage()
        {
            var port = Pi.Gpio[BcmPin.Gpio16];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);
            
            Thread.Sleep(100);

        }

        public void SecondStage()
        {

            var port = Pi.Gpio[BcmPin.Gpio29];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);
            
            Thread.Sleep(100);

        }

        public void ThirdStage()
        {

            var port = Pi.Gpio[BcmPin.Gpio31];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);
            
            Thread.Sleep(100);

        }
    }
}