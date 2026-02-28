// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LogLevelTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LogLevel enumeration.
    ///     Validates enum values and comparison semantics.
    /// </summary>
    public class LogLevelTest
    {
        [Fact]
        public void LogLevel_Trace_HasValue0()
        {
            // Assert
            Assert.Equal(0, (byte)LogLevel.Trace);
        }

        [Fact]
        public void LogLevel_Debug_HasValue1()
        {
            // Assert
            Assert.Equal(1, (byte)LogLevel.Debug);
        }

        [Fact]
        public void LogLevel_Info_HasValue2()
        {
            // Assert
            Assert.Equal(2, (byte)LogLevel.Info);
        }

        [Fact]
        public void LogLevel_Warning_HasValue3()
        {
            // Assert
            Assert.Equal(3, (byte)LogLevel.Warning);
        }

        [Fact]
        public void LogLevel_Error_HasValue4()
        {
            // Assert
            Assert.Equal(4, (byte)LogLevel.Error);
        }

        [Fact]
        public void LogLevel_Critical_HasValue5()
        {
            // Assert
            Assert.Equal(5, (byte)LogLevel.Critical);
        }

        [Fact]
        public void LogLevel_None_HasValue255()
        {
            // Assert
            Assert.Equal(255, (byte)LogLevel.None);
        }

        [Fact]
        public void LogLevel_Comparison_ShouldWorkCorrectly()
        {
            // Assert
            Assert.True(LogLevel.Trace < LogLevel.Debug);
            Assert.True(LogLevel.Debug < LogLevel.Info);
            Assert.True(LogLevel.Info < LogLevel.Warning);
            Assert.True(LogLevel.Warning < LogLevel.Error);
            Assert.True(LogLevel.Error < LogLevel.Critical);
            Assert.True(LogLevel.Critical < LogLevel.None);
        }

        [Fact]
        public void LogLevel_Equality_ShouldWork()
        {
            // Assert
            Assert.True(LogLevel.Info == LogLevel.Info);
            Assert.False(LogLevel.Info == LogLevel.Warning);
        }

        [Fact]
        public void LogLevel_ToString_ShouldReturnName()
        {
            // Assert
            Assert.Equal("Trace", LogLevel.Trace.ToString());
            Assert.Equal("Debug", LogLevel.Debug.ToString());
            Assert.Equal("Info", LogLevel.Info.ToString());
            Assert.Equal("Warning", LogLevel.Warning.ToString());
            Assert.Equal("Error", LogLevel.Error.ToString());
            Assert.Equal("Critical", LogLevel.Critical.ToString());
            Assert.Equal("None", LogLevel.None.ToString());
        }

        [Fact]
        public void LogLevel_CanBeCastFromByte()
        {
            // Assert
            Assert.Equal(LogLevel.Info, (LogLevel)2);
            Assert.Equal(LogLevel.Warning, (LogLevel)3);
        }

        [Fact]
        public void LogLevel_CanBeCastToByte()
        {
            // Assert
            Assert.Equal(2, (byte)LogLevel.Info);
            Assert.Equal(3, (byte)LogLevel.Warning);
        }

        [Fact]
        public void LogLevel_OrderingIsMonotonic()
        {
            // Arrange
            var levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical, LogLevel.None };

            // Assert
            for (int i = 0; i < levels.Length - 1; i++)
            {
                Assert.True(levels[i] < levels[i + 1], $"{levels[i]} should be less than {levels[i + 1]}");
            }
        }

        [Fact]
        public void LogLevel_HasSevenValues()
        {
            // Arrange
            var values = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical, LogLevel.None };

            // Assert
            Assert.Equal(7, values.Length);
        }

        [Fact]
        public void LogLevel_NoneIsSpecial()
        {
            // Assert - None should be the highest value (255)
            Assert.True(LogLevel.None > LogLevel.Critical);
            Assert.Equal(255, (byte)LogLevel.None);
        }

        [Fact]
        public void LogLevel_GreaterThanOrEqual_ShouldWork()
        {
            // Assert
            Assert.True(LogLevel.Error >= LogLevel.Warning);
            Assert.True(LogLevel.Warning >= LogLevel.Warning);
            Assert.False(LogLevel.Warning >= LogLevel.Error);
        }

        [Fact]
        public void LogLevel_LessThanOrEqual_ShouldWork()
        {
            // Assert
            Assert.True(LogLevel.Warning <= LogLevel.Error);
            Assert.True(LogLevel.Warning <= LogLevel.Warning);
            Assert.False(LogLevel.Error <= LogLevel.Warning);
        }
    }
}

