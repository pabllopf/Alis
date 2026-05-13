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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Time;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     Audio player implementation for Windows platforms using the Windows Multimedia API (MCI).
    ///     Manages playback via MCI commands and uses <c>waveOutSetVolume</c> for volume control.
    ///     Supports play, pause, resume, stop, loop, and volume adjustment operations.
    /// </summary>
    /// <seealso cref="IPlayer" />
    internal class WindowsPlayer : IPlayer, IDisposable
    {
        /// <summary>
        ///     The path to the currently loaded audio file being played or paused.
        /// </summary>
        private string _fileName;

        /// <summary>
        ///     Timer used to detect when playback has finished based on the audio file duration.
        /// </summary>
        private Timer _playbackTimer;

        /// <summary>
        ///     Stopwatch used to track elapsed playback time for accurate pause/resume timing.
        /// </summary>
        private Clock _playStopwatch;

        /// <summary>
        ///     Releases all resources used by the <see cref="WindowsPlayer" />, particularly the playback timer.
        /// </summary>
        public void Dispose()
        {
            _playbackTimer?.Dispose();
            _playbackTimer = null;
        }

        /// <summary>
        ///     Occurs when the current audio playback has finished.
        /// </summary>
        public event EventHandler PlaybackFinished;

        /// <summary>
        ///     Gets a value indicating whether audio playback is currently in progress.
        /// </summary>
        public bool Playing { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether audio playback is currently paused.
        /// </summary>
        public bool Paused { get; private set; }

        /// <summary>
        ///     Starts playback of the specified audio file using the Windows MCI subsystem.
        ///     If the file is not found on disk, it attempts to extract it from embedded resources.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the specified file cannot be found on disk or in resources.</exception>
        public Task Play(string fileName)
        {
            if (!File.Exists(fileName))
            {
                try
                {
                    fileName = ExtractWavFromResourcesAsync(fileName);
                }
                catch (Exception ex)
                {
                    throw new FileNotFoundException($"File '{fileName}' not found.", ex);
                }
            }

            _fileName = fileName;
            _playbackTimer = new Timer
            {
                AutoReset = false
            };
            _playStopwatch = new Clock();
            //ExecuteMsiCommand("Close All");
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
        ///     Starts playback of the specified audio file with optional looping via the MCI Repeat command.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <param name="loop">If <c>true</c>, the MCI Repeat flag is appended to the play command for continuous looping.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the specified file cannot be found on disk or in resources.</exception>
        public Task PlayLoop(string fileName, bool loop)
        {
            if (!File.Exists(fileName))
            {
                try
                {
                    fileName = ExtractWavFromResourcesAsync(fileName);
                }
                catch (Exception ex)
                {
                    throw new FileNotFoundException($"File '{fileName}' not found.", ex);
                }
            }

            _fileName = fileName;
            _playbackTimer = new Timer {AutoReset = false};
            _playStopwatch = new Clock();

            ExecuteMsiCommand($"Status {_fileName} Length");
            string playCommand = loop ? $"Play {_fileName} Repeat" : $"Play {_fileName}";
            ExecuteMsiCommand(playCommand);

            Paused = false;
            Playing = true;
            _playbackTimer.Elapsed += HandlePlaybackFinished;
            _playbackTimer.Start();
            _playStopwatch.Start();

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Pauses the currently playing audio via the MCI Pause command.
        ///     Stops the playback timer and stopwatch, and adjusts the remaining timer interval.
        /// </summary>
        /// <returns>A task that represents the asynchronous pause operation.</returns>
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
        ///     Resumes playback of a previously paused audio file via the MCI Resume command.
        ///     Restarts the timer and resets the stopwatch for accurate remaining-duration tracking.
        /// </summary>
        /// <returns>A task that represents the asynchronous resume operation.</returns>
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
        ///     Stops the current audio playback via the MCI Stop command.
        ///     Resets playing and paused flags and stops both the timer and stopwatch.
        /// </summary>
        /// <returns>A task that represents the asynchronous stop operation.</returns>
        public Task Stop()
        {
            if (Playing)
            {
                ExecuteMsiCommand($"Stop {_fileName}");
                Playing = false;
                Paused = false;
                _playbackTimer.Stop();
                _playStopwatch.Stop();
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Sets the audio playback volume using the Windows <c>waveOutSetVolume</c> API.
        ///     Calculates the appropriate 16-bit volume level for both left and right channels from a percentage value.
        /// </summary>
        /// <param name="percent">The volume level as a percentage from 0 to 100.</param>
        /// <returns>A task that represents the asynchronous volume change operation.</returns>
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
        ///     Extracts a WAV file from the embedded asset pack by name and returns its extracted file path.
        /// </summary>
        /// <param name="wavFileName">The name of the WAV resource to extract.</param>
        /// <returns>The file path of the extracted WAV file on disk.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no entry assembly is found.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the resource is not found in the asset pack.</exception>
        private static string ExtractWavFromResourcesAsync(string wavFileName) => AssetRegistry.GetResourcePathByName(wavFileName);


        /// <summary>
        ///     Sends a command string to the Windows MCI (Media Control Interface) subsystem.
        /// </summary>
        /// <param name="command">The MCI command string to send.</param>
        /// <param name="stringReturn">A <see cref="StringBuilder" /> that receives the return information.</param>
        /// <param name="returnLength">The size of the return buffer.</param>
        /// <param name="hwndCallback">A handle to a callback window for MCI notification messages.</param>
        /// <returns>Zero if the function succeeds; otherwise, an error code.</returns>
        [DllImport("winmm.dll"), ExcludeFromCodeCoverage]
        private static extern int mciSendString(string command, StringBuilder stringReturn, int returnLength, IntPtr hwndCallback);

        /// <summary>
        ///     Retrieves a textual description of an MCI error code.
        /// </summary>
        /// <param name="errorCode">The MCI error code returned by <see cref="mciSendString" />.</param>
        /// <param name="errorText">A <see cref="StringBuilder" /> that receives the error description.</param>
        /// <param name="errorTextSize">The size of the error text buffer.</param>
        /// <returns>Zero if the function succeeds; otherwise, an error code.</returns>
        [DllImport("winmm.dll"), ExcludeFromCodeCoverage]
        private static extern int mciGetErrorString(int errorCode, StringBuilder errorText, int errorTextSize);

        /// <summary>
        ///     Sets the volume of the waveform output device.
        /// </summary>
        /// <param name="hwo">A handle to the waveform-audio output device, or <see cref="IntPtr.Zero" /> for the default device.</param>
        /// <param name="dwVolume">The volume setting, with the low-order word for the left channel and the high-order word for the right channel.</param>
        /// <returns>Returns zero if successful, or an error code otherwise.</returns>
        [DllImport("winmm.dll"), ExcludeFromCodeCoverage]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        /// <summary>
        ///     Handles the timer elapsed event to signal that playback has finished.
        ///     Resets the playing flag and invokes the <see cref="PlaybackFinished" /> event.
        /// </summary>
        /// <param name="sender">The source of the event (the playback timer).</param>
        /// <param name="e">An <see cref="ElapsedEventArgs" /> that contains the event data.</param>
        private void HandlePlaybackFinished(object sender, ElapsedEventArgs e)
        {
            Playing = false;
            PlaybackFinished?.Invoke(this, e);
            _playbackTimer.Dispose();
            _playbackTimer = null;
        }

        /// <summary>
        ///     Executes an MCI command string and handles any errors returned by the MCI subsystem.
        ///     If the command is a "Status" query for length, parses the result to set the playback timer interval.
        /// </summary>
        /// <param name="commandString">The MCI command string to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown when the MCI command returns a non-zero error code.</exception>
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
