

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font glyph ranges builder
    /// </summary>
    public struct ImFontGlyphRangesBuilder
    {
        /// <summary>
        ///     The used chars
        /// </summary>
        public ImVector UsedChars { get; set; }


        /// <summary>
        ///     Adds the char using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddChar(ushort c)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_AddChar(ref this, c);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_Clear(ref this);
        }

        /// <summary>
        ///     Describes whether this instance get bit
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The bool</returns>
        public bool GetBit(uint n)
        {
            byte ret = ImGuiNative.ImFontGlyphRangesBuilder_GetBit(ref this, n);
            return ret != 0;
        }

        /// <summary>
        ///     Sets the bit using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void SetBit(uint n)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_SetBit(ref this, n);
        }
    }
}