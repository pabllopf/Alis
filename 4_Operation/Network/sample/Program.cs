// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Network.Sample.Client.Complex;
using Alis.Core.Network.Sample.Client.Simple;
using Alis.Core.Network.Sample.Server;

namespace Alis.Core.Network.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
    {
        //private static ILogger _logger;
        //private static ILoggerFactory _loggerFactory;

        /// <summary>
        ///     The web socket server factory
        /// </summary>
        private static IWebSocketServerFactory _webSocketServerFactory;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            _webSocketServerFactory = new WebSocketServerFactory();
            Task task = StartWebServer();


            RunComplexTest(args);

            if (args.Length == 0)
            {
                RunSimpleTest().Wait();
            }
            else if (args.Length == 5)
            {
                // ws://localhost:27416/echo 5 1000 5000 40000
            }
            else
            {
                Logger.Log("Wrong number of arguments. 0 for simple test. 5 for complex test.");
                Logger.Log(
                    "Complex Test: uri numThreads numItemsPerThread minNumBytesPerMessage maxNumBytesPerMessage");
                Logger.Log("e.g: ws://localhost:27416/chat/echo 5 100 4 4");
            }

            Logger.Log("Press any key to quit");
            Console.ReadKey();
            task.Wait();
        }

        /// <summary>
        ///     Runs the load test
        /// </summary>
        private static async Task RunLoadTest()
        {
            LoadTest client = new LoadTest();
            await client.Run();
        }

        /// <summary>
        ///     Runs the complex test using the specified args
        /// </summary>
        /// <param name="args">The args</param>
        private static void RunComplexTest(string[] args)
        {
            Uri uri = new Uri("ws://localhost:27416/chat");
            int.TryParse("3", out int numThreads);
            int.TryParse("4", out int numItemsPerThread);
            int.TryParse("256", out int minNumBytesPerMessage);
            int.TryParse("1024", out int maxNumBytesPerMessage);

            Logger.Log(
                $"Started DemoClient with Uri '{uri}' numThreads '{numThreads}' numItemsPerThread '{numItemsPerThread}' minNumBytesPerMessage '{minNumBytesPerMessage}' maxNumBytesPerMessage '{maxNumBytesPerMessage}'");

            TestRunner runner = new TestRunner(uri, numThreads, numItemsPerThread, minNumBytesPerMessage,
                maxNumBytesPerMessage);
            runner.Run();
        }

        /// <summary>
        ///     Runs the simple test
        /// </summary>
        private static async Task RunSimpleTest()
        {
            SimpleClient client = new SimpleClient();
            await client.Run();
        }


        /// <summary>
        ///     Starts the web server
        /// </summary>
        private static async Task StartWebServer()
        {
            try
            {
                int port = 27416;
                IList<string> supportedSubProtocols = new[] {"chatV1", "chatV2", "chatV3"};
                using (WebServer server = new WebServer(_webSocketServerFactory, supportedSubProtocols))
                {
                    await server.Listen(port);
                    Debug.Print($"Listening on port {port}");
                    Debug.Print("Press any key to quit");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}