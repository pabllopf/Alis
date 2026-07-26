// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:ShapeTests.cs
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
    public class TestShape : Shape
    {
        private uint _pointCount = 4;
        private float _radius = 50f;

        public TestShape() : base()
        {
        }

        public TestShape(TestShape copy) : base(copy)
        {
            _radius = copy._radius;
            _pointCount = copy._pointCount;
        }

        public void SetTestPointCount(uint count)
        {
            _pointCount = count;
            Update();
        }

        public void SetTestRadius(float radius)
        {
            _radius = radius;
            Update();
        }

        public override uint GetPointCount() => _pointCount;

        public override Vector2F GetPoint(uint index)
        {
            float angle = (float)(index * 2 * System.Math.PI / _pointCount - System.Math.PI / 2);
            float x = (float)System.Math.Cos(angle) * _radius;
            float y = (float)System.Math.Sin(angle) * _radius;
            return new Vector2F(_radius + x, _radius + y);
        }
    }

    public class ShapeTests
    {
        [RequireCSfmlSystemFact]
        public void Constructor_Default_ShouldCreateValidInstance()
        {
            using TestShape shape = new TestShape();
            Assert.NotNull(shape);
            Assert.NotEqual(System.IntPtr.Zero, shape.CPointer);
        }

        [RequireCSfmlSystemFact]
        public void Constructor_Default_ShouldHaveDefaultValues()
        {
            using TestShape shape = new TestShape();
            Assert.Equal(4u, shape.GetPointCount());
            Assert.Equal(new Vector2F(0, 0), shape.Position);
            Assert.Equal(0f, shape.Rotation);
            Assert.Equal(new Vector2F(1, 1), shape.Scale);
            Assert.Equal(new Vector2F(0, 0), shape.Origin);
        }

        [RequireCSfmlSystemFact]
        public void CopyConstructor_ShouldCopyProperties()
        {
            TestShape original = new TestShape();
            original.SetTestPointCount(8u);
            original.SetTestRadius(100f);
            original.Position = new Vector2F(10, 20);
            original.Rotation = 45f;
            original.Scale = new Vector2F(2, 2);
            original.Origin = new Vector2F(5, 5);

            TestShape copy = new TestShape(original);

            Assert.Equal(original.GetPointCount(), copy.GetPointCount());
            Assert.Equal(original.Position, copy.Position);
            Assert.Equal(original.Rotation, copy.Rotation);
            Assert.Equal(original.Scale, copy.Scale);
            Assert.Equal(original.Origin, copy.Origin);

            original.Destroy(true);
            copy.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void CopyConstructor_ModifyOriginal_ShouldNotAffectCopy()
        {
            TestShape original = new TestShape();
            original.SetTestPointCount(8u);
            original.SetTestRadius(100f);
            original.Position = new Vector2F(10, 20);

            TestShape copy = new TestShape(original);

            original.SetTestPointCount(12u);
            original.SetTestRadius(200f);
            original.Position = new Vector2F(30, 40);

            Assert.Equal(8u, copy.GetPointCount());
            Assert.Equal(new Vector2F(10, 20), copy.Position);

            original.Destroy(true);
            copy.Destroy(true);
        }

        [RequireCSfmlSystemFact]
        public void Texture_SetNull_ShouldNotThrow()
        {
            using TestShape shape = new TestShape();

            shape.Texture = null;

            Assert.Null(shape.Texture);
        }

        [RequireCSfmlSystemFact]
        public void Texture_SetAndGetNullWithTexture_SetNullTwice_ShouldNotThrow()
        {
            using TestShape shape = new TestShape();

            shape.Texture = null;
            shape.Texture = null;

            Assert.Null(shape.Texture);
        }

        [RequireCSfmlSystemFact]
        public void TextureRect_Set_ShouldNotThrow()
        {
            using TestShape shape = new TestShape();
            IntRect rect = new IntRect(10, 20, 30, 40);

            shape.TextureRect = rect;
        }

        [RequireCSfmlSystemFact]
        public void FillColor_SetAndGet_ShouldRoundtrip()
        {
            using TestShape shape = new TestShape();
            Color color = new Color(100, 150, 200, 255);

            shape.FillColor = color;
            Color result = shape.FillColor;

            Assert.Equal(color.R, result.R);
            Assert.Equal(color.G, result.G);
            Assert.Equal(color.B, result.B);
            Assert.Equal(color.A, result.A);
        }

        [RequireCSfmlSystemFact]
        public void FillColor_Default_ShouldBeWhite()
        {
            using TestShape shape = new TestShape();
            Color result = shape.FillColor;

            Assert.Equal(255, result.R);
            Assert.Equal(255, result.G);
            Assert.Equal(255, result.B);
            Assert.Equal(255, result.A);
        }

        [RequireCSfmlSystemFact]
        public void OutlineColor_SetAndGet_ShouldRoundtrip()
        {
            using TestShape shape = new TestShape();
            Color color = new Color(200, 100, 50, 128);

            shape.OutlineColor = color;
            Color result = shape.OutlineColor;

            Assert.Equal(color.R, result.R);
            Assert.Equal(color.G, result.G);
            Assert.Equal(color.B, result.B);
            Assert.Equal(color.A, result.A);
        }

        [RequireCSfmlSystemFact]
        public void OutlineColor_Default_ShouldBeWhite()
        {
            using TestShape shape = new TestShape();
            Color result = shape.OutlineColor;

            Assert.Equal(255, result.R);
            Assert.Equal(255, result.G);
            Assert.Equal(255, result.B);
            Assert.Equal(255, result.A);
        }

        [RequireCSfmlSystemFact]
        public void OutlineThickness_SetAndGet_ShouldRoundtrip()
        {
            using TestShape shape = new TestShape();

            shape.OutlineThickness = 5.5f;
            float result = shape.OutlineThickness;

            Assert.Equal(5.5f, result);
        }

        [RequireCSfmlSystemFact]
        public void OutlineThickness_Default_ShouldBeZero()
        {
            using TestShape shape = new TestShape();

            float result = shape.OutlineThickness;

            Assert.Equal(0f, result);
        }

        [RequireCSfmlSystemFact]
        public void GetLocalBounds_ShouldReturnValidRect()
        {
            using TestShape shape = new TestShape();

            FloatRect bounds = shape.GetLocalBounds();

            Assert.True(bounds.Width >= 0);
            Assert.True(bounds.Height >= 0);
        }

        [RequireCSfmlSystemFact]
        public void GetGlobalBounds_ShouldReturnValidRect()
        {
            using TestShape shape = new TestShape();

            FloatRect bounds = shape.GetGlobalBounds();

            Assert.True(bounds.Width >= 0);
            Assert.True(bounds.Height >= 0);
        }

        [RequireCSfmlSystemFact]
        public void GetGlobalBounds_WithPosition_ShouldReflectTranslation()
        {
            using TestShape shape = new TestShape();
            shape.Position = new Vector2F(100, 200);

            FloatRect localBounds = shape.GetLocalBounds();
            FloatRect globalBounds = shape.GetGlobalBounds();

            Assert.Equal(localBounds.Left + 100, globalBounds.Left);
            Assert.Equal(localBounds.Top + 200, globalBounds.Top);
        }

        [RequireCSfmlSystemFact]
        public void Update_AfterChangingGeometry_ShouldRecalculate()
        {
            using TestShape shape = new TestShape();
            FloatRect boundsBefore = shape.GetLocalBounds();

            shape.SetTestRadius(100f);
            shape.SetTestPointCount(8u);

            FloatRect boundsAfter = shape.GetLocalBounds();

            Assert.NotEqual(boundsBefore.Width, boundsAfter.Width);
        }

        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_ShouldSetCPointerToZero()
        {
            TestShape shape = new TestShape();

            shape.Destroy(true);

            Assert.Equal(System.IntPtr.Zero, shape.CPointer);
        }

        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_ShouldSetCPointerToZero()
        {
            TestShape shape = new TestShape();

            shape.Destroy(false);

            Assert.Equal(System.IntPtr.Zero, shape.CPointer);
        }

        [RequireCSfmlSystemFact]
        public void MultipleInstances_ShouldWorkIndependently()
        {
            using TestShape shape1 = new TestShape();
            using TestShape shape2 = new TestShape();

            shape1.SetTestPointCount(6u);
            shape1.SetTestRadius(30f);
            shape1.Position = new Vector2F(10, 10);

            shape2.SetTestPointCount(12u);
            shape2.SetTestRadius(60f);
            shape2.Position = new Vector2F(20, 20);

            Assert.Equal(6u, shape1.GetPointCount());
            Assert.Equal(12u, shape2.GetPointCount());
            Assert.Equal(new Vector2F(10, 10), shape1.Position);
            Assert.Equal(new Vector2F(20, 20), shape2.Position);
        }

        [RequireCSfmlSystemFact]
        public void GetPoint_ShouldReturnExpectedCoordinates()
        {
            using TestShape shape = new TestShape();
            shape.SetTestRadius(50f);
            shape.SetTestPointCount(4u);

            Vector2F point0 = shape.GetPoint(0);
            Vector2F point1 = shape.GetPoint(1);

            Assert.Equal(50f, point0.X, 1);
            Assert.Equal(0f, point0.Y, 1);
            Assert.Equal(100f, point1.X, 1);
            Assert.Equal(50f, point1.Y, 1);
        }

    }
}
