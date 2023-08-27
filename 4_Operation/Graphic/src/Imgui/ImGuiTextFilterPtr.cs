// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextFilterPtr.cs
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
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    ///     The im gui text filter ptr
    /// </summary>
    public unsafe struct ImGuiTextFilterPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiTextFilter* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTextFilterPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextFilterPtr(ImGuiTextFilter* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTextFilterPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextFilterPtr(IntPtr nativePtr) => NativePtr = (ImGuiTextFilter*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextFilterPtr(ImGuiTextFilter* nativePtr) => new ImGuiTextFilterPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextFilter*(ImGuiTextFilterPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextFilterPtr(IntPtr nativePtr) => new ImGuiTextFilterPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the input buf
        /// </summary>
        public RangeAccessor<byte> InputBuf => new RangeAccessor<byte>(NativePtr->InputBuf, 256);

        /// <summary>
        ///     Gets the value of the filters
        /// </summary>
        public ImPtrVector<ImGuiTextRangePtr> Filters => new ImPtrVector<ImGuiTextRangePtr>(NativePtr->Filters, Unsafe.SizeOf<ImGuiTextRange>());

        /// <summary>
        ///     Gets the value of the count grep
        /// </summary>
        public ref int CountGrep => ref Unsafe.AsRef<int>(&NativePtr->CountGrep);

        /// <summary>
        ///     Builds this instance
        /// </summary>
        public void Build()
        {
            ImGuiNative.ImGuiTextFilter_Build(NativePtr);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImGuiTextFilter_Clear(NativePtr);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTextFilter_destroy(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance draw
        /// </summary>
        /// <returns>The bool</returns>
        public bool Draw()
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            labelByteCount = Encoding.UTF8.GetByteCount("Filter(inc,-exc)");
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                nativeLabel = Util.Allocate(labelByteCount + 1);
            }
            else
            {
                byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                nativeLabel = nativeLabelStackBytes;
            }

            int nativeLabelOffset = Util.GetUtf8("Filter(inc,-exc)", nativeLabel, labelByteCount);
            nativeLabel[nativeLabelOffset] = 0;
            float width = 0.0f;
            byte ret = ImGuiNative.ImGuiTextFilter_Draw(NativePtr, nativeLabel, width);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance draw
        /// </summary>
        /// <param name="label">The label</param>
        /// <returns>The bool</returns>
        public bool Draw(string label)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            float width = 0.0f;
            byte ret = ImGuiNative.ImGuiTextFilter_Draw(NativePtr, nativeLabel, width);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance draw
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="width">The width</param>
        /// <returns>The bool</returns>
        public bool Draw(string label, float width)
        {
            byte* nativeLabel;
            int labelByteCount = 0;
            if (label != null)
            {
                labelByteCount = Encoding.UTF8.GetByteCount(label);
                if (labelByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeLabel = Util.Allocate(labelByteCount + 1);
                }
                else
                {
                    byte* nativeLabelStackBytes = stackalloc byte[labelByteCount + 1];
                    nativeLabel = nativeLabelStackBytes;
                }

                int nativeLabelOffset = Util.GetUtf8(label, nativeLabel, labelByteCount);
                nativeLabel[nativeLabelOffset] = 0;
            }
            else
            {
                nativeLabel = null;
            }

            byte ret = ImGuiNative.ImGuiTextFilter_Draw(NativePtr, nativeLabel, width);
            if (labelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeLabel);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance is active
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsActive()
        {
            byte ret = ImGuiNative.ImGuiTextFilter_IsActive(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance pass filter
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        public bool PassFilter(string text)
        {
            byte* nativeText;
            int textByteCount = 0;
            if (text != null)
            {
                textByteCount = Encoding.UTF8.GetByteCount(text);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeText = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeText = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, nativeText, textByteCount);
                nativeText[nativeTextOffset] = 0;
            }
            else
            {
                nativeText = null;
            }

            byte* nativeTextEnd = null;
            byte ret = ImGuiNative.ImGuiTextFilter_PassFilter(NativePtr, nativeText, nativeTextEnd);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }

            return ret != 0;
        }
    }
}