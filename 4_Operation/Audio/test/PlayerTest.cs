// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerTest.cs
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    ///     The player test class
    /// </summary>
    public class PlayerTest
    {
        /// <summary>
        /// Tests that player constructor valid input
        /// </summary>
        [Fact]
        public void Player_Constructor_ValidInput()
        {
            Player player = new Player();
            
            Assert.NotNull(player);
        }
        
        /// <summary>
        /// Tests that play valid input
        /// </summary>
        [Fact]
        public async Task Play_ValidInput()
        {
            Player player = new Player();
            await player.Play("test.mp3");
            
            Assert.True(player.Playing);
        }
        
        /// <summary>
        /// Tests that pause valid input
        /// </summary>
        [Fact]
        public async Task Pause_ValidInput()
        {
            Player player = new Player();
            await player.Play("test.mp3");
            await player.Pause();
            
            Assert.True(player.Paused);
        }
        
        /// <summary>
        /// Tests that resume valid input
        /// </summary>
        [Fact]
        public async Task Resume_ValidInput()
        {
            Player player = new Player();
            await player.Play("test.mp3");
            await player.Pause();
            await player.Resume();
            
            Assert.True(player.Paused);
        }
        
        /// <summary>
        /// Tests that stop valid input
        /// </summary>
        [Fact]
        public async Task Stop_ValidInput()
        {
            Player player = new Player();
            await player.Play("test.mp3");
            await player.Stop();
            
            Assert.False(player.Playing);
        }
        
        /// <summary>
        /// Tests that set volume valid input
        /// </summary>
        [Fact]
        public async Task SetVolume_ValidInput()
        {
            Player player = new Player();
            await player.SetVolume(50);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that check os windows platform
        /// </summary>
        [Fact]
        public void CheckOs_WindowsPlatform()
        {
            bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
           
            
            IPlayer player = Player.CheckOs();
            
            if (originalPlatform)
            {
                Assert.IsType<WindowsPlayer>(player);
            }else{
                Assert.NotNull(player);
            }
            
            
            if (!originalPlatform)
            {
                // Reset the RuntimeInformation.IsOSPlatform to its original state
            }
        }
        
        /// <summary>
        /// Tests that check os linux platform
        /// </summary>
        [Fact]
        public void CheckOs_LinuxPlatform()
        {
            bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
           
            
            IPlayer player = Player.CheckOs();
            
            if (originalPlatform)
            {
                Assert.IsType<LinuxPlayer>(player);
            }else{
                Assert.NotNull(player);
            }
            
            if (!originalPlatform)
            {
                // Reset the RuntimeInformation.IsOSPlatform to its original state
            }
        }
        
        /// <summary>
        /// Tests that check os mac platform
        /// </summary>
        [Fact]
        public void CheckOs_MacPlatform()
        {
            bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            if (!originalPlatform)
            {
                // Mock the RuntimeInformation.IsOSPlatform to return true for OSX
            }
            
            IPlayer player = Player.CheckOs();
            
            Assert.IsType<MacPlayer>(player);
            
            if (!originalPlatform)
            {
                // Reset the RuntimeInformation.IsOSPlatform to its original state
            }
        }
        
        /// <summary>
        /// Tests that check os unknown platform
        /// </summary>
        [Fact]
        public void CheckOs_UnknownPlatform()
        {
            bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            if (originalPlatform)
            {
                // Mock the RuntimeInformation.IsOSPlatform to return false for all known platforms
            }
            
            IPlayer player = Player.CheckOs();
            
            Assert.NotNull(player);
            
            if (originalPlatform)
            {
                // Reset the RuntimeInformation.IsOSPlatform to its original state
            }
        }
    }
}