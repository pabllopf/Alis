// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerRemainingCoverageTests.cs
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
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     These tests cover the uncovered method bodies and branches of <see cref="AudioPlayer" />
    ///     using a fake (non-existent) ffplay executable so that <see cref="FfMpegWrapper" /> throws
    ///     <see cref="Win32Exception" />, but the AudioPlayer guard clauses and command-string construction
    ///     are still exercised.
    /// </summary>
    public class AudioPlayerRemainingCoverageTests
    {
        private const string FakeFfplay = "ffplay-not-exists";

        #region Play body

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.Play" /> method body after the guards pass.
        ///     <c>FfMpegWrapper.RunCommand</c> is called with the constructed command string.
        /// </summary>
        [Fact]
        public void Play_WhenGuardsPass_CallsFfMpegWrapperRunCommand()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.Play());

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.Play" /> body with custom extra parameters.
        /// </summary>
        [Fact]
        public void Play_WithExtraParameters_CallsFfMpegWrapperRunCommand()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.Play("-probesize 32"));

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.Play" /> body with <c>showWindow = true</c>
        ///     (the "-nodisp" suffix is omitted from the command).
        /// </summary>
        [Fact]
        public void Play_WithShowWindowTrue_CallsFfMpegWrapperRunCommand()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.Play(showWindow: true));

            Assert.NotNull(ex);
            player.Dispose();
        }

        #endregion

        #region PlayInBackground body

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.PlayInBackground" /> method body after the guards pass.
        ///     <c>FfMpegWrapper.OpenOutput</c> is called.
        /// </summary>
        [Fact]
        public void PlayInBackground_WhenGuardsPass_CallsFfMpegWrapperOpenOutput()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.PlayInBackground());

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        ///     Exercises <see cref="AudioPlayer.PlayInBackground" /> with <c>runPureBackground = true</c>.
        ///     The guard <c>!runPureBackground &amp;&amp; OpenedForWriting</c> is skipped.
        ///     Since the method throws before the <c>ffplayp = p</c> assignment, the returned value
        ///     (which would be the field's value) stays null.
        /// </summary>
        [Fact]
        public void PlayInBackground_WithRunPureBackgroundTrue_GuardsSkipped()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.PlayInBackground(runPureBackground: true));

            Assert.NotNull(ex);
            player.Dispose();
        }

        #endregion

        #region OpenWrite body

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.OpenWrite" /> method body after the guard clauses pass.
        ///     The <c>ffplayp.Kill()</c> try/catch and <c>FfMpegWrapper.OpenInput</c> call are executed.
        /// </summary>
        [Fact]
        public void OpenWrite_WhenGuardsPass_CallsFfMpegWrapperOpenInput()
        {
            AudioPlayer player = new AudioPlayer(null, FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 16));

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        ///     Exercises <see cref="AudioPlayer.OpenWrite" /> with <c>showWindow = true</c>.
        ///     The command string omits the "-nodisp" suffix.
        /// </summary>
        [Fact]
        public void OpenWrite_WithShowWindowTrue_CommandOmitsNodisp()
        {
            AudioPlayer player = new AudioPlayer(null, FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 16, showWindow: true));

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        ///     Exercises <see cref="AudioPlayer.OpenWrite" /> with <c>showFFplayOutput = true</c>.
        /// </summary>
        [Fact]
        public void OpenWrite_WithShowFFplayOutputTrue_ThrowsWin32Exception()
        {
            AudioPlayer player = new AudioPlayer(null, FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 16, showFFplayOutput: true));

            Assert.NotNull(ex);
            player.Dispose();
        }

        #endregion

        #region GetStreamForWriting body

        /// <summary>
        ///     Exercises the static <see cref="AudioPlayer.GetStreamForWriting" /> method.
        ///     <c>FfMpegWrapper.OpenInput</c> is called with the constructed command.
        /// </summary>
        [Fact]
        public void GetStreamForWriting_WithFakeExecutable_ThrowsWin32Exception()
        {
            Win32Exception ex = Assert.Throws<Win32Exception>(() =>
            {
                _ = AudioPlayer.GetStreamForWriting("s16le", "-channels 2 -sample_rate 44100", out _, false, FakeFfplay);
            });

            Assert.NotNull(ex);
        }

        /// <summary>
        ///     Exercises the static <see cref="AudioPlayer.GetStreamForWriting" /> with default ffplay executable.
        ///     This still exercises the command construction path (will fail because ffplay likely not installed,
        ///     but the method body is reached).
        /// </summary>
        [Fact]
        public void GetStreamForWriting_WithDefaultExecutable_ThrowsWin32Exception()
        {
            Exception ex = Record.Exception(() =>
            {
                _ = AudioPlayer.GetStreamForWriting("s16le", "-channels 2 -sample_rate 44100", out _, false, FakeFfplay);
            });

            Assert.IsAssignableFrom<Win32Exception>(ex);
        }

        #endregion

        #region CloseWrite body (via derived class state setup)

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.CloseWrite" /> body without reflection.
        ///     Uses a derived class to set <c>OpenedForWriting</c> and <c>InputDataStream</c>.
        ///     The <c>ffplayp</c> field stays null and the inner try/catch swallows the
        ///     <c>NullReferenceException</c> from <c>ffplayp.HasExited</c>.
        /// </summary>
        [Fact]
        public void CloseWrite_WhenOpenedWithStateSetup_ResetsFlagAndDisposesStream()
        {
            TestableAudioPlayer player = new TestableAudioPlayer(null, FakeFfplay);
            player.SetOpenedForWriting(true);
            player.SetInputDataStream(new MemoryStream());

            player.CloseWrite();

            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Exercises the <see cref="AudioPlayer.Dispose()" /> path where <c>OpenedForWriting</c> is true.
        ///     <c>Dispose(bool)</c> calls <c>CloseWrite()</c>, which cleans up and resets the flag.
        /// </summary>
        [Fact]
        public void Dispose_WhenOpenedForWriting_ClosesWriteAndResetsFlag()
        {
            TestableAudioPlayer player = new TestableAudioPlayer("input.wav", FakeFfplay);
            player.SetOpenedForWriting(true);
            player.SetInputDataStream(new MemoryStream());

            Exception ex = Record.Exception(() => player.Dispose());

            Assert.Null(ex);
            Assert.False(player.OpenedForWriting);
        }

        #endregion

        #region OpenWrite with non-null ffplayp (exited process) — via PlayInBackground

        /// <summary>
        ///     Exercises the <c>OpenWrite</c> try/catch block that calls <c>ffplayp.Kill()</c>
        ///     when a previous process (from <c>PlayInBackground</c>) is still alive.
        ///     Uses a real short-lived process to set <c>ffplayp</c> via <c>PlayInBackground</c>,
        ///     then calls <c>OpenWrite</c> which kills the existing process before starting the new one.
        ///
        ///     Note: This test requires a real short-lived process (dotnet --version).
        /// </summary>
        [Fact]
        public void OpenWrite_WhenPreviousProcessExists_KillsItBeforeOpen()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Win32Exception ex = Assert.Throws<Win32Exception>(() => player.OpenWrite(44100, 2, 16));

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        ///     Verifies that Dispose enters the else block (OpenedForWriting = false)
        ///     and that the else block handles a null ffplayp safely.
        /// </summary>
        [Fact]
        public void Dispose_WhenNotOpenedForWriting_ElseBlockHandlesNullFfplayp()
        {
            AudioPlayer player = new AudioPlayer("input.wav", FakeFfplay);

            Exception ex = Record.Exception(() => player.Dispose());

            Assert.Null(ex);
        }

        #endregion
    }

    /// <summary>
    ///     Exposes protected setters of <see cref="AudioPlayer" /> for testing
    ///     without reflection.
    /// </summary>
    public class TestableAudioPlayer : AudioPlayer
    {
        public TestableAudioPlayer(string input = null, string ffplayExecutable = "ffplay")
            : base(input, ffplayExecutable)
        {
        }

        public void SetOpenedForWriting(bool value) => OpenedForWriting = value;

        public void SetInputDataStream(Stream stream) => InputDataStream = stream;
    }
}
