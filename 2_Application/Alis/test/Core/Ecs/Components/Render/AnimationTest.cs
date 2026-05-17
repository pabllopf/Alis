// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimationTest.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Animation component struct
    /// </summary>
    public class AnimationTest
    {
        /// <summary>
        ///     Tests that the constructor creates an Animation with default values
        /// </summary>
        [Fact]
        public void Animation_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            Animation animation = new Animation();

            Assert.Null(animation.Name);
            Assert.Equal(0, animation.Order);
            Assert.Equal(0f, animation.Speed);
            Assert.NotNull(animation.Frames);
            Assert.Empty(animation.Frames);
        }

        /// <summary>
        ///     Tests that Animation implements IAnimation interface
        /// </summary>
        [Fact]
        public void Animation_ShouldImplementIAnimationInterface()
        {
            Animation animation = new Animation();

            Assert.IsAssignableFrom<IAnimation>(animation);
        }

        /// <summary>
        ///     Tests that Animation properties are gettable and settable
        /// </summary>
        [Fact]
        public void Animation_Properties_ShouldBeGetAndSettable()
        {
            Animation animation = new Animation();

            animation.Name = "Walk";
            Assert.Equal("Walk", animation.Name);

            animation.Order = 5;
            Assert.Equal(5, animation.Order);

            animation.Speed = 2.5f;
            Assert.Equal(2.5f, animation.Speed);

            List<Frame> frames = new List<Frame>();
            animation.Frames = frames;
            Assert.Same(frames, animation.Frames);
        }
        
        /// <summary>
        ///     Tests that Animation properties can be modified
        /// </summary>
        [Fact]
        public void Animation_Properties_ShouldBeModifiable()
        {
            Animation animation = new Animation();

            animation.Name = "Run";
            Assert.Equal("Run", animation.Name);

            animation.Order = 10;
            Assert.Equal(10, animation.Order);

            animation.Speed = 5f;
            Assert.Equal(5f, animation.Speed);

            List<Frame> frames = new List<Frame>
            {
                new Frame { NameFile = "frame1.png" },
                new Frame { NameFile = "frame2.png" }
            };

            animation.Frames = frames;
            Assert.Equal(2, animation.Frames.Count);
        }

        /// <summary>
        ///     Tests that Animation default state is valid
        /// </summary>
        [Fact]
        public void Animation_DefaultState_ShouldBeValid()
        {
            Animation animation = new Animation();

            Assert.NotNull(animation.Frames);
            Assert.IsType<List<Frame>>(animation.Frames);
            Assert.Equal(0, animation.Order);
            Assert.Equal(0f, animation.Speed);
        }

        /// <summary>
        ///     Tests that Animation has expected public members
        /// </summary>
        [Fact]
        public void Animation_ShouldHaveExpectedPublicMembers()
        {
            Animation animation = new Animation();

            Assert.NotNull(animation.Name);
            Assert.Equal(0, animation.Order);
            Assert.Equal(0f, animation.Speed);
            Assert.NotNull(animation.Frames);

            Assert.NotNull(animation.AddFrame);
        }
    }
}
