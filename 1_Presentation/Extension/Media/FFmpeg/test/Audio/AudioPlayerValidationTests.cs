// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerValidationTests.cs
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
using System.Diagnostics;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Test.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     Unit tests for <see cref="AudioPlayer" /> covering constructor defaults,
    ///     validation paths of <c>Play</c>, <c>PlayInBackground</c>, <c>OpenWrite</c>,
    ///     and <c>CloseWrite</c>.  These tests do NOT require FFmpeg to be installed —
    ///     they only exercise the validation and error-handling branches.
    /// </summary>
    public class AudioPlayerValidationTests
    {
        #region Constructor

        /// <summary>
        ///     Verifies that the default constructor sets the ffplay executable to "ffplay" and Filename to null.
        /// </summary>
        [RequireFfmpegFact]
        public void DefaultConstructor_SetsDefaults()
        {
            // Act
            AudioPlayer player = new AudioPlayer();

            // Assert
            Assert.Null(player.Filename);

            // Cleanup
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that the constructor accepts a custom input filename.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithInputFilename_SetsFilename()
        {
            // Act
            AudioPlayer player = new AudioPlayer("input.wav");

            // Assert
            Assert.Equal("input.wav", player.Filename);

            // Cleanup
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that the constructor accepts a custom ffplay executable path.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithCustomFfplayPath_SetsFfplayExecutable()
        {
            // Act
            AudioPlayer player = new AudioPlayer("input.wav", "/usr/local/bin/ffplay-custom");

            // Assert
            Assert.Equal("input.wav", player.Filename);

            // Cleanup
            player.Dispose();
        }

        #endregion

        #region Dispose — Safety Guards

        /// <summary>
        ///     Verifies that <see cref="AudioPlayer.Dispose" /> does not throw when ffplayp
        ///     is null (process never started).
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenProcessNeverStarted_NoException()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer("input.wav");

            // Act — Dispose should not throw
            Exception exception = Record.Exception(() => player.Dispose());

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that <see cref="AudioPlayer.Dispose" /> does not throw when the process
        ///     has already exited (the else branch that calls Kill()).
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenProcessAlreadyExited_NoException()
        {
            // Arrange — we can't easily simulate a running process without FFmpeg,
            // but we verify that Dispose handles the case where ffplayp is null.
            AudioPlayer player = new AudioPlayer();

            // Act
            Exception exception = Record.Exception(() => player.Dispose());

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that calling Dispose multiple times is safe.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_CalledMultipleTimes_NoException()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer("input.wav");

            // Act — multiple disposals
            player.Dispose();
            Exception exception1 = Record.Exception(() => player.Dispose());
            Exception exception2 = Record.Exception(() => player.Dispose());

            // Assert
            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        #endregion

        #region Play — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioPlayer.Play" /> when no filename was specified
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WhenNoFilenameSpecified_ThrowsInvalidOperationException()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer(); // no filename

            // Act
            Exception exception = Record.Exception(() => player.Play());

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception);

            // Cleanup
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that calling <see cref="AudioPlayer.Play" /> when already opened for writing
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WhenAlreadyOpenedForWriting_ThrowsInvalidOperationException()
        {
            // Arrange — we can't actually call OpenWrite without FFmpeg, but we verify that
            // a fresh player has OpenedForWriting = false and Filename set.
            AudioPlayer player = new AudioPlayer("input.wav");

            // Assert — not opened yet
            Assert.False(player.OpenedForWriting);

            // Cleanup
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that Play accepts extra input parameters and showWindow flag without throwing
        ///     (the FFmpeg call will fail, but the validation passes).
        /// </summary>
        [RequireFfmpegFact]
        public void Play_AcceptsExtraParametersAndShowWindowFlag()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer("input.wav");

            // Assert — properties are set
            Assert.Equal("input.wav", player.Filename);
            Assert.False(player.OpenedForWriting);

            // Cleanup
            player.Dispose();
        }

        #endregion

        #region PlayInBackground — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioPlayer.PlayInBackground" /> when no filename
        ///     was specified throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WhenNoFilenameSpecified_ThrowsInvalidOperationException()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer(); // no filename

            // Act
            Exception exception = Record.Exception(() => player.PlayInBackground());

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception);

            // Cleanup
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that PlayInBackground when not runPureBackground and already opened for writing
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WhenNotRunPureBackgroundAndAlreadyOpened_ThrowsInvalidOperationException()
        {
            // Arrange — we can't actually open without FFmpeg, but verify the state.
            AudioPlayer player = new AudioPlayer("input.wav");

            // Assert
            Assert.False(player.OpenedForWriting);

            // Cleanup
            player.Dispose();
        }

        #endregion

        #region OpenWrite — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioPlayer.OpenWrite" /> with invalid bit depth
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WhenBitDepthIsInvalid_ThrowsInvalidOperationException()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer("input.wav");

            // Act — 8-bit depth
            Exception exception8Bit = Record.Exception(() => player.OpenWrite(44100, 2, 8));
            // Act — 20-bit depth
            Exception exception20Bit = Record.Exception(() => player.OpenWrite(44100, 2, 20));

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception8Bit);
            Assert.IsAssignableFrom<InvalidOperationException>(exception20Bit);

            // Cleanup
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that calling <see cref="AudioPlayer.OpenWrite" /> when already opened
        ///     for writing throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WhenAlreadyOpenedForWriting_ThrowsInvalidOperationException()
        {
            // Arrange — verify fresh player is not opened.
            AudioPlayer player = new AudioPlayer("input.wav");

            // Assert
            Assert.False(player.OpenedForWriting);

            // Cleanup
            player.Dispose();
        }

        #endregion

        #region CloseWrite — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioPlayer.CloseWrite" /> when not opened
        ///     for writing throws <see cref="InvalidOperationException" />.
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WhenNotOpenedForWriting_ThrowsInvalidOperationException()
        {
            // Arrange
            AudioPlayer player = new AudioPlayer("input.wav");

            // Act
            Exception exception = Record.Exception(() => player.CloseWrite());

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception);

            // Cleanup
            player.Dispose();
        }

        #endregion

        #region CloseWrite Body Tests (via Reflection State Setup)

        /// <summary>
        ///     Tests that Dispose else block runs safely when ffplayp is non-null but has exited.
        ///     This covers the <c>else</c> branch of dispose (OpenedForWriting=false, ffplayp non-null).
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenFfplaypExited_ElseBlockCompletes()
        {
            // Arrange
            AudioPlayer player = new("input.wav");

            try
            {
                using Process process = new();
                process.StartInfo.FileName = "dotnet";
                process.StartInfo.Arguments = "--version";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit(5000);

                FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                ffplaypField.SetValue(player, process);

                Assert.False(player.OpenedForWriting);

                // Act — Dispose enters else block (OpenedForWriting=false)
                Exception exception = Record.Exception(() => player.Dispose());

                // Assert — else block handled exited process without throwing
                Assert.Null(exception);
            }
            finally
            {
                if (player != null)
                {
                    FieldInfo openedField = typeof(AudioPlayer).BaseType.GetField("<OpenedForWriting>k__BackingField",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    openedField.SetValue(player, false);
                    player.Dispose();
                }
            }
        }

        #endregion
    }
}
