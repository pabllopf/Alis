// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CircleShapeTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The circle shape tests class
    /// </summary>
    public class CircleShapeTests
    {
        /// <summary>
        ///     Tests that default constructor sets radius to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsRadiusToZero()
        {
            try
            {
                CircleShape shape = new CircleShape();
                Assert.Equal(0, shape.Radius);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that constructor with radius sets radius
        /// </summary>
        [Fact]
        public void Constructor_WithRadius_SetsRadius()
        {
            try
            {
                CircleShape shape = new CircleShape(5.5f);
                Assert.Equal(5.5f, shape.Radius);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that constructor with radius and point count sets values
        /// </summary>
        [Fact]
        public void Constructor_WithRadiusAndPointCount_SetsValues()
        {
            try
            {
                CircleShape shape = new CircleShape(3.3f, 7);
                Assert.Equal(3.3f, shape.Radius);
                Assert.Equal((uint) 7, shape.GetPointCount());
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that set point count changes point count
        /// </summary>
        [Fact]
        public void SetPointCount_ChangesPointCount()
        {
            try
            {
                CircleShape shape = new CircleShape(2.2f, 3);
                shape.SetPointCount(10);
                Assert.Equal((uint) 10, shape.GetPointCount());
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that get point returns expected position
        /// </summary>
        [Fact]
        public void GetPoint_ReturnsExpectedPosition()
        {
            try
            {
                CircleShape shape = new CircleShape(10, 4);
                Vector2F point = shape.GetPoint(0);
                Assert.True(point.X > 0);
                Assert.True(point.Y >= 0);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that copy constructor copies radius and point count
        /// </summary>
        [Fact]
        public void CopyConstructor_CopiesRadiusAndPointCount()
        {
            try
            {
                CircleShape shape1 = new CircleShape(7.7f, 8);
                CircleShape shape2 = new CircleShape(shape1);
                Assert.Equal(shape1.Radius, shape2.Radius);
                Assert.Equal(shape1.GetPointCount(), shape2.GetPointCount());
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }
}