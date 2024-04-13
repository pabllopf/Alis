// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlRendererInfoTest.cs
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

using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The sdl renderer info test class
    /// </summary>
    public class SdlRendererInfoTest
    {
        /// <summary>
        ///     Tests that get name valid call returns expected string
        /// </summary>
        [Fact]
        public void GetName_ValidCall_ReturnsExpectedString()
        {
            // Arrange
            int initResult = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, initResult);
            
            RendererInfo rendererInfo = new RendererInfo(); // Replace with the actual SdlRendererInfo
            
            // Act
            string result = rendererInfo.GetName();
            
            // Assert
            Assert.NotEqual("", result);
            
            Sdl.Quit();
        }
    }
}