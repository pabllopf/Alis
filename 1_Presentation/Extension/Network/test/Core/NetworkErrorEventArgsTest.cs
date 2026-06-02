// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkErrorEventArgsTest.cs
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
    ///     The network error event args test class
    /// </summary>
    public class NetworkErrorEventArgsTest
    {
        /// <summary>
        ///     Tests that constructor sets message when exception not provided
        /// </summary>
        [Fact]
        public void Constructor_WithoutException_SetsMessage()
        {
            NetworkErrorEventArgs args = new NetworkErrorEventArgs("error occurred");

            Assert.Equal("error occurred", args.Message);
            Assert.Null(args.Exception);
        }

        /// <summary>
        ///     Tests that constructor sets message and exception when provided
        /// </summary>
        [Fact]
        public void Constructor_WithException_SetsMessageAndException()
        {
            Exception inner = new InvalidOperationException("inner error");
            NetworkErrorEventArgs args = new NetworkErrorEventArgs("error occurred", inner);

            Assert.Equal("error occurred", args.Message);
            Assert.Equal(inner, args.Exception);
        }
    }
}
