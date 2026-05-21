

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font config
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImFontConfig
    {
        /// <summary>
        ///     The font data
        /// </summary>
        public IntPtr FontData;

        /// <summary>
        ///     The font data size
        /// </summary>
        public int FontDataSize;

        /// <summary>
        ///     The font data owned by atlas
        /// </summary>
        public byte FontDataOwnedByAtlas;

        /// <summary>
        ///     The font no
        /// </summary>
        public int FontNo;

        /// <summary>
        ///     The size pixels
        /// </summary>
        public float SizePixels;

        /// <summary>
        ///     The oversample
        /// </summary>
        public int OversampleH;

        /// <summary>
        ///     The oversample
        /// </summary>
        public int OversampleV;

        /// <summary>
        ///     The pixel snap
        /// </summary>
        public byte SnapH;

        /// <summary>
        ///     The glyph extra spacing
        /// </summary>
        public Vector2F GlyphExtraSpacing;

        /// <summary>
        ///     The glyph offset
        /// </summary>
        public Vector2F GlyphOffset;

        /// <summary>
        ///     The glyph ranges
        /// </summary>
        public IntPtr GlyphRanges;

        /// <summary>
        ///     The glyph min advance
        /// </summary>
        public float GlyphMinAdvanceX;

        /// <summary>
        ///     The glyph max advance
        /// </summary>
        public float GlyphMaxAdvanceX;

        /// <summary>
        ///     The merge mode
        /// </summary>
        public byte MergeMode;

        /// <summary>
        ///     The font builder flags
        /// </summary>
        public uint FontBuilderFlags;

        /// <summary>
        ///     The rasterizer multiply
        /// </summary>
        public float RasterizerMultiply;

        /// <summary>
        ///     The ellipsis char
        /// </summary>
        public ushort EllipsisChar;

        /// <summary>
        ///     The name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] Name;

        /// <summary>
        ///     The dst font
        /// </summary>
        public IntPtr DstFont;
    }
}