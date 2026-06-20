// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimationBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests the <see cref="AnimationBuilder" /> class.
    /// </summary>
    public class AnimationBuilderTest
    {
        /// <summary>
        ///     Tests that the constructor creates an AnimationBuilder with a Context.
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that Name sets the animation name and returns the builder.
        /// </summary>
        [Fact]
        public void Name_SetsAnimationName_ReturnsBuilder()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            AnimationBuilder result = builder.Name("TestAnimation");

            Assert.Same(builder, result);
            Assert.Equal("TestAnimation", builder.Build().Name);
        }

        /// <summary>
        ///     Tests that Speed sets the animation speed and returns the builder.
        /// </summary>
        [Fact]
        public void Speed_SetsAnimationSpeed_ReturnsBuilder()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            AnimationBuilder result = builder.Speed(2.5f);

            Assert.Same(builder, result);
            Assert.Equal(2.5f, builder.Build().Speed);
        }

        /// <summary>
        ///     Tests that Order sets the animation order and returns the builder.
        /// </summary>
        [Fact]
        public void Order_SetsAnimationOrder_ReturnsBuilder()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            AnimationBuilder result = builder.Order(42);

            Assert.Same(builder, result);
            Assert.Equal(42, builder.Build().Order);
        }

        /// <summary>
        ///     Tests that Build returns an Animation instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsAnimationInstance()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            Animation animation = builder.Build();

            Assert.NotNull(animation);
        }

        /// <summary>
        ///     Tests that AddFrame adds a frame and returns the builder.
        /// </summary>
        [Fact]
        public void AddFrame_WithLambda_AddsFrameAndReturnsBuilder()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            AnimationBuilder result = builder.AddFrame(fb => fb.File("test.png").Build());

            Assert.Same(builder, result);
            Animation animation = builder.Build();
            Assert.NotNull(animation.Frames);
            Assert.Single(animation.Frames);
        }

        /// <summary>
        ///     Tests that adding multiple frames works.
        /// </summary>
        [Fact]
        public void AddFrame_MultipleFrames_AddsAllFrames()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            builder.AddFrame(fb => fb.File("frame1.png").Build());
            builder.AddFrame(fb => fb.File("frame2.png").Build());

            Animation animation = builder.Build();
            Assert.Equal(2, animation.Frames.Count);
        }

        /// <summary>
        ///     Tests that chaining Name, Speed, and Order sets all properties correctly.
        /// </summary>
        [Fact]
        public void ChainingAllProperties_SetsAllValues()
        {
            Context context = new Context();
            AnimationBuilder builder = new AnimationBuilder(context);

            Animation animation = builder
                .Name("MyAnim")
                .Speed(1.5f)
                .Order(7)
                .Build();

            Assert.Equal("MyAnim", animation.Name);
            Assert.Equal(1.5f, animation.Speed);
            Assert.Equal(7, animation.Order);
        }
    }
}
