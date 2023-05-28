using System;

namespace Alis.Core.Audio.SDL
{
    /// <summary>
    ///     The mix chunk
    /// </summary>
    public struct MIX_Chunk
    {
        /// <summary>
        ///     The allocated
        /// </summary>
        public int allocated;

        /// <summary>
        ///     The abuf
        /// </summary>
        public IntPtr abuf; /* Uint8* */

        /// <summary>
        ///     The alen
        /// </summary>
        public uint alen;

        /// <summary>
        ///     The volume
        /// </summary>
        public byte volume;
    }
}