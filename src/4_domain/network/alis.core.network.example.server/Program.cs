// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Program.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Network.Exceptions.Example.Server
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
        }
        
        /*
        /// <summary>
        ///     The logger
        /// </summary>
        private static ILogger _logger;

        /// <summary>
        ///     The logger factory
        /// </summary>
        private static ILoggerFactory _loggerFactory;

        /// <summary>
        ///     The web socket server factory
        /// </summary>
        private static IWebSocketServerFactory _webSocketServerFactory;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddConsole(LogLevel.Trace);
            _logger = _loggerFactory.CreateLogger<Program>();
            _webSocketServerFactory = new WebSocketServerFactory();
            Task task = StartWebServer();
            task.Wait();
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
                using (WebServer server = new WebServer(_webSocketServerFactory, _loggerFactory, supportedSubProtocols))
                {
                    await server.Listen(port);
                    _logger.LogInformation($"Listening on port {port}");
                    _logger.LogInformation("Press any key to quit");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                Console.ReadKey();
            }
        }*/
    }
}