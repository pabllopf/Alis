

using System;
using System.IO;
using System.Threading.Tasks;

namespace Alis.Extension.Media.FFmpeg.BaseClasses
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