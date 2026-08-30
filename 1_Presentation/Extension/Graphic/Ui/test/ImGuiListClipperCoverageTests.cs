// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiListClipperCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui list clipper coverage tests class
    /// </summary>
    public class ImGuiListClipperCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have zero values
        /// </summary>
        [Fact]
        public void ImGuiListClipper_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiListClipper clipper = default(ImGuiListClipper);

            Assert.Equal(0, clipper.DisplayStart);
            Assert.Equal(0, clipper.DisplayEnd);
            Assert.Equal(0, clipper.ItemsCount);
            Assert.Equal(0f, clipper.ItemsHeight, 5);
            Assert.Equal(0f, clipper.StartPosY, 5);
            Assert.Equal(IntPtr.Zero, clipper.TempData);
        }

        /// <summary>
        ///     Tests that integer properties round trip correctly
        /// </summary>
        [Fact]
        public void ImGuiListClipper_IntegerProperties_RoundTripCorrectly()
        {
            ImGuiListClipper clipper = default(ImGuiListClipper);

            clipper.DisplayStart = 5;
            clipper.DisplayEnd = 10;
            clipper.ItemsCount = 20;

            Assert.Equal(5, clipper.DisplayStart);
            Assert.Equal(10, clipper.DisplayEnd);
            Assert.Equal(20, clipper.ItemsCount);
        }

        /// <summary>
        ///     Tests that float and pointer properties round trip correctly
        /// </summary>
        [Fact]
        public void ImGuiListClipper_FloatAndPointerProperties_RoundTripCorrectly()
        {
            ImGuiListClipper clipper = default(ImGuiListClipper);

            clipper.ItemsHeight = 25.5f;
            clipper.StartPosY = 30.0f;
            clipper.TempData = new IntPtr(99);

            Assert.Equal(25.5f, clipper.ItemsHeight, 5);
            Assert.Equal(30.0f, clipper.StartPosY, 5);
            Assert.Equal(new IntPtr(99), clipper.TempData);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiListClipper_IsValueType_CopyIsIndependent()
        {
            ImGuiListClipper clipper = new ImGuiListClipper { DisplayStart = 100 };
            ImGuiListClipper copy = clipper;

            copy.DisplayStart = 200;

            Assert.Equal(100, clipper.DisplayStart);
            Assert.Equal(200, copy.DisplayStart);
        }
    }
}