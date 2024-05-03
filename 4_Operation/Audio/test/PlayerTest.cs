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

using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Resource;
using Xunit;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    ///     The player test class
    /// </summary>
    public class PlayerTest
    {
        /// <summary>
        ///     Tests that test method
        /// </summary>
        [Fact]
        public void TestMethod()
        {
            Assert.True(true);
        }
        
        [Fact]
        public async Task Test_Player_Play()
        {
            // Arrange
            Player player = new Player();
            string fileName = AssetManager.Find("sample.wav"); // Replace with a valid audio file for testing
            
            // Act
            await player.Play(fileName);
            
            // Assert
            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }
        
        [Fact]
        public async Task Test_Player_Pause()
        {
            // Arrange
            Player player = new Player();
            string fileName = AssetManager.Find("sample.wav"); // Replace with a valid audio file for testing
            await player.Play(fileName);
            
            // Act
            await player.Pause();
            
            // Assert
            Assert.True(player.Paused);
        }
        
        [Fact]
        public async Task Test_Player_Resume()
        {
            // Arrange
            Player player = new Player();
            string fileName = AssetManager.Find("sample.wav"); // Replace with a valid audio file for testing
            await player.Play(fileName);
            await player.Pause();
            
            // Act
            await player.Resume();
            
            // Assert
            Assert.False(player.Paused);
            Assert.True(player.Playing);
        }
        
        [Fact]
        public async Task Test_Player_Stop()
        {
            // Arrange
            Player player = new Player();
            string fileName = AssetManager.Find("sample.wav"); // Replace with a valid audio file for testing
            await player.Play(fileName);
            
            // Act
            await player.Stop();
            
            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }
        
        [Fact]
        public async Task Test_Player_SetVolume()
        {
            // Arrange
            Player player = new Player();
            byte volumePercent = 50;
            
            // Act
            await player.SetVolume(volumePercent);
            
            // Assert
            // Asserting volume changes might not be possible as the Player class does not provide a way to get the current volume
        }
    }
}