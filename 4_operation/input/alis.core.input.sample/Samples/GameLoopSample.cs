// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameLoopSample.cs
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
using System.Linq;
using System.Text;
using System.Threading;
using Alis.Core.Input.Controllers;
using Microsoft.Extensions.Logging;

namespace Alis.Core.Input.Sample.Samples
{
    /// <summary>
    ///     The game loop sample class
    /// </summary>
    /// <seealso cref="Sample" />
    public class GameLoopSample : Sample
    {
        /// <inheritdoc />
        public override string Description =>
            "Demonstrates a classic synchronous game loop.";

        /// <inheritdoc />
        protected override void Execute()
        {
            // Create a singleton instance of the controllers object, that we should dispose
            // on closing the game, here we use a using block, but can obviously call controllers.Dispose()
            using Devices devices = new Devices(CreateLogger<Devices>());

            Logger.LogInformation("Press A Button to exit!");

            // Holds a reference to the current gamepad, which is set asynchronously as they are detected.
            Gamepad gamepad = null;
            int batch = 0;

            // Controller to any gamepads as they are found
            using IDisposable subscription = devices.Controllers<Gamepad>().Subscribe(g =>
            {
                // If we already have a connected gamepad ignore any more.
                // ReSharper disable once AccessToDisposedClosure
                if (gamepad?.IsConnected == true)
                {
                    return;
                }

                if (g.Name.ToLowerInvariant().Contains("xbox "))
                {
                    Logger.LogWarning(
                        $"{g.Name} found!  Unfortunately, it appears XInput-compatible HID device driver only transmits events from the HID device whilst the current process has a focussed window, so console applications/background services cannot detect button presses. Please try a different controller.");
                    return;
                }

                // Assign this gamepad and connect to it.
                gamepad = g;
                g.Connect();
                batch = 0;
                Logger.LogInformation($"{gamepad.Name} found!  Following controls were mapped:");
                foreach ((Control control, IReadOnlyList<ControlInfo> infos) in g.Mapping)
                {
                    Logger.LogInformation(
                        $"  {control.Name} => {string.Join(", ", infos.Select(info => info.PropertyName))}");
                }
            });

            long timestamp = 0L;
            try
            {
                // Our 'game loop'
                while (true)
                {
                    // Sleep to simulate a game loop.
                    Thread.Sleep(15);

                    // If we haven't got a gamepad, or the current one isn't connected, wait for a connected gamepad.
                    Gamepad currentGamepad = gamepad;
                    if (currentGamepad?.IsConnected != true)
                    {
                        continue;
                    }

                    // Look for any changes since the last detected change.
                    IReadOnlyList<ControlValue> changes = currentGamepad.ChangesSince(timestamp);
                    if (changes.Count > 0)
                    {
                        StringBuilder logBuilder = new StringBuilder();

                        logBuilder.Append("Batch ").Append(++batch).AppendLine();
                        foreach (ControlValue value in changes)
                        {
                            // We should update our timestamp to the last change we see.
                            if (timestamp < value.Timestamp)
                            {
                                timestamp = value.Timestamp;
                            }

                            string valueStr = value.Value switch
                            {
                                bool b => b ? "Pressed" : "Not Pressed",
                                double d => d.ToString("F3"),
                                null => "<null>",
                                _ => value.Value.ToString()
                            };
                            logBuilder.Append("  ")
                                .Append(value.PropertyName)
                                .Append(": ")
                                .Append(valueStr)
                                .Append(" (")
                                .AppendFormat("{0:F3}", value.Elapsed.TotalMilliseconds).AppendLine("ms)");
                        }

                        Logger.LogInformation(logBuilder.ToString());
                    }


                    // Or directly access controls
                    if (currentGamepad.AButton)
                    {
                        Logger.LogInformation("A Button pressed, finishing.");
                    }

                    if (currentGamepad.BButton)
                    {
                        Logger.LogInformation("B Button pressed, finishing.");
                    }
                }
            }
            finally
            {
                // Ensure gamepad connection is disposed to stop listening to the gamepad
                if (gamepad != null)
                {
                    gamepad.Dispose();
                    Logger.LogInformation($"{gamepad.Device.Name} disconnected!");
                }
            }
        }
    }
}