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
using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
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

        /// <summary>
        /// Tests that WithComponent with no args for Animator returns builder
        /// </summary>
        [Fact]
        public void WithComponent_NoArgs_Animator_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.WithComponent<Animator>();
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with no args for BoxCollider returns builder
        /// </summary>
        [Fact]
        public void WithComponent_NoArgs_BoxCollider_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.WithComponent<BoxCollider>();
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with no args for Info returns builder
        /// </summary>
        [Fact]
        public void WithComponent_NoArgs_Info_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.WithComponent<Info>();
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with Animator instance returns builder
        /// </summary>
        [Fact]
        public void WithComponent_WithAnimatorInstance_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            Animator animator = new Animator();
            GameObjectBuilder result = builder.WithComponent(animator);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with CameraConfig returns builder
        /// </summary>
        [Fact]
        public void WithComponent_WithCameraConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            CameraConfig<Camera> config = b => b.Position(100, 200).Resolution(800, 600);
            GameObjectBuilder result = builder.WithComponent(config);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with SpriteConfig returns builder
        /// </summary>
        [Fact]
        public void WithComponent_WithSpriteConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            SpriteConfig<Sprite> config = b => b.SetTexture("test.png").Depth(1);
            GameObjectBuilder result = builder.WithComponent(config);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with AudioSourceConfig returns builder
        /// </summary>
        [Fact]
        public void WithComponent_WithAudioSourceConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            AudioSourceConfig<AudioSource> config = b => b.File("sound.wav");
            GameObjectBuilder result = builder.WithComponent(config);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with BoxColliderConfig returns builder
        /// </summary>
        [Fact]
        public void WithComponent_WithBoxColliderConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            BoxColliderConfig<BoxCollider> config = b => b.Restitution(0.5f);
            GameObjectBuilder result = builder.WithComponent(config);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that WithComponent with Action config returns builder
        /// </summary>
        [Fact]
        public void WithComponent_WithActionConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.WithComponent<Info>(a => { });
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that Name after adding Info updates the name
        /// </summary>
        [Fact]
        public void Name_AfterAddingInfo_UpdatesInfo()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            builder.WithComponent<Info>();
            GameObjectBuilder result = builder.Name("UpdatedName");
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that Tag after adding Info updates the tag
        /// </summary>
        [Fact]
        public void Tag_AfterAddingInfo_UpdatesTag()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            builder.WithComponent<Info>();
            GameObjectBuilder result = builder.Tag("UpdatedTag");
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that IsActive after adding Info updates active
        /// </summary>
        [Fact]
        public void IsActive_AfterAddingInfo_UpdatesActive()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            builder.WithComponent<Info>();
            GameObjectBuilder result = builder.IsActive(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that IsStatic after adding Info updates static
        /// </summary>
        [Fact]
        public void IsStatic_AfterAddingInfo_UpdatesStatic()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            builder.WithComponent<Info>();
            GameObjectBuilder result = builder.IsStatic(true);
            Assert.Same(builder, result);
        }
    }
}
