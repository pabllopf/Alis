// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGameObject.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.System.Common;
using Alis.Core.Ecs.System.Execution;

namespace Alis.Core.Ecs.Entity
{
    /// <summary>
    ///     The game object interface
    /// </summary>
    public interface IGameObject<T> : IEnabled, IIdentifier, IRuntime, ICrud<T>
    {
        /// <summary>
        ///     Gets or sets the value of the components
        /// </summary>
        public List<T> Components { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is static
        /// </summary>
        public bool IsStatic { get; set; }
    }
}