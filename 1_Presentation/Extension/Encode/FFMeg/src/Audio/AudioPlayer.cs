// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayer.cs
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
using Alis.Extension.Encode.FFMeg.BaseClasses;

namespace Alis.Extension.Encode.FFMeg.Audio
{
    /// <summary>
    ///     The audio player class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class AudioPlayer : MediaWriter<AudioFrame>, IDisposable
    {
        /// <summary>
        ///     The ffplay
        /// </summary>
        private readonly string ffplay;

        /// <summary>
        ///     The ffplayp
        /// </summary>
        private Process ffplayp;

        /// <summary>
        ///     Used for playing audio data
        /// </summary>
        /// <param name="input">Input audio to play (can be left empty if planning on playing samples directly)</param>
        /// <param name="ffplayExecutable">Name or path to the ffplay executable</param>
        public AudioPlayer(string input = null, string ffplayExecutable = "ffplay")
        {
            ffplay = ffplayExecutable;

            Filename = input;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (OpenedForWriting)
            {
                CloseWrite();
            }
            else
            {
                try
                {
                    if ((ffplayp != null) && !ffplayp.HasExited)
                    {
                        ffplayp.Kill();
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///     Play audio
        /// </summary>
        /// <param name="extraInputParameters">Extra FFmpeg input parameters to be passed (example: -probesize 32)</param>
        public void Play(string extraInputParameters = "", bool showWindow = false)
        {
            if (OpenedForWriting)
            {
                throw new InvalidOperationException("Player is already opened for writing samples!");
            }

            if (string.IsNullOrEmpty(Filename))
            {
                throw new InvalidOperationException("No filename was specified!");
            }

            FfMpegWrapper.RunCommand(ffplay, $"{extraInputParameters} -i \"{Filename}\"" + (showWindow ? "" : " -nodisp"));
        }

        /// <summary>
        ///     Play audio in background and return the process associated with it
        /// </summary>
        /// <param name="extraInputParameters">Extra FFmpeg input parameters to be passed (example: -probesize 32)</param>
        /// <param name="showWindow">Show player window</param>
        /// <param name="runPureBackground">Detach the player from this AudioPlayer control. Player won't be killed on disposing.</param>
        public Process PlayInBackground(string extraInputParameters = "", bool showWindow = false, bool runPureBackground = false)
        {
            if (!runPureBackground && OpenedForWriting)
            {
                throw new InvalidOperationException("Player is already opened for writing samples!");
            }

            if (string.IsNullOrEmpty(Filename))
            {
                throw new InvalidOperationException("No filename was specified!");
            }

            FfMpegWrapper.OpenOutput(ffplay, $"{extraInputParameters} -i \"{Filename}\"" + (showWindow ? "" : " -nodisp"), out Process p);
            if (!runPureBackground)
            {
                ffplayp = p;
            }

            return ffplayp;
        }

        /// <summary>
        ///     Open player for writing samples for playing.
        /// </summary>
        /// <param name="sampleRate">Sample rate</param>
        /// <param name="channels">Number of channels</param>
        /// <param name="bitDepth">Bits per sample (16, 24, 32)</param>
        /// <param name="extraInputParameters">Extra FFmpeg input parameters to be passed (example: -probesize 32)</param>
        /// <param name="showWindow">Show player graphical window</param>
        /// <param name="showFFplayOutput">Show FFplay output for debugging purposes.</param>
        public void OpenWrite(int sampleRate, int channels, int bitDepth = 16, string extraInputParameters = "",
            bool showWindow = false, bool showFFplayOutput = false)
        {
            if ((bitDepth != 16) && (bitDepth != 24) && (bitDepth != 32))
            {
                throw new InvalidOperationException("Acceptable bit depths are 16, 24 and 32");
            }

            if (OpenedForWriting)
            {
                throw new InvalidOperationException("Player is already opened for writing samples!");
            }

            try
            {
                if ((ffplayp != null) && !ffplayp.HasExited)
                {
                    ffplayp.Kill();
                }
            }
            catch
            {
            }

            InputDataStream = FfMpegWrapper.OpenInput(ffplay, $"{extraInputParameters} -f s{bitDepth}le -channels {channels} -sample_rate {sampleRate} -i -"
                                                              + (showWindow ? "" : " -nodisp"),
                out ffplayp, showFFplayOutput);

            OpenedForWriting = true;
        }

        /// <summary>
        ///     Close player for writing samples.
        /// </summary>
        public void CloseWrite()
        {
            if (!OpenedForWriting)
            {
                throw new InvalidOperationException("Player is not opened for writing samples!");
            }

            try
            {
                try
                {
                    if (!ffplayp.HasExited)
                    {
                        ffplayp.Kill();
                    }
                }
                catch
                {
                }

                InputDataStream.Dispose();
            }
            finally
            {
                OpenedForWriting = false;
            }
        }

        /// <summary>
        ///     Get stream for writing and playing audio in custom format.
        /// </summary>
        /// <param name="format">Custom audio format</param>
        /// <param name="arguments">Custom FFmpeg arguments for the specified audio format</param>
        /// <param name="showFFplayOutput">Show FFplay output for debugging purposes.</param>
        public static Stream GetStreamForWriting(string format, string arguments, out Process ffplayProcess,
            bool showFFplayOutput = false, string ffplayExecutable = "ffplay")
        {
            Stream str = FfMpegWrapper.OpenInput(ffplayExecutable, $"-f {format} {arguments} -i -",
                out ffplayProcess, showFFplayOutput);

            return str;
        }
    }
}