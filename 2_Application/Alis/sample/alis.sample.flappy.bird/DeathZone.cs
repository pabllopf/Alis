// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DeathZone.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity.GameObject;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The death zone class
    /// </summary>
    /// <seealso cref="Component" />
    public class DeathZone : Component
    {
        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(IGameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                Console.WriteLine($"Player dead by '{this.GameObject.Name}'");
            }
        }
    }
}