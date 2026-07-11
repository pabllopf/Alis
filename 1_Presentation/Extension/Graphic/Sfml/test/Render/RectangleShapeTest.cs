// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RectangleShapeTest.cs
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
    ///     Unit tests for the <see cref="RectangleShape"/> class.
    /// </summary>
    public class RectangleShapeTest : IDisposable
    {
        private RectangleShape? _shape;

        static RectangleShapeTest()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(RectangleShapeTest).Assembly.Location) ?? string.Empty;
            string libDir = Path.Combine(assemblyDir, "lib");

            if (Directory.Exists(libDir))
            {
                foreach (string libFile in Directory.GetFiles(libDir, "libcsfml-*.dylib"))
                {
                    string name = Path.GetFileNameWithoutExtension(Path.GetFileName(libFile));
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

        public RectangleShapeTest()
        {
            _shape = new RectangleShape();
        }

        public void Dispose()
        {
            _shape?.Destroy(true);
            _shape = null;
        }

        [Fact]
        public void RectangleShape_IsAssignableFromShape()
        {
            Assert.True(typeof(Shape).IsAssignableFrom(typeof(RectangleShape)));
        }

        [Fact]
        public void RectangleShape_ImplementsIDrawable()
        {
            Assert.True(typeof(IDrawable).IsAssignableFrom(typeof(RectangleShape)));
        }

        [Fact]
        public void Size_Property_Exists()
        {
            var prop = typeof(RectangleShape).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
            Assert.Equal(typeof(Vector2F), prop.PropertyType);
        }

        [RequireCSfmlSystemFact]
        public void GetPointCount_ReturnsFour()
        {
            Assert.Equal(4u, _shape!.GetPointCount());
        }

        [RequireCSfmlSystemFact]
        public void GetPoint_Index0_ReturnsOrigin()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100, 50));
            var point = shape.GetPoint(0);
            Assert.Equal(0f, point.X);
            Assert.Equal(0f, point.Y);
            shape.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void GetPoint_Index1_ReturnsTopRight()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100, 50));
            var point = shape.GetPoint(1);
            Assert.Equal(100f, point.X);
            Assert.Equal(0f, point.Y);
            shape.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void GetPoint_Index2_ReturnsBottomRight()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100, 50));
            var point = shape.GetPoint(2);
            Assert.Equal(100f, point.X);
            Assert.Equal(50f, point.Y);
            shape.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void GetPoint_Index3_ReturnsBottomLeft()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100, 50));
            var point = shape.GetPoint(3);
            Assert.Equal(0f, point.X);
            Assert.Equal(50f, point.Y);
            shape.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void GetPoint_DefaultIndex_ReturnsOrigin()
        {
            RectangleShape shape = new RectangleShape(new Vector2F(100, 50));
            var point = shape.GetPoint(5);
            Assert.Equal(0f, point.X);
            Assert.Equal(0f, point.Y);
            shape.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void DefaultConstructor_SizeIsZero()
        {
            Assert.Equal(0f, _shape!.Size.X);
            Assert.Equal(0f, _shape.Size.Y);
        }

        [RequireCSfmlSystemFact]
        public void SizeSetter_UpdatesGetPoint()
        {
            _shape!.Size = new Vector2F(200, 100);
            Assert.Equal(200f, _shape.Size.X);
            Assert.Equal(100f, _shape.Size.Y);
            Assert.Equal(200f, _shape.GetPoint(1).X);
            Assert.Equal(100f, _shape.GetPoint(2).Y);
        }
    }
}
