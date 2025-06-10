using System;
using System.IO;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi context class
    /// </summary>
    public class Stbicontext
    {
        /// <summary>
        ///     The stream
        /// </summary>
        private readonly Stream stream;

        /// <summary>
        ///     The temp buffer
        /// </summary>
        public byte[] TempBuffer;

        /// <summary>
        ///     The img
        /// </summary>
        public int Imgn = 0;

        /// <summary>
        ///     The img out
        /// </summary>
        public int Imgoutn = 0;

        /// <summary>
        ///     The img
        /// </summary>
        public uint Imgx = 0;

        /// <summary>
        ///     The img
        /// </summary>
        public uint Imgy = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Stbicontext" /> class
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <exception cref="ArgumentNullException">stream</exception>
        public Stbicontext(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.stream = stream;
        }

        /// <summary>
        ///     Gets the value of the stream
        /// </summary>
        public Stream Stream => stream;
    }
}