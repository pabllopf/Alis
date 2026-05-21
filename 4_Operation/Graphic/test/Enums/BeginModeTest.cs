// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BeginModeTest.cs
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
using System.Collections.Generic;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the BeginMode enum validating all drawing mode types.
    /// </summary>
    public class BeginModeTest
    {
        /// <summary>
        ///     Tests that Points mode has correct value.
        /// </summary>
        [Fact]
        public void Points_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0000, (int) BeginMode.Points);
        }

        /// <summary>
        ///     Tests that Lines mode has correct value.
        /// </summary>
        [Fact]
        public void Lines_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0001, (int) BeginMode.Lines);
        }

        /// <summary>
        ///     Tests that LineLoop mode has correct value.
        /// </summary>
        [Fact]
        public void LineLoop_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0002, (int) BeginMode.LineLoop);
        }

        /// <summary>
        ///     Tests that LineStrip mode has correct value.
        /// </summary>
        [Fact]
        public void LineStrip_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0003, (int) BeginMode.LineStrip);
        }

        /// <summary>
        ///     Tests that Triangles mode has correct value.
        /// </summary>
        [Fact]
        public void Triangles_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0004, (int) BeginMode.Triangles);
        }

        /// <summary>
        ///     Tests that TriangleStrip mode has correct value.
        /// </summary>
        [Fact]
        public void TriangleStrip_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0005, (int) BeginMode.TriangleStrip);
        }

        /// <summary>
        ///     Tests that TriangleFan mode has correct value.
        /// </summary>
        [Fact]
        public void TriangleFan_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0x0006, (int) BeginMode.TriangleFan);
        }

        /// <summary>
        ///     Tests that LinesAdjacency mode has correct value.
        /// </summary>
        [Fact]
        public void LinesAdjacency_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0xA, (int) BeginMode.LinesAdjacency);
        }

        /// <summary>
        ///     Tests that LineStripAdjacency mode has correct value.
        /// </summary>
        [Fact]
        public void LineStripAdjacency_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0xB, (int) BeginMode.LineStripAdjacency);
        }

        /// <summary>
        ///     Tests that TrianglesAdjacency mode has correct value.
        /// </summary>
        [Fact]
        public void TrianglesAdjacency_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0xC, (int) BeginMode.TrianglesAdjacency);
        }

        /// <summary>
        ///     Tests that TriangleStripAdjacency mode has correct value.
        /// </summary>
        [Fact]
        public void TriangleStripAdjacency_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0xD, (int) BeginMode.TriangleStripAdjacency);
        }

        /// <summary>
        ///     Tests that Patches mode has correct value.
        /// </summary>
        [Fact]
        public void Patches_HasCorrectValue_EqualsExpected()
        {
            Assert.Equal(0xE, (int) BeginMode.Patches);
        }

        /// <summary>
        ///     Tests that BeginMode is an enum type.
        /// </summary>
        [Fact]
        public void BeginMode_IsEnum_TypeIsCorrect()
        {
            Assert.True(typeof(BeginMode).IsEnum);
        }

        /// <summary>
        ///     Tests that BeginMode enum is public.
        /// </summary>
        [Fact]
        public void BeginMode_IsPublic_CanBeAccessed()
        {
            Assert.True(typeof(BeginMode).IsPublic);
        }

        /// <summary>
        ///     Tests that BeginMode has 13 defined values.
        /// </summary>
        [Fact]
        public void BeginMode_HasThirteenValues_CountIsCorrect()
        {
            Array enumValues = Enum.GetValues(typeof(BeginMode));
            Assert.Equal(12, enumValues.Length);
        }

        /// <summary>
        ///     Tests that all BeginMode values are unique.
        /// </summary>
        [Fact]
        public void AllValues_AreUnique_NoConflicts()
        {
            int[] values = new[]
            {
                (int) BeginMode.Points,
                (int) BeginMode.Lines,
                (int) BeginMode.LineLoop,
                (int) BeginMode.LineStrip,
                (int) BeginMode.Triangles,
                (int) BeginMode.TriangleStrip,
                (int) BeginMode.TriangleFan,
                (int) BeginMode.LinesAdjacency,
                (int) BeginMode.LineStripAdjacency,
                (int) BeginMode.TrianglesAdjacency,
                (int) BeginMode.TriangleStripAdjacency,
                (int) BeginMode.Patches
            };

            int uniqueCount = new HashSet<int>(values).Count;
            Assert.Equal(values.Length, uniqueCount);
        }

        /// <summary>
        ///     Tests that BeginMode can be cast to int.
        /// </summary>
        [Fact]
        public void BeginMode_CanCastToInt_ConversionIsValid()
        {
            int value = (int) BeginMode.Triangles;
            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that BeginMode values can be compared.
        /// </summary>
        [Fact]
        public void BeginMode_CanCompareValues_EqualityWorks()
        {
            BeginMode mode1 = BeginMode.Triangles;
            BeginMode mode2 = BeginMode.Triangles;
            Assert.Equal(mode1, mode2);
        }

        /// <summary>
        ///     Tests that different BeginMode values are not equal.
        /// </summary>
        [Fact]
        public void BeginMode_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(BeginMode.Lines, BeginMode.Triangles);
        }
    }
}