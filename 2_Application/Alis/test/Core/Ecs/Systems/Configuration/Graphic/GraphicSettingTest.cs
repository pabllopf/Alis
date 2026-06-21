// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicSettingTest.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration.Graphic
{
    /// <summary>
    ///     Tests for the GraphicSetting struct
    /// </summary>
    public class GraphicSettingTest
    {
        /// <summary>
        ///     Tests that default constructor sets expected values
        /// </summary>
        [Fact]
        public void GraphicSetting_DefaultConstructor_ShouldSetDefaultValues()
        {
            GraphicSetting setting = new GraphicSetting();

            Assert.Equal(60.0, setting.TargetFrames);
            Assert.Equal("OpenGL", setting.Target);
            Assert.False(setting.PreviewMode);
            Assert.Equal(Color.White, setting.GridColor);
            Assert.False(setting.HasGrid);
            Assert.Equal(Color.Black, setting.BackgroundColor);
            Assert.Equal(800f, setting.WindowSize.X);
            Assert.Equal(600f, setting.WindowSize.Y);
            Assert.True(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that parameterized constructor sets all values
        /// </summary>
        [Fact]
        public void GraphicSetting_ParameterizedConstructor_ShouldSetValues()
        {
            Vector2F windowSize = new Vector2F(1920, 1080);
            GraphicSetting setting = new GraphicSetting(
                120.0, "Vulkan", true,
                Color.Red, true, Color.Blue,
                windowSize, false);

            Assert.Equal(120.0, setting.TargetFrames);
            Assert.Equal("Vulkan", setting.Target);
            Assert.True(setting.PreviewMode);
            Assert.Equal(Color.Red, setting.GridColor);
            Assert.True(setting.HasGrid);
            Assert.Equal(Color.Blue, setting.BackgroundColor);
            Assert.Equal(1920f, setting.WindowSize.X);
            Assert.Equal(1080f, setting.WindowSize.Y);
            Assert.False(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that properties can be modified after construction
        /// </summary>
        [Fact]
        public void GraphicSetting_Properties_ShouldBeModifiable()
        {
            GraphicSetting setting = new GraphicSetting();

            setting.TargetFrames = 144.0;
            Assert.Equal(144.0, setting.TargetFrames);

            setting.Target = "DirectX";
            Assert.Equal("DirectX", setting.Target);

            setting.PreviewMode = true;
            Assert.True(setting.PreviewMode);

            setting.HasGrid = true;
            Assert.True(setting.HasGrid);

            setting.WindowSize = new Vector2F(1024, 768);
            Assert.Equal(1024f, setting.WindowSize.X);
            Assert.Equal(768f, setting.WindowSize.Y);

            setting.IsResizable = false;
            Assert.False(setting.IsResizable);

            Color red = new Color(255, 0, 0, 255);
            setting.GridColor = red;
            Assert.Equal(red, setting.GridColor);

            setting.BackgroundColor = Color.White;
            Assert.Equal(Color.White, setting.BackgroundColor);
        }

        /// <summary>
        ///     Tests that GraphicSetting implements IGraphicSetting interface
        /// </summary>
        [Fact]
        public void GraphicSetting_ShouldImplementIGraphicSetting()
        {
            GraphicSetting setting = new GraphicSetting();
            Assert.IsAssignableFrom<IGraphicSetting>(setting);
        }
    }
}
