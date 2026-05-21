

using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font atlas custom rect
    /// </summary>
    public struct ImFontAtlasCustomRect
    {
        /// <summary>
        ///     The width
        /// </summary>
        public ushort Width { get; set; }

        /// <summary>
        ///     The height
        /// </summary>
        public ushort Height { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public ushort X { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public ushort Y { get; set; }

        /// <summary>
        ///     The glyph id
        /// </summary>
        public uint GlyphId { get; set; }

        /// <summary>
        ///     The glyph advance
        /// </summary>
        public float GlyphAdvanceX { get; set; }

        /// <summary>
        ///     The glyph offset
        /// </summary>
        public Vector2F GlyphOffset { get; set; }

        /// <summary>
        ///     The font
        /// </summary>
        public IntPtr Font { get; set; }
    }
}