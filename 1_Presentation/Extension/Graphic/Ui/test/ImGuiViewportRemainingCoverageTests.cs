// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui viewport remaining coverage tests class
    /// </summary>
    public class ImGuiViewportRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default id should be zero
        /// </summary>
        [Fact]
        public void DefaultId_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(0u, viewport.Id);
        }

        /// <summary>
        ///     Tests that default flags should be none
        /// </summary>
        [Fact]
        public void DefaultFlags_ShouldBeNone()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(ImGuiViewportFlags), viewport.Flags);
        }

        /// <summary>
        ///     Tests that default pos should be zero
        /// </summary>
        [Fact]
        public void DefaultPos_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(Vector2F), viewport.Pos);
        }

        /// <summary>
        ///     Tests that default size should be zero
        /// </summary>
        [Fact]
        public void DefaultSize_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(default(Vector2F), viewport.Size);
        }

        /// <summary>
        ///     Tests that default dpi scale should be zero
        /// </summary>
        [Fact]
        public void DefaultDpiScale_ShouldBeZero()
        {
            ImGuiViewport viewport = default;
            Assert.Equal(0f, viewport.DpiScale);
        }

        /// <summary>
        ///     Tests that id set and get returns correct value
        /// </summary>
        [Fact]
        public void Id_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.Id = 42u;
            Assert.Equal(42u, viewport.Id);
        }

        /// <summary>
        ///     Tests that flags set and get returns correct value
        /// </summary>
        [Fact]
        public void Flags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.Flags = ImGuiViewportFlags.TopMost;
            Assert.Equal(ImGuiViewportFlags.TopMost, viewport.Flags);
        }

        /// <summary>
        ///     Tests that pos set and get returns correct value
        /// </summary>
        [Fact]
        public void Pos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            Vector2F value = new Vector2F(1.0f, 2.0f);
            viewport.Pos = value;
            Assert.Equal(value, viewport.Pos);
        }

        /// <summary>
        ///     Tests that size set and get returns correct value
        /// </summary>
        [Fact]
        public void Size_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            Vector2F value = new Vector2F(3.0f, 4.0f);
            viewport.Size = value;
            Assert.Equal(value, viewport.Size);
        }

        /// <summary>
        ///     Tests that dpi scale set and get returns correct value
        /// </summary>
        [Fact]
        public void DpiScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiViewport viewport = default;
            viewport.DpiScale = 1.5f;
            Assert.Equal(1.5f, viewport.DpiScale);
        }
    }
}
