// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientOptionsTest.cs
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
using Alis.Extension.Network;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for WebSocketClientOptions class
    /// </summary>
    public class WebSocketClientOptionsTest
    {
        [Fact]
        public void Constructor_CreatesInstanceWithDefaultValues()
        {
            // Arrange
            // Act
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(20), options.KeepAliveInterval);
            Assert.True(options.NoDelay);
            Assert.NotNull(options.AdditionalHttpHeaders);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Null(options.SecWebSocketProtocol);
        }

        [Fact]
        public void KeepAliveInterval_DefaultValueIs20Seconds()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            TimeSpan result = options.KeepAliveInterval;

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(20), result);
        }

        [Fact]
        public void KeepAliveInterval_SetValue()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.KeepAliveInterval = TimeSpan.FromSeconds(30);

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
        }

        [Fact]
        public void KeepAliveInterval_SetToZero_DisablesAutoPing()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.KeepAliveInterval = TimeSpan.Zero;

            // Assert
            Assert.Equal(TimeSpan.Zero, options.KeepAliveInterval);
        }

        [Fact]
        public void NoDelay_DefaultValueIsTrue()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            bool result = options.NoDelay;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NoDelay_SetValueToFalse()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.NoDelay = false;

            // Assert
            Assert.False(options.NoDelay);
        }

        [Fact]
        public void AdditionalHttpHeaders_DefaultIsEmptyDictionary()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            Dictionary<string, string> result = options.AdditionalHttpHeaders;

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void AdditionalHttpHeaders_AddHeader()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.AdditionalHttpHeaders["X-Custom-Header"] = "value";

            // Assert
            Assert.Equal(1, options.AdditionalHttpHeaders.Count);
            Assert.Equal("value", options.AdditionalHttpHeaders["X-Custom-Header"]);
        }

        [Fact]
        public void AdditionalHttpHeaders_AddMultipleHeaders()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.AdditionalHttpHeaders["Header1"] = "value1";
            options.AdditionalHttpHeaders["Header2"] = "value2";

            // Assert
            Assert.Equal(2, options.AdditionalHttpHeaders.Count);
            Assert.Equal("value1", options.AdditionalHttpHeaders["Header1"]);
            Assert.Equal("value2", options.AdditionalHttpHeaders["Header2"]);
        }

        [Fact]
        public void IncludeExceptionInCloseResponse_DefaultValueIsFalse()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            bool result = options.IncludeExceptionInCloseResponse;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IncludeExceptionInCloseResponse_SetValueToTrue()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.IncludeExceptionInCloseResponse = true;

            // Assert
            Assert.True(options.IncludeExceptionInCloseResponse);
        }

        [Fact]
        public void SecWebSocketProtocol_DefaultValueIsNull()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            string result = options.SecWebSocketProtocol;

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SecWebSocketProtocol_SetValue()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.SecWebSocketProtocol = "json";

            // Assert
            Assert.Equal("json", options.SecWebSocketProtocol);
        }

        [Fact]
        public void SecWebSocketProtocol_SetToEmptyString()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.SecWebSocketProtocol = "";

            // Assert
            Assert.Equal("", options.SecWebSocketProtocol);
        }

        [Fact]
        public void CreateNewInstance_InitializesAllProperties()
        {
            // Arrange
            // Act
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Assert
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(20), options.KeepAliveInterval);
            Assert.True(options.NoDelay);
            Assert.NotNull(options.AdditionalHttpHeaders);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Null(options.SecWebSocketProtocol);
        }

        [Fact]
        public void AdditionalHttpHeaders_IsModifiable()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.AdditionalHttpHeaders.Clear();
            options.AdditionalHttpHeaders["Test"] = "Value";

            // Assert
            Assert.Equal(1, options.AdditionalHttpHeaders.Count);
        }

        [Fact]
        public void KeepAliveInterval_SetToNegativeValue()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.KeepAliveInterval = TimeSpan.FromSeconds(-1);

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(-1), options.KeepAliveInterval);
        }

        [Fact]
        public void AdditionalHttpHeaders_AddHeaderWithSpecialCharacters()
        {
            // Arrange
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            options.AdditionalHttpHeaders["X-Special-Header"] = "value-with-special-chars";

            // Assert
            Assert.Equal("value-with-special-chars", options.AdditionalHttpHeaders["X-Special-Header"]);
        }

        [Fact]
        public void Constructor_InitializesEmptyDictionary()
        {
            // Arrange
            // Act
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Assert
            Assert.NotNull(options.AdditionalHttpHeaders);
            Assert.Empty(options.AdditionalHttpHeaders);
        }
    }
}
