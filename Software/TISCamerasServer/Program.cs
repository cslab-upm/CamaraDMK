using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Ciclope.Utils;
using Ciclope.Devices.ServerEngine;
using Ciclope.Devices.Camera.Server.Requests;
using System.Reflection;
using System.Linq;
using Ciclope.Devices.Camera.Server;

namespace Ciclope.Devices.Camera.Server
{
    public class TISCameraServer
    {
        public static int Main(String[] args)
        {
            ConsoleColor preColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Astronomy Cameras Socket Server, v0.8.11");
            Console.WriteLine("Developed by Fernando Serena, Ciclope Group. UPM");
            Console.WriteLine("Copyleft @ 2012 - All wrongs reserved.");

            Console.ForegroundColor = preColor;

            int port = 11000;

            if (args.Length > 0)
            {
                foreach (String arg in args)
                {
                    if (arg.StartsWith("logpath="))
                    {
                        Log.LogPath = arg.Replace("logpath=", String.Empty);            
                    }
                    else if (arg.StartsWith("port="))
                    {
                        port = Int32.Parse(arg.Replace("port=", String.Empty));            
                    }
                }                
            }

            //////////////Program fails looking for DBx if not connected////////////
            /*TISCameraDriver driverDBK = TISCameraManager.GetReference().getDriver("DBx 41AU02.AS");

            driverDBK.GetProperty(Properties.PropertyType.GAIN).Value = 300;
            driverDBK.GetProperty(Properties.PropertyType.GAMMA).Value = 50;
            driverDBK.GetProperty(Properties.PropertyType.EXPOSURE).Value = 0.00219;

            driverDBK.ImageQuality = 700;

            Console.WriteLine("DBx 41AU02.AS Gamma set to " + driverDBK.GetProperty(Properties.PropertyType.GAMMA).Value);
            Console.WriteLine("DBx 41AU02.AS Exposure set to " + driverDBK.GetProperty(Properties.PropertyType.EXPOSURE).Value);
            Console.WriteLine("DBx 41AU02.AS Gain set to " + driverDBK.GetProperty(Properties.PropertyType.GAIN).Value);*/

            TISCameraDriver driverDMK = TISCameraManager.GetReference().getDriver("DMx 41AU02.AS");

            driverDMK.GetProperty(Properties.PropertyType.EXPOSURE).Value = 0.003;
            driverDMK.GetProperty(Properties.PropertyType.GAIN).Value = 300;
            driverDMK.GetProperty(Properties.PropertyType.GAMMA).Value = 50;

            Console.WriteLine("DMx 41AU02.AS Exposure set to " + driverDMK.GetProperty(Properties.PropertyType.EXPOSURE).Value);
            Console.WriteLine("DMx 41AU02.AS Gamma set to " + driverDMK.GetProperty(Properties.PropertyType.GAMMA).Value);
            Console.WriteLine("DMx 41AU02.AS Gain set to " + driverDMK.GetProperty(Properties.PropertyType.GAIN).Value);
            
            Log.LogFilterLevel = 10;
            SocketServer server = new CameraSocketServer();

            server.StartListening(port);            

            return 0;
        }
    }

}