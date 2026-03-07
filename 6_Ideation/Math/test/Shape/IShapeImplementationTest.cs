// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IShapeImplementationTest.cs
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

using Alis.Core.Aspect.Math.Shapes;
using Alis.Core.Aspect.Math.Shapes.Circle;
using Alis.Core.Aspect.Math.Shapes.Line;
using Alis.Core.Aspect.Math.Shapes.Point;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Aspect.Math.Shapes.Square;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape
{
    /// <summary>
    ///     The shape implementation test class
    /// </summary>
    public class IShapeImplementationTest
    {
        /// <summary>
        ///     Tests that all shape structs are assignable to i shape
        /// </summary>
        [Fact]
        public void AllShapeStructs_AreAssignableToIShape()
        {
            IShape[] shapes =
            {
                new CircleF(),
                new CircleI(),
                new LineF(),
                new LineI(),
                new PointF(),
                new PointI(),
                new RectangleF(),
                new RectangleI(),
                new SquareF(),
                new SquareI()
            };

            Assert.Equal(10, shapes.Length);
            foreach (IShape shape in shapes)
            {
                Assert.NotNull(shape);
            }
        }
    }
}