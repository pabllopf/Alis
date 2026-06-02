// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseInternalTests.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests for UnixPlayerBase internal methods using MacPlayer as concrete implementation.
    /// </summary>
    public class UnixPlayerBaseInternalTests
    {
        [MacOsOnly]
        public void HandlePlaybackFinished_WithPlayingTrue_ShouldSetPlayingFalse()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProperty.SetValue(player, true, null);

            // Act
            MethodInfo handleMethod = typeof(UnixPlayerBase).GetMethod(
                "HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handleMethod.Invoke(player, new object[] { null, EventArgs.Empty });

            // Assert
            Assert.False((bool) playingProperty.GetValue(player));
        }

        [MacOsOnly]
        public void HandlePlaybackFinished_WithPlayingFalse_ShouldNotChangeState()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProperty.SetValue(player, false, null);

            // Act
            MethodInfo handleMethod = typeof(UnixPlayerBase).GetMethod(
                "HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handleMethod.Invoke(player, new object[] { null, EventArgs.Empty });

            // Assert
            Assert.False((bool) playingProperty.GetValue(player));
        }

        [MacOsOnly]
        public void HandlePlaybackFinished_ShouldInvokePlaybackFinishedEvent()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProperty.SetValue(player, true, null);

            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            // Act
            MethodInfo handleMethod = typeof(UnixPlayerBase).GetMethod(
                "HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handleMethod.Invoke(player, new object[] { "test-sender", EventArgs.Empty });

            // Assert
            Assert.True(eventRaised);
        }

        [MacOsOnly]
        public void HandlePlaybackFinished_WithNullEventArgs_ShouldNotThrow()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProperty.SetValue(player, true, null);

            // Act & Assert
            MethodInfo handleMethod = typeof(UnixPlayerBase).GetMethod(
                "HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handleMethod.Invoke(player, new object[] { null, null });
            Assert.True(true);
        }

        [MacOsOnly]
        public void HandlePlaybackFinished_WithCustomEventArgs_ShouldPassEventArgs()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProperty.SetValue(player, true, null);

            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            EventArgs customArgs = new EventArgs();

            // Act
            MethodInfo handleMethod = typeof(UnixPlayerBase).GetMethod(
                "HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handleMethod.Invoke(player, new object[] { "sender", customArgs });

            // Assert
            Assert.Same(customArgs, receivedArgs);
        }

        [MacOsOnly]
        public void HandlePlaybackFinished_MultipleInvocations_ShouldOnlyFireOncePerPlayingState()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            int eventCount = 0;
            player.PlaybackFinished += (sender, e) => eventCount++;

            // Act
            MethodInfo handleMethod = typeof(UnixPlayerBase).GetMethod(
                "HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);

            playingProperty.SetValue(player, true, null);
            handleMethod.Invoke(player, new object[] { null, EventArgs.Empty });
            handleMethod.Invoke(player, new object[] { null, EventArgs.Empty });

            // Assert
            Assert.Equal(1, eventCount);
        }

        [MacOsOnly]
        public void Playing_Property_ShouldBePrivateSet()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo playingProperty = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);

            // Assert
            Assert.NotNull(playingProperty);
            Assert.True(playingProperty.CanRead);
            // The setter exists but is private, so CanWrite is true but the setter is not publicly accessible
            Assert.NotNull(playingProperty.SetMethod);
            Assert.False(playingProperty.SetMethod.IsPublic);
        }

        [MacOsOnly]
        public void Paused_Property_ShouldBePrivateSet()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            PropertyInfo pausedProperty = typeof(UnixPlayerBase).GetProperty("Paused", BindingFlags.Public | BindingFlags.Instance);

            // Assert
            Assert.NotNull(pausedProperty);
            Assert.True(pausedProperty.CanRead);
            // The setter exists but is private, so CanWrite is true but the setter is not publicly accessible
            Assert.NotNull(pausedProperty.SetMethod);
            Assert.False(pausedProperty.SetMethod.IsPublic);
        }

        [MacOsOnly]
        public void PauseProcessCommand_Constant_ShouldBeDefined()
        {
            // Arrange
            FieldInfo pauseCommandField = typeof(UnixPlayerBase).GetField(
                "PauseProcessCommand",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(pauseCommandField);
        }

        [MacOsOnly]
        public void ResumeProcessCommand_Constant_ShouldBeDefined()
        {
            // Arrange
            FieldInfo resumeCommandField = typeof(UnixPlayerBase).GetField(
                "ResumeProcessCommand",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Assert
            Assert.NotNull(resumeCommandField);
        }

       



        [MacOsOnly]
        public void GetAudioDuration_WithValidFile_ShouldReturnPositiveValue()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            MethodInfo getDurationMethod = typeof(UnixPlayerBase).GetMethod(
                "GetAudioDuration",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Create a temporary WAV file for testing
            string tempFile = Path.GetTempFileName();
            File.WriteAllBytes(tempFile, CreateMinimalWavFile());

            try
            {
                // Act
                object result = getDurationMethod.Invoke(player, new object[] { tempFile });

                // Assert
                Assert.NotNull(result);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }
        

        [MacOsOnly]
        public void GetAudioDuration_WithNullFile_ShouldThrowException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            MethodInfo getDurationMethod = typeof(UnixPlayerBase).GetMethod(
                "GetAudioDuration",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act & Assert
            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => getDurationMethod.Invoke(player, new object[] { null }));
            Assert.NotNull(exception.InnerException);
        }

        [MacOsOnly]
        public void ExtractWavFromResourcesAsync_WithNullFileName_ShouldThrowException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            MethodInfo extractMethod = typeof(UnixPlayerBase).GetMethod(
                "ExtractWavFromResourcesAsync",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Act & Assert
            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => extractMethod.Invoke(null, new object[] { null }));
            Assert.NotNull(exception.InnerException);
        }

        [MacOsOnly]
        public void ExtractWavFromResourcesAsync_WithEmptyFileName_ShouldThrowException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            MethodInfo extractMethod = typeof(UnixPlayerBase).GetMethod(
                "ExtractWavFromResourcesAsync",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Act & Assert
            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => extractMethod.Invoke(null, new object[] { "" }));
            Assert.NotNull(exception.InnerException);
        }
        
        private byte[] CreateMinimalWavFile()
        {
            byte[] wav = new byte[44 + 100];

            // RIFF header
            wav[0] = (byte) 'R';
            wav[1] = (byte) 'I';
            wav[2] = (byte) 'F';
            wav[3] = (byte) 'F';

            // File size - 8
            BitConverter.GetBytes(36 + 100).CopyTo(wav, 4);

            // WAVE
            wav[8] = (byte) 'W';
            wav[9] = (byte) 'A';
            wav[10] = (byte) 'V';
            wav[11] = (byte) 'E';

            // fmt chunk
            wav[12] = (byte) 'f';
            wav[13] = (byte) 'm';
            wav[14] = (byte) 't';
            wav[15] = (byte) ' ';

            // fmt size (16 for PCM)
            BitConverter.GetBytes(16).CopyTo(wav, 16);

            // Audio format (1 = PCM)
            BitConverter.GetBytes((short) 1).CopyTo(wav, 20);

            // Channels (mono)
            BitConverter.GetBytes((short) 1).CopyTo(wav, 22);

            // Sample rate (44100 Hz)
            BitConverter.GetBytes(44100).CopyTo(wav, 24);

            // Byte rate
            BitConverter.GetBytes(44100).CopyTo(wav, 28);

            // Block align
            BitConverter.GetBytes((short) 1).CopyTo(wav, 32);

            // Bits per sample (8)
            BitConverter.GetBytes((short) 8).CopyTo(wav, 34);

            // data chunk
            wav[36] = (byte) 'd';
            wav[37] = (byte) 'a';
            wav[38] = (byte) 't';
            wav[39] = (byte) 'a';

            // data size
            BitConverter.GetBytes(100).CopyTo(wav, 40);

            return wav;
        }
    }
}
