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
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The unix player base class
    /// </summary>
    /// <seealso cref="IPlayer" />
    [ExcludeFromCodeCoverage]
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
        public async Task Play(string fileName)
        {
            await Stop();
            string bashToolName = GetBashCommand(fileName);
            _process = StartBashProcess($"{bashToolName} '{fileName}'");
            _process.EnableRaisingEvents = true;
            _process.Exited += HandlePlaybackFinished;
            _process.ErrorDataReceived += HandlePlaybackFinished;
            _process.Disposed += HandlePlaybackFinished;
            Playing = true;
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