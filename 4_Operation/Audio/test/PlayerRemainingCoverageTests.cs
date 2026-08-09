// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerRemainingCoverageTests.cs
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
    ///     The player remaining coverage tests class
    /// </summary>
    public class PlayerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that player constructor sets internal player via check os
        /// </summary>
        [Fact]
        public void Player_Constructor_SetsInternalPlayerViaCheckOs()
        {
            Player player = new Player();
            IPlayer checkOsResult = Player.CheckOs();

            Assert.NotNull(player);
            Assert.NotNull(checkOsResult);
        }

        /// <summary>
        ///     Tests that check os returns mac player on current platform
        /// </summary>
        [Fact]
        public void CheckOs_ReturnsMacPlayer_OnCurrentPlatform()
        {
            IPlayer player = Player.CheckOs();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.IsType<MacPlayer>(player);
            }
            else
            {
                Assert.NotNull(player);
            }
        }

        /// <summary>
        ///     Tests that OnPlaybackFinished triggers the player's event when subscribed
        /// </summary>
        [Fact]
        public void PlaybackFinished_Chain_WorksViaOnPlaybackFinished()
        {
            Player player = new Player();
            int eventFiredCount = 0;
            player.PlaybackFinished += (sender, e) => eventFiredCount++;

            player.OnPlaybackFinished(player, EventArgs.Empty);

            Assert.Equal(1, eventFiredCount);
        }

        /// <summary>
        ///     Tests that player handles multiple rapid constructor calls
        /// </summary>
        [Fact]
        public void Player_MultipleRapidConstructorCalls_ShouldNotThrow()
        {
            for (int i = 0; i < 10; i++)
            {
                Player player = new Player();
                Assert.NotNull(player);
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
        }

        /// <summary>
        ///     Tests that check os returns valid player type for current architecture
        /// </summary>
        [Fact]
        public void CheckOs_ReturnsValidPlayer_ForCurrentArchitecture()
        {
            IPlayer player = Player.CheckOs();

            Assert.NotNull(player);

            bool isValidType = player is MacPlayer
                               || player is WindowsPlayer
                               || player is LinuxPlayer
                               || player is BrowserPlayer;

            Assert.True(isValidType);
        }

        /// <summary>
        ///     Tests that on playback finished with multiple rapid calls works
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_MultipleRapidCalls_ShouldWork()
        {
            Player player = new Player();
            int callCount = 0;
            player.PlaybackFinished += (sender, e) => callCount++;

            for (int i = 0; i < 100; i++)
            {
                player.OnPlaybackFinished(player, EventArgs.Empty);
            }

            Assert.Equal(100, callCount);
        }

        /// <summary>
        ///     Tests that playing and paused are consistently false after multiple new instances
        /// </summary>
        [Fact]
        public void PlayingAndPaused_AreConsistentlyFalse_AfterMultipleInstances()
        {
            for (int i = 0; i < 5; i++)
            {
                Player player = new Player();
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
        }

        /// <summary>
        ///     Tests that check os called statically returns consistent result
        /// </summary>
        [Fact]
        public void CheckOs_StaticCall_ReturnsConsistentResult()
        {
            IPlayer first = Player.CheckOs();
            IPlayer second = Player.CheckOs();

            Assert.NotNull(first);
            Assert.NotNull(second);
            Assert.NotSame(first, second);
            Assert.IsAssignableFrom<IPlayer>(first);
            Assert.IsAssignableFrom<IPlayer>(second);
        }

        /// <summary>
        ///     Tests that on playback finished with null args does not throw
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithNullEventArgs_ShouldNotThrow()
        {
            Player player = new Player();

            player.OnPlaybackFinished(player, null);
        }

        /// <summary>
        ///     Tests that on playback finished with both null sender and args does not throw
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithBothNull_ShouldNotThrow()
        {
            Player player = new Player();

            player.OnPlaybackFinished(null, null);
        }

        /// <summary>
        ///     Tests that player is usable after constructor for all async operations
        /// </summary>
        [Fact]
        public async Task Player_IsUsable_AfterConstruction_ForAllOperations()
        {
            Player player = new Player();

            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);

            await player.SetVolume(50);
            await player.Pause();
            await player.Resume();
            await player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that check os returns non null on all known platforms
        /// </summary>
        [Fact]
        public void CheckOs_ReturnsNonNull_OnAllKnownPlatforms()
        {
            IPlayer player = Player.CheckOs();

            Assert.NotNull(player);

            Type playerType = player.GetType();
            bool isKnownType = playerType == typeof(MacPlayer)
                               || playerType == typeof(WindowsPlayer)
                               || playerType == typeof(LinuxPlayer)
                               || playerType == typeof(BrowserPlayer);

            Assert.True(isKnownType, $"Unexpected player type: {playerType.FullName}");
        }

        /// <summary>
        ///     Tests that playback finished event is properly forwarded from OnPlaybackFinished
        /// </summary>
        [Fact]
        public void PlaybackFinished_EventForwarding_WorksCorrectly()
        {
            Player player = new Player();
            object capturedSender = null;
            EventArgs capturedArgs = null;
            int callCount = 0;

            player.PlaybackFinished += (sender, e) =>
            {
                capturedSender = sender;
                capturedArgs = e;
                callCount++;
            };

            EventArgs testArgs = new EventArgs();
            player.OnPlaybackFinished(player, testArgs);

            Assert.Same(player, capturedSender);
            Assert.Same(testArgs, capturedArgs);
            Assert.Equal(1, callCount);
        }
    }
}
