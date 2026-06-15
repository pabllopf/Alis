// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketServerOptionsTest.cs
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

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for WebSocketServerOptions class
    /// </summary>
    public class WebSocketServerOptionsTest
    {
        /// <summary>
        /// Tests that constructor creates instance with default values
        /// </summary>
        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(60), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("", options.SubProtocol);
        }

        /// <summary>
        /// Tests that constructor with keep alive interval and exception and protocol creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithKeepAliveIntervalAndExceptionAndProtocol_CreatesInstance()
        {
            // Arrange
            double keepAliveInterval = 30;
            bool includeException = true;
            string subProtocol = "json";

            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(keepAliveInterval, includeException, subProtocol);

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
            Assert.True(options.IncludeExceptionInCloseResponse);
            Assert.Equal("json", options.SubProtocol);
        }

        /// <summary>
        /// Tests that constructor with keep alive interval and protocol creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithKeepAliveIntervalAndProtocol_CreatesInstance()
        {
            // Arrange
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(45);
            string subProtocol = "binary";

            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(keepAliveInterval, subProtocol);

            // Assert
            Assert.NotNull(options);
            Assert.Equal(keepAliveInterval, options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("binary", options.SubProtocol);
        }

        /// <summary>
        /// Tests that keep alive interval default value is 60 seconds
        /// </summary>
        [Fact]
        public void KeepAliveInterval_DefaultValueIs60Seconds()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            TimeSpan result = options.KeepAliveInterval;

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(60), result);
        }

        /// <summary>
        /// Tests that keep alive interval set value
        /// </summary>
        [Fact]
        public void KeepAliveInterval_SetValue()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.KeepAliveInterval = TimeSpan.FromSeconds(30);

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
        }

        /// <summary>
        /// Tests that keep alive interval set to zero disables auto ping
        /// </summary>
        [Fact]
        public void KeepAliveInterval_SetToZero_DisablesAutoPing()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.KeepAliveInterval = TimeSpan.Zero;

            // Assert
            Assert.Equal(TimeSpan.Zero, options.KeepAliveInterval);
        }

        /// <summary>
        /// Tests that include exception in close response default value is false
        /// </summary>
        [Fact]
        public void IncludeExceptionInCloseResponse_DefaultValueIsFalse()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            bool result = options.IncludeExceptionInCloseResponse;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that include exception in close response set value to true
        /// </summary>
        [Fact]
        public void IncludeExceptionInCloseResponse_SetValueToTrue()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.IncludeExceptionInCloseResponse = true;

            // Assert
            Assert.True(options.IncludeExceptionInCloseResponse);
        }

        /// <summary>
        /// Tests that sub protocol default value is empty string
        /// </summary>
        [Fact]
        public void SubProtocol_DefaultValueIsEmptyString()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            string result = options.SubProtocol;

            // Assert
            Assert.Equal("", result);
        }

        /// <summary>
        /// Tests that sub protocol set value
        /// </summary>
        [Fact]
        public void SubProtocol_SetValue()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.SubProtocol = "json";

            // Assert
            Assert.Equal("json", options.SubProtocol);
        }

        /// <summary>
        /// Tests that sub protocol set to null
        /// </summary>
        [Fact]
        public void SubProtocol_SetToNull()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.SubProtocol = null;

            // Assert
            Assert.Null(options.SubProtocol);
        }

        /// <summary>
        /// Tests that constructor with keep alive interval 30 and exception and protocol creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithKeepAliveInterval30AndExceptionAndProtocol_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(30, true, "json");

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
            Assert.True(options.IncludeExceptionInCloseResponse);
            Assert.Equal("json", options.SubProtocol);
        }

        /// <summary>
        /// Tests that constructor with keep alive interval 45 and protocol creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithKeepAliveInterval45AndProtocol_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(TimeSpan.FromSeconds(45), "binary");

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(45), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("binary", options.SubProtocol);
        }

        /// <summary>
        /// Tests that create new instance initializes all properties
        /// </summary>
        [Fact]
        public void CreateNewInstance_InitializesAllProperties()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(60), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("", options.SubProtocol);
        }

        /// <summary>
        /// Tests that constructor with keep alive interval zero creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithKeepAliveIntervalZero_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(TimeSpan.Zero, "");

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.Zero, options.KeepAliveInterval);
        }

        /// <summary>
        /// Tests that constructor with include exception true creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithIncludeExceptionTrue_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(60, true, "json");

            // Assert
            Assert.NotNull(options);
            Assert.True(options.IncludeExceptionInCloseResponse);
        }

        /// <summary>
        /// Tests that sub protocol set to empty string
        /// </summary>
        [Fact]
        public void SubProtocol_SetToEmptyString()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.SubProtocol = "";

            // Assert
            Assert.Equal("", options.SubProtocol);
        }

        /// <summary>
        /// Tests that keep alive interval set to large value
        /// </summary>
        [Fact]
        public void KeepAliveInterval_SetToLargeValue()
        {
            // Arrange
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            options.KeepAliveInterval = TimeSpan.FromMinutes(5);

            // Assert
            Assert.Equal(TimeSpan.FromMinutes(5), options.KeepAliveInterval);
        }

        /// <summary>
        /// Tests that constructor with all parameters creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithAllParameters_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketServerOptions options = new WebSocketServerOptions(120, true, "custom-protocol");

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(120), options.KeepAliveInterval);
            Assert.True(options.IncludeExceptionInCloseResponse);
            Assert.Equal("custom-protocol", options.SubProtocol);
        }
    }
}
