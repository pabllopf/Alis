// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerEventArgsTest.cs
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

using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The player event args test class
    /// </summary>
    public class PlayerEventArgsTest
    {
        /// <summary>
        ///     Tests that constructor sets player
        /// </summary>
        [Fact]
        public void Constructor_SetsPlayer_ReturnsCorrectValue()
        {
            NetworkPlayer player = new NetworkPlayer {PlayerId = "p1", PlayerName = "Test"};
            PlayerEventArgs args = new PlayerEventArgs(player);

            Assert.Equal(player, args.Player);
        }

        /// <summary>
        ///     Tests that constructor null player sets null player
        /// </summary>
        [Fact]
        public void Constructor_NullPlayer_SetsNullPlayer()
        {
            PlayerEventArgs args = new PlayerEventArgs(null);

            Assert.Null(args.Player);
        }
    }
}
