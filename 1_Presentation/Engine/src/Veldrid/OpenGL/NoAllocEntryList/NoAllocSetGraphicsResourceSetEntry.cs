using System.Runtime.CompilerServices;

namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set resource set entry
    /// </summary>
    internal unsafe struct NoAllocSetResourceSetEntry
    {
        /// <summary>
        /// The max inline dynamic offsets
        /// </summary>
        public const int MaxInlineDynamicOffsets = 10;

        /// <summary>
        /// The slot
        /// </summary>
        public readonly uint Slot;
        /// <summary>
        /// The resource set
        /// </summary>
        public readonly Tracked<ResourceSet> ResourceSet;
        /// <summary>
        /// The is graphics
        /// </summary>
        public readonly bool IsGraphics;
        /// <summary>
        /// The dynamic offset count
        /// </summary>
        public readonly uint DynamicOffsetCount;
        /// <summary>
        /// The max inline dynamic offsets
        /// </summary>
        public fixed uint DynamicOffsets_Inline[MaxInlineDynamicOffsets];
        /// <summary>
        /// The dynamicoffsets block
        /// </summary>
        public readonly StagingBlock DynamicOffsets_Block;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetResourceSetEntry"/> class
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="isGraphics">The is graphics</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        public NoAllocSetResourceSetEntry(
            uint slot,
            Tracked<ResourceSet> rs,
            bool isGraphics,
            uint dynamicOffsetCount,
            ref uint dynamicOffsets)
        {
            Slot = slot;
            ResourceSet = rs;
            IsGraphics = isGraphics;
            DynamicOffsetCount = dynamicOffsetCount;
            for (int i = 0; i < dynamicOffsetCount; i++)
            {
                DynamicOffsets_Inline[i] = Unsafe.Add(ref dynamicOffsets, i);
            }

            DynamicOffsets_Block = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetResourceSetEntry"/> class
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="isGraphics">The is graphics</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        public NoAllocSetResourceSetEntry(
            uint slot,
            Tracked<ResourceSet> rs,
            bool isGraphics,
            StagingBlock dynamicOffsets)
        {
            Slot = slot;
            ResourceSet = rs;
            IsGraphics = isGraphics;
            DynamicOffsetCount = (uint)dynamicOffsets.SizeInBytes / sizeof(uint);
            DynamicOffsets_Block = dynamicOffsets;
        }
    }
}
