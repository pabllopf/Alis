// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IComponentRunnerFactory.cs
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

using Frent.Collections;
using Frent.Updating.Runners;

namespace Frent.Updating
{
    /// <summary>
    ///     Defines an object for creating component runners
    /// </summary>
    /// <remarks>Used only in source generation</remarks>
    internal interface IComponentStorageBaseFactory
    {
        /// <summary>
        ///     Used only in source generation
        /// </summary>
        internal ComponentStorageBase Create(int capacity);

        /// <summary>
        ///     Used only in source generation
        /// </summary>
        internal IDTable CreateStack();
    }

    /// <summary>
    ///     The component storage base factory interface
    /// </summary>
    internal interface IComponentStorageBaseFactory<T>
    {
        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t</returns>
        internal ComponentStorage<T> CreateStronglyTyped(int capacity);
    }
}