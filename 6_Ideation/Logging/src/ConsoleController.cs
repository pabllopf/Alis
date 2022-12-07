// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleController.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    /// The console controller class
    /// </summary>
    public static class ConsoleController
    {
        /// <summary>
        /// The message
        /// </summary>
        private static List<Message> messages = new List<Message>();

        /// <summary>
        /// The file path
        /// </summary>
        private static string filePath;

        /// <summary>
        /// The dir path
        /// </summary>
        private static string dirPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleController"/> class
        /// </summary>
        static ConsoleController()
        {
            dirPath = Environment.CurrentDirectory + "/log";
            filePath = Environment.CurrentDirectory + $"/log/{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}_{DateTime.Now.Hour}-{DateTime.Now.Minute}.log";
        }
        
        /// <summary>
        /// Prints the to console using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Print(Message message)
        {
            Console.ForegroundColor = ConsoleLogConfig.GetColorMessageByType(message.MessageType);
            Console.WriteLine($"[{message.DateTime}] {message.Level}: {message.Content} \n" +
                              $"   method: '{message.Method}' \n" +
                              $"   line:   '{message.Line}' \n" +
                              $"   file:   '{message.File}' \n" +
                              $"   {message.StackTrace} \n");
            SaveToFile(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Saves the to file using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        private static void SaveToFile(Message message)
        {
            
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Default,
                WriteIndented = true
            };
            
            options.Converters.Add(new DateTimeConverter());

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            
            if (File.Exists(filePath))
            {
                messages = JsonSerializer.Deserialize<List<Message>>(File.ReadAllText(filePath), options);
            }

            if (messages != null)
            {
                messages.Add(message);
                File.WriteAllText(filePath, JsonSerializer.Serialize(messages, options));
            }
        }
    }
    
    /// <summary>
    /// The date time converter class
    /// </summary>
    /// <seealso cref="JsonConverter{DateTime}"/>
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Reads the reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="typeToConvert">The type to convert</param>
        /// <param name="options">The options</param>
        /// <returns>The date time</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        /// <summary>
        /// Writes the writer
        /// </summary>
        /// <param name="writer">The writer</param>
        /// <param name="value">The value</param>
        /// <param name="options">The options</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString("dd/MM/yyyy HH:mm:ss"));
            //01/05/2020 10:12:32
        }
    }
}