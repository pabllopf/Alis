// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Player.cs
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
using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid.Desktop
{
    /// <summary>
    ///     The player class
    /// </summary>
    /// <seealso cref="IOnStart" />
    /// <seealso cref="IOnUpdate" />
    /// <seealso cref="IOnReleaseKey" />
    /// <seealso cref="IOnPressKey" />
    /// <seealso cref="IOnHoldKey" />
    /// <seealso cref="IHasContext{Context}" />
    public class Player : IOnStart, IOnUpdate, IOnReleaseKey, IOnPressKey, IOnHoldKey, IHasContext<Context>
    {
        /// <summary>
        ///     The reset time
        /// </summary>
        private readonly float resetTime = 3;

        /// <summary>
        ///     The acceleration
        /// </summary>
        public float acceleration = 2.0f;

        /// <summary>
        ///     The audio source
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The counter entities
        /// </summary>
        private int counterEntities = 3;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F direction = new Vector2F(0, 0);

        /// <summary>
        ///     The game object
        /// </summary>
        private IGameObject gameObject;

        /// <summary>
        ///     The time counter
        /// </summary>
        private float timeCounter = 3;

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        ///     Ons the hold key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnHoldKey(KeyEventInfo info)
        {
            ConsoleKey key = info.Key;
            if (key == ConsoleKey.D)
            {
                direction.X = 1;
            }

            if (key == ConsoleKey.A)
            {
                direction.X = -1;
            }

            if (key == ConsoleKey.W)
            {
                direction.Y = 1;
            }

            if (key == ConsoleKey.S)
            {
                direction.Y = -1;
            }

            if (key == ConsoleKey.A || key == ConsoleKey.D || key == ConsoleKey.W || key == ConsoleKey.S)
            {
                boxCollider.Body.ApplyForce(direction * acceleration);
            }
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public void OnPressKey(KeyEventInfo info)
        {
            ConsoleKey key = info.Key;
            if ((key == ConsoleKey.Spacebar) && (direction.X != 0 || direction.Y != 0))
            {
                audioSource.Play();
                CreateBullet();
            }
        }

        /// <summary>
        ///     Ons the release key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnReleaseKey(KeyEventInfo info)
        {
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart(IGameObject self)
        {
            boxCollider = self.Get<BoxCollider>();
            audioSource = self.Get<AudioSource>();
            gameObject = self;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate(IGameObject self)
        {
            float targetRotationDegrees = CalculateRotationInDegrees(direction.X, direction.Y);
            boxCollider.Body.Rotation = targetRotationDegrees;

            // Limit the maximum velocity
            float maxVelocity = 3.0f; // Set your desired maximum velocity
            Vector2F currentVelocity = boxCollider.Body.LinearVelocity;
            if (currentVelocity.Length() > maxVelocity)
            {
                currentVelocity = Vector2F.Normalize(currentVelocity) * maxVelocity;
                boxCollider.Body.LinearVelocity = currentVelocity;
            }

            timeCounter -= Context.TimeManager.DeltaTime;
            if (timeCounter <= 0)
            {
                counterEntities += 1;
                CreateBullet();
                timeCounter = resetTime;
                Console.WriteLine("Bullets created: " + counterEntities);
            }
        }

        /// <summary>
        ///     Calculates the rotation in degrees using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The angle</returns>
        private float CalculateRotationInDegrees(float x, float y)
        {
            float angle = 0.0f;

            if (x == 0)
            {
                if (y > 0)
                {
                    angle = 0.0f;
                }
                else if (y < 0)
                {
                    angle = 180.0f;
                }
            }
            else if (y == 0)
            {
                if (x > 0)
                {
                    angle = 270.0f;
                }
                else if (x < 0)
                {
                    angle = 90.0f;
                }
            }
            else
            {
                if ((x > 0) && (y > 0))
                {
                    angle = 315;
                    //Console.WriteLine("angle: " + angle);
                }

                if ((x < 0) && (y > 0))
                {
                    angle = 45;
                    //Console.WriteLine("angle: " + angle);
                }

                if ((x < 0) && (y < 0))
                {
                    angle = 135;
                    //Console.WriteLine("angle: " + angle);
                }

                if ((x > 0) && (y < 0))
                {
                    angle = 225;
                    //Console.WriteLine("angle: " + angle);
                }
            }

            return angle;
        }

        /// <summary>
        ///     Creates the bullet
        /// </summary>
        public void CreateBullet()
        {
            Transform transform = gameObject.Get<Transform>();
            Transform t = new Transform
            {
                Position = new Vector2F(transform.Position.X, transform.Position.Y),
                Scale = new Vector2F(1, 1)
            };

            Sprite s = new SpriteBuilder(Context)
                .SetTexture("asteroid_0.bmp")
                .Depth(1)
                .Build();


            int bulletSpeed = 5;
            Vector2F velo = new Vector2F(2 * bulletSpeed, 2 * bulletSpeed);

            BoxCollider box = new BoxColliderBuilder(Context)
                .IsActive(true)
                .BodyType(BodyType.Dynamic)
                .IsTrigger(false)
                .AutoTilling(false)
                .Size(0.25F, 0.25F)
                .Rotation(0.0f)
                .RelativePosition(0, 0)
                .LinearVelocity(velo.X, velo.Y)
                .Mass(1.0f)
                .Restitution(1f)
                .Friction(0f)
                .FixedRotation(true)
                .IgnoreGravity(true)
                .Build();


            GameObject bullet = Context.SceneManager.CurrentWorld.Create(t, s, box, new Bullet());


            box.Context = Context;
            s.Context = Context;

            box.OnStart(bullet);
            s.OnStart(bullet);
        }
    }
}