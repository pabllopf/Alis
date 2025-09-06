// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Logger.cs
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


using System.Diagnostics;
#if DEBUG
using System;
#endif

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     The logger class
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Trace(string message)
        {
#if DEBUG
            Console.WriteLine($"[TRACE] {message}");
#endif
        }

        /// <summary>
        ///     Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Info(string message)
        {
#if DEBUG
            Console.WriteLine($"[INFO] {message}");
#endif
        }

        /// <summary>
        ///     Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Log(string message)
        {
#if DEBUG
            Console.WriteLine($"[LOG] {message}");
#endif
        }

        /// <summary>
        ///     Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Warning(string message)
        {
#if DEBUG
            Console.WriteLine($"[WARNING] {message}");
#endif
        }

        /// <summary>
        ///     Errors the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Error(string message)
        {
#if DEBUG
            Console.WriteLine($"[ERROR] {message}");
#endif
        }

        /// <summary>
        ///     Debugs the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Debug(string message)
        {
#if DEBUG
            Console.WriteLine($"[DEBUG] {message}");
#endif
        }

        /// <summary>
        ///     Exceptions the to string
        /// </summary>
        /// <param name="toString">The to string</param>
        [Conditional("DEBUG")]
        public static void Exception(string toString)
        {
#if DEBUG
            Console.WriteLine($"[EXCEPTION] {toString}");
            throw new Exception(toString);
#endif
        }
    }
}