// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextCallbackDataPtr.cs
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
using Alis.Core.Graphic.ImGui.Enums;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui input text callback data ptr
    /// </summary>
    public unsafe struct ImGuiInputTextCallbackDataPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiInputTextCallbackData* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiInputTextCallbackDataPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiInputTextCallbackDataPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiInputTextCallbackDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiInputTextCallbackData*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr) => new ImGuiInputTextCallbackDataPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiInputTextCallbackData*(ImGuiInputTextCallbackDataPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiInputTextCallbackDataPtr(IntPtr nativePtr) => new ImGuiInputTextCallbackDataPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the ctx
        /// </summary>
        public ref IntPtr Ctx => ref Unsafe.AsRef<IntPtr>(&NativePtr->Ctx);

        /// <summary>
        ///     Gets the value of the event flag
        /// </summary>
        public ref ImGuiInputTextFlags EventFlag => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->EventFlag);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ref ImGuiInputTextFlags Flags => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->Flags);

        /// <summary>
        ///     Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData
        {
            get => (IntPtr) NativePtr->UserData;
            set => NativePtr->UserData = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the event char
        /// </summary>
        public ref ushort EventChar => ref Unsafe.AsRef<ushort>(&NativePtr->EventChar);

        /// <summary>
        ///     Gets the value of the event key
        /// </summary>
        public ref ImGuiKey EventKey => ref Unsafe.AsRef<ImGuiKey>(&NativePtr->EventKey);

        /// <summary>
        ///     Gets or sets the value of the buf
        /// </summary>
        public IntPtr Buf
        {
            get => (IntPtr) NativePtr->Buf;
            set => NativePtr->Buf = (byte*) value;
        }

        /// <summary>
        ///     Gets the value of the buf text len
        /// </summary>
        public ref int BufTextLen => ref Unsafe.AsRef<int>(&NativePtr->BufTextLen);

        /// <summary>
        ///     Gets the value of the buf size
        /// </summary>
        public ref int BufSize => ref Unsafe.AsRef<int>(&NativePtr->BufSize);

        /// <summary>
        ///     Gets the value of the buf dirty
        /// </summary>
        public ref bool BufDirty => ref Unsafe.AsRef<bool>(&NativePtr->BufDirty);

        /// <summary>
        ///     Gets the value of the cursor pos
        /// </summary>
        public ref int CursorPos => ref Unsafe.AsRef<int>(&NativePtr->CursorPos);

        /// <summary>
        ///     Gets the value of the selection start
        /// </summary>
        public ref int SelectionStart => ref Unsafe.AsRef<int>(&NativePtr->SelectionStart);

        /// <summary>
        ///     Gets the value of the selection end
        /// </summary>
        public ref int SelectionEnd => ref Unsafe.AsRef<int>(&NativePtr->SelectionEnd);

        /// <summary>
        ///     Clears the selection
        /// </summary>
        public void ClearSelection()
        {
            ImGuiNative.ImGuiInputTextCallbackData_ClearSelection(NativePtr);
        }

        /// <summary>
        ///     Deletes the chars using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="bytesCount">The bytes count</param>
        public void DeleteChars(int pos, int bytesCount)
        {
            ImGuiNative.ImGuiInputTextCallbackData_DeleteChars(NativePtr, pos, bytesCount);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiInputTextCallbackData_destroy(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance has selection
        /// </summary>
        /// <returns>The bool</returns>
        public bool HasSelection()
        {
            byte ret = ImGuiNative.ImGuiInputTextCallbackData_HasSelection(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Inserts the chars using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="text">The text</param>
        public void InsertChars(int pos, string text)
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
            ImGuiNative.ImGuiInputTextCallbackData_InsertChars(NativePtr, pos, nativeText, nativeTextEnd);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
        }

        /// <summary>
        ///     Selects the all
        /// </summary>
        public void SelectAll()
        {
            ImGuiNative.ImGuiInputTextCallbackData_SelectAll(NativePtr);
        }
    }
}