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
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The video game builder test class
    /// </summary>
    public class VideoGameBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            VideoGameBuilder builder = new VideoGameBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns video game instance
        /// </summary>
        [Fact]
        public void Build_ReturnsVideoGameInstance()
        {
            VideoGameBuilder builder = new VideoGameBuilder();
            VideoGame result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that settings with config returns builder
        /// </summary>
        [Fact]
        public void Settings_WithConfig_ReturnsBuilder()
        {
            VideoGameBuilder builder = new VideoGameBuilder();
            VideoGameBuilder result = builder.Settings(s => s
                .General(g => g.Name("Game").Version("1.0"))
                .Graphic(g => g.Target("OpenGL").Resolution(800, 600)));
            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that World with config returns builder
        /// </summary>
        [Fact]
        public void World_WithEmptyConfig_ShouldReturnBuilder()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGameBuilder result = builder.World(sb => { });

            Assert.Same(builder, result);
        }
    }
}
