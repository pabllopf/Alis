// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Box2DXDebug.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace Alis.Core.Physic
{
    /// <summary>
    ///     The box dx debug class
    /// </summary>
    public static class Box2DxDebug
    {
        /// <summary>
        ///     Asserts the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        [Conditional("DEBUG")]
        public static void Assert(bool condition)
        {
            Debug.Assert(condition);
        }

        /// <summary>
        ///     Asserts the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            Debug.Assert(condition, message);
        }

        /// <summary>
        ///     Asserts the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message</param>
        /// <param name="detailMessage">The detail message</param>
        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message, string detailMessage)
        {
            Debug.Assert(condition, message);
        }

        /// <summary>
        ///     Throws the box 2 dx exception using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="Exception"></exception>
        public static void ThrowBox2DxException(string message)
        {
            string msg = string.Format("Error: {0}", message);
            throw new Exception(msg);
        }
    }
}