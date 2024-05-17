// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CanvasTest.cs
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

using Alis.Builder.Core.Ecs.Component.Ui;
using Alis.Core.Ecs.Component.Ui;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Ui
{
    /// <summary>
    /// The canvas test class
    /// </summary>
    public class CanvasTest
    {
        /// <summary>
        /// Tests that canvas default constructor valid input
        /// </summary>
        [Fact]
        public void Canvas_DefaultConstructor_ValidInput()
        {
            Canvas canvas = new Canvas();
            
            Assert.NotNull(canvas);
            Assert.Equal(0, canvas.Width);
            Assert.Equal(0, canvas.Height);
        }
        
        /// <summary>
        /// Tests that canvas width property valid input
        /// </summary>
        [Fact]
        public void Canvas_WidthProperty_ValidInput()
        {
            Canvas canvas = new Canvas();
            canvas.Width = 800;
            
            Assert.Equal(800, canvas.Width);
        }
        
        /// <summary>
        /// Tests that canvas height property valid input
        /// </summary>
        [Fact]
        public void Canvas_HeightProperty_ValidInput()
        {
            Canvas canvas = new Canvas();
            canvas.Height = 600;
            
            Assert.Equal(600, canvas.Height);
        }
        
        /// <summary>
        /// Tests that canvas builder valid input
        /// </summary>
        [Fact]
        public void Canvas_Builder_ValidInput()
        {
            Canvas canvas = new Canvas();
            CanvasBuilder canvasBuilder = canvas.Builder();
            
            Assert.NotNull(canvasBuilder);
            Assert.IsType<CanvasBuilder>(canvasBuilder);
        }
    }
}