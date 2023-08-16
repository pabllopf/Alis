using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The open gl no alloc command entry list class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntryList"/>
    /// <seealso cref="IDisposable"/>
    internal unsafe class OpenGLNoAllocCommandEntryList : OpenGLCommandEntryList, IDisposable
    {
        /// <summary>
        /// The memory pool
        /// </summary>
        private readonly StagingMemoryPool _memoryPool;
        /// <summary>
        /// The entry storage block
        /// </summary>
        private readonly List<EntryStorageBlock> _blocks = new List<EntryStorageBlock>();
        /// <summary>
        /// The current block
        /// </summary>
        private EntryStorageBlock _currentBlock;
        /// <summary>
        /// The total entries
        /// </summary>
        private uint _totalEntries;
        /// <summary>
        /// The list
        /// </summary>
        private readonly List<object> _resourceList = new List<object>();
        /// <summary>
        /// The staging block
        /// </summary>
        private readonly List<StagingBlock> _stagingBlocks = new List<StagingBlock>();

        // Entry IDs
        /// <summary>
        /// The begin entry id
        /// </summary>
        private const byte BeginEntryID = 1;
        /// <summary>
        /// The no alloc begin entry
        /// </summary>
        private static readonly uint BeginEntrySize = Util.USizeOf<NoAllocBeginEntry>();

        /// <summary>
        /// The clear color target id
        /// </summary>
        private const byte ClearColorTargetID = 2;
        /// <summary>
        /// The no alloc clear color target entry
        /// </summary>
        private static readonly uint ClearColorTargetEntrySize = Util.USizeOf<NoAllocClearColorTargetEntry>();

        /// <summary>
        /// The clear depth target id
        /// </summary>
        private const byte ClearDepthTargetID = 3;
        /// <summary>
        /// The no alloc clear depth target entry
        /// </summary>
        private static readonly uint ClearDepthTargetEntrySize = Util.USizeOf<NoAllocClearDepthTargetEntry>();

        /// <summary>
        /// The draw indexed entry id
        /// </summary>
        private const byte DrawIndexedEntryID = 4;
        /// <summary>
        /// The no alloc draw indexed entry
        /// </summary>
        private static readonly uint DrawIndexedEntrySize = Util.USizeOf<NoAllocDrawIndexedEntry>();

        /// <summary>
        /// The end entry id
        /// </summary>
        private const byte EndEntryID = 5;
        /// <summary>
        /// The no alloc end entry
        /// </summary>
        private static readonly uint EndEntrySize = Util.USizeOf<NoAllocEndEntry>();

        /// <summary>
        /// The set framebuffer entry id
        /// </summary>
        private const byte SetFramebufferEntryID = 6;
        /// <summary>
        /// The no alloc set framebuffer entry
        /// </summary>
        private static readonly uint SetFramebufferEntrySize = Util.USizeOf<NoAllocSetFramebufferEntry>();

        /// <summary>
        /// The set index buffer entry id
        /// </summary>
        private const byte SetIndexBufferEntryID = 7;
        /// <summary>
        /// The no alloc set index buffer entry
        /// </summary>
        private static readonly uint SetIndexBufferEntrySize = Util.USizeOf<NoAllocSetIndexBufferEntry>();

        /// <summary>
        /// The set pipeline entry id
        /// </summary>
        private const byte SetPipelineEntryID = 8;
        /// <summary>
        /// The no alloc set pipeline entry
        /// </summary>
        private static readonly uint SetPipelineEntrySize = Util.USizeOf<NoAllocSetPipelineEntry>();

        /// <summary>
        /// The set resource set entry id
        /// </summary>
        private const byte SetResourceSetEntryID = 9;
        /// <summary>
        /// The no alloc set resource set entry
        /// </summary>
        private static readonly uint SetResourceSetEntrySize = Util.USizeOf<NoAllocSetResourceSetEntry>();

        /// <summary>
        /// The set scissor rect entry id
        /// </summary>
        private const byte SetScissorRectEntryID = 10;
        /// <summary>
        /// The no alloc set scissor rect entry
        /// </summary>
        private static readonly uint SetScissorRectEntrySize = Util.USizeOf<NoAllocSetScissorRectEntry>();

        /// <summary>
        /// The set vertex buffer entry id
        /// </summary>
        private const byte SetVertexBufferEntryID = 11;
        /// <summary>
        /// The no alloc set vertex buffer entry
        /// </summary>
        private static readonly uint SetVertexBufferEntrySize = Util.USizeOf<NoAllocSetVertexBufferEntry>();

        /// <summary>
        /// The set viewport entry id
        /// </summary>
        private const byte SetViewportEntryID = 12;
        /// <summary>
        /// The no alloc set viewport entry
        /// </summary>
        private static readonly uint SetViewportEntrySize = Util.USizeOf<NoAllocSetViewportEntry>();

        /// <summary>
        /// The update buffer entry id
        /// </summary>
        private const byte UpdateBufferEntryID = 13;
        /// <summary>
        /// The no alloc update buffer entry
        /// </summary>
        private static readonly uint UpdateBufferEntrySize = Util.USizeOf<NoAllocUpdateBufferEntry>();

        /// <summary>
        /// The copy buffer entry id
        /// </summary>
        private const byte CopyBufferEntryID = 14;
        /// <summary>
        /// The no alloc copy buffer entry
        /// </summary>
        private static readonly uint CopyBufferEntrySize = Util.USizeOf<NoAllocCopyBufferEntry>();

        /// <summary>
        /// The copy texture entry id
        /// </summary>
        private const byte CopyTextureEntryID = 15;
        /// <summary>
        /// The no alloc copy texture entry
        /// </summary>
        private static readonly uint CopyTextureEntrySize = Util.USizeOf<NoAllocCopyTextureEntry>();

        /// <summary>
        /// The resolve texture entry id
        /// </summary>
        private const byte ResolveTextureEntryID = 16;
        /// <summary>
        /// The no alloc resolve texture entry
        /// </summary>
        private static readonly uint ResolveTextureEntrySize = Util.USizeOf<NoAllocResolveTextureEntry>();

        /// <summary>
        /// The draw entry id
        /// </summary>
        private const byte DrawEntryID = 17;
        /// <summary>
        /// The no alloc draw entry
        /// </summary>
        private static readonly uint DrawEntrySize = Util.USizeOf<NoAllocDrawEntry>();

        /// <summary>
        /// The dispatch entry id
        /// </summary>
        private const byte DispatchEntryID = 18;
        /// <summary>
        /// The no alloc dispatch entry
        /// </summary>
        private static readonly uint DispatchEntrySize = Util.USizeOf<NoAllocDispatchEntry>();

        /// <summary>
        /// The draw indirect entry id
        /// </summary>
        private const byte DrawIndirectEntryID = 20;
        /// <summary>
        /// The no alloc draw indirect entry
        /// </summary>
        private static readonly uint DrawIndirectEntrySize = Util.USizeOf<NoAllocDrawIndirectEntry>();

        /// <summary>
        /// The draw indexed indirect entry id
        /// </summary>
        private const byte DrawIndexedIndirectEntryID = 21;
        /// <summary>
        /// The no alloc draw indexed indirect entry
        /// </summary>
        private static readonly uint DrawIndexedIndirectEntrySize = Util.USizeOf<NoAllocDrawIndexedIndirectEntry>();

        /// <summary>
        /// The dispatch indirect entry id
        /// </summary>
        private const byte DispatchIndirectEntryID = 22;
        /// <summary>
        /// The no alloc dispatch indirect entry
        /// </summary>
        private static readonly uint DispatchIndirectEntrySize = Util.USizeOf<NoAllocDispatchIndirectEntry>();

        /// <summary>
        /// The generate mipmaps entry id
        /// </summary>
        private const byte GenerateMipmapsEntryID = 23;
        /// <summary>
        /// The no alloc generate mipmaps entry
        /// </summary>
        private static readonly uint GenerateMipmapsEntrySize = Util.USizeOf<NoAllocGenerateMipmapsEntry>();

        /// <summary>
        /// The push debug group entry id
        /// </summary>
        private const byte PushDebugGroupEntryID = 24;
        /// <summary>
        /// The no alloc push debug group entry
        /// </summary>
        private static readonly uint PushDebugGroupEntrySize = Util.USizeOf<NoAllocPushDebugGroupEntry>();

        /// <summary>
        /// The pop debug group entry id
        /// </summary>
        private const byte PopDebugGroupEntryID = 25;
        /// <summary>
        /// The no alloc pop debug group entry
        /// </summary>
        private static readonly uint PopDebugGroupEntrySize = Util.USizeOf<NoAllocPopDebugGroupEntry>();

        /// <summary>
        /// The insert debug marker entry id
        /// </summary>
        private const byte InsertDebugMarkerEntryID = 26;
        /// <summary>
        /// The no alloc insert debug marker entry
        /// </summary>
        private static readonly uint InsertDebugMarkerEntrySize = Util.USizeOf<NoAllocInsertDebugMarkerEntry>();

        /// <summary>
        /// Gets the value of the parent
        /// </summary>
        public OpenGLCommandList Parent { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLNoAllocCommandEntryList"/> class
        /// </summary>
        /// <param name="cl">The cl</param>
        public OpenGLNoAllocCommandEntryList(OpenGLCommandList cl)
        {
            Parent = cl;
            _memoryPool = cl.Device.StagingMemoryPool;
            _currentBlock = EntryStorageBlock.New();
            _blocks.Add(_currentBlock);
        }

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            FlushStagingBlocks();
            _resourceList.Clear();
            _totalEntries = 0;
            _currentBlock = _blocks[0];
            foreach (EntryStorageBlock block in _blocks)
            {
                block.Clear();
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            FlushStagingBlocks();
            _resourceList.Clear();
            _totalEntries = 0;
            _currentBlock = _blocks[0];
            foreach (EntryStorageBlock block in _blocks)
            {
                block.Clear();
                block.Free();
            }
        }

        /// <summary>
        /// Flushes the staging blocks
        /// </summary>
        private void FlushStagingBlocks()
        {
            StagingMemoryPool pool = _memoryPool;
            foreach (StagingBlock block in _stagingBlocks)
            {
                pool.Free(block);
            }

            _stagingBlocks.Clear();
        }

        /// <summary>
        /// Gets the storage chunk using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="terminatorWritePtr">The terminator write ptr</param>
        /// <returns>The ptr</returns>
        public void* GetStorageChunk(uint size, out byte* terminatorWritePtr)
        {
            terminatorWritePtr = null;
            if (!_currentBlock.Alloc(size, out void* ptr))
            {
                int currentBlockIndex = _blocks.IndexOf(_currentBlock);
                bool anyWorked = false;
                for (int i = currentBlockIndex + 1; i < _blocks.Count; i++)
                {
                    EntryStorageBlock nextBlock = _blocks[i];
                    if (nextBlock.Alloc(size, out ptr))
                    {
                        _currentBlock = nextBlock;
                        anyWorked = true;
                        break;
                    }
                }

                if (!anyWorked)
                {
                    _currentBlock = EntryStorageBlock.New();
                    _blocks.Add(_currentBlock);
                    bool result = _currentBlock.Alloc(size, out ptr);
                    Debug.Assert(result);
                }
            }
            if (_currentBlock.RemainingSize > size)
            {
                terminatorWritePtr = (byte*)ptr + size;
            }

            return ptr;
        }

        /// <summary>
        /// Adds the entry using the specified id
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="id">The id</param>
        /// <param name="entry">The entry</param>
        public void AddEntry<T>(byte id, ref T entry) where T : struct
        {
            uint size = Util.USizeOf<T>();
            AddEntry(id, size, ref entry);
        }

        /// <summary>
        /// Adds the entry using the specified id
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="id">The id</param>
        /// <param name="sizeOfT">The size of</param>
        /// <param name="entry">The entry</param>
        public void AddEntry<T>(byte id, uint sizeOfT, ref T entry) where T : struct
        {
            Debug.Assert(sizeOfT == Unsafe.SizeOf<T>());
            uint storageSize = sizeOfT + 1; // Include ID
            void* storagePtr = GetStorageChunk(storageSize, out byte* terminatorWritePtr);
            Unsafe.Write(storagePtr, id);
            Unsafe.Write((byte*)storagePtr + 1, entry);
            if (terminatorWritePtr != null)
            {
                *terminatorWritePtr = 0;
            }
            _totalEntries += 1;
        }

        /// <summary>
        /// Executes the all using the specified executor
        /// </summary>
        /// <param name="executor">The executor</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ExecuteAll(OpenGLCommandExecutor executor)
        {
            int currentBlockIndex = 0;
            EntryStorageBlock block = _blocks[currentBlockIndex];
            uint currentOffset = 0;
            for (uint i = 0; i < _totalEntries; i++)
            {
                if (currentOffset == block.TotalSize)
                {
                    currentBlockIndex += 1;
                    block = _blocks[currentBlockIndex];
                    currentOffset = 0;
                }

                uint id = Unsafe.Read<byte>(block.BasePtr + currentOffset);
                if (id == 0)
                {
                    currentBlockIndex += 1;
                    block = _blocks[currentBlockIndex];
                    currentOffset = 0;
                    id = Unsafe.Read<byte>(block.BasePtr + currentOffset);
                }

                Debug.Assert(id != 0);
                currentOffset += 1;
                byte* entryBasePtr = block.BasePtr + currentOffset;
                switch (id)
                {
                    case BeginEntryID:
                        executor.Begin();
                        currentOffset += BeginEntrySize;
                        break;
                    case ClearColorTargetID:
                        NoAllocClearColorTargetEntry ccte = Unsafe.ReadUnaligned<NoAllocClearColorTargetEntry>(entryBasePtr);
                        executor.ClearColorTarget(ccte.Index, ccte.ClearColor);
                        currentOffset += ClearColorTargetEntrySize;
                        break;
                    case ClearDepthTargetID:
                        NoAllocClearDepthTargetEntry cdte = Unsafe.ReadUnaligned<NoAllocClearDepthTargetEntry>(entryBasePtr);
                        executor.ClearDepthStencil(cdte.Depth, cdte.Stencil);
                        currentOffset += ClearDepthTargetEntrySize;
                        break;
                    case DrawEntryID:
                        NoAllocDrawEntry de = Unsafe.ReadUnaligned<NoAllocDrawEntry>(entryBasePtr);
                        executor.Draw(de.VertexCount, de.InstanceCount, de.VertexStart, de.InstanceStart);
                        currentOffset += DrawEntrySize;
                        break;
                    case DrawIndexedEntryID:
                        NoAllocDrawIndexedEntry die = Unsafe.ReadUnaligned<NoAllocDrawIndexedEntry>(entryBasePtr);
                        executor.DrawIndexed(die.IndexCount, die.InstanceCount, die.IndexStart, die.VertexOffset, die.InstanceStart);
                        currentOffset += DrawIndexedEntrySize;
                        break;
                    case DrawIndirectEntryID:
                        NoAllocDrawIndirectEntry drawIndirectEntry = Unsafe.ReadUnaligned<NoAllocDrawIndirectEntry>(entryBasePtr);
                        executor.DrawIndirect(
                            drawIndirectEntry.IndirectBuffer.Get(_resourceList),
                            drawIndirectEntry.Offset,
                            drawIndirectEntry.DrawCount,
                            drawIndirectEntry.Stride);
                        currentOffset += DrawIndirectEntrySize;
                        break;
                    case DrawIndexedIndirectEntryID:
                        NoAllocDrawIndexedIndirectEntry diie = Unsafe.ReadUnaligned<NoAllocDrawIndexedIndirectEntry>(entryBasePtr);
                        executor.DrawIndexedIndirect(diie.IndirectBuffer.Get(_resourceList), diie.Offset, diie.DrawCount, diie.Stride);
                        currentOffset += DrawIndexedIndirectEntrySize;
                        break;
                    case DispatchEntryID:
                        NoAllocDispatchEntry dispatchEntry = Unsafe.ReadUnaligned<NoAllocDispatchEntry>(entryBasePtr);
                        executor.Dispatch(dispatchEntry.GroupCountX, dispatchEntry.GroupCountY, dispatchEntry.GroupCountZ);
                        currentOffset += DispatchEntrySize;
                        break;
                    case DispatchIndirectEntryID:
                        NoAllocDispatchIndirectEntry dispatchIndir = Unsafe.ReadUnaligned<NoAllocDispatchIndirectEntry>(entryBasePtr);
                        executor.DispatchIndirect(dispatchIndir.IndirectBuffer.Get(_resourceList), dispatchIndir.Offset);
                        currentOffset += DispatchIndirectEntrySize;
                        break;
                    case EndEntryID:
                        executor.End();
                        currentOffset += EndEntrySize;
                        break;
                    case SetFramebufferEntryID:
                        NoAllocSetFramebufferEntry sfbe = Unsafe.ReadUnaligned<NoAllocSetFramebufferEntry>(entryBasePtr);
                        executor.SetFramebuffer(sfbe.Framebuffer.Get(_resourceList));
                        currentOffset += SetFramebufferEntrySize;
                        break;
                    case SetIndexBufferEntryID:
                        NoAllocSetIndexBufferEntry sibe = Unsafe.ReadUnaligned<NoAllocSetIndexBufferEntry>(entryBasePtr);
                        executor.SetIndexBuffer(sibe.Buffer.Get(_resourceList), sibe.Format, sibe.Offset);
                        currentOffset += SetIndexBufferEntrySize;
                        break;
                    case SetPipelineEntryID:
                        NoAllocSetPipelineEntry spe = Unsafe.ReadUnaligned<NoAllocSetPipelineEntry>(entryBasePtr);
                        executor.SetPipeline(spe.Pipeline.Get(_resourceList));
                        currentOffset += SetPipelineEntrySize;
                        break;
                    case SetResourceSetEntryID:
                        NoAllocSetResourceSetEntry srse = Unsafe.ReadUnaligned<NoAllocSetResourceSetEntry>(entryBasePtr);
                        ResourceSet rs = srse.ResourceSet.Get(_resourceList);
                        uint* dynamicOffsetsPtr = srse.DynamicOffsetCount > NoAllocSetResourceSetEntry.MaxInlineDynamicOffsets
                            ? (uint*)srse.DynamicOffsets_Block.Data
                            : srse.DynamicOffsets_Inline;
                        if (srse.IsGraphics)
                        {
                            executor.SetGraphicsResourceSet(
                                srse.Slot,
                                rs,
                                srse.DynamicOffsetCount,
                                ref Unsafe.AsRef<uint>(dynamicOffsetsPtr));
                        }
                        else
                        {
                            executor.SetComputeResourceSet(
                                srse.Slot,
                                rs,
                                srse.DynamicOffsetCount,
                                ref Unsafe.AsRef<uint>(dynamicOffsetsPtr));
                        }
                        currentOffset += SetResourceSetEntrySize;
                        break;
                    case SetScissorRectEntryID:
                        NoAllocSetScissorRectEntry ssre = Unsafe.ReadUnaligned<NoAllocSetScissorRectEntry>(entryBasePtr);
                        executor.SetScissorRect(ssre.Index, ssre.X, ssre.Y, ssre.Width, ssre.Height);
                        currentOffset += SetScissorRectEntrySize;
                        break;
                    case SetVertexBufferEntryID:
                        NoAllocSetVertexBufferEntry svbe = Unsafe.ReadUnaligned<NoAllocSetVertexBufferEntry>(entryBasePtr);
                        executor.SetVertexBuffer(svbe.Index, svbe.Buffer.Get(_resourceList), svbe.Offset);
                        currentOffset += SetVertexBufferEntrySize;
                        break;
                    case SetViewportEntryID:
                        NoAllocSetViewportEntry svpe = Unsafe.ReadUnaligned<NoAllocSetViewportEntry>(entryBasePtr);
                        executor.SetViewport(svpe.Index, ref svpe.Viewport);
                        currentOffset += SetViewportEntrySize;
                        break;
                    case UpdateBufferEntryID:
                        NoAllocUpdateBufferEntry ube = Unsafe.ReadUnaligned<NoAllocUpdateBufferEntry>(entryBasePtr);
                        byte* dataPtr = (byte*)ube.StagingBlock.Data;
                        executor.UpdateBuffer(
                            ube.Buffer.Get(_resourceList),
                            ube.BufferOffsetInBytes,
                            (IntPtr)dataPtr, ube.StagingBlockSize);
                        currentOffset += UpdateBufferEntrySize;
                        break;
                    case CopyBufferEntryID:
                        NoAllocCopyBufferEntry cbe = Unsafe.ReadUnaligned<NoAllocCopyBufferEntry>(entryBasePtr);
                        executor.CopyBuffer(
                            cbe.Source.Get(_resourceList),
                            cbe.SourceOffset,
                            cbe.Destination.Get(_resourceList),
                            cbe.DestinationOffset,
                            cbe.SizeInBytes);
                        currentOffset += CopyBufferEntrySize;
                        break;
                    case CopyTextureEntryID:
                        NoAllocCopyTextureEntry cte = Unsafe.ReadUnaligned<NoAllocCopyTextureEntry>(entryBasePtr);
                        executor.CopyTexture(
                            cte.Source.Get(_resourceList),
                            cte.SrcX, cte.SrcY, cte.SrcZ,
                            cte.SrcMipLevel,
                            cte.SrcBaseArrayLayer,
                            cte.Destination.Get(_resourceList),
                            cte.DstX, cte.DstY, cte.DstZ,
                            cte.DstMipLevel,
                            cte.DstBaseArrayLayer,
                            cte.Width, cte.Height, cte.Depth,
                            cte.LayerCount);
                        currentOffset += CopyTextureEntrySize;
                        break;
                    case ResolveTextureEntryID:
                        NoAllocResolveTextureEntry rte = Unsafe.ReadUnaligned<NoAllocResolveTextureEntry>(entryBasePtr);
                        executor.ResolveTexture(rte.Source.Get(_resourceList), rte.Destination.Get(_resourceList));
                        currentOffset += ResolveTextureEntrySize;
                        break;
                    case GenerateMipmapsEntryID:
                        NoAllocGenerateMipmapsEntry gme = Unsafe.ReadUnaligned<NoAllocGenerateMipmapsEntry>(entryBasePtr);
                        executor.GenerateMipmaps(gme.Texture.Get(_resourceList));
                        currentOffset += GenerateMipmapsEntrySize;
                        break;
                    case PushDebugGroupEntryID:
                        NoAllocPushDebugGroupEntry pdge = Unsafe.ReadUnaligned<NoAllocPushDebugGroupEntry>(entryBasePtr);
                        executor.PushDebugGroup(pdge.Name.Get(_resourceList));
                        currentOffset += PushDebugGroupEntrySize;
                        break;
                    case PopDebugGroupEntryID:
                        executor.PopDebugGroup();
                        currentOffset += PopDebugGroupEntrySize;
                        break;
                    case InsertDebugMarkerEntryID:
                        NoAllocInsertDebugMarkerEntry idme = Unsafe.ReadUnaligned<NoAllocInsertDebugMarkerEntry>(entryBasePtr);
                        executor.InsertDebugMarker(idme.Name.Get(_resourceList));
                        currentOffset += InsertDebugMarkerEntrySize;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid entry ID: " + id);
                }
            }
        }

        /// <summary>
        /// Begins this instance
        /// </summary>
        public void Begin()
        {
            NoAllocBeginEntry entry = new NoAllocBeginEntry();
            AddEntry(BeginEntryID, ref entry);
        }

        /// <summary>
        /// Clears the color target using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        public void ClearColorTarget(uint index, RgbaFloat clearColor)
        {
            NoAllocClearColorTargetEntry entry = new NoAllocClearColorTargetEntry(index, clearColor);
            AddEntry(ClearColorTargetID, ref entry);
        }

        /// <summary>
        /// Clears the depth target using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <param name="stencil">The stencil</param>
        public void ClearDepthTarget(float depth, byte stencil)
        {
            NoAllocClearDepthTargetEntry entry = new NoAllocClearDepthTargetEntry(depth, stencil);
            AddEntry(ClearDepthTargetID, ref entry);
        }

        /// <summary>
        /// Draws the vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        public void Draw(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart)
        {
            NoAllocDrawEntry entry = new NoAllocDrawEntry(vertexCount, instanceCount, vertexStart, instanceStart);
            AddEntry(DrawEntryID, ref entry);
        }

        /// <summary>
        /// Draws the indexed using the specified index count
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        public void DrawIndexed(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart)
        {
            NoAllocDrawIndexedEntry entry = new NoAllocDrawIndexedEntry(indexCount, instanceCount, indexStart, vertexOffset, instanceStart);
            AddEntry(DrawIndexedEntryID, ref entry);
        }

        /// <summary>
        /// Draws the indirect using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        public void DrawIndirect(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            NoAllocDrawIndirectEntry entry = new NoAllocDrawIndirectEntry(Track(indirectBuffer), offset, drawCount, stride);
            AddEntry(DrawIndirectEntryID, ref entry);
        }

        /// <summary>
        /// Draws the indexed indirect using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        public void DrawIndexedIndirect(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            NoAllocDrawIndexedIndirectEntry entry = new NoAllocDrawIndexedIndirectEntry(Track(indirectBuffer), offset, drawCount, stride);
            AddEntry(DrawIndexedIndirectEntryID, ref entry);
        }

        /// <summary>
        /// Dispatches the group count x
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        public void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            NoAllocDispatchEntry entry = new NoAllocDispatchEntry(groupCountX, groupCountY, groupCountZ);
            AddEntry(DispatchEntryID, ref entry);
        }

        /// <summary>
        /// Dispatches the indirect using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        public void DispatchIndirect(DeviceBuffer indirectBuffer, uint offset)
        {
            NoAllocDispatchIndirectEntry entry = new NoAllocDispatchIndirectEntry(Track(indirectBuffer), offset);
            AddEntry(DispatchIndirectEntryID, ref entry);
        }

        /// <summary>
        /// Ends this instance
        /// </summary>
        public void End()
        {
            NoAllocEndEntry entry = new NoAllocEndEntry();
            AddEntry(EndEntryID, ref entry);
        }

        /// <summary>
        /// Sets the framebuffer using the specified fb
        /// </summary>
        /// <param name="fb">The fb</param>
        public void SetFramebuffer(Framebuffer fb)
        {
            NoAllocSetFramebufferEntry entry = new NoAllocSetFramebufferEntry(Track(fb));
            AddEntry(SetFramebufferEntryID, ref entry);
        }

        /// <summary>
        /// Sets the index buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <param name="offset">The offset</param>
        public void SetIndexBuffer(DeviceBuffer buffer, IndexFormat format, uint offset)
        {
            NoAllocSetIndexBufferEntry entry = new NoAllocSetIndexBufferEntry(Track(buffer), format, offset);
            AddEntry(SetIndexBufferEntryID, ref entry);
        }

        /// <summary>
        /// Sets the pipeline using the specified pipeline
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        public void SetPipeline(Pipeline pipeline)
        {
            NoAllocSetPipelineEntry entry = new NoAllocSetPipelineEntry(Track(pipeline));
            AddEntry(SetPipelineEntryID, ref entry);
        }

        /// <summary>
        /// Sets the graphics resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        public void SetGraphicsResourceSet(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets)
        {
            SetResourceSet(slot, rs, dynamicOffsetCount, ref dynamicOffsets, isGraphics: true);
        }

        /// <summary>
        /// Sets the resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        /// <param name="isGraphics">The is graphics</param>
        private void SetResourceSet(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets, bool isGraphics)
        {
            NoAllocSetResourceSetEntry entry;

            if (dynamicOffsetCount > NoAllocSetResourceSetEntry.MaxInlineDynamicOffsets)
            {
                StagingBlock block = _memoryPool.GetStagingBlock(dynamicOffsetCount * sizeof(uint));
                _stagingBlocks.Add(block);
                for (uint i = 0; i < dynamicOffsetCount; i++)
                {
                    *((uint*)block.Data + i) = Unsafe.Add(ref dynamicOffsets, (int)i);
                }

                entry = new NoAllocSetResourceSetEntry(slot, Track(rs), isGraphics, block);
            }
            else
            {
                entry = new NoAllocSetResourceSetEntry(slot, Track(rs), isGraphics, dynamicOffsetCount, ref dynamicOffsets);
            }

            AddEntry(SetResourceSetEntryID, ref entry);
        }

        /// <summary>
        /// Sets the compute resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        public void SetComputeResourceSet(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets)
        {
            SetResourceSet(slot, rs, dynamicOffsetCount, ref dynamicOffsets, isGraphics: false);
        }

        /// <summary>
        /// Sets the scissor rect using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void SetScissorRect(uint index, uint x, uint y, uint width, uint height)
        {
            NoAllocSetScissorRectEntry entry = new NoAllocSetScissorRectEntry(index, x, y, width, height);
            AddEntry(SetScissorRectEntryID, ref entry);
        }

        /// <summary>
        /// Sets the vertex buffer using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        public void SetVertexBuffer(uint index, DeviceBuffer buffer, uint offset)
        {
            NoAllocSetVertexBufferEntry entry = new NoAllocSetVertexBufferEntry(index, Track(buffer), offset);
            AddEntry(SetVertexBufferEntryID, ref entry);
        }

        /// <summary>
        /// Sets the viewport using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        public void SetViewport(uint index, ref Viewport viewport)
        {
            NoAllocSetViewportEntry entry = new NoAllocSetViewportEntry(index, ref viewport);
            AddEntry(SetViewportEntryID, ref entry);
        }

        /// <summary>
        /// Resolves the texture using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        public void ResolveTexture(Texture source, Texture destination)
        {
            NoAllocResolveTextureEntry entry = new NoAllocResolveTextureEntry(Track(source), Track(destination));
            AddEntry(ResolveTextureEntryID, ref entry);
        }

        /// <summary>
        /// Updates the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        public void UpdateBuffer(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes)
        {
            StagingBlock stagingBlock = _memoryPool.Stage(source, sizeInBytes);
            _stagingBlocks.Add(stagingBlock);
            NoAllocUpdateBufferEntry entry = new NoAllocUpdateBufferEntry(Track(buffer), bufferOffsetInBytes, stagingBlock, sizeInBytes);
            AddEntry(UpdateBufferEntryID, ref entry);
        }

        /// <summary>
        /// Copies the buffer using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destination">The destination</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        public void CopyBuffer(DeviceBuffer source, uint sourceOffset, DeviceBuffer destination, uint destinationOffset, uint sizeInBytes)
        {
            NoAllocCopyBufferEntry entry = new NoAllocCopyBufferEntry(
                Track(source),
                sourceOffset,
                Track(destination),
                destinationOffset,
                sizeInBytes);
            AddEntry(CopyBufferEntryID, ref entry);
        }

        /// <summary>
        /// Copies the texture using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="srcX">The src</param>
        /// <param name="srcY">The src</param>
        /// <param name="srcZ">The src</param>
        /// <param name="srcMipLevel">The src mip level</param>
        /// <param name="srcBaseArrayLayer">The src base array layer</param>
        /// <param name="destination">The destination</param>
        /// <param name="dstX">The dst</param>
        /// <param name="dstY">The dst</param>
        /// <param name="dstZ">The dst</param>
        /// <param name="dstMipLevel">The dst mip level</param>
        /// <param name="dstBaseArrayLayer">The dst base array layer</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="layerCount">The layer count</param>
        public void CopyTexture(
            Texture source,
            uint srcX, uint srcY, uint srcZ,
            uint srcMipLevel,
            uint srcBaseArrayLayer,
            Texture destination,
            uint dstX, uint dstY, uint dstZ,
            uint dstMipLevel,
            uint dstBaseArrayLayer,
            uint width, uint height, uint depth,
            uint layerCount)
        {
            NoAllocCopyTextureEntry entry = new NoAllocCopyTextureEntry(
                Track(source),
                srcX, srcY, srcZ,
                srcMipLevel,
                srcBaseArrayLayer,
                Track(destination),
                dstX, dstY, dstZ,
                dstMipLevel,
                dstBaseArrayLayer,
                width, height, depth,
                layerCount);
            AddEntry(CopyTextureEntryID, ref entry);
        }

        /// <summary>
        /// Generates the mipmaps using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public void GenerateMipmaps(Texture texture)
        {
            NoAllocGenerateMipmapsEntry entry = new NoAllocGenerateMipmapsEntry(Track(texture));
            AddEntry(GenerateMipmapsEntryID, ref entry);
        }

        /// <summary>
        /// Pushes the debug group using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        public void PushDebugGroup(string name)
        {
            NoAllocPushDebugGroupEntry entry = new NoAllocPushDebugGroupEntry(Track(name));
            AddEntry(PushDebugGroupEntryID, ref entry);
        }

        /// <summary>
        /// Pops the debug group
        /// </summary>
        public void PopDebugGroup()
        {
            NoAllocPopDebugGroupEntry entry = new NoAllocPopDebugGroupEntry();
            AddEntry(PopDebugGroupEntryID, ref entry);
        }

        /// <summary>
        /// Inserts the debug marker using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        public void InsertDebugMarker(string name)
        {
            NoAllocInsertDebugMarkerEntry entry = new NoAllocInsertDebugMarkerEntry(Track(name));
            AddEntry(InsertDebugMarkerEntryID, ref entry);
        }

        /// <summary>
        /// Tracks the item
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="item">The item</param>
        /// <returns>A tracked of t</returns>
        private Tracked<T> Track<T>(T item) where T : class
        {
            return new Tracked<T>(_resourceList, item);
        }

        /// <summary>
        /// The entry storage block
        /// </summary>
        private struct EntryStorageBlock : IEquatable<EntryStorageBlock>
        {
            /// <summary>
            /// The default storage block size
            /// </summary>
            private const int DefaultStorageBlockSize = 40000;
            /// <summary>
            /// The bytes
            /// </summary>
            private readonly byte[] _bytes;
            /// <summary>
            /// The gc handle
            /// </summary>
            private readonly GCHandle _gcHandle;
            /// <summary>
            /// The base ptr
            /// </summary>
            public readonly byte* BasePtr;

            /// <summary>
            /// The unused start
            /// </summary>
            private uint _unusedStart;
            /// <summary>
            /// Gets the value of the remaining size
            /// </summary>
            public uint RemainingSize => (uint)_bytes.Length - _unusedStart;

            /// <summary>
            /// Gets the value of the total size
            /// </summary>
            public uint TotalSize => (uint)_bytes.Length;

            /// <summary>
            /// Describes whether this instance alloc
            /// </summary>
            /// <param name="size">The size</param>
            /// <param name="ptr">The ptr</param>
            /// <returns>The bool</returns>
            public bool Alloc(uint size, out void* ptr)
            {
                if (RemainingSize < size)
                {
                    ptr = null;
                    return false;
                }
                else
                {
                    ptr = (BasePtr + _unusedStart);
                    _unusedStart += size;
                    return true;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EntryStorageBlock"/> class
            /// </summary>
            /// <param name="storageBlockSize">The storage block size</param>
            private EntryStorageBlock(int storageBlockSize)
            {
                _bytes = new byte[storageBlockSize];
                _gcHandle = GCHandle.Alloc(_bytes, GCHandleType.Pinned);
                BasePtr = (byte*)_gcHandle.AddrOfPinnedObject().ToPointer();
                _unusedStart = 0;
            }

            /// <summary>
            /// News
            /// </summary>
            /// <returns>The entry storage block</returns>
            public static EntryStorageBlock New()
            {
                return new EntryStorageBlock(DefaultStorageBlockSize);
            }

            /// <summary>
            /// Frees this instance
            /// </summary>
            public void Free()
            {
                _gcHandle.Free();
            }

            /// <summary>
            /// Clears this instance
            /// </summary>
            internal void Clear()
            {
                _unusedStart = 0;
                Util.ClearArray(_bytes);
            }

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The bool</returns>
            public bool Equals(EntryStorageBlock other)
            {
                return _bytes == other._bytes;
            }
        }
    }

    /// <summary>
    /// A handle for an object stored in some List.
    /// </summary>
    /// <typeparam name="T">The type of object to track.</typeparam>
    internal struct Tracked<T> where T : class
    {
        /// <summary>
        /// The index
        /// </summary>
        private readonly int _index;

        /// <summary>
        /// Gets the list
        /// </summary>
        /// <param name="list">The list</param>
        /// <returns>The</returns>
        public T Get(List<object> list) => (T)list[_index];

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="item">The item</param>
        public Tracked(List<object> list, T item)
        {
            _index = list.Count;
            list.Add(item);
        }
    }
}
