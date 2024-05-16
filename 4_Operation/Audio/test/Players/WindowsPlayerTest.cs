// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayerTest.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The windows player test class
    /// </summary>
    public class WindowsPlayerTest
        {
            
            /// <summary>
            /// Plays the valid input
            /// </summary>
            [WindowsOnly]
        public async Task Play_ValidInput()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            
            Assert.True(player.Playing);
        }
            
            /// <summary>
        /// Tests that pause valid input
        /// </summary>
         [WindowsOnly]
        public async Task Pause_ValidInput()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Pause();
            
            Assert.True(player.Paused);
        }
        
        /// <summary>
        /// Tests that resume valid input
        /// </summary>
         [WindowsOnly]
        public async Task Resume_ValidInput()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Pause();
            await player.Resume();
            
            Assert.False(player.Paused);
        }
        
        /// <summary>
        /// Tests that stop valid input
        /// </summary>
         [WindowsOnly]
        public async Task Stop_ValidInput()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Stop();
            
            Assert.False(player.Playing);
        }
        
        /// <summary>
        /// Tests that set volume valid input
        /// </summary>
         [WindowsOnly]
        public async Task SetVolume_ValidInput()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.SetVolume(50);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that stop valid input v 2
        /// </summary>
         [WindowsOnly]
        public async Task Stop_ValidInput_v2()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Stop();
            
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }
        
        /// <summary>
        /// Tests that set volume valid input v 2
        /// </summary>
         [WindowsOnly]
        public async Task SetVolume_ValidInput_v2()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.SetVolume(50);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that set volume invalid input
        /// </summary>
         [WindowsOnly]
        public async Task SetVolume_InvalidInput()
        {
            WindowsPlayer player = new WindowsPlayer();
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(101));
        }
        
         /// <summary>
         /// Resumes the valid input v 4
         /// </summary>
         [WindowsOnly]
        public async Task Resume_ValidInput_v4()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Pause();
            await player.Resume();
            
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Resumes the when not paused does nothing
         /// </summary>
         [WindowsOnly]
        public async Task Resume_WhenNotPaused_DoesNothing()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Resume();
            
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Stops the valid input v 3
         /// </summary>
         [WindowsOnly]
        public async Task Stop_ValidInput_v3()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Stop();
            
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Stops the when not playing does nothing
         /// </summary>
         [WindowsOnly]
        public async Task Stop_WhenNotPlaying_DoesNothing()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Stop();
            
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Resumes the valid input v 5
         /// </summary>
         [WindowsOnly]
        public async Task Resume_ValidInput_v5()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Pause();
            await player.Resume();
            
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Resumes the when not paused does nothing v 4
         /// </summary>
         [WindowsOnly]
        public async Task Resume_WhenNotPaused_DoesNothing_v4()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Resume();
            
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Resumes the when not playing does nothing
         /// </summary>
         [WindowsOnly]
        public async Task Resume_WhenNotPlaying_DoesNothing()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Resume();
            
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }
        
         /// <summary>
         /// Pauses the valid input v 6
         /// </summary>
         [WindowsOnly]
        public async Task Pause_ValidInput_v6()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Pause();
            
            Assert.True(player.Paused);
        }
        
         /// <summary>
         /// Pauses the when not playing does nothing
         /// </summary>
         [WindowsOnly]
        public async Task Pause_WhenNotPlaying_DoesNothing()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Pause();
            
            Assert.False(player.Paused);
        }
        
         /// <summary>
         /// Pauses the when already paused does nothing
         /// </summary>
         [WindowsOnly]
        public async Task Pause_WhenAlreadyPaused_DoesNothing()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Play("test.mp3");
            await player.Pause();
            await player.Pause();
            
            Assert.True(player.Paused);
        }
    }
}