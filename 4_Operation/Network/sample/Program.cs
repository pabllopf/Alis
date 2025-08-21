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
using System.Threading;
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
    public static class Program
    {
        /// <summary>
        ///     The web socket server factory
        /// </summary>
        private static IWebSocketServerFactory _webSocketServerFactory;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            _webSocketServerFactory = new WebSocketServerFactory();
            StartWebServer(cts.Token);

            Logger.Info("Server is running");

            Logger.Log("Running test 'RunLoadTest'");
            RunLoadTest().Wait(cts.Token);

            Logger.Log("Running test 'RunSimpleTest'");
            RunSimpleTest().Wait(cts.Token);

            Logger.Log("Running test 'RunComplexTest'");
            RunComplexTest(args);

            Logger.Warning("Press any key to quit...");

            Thread.Sleep(10000);
            
            // Stop the server
            cts.Cancel();

            return Task.CompletedTask;
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
            Uri uri = new Uri("ws://127.0.0.1:27416/chat");
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
        /// <param name="ctsToken"></param>
        private static async void StartWebServer(CancellationToken ctsToken)
        {
            try
            {
                int port = 27416;
                IList<string> supportedSubProtocols = new[] {"chatV1", "chatV2", "chatV3"};
                using WebServer server = new WebServer(_webSocketServerFactory, supportedSubProtocols);
                Logger.Log($"Listening on port {port}");
                Logger.Log("Press any key to quit");
                await server.Listen(port, ctsToken);
            }
            catch (Exception ex)
            {
                Logger.Exception(ex.ToString());
            }
        }
    }
}