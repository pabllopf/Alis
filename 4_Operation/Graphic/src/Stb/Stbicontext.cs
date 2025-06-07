// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Stbicontext.cs
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
        ///     The temp buffer
        /// </summary>
        public byte[] TempBuffer;

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