// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatformWindowIconCoverageTests.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    /// <summary>
    ///     Exercises the MacNativePlatform.SetWindowIcon Cocoa path on hosts where the icon
    ///     file does not exist, so the native image load returns nil and the method exits
    ///     through the managed guards without touching the main-thread window APIs.
    /// </summary>
    public class MacNativePlatformWindowIconCoverageTests
    {
        /// <summary>
        ///     Verifies that a non-existent icon path flows through the Cocoa calls and
        ///     returns without throwing.
        /// </summary>
        [Fact]
        public void SetWindowIcon_WithNonExistentPath_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SetWindowIcon("nonexistent_icon_zzz.png");
            Assert.NotNull(platform);
        }
    }
}
#endif