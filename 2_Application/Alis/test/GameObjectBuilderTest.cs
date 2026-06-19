// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectBuilderTest.cs
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
    /// The game object builder test class
    /// </summary>
    public class GameObjectBuilderTest
    {
        /// <summary>
        /// Tests that constructor with scene and context creates builder
        /// </summary>
        [Fact]
        public void Constructor_WithSceneAndContext_CreatesBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns game object instance
        /// </summary>
        [Fact]
        public void Build_ReturnsGameObjectInstance()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObject gameObject = builder.Build();
            Assert.NotNull(gameObject);
        }

        /// <summary>
        /// Tests that name sets name returns builder
        /// </summary>
        [Fact]
        public void Name_SetsName_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.Name("Player");
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that tag sets tag returns builder
        /// </summary>
        [Fact]
        public void Tag_SetsTag_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.Tag("Player");
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that id sets id returns builder
        /// </summary>
        [Fact]
        public void Id_SetsId_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.Id(1);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is active sets active returns builder
        /// </summary>
        [Fact]
        public void IsActive_SetsActive_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.IsActive(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is active no args returns builder
        /// </summary>
        [Fact]
        public void IsActive_NoArgs_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.IsActive();
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is static sets static returns builder
        /// </summary>
        [Fact]
        public void IsStatic_SetsStatic_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.IsStatic(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is static no args returns builder
        /// </summary>
        [Fact]
        public void IsStatic_NoArgs_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.IsStatic();
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that transform with config returns builder
        /// </summary>
        [Fact]
        public void Transform_WithConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.Transform(t => t.Position(1, 2).Rotation(0).Scale(1, 1));
            Assert.Same(builder, result);
        }
    }
}
