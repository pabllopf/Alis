// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerTest.cs
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
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     Tests for the <see cref="GraphicManager" /> key-state computation methods.
    /// </summary>
    public class GraphicManagerTest
    {
        /// <summary>
        ///     Tests that ComputePressedKeys returns keys in newKeys but not in currentKeys.
        /// </summary>
        [Fact]
        public void ComputePressedKeys_NewKeysOnly_ReturnsAll()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();

            HashSet<ConsoleKey> result = GraphicManager.ComputePressedKeys(newKeys, currentKeys);

            Assert.Equal(2, result.Count);
            Assert.Contains(ConsoleKey.A, result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Tests that ComputePressedKeys excludes keys already in currentKeys.
        /// </summary>
        [Fact]
        public void ComputePressedKeys_KeysAlreadyHeld_NotIncluded()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A };

            HashSet<ConsoleKey> result = GraphicManager.ComputePressedKeys(newKeys, currentKeys);

            Assert.Single(result);
            Assert.Contains(ConsoleKey.B, result);
            Assert.DoesNotContain(ConsoleKey.A, result);
        }

        /// <summary>
        ///     Tests that ComputePressedKeys returns empty when no new keys.
        /// </summary>
        [Fact]
        public void ComputePressedKeys_NoNewKeys_ReturnsEmpty()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A };

            HashSet<ConsoleKey> result = GraphicManager.ComputePressedKeys(newKeys, currentKeys);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputeHeldKeys returns keys present in both sets.
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_OverlappingKeys_ReturnsIntersection()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };

            HashSet<ConsoleKey> result = GraphicManager.ComputeHeldKeys(newKeys, currentKeys);

            Assert.Equal(2, result.Count);
            Assert.Contains(ConsoleKey.A, result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Tests that ComputeHeldKeys returns empty when no overlap.
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_NoOverlap_ReturnsEmpty()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.B };

            HashSet<ConsoleKey> result = GraphicManager.ComputeHeldKeys(newKeys, currentKeys);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputeHeldKeys returns empty when both sets empty.
        /// </summary>
        [Fact]
        public void ComputeHeldKeys_BothEmpty_ReturnsEmpty()
        {
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey>();

            HashSet<ConsoleKey> result = GraphicManager.ComputeHeldKeys(newKeys, currentKeys);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputeReleasedKeys returns keys released since last frame.
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_KeysNoLongerPressed_ReturnsReleased()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A };

            HashSet<ConsoleKey> result = GraphicManager.ComputeReleasedKeys(currentKeys, newKeys);

            Assert.Single(result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Tests that ComputeReleasedKeys returns empty when no keys released.
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_AllKeysStillHeld_ReturnsEmpty()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };

            HashSet<ConsoleKey> result = GraphicManager.ComputeReleasedKeys(currentKeys, newKeys);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ComputeReleasedKeys returns all current keys when newKeys is empty.
        /// </summary>
        [Fact]
        public void ComputeReleasedKeys_NoNewKeys_ReturnsAll()
        {
            HashSet<ConsoleKey> currentKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey>();

            HashSet<ConsoleKey> result = GraphicManager.ComputeReleasedKeys(currentKeys, newKeys);

            Assert.Equal(2, result.Count);
            Assert.Contains(ConsoleKey.A, result);
            Assert.Contains(ConsoleKey.B, result);
        }

        /// <summary>
        ///     Tests that all three methods work together correctly.
        /// </summary>
        [Fact]
        public void KeyStateComputation_EndToEnd_Consistent()
        {
            HashSet<ConsoleKey> prevKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> newKeys = new HashSet<ConsoleKey> { ConsoleKey.B, ConsoleKey.C };

            HashSet<ConsoleKey> pressed = GraphicManager.ComputePressedKeys(newKeys, prevKeys);
            HashSet<ConsoleKey> held = GraphicManager.ComputeHeldKeys(newKeys, prevKeys);
            HashSet<ConsoleKey> released = GraphicManager.ComputeReleasedKeys(prevKeys, newKeys);

            Assert.Single(pressed);
            Assert.Contains(ConsoleKey.C, pressed);

            Assert.Single(held);
            Assert.Contains(ConsoleKey.B, held);

            Assert.Single(released);
            Assert.Contains(ConsoleKey.A, released);
        }
    }
}
