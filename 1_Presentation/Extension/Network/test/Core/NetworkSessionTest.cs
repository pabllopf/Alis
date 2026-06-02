// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSessionTest.cs
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
    ///     The network session test class
    /// </summary>
    public class NetworkSessionTest
    {
        /// <summary>
        ///     Tests that default constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesProperties_Correctly()
        {
            NetworkSession session = new NetworkSession();

            Assert.Null(session.SessionId);
            Assert.Null(session.SessionName);
            Assert.Null(session.OwnerId);
            Assert.Equal(0, session.PlayerCount);
            Assert.Equal(0, session.MaxPlayers);
            Assert.Equal(SessionState.Waiting, session.State);
            Assert.Equal(0, session.CreatedAt);
            Assert.NotNull(session.CustomData);
            Assert.Empty(session.CustomData);
            Assert.NotNull(session.Players);
            Assert.Empty(session.Players);
        }
    }
}
