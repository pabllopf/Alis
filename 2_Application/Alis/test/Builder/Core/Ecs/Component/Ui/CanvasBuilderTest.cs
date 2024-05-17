// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CanvasBuilderTest.cs
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

namespace Alis.Test.Builder.Core.Ecs.Component.Ui
{
    /// <summary>
    /// The canvas builder test class
    /// </summary>
    public class CanvasBuilderTest
    {
        /// <summary>
        /// Tests that canvas builder default constructor valid input
        /// </summary>
        [Fact]
        public void CanvasBuilder_DefaultConstructor_ValidInput()
        {
            CanvasBuilder canvasBuilder = new CanvasBuilder();
            
            Assert.NotNull(canvasBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            CanvasBuilder canvasBuilder = new CanvasBuilder();
            
            Canvas canvas = canvasBuilder.Build();
            
            Assert.NotNull(canvas);
        }
    }
}