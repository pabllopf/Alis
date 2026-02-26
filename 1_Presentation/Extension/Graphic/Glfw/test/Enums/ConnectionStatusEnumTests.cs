// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConnectionStatusEnumTests.cs
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
    ///     Tests for ConnectionStatus enum
    /// </summary>
    public class ConnectionStatusEnumTests
    {
        [Fact]
        public void ConnectionStatus_Connected_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(ConnectionStatus), ConnectionStatus.Connected));
        }

        [Fact]
        public void ConnectionStatus_Disconnected_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(ConnectionStatus), ConnectionStatus.Disconnected));
        }

        [Fact]
        public void ConnectionStatus_CanBeCastToInt()
        {
            ConnectionStatus status = ConnectionStatus.Connected;
            int value = (int)status;
            Assert.True(value >= 0);
        }

        [Fact]
        public void ConnectionStatus_Connected_And_Disconnected_AreDifferent()
        {
            Assert.NotEqual(ConnectionStatus.Connected, ConnectionStatus.Disconnected);
        }
    }
}

