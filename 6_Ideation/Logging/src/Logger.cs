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

using System;
using System.Diagnostics;

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     The logger class
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Info text color
        /// </summary>
        private const ConsoleColor InfoMessageColor = ConsoleColor.DarkGreen;
        
        /// <summary>
        /// Log text color
        /// </summary>
        private const ConsoleColor LogMessageColor = ConsoleColor.Black;
        
        /// <summary>
        /// Trace text color
        /// </summary>
        private const ConsoleColor TraceMessageColor = ConsoleColor.White;

        /// <summary>
        /// Warning text color
        /// </summary>
        private const ConsoleColor WarningMessageColor = ConsoleColor.DarkYellow;

        /// <summary>
        /// Error text color
        /// </summary>
        private const ConsoleColor ErrorMessageColor = ConsoleColor.Red;

        /// <summary>
        /// Exception text color
        /// </summary>
        private const ConsoleColor ExceptionMessageColor = ConsoleColor.DarkRed;

        /// <summary>
        /// Event text color
        /// </summary>
        private const ConsoleColor EventMessageColor = ConsoleColor.DarkMagenta;
        
        /// <summary>
        ///     Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Log(string message)
        {
            Console.ForegroundColor = LogMessageColor;
            Console.WriteLine($"[{DateTime.Now}] LOG: '{message}' \n" +
                              $"{new StackTrace()}");
            Console.ResetColor();
        }

        /// <summary>
        ///     Traces the message
        /// </summary>
        public static void Trace()
        {
            Console.ForegroundColor = TraceMessageColor;
            Console.WriteLine($"[{DateTime.Now}] TRACE: \n" +
                              $"{new StackTrace()}");
            Console.ResetColor();
        }

        /// <summary>
        /// Info messages
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Console.ForegroundColor = InfoMessageColor;
            Console.WriteLine($"[{DateTime.Now}] INFO: '{message}'");
            Console.ResetColor();
        }

        /// <summary>
        /// Warning message
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(string message)
        {
            Console.ForegroundColor = WarningMessageColor;
            Console.WriteLine($"[{DateTime.Now}] WARNING: '{message}' \n" +
                              $"{new StackTrace()}");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Error message
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ErrorMessageColor;
            Console.WriteLine($"[{DateTime.Now}] ERROR: '{message}' \n" +
                              $"{new StackTrace()}");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Exception message 
        /// </summary>
        /// <param name="exception"></param>
        public static void Exception(Exception exception)
        {
            Console.ForegroundColor = ExceptionMessageColor;
            Console.WriteLine($"[{DateTime.Now}] EXCEPTION: '{exception.Message}' \n" +
                              $"{exception.StackTrace} \n");
            Console.ResetColor();
        }

        /// <summary>
        /// Event message
        /// </summary>
        /// <param name="message"></param>
        public static void Event(string message)
        {
            Console.ForegroundColor = EventMessageColor;
            Console.WriteLine($"[{DateTime.Now}] EVENT: '{message}'");
            Console.ResetColor();
        }
    }
}