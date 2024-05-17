// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseTest.cs
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
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Alis.Core.Audio.Test.Players.Samples;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The unix player base test class
    /// </summary>
    public class UnixPlayerBaseTest
    {
        /// <summary>
        ///     Tests that test method
        /// </summary>
        [UnixOnly]
        public void TestMethod()
        {
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that play valid input
        /// </summary>
        [UnixOnly]
        public async Task Play_ValidInput()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            await player.Play("test.mp3");
            
            Assert.True(player.Playing);
        }
    }
}