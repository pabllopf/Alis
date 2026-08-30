// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditRowCoverageTests.cs
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
    ///     The stb textedit row coverage tests class
    /// </summary>
    public class StbTexteditRowCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have zero values
        /// </summary>
        [Fact]
        public void StbTexteditRow_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            StbTexteditRow row = default(StbTexteditRow);

            Assert.Equal(0f, row.X0, 5);
            Assert.Equal(0f, row.X1, 5);
            Assert.Equal(0f, row.BaselineYDelta, 5);
            Assert.Equal(0f, row.Ymin, 5);
            Assert.Equal(0f, row.Ymax, 5);
            Assert.Equal(0, row.NumChars);
        }

        /// <summary>
        ///     Tests that float properties round trip correctly
        /// </summary>
        [Fact]
        public void StbTexteditRow_FloatProperties_RoundTripCorrectly()
        {
            StbTexteditRow row = default(StbTexteditRow);

            row.X0 = 0.5f;
            row.X1 = 1.5f;
            row.BaselineYDelta = 2.5f;
            row.Ymin = 3.5f;
            row.Ymax = 4.5f;
            row.NumChars = 7;

            Assert.Equal(0.5f, row.X0, 5);
            Assert.Equal(1.5f, row.X1, 5);
            Assert.Equal(2.5f, row.BaselineYDelta, 5);
            Assert.Equal(3.5f, row.Ymin, 5);
            Assert.Equal(4.5f, row.Ymax, 5);
            Assert.Equal(7, row.NumChars);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void StbTexteditRow_IsValueType_CopyIsIndependent()
        {
            StbTexteditRow original = new StbTexteditRow { X0 = 100f };
            StbTexteditRow copy = original;

            copy.X0 = 200f;

            Assert.Equal(100f, original.X0, 5);
            Assert.Equal(200f, copy.X0, 5);
        }
    }
}