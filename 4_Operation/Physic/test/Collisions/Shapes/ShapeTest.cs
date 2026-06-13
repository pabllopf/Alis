// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeTest.cs
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

using Alis.Core.Physic.Collisions.Shapes;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The shape test class
    /// </summary>
    public class ShapeTest
    {
        /// <summary>
        /// Tests that shape type should be accessible
        /// </summary>
        [Fact]
        public void Shape_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(Shape));
        }

        /// <summary>
        /// Tests that circle shape should have correct shape type
        /// </summary>
        [Fact]
        public void CircleShape_ShouldHaveCorrectShapeType()
        {
            CircleShape circle = new CircleShape(1f, 1f);

            Assert.Equal(ShapeType.Circle, circle.ShapeType);
        }

        /// <summary>
        /// Tests that circle shape should have correct child count
        /// </summary>
        [Fact]
        public void CircleShape_ShouldHaveCorrectChildCount()
        {
            CircleShape circle = new CircleShape(1f, 1f);

            Assert.Equal(1, circle.ChildCount);
        }

        /// <summary>
        /// Tests that circle shape should have correct radius
        /// </summary>
        [Fact]
        public void CircleShape_ShouldHaveCorrectRadius()
        {
            CircleShape circle = new CircleShape(2f, 1f);

            Assert.Equal(2f, circle.GetRadius);
        }

        /// <summary>
        /// Tests that circle shape should have correct density
        /// </summary>
        [Fact]
        public void CircleShape_ShouldHaveCorrectDensity()
        {
            CircleShape circle = new CircleShape(1f, 3f);

            Assert.Equal(3f, circle.GetDensity);
        }

        /// <summary>
        /// Tests that circle shape should have mass data
        /// </summary>
        [Fact]
        public void CircleShape_ShouldHaveMassData()
        {
            CircleShape circle = new CircleShape(1f, 1f);

            Assert.NotNull(circle.MassData);
        }

        /// <summary>
        /// Tests that polygon shape should have correct shape type
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldHaveCorrectShapeType()
        {
            PolygonShape polygon = new PolygonShape(1f);

            Assert.Equal(ShapeType.Polygon, polygon.ShapeType);
        }

        /// <summary>
        /// Tests that polygon shape should have correct child count
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldHaveCorrectChildCount()
        {
            PolygonShape polygon = new PolygonShape(1f);

            Assert.Equal(1, polygon.ChildCount);
        }
    }
}
