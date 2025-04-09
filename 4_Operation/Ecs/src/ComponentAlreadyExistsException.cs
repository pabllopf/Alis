// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentAlreadyExistsException.cs
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

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The component already exists exception class
    /// </summary>
    /// <seealso cref="Exception" />
    internal class ComponentAlreadyExistsException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentAlreadyExistsException" /> class
        /// </summary>
        /// <param name="t">The </param>
        public ComponentAlreadyExistsException(Type t)
            : base($"Component of type {t.FullName} already exists on entity!")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentAlreadyExistsException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public ComponentAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}