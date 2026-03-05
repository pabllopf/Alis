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
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Sample.SimpleChat.Client
{
    /// <summary>
    ///     The client sample program
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
                Logger.Info("   ALIS MULTIPLAYER NETWORK CLIENT SAMPLE");
                Logger.Info("═══════════════════════════════════════════════════════");

                using (var clientManager = new NetworkClientManager())
                {
                    var config = new NetworkConfig
                    {
                        MaxPlayers = 32,
                        TickRate = 60,
                        ServerAuthoritative = true
                    };

                    await clientManager.InitializeAsync(config);
                    Logger.Info("✓ Client initialized");

                    // Register message handlers
                    clientManager.RegisterMessageHandler("game.update", OnGameUpdate);
                    clientManager.RegisterMessageHandler("chat", OnChatMessage);

                    // Register events
                    clientManager.PlayerJoined += (s, e) => Logger.Info($"→ Player joined: {e.Player.PlayerName}");
                    clientManager.PlayerLeft += (s, e) => Logger.Info($"← Player left: {e.Player.PlayerName}");
                    clientManager.Connected += (s, e) => Logger.Info("✓ Connected to server");
                    clientManager.Disconnected += (s, e) => Logger.Info("✗ Disconnected from server");
                    clientManager.Error += (s, e) => Logger.Error($"⚠ Error: {e.Message}");
                    clientManager.ServerMessageReceived += (s, e) => Logger.Log($"Message on channel '{e.Channel}': {e.Message}");

                    await clientManager.StartAsync();

                    // Connect to server
                    var serverUri = new Uri("ws://127.0.0.1:8888/");
                    const string playerName = "TestPlayer";

                    Logger.Info($"Connecting to {serverUri}...");
                    await clientManager.ConnectAsync(serverUri, playerName);
                    Logger.Info("✓ Connected!");

                    // Send test message
                    var testMessage = new GameMessage
                    {
                        MessageType = "greeting",
                        Content = "Hello Server!"
                    };

                    await clientManager.BroadcastMessageAsync("chat", testMessage);
                    Logger.Info("✓ Test message sent");

                    // Keep client running
                    Logger.Info("Press Enter to disconnect...");
                    Console.ReadLine();

                    Logger.Info("Disconnecting...");
                    await clientManager.DisconnectAsync();
                    Logger.Info("✓ Disconnected");
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