using System;
using System.IO;

namespace Alis.Extension.FFMeg.BaseClasses
{
    /// <summary>
    /// The media frame interface
    /// </summary>
    public interface IMediaFrame
    {
        /// <summary>
        /// Contains raw frame data
        /// </summary>
        public Memory<byte> RawData { get; }

        /// <summary>
        /// Loads raw data into memory
        /// </summary>
        /// <param name="stream">Stream containing raw data</param>
        public bool Load(Stream stream);
    }
}
