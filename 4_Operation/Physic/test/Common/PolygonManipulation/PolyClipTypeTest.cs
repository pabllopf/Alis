// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolyClipTypeTest.cs
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

using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The poly clip type test class
    /// </summary>
    public class PolyClipTypeTest
    {
        /// <summary>
        ///     Tests that intersect should have value zero
        /// </summary>
        [Fact]
        public void Intersect_ShouldHaveValueZero()
        {
            byte value = 0;
            Assert.Equal(value, (byte) PolyClipType.Intersect);
        }

        /// <summary>
        ///     Tests that union should have value one
        /// </summary>
        [Fact]
        public void Union_ShouldHaveValueOne()
        {
            byte value = 1;
            Assert.Equal(value, (byte) PolyClipType.Union);
        }

        /// <summary>
        ///     Tests that difference should have value two
        /// </summary>
        [Fact]
        public void Difference_ShouldHaveValueTwo()
        {
            byte value = 2;
            Assert.Equal(value, (byte) PolyClipType.Difference);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(PolyClipType.Intersect, PolyClipType.Union);
            Assert.NotEqual(PolyClipType.Intersect, PolyClipType.Difference);
            Assert.NotEqual(PolyClipType.Union, PolyClipType.Difference);
        }
    }
}
