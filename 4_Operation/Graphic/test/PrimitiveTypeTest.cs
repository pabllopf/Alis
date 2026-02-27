// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrimitiveTypeTest.cs
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
using Alis.Core.Graphic.OpenGL;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// Tests for the PrimitiveType enum validating all geometric primitive types.
    /// </summary>
    public class PrimitiveTypeTest
    {
        /// <summary>
        /// Tests that Points primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void Points_HasCorrectValue_EqualsGlPoints()
        {
            // Arrange & Act
            const int expectedValue = 0x0000;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.Points);
        }

        /// <summary>
        /// Tests that Lines primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void Lines_HasCorrectValue_EqualsGlLines()
        {
            // Arrange & Act
            const int expectedValue = 0x0001;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.Lines);
        }

        /// <summary>
        /// Tests that LineLoop primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void LineLoop_HasCorrectValue_EqualsGlLineLoop()
        {
            // Arrange & Act
            const int expectedValue = 0x0002;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.LineLoop);
        }

        /// <summary>
        /// Tests that LineStrip primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void LineStrip_HasCorrectValue_EqualsGlLineStrip()
        {
            // Arrange & Act
            const int expectedValue = 0x0003;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.LineStrip);
        }

        /// <summary>
        /// Tests that Triangles primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void Triangles_HasCorrectValue_EqualsGlTriangles()
        {
            // Arrange & Act
            const int expectedValue = 0x0004;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.Triangles);
        }

        /// <summary>
        /// Tests that TriangleStrip primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void TriangleStrip_HasCorrectValue_EqualsGlTriangleStrip()
        {
            // Arrange & Act
            const int expectedValue = 0x0005;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.TriangleStrip);
        }

        /// <summary>
        /// Tests that TriangleFan primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void TriangleFan_HasCorrectValue_EqualsGlTriangleFan()
        {
            // Arrange & Act
            const int expectedValue = 0x0006;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.TriangleFan);
        }

        /// <summary>
        /// Tests that Quads primitive type has correct OpenGL value.
        /// </summary>
        [Fact]
        public void Quads_HasCorrectValue_EqualsGlQuads()
        {
            // Arrange & Act
            const int expectedValue = 0x0007;

            // Assert
            Assert.Equal(expectedValue, (int)PrimitiveType.Quads);
        }

        /// <summary>
        /// Tests that all PrimitiveType values are unique.
        /// </summary>
        [Fact]
        public void AllValues_AreUnique_NoConflicts()
        {
            // Arrange
            var values = new[]
            {
                (int)PrimitiveType.Points,
                (int)PrimitiveType.Lines,
                (int)PrimitiveType.LineLoop,
                (int)PrimitiveType.LineStrip,
                (int)PrimitiveType.Triangles,
                (int)PrimitiveType.TriangleStrip,
                (int)PrimitiveType.TriangleFan,
                (int)PrimitiveType.Quads
            };

            // Act
            var uniqueCount = new System.Collections.Generic.HashSet<int>(values).Count;

            // Assert
            Assert.Equal(values.Length, uniqueCount);
        }

        /// <summary>
        /// Tests that PrimitiveType is an enum type.
        /// </summary>
        [Fact]
        public void PrimitiveType_IsEnum_TypeIsCorrect()
        {
            // Arrange & Act
            var enumType = typeof(PrimitiveType);

            // Assert
            Assert.True(enumType.IsEnum);
        }

        /// <summary>
        /// Tests that PrimitiveType enum is public.
        /// </summary>
        [Fact]
        public void PrimitiveType_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            var enumType = typeof(PrimitiveType);

            // Assert
            Assert.True(enumType.IsPublic);
        }

        /// <summary>
        /// Tests that PrimitiveType has 8 defined values.
        /// </summary>
        [Fact]
        public void PrimitiveType_HasEightValues_CountIsCorrect()
        {
            // Arrange
            var enumValues = System.Enum.GetValues(typeof(PrimitiveType));

            // Act & Assert
            Assert.Equal(8, enumValues.Length);
        }

        /// <summary>
        /// Tests that PrimitiveType can be cast to int.
        /// </summary>
        [Fact]
        public void PrimitiveType_CanCastToInt_ConversionIsValid()
        {
            // Arrange & Act
            int value = (int)PrimitiveType.Triangles;

            // Assert
            Assert.IsType<int>(value);
            Assert.Equal(0x0004, value);
        }

        /// <summary>
        /// Tests that PrimitiveType values can be compared.
        /// </summary>
        [Fact]
        public void PrimitiveType_CanCompareValues_EqualityWorks()
        {
            // Arrange & Act
            var triangles1 = PrimitiveType.Triangles;
            var triangles2 = PrimitiveType.Triangles;

            // Assert
            Assert.Equal(triangles1, triangles2);
        }

        /// <summary>
        /// Tests that different PrimitiveType values are not equal.
        /// </summary>
        [Fact]
        public void PrimitiveType_DifferentValues_AreNotEqual()
        {
            // Arrange & Act
            var lines = PrimitiveType.Lines;
            var triangles = PrimitiveType.Triangles;

            // Assert
            Assert.NotEqual(lines, triangles);
        }
    }
}

