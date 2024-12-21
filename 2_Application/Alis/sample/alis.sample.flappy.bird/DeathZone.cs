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

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The death zone class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class DeathZone : AComponent
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
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            IsDeath = false;
            CounterTimeDeath = 3.0f;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
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
                    Context.SceneManager.LoadScene("Main_Menu");
                    Logger.Info("RESET LEVEL");
                }
            }
        }

        /// <summary>
        ///     Deadthings this instance
        /// </summary>
        public void Deadthing()
        {
            Bird.Get<AudioSource>().AudioClip = new AudioClip("die.wav");
            Bird.Get<AudioSource>().Play();

            Bird.Remove(Bird.Get<BirdController>());
            Logger.Info("Player remove bird controller");

            Bird.Get<BoxCollider>().Body.Rotation = -45f;
            Bird.Get<BoxCollider>().Body.LinearVelocity = new Vector2F(0, -3);
            Bird.Get<BoxCollider>().IsTrigger = true;
            Bird.Get<BoxCollider>().Body.BodyType = BodyType.Kinematic;

            Bird.Remove(Bird.Get<Animator>());

            PipelineController.IsStop = true;

            IsDeadthing = false;
        }

        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                Logger.Info($"Player dead by '{GameObject.Name}'");

                if (gameObject.Contains<BirdController>() && !gameObject.Get<BirdController>().IsDead)
                {
                    IsDeath = true;
                    IsDeadthing = true;
                    Bird = gameObject;
                    Logger.Info("DEATH");
                }
            }
        }
    }
}