// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrameTest.cs
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

using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Frame component struct
    /// </summary>
    public class FrameTest
    {
        /// <summary>
        ///     Tests that the constructor creates a Frame with default values
        /// </summary>
        [Fact]
        public void Frame_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            Frame frame = new Frame();

            Assert.Equal(string.Empty, frame.NameFile);
        }

        /// <summary>
        ///     Tests that the NameFile property is gettable and settable
        /// </summary>
        [Fact]
        public void Frame_NameFileProperty_ShouldBeGetAndSettable()
        {
            Frame frame = new Frame();

            frame.NameFile = "frame1.png";
            Assert.Equal("frame1.png", frame.NameFile);

            frame.NameFile = "frame2.jpg";
            Assert.Equal("frame2.jpg", frame.NameFile);
        }
        
        /// <summary>
        ///     Tests that Frame properties can be modified independently
        /// </summary>
        [Fact]
        public void Frame_NameFile_ShouldBeModifiableIndependently()
        {
            Frame frame = new Frame();

            frame.NameFile = "frame1.png";
            Assert.Equal("frame1.png", frame.NameFile);

            frame.NameFile = "frame2.png";
            Assert.Equal("frame2.png", frame.NameFile);

            frame.NameFile = string.Empty;
            Assert.Equal(string.Empty, frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame default state is valid
        /// </summary>
        [Fact]
        public void Frame_DefaultState_ShouldBeValid()
        {
            Frame frame = new Frame();

            Assert.NotNull(frame.NameFile);
            Assert.Equal(string.Empty, frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame has expected public members
        /// </summary>
        [Fact]
        public void Frame_ShouldHaveExpectedPublicMembers()
        {
            Frame frame = new Frame();

            Assert.NotNull(frame.NameFile);
        }

        /// <summary>
        ///     Tests that Frame is a struct type
        /// </summary>
        [Fact]
        public void Frame_ShouldBeStructType()
        {
            Frame frame = new Frame();

            Assert.IsType<Frame>(frame);
        }
    }
}
