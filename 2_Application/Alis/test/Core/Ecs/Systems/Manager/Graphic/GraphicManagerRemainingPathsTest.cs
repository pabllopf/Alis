// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerRemainingPathsTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     Tests the remaining runtime paths of the graphic manager
    /// </summary>
    public class GraphicManagerRemainingPathsTest
    {
        /// <summary>
        ///     Creates the context with a scene as current world
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The context</returns>
        private static Context CreateContextWithWorld(Alis.Core.Ecs.Scene scene)
        {
            Context context = new Context(new Setting());
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

        /// <summary>
        ///     Tests that process key event components invokes handlers for objects with info
        /// </summary>
        [Fact]
        public void ProcessKeyEventComponents_WithInfoAndPressComponent_InvokesHandler()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreateContextWithWorld(scene);
            GraphicManager manager = new GraphicManager(context);
            bool wasCalled = false;

            GameObject go = scene.Create();
            go.Add(new Info {Name = "player"});
            PressSpyComponent spy = new PressSpyComponent();
            spy.OnPressKeyAction = (info) => wasCalled = true;
            go.Add(spy);

            manager.ProcessKeyEventComponents(new HashSet<ConsoleKey> {ConsoleKey.A}, new HashSet<ConsoleKey>(), new HashSet<ConsoleKey>(), DateTime.UtcNow);

            Assert.True(wasCalled);
        }

        /// <summary>
        ///     Tests that process key event components with no matching objects does not throw
        /// </summary>
        [Fact]
        public void ProcessKeyEventComponents_WithEmptyWorld_DoesNotThrow()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreateContextWithWorld(scene);
            GraphicManager manager = new GraphicManager(context);

            manager.ProcessKeyEventComponents(new HashSet<ConsoleKey>(), new HashSet<ConsoleKey>(), new HashSet<ConsoleKey>(), DateTime.UtcNow);
        }

        /// <summary>
        ///     Tests that render sprites with invisible sprite returns early without throwing
        /// </summary>
        [Fact]
        public void RenderSprites_WithInvisibleSprite_DoesNotThrow()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreateContextWithWorld(scene);

            GameObject spriteGo = scene.Create();
            spriteGo.Add(new Transform(new Vector2F(5000f, 5000f), 0f));
            spriteGo.Add(new Sprite(context, string.Empty, 0));

            GameObject cameraGo = scene.Create();
            cameraGo.Add(new Camera(context, new Vector2F(0f, 0f), new Vector2F(800f, 600f)));

            GameObjectQueryEnumerator.QueryEnumerable sprites = scene.Query<With<Sprite>>().EnumerateWithEntities();

            foreach (RefTuple<Camera> camera in scene.Query<With<Camera>>().Enumerate<Camera>())
            {
                GraphicManager.RenderSprites(sprites, camera, 32f);
            }
        }

        /// <summary>
        ///     Tests that render sprites with animator and invisible sprite does not throw
        /// </summary>
        [Fact]
        public void RenderSprites_WithAnimatorAndInvisibleSprite_DoesNotThrow()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreateContextWithWorld(scene);

            GameObject spriteGo = scene.Create();
            spriteGo.Add(new Transform(new Vector2F(9000f, 9000f), 0f));
            Animator animator = new Animator(new List<Animation>
            {
                new Animation("idle", 0, 1f, new List<Frame> {new Frame {NameFile = string.Empty}})
            });
            spriteGo.Add(animator);
            spriteGo.Add(new Sprite(context, string.Empty, 0));

            GameObject cameraGo = scene.Create();
            cameraGo.Add(new Camera(context, new Vector2F(0f, 0f), new Vector2F(800f, 600f)));

            GameObjectQueryEnumerator.QueryEnumerable sprites = scene.Query<With<Sprite>>().EnumerateWithEntities();

            foreach (RefTuple<Camera> camera in scene.Query<With<Camera>>().Enumerate<Camera>())
            {
                GraphicManager.RenderSprites(sprites, camera, 32f);
            }
        }

        /// <summary>
        ///     Tests that render box colliders with debug disabled does not throw
        /// </summary>
        [Fact]
        public void RenderBoxColliders_WithDebugDisabled_DoesNotThrow()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreateContextWithWorld(scene);

            GameObject colliderGo = scene.Create();
            colliderGo.Add(new Transform(new Vector2F(0f, 0f), 0f));
            colliderGo.Add(new BoxCollider());

            GameObject cameraGo = scene.Create();
            cameraGo.Add(new Camera(context, new Vector2F(0f, 0f), new Vector2F(800f, 600f)));

            GameObjectQueryEnumerator.QueryEnumerable colliders = scene.Query<With<BoxCollider>>().EnumerateWithEntities();

            foreach (RefTuple<Camera> camera in scene.Query<With<Camera>>().Enumerate<Camera>())
            {
                GraphicManager.RenderBoxColliders(colliders, context.Setting.Physic, camera, 32f);
            }
        }
    }

    /// <summary>
    ///     The press spy component class
    /// </summary>
    /// <seealso cref="IOnPressKey"/>
    public class PressSpyComponent : IOnPressKey
    {
        /// <summary>
        ///     Gets or sets the value of the on press key action
        /// </summary>
        public Action<KeyEventInfo> OnPressKeyAction { get; set; }

        /// <summary>
        ///     Ons the press key using the specified key event info
        /// </summary>
        /// <param name="keyEventInfo">The key event info</param>
        public void OnPressKey(KeyEventInfo keyEventInfo) => OnPressKeyAction(keyEventInfo);
    }
}
