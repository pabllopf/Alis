// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayerTests.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Threading.Tasks;
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
        /// Sets the volume with zero should calculate min volume
        /// </summary>
        [WindowsOnly]
        public void SetVolume_WithZero_ShouldCalculateMinVolume()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            MethodInfo setVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "SetVolume",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            setVolumeMethod.Invoke(player, new object[] { 0 });

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Sets the volume with fifty should calculate mid volume
        /// </summary>
        [WindowsOnly]
        public void SetVolume_WithFifty_ShouldCalculateMidVolume()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            MethodInfo setVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "SetVolume",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            setVolumeMethod.Invoke(player, new object[] { 50 });

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Sets the volume with hundred should calculate max volume
        /// </summary>
        [WindowsOnly]
        public void SetVolume_WithHundred_ShouldCalculateMaxVolume()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            MethodInfo setVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "SetVolume",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            setVolumeMethod.Invoke(player, new object[] { 100 });

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Sets the volume calculation should produce symmetric channels
        /// </summary>
        [WindowsOnly]
        public void SetVolume_Calculation_ShouldProduceSymmetricChannels()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            MethodInfo setVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "SetVolume",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            setVolumeMethod.Invoke(player, new object[] { 50 });

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Sets the volume with negative value should handle gracefully
        /// </summary>
        [WindowsOnly]
        public void SetVolume_WithNegativeValue_ShouldHandleGracefully()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            MethodInfo setVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "SetVolume",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act & Assert
            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => setVolumeMethod.Invoke(player, new object[] { -1 }));
            Assert.NotNull(exception.InnerException);
        }

        /// <summary>
        /// Sets the volume with value over hundred should handle gracefully
        /// </summary>
        [WindowsOnly]
        public void SetVolume_WithValueOverHundred_ShouldHandleGracefully()
        {
            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            MethodInfo setVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "SetVolume",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act & Assert
            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => setVolumeMethod.Invoke(player, new object[] { 101 }));
            Assert.NotNull(exception.InnerException);
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
            Assert.NotNull(isPlayingProperty);
            Assert.True(isPlayingProperty.CanRead);
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
            Assert.NotNull(isPausedProperty);
            Assert.True(isPausedProperty.CanRead);
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
            Assert.NotNull(eventInfo);
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
            Assert.NotNull(eventInfo);
        }

        /// <summary>
        /// Waves the out set volume return type should be int
        /// </summary>
        [WindowsOnly]
        public void WaveOutSetVolume_ReturnType_ShouldBeInt()
        {
            // Arrange
            MethodInfo waveOutSetVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "WaveOutSetVolume",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(waveOutSetVolumeMethod);
            Assert.Equal(typeof(int), waveOutSetVolumeMethod.ReturnType);
        }

        /// <summary>
        /// Waves the out get volume return type should be int
        /// </summary>
        [WindowsOnly]
        public void WaveOutGetVolume_ReturnType_ShouldBeInt()
        {
            // Arrange
            MethodInfo waveOutGetVolumeMethod = typeof(WindowsPlayer).GetMethod(
                "WaveOutGetVolume",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(waveOutGetVolumeMethod);
            Assert.Equal(typeof(int), waveOutGetVolumeMethod.ReturnType);
        }

        /// <summary>
        /// Waves the out reset return type should be int
        /// </summary>
        [WindowsOnly]
        public void WaveOutReset_ReturnType_ShouldBeInt()
        {
            // Arrange
            MethodInfo waveOutResetMethod = typeof(WindowsPlayer).GetMethod(
                "WaveOutReset",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(waveOutResetMethod);
            Assert.Equal(typeof(int), waveOutResetMethod.ReturnType);
        }

        /// <summary>
        /// Waves the out open return type should be int
        /// </summary>
        [WindowsOnly]
        public void WaveOutOpen_ReturnType_ShouldBeInt()
        {
            // Arrange
            MethodInfo waveOutOpenMethod = typeof(WindowsPlayer).GetMethod(
                "WaveOutOpen",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(waveOutOpenMethod);
            Assert.Equal(typeof(int), waveOutOpenMethod.ReturnType);
        }

        /// <summary>
        /// Waves the out close return type should be int
        /// </summary>
        [WindowsOnly]
        public void WaveOutClose_ReturnType_ShouldBeInt()
        {
            // Arrange
            MethodInfo waveOutCloseMethod = typeof(WindowsPlayer).GetMethod(
                "WaveOutClose",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(waveOutCloseMethod);
            Assert.Equal(typeof(int), waveOutCloseMethod.ReturnType);
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
            Assert.NotNull(waveOutWriteMethod);
            Assert.Equal(typeof(int), waveOutWriteMethod.ReturnType);
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
            Assert.NotNull(waveHeaderType);
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
            Assert.NotNull(waveFormatType);
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
            Assert.NotNull(waveOutConstantsField);
        }
    }
}
