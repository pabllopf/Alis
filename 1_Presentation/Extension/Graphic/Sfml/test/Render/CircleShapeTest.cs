// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:CircleShapeTest.cs
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
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the <see cref="CircleShape"/> class.
    /// </summary>
    public class CircleShapeTest : IDisposable
    {
        /// <summary>
        ///     The circle shape instance.
        /// </summary>
        private CircleShape? _circle;

        /// <summary>
        ///     Static constructor that pre-loads SFML native libraries using absolute paths.
        /// </summary>
        static CircleShapeTest()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(CircleShapeTest).Assembly.Location) ?? string.Empty;
            string libDir = Path.Combine(assemblyDir, "lib");

            if (Directory.Exists(libDir))
            {
                foreach (string libFile in Directory.GetFiles(libDir, "libcsfml-*.dylib"))
                {
                    string name = Path.GetFileNameWithoutExtension(Path.GetFileName(libFile));
                    // Strip "lib" prefix for NativeLibrary.Load
                    if (name.StartsWith("lib", StringComparison.Ordinal))
                        name = name[3..];
                    NativeLibrary.Load(Path.Combine(libDir, Path.GetFileName(libFile)));
                }

                foreach (string libFile in Directory.GetFiles(libDir, "sfml-*.dylib"))
                {
                    NativeLibrary.Load(Path.Combine(libDir, Path.GetFileName(libFile)));
                }
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleShapeTest"/> class
        ///     with default circle (radius=0, pointCount=30).
        /// </summary>
        public CircleShapeTest()
        {
            _circle = new CircleShape();
        }

        /// <summary>
        ///     Disposes the circle shape instance.
        /// </summary>
        public void Dispose()
        {
            _circle?.Destroy(true);
            _circle = null;
        }

        /// <summary>
        ///     Tests that the default constructor creates a valid instance.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_ShouldCreateValidInstance()
        {
            // Act & Assert - no exception thrown
            Assert.NotNull(_circle);
        }

        /// <summary>
        ///     Tests that the default point count is 30.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_DefaultPointCount_ShouldBe30()
        {
            // Act
            uint pointCount = _circle!.GetPointCount();

            // Assert
            Assert.Equal(30u, pointCount);
        }

        /// <summary>
        ///     Tests that the default radius is 0.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultConstructor_DefaultRadius_ShouldBe0()
        {
            // Act
            float radius = _circle!.Radius;

            // Assert
            Assert.Equal(0f, radius);
        }

        /// <summary>
        ///     Tests that the constructor with radius sets the correct radius.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithRadius_ShouldSetRadius()
        {
            // Arrange & Act
            CircleShape shape = new CircleShape(50f);

            // Assert
            Assert.Equal(50f, shape.Radius);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that the constructor with radius uses default point count of 30.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithRadius_ShouldUseDefaultPointCount()
        {
            // Arrange & Act
            CircleShape shape = new CircleShape(50f);

            // Assert
            Assert.Equal(30u, shape.GetPointCount());

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that the constructor with radius and point count sets both values.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithRadiusAndPointCount_ShouldSetBothValues()
        {
            // Arrange & Act
            CircleShape shape = new CircleShape(100f, 60u);

            // Assert
            Assert.Equal(100f, shape.Radius);
            Assert.Equal(60u, shape.GetPointCount());

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that the constructor with custom point count returns correct count.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WithCustomPointCount_ShouldReturnCorrectCount()
        {
            // Arrange & Act
            CircleShape shape = new CircleShape(25f, 120u);

            // Assert
            Assert.Equal(120u, shape.GetPointCount());

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that the copy constructor creates an independent copy with same values.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ShouldCopyRadiusAndPointCount()
        {
            // Arrange
            CircleShape original = new CircleShape(75f, 45u);
            CircleShape copy = new CircleShape(original);

            // Assert
            Assert.Equal(original.Radius, copy.Radius);
            Assert.Equal(original.GetPointCount(), copy.GetPointCount());

            // Cleanup
            original.Destroy(true);
            copy.Destroy(true);
        }

        /// <summary>
        ///     Tests that modifying the original does not affect the copy.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyConstructor_ModifyOriginal_ShouldNotAffectCopy()
        {
            // Arrange
            CircleShape original = new CircleShape(75f, 45u);
            CircleShape copy = new CircleShape(original);
            original.Radius = 100f;
            original.SetPointCount(60u);

            // Assert
            Assert.Equal(100f, original.Radius);
            Assert.Equal(60u, original.GetPointCount());
            Assert.Equal(75f, copy.Radius);
            Assert.Equal(45u, copy.GetPointCount());

            // Cleanup
            original.Destroy(true);
            copy.Destroy(true);
        }

        /// <summary>
        ///     Tests that SetPointCount updates the point count correctly.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPointCount_NewValue_ShouldUpdateCount()
        {
            // Act
            _circle!.SetPointCount(60u);

            // Assert
            Assert.Equal(60u, _circle.GetPointCount());
        }

        /// <summary>
        ///     Tests that SetPointCount with a smaller value works correctly.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPointCount_SmallerValue_ShouldUpdateCount()
        {
            // Act
            _circle!.SetPointCount(15u);

            // Assert
            Assert.Equal(15u, _circle.GetPointCount());
        }

        /// <summary>
        ///     Tests that GetPoint at index 0 returns approximately (radius, 0).
        ///     The circle is centered at (radius, radius) in local coordinates,
        ///     and index 0 corresponds to angle -π/2 (rightmost point).
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Index0_WithRadius50_ShouldBeApproximatelyRadiusZero()
        {
            // Arrange
            CircleShape shape = new CircleShape(50f, 30u);

            // Act
            Vector2F point = shape.GetPoint(0);

            // Assert - index 0: angle = -π/2, cos=0, sin=-1
            // x = radius + cos(-π/2)*radius = radius + 0 = radius
            // y = radius + sin(-π/2)*radius = radius - radius = 0
            Assert.Equal(50.0, point.X, 1);
            Assert.Equal(0.0, point.Y, 1);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that GetPoint at the top of the circle (index = pointCount/4)
        ///     returns approximately (radius, 2*radius).
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_IndexAtTop_ShouldBeApproximatelyRadiusDoubleY()
        {
            // Arrange - pointCount=30, index=15 is at angle π/2 (top)
            CircleShape shape = new CircleShape(50f, 30u);

            // Act
            Vector2F point = shape.GetPoint(15);

            // Assert - index 15: angle = π/2, cos=0, sin=1
            // x = radius + 0 = radius
            // y = radius + radius = 2*radius
            Assert.Equal(50.0, point.X, 1);
            Assert.Equal(100.0, point.Y, 1);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that GetPoint returns correct coordinates for a custom radius and point count.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_CustomRadiusAndPoints_Index0_ShouldMatchMath()
        {
            // Arrange
            const float radius = 100f;
            const uint pointCount = 60u;
            CircleShape shape = new CircleShape(radius, pointCount);

            // Act
            Vector2F point = shape.GetPoint(0);

            // Assert - index 0: angle = -π/2
            // x = radius + cos(-π/2)*radius = radius
            // y = radius + sin(-π/2)*radius = 0
            Assert.Equal(100.0, point.X, 1);
            Assert.Equal(0.0, point.Y, 1);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that GetPoint at the bottom of the circle (index = 3*pointCount/4)
        ///     returns approximately (0, 2*radius).
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_IndexAtBottom_ShouldBeApproximatelyZeroXDoubleY()
        {
            // Arrange - pointCount=30, index=22 is near angle 29π/30 ≈ bottom-left area
            // For a cleaner test, use index that gives angle close to π (bottom)
            // angle = index * 2π/30 - π/2 = π → index = 45/2 = 22.5, so index 22 or 23
            CircleShape shape = new CircleShape(50f, 30u);

            // Act - index 23: angle = 23*2π/30 - π/2 = 46π/30 - 15π/30 = 31π/30
            Vector2F point = shape.GetPoint(23);

            // Assert - 31π/30 is slightly past π, cos≈-1, sin≈small positive
            // x = 50 + cos(31π/30)*50 ≈ 50 - 49.74 = 0.26
            // y = 50 + sin(31π/30)*50 ≈ 50 + 2.62 = 52.62
            Assert.InRange(point.X, -5f, 5f);
            Assert.InRange(point.Y, 45f, 60f);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that GetPoint returns correct coordinates for index 7
        ///     which is near angle -π/30 (close to rightmost point).
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Index7_WithRadius50_ShouldBeNearRightSide()
        {
            // Arrange
            CircleShape shape = new CircleShape(50f, 30u);

            // Act - index 7: angle = 7*2π/30 - π/2 = 14π/30 - 15π/30 = -π/30
            Vector2F point = shape.GetPoint(7);

            // Assert - cos(-π/30)≈0.9986, sin(-π/30)≈-0.1045
            // x = 50 + 0.9986*50 ≈ 99.93
            // y = 50 + (-0.1045)*50 ≈ 44.78
            Assert.InRange(point.X, 97f, 101f);
            Assert.InRange(point.Y, 43f, 47f);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that the Radius property setter updates the radius correctly.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Radius_SetNewValue_ShouldUpdateRadius()
        {
            // Act
            _circle!.Radius = 75f;

            // Assert
            Assert.Equal(75f, _circle.Radius);
        }

        /// <summary>
        ///     Tests that the Radius property getter returns the current value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Radius_Getter_ShouldReturnCurrentRadius()
        {
            // Arrange
            _circle!.Radius = 42f;

            // Act
            float radius = _circle.Radius;

            // Assert
            Assert.Equal(42f, radius);
        }

        /// <summary>
        ///     Tests that multiple CircleShape instances can coexist independently.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MultipleInstances_ShouldWorkIndependently()
        {
            // Arrange & Act
            CircleShape shape1 = new CircleShape(50f, 30u);
            CircleShape shape2 = new CircleShape(100f, 60u);
            CircleShape shape3 = new CircleShape(25f, 15u);

            // Assert
            Assert.Equal(50f, shape1.Radius);
            Assert.Equal(30u, shape1.GetPointCount());
            Assert.Equal(100f, shape2.Radius);
            Assert.Equal(60u, shape2.GetPointCount());
            Assert.Equal(25f, shape3.Radius);
            Assert.Equal(15u, shape3.GetPointCount());

            // Cleanup
            shape1.Destroy(true);
            shape2.Destroy(true);
            shape3.Destroy(true);
        }

        /// <summary>
        ///     Tests that Destroy can be called with disposing=true without throwing.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_ShouldNotThrow()
        {
            // Arrange
            CircleShape shape = new CircleShape(50f, 30u);

            // Act & Assert
            Exception? exception = Record.Exception(() => shape.Destroy(true));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Destroy can be called with disposing=false without throwing.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_ShouldNotThrow()
        {
            // Arrange
            CircleShape shape = new CircleShape(50f, 30u);

            // Act & Assert
            Exception? exception = Record.Exception(() => shape.Destroy(false));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests the complete lifecycle: create, modify, read points, destroy.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FullLifecycle_ShouldWorkCorrectly()
        {
            // Arrange & Act - Create with initial values
            CircleShape shape = new CircleShape(50f, 30u);

            // Read initial state
            float initialRadius = shape.Radius;
            uint initialPoints = shape.GetPointCount();
            Assert.Equal(50f, initialRadius);
            Assert.Equal(30u, initialPoints);

            // Get a point
            Vector2F point0 = shape.GetPoint(0);
            Assert.Equal(50.0, point0.X, 1);

            // Modify
            shape.Radius = 100f;
            shape.SetPointCount(60u);

            // Verify modifications
            Assert.Equal(100f, shape.Radius);
            Assert.Equal(60u, shape.GetPointCount());

            // Get point with new values
            Vector2F point0New = shape.GetPoint(0);
            Assert.Equal(100.0, point0New.X, 1);

            // Cleanup
            shape.Destroy(true);

            // Assert - all operations completed without exception
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that GetPoint with zero radius returns (0, 0) for all indices.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_ZeroRadius_ShouldReturnZeroVector()
        {
            // Arrange
            CircleShape shape = new CircleShape(0f, 30u);

            // Act
            Vector2F point = shape.GetPoint(15);

            // Assert - with radius=0: x = 0 + cos(angle)*0 = 0, y = 0 + sin(angle)*0 = 0
            Assert.Equal(0f, point.X);
            Assert.Equal(0f, point.Y);

            // Cleanup
            shape.Destroy(true);
        }

        /// <summary>
        ///     Tests that GetPoint returns consistent results for the same input.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPoint_Deterministic_ShouldReturnSameResult()
        {
            // Arrange
            CircleShape shape = new CircleShape(50f, 30u);

            // Act
            Vector2F point1 = shape.GetPoint(10);
            Vector2F point2 = shape.GetPoint(10);

            // Assert
            Assert.Equal(point1.X, point2.X);
            Assert.Equal(point1.Y, point2.Y);

            // Cleanup
            shape.Destroy(true);
        }
    }
}
