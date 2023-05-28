// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGui.Manual.cs
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
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize)
            => InputText(label, buf, bufSize, 0, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags)
            => InputText(label, buf, bufSize, flags, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
            => InputText(label, buf, bufSize, flags, callback, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }

            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret;
            fixed (byte* bufPtr = buf)
            {
                ret = ImGuiNative.igInputText(utf8LabelBytes, bufPtr, bufSize, flags, callback, userData.ToPointer()) != 0;
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength) => InputText(label, ref input, maxLength, 0, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputText(label, ref input, maxLength, flags, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);

        /// <summary>
        ///     Determines whether the input text.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text; otherwise, <c>false</c>.</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            // Convert label and input to ANSI strings
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr inputPtr = Marshal.StringToHGlobalAnsi(input);

            // Convert ANSI strings to UTF-8 bytes
            byte* utf8LabelBytes = (byte*) labelPtr.ToPointer();
            byte* utf8InputBytes = (byte*) inputPtr.ToPointer();

            // Create buffers for modified input
            int inputBufSize = Math.Max((int) maxLength + 1, Encoding.UTF8.GetByteCount(input) + 1);
            byte* modifiedUtf8InputBytes = stackalloc byte[inputBufSize];
            byte* originalUtf8InputBytes = stackalloc byte[inputBufSize];

            // Copy input bytes to the modified input buffer
            Unsafe.CopyBlock(modifiedUtf8InputBytes, utf8InputBytes, (uint) inputBufSize);

            // Call the ImGuiNative method
            byte result = ImGuiNative.igInputText(
                utf8LabelBytes,
                modifiedUtf8InputBytes,
                (uint) inputBufSize,
                flags,
                callback,
                userData.ToPointer());

            // Check if the input was modified and update the input variable accordingly
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, modifiedUtf8InputBytes))
            {
                input = Encoding.UTF8.GetString(modifiedUtf8InputBytes, inputBufSize);
            }

            // Free the memory allocated by Marshal.StringToHGlobalAnsi
            Marshal.FreeHGlobal(labelPtr);
            Marshal.FreeHGlobal(inputPtr);

            return result != 0;
        }


        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size) => InputTextMultiline(label, ref input, maxLength, size, 0, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags) => InputTextMultiline(label, ref input, maxLength, size, flags, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);

        /// <summary>
        ///     Determines whether the input text is multiline.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="input">The input.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="size">The size.</param>
        /// <param name="flags">The flags.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="userData">The user data.</param>
        /// <returns><c>true</c> if the input text is multiline; otherwise, <c>false</c>.</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            // Convert label and input to ANSI strings
            IntPtr labelPtr = Marshal.StringToHGlobalAnsi(label);
            IntPtr inputPtr = Marshal.StringToHGlobalAnsi(input);

            // Convert ANSI strings to UTF-8 bytes
            byte* utf8LabelBytes = (byte*) labelPtr.ToPointer();
            byte* utf8InputBytes = (byte*) inputPtr.ToPointer();

            // Create buffers for modified input
            int inputBufSize = Math.Max((int) maxLength + 1, Encoding.UTF8.GetByteCount(input) + 1);
            byte* modifiedUtf8InputBytes = stackalloc byte[inputBufSize];
            byte* originalUtf8InputBytes = stackalloc byte[inputBufSize];

            // Copy input bytes to the modified input buffer
            Unsafe.CopyBlock(modifiedUtf8InputBytes, utf8InputBytes, (uint) inputBufSize);

            // Call the ImGuiNative method
            byte result = ImGuiNative.igInputTextMultiline(
                utf8LabelBytes,
                modifiedUtf8InputBytes,
                (uint) inputBufSize,
                size,
                flags,
                callback,
                userData.ToPointer());

            // Check if the input was modified and update the input variable accordingly
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, modifiedUtf8InputBytes))
            {
                input = Encoding.UTF8.GetString(modifiedUtf8InputBytes, inputBufSize);
            }

            // Free the memory allocated by Marshal.StringToHGlobalAnsi
            Marshal.FreeHGlobal(labelPtr);
            Marshal.FreeHGlobal(inputPtr);

            return result != 0;
        }


        /// <summary>
        ///     Describes whether are byte arrays equal
        /// </summary>
        /// <param name="array1">The array</param>
        /// <param name="array2">The array</param>
        /// <returns>The bool</returns>
        public static bool AreByteArraysEqual(byte[] array1, byte[] array2)
        {
            if ((array1 == null) && (array2 == null))
            {
                return true;
            }

            if (array1 == null || array2 == null || array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength) => InputTextWithHint(label, hint, ref input, maxLength, 0, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputTextWithHint(label, hint, ref input, maxLength, flags, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            byte* utf8LabelBytes = GetUtf8Bytes(label);
            byte* utf8HintBytes = GetUtf8Bytes(hint);
            byte* utf8InputBytes = GetUtf8Bytes(input, maxLength);

            byte result = ImGuiNative.igInputTextWithHint(
                utf8LabelBytes,
                utf8HintBytes,
                utf8InputBytes,
                maxLength + 1,
                flags,
                callback,
                userData.ToPointer());

            bool hasInputChanged = !AreUtf8StringsEqual(utf8InputBytes, input);
            if (hasInputChanged)
            {
                input = GetStringFromUtf8(utf8InputBytes);
            }

            FreeUtf8Bytes(utf8LabelBytes);
            FreeUtf8Bytes(utf8HintBytes);
            FreeUtf8Bytes(utf8InputBytes);

            return result != 0;
        }

        /// <summary>
        ///     Gets the utf 8 bytes using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The utf bytes</returns>
        private static byte* GetUtf8Bytes(string text)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            byte* utf8Bytes = (byte*) Marshal.AllocHGlobal(byteCount + 1);
            Util.GetUtf8(text, utf8Bytes, byteCount);
            utf8Bytes[byteCount] = 0; // Null-terminate the string
            return utf8Bytes;
        }


        /// <summary>
        ///     Gets the utf 8 bytes using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="maxLength">The max length</param>
        /// <returns>The utf bytes</returns>
        private static byte* GetUtf8Bytes(string text, uint maxLength)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            int inputBufSize = Math.Max((int) maxLength + 1, byteCount + 1);
            byte[] utf8BytesArray = new byte[inputBufSize];

            fixed (byte* utf8Bytes = utf8BytesArray)
            {
                Util.GetUtf8(text, utf8Bytes, inputBufSize);
                Unsafe.InitBlockUnaligned(utf8Bytes, 0, (uint) inputBufSize);

                byte* result = (byte*) Marshal.AllocHGlobal(inputBufSize);
                Buffer.MemoryCopy(utf8Bytes, result, inputBufSize, inputBufSize);

                return result;
            }
        }


        /// <summary>
        ///     Describes whether are utf 8 strings equal
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <param name="text">The text</param>
        /// <returns>The bool</returns>
        private static bool AreUtf8StringsEqual(byte* utf8Bytes, string text)
        {
            int byteCount = Encoding.UTF8.GetByteCount(text);
            return Util.AreStringsEqual(utf8Bytes, byteCount, utf8Bytes);
        }

        /// <summary>
        ///     Gets the string from utf 8 using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <returns>The string</returns>
        private static string GetStringFromUtf8(byte* utf8Bytes) => Util.StringFromPtr(utf8Bytes);

        /// <summary>
        ///     Frees the utf 8 bytes using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        private static void FreeUtf8Bytes(byte* utf8Bytes)
        {
            int allocatedSize = GetUtf8BytesLength(utf8Bytes);
            if (allocatedSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8Bytes);
            }
        }

        /// <summary>
        ///     Gets the utf 8 bytes length using the specified utf 8 bytes
        /// </summary>
        /// <param name="utf8Bytes">The utf bytes</param>
        /// <returns>The length</returns>
        private static int GetUtf8BytesLength(byte* utf8Bytes)
        {
            if (utf8Bytes == null)
            {
                return 0;
            }

            int length = 0;
            while (*(utf8Bytes + length) != 0)
            {
                length++;
            }

            return length;
        }


        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text)
            => CalcTextSizeImpl(text);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start)
            => CalcTextSizeImpl(text, start);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length)
            => CalcTextSizeImpl(text, start, length);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);

        /// <summary>
        ///     Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);

        /// <summary>
        ///     Calcs the text size impl using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The ret</returns>
        private static Vector2 CalcTextSizeImpl(
            string text,
            int start = 0,
            int? length = null,
            bool hideTextAfterDoubleHash = false,
            float wrapWidth = -1.0f)
        {
            Vector2 ret;
            byte* nativeTextStart = null;
            byte* nativeTextEnd = null;
            int textByteCount = 0;
            if (text != null)
            {
                int textToCopyLen = length.HasValue ? length.Value : text.Length;
                textByteCount = Util.CalcSizeInUtf8(text, start, textToCopyLen);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeTextStart = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeTextStart = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, start, textToCopyLen, nativeTextStart, textByteCount);
                nativeTextStart[nativeTextOffset] = 0;
                nativeTextEnd = nativeTextStart + nativeTextOffset;
            }

            ImGuiNative.igCalcTextSize(&ret, nativeTextStart, nativeTextEnd, *(byte*) &hideTextAfterDoubleHash, wrapWidth);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTextStart);
            }

            return ret;
        }

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize)
            => InputText(label, buf, bufSize, 0, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags)
            => InputText(label, buf, bufSize, flags, null, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
            => InputText(label, buf, bufSize, flags, callback, IntPtr.Zero);

        /// <summary>
        ///     Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="userData">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint bufSize,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr userData)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }

            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret = ImGuiNative.igInputText(utf8LabelBytes, (byte*) buf.ToPointer(), bufSize, flags, callback, userData.ToPointer()) != 0;

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        /// <summary>
        ///     Describes whether begin
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool Begin(string name, ImGuiWindowFlags flags)
        {
            int utf8NameByteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8NameBytes;
            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                utf8NameBytes = Util.Allocate(utf8NameByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8NameByteCount + 1];
                utf8NameBytes = stackPtr;
            }

            Util.GetUtf8(name, utf8NameBytes, utf8NameByteCount);

            byte* pOpen = null;
            byte ret = ImGuiNative.igBegin(utf8NameBytes, pOpen, flags);

            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8NameBytes);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, bool enabled) => MenuItem(label, string.Empty, false, enabled);
    }
}