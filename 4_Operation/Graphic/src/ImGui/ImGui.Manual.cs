using System;
using System.Numerics;
using System.Text;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui class
    /// </summary>
    public static unsafe partial class ImGui
    {
        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint buf_size)
        {
            return InputText(label, buf, buf_size, 0, null, IntPtr.Zero);
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags)
        {
            return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
        {
            return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
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
                ret = ImGuiNative.igInputText(utf8LabelBytes, bufPtr, buf_size, flags, callback, user_data.ToPointer()) != 0;
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        /// <summary>
        /// Describes whether input text
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
        /// Describes whether input text
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
        /// Describes whether input text
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
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
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

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputText(
                utf8LabelBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        /// <summary>
        /// Describes whether input text multiline
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
        /// Describes whether input text multiline
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
        /// Describes whether input text multiline
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
        /// Describes whether input text multiline
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="size">The size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputTextMultiline(
            string label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
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

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputTextMultiline(
                utf8LabelBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                size,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        /// <summary>
        /// Describes whether input text with hint
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
        /// Describes whether input text with hint
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
        /// Describes whether input text with hint
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
        /// Describes whether input text with hint
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="hint">The hint</param>
        /// <param name="input">The input</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The bool</returns>
        public static bool InputTextWithHint(
            string label,
            string hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
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

            int utf8HintByteCount = Encoding.UTF8.GetByteCount(hint);
            byte* utf8HintBytes;
            if (utf8HintByteCount > Util.StackAllocationSizeLimit)
            {
                utf8HintBytes = Util.Allocate(utf8HintByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8HintByteCount + 1];
                utf8HintBytes = stackPtr;
            }
            Util.GetUtf8(hint, utf8HintBytes, utf8HintByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            
            //Array.Clear(utf8InputBytes, utf8InputByteCount, clearBytesCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputTextWithHint(
                utf8LabelBytes,
                utf8HintBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (utf8HintByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8HintBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text)
            => CalcTextSizeImpl(text);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start)
            => CalcTextSizeImpl(text, start);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length)
            => CalcTextSizeImpl(text, start, length);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, hideTextAfterDoubleHash: hideTextAfterDoubleHash, wrapWidth: wrapWidth);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="hideTextAfterDoubleHash">The hide text after double hash</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

        /// <summary>
        /// Calcs the text size using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <param name="wrapWidth">The wrap width</param>
        /// <returns>The vector</returns>
        public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);

        /// <summary>
        /// Calcs the text size using the specified text
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
        /// Calcs the text size impl using the specified text
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

            ImGuiNative.igCalcTextSize(&ret, nativeTextStart, nativeTextEnd, *((byte*)(&hideTextAfterDoubleHash)), wrapWidth);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeTextStart);
            }

            return ret;
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint buf_size)
        {
            return InputText(label, buf, buf_size, 0, null, IntPtr.Zero);
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags)
        {
            return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <returns>The bool</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
        {
            return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
        }

        /// <summary>
        /// Describes whether input text
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="buf">The buf</param>
        /// <param name="buf_size">The buf size</param>
        /// <param name="flags">The flags</param>
        /// <param name="callback">The callback</param>
        /// <param name="user_data">The user data</param>
        /// <returns>The ret</returns>
        public static bool InputText(
            string label,
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
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

            bool ret = ImGuiNative.igInputText(utf8LabelBytes, (byte*)buf.ToPointer(), buf_size, flags, callback, user_data.ToPointer()) != 0;

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        /// <summary>
        /// Describes whether begin
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

            byte* p_open = null;
            byte ret = ImGuiNative.igBegin(utf8NameBytes, p_open, flags);

            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8NameBytes);
            }

            return ret != 0;
        }

        /// <summary>
        /// Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, bool enabled)
        {
            return ImGui.MenuItem(label, string.Empty, false, enabled);
        }
    }
}
