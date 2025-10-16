// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeathZone.cs
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
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Manager.Time;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The death zone class
    /// </summary>
    
    public class DeathZone : IOnStart, IOnUpdate, IHasContext<Context>, IOnCollisionEnter
    {
        /// <summary>
        ///     The is death
        /// </summary>
        public static bool IsDeath;

        /// <summary>
        ///     The time delta
        /// </summary>
        public static float CounterTimeDeath = 3.0f;

        /// <summary>
        ///     Gets or sets the value of the bird
        /// </summary>
        public GameObject Bird { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is deadthing
        /// </summary>
        public bool IsDeadthing { get; set; }
        
        /// <summary>
        ///     Deadthings this instance
        /// </summary>
        public void Deadthing()
        {
            /*
            Bird.Get<AudioSource>().AudioClip = new AudioClip("die.wav");
            Bird.Get<AudioSource>().Play();

            Bird.Remove(Bird.Get<BirdController>());
            Logger.Info("Player remove bird controller");

            Bird.Get<BoxCollider>().Body.Rotation = -45f;
            Bird.Get<BoxCollider>().Body.LinearVelocity = new Vector2F(0, -3);
            Bird.Get<BoxCollider>().IsTrigger = true;
            Bird.Get<BoxCollider>().Body.GetBodyType = BodyType.Kinematic;

            Bird.Remove(Bird.Get<Animator>());

            PipelineController.IsStop = true;

            IsDeadthing = false;*/
        }
        
        

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            if (IsDeath)
            {
                if (IsDeadthing)
                {
                    Deadthing();
                }

                CounterTimeDeath -= 1f * Context.TimeManager.DeltaTime;
                if (CounterTimeDeath <= 0.0f)
                {
                    Context.SceneManager.LoadScene(0);
                    Logger.Info("RESET LEVEL");
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }
        
        /// <summary>
        /// Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void OnCollisionEnter(IGameObject gameObject)
        {
            Info info = gameObject.Get<Info>();
            if (info.Tag == "Player")
            {
                
                if (gameObject.Has<BirdController>() && !gameObject.Get<BirdController>().IsDead)
                {
                    IsDeath = true;
                    IsDeadthing = true;
                    Bird = (GameObject)gameObject;
                    Logger.Info($"Player dead by '{info.Name}'");
                }
            }
        }

        /// <summary>
        /// Ons the start using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            IsDeath = false;
            CounterTimeDeath = 3.0f;
        }
    }
}