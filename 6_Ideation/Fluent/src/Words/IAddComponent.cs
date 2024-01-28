// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAddComponent.cs
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

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     The add component class
    /// </summary>
    public interface IAddComponent<out TBuilder, in TType>
    {
        /// <summary>
        ///     Adds the component using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        TBuilder AddComponent<T>(Func<T, TType> value) where T : TType;

        /// <summary>
        ///     Adds the component using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The builder</returns>
        TBuilder AddComponent<T>(T value) where T : TType;
    }
}