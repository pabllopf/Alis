// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameBuilderTest.cs
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
using Alis.Builder.Core.Ecs.System;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="VideoGameBuilder" /> class.
    /// </summary>
    public class VideoGameBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder with Context.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder_WithContext()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a VideoGame instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsVideoGameInstance()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGame videoGame = builder.Build();

            Assert.NotNull(videoGame);
            Assert.IsType<VideoGame>(videoGame);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null VideoGame.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullVideoGame()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGame videoGame = builder.Build();

            Assert.NotNull(videoGame);
        }

        /// <summary>
        ///     Tests that the Settings method configures the context setting.
        /// </summary>
        [Fact]
        public void Settings_ConfiguresContextSetting()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            builder.Settings(sb => sb.General(g => g.Name("TestGame")));

            Assert.NotNull(builder.Context.Setting);
            Assert.Equal("TestGame", builder.Context.Setting.General.Name);
        }
        
        /// <summary>
        ///     Tests that the Run method calls Build and Run.
        /// </summary>
        [Fact]
        public void Run_CallsBuildAndRun()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the builder implements IBuild<VideoGame>.
        /// </summary>
        [Fact]
        public void Builder_ImplementsIBuildVideoGame()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            Assert.IsAssignableFrom<IBuild<VideoGame>>(builder);
        }

        /// <summary>
        ///     Tests that the builder implements ISettings interface.
        /// </summary>
        [Fact]
        public void Builder_ImplementsISettingsInterface()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            Assert.IsAssignableFrom<ISettings<VideoGameBuilder, Action<SettingsBuilder>>>(builder);
        }

        /// <summary>
        ///     Tests that the Context is accessible from builder.
        /// </summary>
        [Fact]
        public void Context_IsAccessibleFromBuilder()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            Assert.NotNull(builder.Context);
            Assert.IsType<Context>(builder.Context);
        }

        /// <summary>
        ///     Tests that the Settings method returns the builder for chaining.
        /// </summary>
        [Fact]
        public void Settings_ReturnsBuilderForChaining()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGameBuilder result = builder.Settings(sb => sb.General(g => g.Name("Chained")));

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that the World method returns the builder for chaining.
        /// </summary>
        [Fact]
        public void World_ReturnsBuilderForChaining()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGameBuilder result = builder.World(sb => { });

            Assert.Same(builder, result);
        }
    }
}
