

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImFont
    {
        /// <summary>
        ///     The index advance
        /// </summary>
        public ImVector IndexAdvanceX { get; set; }

        /// <summary>
        ///     The fallback advance
        /// </summary>
        public float FallbackAdvanceX { get; set; }

        /// <summary>
        ///     The font size
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        ///     The index lookup
        /// </summary>
        public ImVector IndexLookup { get; set; }

        /// <summary>
        ///     The glyphs
        /// </summary>
        public ImVector Glyphs { get; set; }

        /// <summary>
        ///     The fallback glyph
        /// </summary>
        public IntPtr FallbackGlyph { get; set; }

        /// <summary>
        ///     The container atlas
        /// </summary>
        public IntPtr ContainerAtlas { get; set; }

        /// <summary>
        ///     The config data
        /// </summary>
        public IntPtr ConfigData { get; set; }

        /// <summary>
        ///     The config data count
        /// </summary>
        public short ConfigDataCount { get; set; }

        /// <summary>
        ///     The fallback char
        /// </summary>
        public ushort FallbackChar { get; set; }

        /// <summary>
        ///     The ellipsis char
        /// </summary>
        public ushort EllipsisChar { get; set; }

        /// <summary>
        ///     The dot char
        /// </summary>
        public ushort DotChar { get; set; }

        /// <summary>
        ///     The dirty lookup tables
        /// </summary>
        public byte DirtyLookupTables { get; set; }

        /// <summary>
        ///     The scale
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        ///     The ascent
        /// </summary>
        public float Ascent { get; set; }

        /// <summary>
        ///     The descent
        /// </summary>
        public float Descent { get; set; }

        /// <summary>
        ///     The metrics total surface
        /// </summary>
        public int MetricsTotalSurface { get; set; }

        /// <summary>
        ///     The used 4k pages map
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Used4KPagesMap;
    }
}