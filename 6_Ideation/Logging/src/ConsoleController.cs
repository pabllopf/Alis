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

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     The console controller class
    /// </summary>
    public static class ConsoleController
    {
       
        /// <summary>
        /// Prints the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="detailLevel">The detail level</param>
        public static void Print(Message message, DetailLevel detailLevel)
        {
            Console.ForegroundColor = ConsoleLogConfig.GetColorMessageByType(message.MessageType);
            if (detailLevel == DetailLevel.Minimal)
            {
                Console.WriteLine($"[{message.DateTime}] {message.Level}: {message.Content}");
            }
            else if (detailLevel == DetailLevel.Full)
            {
                Console.WriteLine($"[{message.DateTime}] {message.Level}: {message.Content} \n" +
                                  $"   method: '{message.Method}' \n" +
                                  $"   line:   '{message.Line}' \n" +
                                  $"   file:   '{message.File}' \n" +
                                  $"   {message.StackTrace} \n");
            }

            Console.ResetColor();
        }
    }
}