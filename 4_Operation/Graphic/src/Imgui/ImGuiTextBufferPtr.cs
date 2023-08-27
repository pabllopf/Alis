using System;
using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui text buffer ptr
    /// </summary>
    public unsafe struct ImGuiTextBufferPtr
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr) => new ImGuiTextBufferPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextBuffer* (ImGuiTextBufferPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTextBufferPtr(IntPtr nativePtr) => new ImGuiTextBufferPtr(nativePtr);
        
        /// <summary>
        /// Gets the value of the buf
        /// </summary>
        public ImVector<byte> Buf => new ImVector<byte>(NativePtr->Buf);
        /// <summary>
        /// Appends the str
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
            else { nativeStr = null; }
            byte* nativeStrEnd = null;
            ImGuiNative.ImGuiTextBuffer_append(NativePtr, nativeStr, nativeStrEnd);
            if (strByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeStr);
            }
        }
        /// <summary>
        /// Appendfs the fmt
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
            else { nativeFmt = null; }
            ImGuiNative.ImGuiTextBuffer_appendf(NativePtr, nativeFmt);
            if (fmtByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFmt);
            }
        }
        /// <summary>
        /// Begins this instance
        /// </summary>
        /// <returns>The string</returns>
        public string Begin()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_begin(NativePtr);
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Cs the str
        /// </summary>
        /// <returns>The string</returns>
        public string c_str()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_c_str(NativePtr);
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImGuiTextBuffer_clear(NativePtr);
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTextBuffer_destroy(NativePtr);
        }
        /// <summary>
        /// Describes whether this instance empty
        /// </summary>
        /// <returns>The bool</returns>
        public bool Empty()
        {
            byte ret = ImGuiNative.ImGuiTextBuffer_empty(NativePtr);
            return ret != 0;
        }
        /// <summary>
        /// Ends this instance
        /// </summary>
        /// <returns>The string</returns>
        public string End()
        {
            byte* ret = ImGuiNative.ImGuiTextBuffer_end(NativePtr);
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Reserves the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public void Reserve(int capacity)
        {
            ImGuiNative.ImGuiTextBuffer_reserve(NativePtr, capacity);
        }
        /// <summary>
        /// Sizes this instance
        /// </summary>
        /// <returns>The ret</returns>
        public int Size()
        {
            int ret = ImGuiNative.ImGuiTextBuffer_size(NativePtr);
            return ret;
        }
    }
}