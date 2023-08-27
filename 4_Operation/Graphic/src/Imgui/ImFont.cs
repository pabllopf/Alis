using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im font
    /// </summary>
    public unsafe struct ImFont
    {
        /// <summary>
        /// The index advance
        /// </summary>
        public ImVector IndexAdvanceX;
        /// <summary>
        /// The fallback advance
        /// </summary>
        public float FallbackAdvanceX;
        /// <summary>
        /// The font size
        /// </summary>
        public float FontSize;
        /// <summary>
        /// The index lookup
        /// </summary>
        public ImVector IndexLookup;
        /// <summary>
        /// The glyphs
        /// </summary>
        public ImVector Glyphs;
        /// <summary>
        /// The fallback glyph
        /// </summary>
        public ImFontGlyph* FallbackGlyph;
        /// <summary>
        /// The container atlas
        /// </summary>
        public ImFontAtlas* ContainerAtlas;
        /// <summary>
        /// The config data
        /// </summary>
        public ImFontConfig* ConfigData;
        /// <summary>
        /// The config data count
        /// </summary>
        public short ConfigDataCount;
        /// <summary>
        /// The fallback char
        /// </summary>
        public ushort FallbackChar;
        /// <summary>
        /// The ellipsis char
        /// </summary>
        public ushort EllipsisChar;
        /// <summary>
        /// The dot char
        /// </summary>
        public ushort DotChar;
        /// <summary>
        /// The dirty lookup tables
        /// </summary>
        public byte DirtyLookupTables;
        /// <summary>
        /// The scale
        /// </summary>
        public float Scale;
        /// <summary>
        /// The ascent
        /// </summary>
        public float Ascent;
        /// <summary>
        /// The descent
        /// </summary>
        public float Descent;
        /// <summary>
        /// The metrics total surface
        /// </summary>
        public int MetricsTotalSurface;
        /// <summary>
        /// The used 4k pages map
        /// </summary>
        public fixed byte Used4kPagesMap[2];
    }
}
