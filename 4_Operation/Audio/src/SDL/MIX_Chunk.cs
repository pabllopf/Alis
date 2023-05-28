using System;

namespace Alis.Core.Audio.SDL
{
    /// <summary>
    ///     The mix chunk
    /// </summary>
    public struct MixChunk
    {
        /// <summary>
        ///     The allocated
        /// </summary>
        public int Allocated;

        /// <summary>
        ///     The abuf
        /// </summary>
        public IntPtr Abuf; /* Uint8* */

        /// <summary>
        ///     The alen
        /// </summary>
        public uint Alen;

        /// <summary>
        ///     The volume
        /// </summary>
        public byte Volume;
    }
}