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
        public static void Trace() => ConsoleController.Print(new Message(MessageType.Trace));

        /// <summary>
        ///     Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Trace(string message) => ConsoleController.Print(new Message(MessageType.Trace, message));

        /// <summary>
        ///     Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Info(string message) => ConsoleController.Print(new Message(MessageType.Info, message));

        /// <summary>
        ///     Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Log(string message) => ConsoleController.Print(new Message(MessageType.Log, message));

        /// <summary>
        ///     Events the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Event(string message) => ConsoleController.Print(new Message(MessageType.Event, message));

        /// <summary>
        ///     Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Warning(string message) => ConsoleController.Print(new Message(MessageType.Warning, message));

        /// <summary>
        ///     Errors the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Error(string message) => ConsoleController.Print(new Message(MessageType.Error, message));

        /// <summary>
        ///     Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Exception(string message) => ConsoleController.Print(new Message(MessageType.Exception, message));

        /// <summary>
        ///     Exceptions the exception
        /// </summary>
        /// <param name="exception">The exception</param>
        public static void Exception(Exception exception) => ConsoleController.Print(new Message(MessageType.Exception, exception.Message));
    }
}