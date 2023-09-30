// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayer.cs
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Alis.Core.Audio.OS.Interfaces;
using Alis.Core.Audio.OS.Utils;

namespace Alis.Core.Audio.OS.Players
{
    /// <summary>
    ///     The windows player class
    /// </summary>
    /// <seealso cref="IPlayer" />
    internal class WindowsPlayer : IPlayer
    {
        /// <summary>
        ///     The file name
        /// </summary>
        private string _fileName;

        /// <summary>
        ///     The playback timer
        /// </summary>
        private Timer _playbackTimer;

        /// <summary>
        ///     The play stopwatch
        /// </summary>
        private Stopwatch _playStopwatch;

        public event EventHandler PlaybackFinished;

        /// <summary>
        ///     Gets or sets the value of the playing
        /// </summary>
        public bool Playing { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the paused
        /// </summary>
        public bool Paused { get; private set; }

        /// <summary>
        ///     Plays the file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        public Task Play(string fileName)
        {
            FileUtil.ClearTempFiles();
            _fileName = $"\"{FileUtil.CheckFileToPlay(fileName)}\"";
            _playbackTimer = new Timer
            {
                AutoReset = false
            };
            _playStopwatch = new Stopwatch();
            ExecuteMsiCommand("Close All");
            ExecuteMsiCommand($"Status {_fileName} Length");
            ExecuteMsiCommand($"Play {_fileName}");
            Paused = false;
            Playing = true;
            _playbackTimer.Elapsed += HandlePlaybackFinished;
            _playbackTimer.Start();
            _playStopwatch.Start();

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Pauses this instance
        /// </summary>
        public Task Pause()
        {
            if (Playing && !Paused)
            {
                ExecuteMsiCommand($"Pause {_fileName}");
                Paused = true;
                _playbackTimer.Stop();
                _playStopwatch.Stop();
                _playbackTimer.Interval -= _playStopwatch.ElapsedMilliseconds;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        public Task Resume()
        {
            if (Playing && Paused)
            {
                ExecuteMsiCommand($"Resume {_fileName}");
                Paused = false;
                _playbackTimer.Start();
                _playStopwatch.Reset();
                _playStopwatch.Start();
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public Task Stop()
        {
            if (Playing)
            {
                ExecuteMsiCommand($"Stop {_fileName}");
                Playing = false;
                Paused = false;
                _playbackTimer.Stop();
                _playStopwatch.Stop();
                FileUtil.ClearTempFiles();
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        public Task SetVolume(byte percent)
        {
            // Calculate the volume that's being set
            int newVolume = ushort.MaxValue / 100 * percent;
            // Set the same volume for both the left and the right channels
            uint newVolumeAllChannels = ((uint) newVolume & 0x0000ffff) | ((uint) newVolume << 16);
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Mcis the send string using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="stringReturn">The string return</param>
        /// <param name="returnLength">The return length</param>
        /// <param name="hwndCallback">The hwnd callback</param>
        /// <returns>The int</returns>
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string command, StringBuilder stringReturn, int returnLength, IntPtr hwndCallback);

        /// <summary>
        ///     Mcis the get error string using the specified error code
        /// </summary>
        /// <param name="errorCode">The error code</param>
        /// <param name="errorText">The error text</param>
        /// <param name="errorTextSize">The error text size</param>
        /// <returns>The int</returns>
        [DllImport("winmm.dll")]
        private static extern int mciGetErrorString(int errorCode, StringBuilder errorText, int errorTextSize);

        /// <summary>
        ///     Waves the out set volume using the specified hwo
        /// </summary>
        /// <param name="hwo">The hwo</param>
        /// <param name="dwVolume">The dw volume</param>
        /// <returns>The int</returns>
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        /// <summary>
        ///     Handles the playback finished using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void HandlePlaybackFinished(object sender, ElapsedEventArgs e)
        {
            Playing = false;
            PlaybackFinished?.Invoke(this, e);
            _playbackTimer.Dispose();
            _playbackTimer = null;
        }

        /// <summary>
        ///     Executes the msi command using the specified command string
        /// </summary>
        /// <param name="commandString">The command string</param>
        /// <exception cref="Exception"></exception>
        private Task ExecuteMsiCommand(string commandString)
        {
            StringBuilder sb = new StringBuilder();

            int result = mciSendString(commandString, sb, 1024 * 1024, IntPtr.Zero);

            if (result != 0)
            {
                StringBuilder errorSb = new StringBuilder($"Error executing MCI command '{commandString}'. Error code: {result}.");
                StringBuilder sb2 = new StringBuilder(128);

                mciGetErrorString(result, sb2, 128);
                errorSb.Append($" Message: {sb2}");

                throw new Exception(errorSb.ToString());
            }

            if (commandString.ToLower().StartsWith("status") && int.TryParse(sb.ToString(), out int length))
            {
                _playbackTimer.Interval = length;
            }

            return Task.CompletedTask;
        }
    }
}