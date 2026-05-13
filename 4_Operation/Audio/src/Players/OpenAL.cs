// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OpenAL.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     Provides P/Invoke declarations for the OpenAL 32-bit audio library (openal32).
    ///     Encapsulates device, context, source, and buffer management functions used for cross-platform audio playback.
    /// </summary>
    internal static class OpenAl
    {
        // Device management
        /// <summary>
        ///     Opens an OpenAL audio device for playback.
        /// </summary>
        /// <param name="devicename">The name of the device to open, or <c>null</c> to open the default device.</param>
        /// <returns>A pointer to the opened device, or <see cref="IntPtr.Zero" /> if the device could not be opened.</returns>
        [DllImport("openal32", EntryPoint = "alcOpenDevice"), ExcludeFromCodeCoverage]
        public static extern IntPtr alcOpenDevice(string devicename);

        /// <summary>
        ///     Creates an OpenAL audio context on the specified device.
        /// </summary>
        /// <param name="device">A pointer to the previously opened audio device.</param>
        /// <param name="attrlist">A pointer to a list of context attributes, or <see cref="IntPtr.Zero" /> for default attributes.</param>
        /// <returns>A pointer to the created context, or <see cref="IntPtr.Zero" /> if creation failed.</returns>
        [DllImport("openal32", EntryPoint = "alcCreateContext"), ExcludeFromCodeCoverage]
        public static extern IntPtr alcCreateContext(IntPtr device, IntPtr attrlist);

        /// <summary>
        ///     Makes the specified OpenAL context the current (active) context for the calling thread.
        /// </summary>
        /// <param name="context">A pointer to the context to make current.</param>
        /// <returns><c>true</c> if the context was successfully made current; otherwise, <c>false</c>.</returns>
        [DllImport("openal32", EntryPoint = "alcMakeContextCurrent"), ExcludeFromCodeCoverage]
        public static extern bool alcMakeContextCurrent(IntPtr context);

        /// <summary>
        ///     Closes an OpenAL audio device that was previously opened with <see cref="alcOpenDevice" />.
        /// </summary>
        /// <param name="device">A pointer to the device to close.</param>
        /// <returns><c>true</c> if the device was successfully closed; otherwise, <c>false</c>.</returns>
        [DllImport("openal32", EntryPoint = "alcCloseDevice"), ExcludeFromCodeCoverage]
        public static extern bool alcCloseDevice(IntPtr device);

        // Source management
        /// <summary>
        ///     Generates one or more OpenAL source names.
        /// </summary>
        /// <param name="n">The number of sources to generate.</param>
        /// <param name="sources">When this method returns, contains the generated source name.</param>
        [DllImport("openal32", EntryPoint = "alGenSources"), ExcludeFromCodeCoverage]
        public static extern void alGenSources(int n, out uint sources);

        /// <summary>
        ///     Deletes one or more OpenAL sources.
        /// </summary>
        /// <param name="n">The number of sources to delete.</param>
        /// <param name="sources">A reference to the source name(s) to delete.</param>
        [DllImport("openal32", EntryPoint = "alDeleteSources"), ExcludeFromCodeCoverage]
        public static extern void alDeleteSources(int n, ref uint sources);

        /// <summary>
        ///     Starts playback on the specified OpenAL source.
        /// </summary>
        /// <param name="source">The source name to start playing.</param>
        [DllImport("openal32", EntryPoint = "alSourcePlay"), ExcludeFromCodeCoverage]
        public static extern void alSourcePlay(uint source);

        /// <summary>
        ///     Stops playback on the specified OpenAL source.
        /// </summary>
        /// <param name="source">The source name to stop.</param>
        [DllImport("openal32", EntryPoint = "alSourceStop"), ExcludeFromCodeCoverage]
        public static extern void alSourceStop(uint source);

        // Buffer management
        /// <summary>
        ///     Generates one or more OpenAL buffer names.
        /// </summary>
        /// <param name="n">The number of buffers to generate.</param>
        /// <param name="buffers">When this method returns, contains the generated buffer name.</param>
        [DllImport("openal32", EntryPoint = "alGenBuffers"), ExcludeFromCodeCoverage]
        public static extern void alGenBuffers(int n, out uint buffers);

        /// <summary>
        ///     Deletes one or more OpenAL buffers.
        /// </summary>
        /// <param name="n">The number of buffers to delete.</param>
        /// <param name="buffers">A reference to the buffer name(s) to delete.</param>
        [DllImport("openal32", EntryPoint = "alDeleteBuffers"), ExcludeFromCodeCoverage]
        public static extern void alDeleteBuffers(int n, ref uint buffers);

        /// <summary>
        ///     Fills an OpenAL buffer with audio data in the specified format.
        /// </summary>
        /// <param name="buffer">The buffer name to fill.</param>
        /// <param name="format">The OpenAL audio format (e.g., AL_FORMAT_MONO16 or AL_FORMAT_STEREO16).</param>
        /// <param name="data">A pointer to the raw PCM audio data.</param>
        /// <param name="size">The size of the audio data in bytes.</param>
        /// <param name="freq">The sample frequency of the audio data in Hertz.</param>
        [DllImport("openal32", EntryPoint = "alBufferData"), ExcludeFromCodeCoverage]
        public static extern void alBufferData(uint buffer, int format, IntPtr data, int size, int freq);

        /// <summary>
        ///     Sets an integer property on the specified OpenAL source.
        /// </summary>
        /// <param name="source">The source name to configure.</param>
        /// <param name="param">The parameter identifier to set.</param>
        /// <param name="value">The integer value to assign to the parameter.</param>
        [DllImport("openal32", EntryPoint = "alSourcei"), ExcludeFromCodeCoverage]
        public static extern void alSourcei(uint source, int param, int value);

        /// <summary>
        ///     Queues one or more buffers on the specified OpenAL source for sequential playback.
        /// </summary>
        /// <param name="source">The source name to queue buffers on.</param>
        /// <param name="nb">The number of buffers to queue.</param>
        /// <param name="buffers">A reference to the buffer name(s) to queue.</param>
        [DllImport("openal32", EntryPoint = "alSourceQueueBuffers"), ExcludeFromCodeCoverage]
        public static extern void alSourceQueueBuffers(uint source, int nb, ref uint buffers);
    }
}
