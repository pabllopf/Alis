using System;
using System.Text;

namespace ImGuiNET
{
    /// <summary>
    /// The im font glyph ranges builder
    /// </summary>
    public unsafe partial struct ImFontGlyphRangesBuilder
    {
        /// <summary>
        /// The used chars
        /// </summary>
        public ImVector UsedChars;
    }
    /// <summary>
    /// The im font glyph ranges builder ptr
    /// </summary>
    public unsafe partial struct ImFontGlyphRangesBuilderPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImFontGlyphRangesBuilder* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontGlyphRangesBuilderPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontGlyphRangesBuilderPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphRangesBuilderPtr(IntPtr nativePtr) => NativePtr = (ImFontGlyphRangesBuilder*)nativePtr;
        public static implicit operator ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr) => new ImFontGlyphRangesBuilderPtr(nativePtr);
        public static implicit operator ImFontGlyphRangesBuilder* (ImFontGlyphRangesBuilderPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontGlyphRangesBuilderPtr(IntPtr nativePtr) => new ImFontGlyphRangesBuilderPtr(nativePtr);
        /// <summary>
        /// Gets the value of the used chars
        /// </summary>
        public ImVector<uint> UsedChars => new ImVector<uint>(NativePtr->UsedChars);
        /// <summary>
        /// Adds the char using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddChar(ushort c)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_AddChar((ImFontGlyphRangesBuilder*)(NativePtr), c);
        }
        /// <summary>
        /// Adds the ranges using the specified ranges
        /// </summary>
        /// <param name="ranges">The ranges</param>
        public void AddRanges(IntPtr ranges)
        {
            ushort* native_ranges = (ushort*)ranges.ToPointer();
            ImGuiNative.ImFontGlyphRangesBuilder_AddRanges((ImFontGlyphRangesBuilder*)(NativePtr), native_ranges);
        }
        /// <summary>
        /// Adds the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public void AddText(string text)
        {
            byte* native_text;
            int text_byteCount = 0;
            if (text != null)
            {
                text_byteCount = Encoding.UTF8.GetByteCount(text);
                if (text_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_text = Util.Allocate(text_byteCount + 1);
                }
                else
                {
                    byte* native_text_stackBytes = stackalloc byte[text_byteCount + 1];
                    native_text = native_text_stackBytes;
                }
                int native_text_offset = Util.GetUtf8(text, native_text, text_byteCount);
                native_text[native_text_offset] = 0;
            }
            else { native_text = null; }
            byte* native_text_end = null;
            ImGuiNative.ImFontGlyphRangesBuilder_AddText((ImFontGlyphRangesBuilder*)(NativePtr), native_text, native_text_end);
            if (text_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_text);
            }
        }
        /// <summary>
        /// Builds the ranges using the specified out ranges
        /// </summary>
        /// <param name="out_ranges">The out ranges</param>
        public void BuildRanges(out ImVector out_ranges)
        {
            fixed (ImVector* native_out_ranges = &out_ranges)
            {
                ImGuiNative.ImFontGlyphRangesBuilder_BuildRanges((ImFontGlyphRangesBuilder*)(NativePtr), native_out_ranges);
            }
        }
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_Clear((ImFontGlyphRangesBuilder*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_destroy((ImFontGlyphRangesBuilder*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance get bit
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The bool</returns>
        public bool GetBit(uint n)
        {
            byte ret = ImGuiNative.ImFontGlyphRangesBuilder_GetBit((ImFontGlyphRangesBuilder*)(NativePtr), n);
            return ret != 0;
        }
        /// <summary>
        /// Sets the bit using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void SetBit(uint n)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_SetBit((ImFontGlyphRangesBuilder*)(NativePtr), n);
        }
    }
}
