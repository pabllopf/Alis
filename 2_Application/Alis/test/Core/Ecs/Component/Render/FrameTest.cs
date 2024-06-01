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

using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Render
{
    /// <summary>
    /// The frame test class
    /// </summary>
    public class FrameTest
    {
        /// <summary>
        /// Tests that frame default constructor valid input
        /// </summary>
        [Fact]
        public void Frame_DefaultConstructor_ValidInput()
        {
            Frame frame = new Frame();
            
            Assert.NotNull(frame);
        }
        
        /// <summary>
        /// Tests that frame constructor with parameters valid input
        /// </summary>
        [Fact]
        public void Frame_ConstructorWithParameters_ValidInput()
        {
            VideoGame videoGame = new VideoGame();
            
            string filePath = "dino_assets.png";
            Frame frame = new Frame(filePath);
            
            Assert.NotNull(frame);
        }
        
        /// <summary>
        /// Tests that frame file path property valid input
        /// </summary>
        [Fact]
        public void Frame_FilePathProperty_ValidInput()
        {
            string filePath = "dino_assets.png";
            Frame frame = new Frame();
            frame.FilePath = filePath;
            
            Assert.NotNull(frame);
        }
        
        /// <summary>
        /// Tests that frame builder valid input
        /// </summary>
        [Fact]
        public void Frame_Builder_ValidInput()
        {
            Frame frame = new Frame();
            FrameBuilder frameBuilder = frame.Builder();
            
            Assert.NotNull(frame);
        }
    }
}