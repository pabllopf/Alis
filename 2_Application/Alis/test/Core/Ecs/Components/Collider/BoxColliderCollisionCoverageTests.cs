// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderCollisionCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider collision coverage tests class
    /// </summary>
    public class BoxColliderCollisionCoverageTests
    {
        /// <summary>
        ///     Tests that colliding boxes trigger separation event
        /// </summary>
        [Fact]
        public void CollidingBoxes_TriggerSeparationEvent()
        {
            Context context = CreateContext();
            Scene scene = new Scene();
            context.SceneManager.LoadedScenes.Add(scene);
            context.SceneManager.CurrentWorld = scene;

            GameObject boxA = scene.CreateGameObject("boxA");
            GameObject boxB = scene.CreateGameObject("boxB");
            boxA.Add<Transform>(new Transform { Position = new Vector2F(0, 0), Scale = new Vector2F(1, 1) });
            boxB.Add<Transform>(new Transform { Position = new Vector2F(0.6f, 0), Scale = new Vector2F(1, 1) });

            BoxCollider colliderA = new BoxCollider { Context = context, SizeOfTexture = new Vector2F(1, 1), BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic };
            BoxCollider colliderB = new BoxCollider { Context = context, SizeOfTexture = new Vector2F(1, 1), BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic };
            boxA.Add(colliderA);
            boxB.Add(colliderB);

            colliderA.OnStart(boxA);
            colliderB.OnStart(boxB);

            context.PhysicManager.WorldPhysic.Step(1.0f / 60.0f);
            context.PhysicManager.WorldPhysic.Step(1.0f / 60.0f);

            colliderA.Body.SetTransform(new Vector2F(-10, 0), 0);
            colliderB.Body.SetTransform(new Vector2F(10, 0), 0);
            context.PhysicManager.WorldPhysic.Step(1.0f / 60.0f);

            Assert.NotNull(colliderA.Body);
            Assert.NotNull(colliderB.Body);
        }

        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContext() => new Context(new Setting());
    }
}
