using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im font atlas custom rect
    /// </summary>
    public unsafe struct ImFontAtlasCustomRect
    {
        /// <summary>
        /// The width
        /// </summary>
        public ushort Width;
        /// <summary>
        /// The height
        /// </summary>
        public ushort Height;
        /// <summary>
        /// The 
        /// </summary>
        public ushort X;
        /// <summary>
        /// The 
        /// </summary>
        public ushort Y;
        /// <summary>
        /// The glyph id
        /// </summary>
        public uint GlyphID;
        /// <summary>
        /// The glyph advance
        /// </summary>
        public float GlyphAdvanceX;
        /// <summary>
        /// The glyph offset
        /// </summary>
        public Vector2 GlyphOffset;
        /// <summary>
        /// The font
        /// </summary>
        public ImFont* Font;
    }
}
