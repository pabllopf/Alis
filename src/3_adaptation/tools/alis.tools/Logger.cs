// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Logger.cs
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

namespace Alis.Tools
{
    /// <summary>
    ///     The logger class
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The level
        /// </summary>
        private static readonly LogLevel Level;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class
        /// </summary>
        static Logger()
        {
            Level = LogLevel.Info;
        }
        
        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Log(string message)
        {
            System.Console.WriteLine(message);
        }
        
        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Log(string message, params object[] args)
        {
            System.Console.WriteLine(message, args);
        }
        
        /// <summary>
        /// Errors the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Error(string message)
        {
            
        }
        
        /// <summary>
        /// Errors the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Error(string message, params object[] args)
        {
            System.Console.Error.WriteLine(message, args);
        }
        
        /// <summary>
        /// Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Warning(string message)
        {
            System.Console.Error.WriteLine(message);
        }
        
        /// <summary>
        /// Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Warning(string message, params object[] args)
        {
            System.Console.Error.WriteLine(message, args);
        }
        
        /// <summary>
        /// Successes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Success(string message)
        {
            System.Console.WriteLine(message);
        }
        
        /// <summary>
        /// Successes the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Success(string message, params object[] args)
        {
            System.Console.WriteLine(message, args);
        }
        
        /// <summary>
        /// Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Info(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Debug)
            {
                System.Console.WriteLine(message);
            }
        }
        
        /// <summary>
        /// Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Info(string message, params object[] args)
        {
            System.Console.WriteLine(message, args);
        }
        
        /// <summary>
        /// Debugs the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Debug(string message)
        {
            System.Console.WriteLine(message);
        }
        
        /// <summary>
        /// Debugs the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Debug(string message, params object[] args)
        {
            System.Console.WriteLine(message, args);
        }
        
        /// <summary>
        /// Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Trace(string message)
        {
            System.Console.WriteLine(message);
        }
        
        /// <summary>
        /// Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Trace(string message, params object[] args)
        {
            System.Console.WriteLine(message, args);
        }
        
        /// <summary>
        /// Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Exception(string message)
        {
            System.Console.Error.WriteLine(message);
        }
        
        /// <summary>
        /// Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Exception(string message, params object[] args)
        {
            System.Console.Error.WriteLine(message, args);
        }
        
        /// <summary>
        /// Exceptions the exception
        /// </summary>
        /// <param name="exception">The exception</param>
        public static void Exception(System.Exception exception)
        {
            System.Console.Error.WriteLine(exception.Message);
        }
        
        /// <summary>
        /// Exceptions the exception
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="args">The args</param>
        public static void Exception(System.Exception exception, params object[] args)
        {
            System.Console.Error.WriteLine(exception.Message, args);
        }
        
    }
}