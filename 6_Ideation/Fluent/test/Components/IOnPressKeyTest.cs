// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IOnPressKeyTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnPressKey interface.
    ///     Tests the OnPressKey lifecycle method for keyboard input detection.
    /// </summary>
    public class IOnPressKeyTest
    {
        

        /// <summary>
        ///     Helper implementation for testing IOnPressKey.
        /// </summary>
        private class PressKeyHandler : IOnPressKey
        {
            public int PressCount { get; private set; }
            public KeyEventInfo LastKeyEvent { get; private set; }

            public void OnPressKey(IGameObject self, KeyEventInfo keyInfo)
            {
                PressCount++;
                LastKeyEvent = keyInfo;
            }

            public void OnPressKey(KeyEventInfo info)
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        ///     Tests that IOnPressKey can be implemented.
        /// </summary>
        [Fact]
        public void IOnPressKey_CanBeImplemented()
        {
            var handler = new PressKeyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnPressKey>(handler);
        }

        /// <summary>
        ///     Tests that OnPressKey method can be called.
        /// </summary>
        [Fact]
        public void OnPressKey_CanBeCalled()
        {
            var handler = new PressKeyHandler();
            var self = new MockGameObject();
            var keyInfo = new KeyEventInfo(System.ConsoleKey.A, System.DateTime.UtcNow, System.TimeSpan.Zero);
            handler.OnPressKey(self, keyInfo);
            Assert.Equal(1, handler.PressCount);
        }

        /// <summary>
        ///     Tests that OnPressKey records key event.
        /// </summary>
        [Fact]
        public void OnPressKey_RecordsKeyEvent()
        {
            var handler = new PressKeyHandler();
            var self = new MockGameObject();
            var keyInfo = new KeyEventInfo(System.ConsoleKey.Enter, System.DateTime.UtcNow, System.TimeSpan.FromMilliseconds(100));
            handler.OnPressKey(self, keyInfo);
            Assert.Equal(System.ConsoleKey.Enter, handler.LastKeyEvent.Key);
        }

        /// <summary>
        ///     Tests multiple key press events.
        /// </summary>
        [Fact]
        public void OnPressKey_HandlesMultiplePresses()
        {
            var handler = new PressKeyHandler();
            var self = new MockGameObject();
            var keyInfo1 = new KeyEventInfo(System.ConsoleKey.A, System.DateTime.UtcNow, System.TimeSpan.Zero);
            var keyInfo2 = new KeyEventInfo(System.ConsoleKey.B, System.DateTime.UtcNow, System.TimeSpan.Zero);
            handler.OnPressKey(self, keyInfo1);
            handler.OnPressKey(self, keyInfo2);
            Assert.Equal(2, handler.PressCount);
            Assert.Equal(System.ConsoleKey.B, handler.LastKeyEvent.Key);
        }
    }
}

