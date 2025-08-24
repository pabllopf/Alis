using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    /// Structure mapping the C library arguments passed to the data callback
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct Chunk
    {
        /// <summary>
        /// The samples
        /// </summary>
        public IntPtr samples;
        /// <summary>
        /// The sample count
        /// </summary>
        public uint sampleCount;
    }
}