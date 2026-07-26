// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditRowRemainingCoverageTests.cs
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
    ///     The stb textedit row remaining coverage tests class
    /// </summary>
    public class StbTexteditRowRemainingCoverageTests
    {
        [Fact]
        public void DefaultX0_ShouldBeZero()
        {
            StbTexteditRow row = default;
            Assert.Equal(0f, row.X0);
        }

        [Fact]
        public void DefaultX1_ShouldBeZero()
        {
            StbTexteditRow row = default;
            Assert.Equal(0f, row.X1);
        }

        [Fact]
        public void DefaultBaselineYDelta_ShouldBeZero()
        {
            StbTexteditRow row = default;
            Assert.Equal(0f, row.BaselineYDelta);
        }

        [Fact]
        public void DefaultYmin_ShouldBeZero()
        {
            StbTexteditRow row = default;
            Assert.Equal(0f, row.Ymin);
        }

        [Fact]
        public void DefaultYmax_ShouldBeZero()
        {
            StbTexteditRow row = default;
            Assert.Equal(0f, row.Ymax);
        }

        [Fact]
        public void DefaultNumChars_ShouldBeZero()
        {
            StbTexteditRow row = default;
            Assert.Equal(0, row.NumChars);
        }

        [Fact]
        public void X0_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditRow row = default;
            row.X0 = 1.5f;
            Assert.Equal(1.5f, row.X0);
        }

        [Fact]
        public void X1_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditRow row = default;
            row.X1 = 2.5f;
            Assert.Equal(2.5f, row.X1);
        }

        [Fact]
        public void BaselineYDelta_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditRow row = default;
            row.BaselineYDelta = 3.5f;
            Assert.Equal(3.5f, row.BaselineYDelta);
        }

        [Fact]
        public void Ymin_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditRow row = default;
            row.Ymin = 4.5f;
            Assert.Equal(4.5f, row.Ymin);
        }

        [Fact]
        public void Ymax_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditRow row = default;
            row.Ymax = 5.5f;
            Assert.Equal(5.5f, row.Ymax);
        }

        [Fact]
        public void NumChars_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditRow row = default;
            row.NumChars = 10;
            Assert.Equal(10, row.NumChars);
        }
    }
}
