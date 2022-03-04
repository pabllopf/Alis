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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Alis.Tools
{
    /// <summary>
    ///     The logger class
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Logger" /> class
        /// </summary>
        static Logger()
        {
            Level = LogLevel.Info;

            Console.WriteLine("SYSTEM STATS \n" +
                              $"- MachineName:    {Environment.MachineName} \n" +
                              $"- UserName:       {Environment.UserName} \n" +
                              $"- ProcessId:      {Environment.ProcessId} \n" +
                              $"- OSVersion:      {Environment.OSVersion} \n" +
                              $"- 64OS:           {Environment.Is64BitOperatingSystem} \n" +
                              $"- .NET CLR:       {Environment.Version} \n" +
                              $"- ProcessorCount: {Environment.ProcessorCount} \n" +
                              $"- WorkDirectory:  {Environment.CurrentDirectory} \n");

            string path = Environment.CurrentDirectory + "/logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            LogFile = File.Create(path + "/" + DateTime.Now.ToString("yyyy_M_dd-HH_mm_ss") + ".json");
            LogFile.Close();
        }

        /// <summary>
        ///     The level
        /// </summary>
        private static readonly LogLevel Level;

        /// <summary>
        ///     The my file
        /// </summary>
        private static readonly FileStream LogFile;

        /// <summary>
        ///     The log
        /// </summary>
        private static readonly List<Log> Logs = new List<Log>();


        /// <summary>
        ///     Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Info(string message)
        {
            if (Level is LogLevel.Info)
            {
                Write(CreateText(LogType.Info, message), ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        ///     Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Info(string message, params object[] args)
        {
            if (Level is LogLevel.Info)
            {
                Write(CreateText(LogType.Info, $"{message} {string.Join(",", args)}"), ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        ///     Infoes
        /// </summary>
        public static void Trace()
        {
            if (Level is LogLevel.Info)
            {
                Write(CreateText(LogType.Trace, ""), ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        ///     Traces the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Trace(params object[] args)
        {
            if (Level is LogLevel.Info)
            {
                Write(CreateText(LogType.Trace, $"{string.Join(",", args)}"), ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        ///     Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Trace(string message)
        {
            if (Level is LogLevel.Info)
            {
                Write(CreateText(LogType.Trace, message), ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        ///     Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Trace(string message, params object[] args)
        {
            if (Level is LogLevel.Info)
            {
                Write(CreateText(LogType.Trace, $"{message} {string.Join(",", args)}"), ConsoleColor.DarkGray);
            }
        }

        /// <summary>
        ///     Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Log(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log)
            {
                Write(CreateText(LogType.Log, $"{message}"), ConsoleColor.DarkCyan);
            }
        }

        /// <summary>
        ///     Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Log(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log)
            {
                Write(CreateText(LogType.Log, $"{message} {string.Join(",", args)}"), ConsoleColor.DarkCyan);
            }
        }

        /// <summary>
        ///     Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Warning(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                Write(CreateText(LogType.Warning, $"{message}"), ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        ///     Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Warning(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                Write(CreateText(LogType.Warning, $"{message} {string.Join(",", args)}"), ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        ///     Successes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Success(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                Write(CreateText(LogType.Success, $"{message}"), ConsoleColor.DarkGreen);
            }
        }

        /// <summary>
        ///     Successes the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Success(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                Write(CreateText(LogType.Success, $"{message} {string.Join(",", args)}"), ConsoleColor.DarkGreen);
            }
        }


        /// <summary>
        ///     Exceptions the exception
        /// </summary>
        /// <param name="exception">The exception</param>
        public static void Exception(Exception exception)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal or LogLevel.Critical)
            {
                WriteError(CreateText(LogType.Exception, $"{exception.Message}"), ConsoleColor.DarkRed);
            }
        }


        /// <summary>
        ///     Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Exception(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal or LogLevel.Critical)
            {
                WriteError(CreateText(LogType.Exception, $"{message}"), ConsoleColor.DarkRed);
            }
        }

        /// <summary>
        ///     Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Exception(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal or LogLevel.Critical)
            {
                WriteError(CreateText(LogType.Exception, $"{message} {string.Join(",", args)}"), ConsoleColor.DarkRed);
            }
        }

        /// <summary>
        ///     Creates the text using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        /// <returns>The string</returns>
        private static string CreateText(LogType level, string message)
        {
            StackTrace stack = new StackTrace();
            string? assemblyQualifiedName = stack.GetFrame(2)?.GetMethod()?.ReflectedType?.AssemblyQualifiedName;
            string fullName = stack.GetFrame(2)?.GetMethod()?.ReflectedType?.FullName + "." +
                              stack.GetFrame(2)?.GetMethod()?.Name;
            ParameterInfo[]? parameters = stack.GetFrame(2)?.GetMethod()?.GetParameters();
            string parametersText = "";
            for (int index = 0; index < parameters.Length; index++)
            {
                if (index != parameters.Length - 1)
                {
                    parametersText += $"{parameters[index].ParameterType.Name} {parameters[index].Name}, ";
                }
                else
                {
                    parametersText += $"{parameters[index].ParameterType.Name} {parameters[index].Name}";
                }
            }

            Log log = new Log(
                $"{level}",
                DateTime.Now,
                message,
                $"{fullName}({parametersText})",
                assemblyQualifiedName ?? "Default",
                Environment.CurrentManagedThreadId,
                Environment.StackTrace);

            Logs.Add(log);
            JsonSerializerOptions jsonSerializerSettings = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            return JsonSerializer.Serialize(log, jsonSerializerSettings);
        }

        /// <summary>
        ///     Writes the text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="color">The color</param>
        private static void Write(string text, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine(text);
            JsonSerializerOptions jsonSerializerSettings = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            File.WriteAllText(LogFile.Name, JsonSerializer.Serialize(Logs, jsonSerializerSettings));
            Console.ResetColor();
        }

        /// <summary>
        ///     Writes the error using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="color">The color</param>
        private static void WriteError(string text, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Error.WriteLine(text);
            JsonSerializerOptions jsonSerializerSettings = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            File.WriteAllText(LogFile.Name, JsonSerializer.Serialize(Logs, jsonSerializerSettings));
            Console.ResetColor();
        }
    }
}