// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxPlayerTest.cs
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
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The linux player test class
    /// </summary>
    public class LinuxPlayerTest
    {
        /// <summary>
        ///     Tests that test method
        /// </summary>
        [LinuxOnly]
        public void TestMethod()
        {
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that set volume valid input
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_ValidInput()
        {
            LinuxPlayer player = new LinuxPlayer();
            await player.SetVolume(50);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that set volume invalid input
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_InvalidInput()
        {
            LinuxPlayer player = new LinuxPlayer();
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(101));
        }
        
        /// <summary>
        /// Tests that get bash command valid input
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_ValidInput()
        {
            LinuxPlayer player = new LinuxPlayer();
            string command = player.GetBashCommand("test.mp3");
            
            Assert.Equal("mpg123 -q", command);
        }
        
        /// <summary>
        /// Tests that get bash command invalid input
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_InvalidInput()
        {
            LinuxPlayer player = new LinuxPlayer();
            string command = player.GetBashCommand("test.wav");
            
            Assert.Equal("aplay -q", command);
        }
    }
}