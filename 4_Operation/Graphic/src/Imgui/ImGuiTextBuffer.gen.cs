using System;
using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui text buffer
    /// </summary>
    public unsafe partial struct ImGuiTextBuffer
    {
        /// <summary>
        /// The buf
        /// </summary>
        public ImVector Buf;
    }
    /// <summary>
    /// The im gui text buffer ptr
    /// </summary>
    public unsafe partial struct ImGuiTextBufferPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiTextBuffer* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTextBufferPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTextBufferPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextBufferPtr(IntPtr nativePtr) => NativePtr = (ImGuiTextBuffer*)nativePtr;
        public static implicit operator ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr) => new ImGuiTextBufferPtr(nativePtr);
        public static implicit operator ImGuiTextBuffer* (ImGuiTextBufferPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiTextBufferPtr(IntPtr nativePtr) => new ImGuiTextBufferPtr(nativePtr);
        /// <summary>
        /// Gets the value of the buf
        /// </summary>
        public ImVector<byte> Buf => new ImVector<byte>(NativePtr->Buf);
        /// <summary>
        /// Appends the str
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
            else { native_str = null; }
            byte* native_str_end = null;
            ImGuiNative.ImGuiTextBuffer_append((ImGuiTextBuffer*)(NativePtr), native_str, native_str_end);
            if (str_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_str);
            }
        }
        /// <summary>
        /// Appendfs the fmt
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
            else { native_fmt = null; }
            ImGuiNative.ImGuiTextBuffer_appendf((ImGuiTextBuffer*)(NativePtr), native_fmt);
            if (fmt_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_fmt);
            }
        }
        /// <summary>
        /// Begins this instance
        /// </summary>
        /// <returns>The string</returns>
        public string begin()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_begin((ImGuiTextBuffer*)(NativePtr));
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Cs the str
        /// </summary>
        /// <returns>The string</returns>
        public string c_str()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_c_str((ImGuiTextBuffer*)(NativePtr));
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void clear()
        {
            ImGuiNative.ImGuiTextBuffer_clear((ImGuiTextBuffer*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTextBuffer_destroy((ImGuiTextBuffer*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance empty
        /// </summary>
        /// <returns>The bool</returns>
        public bool empty()
        {
            byte ret = ImGuiNative.ImGuiTextBuffer_empty((ImGuiTextBuffer*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Ends this instance
        /// </summary>
        /// <returns>The string</returns>
        public string end()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_end((ImGuiTextBuffer*)(NativePtr));
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Reserves the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public void reserve(int capacity)
        {
            ImGuiNative.ImGuiTextBuffer_reserve((ImGuiTextBuffer*)(NativePtr), capacity);
        }
        /// <summary>
        /// Sizes this instance
        /// </summary>
        /// <returns>The ret</returns>
        public int size()
        {
            int ret = ImGuiNative.ImGuiTextBuffer_size((ImGuiTextBuffer*)(NativePtr));
            return ret;
        }
    }
}
