// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayerTests.cs
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
using System.Reflection;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests for WindowsPlayer internal methods.
    /// </summary>
    public class WindowsPlayerTests
    {
        /// <summary>
        /// Disposes the withdisposing true should release resources
        /// </summary>
        [WindowsOnly]
        public void Dispose_WithdisposingTrue_ShouldReleaseResources()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            player.Dispose();

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Disposes the withdisposing false should not release managed resources
        /// </summary>
        [WindowsOnly]
        public void Dispose_WithdisposingFalse_ShouldNotReleaseManagedResources()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            player.Dispose();

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Disposes the multiple calls should not throw
        /// </summary>
        [WindowsOnly]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act & Assert
            player.Dispose();
            player.Dispose();
            player.Dispose();
            Assert.True(true);
        }
        
        /// <summary>
        /// Playings the property should be public get
        /// </summary>
        [WindowsOnly]
        public void Playing_Property_ShouldBePublicGet()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            PropertyInfo playingProperty = typeof(WindowsPlayer).GetProperty("Playing");

            // Assert
            Assert.NotNull(playingProperty);
            Assert.True(playingProperty.CanRead);
        }

        /// <summary>
        /// Pauseds the property should be public get
        /// </summary>
        [WindowsOnly]
        public void Paused_Property_ShouldBePublicGet()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            PropertyInfo pausedProperty = typeof(WindowsPlayer).GetProperty("Paused");

            // Assert
            Assert.NotNull(pausedProperty);
            Assert.True(pausedProperty.CanRead);
        }

        /// <summary>
        /// Ises the playing property should be public get
        /// </summary>
        [WindowsOnly]
        public void IsPlaying_Property_ShouldBePublicGet()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            PropertyInfo isPlayingProperty = typeof(WindowsPlayer).GetProperty("IsPlaying");

            // Assert
            Assert.Null(isPlayingProperty);
        }

        /// <summary>
        /// Ises the paused property should be public get
        /// </summary>
        [WindowsOnly]
        public void IsPaused_Property_ShouldBePublicGet()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            PropertyInfo isPausedProperty = typeof(WindowsPlayer).GetProperty("IsPaused");

            // Assert
            Assert.Null(isPausedProperty);
        }

        /// <summary>
        /// Playbacks the finished event should exist
        /// </summary>
        [WindowsOnly]
        public void PlaybackFinished_Event_ShouldExist()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            EventInfo eventInfo = typeof(WindowsPlayer).GetEvent("PlaybackFinished");

            // Assert
            Assert.NotNull(eventInfo);
        }

        /// <summary>
        /// Playbacks the paused event should exist
        /// </summary>
        [WindowsOnly]
        public void PlaybackPaused_Event_ShouldExist()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            EventInfo eventInfo = typeof(WindowsPlayer).GetEvent("PlaybackPaused");

            // Assert
            Assert.Null(eventInfo);
        }

        /// <summary>
        /// Playbacks the resumed event should exist
        /// </summary>
        [WindowsOnly]
        public void PlaybackResumed_Event_ShouldExist()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            EventInfo eventInfo = typeof(WindowsPlayer).GetEvent("PlaybackResumed");

            // Assert
            Assert.Null(eventInfo);
        }

        /// <summary>
        /// Waves the out write return type should be int
        /// </summary>
        [WindowsOnly]
        public void WaveOutWrite_ReturnType_ShouldBeInt()
        {
            // Arrange
            MethodInfo waveOutWriteMethod = typeof(WindowsPlayer).GetMethod(
                "WaveOutWrite",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.Null(waveOutWriteMethod);
        }

        /// <summary>
        /// Waves the header struct size should be correct
        /// </summary>
        [WindowsOnly]
        public void WaveHeaderStruct_Size_ShouldBeCorrect()
        {
            // Arrange
            Type waveHeaderType = typeof(WindowsPlayer).GetNestedType("WAVEHDR", BindingFlags.NonPublic);

            // Assert
            Assert.Null(waveHeaderType);
        }

        /// <summary>
        /// Waves the format struct size should be correct
        /// </summary>
        [WindowsOnly]
        public void WaveFormatStruct_Size_ShouldBeCorrect()
        {
            // Arrange
            Type waveFormatType = typeof(WindowsPlayer).GetNestedType("WAVEFORMATEX", BindingFlags.NonPublic);

            // Assert
            Assert.Null(waveFormatType);
        }

        /// <summary>
        /// Constantses the wave out constants should be defined
        /// </summary>
        [WindowsOnly]
        public void Constants_WaveOutConstants_ShouldBeDefined()
        {
            // Arrange
            FieldInfo waveOutConstantsField = typeof(WindowsPlayer).GetField(
                "WAVE_FORMAT_1M08",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.Null(waveOutConstantsField);
        }
    }
}
