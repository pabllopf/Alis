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

using System;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Graphic;
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Sample.King.Platform
{
    /// <summary>
    /// The player movement class
    /// </summary>
    /// <seealso cref="Component"/>
    public class PlayerMovement : Component
    {
        /// <summary>
        /// The animator
        /// </summary>
        private Animator animator;
        
        private BoxCollider boxCollider;
        
        private Sprite sprite;
        
        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            animator = GameObject.Get<Animator>();
            boxCollider = GameObject.Get<BoxCollider>();
            sprite = GameObject.Get<Sprite>();
        }

        /// <summary>
        /// Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(SdlKeycode key)
        {
            switch (key)
            {
                case SdlKeycode.SdlkD:
                    switch (sprite.Flip)
                    {
                        case FlipTo.Right:
                            animator.ChangeAnimationTo("Idle", FlipTo.Right);
                            break;
                        case FlipTo.Left:
                            animator.ChangeAnimationTo("Idle", FlipTo.Left);
                            break;
                    }
                    boxCollider.Body.LinearVelocity = new Vector2(0, 0);
                    break;
                case SdlKeycode.SdlkA:
                    switch (sprite.Flip)
                    {
                        case FlipTo.Right:
                            animator.ChangeAnimationTo("Idle", FlipTo.Right);
                            break;
                        case FlipTo.Left:
                            animator.ChangeAnimationTo("Idle", FlipTo.Left);
                            break;
                    }
                    boxCollider.Body.LinearVelocity = new Vector2(0, 0);
                    break;
                case SdlKeycode.SdlkSpace:
                    switch (sprite.Flip)
                    {
                        case FlipTo.Right:
                            animator.ChangeAnimationTo("Idle", FlipTo.Right);
                            break;
                        case FlipTo.Left:
                            animator.ChangeAnimationTo("Idle", FlipTo.Left);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(SdlKeycode key)
        {
            Vector2 velocity = boxCollider.Body.LinearVelocity;
            switch (key)
            {
                case SdlKeycode.SdlkD:
                    animator.ChangeAnimationTo("Run", FlipTo.Right);
                    boxCollider.Body.LinearVelocity = new Vector2(5, velocity.Y);
                    break;
                case SdlKeycode.SdlkA:
                    animator.ChangeAnimationTo("Run" , FlipTo.Left);
                    boxCollider.Body.LinearVelocity = new Vector2(-5, velocity.Y);
                    break;
            }
        }

        public override void OnPressKey(SdlKeycode key)
        {
            Vector2 velocity = boxCollider.Body.LinearVelocity;
            switch (key)
            {
                case SdlKeycode.SdlkSpace:
                    boxCollider.Body.LinearVelocity = new Vector2(velocity.X, -15f);
                    
                    switch (sprite.Flip)
                    {
                        case FlipTo.Right:
                            animator.ChangeAnimationTo("Jump", FlipTo.Right);
                            break;
                        case FlipTo.Left:
                            animator.ChangeAnimationTo("Jump", FlipTo.Left);
                            break;
                    }

                    break;
            }
        }
    }
}