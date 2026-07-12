// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiBackendFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiBackendFlags" /> enum values.
    /// </summary>
    public class ImGuiBackendFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that HasGamepad has the expected value of 1.
        /// </summary>
        [Fact]
        public void HasGamepad_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.HasGamepad;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that HasMouseCursors has the expected value of 2.
        /// </summary>
        [Fact]
        public void HasMouseCursors_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.HasMouseCursors;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that HasSetMousePos has the expected value of 4.
        /// </summary>
        [Fact]
        public void HasSetMousePos_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.HasSetMousePos;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that RendererHasVtxOffset has the expected value of 8.
        /// </summary>
        [Fact]
        public void RendererHasVtxOffset_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.RendererHasVtxOffset;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that PlatformHasViewports has the expected value of 1024.
        /// </summary>
        [Fact]
        public void PlatformHasViewports_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.PlatformHasViewports;
            Assert.Equal(1024, (int)flag);
        }

        /// <summary>
        ///     Verifies that HasMouseHoveredViewport has the expected value of 2048.
        /// </summary>
        [Fact]
        public void HasMouseHoveredViewport_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.HasMouseHoveredViewport;
            Assert.Equal(2048, (int)flag);
        }

        /// <summary>
        ///     Verifies that RendererHasViewports has the expected value of 4096.
        /// </summary>
        [Fact]
        public void RendererHasViewports_ShouldHaveCorrectValue()
        {
            ImGuiBackendFlags flag = ImGuiBackendFlags.RendererHasViewports;
            Assert.Equal(4096, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiBackendFlags combined = ImGuiBackendFlags.HasGamepad | ImGuiBackendFlags.HasMouseCursors;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
