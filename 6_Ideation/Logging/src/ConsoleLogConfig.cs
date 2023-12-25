// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ConsoleLogConfig.cs
// 
//  Author: Pablo Perdomo Falcón
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
    ///     The console log config class
    /// </summary>
    public static class ConsoleLogConfig
    {
        /// <summary>
        ///     Info text color
        /// </summary>
        private const ConsoleColor InfoMessageColor = ConsoleColor.DarkGreen;

        /// <summary>
        ///     Log text color
        /// </summary>
        private const ConsoleColor LogMessageColor = ConsoleColor.White;

        /// <summary>
        ///     Trace text color
        /// </summary>
        private const ConsoleColor TraceMessageColor = ConsoleColor.White;

        /// <summary>
        ///     Warning text color
        /// </summary>
        private const ConsoleColor WarningMessageColor = ConsoleColor.DarkYellow;

        /// <summary>
        ///     Error text color
        /// </summary>
        private const ConsoleColor ErrorMessageColor = ConsoleColor.Red;

        /// <summary>
        ///     Exception text color
        /// </summary>
        private const ConsoleColor ExceptionMessageColor = ConsoleColor.DarkRed;

        /// <summary>
        ///     Event text color
        /// </summary>
        private const ConsoleColor EventMessageColor = ConsoleColor.DarkMagenta;

        /// <summary>
        ///     Gets the color message by type using the specified message type
        /// </summary>
        /// <param name="messageType">The message type</param>
        /// <exception cref="ArgumentOutOfRangeException">null</exception>
        /// <returns>The console color</returns>
        public static ConsoleColor GetColorMessageByType(MessageType messageType)
        {
            return messageType switch
            {
                MessageType.Trace => TraceMessageColor,
                MessageType.Info => InfoMessageColor,
                MessageType.Log => LogMessageColor,
                MessageType.Event => EventMessageColor,
                MessageType.Warning => WarningMessageColor,
                MessageType.Error => ErrorMessageColor,
                MessageType.Exception => ExceptionMessageColor,
                _ => throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null)
            };
        }
    }
}