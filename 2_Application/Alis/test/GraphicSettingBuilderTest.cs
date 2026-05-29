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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders.Graphic
{
    /// <summary>
    ///     Contains unit tests for the <see cref="GraphicSettingBuilder" /> class.
    /// </summary>
    public class GraphicSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a GraphicSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsGraphicSettingInstance()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSetting setting = builder.Build();

            Assert.IsType<GraphicSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null GraphicSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullGraphicSetting()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            Assert.IsAssignableFrom<IBuild<GraphicSetting>>(builder);
        }

        /// <summary>
        ///     Tests that Target can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void TargetCanBeSetViaBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            const string expectedTarget = "Vulkan";

            GraphicSetting setting = builder.Target(expectedTarget).Build();

            Assert.Equal(expectedTarget, setting.Target);
        }

        /// <summary>
        ///     Tests that FrameRate can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void FrameRateCanBeSetViaBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            const double expectedFrameRate = 144.0;

            GraphicSetting setting = builder.FrameRate(expectedFrameRate).Build();

            Assert.Equal(expectedFrameRate, setting.TargetFrames);
        }

        /// <summary>
        ///     Tests that Resolution can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void ResolutionCanBeSetViaBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            const int width = 1920;
            const int height = 1080;

            GraphicSetting setting = builder.Resolution(width, height).Build();

            Assert.Equal(width, setting.WindowSize.X);
            Assert.Equal(height, setting.WindowSize.Y);
        }

        /// <summary>
        ///     Tests that BackgroundColor can be set via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void BackgroundColorCanBeSetViaBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            Color expectedColor = new Color(255, 0, 0, 255);

            GraphicSetting setting = builder.BackgroundColor(expectedColor).Build();

            Assert.Equal(expectedColor.R, setting.BackgroundColor.R);
            Assert.Equal(expectedColor.G, setting.BackgroundColor.G);
            Assert.Equal(expectedColor.B, setting.BackgroundColor.B);
            Assert.Equal(expectedColor.A, setting.BackgroundColor.A);
        }

        /// <summary>
        ///     Tests that IsResizable can be set to true via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void IsResizableCanBeSetToTrueViaBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            GraphicSetting setting = builder.IsResizable(true).Build();

            Assert.True(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that IsResizable can be set to false via the builder and is reflected in the built result.
        /// </summary>
        [Fact]
        public void IsResizableCanBeSetToFalseViaBuilder()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            GraphicSetting setting = builder.IsResizable(false).Build();

            Assert.False(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that all properties can be set via fluent chaining and are reflected in the built result.
        /// </summary>
        [Fact]
        public void AllPropertiesCanBeSetViaFluentChaining()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            Color backgroundColor = new Color(10, 20, 30, 255);

            GraphicSetting setting = builder
                .Target("DirectX 12")
                .FrameRate(60.0)
                .Resolution(1280, 720)
                .BackgroundColor(backgroundColor)
                .IsResizable(false)
                .Build();

            Assert.Equal("DirectX 12", setting.Target);
            Assert.Equal(60.0, setting.TargetFrames);
            Assert.Equal(1280, setting.WindowSize.X);
            Assert.Equal(720, setting.WindowSize.Y);
            Assert.Equal(backgroundColor.R, setting.BackgroundColor.R);
            Assert.Equal(backgroundColor.G, setting.BackgroundColor.G);
            Assert.Equal(backgroundColor.B, setting.BackgroundColor.B);
            Assert.Equal(backgroundColor.A, setting.BackgroundColor.A);
            Assert.False(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that the builder returns itself from fluent methods for chaining.
        /// </summary>
        [Fact]
        public void BuilderReturnsItselfFromFluentMethods()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            GraphicSettingBuilder result = builder.Target("Test");

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that FrameRate with zero value can be set via the builder.
        /// </summary>
        [Fact]
        public void FrameRateCanBeSetToZero()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            GraphicSetting setting = builder.FrameRate(0.0).Build();

            Assert.Equal(0.0, setting.TargetFrames);
        }

        /// <summary>
        ///     Tests that Target with null value can be set via the builder.
        /// </summary>
        [Fact]
        public void TargetCanBeSetToNull()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            GraphicSetting setting = builder.Target(null).Build();

            Assert.Null(setting.Target);
        }

        /// <summary>
        ///     Tests that Resolution with negative values can be set via the builder.
        /// </summary>
        [Fact]
        public void ResolutionCanBeSetWithNegativeValues()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();

            GraphicSetting setting = builder.Resolution(-1, -1).Build();

            Assert.Equal(-1, setting.WindowSize.X);
            Assert.Equal(-1, setting.WindowSize.Y);
        }

        /// <summary>
        ///     Tests that the default Build returns default values.
        /// </summary>
        [Fact]
        public void DefaultBuildReturnsDefaultValues()
        {
            GraphicSettingBuilder builder = new GraphicSettingBuilder();
            GraphicSetting setting = builder.Build();

            Assert.Equal(60.0, setting.TargetFrames);
            Assert.Equal("OpenGL", setting.Target);
            Assert.Equal(800, setting.WindowSize.X);
            Assert.Equal(600, setting.WindowSize.Y);
            Assert.Equal(0, setting.BackgroundColor.R);
            Assert.Equal(0, setting.BackgroundColor.G);
            Assert.Equal(0, setting.BackgroundColor.B);
            Assert.Equal(255, setting.BackgroundColor.A);
            Assert.True(setting.IsResizable);
        }
    }
}
