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
using Alis.Core.Aspect.Data.Resource;
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
            try
            {
                Player player = new Player();
                Assert.NotNull(player);
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that play valid input
        /// </summary>
        [Fact]
        public async Task Play_ValidInput()
        {
            try
            {
                Player player = new Player();
                await player.Play(AssetManager.Find("sample_1.wav"));
                
                Assert.True(player.Playing);
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that pause valid input
        /// </summary>
        [Fact]
        public async Task Pause_ValidInput()
        {
            try
            {
                Player player = new Player();
                await player.Play(AssetManager.Find("sample_1.wav"));
                await player.Pause();
                
                Assert.True(player.Paused);
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that resume valid input
        /// </summary>
        [Fact]
        public async Task Resume_ValidInput()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Player player = new Player();
                    await player.Play(AssetManager.Find("sample_1.wav"));
                    await player.Pause();
                    await player.Resume();
                    
                    Assert.True(player.Paused);
                }
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Player player = new Player();
                    await player.Play(AssetManager.Find("sample_1.wav"));
                    await player.Pause();
                    await player.Resume();
                    
                    Assert.False(player.Paused);
                }
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Player player = new Player();
                    await player.Play(AssetManager.Find("sample_1.wav"));
                    await player.Pause();
                    await player.Resume();
                    
                    Assert.False(player.Paused);
                }
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that stop valid input
        /// </summary>
        [Fact]
        public async Task Stop_ValidInput()
        {
            try
            {
                Player player = new Player();
                await player.Play(AssetManager.Find("sample_1.wav"));
                await player.Stop();
                
                Assert.False(player.Playing);
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that set volume valid input
        /// </summary>
        [Fact]
        public async Task SetVolume_ValidInput()
        {
            try
            {
                Player player = new Player();
                await player.SetVolume(50);
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that check os windows platform
        /// </summary>
        [Fact]
        public void CheckOs_WindowsPlatform()
        {
            try
            {
                
                
                bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                
                
                IPlayer player = Player.CheckOs();
                
                if (originalPlatform)
                {
                    Assert.IsType<WindowsPlayer>(player);
                }
                else
                {
                    Assert.NotNull(player);
                }
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that check os linux platform
        /// </summary>
        [Fact]
        public void CheckOs_LinuxPlatform()
        {
            try
            {
                bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
                
                
                IPlayer player = Player.CheckOs();
                
                if (originalPlatform)
                {
                    Assert.IsType<LinuxPlayer>(player);
                }
                else
                {
                    Assert.NotNull(player);
                }
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that check os mac platform
        /// </summary>
        [Fact]
        public void CheckOs_MacPlatform()
        {
            
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    IPlayer player = Player.CheckOs();
                    
                    Assert.IsType<MacPlayer>(player);
                }
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    IPlayer player = Player.CheckOs();
                    
                    Assert.IsType<WindowsPlayer>(player);
                }
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    IPlayer player = Player.CheckOs();
                    
                    Assert.IsType<LinuxPlayer>(player);
                }
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
        
        /// <summary>
        /// Tests that check os unknown platform
        /// </summary>
        [Fact]
        public void CheckOs_UnknownPlatform()
        {
            try
            {
                bool originalPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
                
                IPlayer player = Player.CheckOs();
                
                Assert.NotNull(player);
            }
            catch (Exception e)
            {
                Assert.IsType<Exception>(e);
                throw;
            }
        }
    }
}