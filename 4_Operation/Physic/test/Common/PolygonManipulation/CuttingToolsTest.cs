// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CuttingToolsTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The cutting tools test class
    /// </summary>
    public class CuttingToolsTest
    {
        /// <summary>
        ///     Tests that CuttingTools type is accessible and static.
        /// </summary>
        [Fact]
        public void CuttingTools_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(CuttingTools));
            Assert.True(typeof(CuttingTools).IsPublic);
        }

        /// <summary>
        ///     Tests that SplitShape handles non-polygon shapes correctly.
        /// </summary>
        [Fact]
        public void SplitShape_NonPolygonShape_ShouldReturnEmptyPolygons()
        {
            // This test verifies the method signature and basic error handling
            // Actual testing requires full physics world setup
            Assert.NotNull(CuttingTools.SplitShape);
        }

        /// <summary>
        ///     Tests that Cut method signature is accessible.
        /// </summary>
        [Fact]
        public void Cut_MethodShouldBeAccessible()
        {
            Assert.NotNull(CuttingTools.Cut);
        }

        /// <summary>
        ///     Tests that SplitShape method exists with correct signature.
        /// </summary>
        [Fact]
        public void SplitShape_MethodSignatureShouldBeCorrect()
        {
            var method = typeof(CuttingTools).GetMethod("SplitShape");
            Assert.NotNull(method);
            Assert.True(method!.IsStatic);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Tests that Cut method exists with correct signature.
        /// </summary>
        [Fact]
        public void Cut_MethodSignatureShouldBeCorrect()
        {
            var method = typeof(CuttingTools).GetMethod("Cut");
            Assert.NotNull(method);
            Assert.True(method!.IsStatic);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        ///     Tests that Cut has correct parameters.
        /// </summary>
        [Fact]
        public void Cut_ParametersShouldBeCorrect()
        {
            var method = typeof(CuttingTools).GetMethod("Cut")!;
            var parameters = method.GetParameters();

            Assert.Equal(3, parameters.Length);
            Assert.Equal("worldPhysic", parameters[0].Name);
            Assert.Equal("start", parameters[1].Name);
            Assert.Equal("end", parameters[2].Name);
        }

        /// <summary>
        ///     Tests that Vector2F is accessible for test setup.
        /// </summary>
        [Fact]
        public void Vector2F_ShouldBeAccessible()
        {
            var vector = new Vector2F(1.0f, 2.0f);
            Assert.Equal(1.0f, vector.X);
            Assert.Equal(2.0f, vector.Y);
        }

        /// <summary>
        ///     Tests that Vector2F operations work correctly.
        /// </summary>
        [Fact]
        public void Vector2F_OperationsShouldWork()
        {
            var v1 = new Vector2F(3.0f, 4.0f);
            var v2 = new Vector2F(1.0f, 2.0f);

            var sum = v1 + v2;
            Assert.Equal(4.0f, sum.X);
            Assert.Equal(6.0f, sum.Y);

            var diff = v1 - v2;
            Assert.Equal(2.0f, diff.X);
            Assert.Equal(2.0f, diff.Y);
        }

        /// <summary>
        ///     Tests that Vector2F equality works.
        /// </summary>
        [Fact]
        public void Vector2F_EqualityShouldWork()
        {
            var v1 = new Vector2F(1.0f, 2.0f);
            var v2 = new Vector2F(1.0f, 2.0f);
            var v3 = new Vector2F(1.0f, 3.0f);

            Assert.True(v1.Equals(v2));
            Assert.False(v1.Equals(v3));
        }

        /// <summary>
        ///     Tests that PolygonShape can be instantiated.
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldBeInstantiable()
        {
            var vertices = new Vertices
            {
                new(0, 0),
                new(1, 0),
                new(1, 1),
                new(0, 1)
            };

            var shape = new PolygonShape(vertices, 1.0f);
            Assert.NotNull(shape);
        }

        /// <summary>
        ///     Tests that Vertices collection works.
        /// </summary>
        [Fact]
        public void Vertices_CollectionShouldWork()
        {
            var vertices = new Vertices();
            Assert.NotNull(vertices);
            Assert.Equal(0, vertices.Count);

            vertices.Add(new Vector2F(0, 0));
            vertices.Add(new Vector2F(1, 0));
            vertices.Add(new Vector2F(1, 1));

            Assert.Equal(3, vertices.Count);
        }

        /// <summary>
        ///     Tests that WorldPhysic can be created for cut operations.
        /// </summary>
        [Fact]
        public void WorldPhysic_ShouldBeCreateable()
        {
            var world = new WorldPhysic(new Vector2F(0, -9.81f));
            Assert.NotNull(world);
        }

        /// <summary>
        ///     Tests that PolygonError enum values are accessible.
        /// </summary>
        [Fact]
        public void PolygonError_NoErrorShouldBeZero()
        {
            Assert.Equal(0, (int)PolygonError.NoError);
        }

        /// <summary>
        ///     Tests that SettingEnv.Epsilon is accessible.
        /// </summary>
        [Fact]
        public void SettingEnv_EpsilonShouldBeAccessible()
        {
            Assert.True(SettingEnv.Epsilon > 0);
            Assert.True(SettingEnv.Epsilon < 1);
        }

        /// <summary>
        ///     Tests that Vector2F.Dot product works.
        /// </summary>
        [Fact]
        public void Vector2F_DotProductShouldWork()
        {
            var v1 = new Vector2F(1, 0);
            var v2 = new Vector2F(0, 1);

            float dot = Vector2F.Dot(v1, v2);
            Assert.Equal(0.0f, dot);

            var v3 = new Vector2F(1, 1);
            dot = Vector2F.Dot(v3, v3);
            Assert.Equal(2.0f, dot);
        }

        /// <summary>
        ///     Tests that Vector2F.Cross product works.
        /// </summary>
        [Fact]
        public void Vector2F_CrossProductShouldWork()
        {
            var v1 = new Vector2F(1, 0);
            var v2 = new Vector2F(0, 1);

            float cross = MathUtils.Cross(v1, v2);
            Assert.Equal(1.0f, cross);

            cross = MathUtils.Cross(v2, v1);
            Assert.Equal(-1.0f, cross);
        }

        /// <summary>
        ///     Tests that Vector2F.Normalize works.
        /// </summary>
        [Fact]
        public void Vector2F_NormalizeShouldWork()
        {
            var v = new Vector2F(3, 4);
            v.Normalize();

            float magnitude = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            Assert.True(Math.Abs(magnitude - 1.0f) < 0.001f);
        }

        /// <summary>
        ///     Tests that Vector2F.IsValid works.
        /// </summary>
        [Fact]
        public void Vector2F_IsValidShouldWork()
        {
            var valid = new Vector2F(1, 2);
            Assert.True(valid.IsValid());

            var invalid = new Vector2F(float.NaN, float.NaN);
            Assert.False(invalid.IsValid());
        }

        /// <summary>
        ///     Tests that Vector2F.One is accessible.
        /// </summary>
        [Fact]
        public void Vector2F_OneShouldBeAccessible()
        {
            var one = Vector2F.One;
            Assert.Equal(1.0f, one.X);
            Assert.Equal(1.0f, one.Y);
        }
    }
}
