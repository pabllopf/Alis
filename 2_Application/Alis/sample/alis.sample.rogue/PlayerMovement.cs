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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Component;
using Alis.Core.Component.Collider;
using Alis.Core.Component.Render;
using Alis.Core.Input.SDL2;

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
        /// Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(SDL.SDL_Keycode key)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            switch (key)
            {
                case SDL.SDL_Keycode.SDLK_d:
                    velocity.X = 0;
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case SDL.SDL_Keycode.SDLK_a:
                    velocity.X = 0;
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case SDL.SDL_Keycode.SDLK_w:
                    velocity.Y = 0;
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case SDL.SDL_Keycode.SDLK_s:
                    velocity.Y = 0;
                    walk = false;
                    boxCollider.Body.LinearVelocity = velocity;
                    break;
            }
        }

        /// <summary>
        /// Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(SDL.SDL_Keycode key)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            switch (key)
            {
                case SDL.SDL_Keycode.SDLK_d:
                    walk = true;
                    animator.ChangeAnimationTo("WalkRight");
                    velocity.X = 5;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case SDL.SDL_Keycode.SDLK_a:
                    walk = true;
                    animator.ChangeAnimationTo("WalkLeft");
                    velocity.X = -5;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case SDL.SDL_Keycode.SDLK_w:
                    walk = true;
                    animator.ChangeAnimationTo("WalkUp");
                    velocity.Y = -5;
                    boxCollider.Body.LinearVelocity = velocity;
                    return;
                case SDL.SDL_Keycode.SDLK_s:
                    walk = true;
                    animator.ChangeAnimationTo("WalkDown");
                    velocity.Y = 5;
                    boxCollider.Body.LinearVelocity = velocity;
                    break;
            }
        }
    }
}