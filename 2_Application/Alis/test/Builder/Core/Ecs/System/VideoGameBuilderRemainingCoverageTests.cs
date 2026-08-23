// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameBuilderRemainingCoverageTests.cs
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

using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System
{
    /// <summary>
    ///     The video game builder remaining coverage tests class
    /// </summary>
    public class VideoGameBuilderRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that settings applies configuration
        /// </summary>
        [Fact]
        public void Settings_AppliesConfiguration()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGameBuilder result = builder.Settings(settings => settings.Audio(audio => { }));

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that world configures scene manager
        /// </summary>
        [Fact]
        public void World_ConfiguresSceneManager()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGameBuilder result = builder.World(scene => { });

            Assert.Same(builder, result);
        }

        /// <summary>
        ///     Tests that build returns video game
        /// </summary>
        [Fact]
        public void Build_ReturnsVideoGame()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            VideoGame game = builder.Build();

            Assert.NotNull(game);
        }
    }
}
