

using System.IO;

namespace Alis.Extension.Media.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media frame interface
    /// </summary>
    public interface IMediaFrame
    {
        /// <summary>
        ///     Contains raw frame data
        /// </summary>
        byte[] RawData { get; }

        /// <summary>
        ///     Loads raw data into memory
        /// </summary>
        /// <param name="stream">Stream containing raw data</param>
        bool Load(Stream stream);
    }
}