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
        /// <param name="devicename">The devicename</param>
        /// <returns>The int ptr</returns>
        [DllImport("openal32", EntryPoint = "alcOpenDevice")]
        public static extern IntPtr alcOpenDevice(string devicename);

        /// <summary>
        ///     Alcs the create context using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="attrlist">The attrlist</param>
        /// <returns>The int ptr</returns>
        [DllImport("openal32", EntryPoint = "alcCreateContext")]
        public static extern IntPtr alcCreateContext(IntPtr device, IntPtr attrlist);

        /// <summary>
        ///     Alcs the make context current using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The bool</returns>
        [DllImport("openal32", EntryPoint = "alcMakeContextCurrent")]
        public static extern bool alcMakeContextCurrent(IntPtr context);

        /// <summary>
        ///     Alcs the close device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <returns>The bool</returns>
        [DllImport("openal32", EntryPoint = "alcCloseDevice")]
        public static extern bool alcCloseDevice(IntPtr device);

        // Source management
        /// <summary>
        ///     Als the gen sources using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="sources">The sources</param>
        [DllImport("openal32", EntryPoint = "alGenSources")]
        public static extern void alGenSources(int n, out uint sources);

        /// <summary>
        ///     Als the delete sources using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="sources">The sources</param>
        [DllImport("openal32", EntryPoint = "alDeleteSources")]
        public static extern void alDeleteSources(int n, ref uint sources);

        /// <summary>
        ///     Als the source play using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        [DllImport("openal32", EntryPoint = "alSourcePlay")]
        public static extern void alSourcePlay(uint source);

        /// <summary>
        ///     Als the source stop using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        [DllImport("openal32", EntryPoint = "alSourceStop")]
        public static extern void alSourceStop(uint source);

        // Buffer management
        /// <summary>
        ///     Als the gen buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        [DllImport("openal32", EntryPoint = "alGenBuffers")]
        public static extern void alGenBuffers(int n, out uint buffers);

        /// <summary>
        ///     Als the delete buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        [DllImport("openal32", EntryPoint = "alDeleteBuffers")]
        public static extern void alDeleteBuffers(int n, ref uint buffers);

        /// <summary>
        ///     Als the buffer data using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <param name="freq">The freq</param>
        [DllImport("openal32", EntryPoint = "alBufferData")]
        public static extern void alBufferData(uint buffer, int format, IntPtr data, int size, int freq);

        /// <summary>
        ///     Als the sourcei using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="value">The value</param>
        [DllImport("openal32", EntryPoint = "alSourcei")]
        public static extern void alSourcei(uint source, int param, int value);

        /// <summary>
        ///     Als the source queue buffers using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="nb">The nb</param>
        /// <param name="buffers">The buffers</param>
        [DllImport("openal32", EntryPoint = "alSourceQueueBuffers")]
        public static extern void alSourceQueueBuffers(uint source, int nb, ref uint buffers);
    }
}