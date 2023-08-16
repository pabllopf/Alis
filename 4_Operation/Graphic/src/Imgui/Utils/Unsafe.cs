// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Unsafe.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.ImGui.Attributes;

namespace Alis.Core.Graphic.ImGui.Utils
{
    /// <summary>Contains generic, low-level functionality for manipulating pointers.</summary>
    public class Unsafe
    {
        /// <summary>Reads a value of type <typeparamref name="T" /> from the given location.</summary>
        /// <param name="source">The location to read from.</param>
        /// <typeparam name="T">The type to read.</typeparam>
        /// <returns>An object of type <typeparamref name="T" /> read from the given location.</returns>
        [NonVersionable, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T Read<T>(void* source) where T : unmanaged => *(T*) source;

        /// <summary>
        ///     Sizes the of
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The int</returns>
        public static int SizeOf<T>() => Marshal.SizeOf<T>();

        /// <summary>
        ///     Converts the ref using the specified source
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="source">The source</param>
        /// <returns>The ref</returns>
        public static unsafe ref T AsRef<T>(void* source) where T : unmanaged
        {
            T* typedPointer = (T*) source;

            return ref *typedPointer;
        }

        /// <summary>Copies bytes from the source address to the destination address.</summary>
        /// <param name="destination">The destination address to copy to.</param>
        /// <param name="source">The source address to copy from.</param>
        /// <param name="byteCount">The number of bytes to copy.</param>
        [NonVersionable, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void CopyBlock(void* destination, void* source, uint byteCount)
        {
            Buffer.MemoryCopy(source, destination, byteCount, byteCount);
        }

        /// <summary>
        ///     Initializes a block of memory at the given location with a given initial value without assuming architecture
        ///     dependent alignment of the address.
        /// </summary>
        /// <param name="startAddress">The address of the start of the memory block to initialize.</param>
        /// <param name="value">The value to initialize the block to.</param>
        /// <param name="byteCount">The number of bytes to initialize.</param>
        [NonVersionable, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void InitBlockUnaligned(void* startAddress, byte value, uint byteCount)
        {
            byte[] block = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                block[i] = value;
            }

            IntPtr ptr = new IntPtr(startAddress);
            Marshal.Copy(block, 0, ptr, (int) byteCount);
        }
    }
}