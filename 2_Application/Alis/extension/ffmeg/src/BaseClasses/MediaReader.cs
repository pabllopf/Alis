using System;
using System.IO;
using System.Threading.Tasks;

namespace Alis.Extension.FFMeg.BaseClasses
{
    /// <summary>
    /// The media reader class
    /// </summary>
    public abstract class MediaReader<Frame, Writer> where Frame : IMediaFrame where Writer : MediaWriter<Frame>
    {        
        /// <summary>
        /// Input filename
        /// </summary>
        public virtual string Filename { get; protected set; }

        /// <summary>
        /// Input raw data stream
        /// </summary>
        public virtual Stream DataStream { get; protected set; }

        /// <summary>
        /// Is data stream opened for reading
        /// </summary>
        public virtual bool OpenedForReading { get; protected set; }

        /// <summary>
        /// Nexts the frame
        /// </summary>
        /// <returns>The frame</returns>
        public abstract Frame NextFrame();
        /// <summary>
        /// Nexts the frame using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <returns>The frame</returns>
        public abstract Frame NextFrame(Frame frame);

        /// <summary>
        /// Copy data directly to writer
        /// </summary>
        /// <param name="writer">Writer that is opened for writing</param>
        public virtual void CopyTo(MediaWriter<Frame> writer)
    {
        if (DataStream == null) throw new InvalidOperationException("Reader is not opened for reading! Have you called Load()?");
        if (!writer.OpenedForWriting) throw new InvalidOperationException("Writer is not opened for writing!");

        DataStream.CopyTo(writer.InputDataStream);
    }

        /// <summary>
        /// Copy data directly to writer
        /// </summary>
        /// <param name="writer">Writer that is opened for writing</param>
        public virtual async Task CopyToAsync(MediaWriter<Frame> writer)
    {
        if (DataStream == null) throw new InvalidOperationException("Reader is not opened for reading! Have you called Load()?");
        if (!writer.OpenedForWriting) throw new InvalidOperationException("Writer is not opened for writing!");          

        await DataStream.CopyToAsync(writer.InputDataStream);
    }
    }
}
