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
    ///     The open al class
    /// </summary>
    internal static class OpenAl
    {
        // Device management
        /// <summary>
        ///     Alcs the open device using the specified devicename
        /// </summary>
        /// <param name="devicename">The name of the device to open, or null for the default device.</param>
        /// <returns>A handle to the opened device, or IntPtr.Zero if the device could not be opened.</returns>
        [DllImport("openal32", EntryPoint = "alcOpenDevice"), ExcludeFromCodeCoverage]
        public static extern IntPtr alcOpenDevice(string devicename);

        /// <summary>
        ///     Alcs the create context using the specified device
        /// </summary>
        /// <param name="device">The handle to the OpenAL device.</param>
        /// <param name="attrlist">A pointer to the attribute list, or IntPtr.Zero for default attributes.</param>
        /// <returns>A handle to the created context, or IntPtr.Zero if the context could not be created.</returns>
        [DllImport("openal32", EntryPoint = "alcCreateContext"), ExcludeFromCodeCoverage]
        public static extern IntPtr alcCreateContext(IntPtr device, IntPtr attrlist);

        /// <summary>
        ///     Alcs the make context current using the specified context
        /// </summary>
        /// <param name="context">The handle to the context to make current.</param>
        /// <returns>True if the context was successfully made current; otherwise false.</returns>
        [DllImport("openal32", EntryPoint = "alcMakeContextCurrent"), ExcludeFromCodeCoverage]
        public static extern bool alcMakeContextCurrent(IntPtr context);

        /// <summary>
        ///     Alcs the close device using the specified device
        /// </summary>
        /// <param name="device">The handle to the device to close.</param>
        /// <returns>True if the device was successfully closed; otherwise false.</returns>
        [DllImport("openal32", EntryPoint = "alcCloseDevice"), ExcludeFromCodeCoverage]
        public static extern bool alcCloseDevice(IntPtr device);

        // Source management
        /// <summary>
        ///     Als the gen sources using the specified n
        /// </summary>
        /// <param name="n">The number of sources to generate.</param>
        /// <param name="sources">The generated source handles.</param>
        [DllImport("openal32", EntryPoint = "alGenSources"), ExcludeFromCodeCoverage]
        public static extern void alGenSources(int n, out uint sources);

        /// <summary>
        ///     Als the delete sources using the specified n
        /// </summary>
        /// <param name="n">The number of sources to delete.</param>
        /// <param name="sources">A reference to the source handles to delete.</param>
        [DllImport("openal32", EntryPoint = "alDeleteSources"), ExcludeFromCodeCoverage]
        public static extern void alDeleteSources(int n, ref uint sources);

        /// <summary>
        ///     Als the source play using the specified source
        /// </summary>
        /// <param name="source">The handle of the source to play.</param>
        [DllImport("openal32", EntryPoint = "alSourcePlay"), ExcludeFromCodeCoverage]
        public static extern void alSourcePlay(uint source);

        /// <summary>
        ///     Als the source stop using the specified source
        /// </summary>
        /// <param name="source">The handle of the source to stop.</param>
        [DllImport("openal32", EntryPoint = "alSourceStop"), ExcludeFromCodeCoverage]
        public static extern void alSourceStop(uint source);

        // Buffer management
        /// <summary>
        ///     Als the gen buffers using the specified n
        /// </summary>
        /// <param name="n">The number of buffers to generate.</param>
        /// <param name="buffers">The generated buffer handles.</param>
        [DllImport("openal32", EntryPoint = "alGenBuffers"), ExcludeFromCodeCoverage]
        public static extern void alGenBuffers(int n, out uint buffers);

        /// <summary>
        ///     Als the delete buffers using the specified n
        /// </summary>
        /// <param name="n">The number of buffers to delete.</param>
        /// <param name="buffers">A reference to the buffer handles to delete.</param>
        [DllImport("openal32", EntryPoint = "alDeleteBuffers"), ExcludeFromCodeCoverage]
        public static extern void alDeleteBuffers(int n, ref uint buffers);

        /// <summary>
        ///     Als the buffer data using the specified buffer
        /// </summary>
        /// <param name="buffer">The handle of the buffer to fill.</param>
        /// <param name="format">The OpenAL format (e.g. AL_FORMAT_MONO16).</param>
        /// <param name="data">A pointer to the audio data.</param>
        /// <param name="size">The size of the audio data in bytes.</param>
        /// <param name="freq">The frequency (sample rate) of the audio data.</param>
        [DllImport("openal32", EntryPoint = "alBufferData"), ExcludeFromCodeCoverage]
        public static extern void alBufferData(uint buffer, int format, IntPtr data, int size, int freq);

        /// <summary>
        ///     Als the sourcei using the specified source
        /// </summary>
        /// <param name="source">The handle of the source to configure.</param>
        /// <param name="param">The parameter identifier to set.</param>
        /// <param name="value">The integer value to assign to the parameter.</param>
        [DllImport("openal32", EntryPoint = "alSourcei"), ExcludeFromCodeCoverage]
        public static extern void alSourcei(uint source, int param, int value);

        /// <summary>
        ///     Als the source queue buffers using the specified source
        /// </summary>
        /// <param name="source">The handle of the source to queue buffers on.</param>
        /// <param name="nb">The number of buffers to queue.</param>
        /// <param name="buffers">A reference to the buffer handles to queue.</param>
        [DllImport("openal32", EntryPoint = "alSourceQueueBuffers"), ExcludeFromCodeCoverage]
        public static extern void alSourceQueueBuffers(uint source, int nb, ref uint buffers);
    }
}