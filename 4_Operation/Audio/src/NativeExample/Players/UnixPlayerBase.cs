using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Alis.Core.Audio.NativeExample.Interfaces;

namespace Alis.Core.Audio.NativeExample.Players
{
    /// <summary>
    /// The unix player base class
    /// </summary>
    /// <seealso cref="IPlayer"/>
    internal abstract class UnixPlayerBase : IPlayer
    {
        /// <summary>
        /// The process
        /// </summary>
        private Process _process = null;

        /// <summary>
        /// The pause process command
        /// </summary>
        internal const string PauseProcessCommand = "kill -STOP {0}";
        /// <summary>
        /// The resume process command
        /// </summary>
        internal const string ResumeProcessCommand = "kill -CONT {0}";

        public event EventHandler PlaybackFinished;

        /// <summary>
        /// Gets or sets the value of the playing
        /// </summary>
        public bool Playing { get; private set; }

        /// <summary>
        /// Gets or sets the value of the paused
        /// </summary>
        public bool Paused { get; private set; }

        /// <summary>
        /// Gets the bash command using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The string</returns>
        protected abstract string GetBashCommand(string fileName);

        /// <summary>
        /// Plays the file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        public async Task Play(string fileName)
        {
            await Stop();
            var BashToolName = GetBashCommand(fileName);
            _process = StartBashProcess($"{BashToolName} '{fileName}'");
            _process.EnableRaisingEvents = true;
            _process.Exited += HandlePlaybackFinished;
            _process.ErrorDataReceived += HandlePlaybackFinished;
            _process.Disposed += HandlePlaybackFinished;
            Playing = true;
        }

        /// <summary>
        /// Pauses this instance
        /// </summary>
        public Task Pause()
        {
            if (Playing && !Paused && _process != null)
            {
                var tempProcess = StartBashProcess(string.Format(PauseProcessCommand, _process.Id));
                tempProcess.WaitForExit();
                Paused = true;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Resumes this instance
        /// </summary>
        public Task Resume()
        {
            if (Playing && Paused && _process != null)
            {
                var tempProcess = StartBashProcess(string.Format(ResumeProcessCommand, _process.Id));
                tempProcess.WaitForExit();
                Paused = false;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Stops this instance
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
        /// Starts the bash process using the specified command
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The process</returns>
        protected Process StartBashProcess(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            return process;
        }

        /// <summary>
        /// Handles the playback finished using the specified sender
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

        /// <summary>
        /// Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        public abstract Task SetVolume(byte percent);
    }
}
