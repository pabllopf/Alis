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
using Alis.Core.Extension.FFMeg.BaseClasses;

namespace Alis.Core.Extension.FFMeg.Video
{
    /// <summary>
    ///     Video frame containing pixel data in RGB24 format.
    /// </summary>
    public class VideoFrame : IDisposable, IMediaFrame
    {
        /// <summary>
        ///     The frame buffer
        /// </summary>
        private byte[] frameBuffer;

        /// <summary>
        ///     The offset
        /// </summary>
        private readonly int size;

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
            if (w <= 0 || h <= 0) throw new InvalidDataException("Video frame dimensions have to be bigger than 0 pixels!");

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
                    if (offset == 0) return false;
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
        ///     Saves the output
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="encoder">The encoder</param>
        /// <param name="extraParameters">The extra parameters</param>
        /// <param name="ffmpegExecutable">The ffmpeg executable</param>
        public void Save(string output, string encoder = "png", string extraParameters = "",
            string ffmpegExecutable = "ffmpeg")
        {
            if (File.Exists(output)) File.Delete(output);

            using (Stream inp = FfMpegWrapper.OpenInput(ffmpegExecutable,
                       $"-f rawvideo -video_size {Width}:{Height} -pixel_format rgb24 -i - " +
                       $"-c:v {encoder} {extraParameters} -f image2pipe \"{output}\"",
                       out _))
            {
                // save it
                Console.WriteLine("Saving frame...");
                byte[] data = RawData;
                Console.WriteLine($"Writing Length {data.Length} bytes to ffmpeg...");
                inp.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        ///     Gets the pixels using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="length">The length</param>
        /// <returns>The pixels</returns>
        public byte[] GetPixels(int x, int y, int length = 1)
        {
            int index = (x + y * Width) * 3;
            byte[] pixels = new byte[length * 3];
            Array.Copy(RawData, index, pixels, 0, length * 3);
            return pixels;
        }
    }
}