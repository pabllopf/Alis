// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Xunit;

namespace Alis.Test
{
    public class TransformBuilderTest
    {
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            TransformBuilder builder = new TransformBuilder();
            Assert.NotNull(builder);
        }

        [Fact]
        public void Build_ReturnsTransformInstance()
        {
            TransformBuilder builder = new TransformBuilder();
            Transform result = builder.Build();
            Assert.NotNull(result);
        }

        [Fact]
        public void Position_SetsXY_ReturnsBuilder()
        {
            TransformBuilder builder = new TransformBuilder();
            TransformBuilder result = builder.Position(10.0f, 20.0f);
            Assert.Same(builder, result);
        }

        [Fact]
        public void Position_SetsVector_ReturnsBuilder()
        {
            TransformBuilder builder = new TransformBuilder();
            TransformBuilder result = builder.Position(new Vector2F(5.0f, 15.0f));
            Assert.Same(builder, result);
        }

        [Fact]
        public void Rotation_SetsAngle_ReturnsBuilder()
        {
            TransformBuilder builder = new TransformBuilder();
            TransformBuilder result = builder.Rotation(45.0f);
            Assert.Same(builder, result);
        }

        [Fact]
        public void Scale_SetsXY_ReturnsBuilder()
        {
            TransformBuilder builder = new TransformBuilder();
            TransformBuilder result = builder.Scale(2.0f, 3.0f);
            Assert.Same(builder, result);
        }

        [Fact]
        public void ChainingAllProperties_CreatesTransform()
        {
            TransformBuilder builder = new TransformBuilder();
            Transform result = builder
                .Position(1.0f, 2.0f)
                .Rotation(90.0f)
                .Scale(2.0f, 2.0f)
                .Build();
            Assert.NotNull(result);
        }
    }
}
