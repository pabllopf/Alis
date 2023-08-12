using System;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The block literal
    /// </summary>
    public unsafe struct BlockLiteral
    {
        /// <summary>
        /// The isa
        /// </summary>
        public IntPtr isa;
        /// <summary>
        /// The flags
        /// </summary>
        public int flags;
        /// <summary>
        /// The reserved
        /// </summary>
        public int reserved;
        /// <summary>
        /// The invoke
        /// </summary>
        public IntPtr invoke;
        /// <summary>
        /// The descriptor
        /// </summary>
        public BlockDescriptor* descriptor;
    };

    /// <summary>
    /// The block descriptor
    /// </summary>
    public unsafe struct BlockDescriptor
    {
        /// <summary>
        /// The reserved
        /// </summary>
        public ulong reserved;
        /// <summary>
        /// The block size
        /// </summary>
        public ulong Block_size;
    }
}

