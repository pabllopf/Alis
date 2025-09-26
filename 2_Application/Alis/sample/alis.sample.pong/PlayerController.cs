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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Sample.Pong
{
    /// <summary>
    ///     The player controller class
    /// </summary>
    public struct PlayerController(int playerId = 0) : IInitable, IGameObjectComponent, IOnHoldKey, IOnReleaseKey, IOnPressKey
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
        public void Init(IGameObject self)
        {
            boxCollider = self.Get<BoxCollider>();
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
        }

        public void OnHoldKey(KeyEventInfo info)
        {

        }

        public void OnReleaseKey(KeyEventInfo info)
        {
        }

        public void OnPressKey(KeyEventInfo info)
        {

        }
    }
}