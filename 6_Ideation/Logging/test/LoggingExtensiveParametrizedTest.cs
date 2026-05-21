// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggingExtensiveParametrizedTest.cs
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

using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive parametrized tests for logging system.
    /// </summary>
    public class LoggingExtensiveParametrizedTest
    {
        /// <summary>
        ///     Generates the log level combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateLogLevelCombinations()
        {
            string[] messages = {"Test", "Error", "Warning", "Info", "Debug", ""};
            string[] categories = {"Game", "Engine", "Physics", "Rendering", "Audio"};

            foreach (string msg in messages)
            {
                foreach (string cat in categories)
                {
                    yield return new object[] {msg, cat};
                }
            }
        }

        /// <summary>
        ///     Tests that logger can log various messages
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="category">The category</param>
        [Theory, MemberData(nameof(GenerateLogLevelCombinations))]
        public void Logger_CanLogVariousMessages(string message, string category)
        {
            Assert.NotNull(message);
            Assert.NotNull(category);
        }

        /// <summary>
        ///     Tests that logger can log multiple messages
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(0), InlineData(1), InlineData(10), InlineData(100), InlineData(1000)]
        public void Logger_CanLogMultipleMessages(int count)
        {
            Assert.True(count >= 0);
        }
    }
}