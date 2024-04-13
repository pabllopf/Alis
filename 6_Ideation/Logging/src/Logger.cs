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
        ///     The normal
        /// </summary>
        public static LogLevel LogLevel { get; set; } = LogLevel.Trace;
        
        /// <summary>
        ///     Gets or sets the value of the detail level
        /// </summary>
        public static DetailLevel DetailLevel { get; set; } = DetailLevel.Minimal;
        
        /// <summary>
        ///     Traces the message
        /// </summary>
        [Conditional("DEBUG")]
        public static void Trace()
        {
            if (LogLevel.Trace >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Trace), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Trace(string message)
        {
            if (LogLevel.Trace >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Trace, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Info
        /// </summary>
        [Conditional("DEBUG")]
        public static void Info()
        {
            if (LogLevel.Info >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Info, "Info method called with no message."), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Info the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Info(string message)
        {
            if (LogLevel.Info >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Info, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Log(string message)
        {
            if (LogLevel.Log >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Log, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Events the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Event(string message)
        {
            if (LogLevel.Event >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Event, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Events
        /// </summary>
        [Conditional("DEBUG")]
        public static void Event()
        {
            if (LogLevel.Event >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Event, "Event method called with no message."), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Warning(string message)
        {
            if (LogLevel.Warning >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Warning, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Errors the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Error(string message)
        {
            if (LogLevel.Critical >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Error, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        [Conditional("DEBUG")]
        public static void Exception(string message)
        {
            if (LogLevel.Critical >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Exception, message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Exceptions the exception
        /// </summary>
        /// <param name="exception">The exception</param>
        [Conditional("DEBUG")]
        public static void Exception(Exception exception)
        {
            if (LogLevel.Critical >= LogLevel)
            {
                ConsoleController.Print(new Message(MessageType.Exception, exception.Message), DetailLevel);
            }
        }
        
        /// <summary>
        ///     Sets the detail level using the specified detail level
        /// </summary>
        /// <param name="detailLevel">The detail level</param>
        [Conditional("DEBUG")]
        public static void SetDetailLevel(DetailLevel detailLevel) => DetailLevel = detailLevel;
        
        /// <summary>
        ///     Sets the log level using the specified trace
        /// </summary>
        /// <param name="trace">The trace</param>
        [Conditional("DEBUG")]
        public static void SetLogLevel(LogLevel trace) => LogLevel = trace;
    }
}