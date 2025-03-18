// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Exceptions.cs
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

namespace Frent
{
    /// <summary>
    ///     The frent exceptions class
    /// </summary>
    internal class FrentExceptions
    {
        /// <summary>
        ///     Throws the invalid operation exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Throw_InvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }


        /// <summary>
        ///     Throws the component not found exception using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <exception cref="ComponentNotFoundException"></exception>
        public static void Throw_ComponentNotFoundException(Type t)
        {
            throw new ComponentNotFoundException(t);
        }


        /// <summary>
        ///     Throws the component not found exception
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <exception cref="ComponentNotFoundException"></exception>
        public static void Throw_ComponentNotFoundException<T>()
        {
            throw new ComponentNotFoundException(typeof(T));
        }


        /// <summary>
        ///     Throws the component not found exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ComponentNotFoundException"></exception>
        public static void Throw_ComponentNotFoundException(string message)
        {
            throw new ComponentNotFoundException(message);
        }


        /// <summary>
        ///     Throws the component already exists exception using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <exception cref="ComponentAlreadyExistsException"></exception>
        public static void Throw_ComponentAlreadyExistsException(Type t)
        {
            throw new ComponentAlreadyExistsException(t);
        }


        /// <summary>
        ///     Throws the component already exists exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ComponentAlreadyExistsException"></exception>
        public static void Throw_ComponentAlreadyExistsException(string message)
        {
            throw new ComponentAlreadyExistsException(message);
        }


        /// <summary>
        ///     Throws the argument out of range exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Throw_ArgumentOutOfRangeException(string message)
        {
            throw new ArgumentOutOfRangeException(message);
        }
    }

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

    /// <summary>
    ///     The component not found exception class
    /// </summary>
    /// <seealso cref="Exception" />
    internal class ComponentNotFoundException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentNotFoundException" /> class
        /// </summary>
        /// <param name="t">The </param>
        public ComponentNotFoundException(Type t)
            : base($"Component of type {t.FullName} not found")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentNotFoundException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public ComponentNotFoundException(string message)
            : base(message)
        {
        }
    }
}