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

using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;

namespace Alis.Sample.Pong
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    public class PlayerController : AComponent
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
        public override void OnStart() => boxCollider = GameObject.Get<BoxCollider>();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void OnUpdate() => Logger.Trace();

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(KeyCodes key)
        {
            Vector2 velocity = boxCollider.Body.LinearVelocity;
            switch (playerId)
            {
                case 1:
                    switch (key)
                    {
                        case KeyCodes.W:
                            velocity = new Vector2(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case KeyCodes.S:
                            velocity = new Vector2(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
                case 2:
                    switch (key)
                    {
                        case KeyCodes.Up:
                            velocity = new Vector2(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case KeyCodes.Down:
                            velocity = new Vector2(velocity.X, 0);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
            }
        }


        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(KeyCodes key)
        {
            Vector2 velocity = boxCollider.Body.LinearVelocity;

            switch (playerId)
            {
                case 1:
                    switch (key)
                    {
                        case KeyCodes.W:
                            velocity = new Vector2(velocity.X, 3);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case KeyCodes.S:
                            velocity = new Vector2(velocity.X, -3);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
                case 2:
                    switch (key)
                    {
                        case KeyCodes.Up:
                            velocity = new Vector2(velocity.X, 3);
                            boxCollider.Body.LinearVelocity = velocity;
                            return;
                        case KeyCodes.Down:
                            velocity = new Vector2(velocity.X, -3);
                            boxCollider.Body.LinearVelocity = velocity;
                            break;
                    }

                    break;
            }
        }
    }
}