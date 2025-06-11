using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi huffman
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Stbihuffman
    {
        /// <summary>
        ///     The fast
        /// </summary>
        public fixed byte fast[512];

        /// <summary>
        ///     The code
        /// </summary>
        public fixed ushort code[256];

        /// <summary>
        ///     The values
        /// </summary>
        public fixed byte values[256];

        /// <summary>
        ///     The size
        /// </summary>
        public fixed byte size[257];

        /// <summary>
        ///     The maxcode
        /// </summary>
        public fixed uint maxcode[18];

        /// <summary>
        ///     The delta
        /// </summary>
        public fixed int delta[17];
    }
}