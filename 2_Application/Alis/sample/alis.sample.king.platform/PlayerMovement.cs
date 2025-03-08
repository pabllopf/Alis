// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerMovement.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.King.Platform
{
    /// <summary>
    ///     The player movement class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class PlayerMovement : AComponent
    {
        /// <summary>
        ///     The jump force
        /// </summary>
        private const float JumpForce = 10;

        /// <summary>
        ///     The velocity player
        /// </summary>
        private const float VelocityPlayer = 5f;

        /// <summary>
        ///     The reset cool down jump
        /// </summary>
        private const float ResetCoolDownJump = 0.8f;

        /// <summary>
        ///     The animator
        /// </summary>
        private Animator animator;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F directionPlayer = new Vector2F(0, 0);

        /// <summary>
        ///     The is jumping
        /// </summary>
        private bool isJumping;

        /// <summary>
        ///     The sprite
        /// </summary>
        private Sprite sprite;

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            animator = GameObject.Get<Animator>();
            boxCollider = GameObject.Get<BoxCollider>();
            sprite = GameObject.Get<Sprite>();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            // Apply movement
            boxCollider.Body.LinearVelocity = new Vector2F(directionPlayer.X * VelocityPlayer, boxCollider.Body.LinearVelocity.Y);

            // Update animation based on movement
            if (directionPlayer.X != 0 && !isJumping)
            {
                animator.ChangeAnimationTo("Run");
                if (directionPlayer.X < 0)
                {
                    sprite.Flip = true;
                }
                else
                {
                    sprite.Flip = false;
                }
            }
            else if (!isJumping)
            {
                animator.ChangeAnimationTo("Idle");
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(Keys key)
        {
            if ((key == Keys.A && directionPlayer.X == -1) || (key == Keys.D && directionPlayer.X == 1))
            {
                directionPlayer.X = 0;
            }
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(Keys key)
        {
            if (key == Keys.Space && !isJumping)
            {
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(0, JumpForce));
                isJumping = true;
                animator.ChangeAnimationTo("Jump");
            }

            if (key == Keys.A)
            {
                directionPlayer.X = -1;
            }

            if (key == Keys.D)
            {
                directionPlayer.X = 1;
            }
        }

        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Floor")
            {
                isJumping = false;
            }
        }
    }
}