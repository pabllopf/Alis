// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowTest.cs
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

namespace Alis.Test.Core.Graphic
{
    /// <summary>
    /// The window test class
    /// </summary>
    public class WindowTest
    {
        /// <summary>
        /// Tests that background set value should change background
        /// </summary>
        [Fact]
        public void Background_SetValue_ShouldChangeBackground()
        {
            Window window = new Window();
            Color color = new Color(255, 255, 255, 255);
            
            window.Background = color;
            
            Assert.Equal(color, window.Background);
        }
        
        /// <summary>
        /// Tests that resolution set value should change resolution
        /// </summary>
        [Fact]
        public void Resolution_SetValue_ShouldChangeResolution()
        {
            Window window = new Window();
            Vector2 resolution = new Vector2(1920, 1080);
            
            window.Resolution = resolution;
            
            Assert.Equal(resolution, window.Resolution);
        }
        
        /// <summary>
        /// Tests that is window resizable set value should change is window resizable
        /// </summary>
        [Fact]
        public void IsWindowResizable_SetValue_ShouldChangeIsWindowResizable()
        {
            Window window = new Window();
            
            window.IsWindowResizable = false;
            
            Assert.False(window.IsWindowResizable);
        }
        
        /// <summary>
        /// Tests that builder call method should return window builder
        /// </summary>
        [Fact]
        public void Builder_CallMethod_ShouldReturnWindowBuilder()
        {
            Window window = new Window();
            
            WindowBuilder result = window.Builder();
            
            Assert.IsType<WindowBuilder>(result);
        }
    }
}