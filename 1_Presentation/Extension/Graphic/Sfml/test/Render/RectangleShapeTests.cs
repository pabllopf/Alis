// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleShapeTests.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The rectangle shape tests class
    /// </summary>
    public class RectangleShapeTests
    {
        /// <summary>
        /// Defaults the constructor sets size to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_SetsSizeToZero()
        {
            using RectangleShape shape = new RectangleShape();
            Assert.Equal(0f, shape.Size.X, 5);
            Assert.Equal(0f, shape.Size.Y, 5);
        }

        /// <summary>
        /// Constructors the with size sets size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithSize_SetsSize()
        {
            Vector2F size = new Vector2F(100f, 200f);
            using RectangleShape shape = new RectangleShape(size);
            Assert.Equal(100f, shape.Size.X, 5);
            Assert.Equal(200f, shape.Size.Y, 5);
        }

        /// <summary>
        /// Constructors the with zero size sets size to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithZeroSize_SetsSizeToZero()
        {
            Vector2F size = new Vector2F(0f, 0f);
            using RectangleShape shape = new RectangleShape(size);
            Assert.Equal(0f, shape.Size.X, 5);
            Assert.Equal(0f, shape.Size.Y, 5);
        }

        /// <summary>
        /// Constructors the with negative size sets size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithNegativeSize_SetsSize()
        {
            Vector2F size = new Vector2F(-50f, -75f);
            using RectangleShape shape = new RectangleShape(size);
            Assert.Equal(-50f, shape.Size.X, 5);
            Assert.Equal(-75f, shape.Size.Y, 5);
        }

        /// <summary>
        /// Copies the constructor copies size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_CopiesSize()
        {
            using RectangleShape original = new RectangleShape(new Vector2F(150f, 250f));
            using RectangleShape copy = new RectangleShape(original);
            Assert.Equal(original.Size.X, copy.Size.X);
            Assert.Equal(original.Size.Y, copy.Size.Y);
        }

        /// <summary>
        /// Copies the constructor modify original does not affect copy
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ModifyOriginal_DoesNotAffectCopy()
        {
            using RectangleShape original = new RectangleShape(new Vector2F(100f, 200f));
            using RectangleShape copy = new RectangleShape(original);
            original.Size = new Vector2F(300f, 400f);
            Assert.Equal(100f, copy.Size.X, 5);
            Assert.Equal(200f, copy.Size.Y, 5);
        }

        /// <summary>
        /// Copies the constructor zero size copies correctly
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ZeroSize_CopiesCorrectly()
        {
            using RectangleShape original = new RectangleShape(new Vector2F(0f, 0f));
            using RectangleShape copy = new RectangleShape(original);
            Assert.Equal(0f, copy.Size.X, 5);
            Assert.Equal(0f, copy.Size.Y, 5);
        }

        /// <summary>
        /// Sizes the setter updates value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Setter_UpdatesValue()
        {
            using RectangleShape shape = new RectangleShape();
            shape.Size = new Vector2F(80f, 120f);
            Assert.Equal(80f, shape.Size.X, 5);
            Assert.Equal(120f, shape.Size.Y, 5);
        }

        /// <summary>
        /// Sizes the setter multiple times returns last value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Setter_MultipleTimes_ReturnsLastValue()
        {
            using RectangleShape shape = new RectangleShape();
            shape.Size = new Vector2F(10f, 20f);
            shape.Size = new Vector2F(30f, 40f);
            shape.Size = new Vector2F(50f, 60f);
            Assert.Equal(50f, shape.Size.X, 5);
            Assert.Equal(60f, shape.Size.Y, 5);
        }

        /// <summary>
        /// Sizes the getter returns current value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Getter_ReturnsCurrentValue()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(200f, 300f));
            Vector2F size = shape.Size;
            Assert.Equal(200f, size.X, 5);
            Assert.Equal(300f, size.Y, 5);
        }

        /// <summary>
        /// Gets the point count returns four
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPointCount_ReturnsFour()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Assert.Equal(4u, shape.GetPointCount());
        }

        /// <summary>
        /// Gets the point count after resize still returns four
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPointCount_AfterResize_StillReturnsFour()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            shape.Size = new Vector2F(300f, 400f);
            Assert.Equal(4u, shape.GetPointCount());
        }

        /// <summary>
        /// Gets the point count zero size returns four
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPointCount_ZeroSize_ReturnsFour()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(0f, 0f));
            Assert.Equal(4u, shape.GetPointCount());
        }

        /// <summary>
        /// Gets the point index 0 returns top left
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Index0_ReturnsTopLeft()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Vector2F point = shape.GetPoint(0);
            Assert.Equal(0f, point.X, 5);
            Assert.Equal(0f, point.Y, 5);
        }

        /// <summary>
        /// Gets the point index 1 returns top right
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Index1_ReturnsTopRight()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Vector2F point = shape.GetPoint(1);
            Assert.Equal(100f, point.X, 5);
            Assert.Equal(0f, point.Y, 5);
        }

        /// <summary>
        /// Gets the point index 2 returns bottom right
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Index2_ReturnsBottomRight()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Vector2F point = shape.GetPoint(2);
            Assert.Equal(100f, point.X, 5);
            Assert.Equal(200f, point.Y, 5);
        }

        /// <summary>
        /// Gets the point index 3 returns bottom left
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Index3_ReturnsBottomLeft()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Vector2F point = shape.GetPoint(3);
            Assert.Equal(0f, point.X, 5);
            Assert.Equal(200f, point.Y, 5);
        }

        /// <summary>
        /// Gets the point default case returns top left
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_DefaultCase_ReturnsTopLeft()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Vector2F point = shape.GetPoint(5);
            Assert.Equal(0f, point.X, 5);
            Assert.Equal(0f, point.Y, 5);
        }

        /// <summary>
        /// Gets the point default case large index returns top left
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_DefaultCaseLargeIndex_ReturnsTopLeft()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            Vector2F point = shape.GetPoint(999);
            Assert.Equal(0f, point.X, 5);
            Assert.Equal(0f, point.Y, 5);
        }

        /// <summary>
        /// Gets the point after size change reflects new size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_AfterSizeChange_ReflectsNewSize()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            shape.Size = new Vector2F(300f, 400f);
            Assert.Equal(new Vector2F(300f, 0f), shape.GetPoint(1));
            Assert.Equal(new Vector2F(300f, 400f), shape.GetPoint(2));
            Assert.Equal(new Vector2F(0f, 400f), shape.GetPoint(3));
        }

        /// <summary>
        /// Gets the point zero size all points at origin
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_ZeroSize_AllPointsAtOrigin()
        {
            using RectangleShape shape = new RectangleShape(new Vector2F(0f, 0f));
            Assert.Equal(new Vector2F(0f, 0f), shape.GetPoint(0));
            Assert.Equal(new Vector2F(0f, 0f), shape.GetPoint(1));
            Assert.Equal(new Vector2F(0f, 0f), shape.GetPoint(2));
            Assert.Equal(new Vector2F(0f, 0f), shape.GetPoint(3));
        }

        /// <summary>
        /// Inheritses the from shape
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InheritsFromShape()
        {
            using RectangleShape shape = new RectangleShape();
            Assert.True(shape is Shape);
            Assert.True(shape is IDrawable);
        }

        /// <summary>
        /// Multiples the instances work independently
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MultipleInstances_WorkIndependently()
        {
            using RectangleShape shape1 = new RectangleShape(new Vector2F(100f, 200f));
            using RectangleShape shape2 = new RectangleShape(new Vector2F(300f, 400f));
            Assert.Equal(100f, shape1.Size.X, 5);
            Assert.Equal(200f, shape1.Size.Y, 5);
            Assert.Equal(300f, shape2.Size.X, 5);
            Assert.Equal(400f, shape2.Size.Y, 5);
        }

        /// <summary>
        /// Destroys the with disposing true does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_DoesNotThrow()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            shape.Destroy(true);
            Assert.Equal(System.IntPtr.Zero, shape.CPointer);
        }

        /// <summary>
        /// Destroys the with disposing false does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_DoesNotThrow()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100f, 200f));
            shape.Destroy(false);
            Assert.Equal(System.IntPtr.Zero, shape.CPointer);
        }
    }
}
