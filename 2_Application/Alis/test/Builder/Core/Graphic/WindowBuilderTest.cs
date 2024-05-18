// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowBuilderTest.cs
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

using Alis.Builder.Core.Graphic;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic;
using Xunit;

namespace Alis.Test.Builder.Core.Graphic
{
    /// <summary>
    /// The window builder test class
    /// </summary>
    public class WindowBuilderTest
    {
        /// <summary>
        /// Tests that window builder default constructor valid input
        /// </summary>
        [Fact]
        public void WindowBuilder_DefaultConstructor_ValidInput()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            
            Assert.NotNull(windowBuilder);
        }
        
        /// <summary>
        /// Tests that background valid input
        /// </summary>
        [Fact]
        public void Background_ValidInput()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            Color color = new Color(255, 255, 255, 255);
            
            windowBuilder.Background(color);
            
            Assert.Equal(color, windowBuilder.Build().Background);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            
            Window window = windowBuilder.Build();
            
            Assert.NotNull(window);
        }
        
        /// <summary>
        /// Tests that is resizable valid input
        /// </summary>
        [Fact]
        public void IsResizable_ValidInput()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            
            windowBuilder.IsResizable(true);
            
            Assert.True(windowBuilder.Build().IsWindowResizable);
        }
        
        /// <summary>
        /// Tests that resolution valid input
        /// </summary>
        [Fact]
        public void Resolution_ValidInput()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            Vector2 resolution = new Vector2(800, 600);
            
            windowBuilder.Resolution(resolution.X, resolution.Y);
            
            Assert.Equal(resolution, windowBuilder.Build().Resolution);
        }
        
        /// <summary>
        /// Tests that window builder default constructor valid input v 2
        /// </summary>
        [Fact]
        public void WindowBuilder_DefaultConstructor_ValidInput_v2()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            
            Assert.NotNull(windowBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input v 2
        /// </summary>
        [Fact]
        public void Build_ValidInput_v2()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            
            Window window = windowBuilder.Build();
            
            Assert.NotNull(window);
        }
        
        /// <summary>
        /// Tests that background valid input v 2
        /// </summary>
        [Fact]
        public void Background_ValidInput_v2()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            Color color = new Color(255, 255, 255, 255);
            
            windowBuilder.Background(color);
            
            Assert.Equal(color, windowBuilder.Build().Background);
        }
        
        /// <summary>
        /// Tests that is resizable valid input v 2
        /// </summary>
        [Fact]
        public void IsResizable_ValidInput_v2()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            
            windowBuilder.IsResizable(true);
            
            Assert.True(windowBuilder.Build().IsWindowResizable);
        }
        
        /// <summary>
        /// Tests that resolution valid input v 2
        /// </summary>
        [Fact]
        public void Resolution_ValidInput_v2()
        {
            WindowBuilder windowBuilder = new WindowBuilder();
            Vector2 resolution = new Vector2(1920, 1080);
            
            windowBuilder.Resolution(resolution.X, resolution.Y);
            
            Assert.Equal(resolution, windowBuilder.Build().Resolution);
        }
        
        /// <summary>
        /// Tests that is resizable no argument sets is window resizable to true
        /// </summary>
        [Fact]
        public void IsResizable_NoArgument_SetsIsWindowResizableToTrue()
        {
            WindowBuilder builder = new WindowBuilder();
            
            builder.IsResizable();
            
            Window result = builder.Build();
            
            Assert.True(result.IsWindowResizable);
        }
        
        /// <summary>
        /// Tests that is resizable with argument sets is window resizable to given value
        /// </summary>
        [Fact]
        public void IsResizable_WithArgument_SetsIsWindowResizableToGivenValue()
        {
            WindowBuilder builder = new WindowBuilder();
            
            builder.IsResizable(false);
            
            Window result = builder.Build();
            
            Assert.False(result.IsWindowResizable);
        }
        
        /// <summary>
        /// Tests that background sets background to given value
        /// </summary>
        [Fact]
        public void Background_SetsBackgroundToGivenValue()
        {
            WindowBuilder builder = new WindowBuilder();
            Color color = new Color(255, 255, 255, 255);
            
            builder.Background(color);
            
            Window result = builder.Build();
            
            Assert.Equal(color, result.Background);
        }
        
        /// <summary>
        /// Tests that resolution sets resolution to given value
        /// </summary>
        [Fact]
        public void Resolution_SetsResolutionToGivenValue()
        {
            WindowBuilder builder = new WindowBuilder();
            Vector2 resolution = new Vector2(1920, 1080);
            
            builder.Resolution(resolution.X, resolution.Y);
            
            Window result = builder.Build();
            
            Assert.Equal(resolution, result.Resolution);
        }
    }
}