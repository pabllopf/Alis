// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector4Test.cs
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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     The vector test class
    /// </summary>
    public class Vector4Test
    {
        /// <summary>
        ///     Tests that constructor should set values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetValues()
        {
            // Arrange
            float x = 1;
            float y = 2;
            float z = 3;
            float w = 4;
            
            // Act
            Vector4 vector = new Vector4(x, y, z, w);
            
            // Assert
            Assert.Equal(x, vector.X);
            Assert.Equal(y, vector.Y);
            Assert.Equal(z, vector.Z);
            Assert.Equal(w, vector.W);
        }
        
        /// <summary>
        ///     Tests that get should return correct value
        /// </summary>
        [Fact]
        public void Get_ShouldReturnCorrectValue()
        {
            // Arrange
            Vector4 vector = new Vector4(1, 2, 3, 4);
            
            // Act & Assert
            Assert.Equal(1, Vector4.Get(vector, 0));
            Assert.Equal(2, Vector4.Get(vector, 1));
            Assert.Equal(3, Vector4.Get(vector, 2));
            Assert.Equal(4, Vector4.Get(vector, 3));
        }
        
        /// <summary>
        ///     Tests that get with invalid index should return zero
        /// </summary>
        [Fact]
        public void Get_WithInvalidIndex_ShouldReturnZero()
        {
            // Arrange
            Vector4 vector = new Vector4(1, 2, 3, 4);
            
            // Act & Assert
            Assert.Equal(0, Vector4.Get(vector, 4));
        }
    }
}