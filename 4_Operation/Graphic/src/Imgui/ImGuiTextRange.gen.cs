using System;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui text range
    /// </summary>
    public unsafe partial struct ImGuiTextRange
    {
        /// <summary>
        /// The 
        /// </summary>
        public byte* b;
        /// <summary>
        /// The 
        /// </summary>
        public byte* e;
    }
    /// <summary>
    /// The im gui text range ptr
    /// </summary>
    public unsafe partial struct ImGuiTextRangePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiTextRange* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTextRangePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextRangePtr(ImGuiTextRange* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTextRangePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTextRangePtr(IntPtr nativePtr) => NativePtr = (ImGuiTextRange*)nativePtr;
        public static implicit operator ImGuiTextRangePtr(ImGuiTextRange* nativePtr) => new ImGuiTextRangePtr(nativePtr);
        public static implicit operator ImGuiTextRange* (ImGuiTextRangePtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiTextRangePtr(IntPtr nativePtr) => new ImGuiTextRangePtr(nativePtr);
        /// <summary>
        /// Gets or sets the value of the b
        /// </summary>
        public IntPtr b { get => (IntPtr)NativePtr->b; set => NativePtr->b = (byte*)value; }
        /// <summary>
        /// Gets or sets the value of the e
        /// </summary>
        public IntPtr e { get => (IntPtr)NativePtr->e; set => NativePtr->e = (byte*)value; }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTextRange_destroy((ImGuiTextRange*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance empty
        /// </summary>
        /// <returns>The bool</returns>
        public bool empty()
        {
            byte ret = ImGuiNative.ImGuiTextRange_empty((ImGuiTextRange*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Splits the separator
        /// </summary>
        /// <param name="separator">The separator</param>
        /// <param name="out">The out</param>
        public void split(byte separator, out ImVector @out)
        {
            fixed (ImVector* native_out = &@out)
            {
                ImGuiNative.ImGuiTextRange_split((ImGuiTextRange*)(NativePtr), separator, native_out);
            }
        }
    }
}
