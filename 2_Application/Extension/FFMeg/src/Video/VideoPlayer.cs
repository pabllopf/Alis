// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoPlayer.cs
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
using Alis.Extension.FFMeg.BaseClasses;

namespace Alis.Extension.FFMeg.Video
{
    /// <summary>
    ///     The video player class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class VideoPlayer : MediaWriter<VideoFrame>, IDisposable
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
        ///     Used for playing video data
        /// </summary>
        /// <param name="input">Input video to play (can be left empty if planning on playing frames directly)</param>
        /// <param name="ffplayExecutable">Name or path to the ffplay executable</param>
        public VideoPlayer(string input = null, string ffplayExecutable = "ffplay")
        {
            ffplay = ffplayExecutable;

            Filename = input;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (OpenedForWriting) CloseWrite();
            else
            {
                try
                {
                    if ((ffplayp != null) && !ffplayp.HasExited) ffplayp.Kill();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///     Play video
        /// </summary>
        /// <param name="extraInputParameters">Extra FFmpeg input parameters to be passed</param>
        public void Play(string extraInputParameters = "")
        {
            if (OpenedForWriting) throw new InvalidOperationException("Player is already opened for writing frames!");
            if (string.IsNullOrEmpty(Filename)) throw new InvalidOperationException("No filename was specified!");

            FfMpegWrapper.RunCommand(ffplay, $"{extraInputParameters} -i \"{Filename}\"");
        }

        /// <summary>
        ///     Play video in background and return the process associated with it
        /// </summary>
        /// <param name="runPureBackground">Detach the player from this VideoPlayer control. Player won't be killed on disposing.</param>
        /// <param name="extraInputParameters">Extra FFmpeg input parameters to be passed</param>
        public Process PlayInBackground(bool runPureBackground = false, string extraInputParameters = "")
        {
            if (!runPureBackground && OpenedForWriting) throw new InvalidOperationException("Player is already opened for writing frames!");
            if (string.IsNullOrEmpty(Filename)) throw new InvalidOperationException("No filename was specified!");

            FfMpegWrapper.OpenOutput(ffplay, $"{extraInputParameters} -i \"{Filename}\"", out Process p);
            if (!runPureBackground) ffplayp = p;
            return ffplayp;
        }

        /// <summary>
        ///     Open player for writing frames for playing.
        /// </summary>
        /// <param name="width">Video frame width</param>
        /// <param name="height">Video frame height</param>
        /// <param name="framerateFrequency">Video framerate (frequency form)</param>
        /// <param name="extraInputParameters">Extra FFmpeg input parameters to be passed</param>
        /// <param name="showFFplayOutput">Show FFplay output for debugging purposes.</param>
        public void OpenWrite(int width, int height, string framerateFrequency,
            string extraInputParameters = "", bool showFFplayOutput = false)
        {
            if (OpenedForWriting) throw new InvalidOperationException("Player is already opened for writing frames!");
            try
            {
                if ((ffplayp != null) && !ffplayp.HasExited) ffplayp.Kill();
            }
            catch
            {
            }

            InputDataStream = FfMpegWrapper.OpenInput(ffplay, $"-f rawvideo -video_size {width}:{height} -framerate {framerateFrequency} -pixel_format rgb24 -i -",
                out ffplayp, showFFplayOutput);

            OpenedForWriting = true;
        }

        /// <summary>
        ///     Close player for writing frames.
        /// </summary>
        public void CloseWrite()
        {
            if (!OpenedForWriting) throw new InvalidOperationException("Player is not opened for writing frames!");

            try
            {
                try
                {
                    if (!ffplayp.HasExited) ffplayp.Kill();
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
        ///     Get stream for writing and playing video in custom format.
        /// </summary>
        /// <param name="format">Custom video format</param>
        /// <param name="arguments">Custom FFmpeg arguments for the specified video format</param>
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