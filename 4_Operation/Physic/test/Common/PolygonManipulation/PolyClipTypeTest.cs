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
        ///     Tests that intersect enum value should be defined
        /// </summary>
        [Fact]
        public void IntersectEnumValue_ShouldBeDefined()
        {
            PolyClipType type = PolyClipType.Intersect;
            
            Assert.Equal(PolyClipType.Intersect, type);
        }

        /// <summary>
        ///     Tests that union enum value should be defined
        /// </summary>
        [Fact]
        public void UnionEnumValue_ShouldBeDefined()
        {
            PolyClipType type = PolyClipType.Union;
            
            Assert.Equal(PolyClipType.Union, type);
        }

        /// <summary>
        ///     Tests that difference enum value should be defined
        /// </summary>
        [Fact]
        public void DifferenceEnumValue_ShouldBeDefined()
        {
            PolyClipType type = PolyClipType.Difference;
            
            Assert.Equal(PolyClipType.Difference, type);
        }

        /// <summary>
        ///     Tests that poly clip type should have three values
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldHaveThreeValues()
        {
            var values = System.Enum.GetValues(typeof(PolyClipType));
            
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that poly clip type should be castable to int
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldBeCastableToInt()
        {
            int intersectValue = (int)PolyClipType.Intersect;
            int unionValue = (int)PolyClipType.Union;
            int differenceValue = (int)PolyClipType.Difference;
            
            Assert.Equal(0, intersectValue);
            Assert.Equal(1, unionValue);
            Assert.Equal(2, differenceValue);
        }

        /// <summary>
        ///     Tests that poly clip type should support equality comparison
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldSupportEqualityComparison()
        {
            PolyClipType type1 = PolyClipType.Union;
            PolyClipType type2 = PolyClipType.Union;
            
            Assert.Equal(type1, type2);
        }

        /// <summary>
        ///     Tests that poly clip type should support inequality comparison
        /// </summary>
        [Fact]
        public void PolyClipType_ShouldSupportInequalityComparison()
        {
            PolyClipType type1 = PolyClipType.Intersect;
            PolyClipType type2 = PolyClipType.Difference;
            
            Assert.NotEqual(type1, type2);
        }
    }
}

