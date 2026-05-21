

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
        ///     Tests that error code none is defined
        /// </summary>
        [Fact]
        public void ErrorCode_None_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.None);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code not initialized is defined
        /// </summary>
        [Fact]
        public void ErrorCode_NotInitialized_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.NotInitialized);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code no current context is defined
        /// </summary>
        [Fact]
        public void ErrorCode_NoCurrentContext_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.NoCurrentContext);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code invalid enum is defined
        /// </summary>
        [Fact]
        public void ErrorCode_InvalidEnum_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.InvalidEnum);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code invalid value is defined
        /// </summary>
        [Fact]
        public void ErrorCode_InvalidValue_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.InvalidValue);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code out of memory is defined
        /// </summary>
        [Fact]
        public void ErrorCode_OutOfMemory_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.OutOfMemory);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code api unavailable is defined
        /// </summary>
        [Fact]
        public void ErrorCode_ApiUnavailable_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.ApiUnavailable);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code version unavailable is defined
        /// </summary>
        [Fact]
        public void ErrorCode_VersionUnavailable_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.VersionUnavailable);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code platform error is defined
        /// </summary>
        [Fact]
        public void ErrorCode_PlatformError_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.PlatformError);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code format unavailable is defined
        /// </summary>
        [Fact]
        public void ErrorCode_FormatUnavailable_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.FormatUnavailable);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code no window context is defined
        /// </summary>
        [Fact]
        public void ErrorCode_NoWindowContext_IsDefined()
        {
            bool isDefined = Enum.IsDefined(typeof(ErrorCode), ErrorCode.NoWindowContext);

            Assert.True(isDefined);
        }

        /// <summary>
        ///     Tests that error code can be cast to int
        /// </summary>
        [Fact]
        public void ErrorCode_CanBeCastToInt()
        {
            ErrorCode errorCode = ErrorCode.InvalidEnum;

            int value = (int) errorCode;

            Assert.True(value != 0);
        }

        /// <summary>
        ///     Tests that error code none has zero value
        /// </summary>
        [Fact]
        public void ErrorCode_None_HasZeroValue()
        {
            // Assert
            Assert.Equal(0, (int) ErrorCode.None);
        }

        /// <summary>
        ///     Tests that error code all error codes are different
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