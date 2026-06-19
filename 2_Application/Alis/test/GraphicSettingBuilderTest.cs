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

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Graphic;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The graphic setting builder test class
    /// </summary>
    public class GraphicSettingBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns graphic setting instance
        /// </summary>
        [Fact]
        public void Build_ReturnsGraphicSettingInstance()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSetting result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that target sets target returns builder
        /// </summary>
        [Fact]
        public void Target_SetsTarget_ReturnsBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSettingBuilder result = builder.Target("OpenGL");
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that frame rate sets frame rate returns builder
        /// </summary>
        [Fact]
        public void FrameRate_SetsFrameRate_ReturnsBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSettingBuilder result = builder.FrameRate(60.0);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that resolution sets resolution returns builder
        /// </summary>
        [Fact]
        public void Resolution_SetsResolution_ReturnsBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSettingBuilder result = builder.Resolution(1920, 1080);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that background color sets color returns builder
        /// </summary>
        [Fact]
        public void BackgroundColor_SetsColor_ReturnsBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSettingBuilder result = builder.BackgroundColor(Color.Black);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is resizable sets flag returns builder
        /// </summary>
        [Fact]
        public void IsResizable_SetsFlag_ReturnsBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSettingBuilder result = builder.IsResizable(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates graphic setting
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesGraphicSetting()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSetting result = builder
                .Target("Vulkan")
                .FrameRate(144.0)
                .Resolution(2560, 1440)
                .BackgroundColor(Color.Black)
                .IsResizable(false)
                .Build();
            Assert.NotNull(result);
        }
    }
}
