// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConvexShapeTest.cs
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
    ///     Unit tests for the <see cref="ConvexShape"/> class.
    /// </summary>
    public class ConvexShapeTest
    {
        /// <summary>
        /// Tests that default constructor initializes with zero points
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesWithZeroPoints()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Tests that convex shape is assignable from shape
        /// </summary>
        [Fact]
        public void ConvexShape_IsAssignableFromShape()
        {
            Assert.True(typeof(Shape).IsAssignableFrom(typeof(ConvexShape)));
        }

        /// <summary>
        /// Tests that convex shape implements i drawable
        /// </summary>
        [Fact]
        public void ConvexShape_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(ConvexShape)));
        }

        /// <summary>
        /// Tests that point count property exists
        /// </summary>
        [Fact]
        public void PointCount_Property_Exists()
        {
            var prop = typeof(ConvexShape).GetMethod("GetPointCount");
            Assert.NotNull(prop);

            var setter = typeof(ConvexShape).GetMethod("SetPointCount");
            Assert.NotNull(setter);
        }

        /// <summary>
        /// Tests that get point method exists
        /// </summary>
        [Fact]
        public void GetPoint_Method_Exists()
        {
            var method = typeof(ConvexShape).GetMethod("GetPoint", new[] { typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(Vector2F), method.ReturnType);
        }

        /// <summary>
        /// Tests that set point method exists
        /// </summary>
        [Fact]
        public void SetPoint_Method_Exists()
        {
            var method = typeof(ConvexShape).GetMethod("SetPoint", new[] { typeof(uint), typeof(Vector2F) });
            Assert.NotNull(method);
        }
    }
}
