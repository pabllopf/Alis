// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicSettingBuilderTest.cs
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

using System;
using Alis.Builder.Core.Ecs.System.Setting.Graphic;
using Alis.Builder.Core.Graphic;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Graphic;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.Setting.Graphic
{
    /// <summary>
    ///     The graphic setting builder test class
    /// </summary>
    public class GraphicSettingBuilderTest
    {
        /// <summary>
        ///     Tests that graphic setting builder default constructor valid input
        /// </summary>
        [Fact]
        public void GraphicSettingBuilder_DefaultConstructor_ValidInput()
        {
            GraphicSettingBuilder graphicSettingBuilder = new GraphicSettingBuilder();
            
            Assert.NotNull(graphicSettingBuilder);
        }
        
        /// <summary>
        ///     Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            GraphicSettingBuilder graphicSettingBuilder = new GraphicSettingBuilder();
            
            GraphicSetting graphicSetting = graphicSettingBuilder.Build();
            
            Assert.NotNull(graphicSetting);
        }
        
        /// <summary>
        ///     Tests that window valid input
        /// </summary>
        [Fact]
        public void Window_ValidInput()
        {
            GraphicSettingBuilder graphicSettingBuilder = new GraphicSettingBuilder();
            Func<WindowBuilder, Window> windowFunc = wb => wb.Build();
            
            graphicSettingBuilder.Window(windowFunc);
            
            Assert.NotNull(graphicSettingBuilder.Build().Window);
        }
    }
}