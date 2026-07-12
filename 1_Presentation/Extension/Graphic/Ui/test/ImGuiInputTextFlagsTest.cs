// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiInputTextFlags" /> values.
    /// </summary>
    public class ImGuiInputTextFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiInputTextFlags.None);
        }

        /// <summary>
        ///     Verifies representative flags use distinct bit values.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiInputTextFlags.CharsDecimal, (int) ImGuiInputTextFlags.CharsHexadecimal);
            Assert.NotEqual((int) ImGuiInputTextFlags.ReadOnly, (int) ImGuiInputTextFlags.Password);
            Assert.NotEqual((int) ImGuiInputTextFlags.CallbackResize, (int) ImGuiInputTextFlags.CallbackEdit);
        }
    }
}