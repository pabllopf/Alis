

using System.IO;

namespace Alis.Core.Physic.Common
{
/// <summary>
///     Provides a buffered reader for efficiently reading characters from a stream.
///     This class reads the entire stream content into memory and allows sequential
///     access to characters with position tracking. It's designed for parsing text
///     content where you need to read character by character while keeping track
///     of the current position.
/// </summary>
    internal class FileBuffer
    {
/// <summary>
///     Initializes a new instance of the <see cref="FileBuffer"/> class.
///     Reads the entire content of the provided stream into an internal buffer
///     for efficient character-by-character access.
/// </summary>
/// <param name="stream">The input stream to read from. The stream's content
///     will be read completely during initialization.</param>
        public FileBuffer(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                Buffer = sr.ReadToEnd();
            }

            Position = 0;
        }

/// <summary>
///     Gets or sets the internal buffer containing the entire content of the stream.
///     This string holds all the data read from the stream during initialization.
/// </summary>
        public string Buffer { get; set; }

        /// <summary>
        ///     Gets or sets the value of the position
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        ///     Gets the value of the length
        /// </summary>
        internal int Length => Buffer.Length;

        /// <summary>
        ///     Gets the value of the next
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
        ///     Gets the value of the end of buffer
        /// </summary>
        public bool EndOfBuffer => Position == Length;
    }
}