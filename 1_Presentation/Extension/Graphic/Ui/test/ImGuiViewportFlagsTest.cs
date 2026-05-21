// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportFlagsTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiViewportFlags" /> values.
    /// </summary>
    public class ImGuiViewportFlagsTest
    {
        /// <summary>
        ///     Verifies that representative viewport flags are distinct values.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiViewportFlags.IsPlatformWindow, (int) ImGuiViewportFlags.IsPlatformMonitor);
            Assert.NotEqual((int) ImGuiViewportFlags.NoInputs, (int) ImGuiViewportFlags.NoRendererClear);
            Assert.NotEqual((int) ImGuiViewportFlags.NoAutoMerge, (int) ImGuiViewportFlags.CanHostOtherWindows);
        }
    }
}