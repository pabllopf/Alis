// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneBuilderTest.cs
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
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The scene builder test class
    /// </summary>
    public class SceneBuilderTest
    {
        /// <summary>
        /// Tests that constructor with context creates builder
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            SceneBuilder builder = new SceneBuilder(context);
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns scene instance
        /// </summary>
        [Fact]
        public void Build_ReturnsSceneInstance()
        {
            Context context = new Context();
            SceneBuilder builder = new SceneBuilder(context);
            Scene scene = builder.Build();
            Assert.NotNull(scene);
        }

        /// <summary>
        /// Tests that build returns same instance
        /// </summary>
        [Fact]
        public void Build_ReturnsSameInstance()
        {
            Context context = new Context();
            SceneBuilder builder = new SceneBuilder(context);
            Scene first = builder.Build();
            Scene second = builder.Build();
            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Add adds a game object and returns the builder
        /// </summary>
        [Fact]
        public void Add_WithEmptyConfig_ShouldReturnBuilder()
        {
            Context context = new Context();
            SceneBuilder builder = new SceneBuilder(context);

            SceneBuilder result = builder.Add<GameObject>(gb => { });

            Assert.Same(builder, result);
        }
    }
}
