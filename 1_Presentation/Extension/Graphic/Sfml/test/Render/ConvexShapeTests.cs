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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The convex shape tests class
    /// </summary>
    public class ConvexShapeTests
    {
        /// <summary>
        /// Defaults the constructor initializes with zero points
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_InitializesWithZeroPoints()
        {
            using ConvexShape shape = new ConvexShape();
            Assert.Equal(0u, shape.GetPointCount());
        }

        /// <summary>
        /// Constructors the with point count initializes with specified count
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithPointCount_InitializesWithSpecifiedCount()
        {
            using ConvexShape shape = new ConvexShape(5u);
            Assert.Equal(5u, shape.GetPointCount());
        }

        /// <summary>
        /// Constructors the with zero point count initializes with zero points
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithZeroPointCount_InitializesWithZeroPoints()
        {
            using ConvexShape shape = new ConvexShape(0u);
            Assert.Equal(0u, shape.GetPointCount());
        }

        /// <summary>
        /// Copies the constructor copies all points
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_CopiesAllPoints()
        {
            using ConvexShape original = new ConvexShape(3u);
            original.SetPoint(0, new Vector2F(10, 20));
            original.SetPoint(1, new Vector2F(30, 40));
            original.SetPoint(2, new Vector2F(50, 60));

            using ConvexShape copy = new ConvexShape(original);
            Assert.Equal(original.GetPointCount(), copy.GetPointCount());
            Assert.Equal(original.GetPoint(0), copy.GetPoint(0));
            Assert.Equal(original.GetPoint(1), copy.GetPoint(1));
            Assert.Equal(original.GetPoint(2), copy.GetPoint(2));
        }

        /// <summary>
        /// Copies the constructor modify original does not affect copy
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ModifyOriginal_DoesNotAffectCopy()
        {
            using ConvexShape original = new ConvexShape(2u);
            original.SetPoint(0, new Vector2F(10, 20));
            original.SetPoint(1, new Vector2F(30, 40));

            using ConvexShape copy = new ConvexShape(original);
            original.SetPoint(0, new Vector2F(99, 99));

            Assert.Equal(new Vector2F(10, 20), copy.GetPoint(0));
        }

        /// <summary>
        /// Sets the point count increases size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPointCount_IncreasesSize()
        {
            using ConvexShape shape = new ConvexShape(3u);
            shape.SetPointCount(6u);
            Assert.Equal(6u, shape.GetPointCount());
        }

        /// <summary>
        /// Sets the point count decreases size
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPointCount_DecreasesSize()
        {
            using ConvexShape shape = new ConvexShape(5u);
            shape.SetPointCount(2u);
            Assert.Equal(2u, shape.GetPointCount());
        }

        /// <summary>
        /// Sets the point count to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPointCount_ToZero()
        {
            using ConvexShape shape = new ConvexShape(3u);
            shape.SetPointCount(0u);
            Assert.Equal(0u, shape.GetPointCount());
        }

        /// <summary>
        /// Gets the point count returns correct count
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPointCount_ReturnsCorrectCount()
        {
            using ConvexShape shape = new ConvexShape();
            Assert.Equal(0u, shape.GetPointCount());

            shape.SetPointCount(10u);
            Assert.Equal(10u, shape.GetPointCount());
        }

        /// <summary>
        /// Gets the point returns set point
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_ReturnsSetPoint()
        {
            using ConvexShape shape = new ConvexShape(1u);
            Vector2F point = new Vector2F(15.5f, -25.3f);
            shape.SetPoint(0, point);

            Vector2F result = shape.GetPoint(0);
            Assert.Equal(point.X, result.X);
            Assert.Equal(point.Y, result.Y);
        }

        /// <summary>
        /// Sets the point updates existing point
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPoint_UpdatesExistingPoint()
        {
            using ConvexShape shape = new ConvexShape(1u);
            shape.SetPoint(0, new Vector2F(10, 20));
            shape.SetPoint(0, new Vector2F(30, 40));

            Vector2F result = shape.GetPoint(0);
            Assert.Equal(30f, result.X, 5);
            Assert.Equal(40f, result.Y, 5);
        }

        /// <summary>
        /// Sets the point multiple points all roundtrip
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPoint_MultiplePoints_AllRoundtrip()
        {
            using ConvexShape shape = new ConvexShape(4u);
            Vector2F[] points = new[]
            {
                new Vector2F(0, 0),
                new Vector2F(100, 0),
                new Vector2F(100, 100),
                new Vector2F(0, 100)
            };

            for (uint i = 0; i < 4; i++)
            {
                shape.SetPoint(i, points[i]);
            }

            for (uint i = 0; i < 4; i++)
            {
                Vector2F result = shape.GetPoint(i);
                Assert.Equal(points[i].X, result.X);
                Assert.Equal(points[i].Y, result.Y);
            }
        }

        /// <summary>
        /// Gets the local bounds after setting points returns valid rect
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetLocalBounds_AfterSettingPoints_ReturnsValidRect()
        {
            using ConvexShape shape = new ConvexShape(4u);
            shape.SetPoint(0, new Vector2F(0, 0));
            shape.SetPoint(1, new Vector2F(100, 0));
            shape.SetPoint(2, new Vector2F(100, 100));
            shape.SetPoint(3, new Vector2F(0, 100));

            FloatRect bounds = shape.GetLocalBounds();
            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        /// Gets the global bounds after setting points returns valid rect
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetGlobalBounds_AfterSettingPoints_ReturnsValidRect()
        {
            using ConvexShape shape = new ConvexShape(4u);
            shape.SetPoint(0, new Vector2F(0, 0));
            shape.SetPoint(1, new Vector2F(100, 0));
            shape.SetPoint(2, new Vector2F(100, 100));
            shape.SetPoint(3, new Vector2F(0, 100));

            FloatRect bounds = shape.GetGlobalBounds();
            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        /// Inheritses the from shape
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InheritsFromShape()
        {
            using ConvexShape shape = new ConvexShape();
            Assert.True(shape is Shape);
            Assert.True(shape is IDrawable);
        }

        /// <summary>
        /// Disposes the releases native resources
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_ReleasesNativeResources()
        {
            ConvexShape shape = new ConvexShape();
            shape.Destroy(true);
            Assert.Equal(System.IntPtr.Zero, shape.CPointer);
        }

        /// <summary>
        /// Sets the point count after setting points preserves points within range
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPointCount_AfterSettingPoints_PreservesPointsWithinRange()
        {
            using ConvexShape shape = new ConvexShape(5u);
            for (uint i = 0; i < 5; i++)
            {
                shape.SetPoint(i, new Vector2F(i * 10, i * 20));
            }

            shape.SetPointCount(3u);
            Assert.Equal(3u, shape.GetPointCount());
            Assert.Equal(new Vector2F(0, 0), shape.GetPoint(0));
            Assert.Equal(new Vector2F(10, 20), shape.GetPoint(1));
            Assert.Equal(new Vector2F(20, 40), shape.GetPoint(2));
        }
    }
}
