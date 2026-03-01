// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnReleaseKeyTest.cs
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
    ///     Unit tests for the IOnReleaseKey interface.
    ///     Tests the OnReleaseKey lifecycle method for key release detection.
    /// </summary>
    public class IOnReleaseKeyTest
    {
        /// <summary>
        ///     Tests that IOnReleaseKey can be implemented.
        /// </summary>
        [Fact]
        public void IOnReleaseKey_CanBeImplemented()
        {
            ReleaseKeyHandler handler = new ReleaseKeyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnReleaseKey>(handler);
        }

        /// <summary>
        ///     Tests that OnReleaseKey method can be called.
        /// </summary>
        [Fact]
        public void OnReleaseKey_CanBeCalled()
        {
            ReleaseKeyHandler handler = new ReleaseKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.Spacebar, DateTime.UtcNow, TimeSpan.FromMilliseconds(50));
            handler.OnReleaseKey(self, keyInfo);
            Assert.Equal(1, handler.ReleaseCount);
        }

        /// <summary>
        ///     Tests that OnReleaseKey counts releases.
        /// </summary>
        [Fact]
        public void OnReleaseKey_CountsReleases()
        {
            ReleaseKeyHandler handler = new ReleaseKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.W, DateTime.UtcNow, TimeSpan.FromMilliseconds(200));
            handler.OnReleaseKey(self, keyInfo);
            handler.OnReleaseKey(self, keyInfo);
            Assert.Equal(2, handler.ReleaseCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnReleaseKey.
        /// </summary>
        private class ReleaseKeyHandler : IOnReleaseKey
        {
            /// <summary>
            /// Gets or sets the value of the release count
            /// </summary>
            public int ReleaseCount { get; private set; }

            /// <summary>
            /// Ons the release key using the specified info
            /// </summary>
            /// <param name="info">The info</param>
            /// <exception cref="NotImplementedException"></exception>
            public void OnReleaseKey(KeyEventInfo info)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Ons the release key using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="keyInfo">The key info</param>
            public void OnReleaseKey(IGameObject self, KeyEventInfo keyInfo)
            {
                ReleaseCount++;
            }
        }
    }
}