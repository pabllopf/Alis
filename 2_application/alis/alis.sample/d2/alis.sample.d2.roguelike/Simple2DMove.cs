// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Simple2DMove.cs
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

using System.Numerics;

namespace Alis.Sample.D2.Roguelike
{
    /// <summary>
    ///     The simple move class
    /// </summary>
    /// <seealso cref="Component" />
    public class Simple2DMove : Component
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider2D boxCollider2D;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            boxCollider2D = GameObject.Get<BoxCollider2D>();
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(string key)
        {
            Vector2 velocity = boxCollider2D.Body.LinearVelocity;

            switch (key)
            {
                case "D":
                    velocity.X = 5;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    return;
                case "A":
                    velocity.X = -5;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    return;
                case "W":
                    velocity.Y = -5;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    return;
                case "S":
                    velocity.Y = 5;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    break;
            }
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(string key)
        {
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(string key)
        {
            Vector2 velocity = boxCollider2D.Body.LinearVelocity;

            switch (key)
            {
                case "D":
                    velocity.X = 0;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    return;
                case "A":
                    velocity.X = 0;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    return;
                case "W":
                    velocity.Y = 0;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    return;
                case "S":
                    velocity.Y = 0;
                    boxCollider2D.Body.LinearVelocity = velocity;
                    break;
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}