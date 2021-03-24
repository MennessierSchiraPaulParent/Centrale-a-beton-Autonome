namespace Projet_Centrale_Beton
{
    public class HoneyWellScanner : RS232Controller
    {
        public HoneyWellScanner()
        {
            RS232Controller sp = new RS232Controller("/dev/ttyUSB0");
        }
        
    }
}