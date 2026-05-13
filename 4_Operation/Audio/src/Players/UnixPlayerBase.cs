// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBase.cs
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     Abstract base class for Unix-based audio player implementations (macOS and Linux).
    ///     Provides common playback functionality using bash processes, including file extraction from resources,
    ///     process lifecycle management, and playback-duration tracking via afinfo (macOS).
    /// </summary>
    /// <seealso cref="IPlayer" />
    public abstract class UnixPlayerBase : IPlayer
    {
        /// <summary>
        ///     The bash command template used to pause a running process by sending a SIGSTOP signal.
        /// </summary>
        internal const string PauseProcessCommand = "kill -STOP {0}";

        /// <summary>
        ///     The bash command template used to resume a paused process by sending a SIGCONT signal.
        /// </summary>
        internal const string ResumeProcessCommand = "kill -CONT {0}";

        /// <summary>
        ///     The file path of the most recently extracted audio resource, used for caching.
        /// </summary>
        private string _lastExtractedFile;

        /// <summary>
        ///     The file name most recently played, used to avoid redundant extraction.
        /// </summary>
        private string _lastPlayedFile;

        /// <summary>
        ///     The bash process currently handling audio playback.
        /// </summary>
        private Process _process;

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
        ///     Starts playback of the specified audio file using a bash command-line tool.
        ///     If the file does not exist on disk, it attempts to extract it from embedded resources.
        ///     Caches the extracted file path to avoid redundant extraction for repeated play requests.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the specified audio file cannot be found on disk or extracted from resources.
        /// </exception>
        public async Task Play(string fileName)
        {
            await Stop();

            // Si el archivo es el mismo y ya fue extraído, lo usamos directamente
            if ((_lastPlayedFile == fileName) && !string.IsNullOrEmpty(_lastExtractedFile) && File.Exists(_lastExtractedFile))
            {
                fileName = _lastExtractedFile;
            }
            else
            {
                if (!File.Exists(fileName))
                {
                    try
                    {
                        fileName = ExtractWavFromResourcesAsync(fileName);
                        _lastExtractedFile = fileName;
                    }
                    catch (Exception ex)
                    {
                        throw new FileNotFoundException($"The specified audio file '{fileName}' was not found and could not be extracted from resources.", ex);
                    }
                }
                else
                {
                    _lastExtractedFile = fileName;
                }

                _lastPlayedFile = fileName;
            }

            string bashToolName = GetBashCommand(fileName);
            _process = StartBashProcess($"{bashToolName} '{fileName}'");
            _process.EnableRaisingEvents = true;
            _process.Exited += HandlePlaybackFinished;
            _process.ErrorDataReceived += HandlePlaybackFinished;
            _process.Disposed += HandlePlaybackFinished;
            Playing = true;
        }

        /// <summary>
        ///     Starts playback of the specified audio file with optional looping.
        ///     When looping is enabled, a background task continuously restarts playback in a loop
        ///     using a calculated delay based on the audio file's duration. When looping is disabled,
        ///     falls back to single-playback behavior similar to <see cref="Play" />.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <param name="loop">If <c>true</c>, the audio file plays in an infinite loop; otherwise it plays once.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        public async Task PlayLoop(string fileName, bool loop)
        {
            await Stop();

            if ((_lastPlayedFile == fileName) && !string.IsNullOrEmpty(_lastExtractedFile) && File.Exists(_lastExtractedFile))
            {
                fileName = _lastExtractedFile;
            }
            else
            {
                if (!File.Exists(fileName))
                {
                    fileName = ExtractWavFromResourcesAsync(fileName);
                    _lastExtractedFile = fileName;
                }
                else
                {
                    _lastExtractedFile = fileName;
                }

                _lastPlayedFile = fileName;
            }

            if (!loop)
            {
                _process = StartBashProcess($"afplay '{fileName}'");
                _process.EnableRaisingEvents = true;
                _process.Exited += HandlePlaybackFinished;
                Playing = true;
                return;
            }

            Playing = true;
            double duration = GetAudioDuration(fileName);
            _ = Task.Run(async () =>
            {
                while (Playing)
                {
                    _process = StartBashProcess($"afplay '{fileName}'");
                    _process.EnableRaisingEvents = true;
                    // No añadir HandlePlaybackFinished aquí
                    await Task.Delay(TimeSpan.FromSeconds(duration - 0.1));
                }
            });
        }

        /// <summary>
        ///     Pauses the currently playing audio by sending a SIGSTOP signal to the playback process.
        /// </summary>
        /// <returns>A task that represents the asynchronous pause operation.</returns>
        public Task Pause()
        {
            if (Playing && !Paused && (_process != null))
            {
                Process tempProcess = StartBashProcess(string.Format(PauseProcessCommand, _process.Id));
                tempProcess.WaitForExit();
                Paused = true;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Resumes playback of a previously paused audio file by sending a SIGCONT signal to the playback process.
        /// </summary>
        /// <returns>A task that represents the asynchronous resume operation.</returns>
        public Task Resume()
        {
            if (Playing && Paused && (_process != null))
            {
                Process tempProcess = StartBashProcess(string.Format(ResumeProcessCommand, _process.Id));
                tempProcess.WaitForExit();
                Paused = false;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Stops the current audio playback by killing the associated bash process.
        ///     Resets both the playing and paused flags to <c>false</c> and disposes the process handle.
        /// </summary>
        /// <returns>A task that represents the asynchronous stop operation.</returns>
        public Task Stop()
        {
            if (_process != null)
            {
                _process.Kill();
                _process.Dispose();
                _process = null;
            }

            Playing = false;
            Paused = false;

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Sets the audio playback volume. Must be implemented by derived platform-specific classes.
        /// </summary>
        /// <param name="percent">The volume level as a percentage from 0 to 100.</param>
        /// <returns>A task that represents the asynchronous volume change operation.</returns>
        public abstract Task SetVolume(byte percent);

        /// <summary>
        ///     Extracts a WAV file from the embedded asset pack by name and returns the extracted file path.
        /// </summary>
        /// <param name="wavFileName">The name of the WAV resource to extract.</param>
        /// <returns>The file path of the extracted WAV file on disk.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the resource is not found in the asset pack.</exception>
        private static string ExtractWavFromResourcesAsync(string wavFileName) => AssetRegistry.GetResourcePathByName(wavFileName);

        // Utilidad para obtener la duración del audio usando afinfo
        /// <summary>
        ///     Retrieves the estimated duration of an audio file in seconds using the macOS afinfo command-line tool.
        /// </summary>
        /// <param name="fileName">The path to the audio file.</param>
        /// <returns>The estimated duration of the audio in seconds. Returns 1.0 as a fallback if duration cannot be determined.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the specified audio file does not exist.</exception>
        private double GetAudioDuration(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"El archivo '{fileName}' no existe.");
            }

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/usr/bin/afinfo",
                    Arguments = fileName, // Sin comillas simples
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            string line = output.Split('\n').FirstOrDefault(l => l.Contains("estimated duration"));
            if (line != null)
            {
                string[] parts = line.Split(':');
                if ((parts.Length > 1) && double.TryParse(parts[1].Replace(".", ",").Replace("sec", "").Trim(), out double seconds))
                {
                    return seconds;
                }
            }

            return 1.0;
        }

        /// <summary>
        ///     When overridden in a derived class, returns the appropriate bash command-line audio player tool
        ///     for the given file. Used by <see cref="Play" /> to determine which command to execute.
        /// </summary>
        /// <param name="fileName">The path to the audio file.</param>
        /// <returns>The name and arguments of the command-line audio player tool.</returns>
        internal abstract string GetBashCommand(string fileName);

        /// <summary>
        ///     Starts a bash process with the specified command string.
        ///     The command is executed via <c>/bin/bash -c</c> with proper argument escaping.
        /// </summary>
        /// <param name="command">The bash command to execute.</param>
        /// <returns>The <see cref="Process" /> instance representing the started bash process.</returns>
        protected Process StartBashProcess(string command)
        {
            string escapedArgs = command.Replace("\"", "\\\"");

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            return process;
        }

        /// <summary>
        ///     Handles the process-exited, error-data-received, or disposed events from the playback process.
        ///     Sets the <see cref="Playing" /> flag to <c>false</c> and invokes the <see cref="PlaybackFinished" /> event
        ///     if playback was previously active.
        /// </summary>
        /// <param name="sender">The source of the event (the playback process).</param>
        /// <param name="e">An <see cref="EventArgs" /> that contains the event data.</param>
        internal void HandlePlaybackFinished(object sender, EventArgs e)
        {
            if (Playing)
            {
                Playing = false;
                PlaybackFinished?.Invoke(this, e);
            }
        }
    }
}
