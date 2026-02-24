// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClientApiEnumTests.cs
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
    ///     Tests for ClientApi enum
    /// </summary>
    public class ClientApiEnumTests
    {
        /// <summary>
        /// Tests that client api open gl is defined
        /// </summary>
        [Fact]
        public void ClientApi_OpenGl_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ClientApi), ClientApi.OpenGl);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that client api open gl es is defined
        /// </summary>
        [Fact]
        public void ClientApi_OpenGlEs_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ClientApi), ClientApi.OpenGles);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that client api none is defined
        /// </summary>
        [Fact]
        public void ClientApi_None_IsDefined()
        {
            // Act
            bool isDefined = Enum.IsDefined(typeof(ClientApi), ClientApi.None);

            // Assert
            Assert.True(isDefined);
        }

        /// <summary>
        /// Tests that client api can be cast to int
        /// </summary>
        [Fact]
        public void ClientApi_CanBeCastToInt()
        {
            // Arrange
            ClientApi api = ClientApi.OpenGl;

            // Act
            int value = (int)api;

            // Assert
            Assert.True(value != 0);
        }

        /// <summary>
        /// Tests that client api all apis are different
        /// </summary>
        [Fact]
        public void ClientApi_AllApis_AreDifferent()
        {
            // Assert
            Assert.NotEqual(ClientApi.OpenGl, ClientApi.OpenGles);
            Assert.NotEqual(ClientApi.OpenGl, ClientApi.None);
            Assert.NotEqual(ClientApi.OpenGles, ClientApi.None);
        }
    }
}

