// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManagerCatchCoverageTests.cs
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
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Covers the SetResolution failure catch by raising exceptions from the
    ///     public event subscribers, which is the only deterministic path into it
    ///     on a desktop host (SetSize itself never throws).
    /// </summary>
    public class WebAssemblyDisplayManagerCatchCoverageTests
    {
        /// <summary>
        ///     Verifies SetResolution returns false when a display resized subscriber throws.
        /// </summary>
        [Fact]
        public void SetResolution_WhenResizedSubscriberThrows_ReturnsFalse()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.OnDisplayResized += (sender, args) => throw new InvalidOperationException("subscriber failure");

            bool result = manager.SetResolution(1024, 768);

            Assert.False(result);
        }

        /// <summary>
        ///     Verifies SetResolution returns false when an orientation changed subscriber throws.
        /// </summary>
        [Fact]
        public void SetResolution_WhenOrientationSubscriberThrows_ReturnsFalse()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.OnOrientationChanged += (sender, args) => throw new InvalidOperationException("subscriber failure");

            bool result = manager.SetResolution(500, 500);

            Assert.False(result);
        }
    }
}
