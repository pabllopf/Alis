// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileBuffer.cs
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