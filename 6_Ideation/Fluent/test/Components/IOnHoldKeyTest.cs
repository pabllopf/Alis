// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnHoldKeyTest.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnHoldKey interface.
    ///     Tests the OnHoldKey lifecycle method for key hold detection.
    /// </summary>
    public class IOnHoldKeyTest
    {
        /// <summary>
        ///     Tests that IOnHoldKey can be implemented.
        /// </summary>
        [Fact]
        public void IOnHoldKey_CanBeImplemented()
        {
            HoldKeyHandler handler = new HoldKeyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnHoldKey>(handler);
        }

        /// <summary>
        ///     Tests that OnHoldKey method can be called.
        /// </summary>
        [Fact]
        public void OnHoldKey_CanBeCalled()
        {
            HoldKeyHandler handler = new HoldKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.A, DateTime.UtcNow, TimeSpan.FromSeconds(1));
            handler.OnHoldKey(self, keyInfo);
            Assert.Equal(1, handler.HoldCount);
        }

        /// <summary>
        ///     Tests that OnHoldKey accumulates hold time.
        /// </summary>
        [Fact]
        public void OnHoldKey_AccumulatesHoldTime()
        {
            HoldKeyHandler handler = new HoldKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo1 = new KeyEventInfo(ConsoleKey.D, DateTime.UtcNow, TimeSpan.FromSeconds(2));
            KeyEventInfo keyInfo2 = new KeyEventInfo(ConsoleKey.D, DateTime.UtcNow, TimeSpan.FromSeconds(1));
            handler.OnHoldKey(self, keyInfo1);
            handler.OnHoldKey(self, keyInfo2);
            Assert.Equal(2, handler.HoldCount);
            Assert.Equal(TimeSpan.FromSeconds(3), handler.TotalHoldTime);
        }


        /// <summary>
        ///     Helper implementation for testing IOnHoldKey.
        /// </summary>
        private class HoldKeyHandler : IOnHoldKey
        {
            public int HoldCount { get; private set; }
            public TimeSpan TotalHoldTime { get; private set; }

            public void OnHoldKey(KeyEventInfo info)
            {
            }

            public void OnHoldKey(IGameObject self, KeyEventInfo keyInfo)
            {
                HoldCount++;
                TotalHoldTime += keyInfo.HoldDuration;
            }
        }
    }
}