// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaReader.cs
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
using System.Threading.Tasks;

namespace Alis.Extension.Multimedia.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media reader class
    /// </summary>
    public abstract class MediaReader<TFrame, TWriter> where TFrame : IMediaFrame where TWriter : MediaWriter<TFrame>
    {
        /// <summary>
        ///     Input filename
        /// </summary>
        public virtual string Filename { get; protected set; }

        /// <summary>
        ///     Input raw data stream
        /// </summary>
        public virtual Stream DataStream { get; protected set; }

        /// <summary>
        ///     Is data stream opened for reading
        /// </summary>
        public virtual bool OpenedForReading { get; protected set; }

        /// <summary>
        ///     Nexts the frame
        /// </summary>
        /// <returns>The frame</returns>
        public abstract TFrame NextFrame();

        /// <summary>
        ///     Nexts the frame using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <returns>The frame</returns>
        public abstract TFrame NextFrame(TFrame frame);

        /// <summary>
        ///     Copy data directly to writer
        /// </summary>
        /// <param name="writer">Writer that is opened for writing</param>
        public virtual void CopyTo(MediaWriter<TFrame> writer)
        {
            if (DataStream == null)
            {
                throw new InvalidOperationException("Reader is not opened for reading! Have you called Load()?");
            }

            if (!writer.OpenedForWriting)
            {
                throw new InvalidOperationException("Writer is not opened for writing!");
            }

            DataStream.CopyTo(writer.InputDataStream);
        }

        /// <summary>
        ///     Copy data directly to writer
        /// </summary>
        /// <param name="writer">Writer that is opened for writing</param>
        public virtual async Task CopyToAsync(MediaWriter<TFrame> writer)
        {
            if (DataStream == null)
            {
                throw new InvalidOperationException("Reader is not opened for reading! Have you called Load()?");
            }

            if (!writer.OpenedForWriting)
            {
                throw new InvalidOperationException("Writer is not opened for writing!");
            }

            await DataStream.CopyToAsync(writer.InputDataStream);
        }
    }
}