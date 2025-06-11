using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi pngchunk
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Stbipngchunk
    {
        /// <summary>
        ///     The length
        /// </summary>
        public uint length;

        /// <summary>
        ///     The type
        /// </summary>
        public uint type;
    }
}