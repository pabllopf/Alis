// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ServerMessageEventArgsTest.cs
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
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The server message event args test class
    /// </summary>
    public class ServerMessageEventArgsTest
    {
        /// <summary>
        ///     Tests that constructor sets channel and message
        /// </summary>
        [Fact]
        public void Constructor_SetsChannelAndMessage_ReturnsCorrectValues()
        {
            ServerMessageEventArgs args = new ServerMessageEventArgs("chat", "hello");

            Assert.Equal("chat", args.Channel);
            Assert.Equal("hello", args.Message);
        }

        /// <summary>
        ///     Tests that constructor null channel returns null channel
        /// </summary>
        [Fact]
        public void Constructor_NullChannel_ReturnsNullChannel()
        {
            ServerMessageEventArgs args = new ServerMessageEventArgs(null, "message");

            Assert.Null(args.Channel);
        }

        /// <summary>
        ///     Tests that constructor null message returns null message
        /// </summary>
        [Fact]
        public void Constructor_NullMessage_ReturnsNullMessage()
        {
            ServerMessageEventArgs args = new ServerMessageEventArgs("chat", null);

            Assert.Null(args.Message);
        }
    }
}
