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

        }


        public void FirstStage()
        {
            var port = Pi.Gpio[BcmPin.Gpio27];
            port.PinMode = GpioPinDriveMode.Output;
            port.Write(true);
            
            Thread.Sleep(100);

        }
    }
}