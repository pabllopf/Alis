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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Component.Collider;
using Alis.Core.Ecs;
using Alis.Core.Graphic.SDL.Enums;

namespace Alis.Sample.Pong
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    public class PlayerController : ComponentBase
    {
        /// <summary>
        ///     The player id
        /// </summary>
        private readonly int playerId;

        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerController" /> class
        /// </summary>
        /// <param name="playerId">The player id</param>
        public PlayerController(int playerId) => this.playerId = playerId;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => boxCollider = GameObject.GetComponent<BoxCollider>();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() => Logger.Trace();

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(SdlKeycode key)
        {
            Vector2 velocity = boxCollider.Body.LinearVelocity;
            if (playerId == 1)
            {
                switch (key)
                {
                    case SdlKeycode.SdlkW:
                        velocity = new Vector2(velocity.X, 0);
                        boxCollider.Body.LinearVelocity = velocity;
                        return;
                    case SdlKeycode.SdlkS:
                        velocity = new Vector2(velocity.X, 0);
                        boxCollider.Body.LinearVelocity = velocity;
                        break;
                }
            }

            if (playerId == 2)
            {
                switch (key)
                {
                    case SdlKeycode.SdlkUp:
                        velocity = new Vector2(velocity.X, 0);
                        boxCollider.Body.LinearVelocity = velocity;
                        return;
                    case SdlKeycode.SdlkDown:
                        velocity = new Vector2(velocity.X, 0);
                        boxCollider.Body.LinearVelocity = velocity;
                        break;
                }
            }
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(SdlKeycode key)
        {
            Vector2 velocity = boxCollider.Body.LinearVelocity;

            if (playerId == 1)
            {
                switch (key)
                {
                    case SdlKeycode.SdlkW:
                        velocity = new Vector2(velocity.X, -5);
                        boxCollider.Body.LinearVelocity = velocity;
                        //Console.WriteLine($" {boxCollider.Body.LinearVelocity} ");
                        return;
                    case SdlKeycode.SdlkS:
                        velocity = new Vector2(velocity.X, 5);
                        boxCollider.Body.LinearVelocity = velocity;
                        //Console.WriteLine($" {boxCollider.Body.LinearVelocity} ");
                        break;
                }
            }

            if (playerId == 2)
            {
                switch (key)
                {
                    case SdlKeycode.SdlkUp:
                        velocity = new Vector2(velocity.X, -5);
                        boxCollider.Body.LinearVelocity = velocity;
                        return;
                    case SdlKeycode.SdlkDown:
                        velocity = new Vector2(velocity.X, 5);
                        boxCollider.Body.LinearVelocity = velocity;
                        break;
                }
            }
        }
    }
}