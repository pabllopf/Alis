// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerCoverageGapTests.cs
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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Coverage gap tests for <see cref="AudioPlayer" /> that run without FFmpeg installed.
    ///     They exercise guard clauses, state transitions, disposal semantics and command
    ///     launching paths using a missing executable or a short-lived system binary.
    /// </summary>
    public class AudioPlayerCoverageGapTests
    {
        /// <summary>
        ///     The missing ffplay executable name used to force process start failures
        /// </summary>
        private const string MissingFfplay = "ffplay-coverage-gap-not-exists";

        /// <summary>
        ///     The sleep executable available on unix systems, used as a stand-in ffplay
        /// </summary>
        private const string SleepExecutable = "/bin/sleep";

        /// <summary>
        ///     Exposes protected setters of <see cref="AudioPlayer" /> for state setup without reflection
        /// </summary>
        private sealed class TestablePlayer : AudioPlayer
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestablePlayer"/> class
            /// </summary>
            /// <param name="input">The input</param>
            /// <param name="ffplayExecutable">The ffplay executable</param>
            public TestablePlayer(string input = null, string ffplayExecutable = "ffplay")
                : base(input, ffplayExecutable)
            {
            }

            /// <summary>
            /// Sets the opened for writing using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetOpenedForWriting(bool value) => OpenedForWriting = value;

            /// <summary>
            /// Sets the input data stream using the specified stream
            /// </summary>
            /// <param name="stream">The stream</param>
            public void SetInputDataStream(Stream stream) => InputDataStream = stream;
        }

        /// <summary>
        ///     Tests that play when already opened for writing throws invalid operation exception
        /// </summary>
        [Fact]
        public void Play_WhenAlreadyOpenedForWriting_ThrowsInvalidOperationException()
        {
            TestablePlayer player = new TestablePlayer("input.wav");
            player.SetOpenedForWriting(true);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => player.Play());

            Assert.Contains("already opened for writing", exception.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that play with empty filename throws invalid operation exception
        /// </summary>
        [Fact]
        public void Play_WithEmptyFilename_ThrowsInvalidOperationException()
        {
            TestablePlayer player = new TestablePlayer(string.Empty);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => player.Play());

            Assert.Contains("No filename was specified", exception.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that play with missing executable throws win 32 exception
        /// </summary>
        [Fact]
        public void Play_WithMissingExecutable_ThrowsWin32Exception()
        {
            TestablePlayer player = new TestablePlayer("input.wav", MissingFfplay);

            Win32Exception exception = Assert.Throws<Win32Exception>(() => player.Play());

            Assert.NotNull(exception);
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that play with missing executable and show window throws win 32 exception
        /// </summary>
        [Fact]
        public void Play_WithMissingExecutableAndShowWindow_ThrowsWin32Exception()
        {
            TestablePlayer player = new TestablePlayer("input.wav", MissingFfplay);

            Win32Exception exception = Assert.Throws<Win32Exception>(() => player.Play(showWindow: true));

            Assert.NotNull(exception);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that play in background when already opened for writing throws invalid operation exception
        /// </summary>
        [Fact]
        public void PlayInBackground_WhenAlreadyOpenedForWriting_ThrowsInvalidOperationException()
        {
            TestablePlayer player = new TestablePlayer("input.wav");
            player.SetOpenedForWriting(true);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());

            Assert.Contains("already opened for writing", exception.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that play in background with missing executable throws win 32 exception and keeps state clean
        /// </summary>
        [Fact]
        public void PlayInBackground_WithMissingExecutable_ThrowsWin32ExceptionAndKeepsStateClean()
        {
            TestablePlayer player = new TestablePlayer("input.wav", MissingFfplay);

            Win32Exception exception = Assert.Throws<Win32Exception>(() => player.PlayInBackground());

            Assert.NotNull(exception);
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that play in background with short lived executable assigns process and returns it
        /// </summary>
        [Fact]
        public void PlayInBackground_WithShortLivedExecutable_AssignsProcessAndReturnsIt()
        {
            TestablePlayer player = new TestablePlayer("input.wav", SleepExecutable);

            Process result = player.PlayInBackground();

            Assert.NotNull(result);
            player.Dispose();
            result.Dispose();
        }

        /// <summary>
        ///     Tests that play in background with short lived executable and pure background returns unassigned process
        /// </summary>
        [Fact]
        public void PlayInBackground_WithShortLivedExecutableAndPureBackground_ReturnsUnassignedProcess()
        {
            TestablePlayer player = new TestablePlayer("input.wav", SleepExecutable);

            Process result = player.PlayInBackground(runPureBackground: true);

            Assert.Null(result);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that open write when already opened for writing throws invalid operation exception
        /// </summary>
        [Fact]
        public void OpenWrite_WhenAlreadyOpenedForWriting_ThrowsInvalidOperationException()
        {
            TestablePlayer player = new TestablePlayer("input.wav");
            player.SetOpenedForWriting(true);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => player.OpenWrite(44100, 2, 16));

            Assert.Contains("already opened for writing", exception.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that open write with missing executable throws win 32 exception and stays not opened
        /// </summary>
        [Fact]
        public void OpenWrite_WithMissingExecutable_ThrowsWin32ExceptionAndStaysNotOpened()
        {
            TestablePlayer player = new TestablePlayer(null, MissingFfplay);

            Win32Exception exception = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 16));

            Assert.NotNull(exception);
            Assert.False(player.OpenedForWriting);
            Assert.Null(player.InputDataStream);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that open write with bit depth twenty four passes validation before failing to start
        /// </summary>
        [Fact]
        public void OpenWrite_WithBitDepthTwentyFour_PassesValidationBeforeFailingToStart()
        {
            TestablePlayer player = new TestablePlayer(null, MissingFfplay);

            Win32Exception exception = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 24));

            Assert.NotNull(exception);
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that open write with bit depth thirty two passes validation before failing to start
        /// </summary>
        [Fact]
        public void OpenWrite_WithBitDepthThirtyTwo_PassesValidationBeforeFailingToStart()
        {
            TestablePlayer player = new TestablePlayer(null, MissingFfplay);

            Win32Exception exception = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 32));

            Assert.NotNull(exception);
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that open write with short lived executable opens writing and close write cleans up
        /// </summary>
        [Fact]
        public void OpenWrite_WithShortLivedExecutable_OpensWritingAndCloseWriteCleansUp()
        {
            TestablePlayer player = new TestablePlayer(null, SleepExecutable);

            player.OpenWrite(44100, 2, 16);

            Assert.True(player.OpenedForWriting);
            Assert.NotNull(player.InputDataStream);

            player.CloseWrite();

            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that close write when opened with stream and null process resets flag and disposes stream
        /// </summary>
        [Fact]
        public void CloseWrite_WhenOpenedWithStreamAndNullProcess_ResetsFlagAndDisposesStream()
        {
            TestablePlayer player = new TestablePlayer(null, MissingFfplay);
            MemoryStream stream = new MemoryStream();
            player.SetOpenedForWriting(true);
            player.SetInputDataStream(stream);

            player.CloseWrite();

            Assert.False(player.OpenedForWriting);
            Assert.False(stream.CanRead);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that dispose when opened for writing calls close write and resets flag
        /// </summary>
        [Fact]
        public void Dispose_WhenOpenedForWriting_CallsCloseWriteAndResetsFlag()
        {
            TestablePlayer player = new TestablePlayer(null, MissingFfplay);
            MemoryStream stream = new MemoryStream();
            player.SetOpenedForWriting(true);
            player.SetInputDataStream(stream);

            Exception exception = Record.Exception(() => player.Dispose());

            Assert.Null(exception);
            Assert.False(player.OpenedForWriting);
            Assert.False(stream.CanRead);
        }

        /// <summary>
        ///     Tests that dispose when opened for writing with null stream does not throw
        /// </summary>
        [Fact]
        public void Dispose_WhenOpenedForWritingWithNullStream_DoesNotThrow()
        {
            TestablePlayer player = new TestablePlayer(null, MissingFfplay);
            player.SetOpenedForWriting(true);

            Exception exception = Record.Exception(() => player.Dispose());

            Assert.Null(exception);
            Assert.False(player.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that get stream for writing with missing executable throws win 32 exception
        /// </summary>
        [Fact]
        public void GetStreamForWriting_WithMissingExecutable_ThrowsWin32Exception()
        {
            Win32Exception exception = Assert.Throws<Win32Exception>(() =>
            {
                _ = AudioPlayer.GetStreamForWriting("s16le", "-channels 2 -sample_rate 44100", out _, false, MissingFfplay);
            });

            Assert.NotNull(exception);
        }
    }
}
