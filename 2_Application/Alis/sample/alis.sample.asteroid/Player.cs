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

using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Asteroid
{
    /// <summary>
    ///     The player movement class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class Player : AComponent
    {
        /// <summary>
        ///     The acceleration
        /// </summary>
        public float acceleration = 2.0f;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F direction = new Vector2F(0, 0);

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            boxCollider = GameObject.Get<BoxCollider>();
        }


        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
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
                if (x > 0 && y > 0)
                {
                    angle = 315;
                    //Console.WriteLine("angle: " + angle);
                }

                if (x < 0 && y > 0)
                {
                    angle = 45;
                    //Console.WriteLine("angle: " + angle);
                }

                if (x < 0 && y < 0)
                {
                    angle = 135;
                    //Console.WriteLine("angle: " + angle);
                }

                if (x > 0 && y < 0)
                {
                    angle = 225;
                    //Console.WriteLine("angle: " + angle);
                }
            }

            return angle;
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(Keys key)
        {
            if (key == Keys.D)
            {
                direction.X = 1;
            }

            if (key == Keys.A)
            {
                direction.X = -1;
            }

            if (key == Keys.W)
            {
                direction.Y = 1;
            }

            if (key == Keys.S)
            {
                direction.Y = -1;
            }

            if (key == Keys.A || key == Keys.D || key == Keys.W || key == Keys.S)
            {
                boxCollider.Body.ApplyForce(direction * acceleration);
            }
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(Keys key)
        {
            if (key == Keys.Space && (direction.X != 0 || direction.Y != 0))
            {
                GameObject.Get<AudioSource>().Play();
                Context.SceneManager.CurrentScene.GetByTag("Points").Get<CounterManager>().Decrement();


                GameObject bullet = new GameObject();
                bullet.Name = $"Bullet_{Context.TimeManager.FrameCount}";

                Transform transform = bullet.Transform;
                transform.Position = GameObject.Transform.Position; // Set the bullet's initial position to the player's position
                transform.Scale = new Vector2F(0.25f, 0.25f);
                bullet.Transform = transform;

                bullet.Add(new Sprite().Builder()
                    .SetTexture("asteroid_0.jpeg")
                    .Depth(1)
                    .Build());

                int bulletSpeed = 5;
                Vector2F velo = new Vector2F(direction.X * bulletSpeed, direction.Y * bulletSpeed);

                bullet.Add(new BoxCollider()
                    .Builder()
                    .IsActive(true)
                    .BodyType(BodyType.Dynamic)
                    .IsTrigger(true)
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
                    .Build());

                bullet.Add(new Bullet());

                Context.SceneManager.CurrentScene.Add(bullet);
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(Keys key)
        {
        }
    }
}