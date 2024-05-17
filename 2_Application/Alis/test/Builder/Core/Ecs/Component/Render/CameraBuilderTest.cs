// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CameraBuilderTest.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Render
{
    /// <summary>
    /// The camera builder test class
    /// </summary>
    public class CameraBuilderTest
    {
        /// <summary>
        /// Tests that camera builder default constructor valid input
        /// </summary>
        [Fact]
        public void CameraBuilder_DefaultConstructor_ValidInput()
        {
            CameraBuilder cameraBuilder = new CameraBuilder();
            
            Assert.NotNull(cameraBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            CameraBuilder cameraBuilder = new CameraBuilder();
            
            Camera camera = cameraBuilder.Build();
            
            Assert.NotNull(camera);
        }
        
        /// <summary>
        /// Tests that background color valid input
        /// </summary>
        [Fact]
        public void BackgroundColor_ValidInput()
        {
            CameraBuilder cameraBuilder = new CameraBuilder();
            Color color = new Color(255, 255, 255, 255);
            
            cameraBuilder.BackgroundColor(color);
            
            Assert.Equal(color, cameraBuilder.Build().BackgroundColor);
        }
        
        /// <summary>
        /// Tests that resolution valid input
        /// </summary>
        [Fact]
        public void Resolution_ValidInput()
        {
            CameraBuilder cameraBuilder = new CameraBuilder();
            int resolutionX = 1920;
            int resolutionY = 1080;
            
            cameraBuilder.Resolution(resolutionX, resolutionY);
            
            Assert.Equal(new Vector2(resolutionX, resolutionY), cameraBuilder.Build().Resolution);
        }
    }
}