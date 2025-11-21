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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Sample.King.Platform
{
    /// <summary>
    ///     The player movement
    /// </summary>
    public struct PlayerMovement : IOnInit, IOnUpdate, IOnPressKey, IOnHoldKey, IOnReleaseKey
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
        ///     The sprite
        /// </summary>
        private Sprite sprite;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerMovement" /> class
        /// </summary>
        public PlayerMovement()
        {
            animator = default;
            boxCollider = null;
            sprite = default;
        }

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <exception cref="ArgumentNullException">GameObject cannot be null</exception>
        /// <exception cref="InvalidOperationException">GameObject must have a BoxCollider component</exception>
        /// <exception cref="InvalidOperationException">GameObject must have a Sprite component</exception>
        /// <exception cref="InvalidOperationException">GameObject must have an Animator component</exception>
        public void OnInit(IGameObject self)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self), "GameObject cannot be null");
            }

            if (!self.Has<Animator>())
            {
                throw new InvalidOperationException("GameObject must have an Animator component");
            }

            if (!self.Has<BoxCollider>())
            {
                throw new InvalidOperationException("GameObject must have a BoxCollider component");
            }

            if (!self.Has<Sprite>())
            {
                throw new InvalidOperationException("GameObject must have a Sprite component");
            }

            animator = self.Get<Animator>();
            boxCollider = self.Get<BoxCollider>();
            sprite = self.Get<Sprite>();
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        ///     Ons the press key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnPressKey(KeyEventInfo info)
        {
            if (info.Key == ConsoleKey.A)
            {
                directionPlayer.X = -1;
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(-0.5f, 0));
            }

            if (info.Key == ConsoleKey.D)
            {
                directionPlayer.X = 1;
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(0.5f, 0));
            }

            if (info.Key == ConsoleKey.Spacebar)
            {
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(0, JumpForce));
            }

            //Logger.Info($"OnPressKey {info.Key}, {info.HoldDuration}, {info.Timestamp}");
        }

        /// <summary>
        ///     Ons the hold key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnHoldKey(KeyEventInfo info)
        {
            //Logger.Info($"OnHoldKey {info.Key}, {info.HoldDuration}, {info.Timestamp}");
        }

        /// <summary>
        ///     Ons the release key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnReleaseKey(KeyEventInfo info)
        {
            //Logger.Info($"OnReleaseKey {info.Key}, {info.HoldDuration}, {info.Timestamp}");
        }
    }
}