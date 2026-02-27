// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunctionTypeTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The separation function type test class
    /// </summary>
    public class SeparationFunctionTypeTest
    {
        /// <summary>
        ///     Tests that points enum value should be defined
        /// </summary>
        [Fact]
        public void PointsEnumValue_ShouldBeDefined()
        {
            SeparationFunctionType type = SeparationFunctionType.Points;
            
            Assert.Equal(SeparationFunctionType.Points, type);
        }

        /// <summary>
        ///     Tests that face a enum value should be defined
        /// </summary>
        [Fact]
        public void FaceAEnumValue_ShouldBeDefined()
        {
            SeparationFunctionType type = SeparationFunctionType.FaceA;
            
            Assert.Equal(SeparationFunctionType.FaceA, type);
        }

        /// <summary>
        ///     Tests that face b enum value should be defined
        /// </summary>
        [Fact]
        public void FaceBEnumValue_ShouldBeDefined()
        {
            SeparationFunctionType type = SeparationFunctionType.FaceB;
            
            Assert.Equal(SeparationFunctionType.FaceB, type);
        }

        /// <summary>
        ///     Tests that separation function type should have three values
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldHaveThreeValues()
        {
            var values = System.Enum.GetValues(typeof(SeparationFunctionType));
            
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that separation function type should be castable to int
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldBeCastableToInt()
        {
            int pointsValue = (int)SeparationFunctionType.Points;
            int faceAValue = (int)SeparationFunctionType.FaceA;
            int faceBValue = (int)SeparationFunctionType.FaceB;
            
            Assert.Equal(0, pointsValue);
            Assert.Equal(1, faceAValue);
            Assert.Equal(2, faceBValue);
        }

        /// <summary>
        ///     Tests that separation function type should support equality comparison
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldSupportEqualityComparison()
        {
            SeparationFunctionType type1 = SeparationFunctionType.FaceA;
            SeparationFunctionType type2 = SeparationFunctionType.FaceA;
            
            Assert.Equal(type1, type2);
        }

        /// <summary>
        ///     Tests that separation function type should support inequality comparison
        /// </summary>
        [Fact]
        public void SeparationFunctionType_ShouldSupportInequalityComparison()
        {
            SeparationFunctionType type1 = SeparationFunctionType.Points;
            SeparationFunctionType type2 = SeparationFunctionType.FaceB;
            
            Assert.NotEqual(type1, type2);
        }
    }
}

