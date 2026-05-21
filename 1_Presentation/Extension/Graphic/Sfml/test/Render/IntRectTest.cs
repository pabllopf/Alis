// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IntRectTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the IntRect struct.
    /// </summary>
    public class IntRectTest
    {
        /// <summary>
        ///     Tests the constructors and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);
            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Width);
            Assert.Equal(4, rect.Height);
        }

        /// <summary>
        ///     Tests Contains method for points inside and outside.
        /// </summary>
        [Fact]
        public void Contains_Works()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(15, 5));
        }

        /// <summary>
        ///     Tests Intersects method for overlapping and non-overlapping rectangles.
        /// </summary>
        [Fact]
        public void Intersects_Works()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(5, 5, 10, 10);
            IntRect r3 = new IntRect(20, 20, 5, 5);
            Assert.True(r1.Intersects(r2));
            Assert.False(r1.Intersects(r3));
        }

        /// <summary>
        ///     Tests Intersects with overlap output.
        /// </summary>
        [Fact]
        public void Intersects_OverlapOutput_Works()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(5, 5, 10, 10);
            Assert.True(r1.Intersects(r2, out IntRect overlap));
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        ///     Tests ToString returns a non-empty string.
        /// </summary>
        [Fact]
        public void ToString_NotEmpty()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);
            Assert.False(string.IsNullOrWhiteSpace(rect.ToString()));
        }
    }
}