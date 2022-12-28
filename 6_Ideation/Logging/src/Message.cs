// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Message.cs
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
using System.Text.Json.Serialization;

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     The message class
    /// </summary>
    public class Message
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Message" /> class
        /// </summary>
        /// <param name="messageType">The message type</param>
        /// <param name="content">The content</param>
        [JsonConstructor]
        public Message(
            MessageType messageType,
            string content = "")
        {
            DateTime = DateTime.Now.ToUniversalTime();
            MessageType = messageType;
            Content = content;

            StackTrace stackTrace1 = new StackTrace(2, false);
            StackTrace stackTrace2 = new StackTrace(2, true);

            string methodName = stackTrace1.GetFrame(0).GetMethod().Name;
            Type reflectedType = stackTrace1.GetFrame(0).GetMethod().ReflectedType;
            if (reflectedType != null)
            {
                string className = reflectedType.FullName;
                Method = className + "." + methodName + "()";
            }

            Level = MessageType.ToString();

            StackTrace = stackTrace1.ToString().Trim();
            File = stackTrace2.GetFrame(0).GetFileName();
            Line = stackTrace2.GetFrame(0).GetFileLineNumber().ToString();
        }

        /// <summary>
        ///     Gets or sets the value of the date time
        /// </summary>
        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the message type
        /// </summary>
        [JsonPropertyName("MessageType")]
        public MessageType MessageType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the level
        /// </summary>
        [JsonPropertyName("Level")]
        public string Level { get; set; }

        /// <summary>
        ///     Gets or sets the value of the content
        /// </summary>
        [JsonPropertyName("Content")]
        public string Content { get; set; }

        /// <summary>
        ///     Gets or sets the value of the stack trace
        /// </summary>
        [JsonPropertyName("StackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        ///     Gets or sets the value of the method
        /// </summary>
        [JsonPropertyName("Method")]
        public string Method { get; set; }

        /// <summary>
        ///     Gets or sets the value of the file
        /// </summary>
        [JsonPropertyName("File")]
        public string File { get; set; }

        /// <summary>
        ///     Gets or sets the value of the line
        /// </summary>
        [JsonPropertyName("Line")]
        public string Line { get; set; }
    }
}