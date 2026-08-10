// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager remaining coverage tests class
    /// </summary>
    public class GraphicManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that update key timestamps sets pressed and removes released
        /// </summary>
        [Fact]
        public void UpdateKeyTimestamps_SetsPressedAndRemovesReleased()
        {
            GraphicManager manager = CreateManager();
            DateTime now = DateTime.UtcNow;
            HashSet<ConsoleKey> pressed = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> released = new HashSet<ConsoleKey> { ConsoleKey.B };
            manager.UpdateKeyTimestamps(new HashSet<ConsoleKey> { ConsoleKey.B }, new HashSet<ConsoleKey>(), now);
            manager.UpdateKeyTimestamps(pressed, released, now);

            Assert.True(manager.keyDownTimestamps.ContainsKey(ConsoleKey.A));
            Assert.False(manager.keyDownTimestamps.ContainsKey(ConsoleKey.B));
        }

        /// <summary>
        ///     Tests that compute pressed keys with new keys returns pressed
        /// </summary>
        [Fact]
        public void ComputePressedKeys_WithNewKeys_ReturnsPressed()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.B };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputePressedKeys(newKeys, currentKeys, result);

            Assert.Single(result);
            Assert.Contains(ConsoleKey.A, result);
        }

        /// <summary>
        ///     Tests that compute held keys with common keys returns them
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_WithCommonKeys_ReturnsThem()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.B, ConsoleKey.C };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputeHeldKeys(newKeys, currentKeys, result);

            Assert.Single(result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Tests that compute released keys with removed keys returns them
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_WithRemovedKeys_ReturnsThem()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> result = new HashSet<ConsoleKey>();

            GraphicManager.ComputeReleasedKeys(currentKeys, newKeys, result);

            Assert.Single(result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Creates the manager
        /// </summary>
        /// <returns>The manager</returns>
        private static GraphicManager CreateManager() => new GraphicManager(new Context(new Setting()));
    }
}
