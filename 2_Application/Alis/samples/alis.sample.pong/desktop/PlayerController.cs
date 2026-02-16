// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerController.cs
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

namespace Alis.Sample.Pong.Desktop
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    public struct PlayerController(int playerId = 0) : IOnInit, IOnUpdate, IOnHoldKey, IOnReleaseKey, IOnPressKey
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     The player id
        /// </summary>
        public int PlayerId { get; set; } = playerId;

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
            boxCollider = self.Get<BoxCollider>();
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        ///     Ons the hold key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnHoldKey(KeyEventInfo info)
        {
        }

        /// <summary>
        ///     Ons the release key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnReleaseKey(KeyEventInfo info)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;
            ConsoleKey key = info.Key;
            switch (PlayerId)
            {
                case 1:
                    switch (key)
                    {
                        case ConsoleKey.W:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.S:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
                case 2:
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.DownArrow:
                            velocity = new Vector2F(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
            }
        }

        /// <summary>
        ///     Ons the press key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnPressKey(KeyEventInfo info)
        {
            Vector2F velocity = boxCollider.Body.LinearVelocity;

            ConsoleKey key = info.Key;
            switch (PlayerId)
            {
                case 1:
                    switch (key)
                    {
                        case ConsoleKey.W:
                            velocity = new Vector2F(velocity.X, 3);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.S:
                            velocity = new Vector2F(velocity.X, -3);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
                case 2:
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            velocity = new Vector2F(velocity.X, 3);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case ConsoleKey.DownArrow:
                            velocity = new Vector2F(velocity.X, -3);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
            }
        }
    }
}