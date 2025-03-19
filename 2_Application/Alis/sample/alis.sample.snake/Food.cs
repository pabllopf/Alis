// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Food.cs
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


using Alis.Core.EcsOld.Component;
using Alis.Core.EcsOld.Component.Collider;
using Alis.Core.EcsOld.Entity;

namespace Alis.Sample.Snake
{
    /// <summary>
    ///     The food class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class Food : AComponent
    {
        /// <summary>
        ///     The box collider
        /// </summary>
        private BoxCollider _boxCollider;

        /// <summary>
        ///     The player
        /// </summary>
        private GameObject _player;

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            _boxCollider = GameObject.Get<BoxCollider>();
        }

        /// <summary>
        ///     Consumes this instance
        /// </summary>
        public void Consume()
        {
            GameObject.IsEnable = false;
            _player.Get<PlayerController>().Grow();
        }

        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                _player ??= gameObject;
                Consume();
            }
        }
    }
}