using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi bmp data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StbiBmpData
    {
        /// <summary>
        ///     The bpp
        /// </summary>
        public int bpp;

        /// <summary>
        ///     The offset
        /// </summary>
        public int offset;

        /// <summary>
        ///     The hsz
        /// </summary>
        public int hsz;

        /// <summary>
        ///     The mr
        /// </summary>
        public uint mr;

        /// <summary>
        ///     The mg
        /// </summary>
        public uint mg;

        /// <summary>
        ///     The mb
        /// </summary>
        public uint mb;

        /// <summary>
        ///     The ma
        /// </summary>
        public uint ma;

        /// <summary>
        ///     The all
        /// </summary>
        public uint all_a;

        /// <summary>
        ///     The extra read
        /// </summary>
        public int extra_read;
    }
}