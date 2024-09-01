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
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Graphic.Sdl2.Enums;

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
        private const float JumpForce = 30;
        
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
        private Vector2 directionPlayer = new Vector2(0, 0);
        
        /// <summary>
        ///     The sprite
        /// </summary>
        private Sprite sprite;

        private bool moveLeft;
        private bool moveRight;

        /// <summary>
        /// The jump force
        /// </summary>
        const float JUMP_FORCE = 20.0f;
        /// <summary>
        /// The jump duration
        /// </summary>
        const float JUMP_DURATION = 0.35f;

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
            if (moveRight)
            {
                boxCollider.Body.ApplyTorque(10);
            }
            
            if (moveLeft)
            {
                boxCollider.Body.ApplyTorque(-10);
            }
        }
        
        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(KeyCodes key)
        {
            if (key == KeyCodes.D)
            {
                moveRight = true;
            }
            
            if (key == KeyCodes.A)
            {
                moveLeft = true;
            }
        }
    }
}