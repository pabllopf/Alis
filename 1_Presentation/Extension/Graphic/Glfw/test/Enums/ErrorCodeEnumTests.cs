// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ErrorCodeEnumTests.cs
// 
//  Author:GitHub Copilot
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
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for ErrorCode enum
    /// </summary>
    public class ErrorCodeEnumTests
    {
        /// <summary>
        /// Tests that error code none is defined
        /// </summary>
        [Fact]
        public void ErrorCode_None_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.None);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code not initialized is defined
        /// </summary>
        [Fact]
        public void ErrorCode_NotInitialized_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.NotInitialized);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code no current context is defined
        /// </summary>
        [Fact]
        public void ErrorCode_NoCurrentContext_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.NoCurrentContext);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code invalid enum is defined
        /// </summary>
        [Fact]
        public void ErrorCode_InvalidEnum_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.InvalidEnum);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code invalid value is defined
        /// </summary>
        [Fact]
        public void ErrorCode_InvalidValue_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.InvalidValue);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code out of memory is defined
        /// </summary>
        [Fact]
        public void ErrorCode_OutOfMemory_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.OutOfMemory);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code api unavailable is defined
        /// </summary>
        [Fact]
        public void ErrorCode_ApiUnavailable_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.ApiUnavailable);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code version unavailable is defined
        /// </summary>
        [Fact]
        public void ErrorCode_VersionUnavailable_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.VersionUnavailable);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code platform error is defined
        /// </summary>
        [Fact]
        public void ErrorCode_PlatformError_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.PlatformError);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code format unavailable is defined
        /// </summary>
        [Fact]
        public void ErrorCode_FormatUnavailable_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.FormatUnavailable);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code no window context is defined
        /// </summary>
        [Fact]
        public void ErrorCode_NoWindowContext_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.NoWindowContext);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that error code can be cast to int
        /// </summary>
        [Fact]
        public void ErrorCode_CanBeCastToInt()
        {
            // Arrange
            ErrorCode errorCode = ErrorCode.InvalidEnum;

            // Act
            int value = (int)errorCode;

            // Assert
            Assert.True(value != 0);
        }

        /// <summary>
        /// Tests that error code none has zero value
        /// </summary>
        [Fact]
        public void ErrorCode_None_HasZeroValue()
        {
            // Assert
            Assert.Equal(0, (int)ErrorCode.None);
        }

        /// <summary>
        /// Tests that error code all error codes are different
        /// </summary>
        [Fact]
        public void ErrorCode_AllErrorCodes_AreDifferent()
        {
            // Assert
            Assert.NotEqual(ErrorCode.None, ErrorCode.NotInitialized);
            Assert.NotEqual(ErrorCode.InvalidEnum, ErrorCode.InvalidValue);
            Assert.NotEqual(ErrorCode.OutOfMemory, ErrorCode.ApiUnavailable);
        }
    }
}

