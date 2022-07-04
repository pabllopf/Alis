// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Log.cs
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
using Newtonsoft.Json;

namespace Alis.Aspect.Debug
{
    /// <summary>
    ///     The log class
    /// </summary>
    public class Log
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Log" /> class
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="dateTime">The date time</param>
        /// <param name="message">The message</param>
        /// <param name="method">The method</param>
        /// <param name="assembly">The assembly</param>
        /// <param name="thread">The thread</param>
        /// <param name="stackTrace">The stack trace</param>
        [JsonConstructor]
        public Log(string level, DateTime dateTime, string message, string method, string assembly, int thread, string stackTrace)
        {
            Level = level;
            DateTime = dateTime;
            Message = message;
            Method = method;
            Assembly = assembly;
            Thread = thread;
            StackTrace = stackTrace;
        }

        /// <summary>
        ///     Gets or sets the value of the level
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the date time
        /// </summary>
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the value of the method
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        ///     Gets or sets the value of the assembly
        /// </summary>
        [JsonProperty("assembly")]
        public string Assembly { get; set; }

        /// <summary>
        ///     Gets or sets the value of the thread
        /// </summary>
        [JsonProperty("thread")]
        public int Thread { get; set; }

        /// <summary>
        ///     Gets or sets the value of the stack trace
        /// </summary>
        [JsonProperty("stacktrace")]
        public string StackTrace { get; set; }
    }
}