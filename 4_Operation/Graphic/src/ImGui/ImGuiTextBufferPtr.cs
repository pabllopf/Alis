// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextBufferPtr.cs
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
using System.Text;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui text buffer ptr
    /// </summary>
    public unsafe struct ImGuiTextBufferPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiTextBuffer* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTextBufferPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTextBufferPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextBufferPtr(IntPtr nativePtr) => NativePtr = (ImGuiTextBuffer*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr) => new ImGuiTextBufferPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextBuffer*(ImGuiTextBufferPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextBufferPtr(IntPtr nativePtr) => new ImGuiTextBufferPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the buf
        /// </summary>
        public ImVector<byte> Buf => new ImVector<byte>(NativePtr->Buf);

        /// <summary>
        ///     Appends the str
        /// </summary>
        /// <param name="str">The str</param>
        public void append(string str)
        {
            byte* native_str;
            int str_byteCount = 0;
            if (str != null)
            {
                str_byteCount = Encoding.UTF8.GetByteCount(str);
                if (str_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_str = Util.Allocate(str_byteCount + 1);
                }
                else
                {
                    byte* native_str_stackBytes = stackalloc byte[str_byteCount + 1];
                    native_str = native_str_stackBytes;
                }

                int native_str_offset = Util.GetUtf8(str, native_str, str_byteCount);
                native_str[native_str_offset] = 0;
            }
            else
            {
                native_str = null;
            }

            byte* native_str_end = null;
            ImGuiNative.ImGuiTextBuffer_append(NativePtr, native_str, native_str_end);
            if (str_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_str);
            }
        }

        /// <summary>
        ///     Appendfs the fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public void appendf(string fmt)
        {
            byte* native_fmt;
            int fmt_byteCount = 0;
            if (fmt != null)
            {
                fmt_byteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmt_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_fmt = Util.Allocate(fmt_byteCount + 1);
                }
                else
                {
                    byte* native_fmt_stackBytes = stackalloc byte[fmt_byteCount + 1];
                    native_fmt = native_fmt_stackBytes;
                }

                int native_fmt_offset = Util.GetUtf8(fmt, native_fmt, fmt_byteCount);
                native_fmt[native_fmt_offset] = 0;
            }
            else
            {
                native_fmt = null;
            }

            ImGuiNative.ImGuiTextBuffer_appendf(NativePtr, native_fmt);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_fmt);
            }
        }

        /// <summary>
        ///     Begins this instance
        /// </summary>
        /// <returns>The string</returns>
        public string begin()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_begin(NativePtr);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Cs the str
        /// </summary>
        /// <returns>The string</returns>
        public string c_str()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_c_str(NativePtr);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void clear()
        {
            ImGuiNative.ImGuiTextBuffer_clear(NativePtr);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTextBuffer_destroy(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance empty
        /// </summary>
        /// <returns>The bool</returns>
        public bool empty()
        {
            byte ret = ImGuiNative.ImGuiTextBuffer_empty(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Ends this instance
        /// </summary>
        /// <returns>The string</returns>
        public string end()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_end(NativePtr);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Reserves the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public void reserve(int capacity)
        {
            ImGuiNative.ImGuiTextBuffer_reserve(NativePtr, capacity);
        }

        /// <summary>
        ///     Sizes this instance
        /// </summary>
        /// <returns>The ret</returns>
        public int size()
        {
            int ret = ImGuiNative.ImGuiTextBuffer_size(NativePtr);
            return ret;
        }
    }
}