using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Ciclope.Devices.Camera.Client
{   
    public class AsynchronousClient
    {
        private static String input = String.Empty;
        private static String hostName = "127.0.0.1";        

        private static String SendRequest(String message)
        {
            SocketClient client = new SocketClient();
            return client.Start(hostName, message);
           //return client.Start("127.0.0.1", message);
        }

        public static int Main(String[] args)
        {
            //if (args.Length > 0)
            //    hostName = args[0];

            ConsoleColor preColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Astronomy Cameras Client, v0.5.");
            Console.WriteLine("Developed by Fernando Serena, Ciclope Group. UPM");
            Console.WriteLine("@Copyleft 2012 - All wrongs reserved.");

            Console.ForegroundColor = preColor;  

            while (input != null && input != "exit")
            {
                Console.Write(">");
                input += Console.ReadLine();

                if (input != null && input.Contains(";"))
                {
                    String[] messages = input.Split(';');
                    foreach (String message in messages)
                    {
                        if (message != String.Empty)
                        {
                            try
                            {
                                String response = SendRequest(message + ";");
                                if (!String.IsNullOrEmpty(response))
                                    Console.WriteLine(response);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }

                    input = String.Empty;
                }
            }

            return 0;
        }
    }
}
