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

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     The console controller class
    /// </summary>
    public static class ConsoleController
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConsoleController" /> class
        /// </summary>
        static ConsoleController()
        {
            _dirPath = Environment.CurrentDirectory + "/log";
            _filePath = Environment.CurrentDirectory + $"/log/{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}_{DateTime.Now.Hour}-{DateTime.Now.Minute}.log";
        }
        
        /// <summary>
        ///     The file path
        /// </summary>
        private static string _filePath;

        /// <summary>
        ///     The dir path
        /// </summary>
        private static string _dirPath;

        /// <summary>
        ///     Prints the to console using the specified message
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
            Console.ResetColor();
        }
    }
}