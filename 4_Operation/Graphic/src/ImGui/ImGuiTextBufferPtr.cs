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
    public struct ImGuiTextBufferPtr
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
        public void Append(string str)
        {
            byte* nativeStr;
            int strByteCount = 0;
            if (str != null)
            {
                strByteCount = Encoding.UTF8.GetByteCount(str);
                if (strByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeStr = Util.Allocate(strByteCount + 1);
                }
                else
                {
                    byte* nativeStrStackBytes = stackalloc byte[strByteCount + 1];
                    nativeStr = nativeStrStackBytes;
                }

                int nativeStrOffset = Util.GetUtf8(str, nativeStr, strByteCount);
                nativeStr[nativeStrOffset] = 0;
            }
            else
            {
                nativeStr = null;
            }

            byte* nativeStrEnd = null;
            ImGuiNative.ImGuiTextBuffer_append(NativePtr, nativeStr, nativeStrEnd);
            if (strByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStr);
            }
        }

        /// <summary>
        ///     Appendfs the fmt
        /// </summary>
        /// <param name="fmt">The fmt</param>
        public void Appendf(string fmt)
        {
            byte* nativeFmt;
            int fmtByteCount = 0;
            if (fmt != null)
            {
                fmtByteCount = Encoding.UTF8.GetByteCount(fmt);
                if (fmtByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFmt = Util.Allocate(fmtByteCount + 1);
                }
                else
                {
                    byte* nativeFmtStackBytes = stackalloc byte[fmtByteCount + 1];
                    nativeFmt = nativeFmtStackBytes;
                }

                int nativeFmtOffset = Util.GetUtf8(fmt, nativeFmt, fmtByteCount);
                nativeFmt[nativeFmtOffset] = 0;
            }
            else
            {
                nativeFmt = null;
            }

            ImGuiNative.ImGuiTextBuffer_appendf(NativePtr, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }

        /// <summary>
        ///     Begins this instance
        /// </summary>
        /// <returns>The string</returns>
        public string Begin()
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
        public void Clear()
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
        public bool Empty()
        {
            byte ret = ImGuiNative.ImGuiTextBuffer_empty(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Ends this instance
        /// </summary>
        /// <returns>The string</returns>
        public string End()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_end(NativePtr);
            return Util.StringFromPtr(ret);
        }

        /// <summary>
        ///     Reserves the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public void Reserve(int capacity)
        {
            ImGuiNative.ImGuiTextBuffer_reserve(NativePtr, capacity);
        }

        /// <summary>
        ///     Sizes this instance
        /// </summary>
        /// <returns>The ret</returns>
        public int Size()
        {
            int ret = ImGuiNative.ImGuiTextBuffer_size(NativePtr);
            return ret;
        }
    }
}