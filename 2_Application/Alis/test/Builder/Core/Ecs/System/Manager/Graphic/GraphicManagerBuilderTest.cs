// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Graphic;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Manager.Graphic
{
    /// <summary>
    /// The graphic manager builder test class
    /// </summary>
    public class GraphicManagerBuilderTest
    {
        /// <summary>
        /// Tests that graphic manager builder default constructor valid input
        /// </summary>
        [Fact]
        public void GraphicManagerBuilder_DefaultConstructor_ValidInput()
        {
            GraphicManagerBuilder graphicManagerBuilder = new GraphicManagerBuilder();
            
            Assert.NotNull(graphicManagerBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            GraphicManagerBuilder graphicManagerBuilder = new GraphicManagerBuilder();
            
            GraphicManager graphicManager = graphicManagerBuilder.Build();
            
            Assert.NotNull(graphicManager);
        }
    }
}