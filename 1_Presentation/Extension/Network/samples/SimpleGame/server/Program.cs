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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;

namespace Alis.Extension.Network.Sample.SimpleGame.Server
{
    /// <summary>
    ///     The server sample program
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point
        /// </summary>
        /// <param name="args">The args</param>
        public static async Task Main(string[] args)
        {
            try
            {
                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("   ALIS MULTIPLAYER NETWORK SERVER SAMPLE");
                Logger.Info("═══════════════════════════════════════════════════════");

                using (var serverManager = new NetworkServerManager())
                {
                    var config = new NetworkConfig
                    {
                        MaxPlayers = 32,
                        TickRate = 60,
                        ServerAuthoritative = true
                    };

                    await serverManager.InitializeAsync(config);
                    Logger.Info("✓ Server initialized");

                    // Create a session
                    var session = await serverManager.CreateSessionAsync("Main Game", 8);
                    Logger.Info($"✓ Session created: {session.SessionName} (ID: {session.SessionId})");

                    // Register message handlers
                    serverManager.RegisterMessageHandler("game.update", OnGameUpdate);
                    serverManager.RegisterMessageHandler("chat", OnChatMessage);

                    // Register events
                    serverManager.PlayerJoined += (s, e) => Logger.Info($"→ Player joined: {e.Player.PlayerName}");
                    serverManager.PlayerLeft += (s, e) => Logger.Info($"← Player left: {e.Player.PlayerName}");
                    serverManager.Error += (s, e) => Logger.Error($"⚠ Error: {e.Message}");

                    // Start listening
                    var listenUri = new Uri("ws://127.0.0.1:8888/");

                    await serverManager.StartAsync();
                    await serverManager.ListenAsync(listenUri);
                    Logger.Info($"✓ Server listening on {listenUri}");

                    // Keep server running
                    Logger.Info("Press Enter to stop server...");
                    Console.ReadLine();

                    Logger.Info("Stopping server...");
                    await serverManager.StopAsync();
                    Logger.Info("✓ Server stopped");
                }
            }
            catch (Exception ex)
            {
                Logger.Exception($"Fatal error: {ex.Message}");
                Logger.Exception(ex.StackTrace);
            }
        }

        /// <summary>
        ///     Handles game update messages
        /// </summary>
        private static async Task OnGameUpdate(string senderId, string payload)
        {
            Logger.Log($"Game update from {senderId}: {payload.Substring(0, Math.Min(50, payload.Length))}...");
            await Task.CompletedTask;
        }

        /// <summary>
        ///     Handles chat messages
        /// </summary>
        private static async Task OnChatMessage(string senderId, string payload)
        {
            Logger.Log($"Chat from {senderId}: {payload}");
            await Task.CompletedTask;
        }
    }
}