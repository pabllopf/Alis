// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConvexShapeTests.cs
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
    ///     The convex shape tests class
    /// </summary>
    public class ConvexShapeTests
    {
        /// <summary>
        ///     Tests that constructor sets point count
        /// </summary>
        [Fact]
        public void Constructor_SetsPointCount()
        {
            ConvexShape shape = new ConvexShape(3);
            Assert.Equal((uint) 3, shape.GetPointCount());
        }

        /// <summary>
        ///     Tests that set point count changes point count
        /// </summary>
        [Fact]
        public void SetPointCount_ChangesPointCount()
        {
            ConvexShape shape = new ConvexShape(2);
            shape.SetPointCount(5);
            Assert.Equal((uint) 5, shape.GetPointCount());
        }

        /// <summary>
        ///     Tests that set and get point works
        /// </summary>
        [Fact]
        public void SetAndGetPoint_Works()
        {
            ConvexShape shape = new ConvexShape(2);
            Vector2F p = new Vector2F(1, 2);
            shape.SetPoint(0, p);
            Assert.Equal(p, shape.GetPoint(0));
        }

        /// <summary>
        ///     Tests that copy constructor copies points
        /// </summary>
        [Fact]
        public void CopyConstructor_CopiesPoints()
        {
            ConvexShape shape1 = new ConvexShape(2);
            shape1.SetPoint(0, new Vector2F(1, 2));
            shape1.SetPoint(1, new Vector2F(3, 4));
            ConvexShape shape2 = new ConvexShape(shape1);
            Assert.Equal(shape1.GetPointCount(), shape2.GetPointCount());
            Assert.Equal(shape1.GetPoint(0), shape2.GetPoint(0));
            Assert.Equal(shape1.GetPoint(1), shape2.GetPoint(1));
        }
    }
}