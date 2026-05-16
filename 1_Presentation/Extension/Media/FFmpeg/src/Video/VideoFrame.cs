// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFrame.cs
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
using System.IO;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     Video frame containing pixel data in RGB24 format.
    /// </summary>
    public class VideoFrame : IDisposable, IMediaFrame
    {
        /// <summary>
        ///     The offset
        /// </summary>
        private readonly int size;

        /// <summary>
        ///     The frame buffer
        /// </summary>
        private byte[] frameBuffer;

        /// <summary>
        ///     The offset
        /// </summary>
        private int offset;

        /// <summary>
        ///     Creates an empty video frame with given dimensions using the RGB24 pixel format.
        /// </summary>
        /// <param name="w">Width in pixels</param>
        /// <param name="h">Height in pixels</param>
        public VideoFrame(int w, int h)
        {
            if (w <= 0 || h <= 0)
            {
                throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");
            }

            Width = w;
            Height = h;

            size = Width * Height * 3;
            frameBuffer = new byte[size];
            RawData = frameBuffer;
        }

        /// <summary>
        ///     Video width in pixels
        /// </summary>
        public int Width { get; }

        /// <summary>
        ///     Video height in pixels
        /// </summary>
        public int Height { get; }

        /// <summary>
        ///     Clears the frame buffer
        /// </summary>
        public void Dispose()
        {
            frameBuffer = null;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Raw video data in RGB24 pixel format
        /// </summary>
        public byte[] RawData { get; private set; }

        /// <summary>
        ///     Loads frame data from stream.
        /// </summary>
        /// <param name="str">Stream containing raw frame data in RGB24 format</param>
        public bool Load(Stream str)
        {
            offset = 0;

            while (offset < size)
            {
                int r = str.Read(frameBuffer, offset, size - offset);
                if (r <= 0)
                {
                    if (offset == 0)
                    {
                        return false;
                    }

                    break;
                }

                offset += r;
            }

            // Adjust RawData length when changed
            if (RawData.Length != offset)
            {
                byte[] newRawData = new byte[offset];
                Array.Copy(frameBuffer, 0, newRawData, 0, offset);
                RawData = newRawData;
            }

            return true;
        }

        /// <summary>
        ///     Saves the current frame as an image file using the specified encoder.
        /// </summary>
        /// <param name="output">Output file path for the saved image.</param>
        /// <param name="encoder">FFmpeg encoder to use (default: png).</param>
        /// <param name="extraParameters">Extra FFmpeg encoder parameters.</param>
        /// <param name="ffmpegExecutable">Name or path to the ffmpeg executable.</param>
        public void Save(string output, string encoder = "png", string extraParameters = "",
            string ffmpegExecutable = "ffmpeg")
        {
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            using (Stream inp = FfMpegWrapper.OpenInput(ffmpegExecutable,
                       $"-f rawvideo -video_size {Width}:{Height} -pixel_format rgb24 -i - " +
                       $"-c:v {encoder} {extraParameters} -f image2pipe \"{output}\"",
                       out _))
            {
                // save it
                Logger.Info("Saving frame...");
                byte[] data = RawData;
                Logger.Info($"Writing Length {data.Length} bytes to ffmpeg...");
                inp.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        ///     Gets a contiguous block of pixel data starting at the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the starting pixel.</param>
        /// <param name="y">The y-coordinate of the starting pixel.</param>
        /// <param name="length">Number of pixels to retrieve from the starting position.</param>
        /// <returns>A byte array containing RGB pixel data for the requested pixels.</returns>
        public byte[] GetPixels(int x, int y, int length = 1)
        {
            int index = (x + y * Width) * 3;
            byte[] pixels = new byte[length * 3];
            Array.Copy(RawData, index, pixels, 0, length * 3);
            return pixels;
        }
    }
}