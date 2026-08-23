// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderCollisionHandlerTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider collision handler test class
    /// </summary>
    public class BoxColliderCollisionHandlerTest
    {
        /// <summary>
        ///     Tests that a collision with a component implementing collision enter invokes the handler
        /// </summary>
        [Fact]
        public void OnCollision_WithCollisionEnterComponent_InvokesHandler()
        {
            Context context = new Context(new Setting());
            Scene scene = new Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;

            bool enterInvoked = false;
            int enterCount = 0;

            GameObject gameObjectA = scene.Create(
                new Transform { Position = new Vector2F(0, 0), Scale = new Vector2F(1, 1) },
                new CollisionEnterComponent { OnEnterAction = other => { enterInvoked = true; enterCount++; } },
                new BoxCollider { SizeOfTexture = new Vector2F(1, 1), BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic });
            GameObject gameObjectB = scene.Create(
                new Transform { Position = new Vector2F(0.5f, 0), Scale = new Vector2F(1, 1) },
                new CollisionEnterComponent { OnEnterAction = other => { enterInvoked = true; enterCount++; } },
                new BoxCollider { SizeOfTexture = new Vector2F(1, 1), BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic });

            BoxCollider colliderA = gameObjectA.Get<BoxCollider>();
            BoxCollider colliderB = gameObjectB.Get<BoxCollider>();
            colliderA.Context = context;
            colliderB.Context = context;

            colliderA.OnStart(gameObjectA);
            colliderB.OnStart(gameObjectB);

            for (int i = 0; i < 10; i++)
            {
                context.PhysicManager.WorldPhysic.Step(1.0f / 60.0f);
            }

            Assert.True(enterInvoked);
            Assert.True(enterCount >= 1);
        }

        /// <summary>
        ///     Tests that a collision with a component implementing collision exit invokes the handler on separation
        /// </summary>
        [Fact]
        public void OnSeparation_WithCollisionExitComponent_InvokesHandler()
        {
            Context context = new Context(new Setting());
            Scene scene = new Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;

            bool exitInvoked = false;
            int exitCount = 0;

            GameObject gameObjectA = scene.Create(
                new Transform { Position = new Vector2F(0, 0), Scale = new Vector2F(1, 1) },
                new CollisionExitComponent { OnExitAction = other => { exitInvoked = true; exitCount++; } },
                new BoxCollider { SizeOfTexture = new Vector2F(1, 1), BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic });
            GameObject gameObjectB = scene.Create(
                new Transform { Position = new Vector2F(0.5f, 0), Scale = new Vector2F(1, 1) },
                new CollisionExitComponent { OnExitAction = other => { exitInvoked = true; exitCount++; } },
                new BoxCollider { SizeOfTexture = new Vector2F(1, 1), BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic });

            BoxCollider colliderA = gameObjectA.Get<BoxCollider>();
            BoxCollider colliderB = gameObjectB.Get<BoxCollider>();
            colliderA.Context = context;
            colliderB.Context = context;

            colliderA.OnStart(gameObjectA);
            colliderB.OnStart(gameObjectB);

            for (int i = 0; i < 10; i++)
            {
                context.PhysicManager.WorldPhysic.Step(1.0f / 60.0f);
            }

            colliderA.Body.SetTransform(new Vector2F(-50, 0), 0);
            colliderB.Body.SetTransform(new Vector2F(50, 0), 0);

            for (int i = 0; i < 10; i++)
            {
                context.PhysicManager.WorldPhysic.Step(1.0f / 60.0f);
            }

            Assert.True(exitInvoked);
            Assert.True(exitCount >= 1);
        }
    }

    /// <summary>
    ///     The collision enter component class
    /// </summary>
    public class CollisionEnterComponent : IOnCollisionEnter
    {
        /// <summary>
        ///     Gets or sets the on enter action
        /// </summary>
        public System.Action<IGameObject> OnEnterAction { get; set; }

        /// <summary>
        ///     Ons the collision enter using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        public void OnCollisionEnter(IGameObject other) => OnEnterAction(other);
    }

    /// <summary>
    ///     The collision exit component class
    /// </summary>
    public class CollisionExitComponent : IOnCollisionExit
    {
        /// <summary>
        ///     Gets or sets the on exit action
        /// </summary>
        public System.Action<IGameObject> OnExitAction { get; set; }

        /// <summary>
        ///     Ons the collision exit using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        public void OnCollisionExit(IGameObject other) => OnExitAction(other);
    }
}
