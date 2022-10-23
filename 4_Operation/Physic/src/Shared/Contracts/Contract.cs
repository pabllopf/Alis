// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Contract.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Alis.Core.Physic.Shared.Contracts
{
    /// <summary>
    ///     The contract class
    /// </summary>
    public static class Contract
    {
        /// <summary>
        ///     Requires the not null using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="message">The message</param>
        /// <exception cref="RequiredException"></exception>
        [Conditional("DEBUG")]
        public static void RequireNotNull(object obj, string message)
        {
            if (obj != null)
            {
                return;
            }

            message = BuildMessage("REQUIRED", message);
            throw new RequiredException(message);
        }

        /// <summary>
        ///     Requireses the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message</param>
        /// <exception cref="RequiredException"></exception>
        [Conditional("DEBUG")]
        public static void Requires(bool condition, string message)
        {
            if (condition)
            {
                return;
            }

            message = BuildMessage("REQUIRED", message);
            throw new RequiredException(message);
        }

        /// <summary>
        ///     Warns the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Warn(bool condition, string message)
        {
            message = BuildMessage("WARNING", message);
            Debug.WriteLineIf(!condition, message);
        }

        /// <summary>
        ///     Ensureses the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message</param>
        /// <exception cref="EnsuresException"></exception>
        [Conditional("DEBUG")]
        public static void Ensures(bool condition, string message)
        {
            if (condition)
            {
                return;
            }

            message = BuildMessage("ENSURANCE", message);
            throw new EnsuresException(message);
        }

        /// <summary>
        ///     Requires the for all using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="check">The check</param>
        [Conditional("DEBUG")]
        public static void RequireForAll<T>(IEnumerable<T> value, Predicate<T> check)
        {
            foreach (T item in value)
            {
                Requires(check(item), "Failed on: " + item);
            }
        }

        /// <summary>
        ///     Fails the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="RequiredException"></exception>
        [Conditional("DEBUG")]
        public static void Fail(string message)
        {
            message = BuildMessage("FAILURE", message);
            throw new RequiredException(message);
        }

        /// <summary>
        ///     Builds the message using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="message">The message</param>
        /// <returns>The string</returns>
        private static string BuildMessage(string type, string message)
        {
            string stackTrace = string.Join(Environment.NewLine,
                Environment.StackTrace.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Skip(3));
            return message == null ? string.Empty : type + ": " + message + Environment.NewLine + stackTrace;
        }
    }
}