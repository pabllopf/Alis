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

using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Component;
using Alis.Core.Component.Collider;
using Alis.Core.Component.Render;
using Alis.Core.Ecs;

namespace Alis.Sample.Rogue
{
    /// <summary>
    ///     Move control of player
    /// </summary>
    public class PlayerMovement : ComponentBase
    {
        /// <summary>
        ///     The animator
        /// </summary>
        private Animator animator;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The walking
        /// </summary>
        private bool walk;

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            animator = GameObject.GetComponent<Animator>();
            boxCollider = GameObject.GetComponent<BoxCollider>();
            walk = false;
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            if (!walk)
            {
                animator.ChangeAnimationTo("Idle");
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(Key key)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            switch (key)
            {
                case Key.D:
                    velocity = new Vector2F(0, velocity.Y);
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.A:
                    velocity = new Vector2F(0, velocity.Y);
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.W:
                    velocity = new Vector2F(velocity.X, 0);
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.S:
                    velocity = new Vector2F(velocity.X, 0);
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    break;
            }
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(Key key)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            //Console.WriteLine($"key={key}");
            switch (key)
            {
                case Key.D:
                    walk = true;
                    animator.ChangeAnimationTo("WalkRight");
                    velocity = new Vector2F(5, velocity.Y);
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.A:
                    walk = true;
                    animator.ChangeAnimationTo("WalkLeft");
                    velocity = new Vector2F(-5, velocity.Y);
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.W:
                    walk = true;
                    animator.ChangeAnimationTo("WalkUp");
                    velocity = new Vector2F(velocity.X, -5);
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case Key.S:
                    walk = true;
                    animator.ChangeAnimationTo("WalkDown");
                    velocity = new Vector2F(velocity.X, 5);
                    boxCollider.Body.LinearVelocity = velocity;
                    break;
            }
        }
    }
}