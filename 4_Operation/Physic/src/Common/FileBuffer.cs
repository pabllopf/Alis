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
    ///     Provides a simple text buffer reader that reads all content from a <see cref="Stream"/>
    ///     and provides sequential character access with position tracking.
    ///     Used for parsing textual physics data (e.g., polygon definitions from files).
    /// </summary>
    internal class FileBuffer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FileBuffer" /> class by reading the entire stream content into a string buffer.
        /// </summary>
        /// <param name="stream">The input stream containing text data to read (e.g., polygon vertex definitions).</param>
        public FileBuffer(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                Buffer = sr.ReadToEnd();
            }

            Position = 0;
        }

        /// <summary>
        ///     Gets or sets the value of the buffer
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