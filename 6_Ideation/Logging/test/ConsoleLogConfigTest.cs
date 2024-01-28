// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogConfigTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     The console log config test class
    /// </summary>
    public class ConsoleLogConfigTest
    {
        /// <summary>
        ///     Tests that get color message by type should return trace color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnTraceColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Trace);
            Assert.Equal(ConsoleColor.White, color);
        }

        /// <summary>
        ///     Tests that get color message by type should return info color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnInfoColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Info);
            Assert.Equal(ConsoleColor.DarkGreen, color);
        }

        /// <summary>
        ///     Tests that get color message by type should return log color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnLogColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Log);
            Assert.Equal(ConsoleColor.White, color);
        }

        /// <summary>
        ///     Tests that get color message by type should return event color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnEventColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Event);
            Assert.Equal(ConsoleColor.DarkMagenta, color);
        }

        /// <summary>
        ///     Tests that get color message by type should return warning color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnWarningColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Warning);
            Assert.Equal(ConsoleColor.DarkYellow, color);
        }

        /// <summary>
        ///     Tests that get color message by type should return error color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnErrorColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Error);
            Assert.Equal(ConsoleColor.Red, color);
        }

        /// <summary>
        ///     Tests that get color message by type should return exception color
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldReturnExceptionColor()
        {
            ConsoleColor color = ConsoleLogConfig.GetColorMessageByType(MessageType.Exception);
            Assert.Equal(ConsoleColor.DarkRed, color);
        }

        /// <summary>
        ///     Tests that get color message by type should throw exception when invalid message type
        /// </summary>
        [Fact]
        public void GetColorMessageByType_ShouldThrowException_WhenInvalidMessageType()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                ConsoleLogConfig.GetColorMessageByType((MessageType) 100));
        }
    }
}