using System.IO;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    /// The file buffer class
    /// </summary>
    internal class FileBuffer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileBuffer"/> class
        /// </summary>
        /// <param name="stream">The stream</param>
        public FileBuffer(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
                Buffer = sr.ReadToEnd();

            Position = 0;
        }

        /// <summary>
        /// Gets or sets the value of the buffer
        /// </summary>
        public string Buffer { get; set; }

        /// <summary>
        /// Gets or sets the value of the position
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets the value of the length
        /// </summary>
        private int Length => Buffer.Length;

        /// <summary>
        /// Gets the value of the next
        /// </summary>
        public char Next
        {
            get
            {
                char c = Buffer[Position];
                Position++;
                return c;
            }
        }

        /// <summary>
        /// Gets the value of the end of buffer
        /// </summary>
        public bool EndOfBuffer => Position == Length;
    }
}