// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EXTDouble.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Alis.Core.Audio2D.Extensions.EXT.Double.Enums;
using Alis.Core.Audio2D.Native;

namespace Alis.Core.Audio2D.Extensions.EXT.Double
{
    /// <summary>
    ///     The ext double class
    /// </summary>
    /// <seealso cref="ALBase" />
    public class EXTDouble : ALBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EXTDouble" /> class
        /// </summary>
        static EXTDouble()
        {
            // We need to register the resolver for OpenAL before we can DllImport functions.
            RegisterOpenALResolver();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EXTDouble" /> class
        /// </summary>
        private EXTDouble()
        {
        }

        /// <summary>
        ///     The name of this AL extension.
        /// </summary>
        public const string ExtensionName = "AL_EXT_double";

        /// <summary>
        ///     Checks if this extension is present.
        /// </summary>
        /// <returns>Whether the extension was present or not.</returns>
        public static bool IsExtensionPresent() => AL.IsExtensionPresent(ExtensionName);

        /// <summary>
        ///     This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function
        ///     may be used by extensions to load other buffer types as well.
        /// </summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: DoubleBufferFormat.Mono, DoubleBufferFormat.Stereo.</param>
        /// <param name="buffer">Pointer to a pinned audio buffer.</param>
        /// <param name="bytes">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        [DllImport(AL.Lib, EntryPoint = "alBufferData", ExactSpelling = true,
            CallingConvention = AL.ALCallingConvention)]
        public static extern unsafe void BufferData(int bid, DoubleBufferFormat format, double* buffer, int bytes,
            int freq);
        // AL_API void AL_APIENTRY alBufferData( ALuint bid, ALenum format, const ALvoid* buffer, ALsizei size, ALsizei freq );

        /// <summary>
        ///     This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function
        ///     may be used by extensions to load other buffer types as well.
        /// </summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: DoubleBufferFormat.Mono, DoubleBufferFormat.Stereo.</param>
        /// <param name="buffer">Pointer to a pinned audio buffer.</param>
        /// <param name="bytes">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        [DllImport(AL.Lib, EntryPoint = "alBufferData", ExactSpelling = true,
            CallingConvention = AL.ALCallingConvention)]
        public static extern void BufferData(int bid, DoubleBufferFormat format, ref double buffer, int bytes,
            int freq);
        // AL_API void AL_APIENTRY alBufferData( ALuint bid, ALenum format, const ALvoid* buffer, ALsizei size, ALsizei freq );

        /// <summary>
        ///     This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function
        ///     may be used by extensions to load other buffer types as well.
        /// </summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: DoubleBufferFormat.Mono, DoubleBufferFormat.Stereo.</param>
        /// <param name="buffer">The audio buffer.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        /// FIXME: Should "size" be changed to "elements"?
        public static void BufferData(int bid, DoubleBufferFormat format, double[] buffer, int freq)
        {
            BufferData(bid, format, ref buffer[0], buffer.Length * sizeof(double), freq);
        }

        /// <summary>
        ///     This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function
        ///     may be used by extensions to load other buffer types as well.
        /// </summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: DoubleBufferFormat.Mono, DoubleBufferFormat.Stereo.</param>
        /// <param name="buffer">Span representing the audio buffer.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        public static void BufferData(int bid, DoubleBufferFormat format, Span<double> buffer, int freq)
        {
            BufferData(bid, format, ref buffer[0], buffer.Length * sizeof(double), freq);
        }
    }
}