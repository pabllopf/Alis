// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BallController.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using Alis.Core.Components;
using Alis.Core.Input;
using SFML.System;

namespace GeometryDash
{
    /// <summary>Ball Controller</summary>
    internal class BallController : Component
    {
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider2D boxCollider2D;

        private float timeStop;

        private bool jumping = false;

        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            boxCollider2D = GameObject.Get<BoxCollider2D>();

            //boxCollider2D.Body.LinearVelocity = new Vector2(boxCollider2D.Body.LinearVelocity.X + 5, boxCollider2D.Body.LinearVelocity.Y);

            InputManager.OnReleaseKey += OnReleaseKey;
            InputManager.OnPressKey += OnPressKey;
        }

        /// <summary>
        /// Ons the press key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void OnPressKey(object? sender, string key)
        {
            //Console.WriteLine(key);
            if (key.Equals("Space") && jumping == false)
            {
                boxCollider2D.Body.SetLinearVelocity(new Vector2(
                    0, 
                    -1000.0F));
                jumping = true;
            }
        }

        /// <summary>
        /// Ons the release key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void OnReleaseKey(object? sender, string key)
        {
            
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
            timeStop -= 0.1f;
            if (timeStop <= 0)
            {
                timeStop = 25f;
                jumping = false;
            }
        }
    }
}