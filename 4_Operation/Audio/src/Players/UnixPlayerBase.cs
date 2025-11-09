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
using System.IO.Compression;
using System.Linq;

using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The unix player base class
    /// </summary>
    /// <seealso cref="IPlayer" />
    public abstract class UnixPlayerBase : IPlayer
    {
        /// <summary>
        ///     The pause process command
        /// </summary>
        internal const string PauseProcessCommand = "kill -STOP {0}";

        /// <summary>
        ///     The resume process command
        /// </summary>
        internal const string ResumeProcessCommand = "kill -CONT {0}";

        /// <summary>
        ///     The process
        /// </summary>
        private Process _process;

        /// <summary>
        ///     Event
        /// </summary>
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
        /// Extracts the wav from resources using the specified wav file name
        /// </summary>
        /// <param name="wavFileName">The wav file name</param>
        /// <exception cref="FileNotFoundException">Resource '{wavFileName}' not found in 'assets.pack'.</exception>
        /// <exception cref="FileNotFoundException">Resource file 'assets.pack' not found in embedded resources.</exception>
        /// <returns>A task containing the string</returns>
        private static string ExtractWavFromResourcesAsync(string wavFileName)
        {
            return AssetRegistry.GetResourcePathByName(wavFileName);
        }
        
        /// <summary>
        /// The last played file
        /// </summary>
        private string _lastPlayedFile;
        /// <summary>
        /// The last extracted file
        /// </summary>
        private string _lastExtractedFile;
        
        /// <summary>
        /// Plays the file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <exception cref="FileNotFoundException">The specified audio file '{fileName}' was not found and could not be extracted from resources. </exception>
        public async Task Play(string fileName)
        {
            await Stop();
        
            // Si el archivo es el mismo y ya fue extraído, lo usamos directamente
            if (_lastPlayedFile == fileName && !string.IsNullOrEmpty(_lastExtractedFile) && File.Exists(_lastExtractedFile))
            {
                fileName = _lastExtractedFile;
            }
            else
            {
                if (!File.Exists(fileName))
                {
                    try
                    {
                        fileName =  ExtractWavFromResourcesAsync(fileName);
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
       /// Plays the loop using the specified file name
       /// </summary>
       /// <param name="fileName">The file name</param>
       /// <param name="loop">The loop</param>
       public async Task PlayLoop(string fileName, bool loop)
       {
           await Stop();
       
           if (_lastPlayedFile == fileName && !string.IsNullOrEmpty(_lastExtractedFile) && File.Exists(_lastExtractedFile))
           {
               fileName = _lastExtractedFile;
           }
           else
           {
               if (!File.Exists(fileName))
               {
                   fileName =  ExtractWavFromResourcesAsync(fileName);
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

        // Utilidad para obtener la duración del audio usando afinfo
        /// <summary>
        /// Gets the audio duration using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <exception cref="FileNotFoundException">El archivo '{fileName}' no existe.</exception>
        /// <returns>The double</returns>
        private double GetAudioDuration(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"El archivo '{fileName}' no existe.");
            }

            var process = new Process
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

            var line = output.Split('\n').FirstOrDefault(l => l.Contains("estimated duration"));
            if (line != null)
            {
                var parts = line.Split(':');
                if (parts.Length > 1 && double.TryParse(parts[1].Replace(".", ",").Replace("sec", "").Trim(), out double seconds))
                {
                    return seconds;
                }
            }

            return 1.0;
        }

        /// <summary>
        ///     Pauses this instance
        /// </summary>
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
        ///     Resumes this instance
        /// </summary>
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
        ///     Stops this instance
        /// </summary>
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
        ///     Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        public abstract Task SetVolume(byte percent);

        /// <summary>
        ///     Gets the bash command using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The string</returns>
        internal abstract string GetBashCommand(string fileName);

        /// <summary>
        ///     Starts the bash process using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The process</returns>
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
        ///     Handles the playback finished using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
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