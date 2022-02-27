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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

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
        /// The my file
        /// </summary>
        private static readonly System.IO.FileStream LogFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class
        /// </summary>
        static Logger()
        {
            Level = LogLevel.Info;
            
            System.Console.WriteLine("SYSTEM STATS \n" +
                                     $"- MachineName:    {System.Environment.MachineName} \n" +
                                     $"- UserName:       {System.Environment.UserName} \n" +
                                     $"- ProcessId:      {System.Environment.ProcessId} \n" +
                                     $"- OSVersion:      {System.Environment.OSVersion} \n" +
                                     $"- 64OS:           {System.Environment.Is64BitOperatingSystem} \n" +
                                     $"- .NET CLR:       {System.Environment.Version} \n" +
                                     $"- ProcessorCount: {System.Environment.ProcessorCount} \n" +
                                     $"- WorkDirectory:  {System.Environment.CurrentDirectory} \n");
            
            string path = System.Environment.CurrentDirectory + "/logs";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            LogFile = System.IO.File.Create(path + "/" + System.DateTime.Now.ToString("yyyy_M_dd-HH_mm_ss") + ".log");
            LogFile.Close();
        }
        

        /// <summary>
        /// Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Info(string message)
        {
            if (Level is LogLevel.Info)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkGray;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] INFO '{message}' \n" +
                       $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                       $"StackTrace:\n {System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Infoes the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Info(string message, params object[] args)
        {
            if (Level is LogLevel.Info)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkGray;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] INFO '{message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n {System.Environment.StackTrace} \n";
                System.Console.WriteLine(text, args);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        /// <summary>
        /// Infoes
        /// </summary>
        public static void Trace()
        {
            if (Level is LogLevel.Info)
            {
                StackTrace stack = new StackTrace();
                string? assemblyQualifiedName = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.AssemblyQualifiedName;
                string fullName = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.FullName + "." + stack.GetFrame(1)?.GetMethod()?.Name;
                ParameterInfo[]? parameters = stack.GetFrame(1)?.GetMethod()?.GetParameters();
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
                
                string text = $"[{System.DateTime.Now}] TRACE '{fullName}({parametersText}) \n" +
                              $"Assembly:    {assemblyQualifiedName} \n" +
                              $"ThreadId:    {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
            }
        }
        
        public static void Trace(params object[] args)
        {
            if (Level is LogLevel.Info)
            {
                StackTrace stack = new StackTrace();
                string? assemblyQualifiedName = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.AssemblyQualifiedName;
                string fullName = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.FullName + "." + stack.GetFrame(1)?.GetMethod()?.Name;
                ParameterInfo[]? parameters = stack.GetFrame(1)?.GetMethod()?.GetParameters();
                string parametersText = "";
                for (int index = 0; index < parameters.Length; index++)
                {
                    if (index != parameters.Length - 1)
                    {
                        parametersText += $"{parameters[index].ParameterType.Name} {parameters[index].Name}={args[index]}, ";
                    }
                    else
                    {
                        parametersText += $"{parameters[index].ParameterType.Name} {parameters[index].Name}={args[index]}";
                    }
                }
                
                string text = $"[{System.DateTime.Now}] TRACE '{fullName}({parametersText}) \n" +
                              $"Assembly:    {assemblyQualifiedName} \n" +
                              $"ThreadId:    {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
            }
        }
        
        /// <summary>
        /// Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Trace(string message)
        {
            if (Level is LogLevel.Info)
            {
                string text = $"[{System.DateTime.Now}] TRACE '{message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
            }
        }
        
        /// <summary>
        /// Traces the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Trace(string message, params object[] args)
        {
            if (Level is LogLevel.Info)
            {
                StackTrace stack = new StackTrace();
                int? id = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.GetHashCode();
                string? assemblyQualifiedName = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.AssemblyQualifiedName;
                string fullName = stack.GetFrame(1)?.GetMethod()?.ReflectedType?.FullName + "." + stack.GetFrame(1)?.GetMethod()?.Name;
                    
                string text = $"[{System.DateTime.Now}] TRACE '{message}' '{string.Join(" ", args)}' \n" +
                              $"Assembly:    {assemblyQualifiedName} \n" +
                              $"HashCode:    {id} \n" +
                              $"ThreadId:    {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, contents: text, Encoding.UTF8);
            }
        }
        
        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Log(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkCyan;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] LOG '{message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Logs the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Log(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkCyan;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] LOG '{message}' '{string.Join(" ", args)}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Warning(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] WARNING '{message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Warnings the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Warning(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] WARNING '{message}' '{string.Join(" ", args)}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Successes the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Success(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkGreen;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] SUCCESS '{message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Successes the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Success(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkGreen;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] SUCCESS '{message}' '{string.Join(" ", args)}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.Console.WriteLine(text);
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.ResetColor();
            }
        }
        
        
        /// <summary>
        /// Exceptions the exception
        /// </summary>
        /// <param name="exception">The exception</param>
        public static void Exception(System.Exception exception)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal or LogLevel.Critical)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] EXCEPTION '{exception.Message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.Error.WriteLine(text);
                System.Console.ResetColor();
            }
        }
        
        
        /// <summary>
        /// Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        public static void Exception(string message)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal or LogLevel.Critical)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] EXCEPTION '{message}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.Error.WriteLine(text);
                System.Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Exceptions the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="args">The args</param>
        public static void Exception(string message, params object[] args)
        {
            if (Level is LogLevel.Info or LogLevel.Log or LogLevel.Normal or LogLevel.Critical)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                System.Console.ForegroundColor = System.ConsoleColor.White;
                string text = $"[{System.DateTime.Now}] EXCEPTION '{message}' '{string.Join(" ", args)}' \n" +
                              $"ThreadId:  {System.Environment.CurrentManagedThreadId} \n" +
                              $"StackTrace:\n{System.Environment.StackTrace} \n";
                System.IO.File.AppendAllText(LogFile.Name, text, Encoding.UTF8);
                System.Console.Error.WriteLine(text);
                System.Console.ResetColor();
            }
        }
    }
}