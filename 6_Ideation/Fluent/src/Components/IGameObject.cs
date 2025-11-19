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

using System;

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     The game object interface
    /// </summary>
    public interface IGameObject
    {
        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The ref</returns>
        ref T Get<T>();

        /// <summary>
        ///     Hases this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        bool Has<T>();

        /// <summary>
        ///     Hases the type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        bool Has(Type type);

        /// <summary>
        ///     Tries the has
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        bool TryHas<T>();
    }
}