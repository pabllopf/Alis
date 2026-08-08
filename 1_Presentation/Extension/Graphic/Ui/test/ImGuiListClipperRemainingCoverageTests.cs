// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiListClipperRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="ImGuiListClipper" /> struct.
    /// </summary>
    public class ImGuiListClipperRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
        [Fact]
        public void Default_ValuesAreZero()
        {
            ImGuiListClipper clipper = default;
            Assert.Equal(0, clipper.DisplayStart);
            Assert.Equal(0, clipper.DisplayEnd);
            Assert.Equal(0, clipper.ItemsCount);
            Assert.Equal(0f, clipper.ItemsHeight, 5);
            Assert.Equal(0f, clipper.StartPosY, 5);
            Assert.Equal(IntPtr.Zero, clipper.TempData);
        }

        /// <summary>
        ///     Verifies that integer properties round-trip.
        /// </summary>
        [Fact]
        public void IntegerProperties_RoundTrip()
        {
            ImGuiListClipper clipper = default;
            clipper.DisplayStart = 5;
            clipper.DisplayEnd = 10;
            clipper.ItemsCount = 20;
            Assert.Equal(5, clipper.DisplayStart);
            Assert.Equal(10, clipper.DisplayEnd);
            Assert.Equal(20, clipper.ItemsCount);
        }

        /// <summary>
        ///     Verifies that float and pointer properties round-trip.
        /// </summary>
        [Fact]
        public void FloatAndPtr_RoundTrip()
        {
            ImGuiListClipper clipper = default;
            clipper.ItemsHeight = 25.5f;
            clipper.StartPosY = 30.0f;
            clipper.TempData = new IntPtr(99);
            Assert.Equal(25.5f, clipper.ItemsHeight, 5);
            Assert.Equal(30.0f, clipper.StartPosY, 5);
            Assert.Equal(new IntPtr(99), clipper.TempData);
        }
    }
}
