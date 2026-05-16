// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Info.cs
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

namespace Alis.Core.Ecs.Components
{
    /// <summary>
    ///     Info component
    /// </summary>
    public record struct Info : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///     The is static
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        ///     The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }
    }
}