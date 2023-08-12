using System;
using System.Diagnostics;
using Alis.Core.Graphic.Backends.Metal;

namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl command list class
    /// </summary>
    /// <seealso cref="CommandList"/>
    internal unsafe class MTLCommandList : CommandList
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly MTLGraphicsDevice _gd;
        /// <summary>
        /// The cb
        /// </summary>
        private MTLCommandBuffer _cb;
        /// <summary>
        /// The mtl framebuffer
        /// </summary>
        private MTLFramebufferBase _mtlFramebuffer;
        /// <summary>
        /// The viewport count
        /// </summary>
        private uint _viewportCount;
        /// <summary>
        /// The current framebuffer ever active
        /// </summary>
        private bool _currentFramebufferEverActive;
        /// <summary>
        /// The rce
        /// </summary>
        private MTLRenderCommandEncoder _rce;
        /// <summary>
        /// The bce
        /// </summary>
        private MTLBlitCommandEncoder _bce;
        /// <summary>
        /// The cce
        /// </summary>
        private MTLComputeCommandEncoder _cce;
        /// <summary>
        /// The rgba float
        /// </summary>
        private RgbaFloat?[] _clearColors = Array.Empty<RgbaFloat?>();
        /// <summary>
        /// The clear depth
        /// </summary>
        private (float depth, byte stencil)? _clearDepth;
        /// <summary>
        /// The index buffer
        /// </summary>
        private MTLBuffer _indexBuffer;
        /// <summary>
        /// The ib offset
        /// </summary>
        private uint _ibOffset;
        /// <summary>
        /// The index type
        /// </summary>
        private MTLIndexType _indexType;
        /// <summary>
        /// The graphics pipeline
        /// </summary>
        private new MTLPipeline _graphicsPipeline;
        /// <summary>
        /// The graphics pipeline changed
        /// </summary>
        private bool _graphicsPipelineChanged;
        /// <summary>
        /// The compute pipeline
        /// </summary>
        private new MTLPipeline _computePipeline;
        /// <summary>
        /// The compute pipeline changed
        /// </summary>
        private bool _computePipelineChanged;
        /// <summary>
        /// The mtl viewport
        /// </summary>
        private MTLViewport[] _viewports = Array.Empty<MTLViewport>();
        /// <summary>
        /// The viewports changed
        /// </summary>
        private bool _viewportsChanged;
        /// <summary>
        /// The mtl scissor rect
        /// </summary>
        private MTLScissorRect[] _scissorRects = Array.Empty<MTLScissorRect>();
        /// <summary>
        /// The scissor rects changed
        /// </summary>
        private bool _scissorRectsChanged;
        /// <summary>
        /// The graphics resource set count
        /// </summary>
        private uint _graphicsResourceSetCount;
        /// <summary>
        /// The graphics resource sets
        /// </summary>
        private BoundResourceSetInfo[] _graphicsResourceSets;
        /// <summary>
        /// The graphics resource sets active
        /// </summary>
        private bool[] _graphicsResourceSetsActive;
        /// <summary>
        /// The compute resource set count
        /// </summary>
        private uint _computeResourceSetCount;
        /// <summary>
        /// The compute resource sets
        /// </summary>
        private BoundResourceSetInfo[] _computeResourceSets;
        /// <summary>
        /// The compute resource sets active
        /// </summary>
        private bool[] _computeResourceSetsActive;
        /// <summary>
        /// The vertex buffer count
        /// </summary>
        private uint _vertexBufferCount;
        /// <summary>
        /// The non vertex buffer count
        /// </summary>
        private uint _nonVertexBufferCount;
        /// <summary>
        /// The vertex buffers
        /// </summary>
        private MTLBuffer[] _vertexBuffers;
        /// <summary>
        /// The vb offsets
        /// </summary>
        private uint[] _vbOffsets;
        /// <summary>
        /// The vertex buffers active
        /// </summary>
        private bool[] _vertexBuffersActive;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the command buffer
        /// </summary>
        public MTLCommandBuffer CommandBuffer => _cb;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLCommandList"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        public MTLCommandList(ref CommandListDescription description, MTLGraphicsDevice gd)
            : base(ref description, gd.Features, gd.UniformBufferMinOffsetAlignment, gd.StructuredBufferMinOffsetAlignment)
        {
            _gd = gd;
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Commits this instance
        /// </summary>
        /// <returns>The ret</returns>
        public MTLCommandBuffer Commit()
        {
            _cb.commit();
            MTLCommandBuffer ret = _cb;
            _cb = default(MTLCommandBuffer);
            return ret;
        }

        /// <summary>
        /// Begins this instance
        /// </summary>
        public override void Begin()
        {
            if (_cb.NativePtr != IntPtr.Zero)
            {
                ObjectiveCRuntime.release(_cb.NativePtr);
            }

            using (NSAutoreleasePool.Begin())
            {
                _cb = _gd.CommandQueue.commandBuffer();
                ObjectiveCRuntime.retain(_cb.NativePtr);
            }

            ClearCachedState();
        }

        /// <summary>
        /// Clears the color target core using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        private protected override void ClearColorTargetCore(uint index, RgbaFloat clearColor)
        {
            EnsureNoRenderPass();
            _clearColors[index] = clearColor;
        }

        /// <summary>
        /// Clears the depth stencil core using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <param name="stencil">The stencil</param>
        private protected override void ClearDepthStencilCore(float depth, byte stencil)
        {
            EnsureNoRenderPass();
            _clearDepth = (depth, stencil);
        }

        /// <summary>
        /// Dispatches the group count x
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        public override void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            PreComputeCommand();
            _cce.dispatchThreadGroups(
                new MTLSize(groupCountX, groupCountY, groupCountZ),
                _computePipeline.ThreadsPerThreadgroup);
        }

        /// <summary>
        /// Draws the core using the specified vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        private protected override void DrawCore(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart)
        {
            if (PreDrawCommand())
            {
                if (instanceStart == 0)
                {
                    _rce.drawPrimitives(
                        _graphicsPipeline.PrimitiveType,
                        (UIntPtr)vertexStart,
                        (UIntPtr)vertexCount,
                        (UIntPtr)instanceCount);
                }
                else
                {
                    _rce.drawPrimitives(
                        _graphicsPipeline.PrimitiveType,
                        (UIntPtr)vertexStart,
                        (UIntPtr)vertexCount,
                        (UIntPtr)instanceCount,
                        (UIntPtr)instanceStart);

                }
            }
        }

        /// <summary>
        /// Draws the indexed core using the specified index count
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        private protected override void DrawIndexedCore(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart)
        {
            if (PreDrawCommand())
            {
                uint indexSize = _indexType == MTLIndexType.UInt16 ? 2u : 4u;
                uint indexBufferOffset = (indexSize * indexStart) + _ibOffset;

                if (vertexOffset == 0 && instanceStart == 0)
                {
                    _rce.drawIndexedPrimitives(
                        _graphicsPipeline.PrimitiveType,
                        (UIntPtr)indexCount,
                        _indexType,
                        _indexBuffer.DeviceBuffer,
                        (UIntPtr)indexBufferOffset,
                        (UIntPtr)instanceCount);
                }
                else
                {
                    _rce.drawIndexedPrimitives(
                        _graphicsPipeline.PrimitiveType,
                        (UIntPtr)indexCount,
                        _indexType,
                        _indexBuffer.DeviceBuffer,
                        (UIntPtr)indexBufferOffset,
                        (UIntPtr)instanceCount,
                        (IntPtr)vertexOffset,
                        (UIntPtr)instanceStart);
                }
            }
        }
        /// <summary>
        /// Describes whether this instance pre draw command
        /// </summary>
        /// <returns>The bool</returns>
        private bool PreDrawCommand()
        {
            if (EnsureRenderPass())
            {
                if (_viewportsChanged)
                {
                    FlushViewports();
                    _viewportsChanged = false;
                }
                if (_scissorRectsChanged && _graphicsPipeline.ScissorTestEnabled)
                {
                    FlushScissorRects();
                    _scissorRectsChanged = false;
                }
                if (_graphicsPipelineChanged)
                {
                    Debug.Assert(_graphicsPipeline != null);
                    _rce.setRenderPipelineState(_graphicsPipeline.RenderPipelineState);
                    _rce.setCullMode(_graphicsPipeline.CullMode);
                    _rce.setFrontFacing(_graphicsPipeline.FrontFace);
                    _rce.setTriangleFillMode(_graphicsPipeline.FillMode);
                    RgbaFloat blendColor = _graphicsPipeline.BlendColor;
                    _rce.setBlendColor(blendColor.R, blendColor.G, blendColor.B, blendColor.A);
                    if (_framebuffer.DepthTarget != null)
                    {
                        _rce.setDepthStencilState(_graphicsPipeline.DepthStencilState);
                        _rce.setDepthClipMode(_graphicsPipeline.DepthClipMode);
                        _rce.setStencilReferenceValue(_graphicsPipeline.StencilReference);
                    }
                }

                for (uint i = 0; i < _graphicsResourceSetCount; i++)
                {
                    if (!_graphicsResourceSetsActive[i])
                    {
                        ActivateGraphicsResourceSet(i, _graphicsResourceSets[i]);
                        _graphicsResourceSetsActive[i] = true;
                    }
                }

                for (uint i = 0; i < _vertexBufferCount; i++)
                {
                    if (!_vertexBuffersActive[i])
                    {
                        UIntPtr index = (UIntPtr)(_graphicsPipeline.ResourceBindingModel == ResourceBindingModel.Improved
                            ? _nonVertexBufferCount + i
                            : i);
                        _rce.setVertexBuffer(
                            _vertexBuffers[i].DeviceBuffer,
                            (UIntPtr)_vbOffsets[i],
                            index);
                    }
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// Flushes the viewports
        /// </summary>
        private void FlushViewports()
        {
            if (_gd.MetalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v3))
            {
                fixed (MTLViewport* viewportsPtr = &_viewports[0])
                {
                    _rce.setViewports(viewportsPtr, (UIntPtr)_viewportCount);
                }
            }
            else
            {
                _rce.setViewport(_viewports[0]);
            }
        }

        /// <summary>
        /// Flushes the scissor rects
        /// </summary>
        private void FlushScissorRects()
        {
            if (_gd.MetalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v3))
            {
                fixed (MTLScissorRect* scissorRectsPtr = &_scissorRects[0])
                {
                    _rce.setScissorRects(scissorRectsPtr, (UIntPtr)_viewportCount);
                }
            }
            else
            {
                _rce.setScissorRect(_scissorRects[0]);
            }
        }

        /// <summary>
        /// Pres the compute command
        /// </summary>
        private void PreComputeCommand()
        {
            EnsureComputeEncoder();
            if (_computePipelineChanged)
            {
                _cce.setComputePipelineState(_computePipeline.ComputePipelineState);
            }

            for (uint i = 0; i < _computeResourceSetCount; i++)
            {
                if (!_computeResourceSetsActive[i])
                {
                    ActivateComputeResourceSet(i, _computeResourceSets[i]);
                    _computeResourceSetsActive[i] = true;
                }
            }
        }

        /// <summary>
        /// Ends this instance
        /// </summary>
        public override void End()
        {
            EnsureNoBlitEncoder();
            EnsureNoComputeEncoder();

            if (!_currentFramebufferEverActive && _mtlFramebuffer != null)
            {
                BeginCurrentRenderPass();
            }
            EnsureNoRenderPass();
        }

        /// <summary>
        /// Sets the pipeline core using the specified pipeline
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        private protected override void SetPipelineCore(Pipeline pipeline)
        {
            if (pipeline.IsComputePipeline)
            {
                _computePipeline = Util.AssertSubtype<Pipeline, MTLPipeline>(pipeline);
                _computeResourceSetCount = (uint)_computePipeline.ResourceLayouts.Length;
                Util.EnsureArrayMinimumSize(ref _computeResourceSets, _computeResourceSetCount);
                Util.EnsureArrayMinimumSize(ref _computeResourceSetsActive, _computeResourceSetCount);
                Util.ClearArray(_computeResourceSetsActive);
                _computePipelineChanged = true;
            }
            else
            {
                _graphicsPipeline = Util.AssertSubtype<Pipeline, MTLPipeline>(pipeline);
                _graphicsResourceSetCount = (uint)_graphicsPipeline.ResourceLayouts.Length;
                Util.EnsureArrayMinimumSize(ref _graphicsResourceSets, _graphicsResourceSetCount);
                Util.EnsureArrayMinimumSize(ref _graphicsResourceSetsActive, _graphicsResourceSetCount);
                Util.ClearArray(_graphicsResourceSetsActive);

                _nonVertexBufferCount = _graphicsPipeline.NonVertexBufferCount;

                _vertexBufferCount = _graphicsPipeline.VertexBufferCount;
                Util.EnsureArrayMinimumSize(ref _vertexBuffers, _vertexBufferCount);
                Util.EnsureArrayMinimumSize(ref _vbOffsets, _vertexBufferCount);
                Util.EnsureArrayMinimumSize(ref _vertexBuffersActive, _vertexBufferCount);
                Util.ClearArray(_vertexBuffersActive);

                _graphicsPipelineChanged = true;
            }
        }

        /// <summary>
        /// Sets the scissor rect using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public override void SetScissorRect(uint index, uint x, uint y, uint width, uint height)
        {
            _scissorRectsChanged = true;
            _scissorRects[index] = new MTLScissorRect(x, y, width, height);
        }

        /// <summary>
        /// Sets the viewport using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        public override void SetViewport(uint index, ref Viewport viewport)
        {
            _viewportsChanged = true;
            _viewports[index] = new MTLViewport(
                viewport.X,
                viewport.Y,
                viewport.Width,
                viewport.Height,
                viewport.MinDepth,
                viewport.MaxDepth);
        }

        /// <summary>
        /// Updates the buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        private protected override void UpdateBufferCore(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes)
        {
            bool useComputeCopy = (bufferOffsetInBytes % 4 != 0)
                || (sizeInBytes % 4 != 0 && bufferOffsetInBytes != 0 && sizeInBytes != buffer.SizeInBytes);

            MTLBuffer dstMTLBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(buffer);
            // TODO: Cache these, and rely on the command buffer's completion callback to add them back to a shared pool.
            MTLBuffer copySrc = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(
                _gd.ResourceFactory.CreateBuffer(new BufferDescription(sizeInBytes, BufferUsage.Staging)));
            _gd.UpdateBuffer(copySrc, 0, source, sizeInBytes);

            if (useComputeCopy)
            {
                CopyBufferCore(copySrc, 0, buffer, bufferOffsetInBytes, sizeInBytes);
            }
            else
            {
                Debug.Assert(bufferOffsetInBytes % 4 == 0);
                uint sizeRoundFactor = (4 - (sizeInBytes % 4)) % 4;
                EnsureBlitEncoder();
                _bce.copy(
                    copySrc.DeviceBuffer, UIntPtr.Zero,
                    dstMTLBuffer.DeviceBuffer, (UIntPtr)bufferOffsetInBytes,
                    (UIntPtr)(sizeInBytes + sizeRoundFactor));
            }

            copySrc.Dispose();
        }

        /// <summary>
        /// Copies the buffer core using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destination">The destination</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        protected override void CopyBufferCore(
            DeviceBuffer source,
            uint sourceOffset,
            DeviceBuffer destination,
            uint destinationOffset,
            uint sizeInBytes)
        {
            MTLBuffer mtlSrc = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(source);
            MTLBuffer mtlDst = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(destination);

            if (sourceOffset % 4 != 0 || destinationOffset % 4 != 0 || sizeInBytes % 4 != 0)
            {
                // Unaligned copy -- use special compute shader.
                EnsureComputeEncoder();
                _cce.setComputePipelineState(_gd.GetUnalignedBufferCopyPipeline());
                _cce.setBuffer(mtlSrc.DeviceBuffer, UIntPtr.Zero, (UIntPtr)0);
                _cce.setBuffer(mtlDst.DeviceBuffer, UIntPtr.Zero, (UIntPtr)1);

                MTLUnalignedBufferCopyInfo copyInfo;
                copyInfo.SourceOffset = sourceOffset;
                copyInfo.DestinationOffset = destinationOffset;
                copyInfo.CopySize = sizeInBytes;

                _cce.setBytes(&copyInfo, (UIntPtr)sizeof(MTLUnalignedBufferCopyInfo), (UIntPtr)2);
                _cce.dispatchThreadGroups(new MTLSize(1, 1, 1), new MTLSize(1, 1, 1));
            }
            else
            {
                EnsureBlitEncoder();
                _bce.copy(
                    mtlSrc.DeviceBuffer, (UIntPtr)sourceOffset,
                    mtlDst.DeviceBuffer, (UIntPtr)destinationOffset,
                    (UIntPtr)sizeInBytes);
            }
        }

        /// <summary>
        /// Copies the texture core using the specified source
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
        protected override void CopyTextureCore(
            Texture source, uint srcX, uint srcY, uint srcZ, uint srcMipLevel, uint srcBaseArrayLayer,
            Texture destination, uint dstX, uint dstY, uint dstZ, uint dstMipLevel, uint dstBaseArrayLayer,
            uint width, uint height, uint depth, uint layerCount)
        {
            EnsureBlitEncoder();
            MTLTexture srcMTLTexture = Util.AssertSubtype<Texture, MTLTexture>(source);
            MTLTexture dstMTLTexture = Util.AssertSubtype<Texture, MTLTexture>(destination);

            bool srcIsStaging = (source.Usage & TextureUsage.Staging) != 0;
            bool dstIsStaging = (destination.Usage & TextureUsage.Staging) != 0;
            if (srcIsStaging && !dstIsStaging)
            {
                // Staging -> Normal
                Metal.MTLBuffer srcBuffer = srcMTLTexture.StagingBuffer;
                Metal.MTLTexture dstTexture = dstMTLTexture.DeviceTexture;

                Util.GetMipDimensions(srcMTLTexture, srcMipLevel, out uint mipWidth, out uint mipHeight, out uint mipDepth);
                for (uint layer = 0; layer < layerCount; layer++)
                {
                    uint blockSize = FormatHelpers.IsCompressedFormat(srcMTLTexture.Format) ? 4u : 1u;
                    uint compressedSrcX = srcX / blockSize;
                    uint compressedSrcY = srcY / blockSize;
                    uint blockSizeInBytes = blockSize == 1
                        ? FormatSizeHelpers.GetSizeInBytes(srcMTLTexture.Format)
                        : FormatHelpers.GetBlockSizeInBytes(srcMTLTexture.Format);

                    ulong srcSubresourceBase = Util.ComputeSubresourceOffset(
                        srcMTLTexture,
                        srcMipLevel,
                        layer + srcBaseArrayLayer);
                    srcMTLTexture.GetSubresourceLayout(
                        srcMipLevel,
                        srcBaseArrayLayer + layer,
                        out uint srcRowPitch,
                        out uint srcDepthPitch);
                    ulong sourceOffset = srcSubresourceBase
                        + srcDepthPitch * srcZ
                        + srcRowPitch * compressedSrcY
                        + blockSizeInBytes * compressedSrcX;

                    uint copyWidth = width > mipWidth && width <= blockSize
                        ? mipWidth
                        : width;

                    uint copyHeight = height > mipHeight && height <= blockSize
                        ? mipHeight
                        : height;

                    MTLSize sourceSize = new MTLSize(copyWidth, copyHeight, depth);
                    if (dstMTLTexture.Type != TextureType.Texture3D)
                    {
                        srcDepthPitch = 0;
                    }
                    _bce.copyFromBuffer(
                        srcBuffer,
                        (UIntPtr)sourceOffset,
                        (UIntPtr)srcRowPitch,
                        (UIntPtr)srcDepthPitch,
                        sourceSize,
                        dstTexture,
                        (UIntPtr)(dstBaseArrayLayer + layer),
                        (UIntPtr)dstMipLevel,
                        new MTLOrigin(dstX, dstY, dstZ));
                }
            }
            else if (srcIsStaging && dstIsStaging)
            {
                for (uint layer = 0; layer < layerCount; layer++)
                {
                    // Staging -> Staging
                    ulong srcSubresourceBase = Util.ComputeSubresourceOffset(
                        srcMTLTexture,
                        srcMipLevel,
                        layer + srcBaseArrayLayer);
                    srcMTLTexture.GetSubresourceLayout(
                        srcMipLevel,
                        srcBaseArrayLayer + layer,
                        out uint srcRowPitch,
                        out uint srcDepthPitch);

                    ulong dstSubresourceBase = Util.ComputeSubresourceOffset(
                        dstMTLTexture,
                        dstMipLevel,
                        layer + dstBaseArrayLayer);
                    dstMTLTexture.GetSubresourceLayout(
                        dstMipLevel,
                        dstBaseArrayLayer + layer,
                        out uint dstRowPitch,
                        out uint dstDepthPitch);

                    uint blockSize = FormatHelpers.IsCompressedFormat(dstMTLTexture.Format) ? 4u : 1u;
                    if (blockSize == 1)
                    {
                        uint pixelSize = FormatSizeHelpers.GetSizeInBytes(dstMTLTexture.Format);
                        uint copySize = width * pixelSize;
                        for (uint zz = 0; zz < depth; zz++)
                            for (uint yy = 0; yy < height; yy++)
                            {
                                ulong srcRowOffset = srcSubresourceBase
                                    + srcDepthPitch * (zz + srcZ)
                                    + srcRowPitch * (yy + srcY)
                                    + pixelSize * srcX;
                                ulong dstRowOffset = dstSubresourceBase
                                    + dstDepthPitch * (zz + dstZ)
                                    + dstRowPitch * (yy + dstY)
                                    + pixelSize * dstX;
                                _bce.copy(
                                    srcMTLTexture.StagingBuffer,
                                    (UIntPtr)srcRowOffset,
                                    dstMTLTexture.StagingBuffer,
                                    (UIntPtr)dstRowOffset,
                                    (UIntPtr)copySize);
                            }
                    }
                    else // blockSize != 1
                    {
                        uint paddedWidth = Math.Max(blockSize, width);
                        uint paddedHeight = Math.Max(blockSize, height);
                        uint numRows = FormatHelpers.GetNumRows(paddedHeight, srcMTLTexture.Format);
                        uint rowPitch = FormatHelpers.GetRowPitch(paddedWidth, srcMTLTexture.Format);

                        uint compressedSrcX = srcX / 4;
                        uint compressedSrcY = srcY / 4;
                        uint compressedDstX = dstX / 4;
                        uint compressedDstY = dstY / 4;
                        uint blockSizeInBytes = FormatHelpers.GetBlockSizeInBytes(srcMTLTexture.Format);

                        for (uint zz = 0; zz < depth; zz++)
                            for (uint row = 0; row < numRows; row++)
                            {
                                ulong srcRowOffset = srcSubresourceBase
                                    + srcDepthPitch * (zz + srcZ)
                                    + srcRowPitch * (row + compressedSrcY)
                                    + blockSizeInBytes * compressedSrcX;
                                ulong dstRowOffset = dstSubresourceBase
                                    + dstDepthPitch * (zz + dstZ)
                                    + dstRowPitch * (row + compressedDstY)
                                    + blockSizeInBytes * compressedDstX;
                                _bce.copy(
                                    srcMTLTexture.StagingBuffer,
                                    (UIntPtr)srcRowOffset,
                                    dstMTLTexture.StagingBuffer,
                                    (UIntPtr)dstRowOffset,
                                    (UIntPtr)rowPitch);
                            }
                    }
                }
            }
            else if (!srcIsStaging && dstIsStaging)
            {
                // Normal -> Staging
                MTLOrigin srcOrigin = new MTLOrigin(srcX, srcY, srcZ);
                MTLSize srcSize = new MTLSize(width, height, depth);
                for (uint layer = 0; layer < layerCount; layer++)
                {
                    dstMTLTexture.GetSubresourceLayout(
                        dstMipLevel,
                        dstBaseArrayLayer + layer,
                        out uint dstBytesPerRow,
                        out uint dstBytesPerImage);

                    Util.GetMipDimensions(srcMTLTexture, dstMipLevel, out uint mipWidth, out uint mipHeight, out uint mipDepth);
                    uint blockSize = FormatHelpers.IsCompressedFormat(srcMTLTexture.Format) ? 4u : 1u;
                    uint bufferRowLength = Math.Max(mipWidth, blockSize);
                    uint bufferImageHeight = Math.Max(mipHeight, blockSize);
                    uint compressedDstX = dstX / blockSize;
                    uint compressedDstY = dstY / blockSize;
                    uint blockSizeInBytes = blockSize == 1
                        ? FormatSizeHelpers.GetSizeInBytes(srcMTLTexture.Format)
                        : FormatHelpers.GetBlockSizeInBytes(srcMTLTexture.Format);
                    uint rowPitch = FormatHelpers.GetRowPitch(bufferRowLength, srcMTLTexture.Format);
                    uint depthPitch = FormatHelpers.GetDepthPitch(rowPitch, bufferImageHeight, srcMTLTexture.Format);

                    ulong dstOffset = Util.ComputeSubresourceOffset(dstMTLTexture, dstMipLevel, dstBaseArrayLayer + layer)
                        + (dstZ * depthPitch)
                        + (compressedDstY * rowPitch)
                        + (compressedDstX * blockSizeInBytes);

                    _bce.copyTextureToBuffer(
                        srcMTLTexture.DeviceTexture,
                        (UIntPtr)(srcBaseArrayLayer + layer),
                        (UIntPtr)srcMipLevel,
                        srcOrigin,
                        srcSize,
                        dstMTLTexture.StagingBuffer,
                        (UIntPtr)dstOffset,
                        (UIntPtr)dstBytesPerRow,
                        (UIntPtr)dstBytesPerImage);
                }
            }
            else
            {
                // Normal -> Normal
                for (uint layer = 0; layer < layerCount; layer++)
                {
                    _bce.copyFromTexture(
                        srcMTLTexture.DeviceTexture,
                        (UIntPtr)(srcBaseArrayLayer + layer),
                        (UIntPtr)srcMipLevel,
                        new MTLOrigin(srcX, srcY, srcZ),
                        new MTLSize(width, height, depth),
                        dstMTLTexture.DeviceTexture,
                        (UIntPtr)(dstBaseArrayLayer + layer),
                        (UIntPtr)dstMipLevel,
                        new MTLOrigin(dstX, dstY, dstZ));
                }
            }
        }

        /// <summary>
        /// Generates the mipmaps core using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        private protected override void GenerateMipmapsCore(Texture texture)
        {
            Debug.Assert(texture.MipLevels > 1);
            EnsureBlitEncoder();
            MTLTexture mtlTex = Util.AssertSubtype<Texture, MTLTexture>(texture);
            _bce.generateMipmapsForTexture(mtlTex.DeviceTexture);
        }

        /// <summary>
        /// Dispatches the indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        protected override void DispatchIndirectCore(DeviceBuffer indirectBuffer, uint offset)
        {
            MTLBuffer mtlBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(indirectBuffer);
            PreComputeCommand();
            _cce.dispatchThreadgroupsWithIndirectBuffer(
                mtlBuffer.DeviceBuffer,
                (UIntPtr)offset,
                _computePipeline.ThreadsPerThreadgroup);
        }

        /// <summary>
        /// Draws the indexed indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        protected override void DrawIndexedIndirectCore(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            if (PreDrawCommand())
            {
                MTLBuffer mtlBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(indirectBuffer);
                for (uint i = 0; i < drawCount; i++)
                {
                    uint currentOffset = i * stride + offset;
                    _rce.drawIndexedPrimitives(
                        _graphicsPipeline.PrimitiveType,
                        _indexType,
                        _indexBuffer.DeviceBuffer,
                        (UIntPtr)_ibOffset,
                        mtlBuffer.DeviceBuffer,
                        (UIntPtr)currentOffset);
                }
            }
        }

        /// <summary>
        /// Draws the indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        protected override void DrawIndirectCore(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            if (PreDrawCommand())
            {
                MTLBuffer mtlBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(indirectBuffer);
                for (uint i = 0; i < drawCount; i++)
                {
                    uint currentOffset = i * stride + offset;
                    _rce.drawPrimitives(_graphicsPipeline.PrimitiveType, mtlBuffer.DeviceBuffer, (UIntPtr)currentOffset);
                }
            }
        }

        /// <summary>
        /// Resolves the texture core using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        protected override void ResolveTextureCore(Texture source, Texture destination)
        {
            // TODO: This approach destroys the contents of the source Texture (according to the docs).
            EnsureNoBlitEncoder();
            EnsureNoRenderPass();

            MTLTexture mtlSrc = Util.AssertSubtype<Texture, MTLTexture>(source);
            MTLTexture mtlDst = Util.AssertSubtype<Texture, MTLTexture>(destination);

            MTLRenderPassDescriptor rpDesc = MTLRenderPassDescriptor.New();
            var colorAttachment = rpDesc.colorAttachments[0];
            colorAttachment.texture = mtlSrc.DeviceTexture;
            colorAttachment.loadAction = MTLLoadAction.Load;
            colorAttachment.storeAction = MTLStoreAction.MultisampleResolve;
            colorAttachment.resolveTexture = mtlDst.DeviceTexture;

            using (NSAutoreleasePool.Begin())
            {
                MTLRenderCommandEncoder encoder = _cb.renderCommandEncoderWithDescriptor(rpDesc);
                encoder.endEncoding();
            }

            ObjectiveCRuntime.release(rpDesc.NativePtr);
        }

        /// <summary>
        /// Sets the compute resource set core using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="set">The set</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        protected override void SetComputeResourceSetCore(uint slot, ResourceSet set, uint dynamicOffsetCount, ref uint dynamicOffsets)
        {
            if (!_computeResourceSets[slot].Equals(set, dynamicOffsetCount, ref dynamicOffsets))
            {
                _computeResourceSets[slot].Offsets.Dispose();
                _computeResourceSets[slot] = new BoundResourceSetInfo(set, dynamicOffsetCount, ref dynamicOffsets);
                _computeResourceSetsActive[slot] = false;
            }
        }

        /// <summary>
        /// Sets the framebuffer core using the specified fb
        /// </summary>
        /// <param name="fb">The fb</param>
        protected override void SetFramebufferCore(Framebuffer fb)
        {
            if (!_currentFramebufferEverActive && _mtlFramebuffer != null)
            {
                // This ensures that any submitted clear values will be used even if nothing has been drawn.
                if (EnsureRenderPass())
                {
                    EndCurrentRenderPass();
                }
            }

            EnsureNoRenderPass();
            _mtlFramebuffer = Util.AssertSubtype<Framebuffer, MTLFramebufferBase>(fb);
            _viewportCount = Math.Max(1u, (uint)fb.ColorTargets.Count);
            Util.EnsureArrayMinimumSize(ref _viewports, _viewportCount);
            Util.ClearArray(_viewports);
            Util.EnsureArrayMinimumSize(ref _scissorRects, _viewportCount);
            Util.ClearArray(_scissorRects);
            Util.EnsureArrayMinimumSize(ref _clearColors, (uint)fb.ColorTargets.Count);
            Util.ClearArray(_clearColors);
            _currentFramebufferEverActive = false;
        }

        /// <summary>
        /// Sets the graphics resource set core using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        protected override void SetGraphicsResourceSetCore(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets)
        {
            if (!_graphicsResourceSets[slot].Equals(rs, dynamicOffsetCount, ref dynamicOffsets))
            {
                _graphicsResourceSets[slot].Offsets.Dispose();
                _graphicsResourceSets[slot] = new BoundResourceSetInfo(rs, dynamicOffsetCount, ref dynamicOffsets);
                _graphicsResourceSetsActive[slot] = false;
            }
        }

        /// <summary>
        /// Activates the graphics resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="brsi">The brsi</param>
        private void ActivateGraphicsResourceSet(uint slot, BoundResourceSetInfo brsi)
        {
            Debug.Assert(RenderEncoderActive);
            MTLResourceSet mtlRS = Util.AssertSubtype<ResourceSet, MTLResourceSet>(brsi.Set);
            MTLResourceLayout layout = mtlRS.Layout;
            uint dynamicOffsetIndex = 0;

            for (int i = 0; i < mtlRS.Resources.Length; i++)
            {
                MTLResourceLayout.ResourceBindingInfo bindingInfo = layout.GetBindingInfo(i);
                BindableResource resource = mtlRS.Resources[i];
                uint bufferOffset = 0;
                if (bindingInfo.DynamicBuffer)
                {
                    bufferOffset = brsi.Offsets.Get(dynamicOffsetIndex);
                    dynamicOffsetIndex += 1;
                }
                switch (bindingInfo.Kind)
                {
                    case ResourceKind.UniformBuffer:
                    {
                        DeviceBufferRange range = Util.GetBufferRange(resource, bufferOffset);
                        BindBuffer(range, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    }
                    case ResourceKind.TextureReadOnly:
                        TextureView texView = Util.GetTextureView(_gd, resource);
                        MTLTextureView mtlTexView = Util.AssertSubtype<TextureView, MTLTextureView>(texView);
                        BindTexture(mtlTexView, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    case ResourceKind.TextureReadWrite:
                        TextureView texViewRW = Util.GetTextureView(_gd, resource);
                        MTLTextureView mtlTexViewRW = Util.AssertSubtype<TextureView, MTLTextureView>(texViewRW);
                        BindTexture(mtlTexViewRW, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    case ResourceKind.Sampler:
                        MTLSampler mtlSampler = Util.AssertSubtype<BindableResource, MTLSampler>(resource);
                        BindSampler(mtlSampler, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    case ResourceKind.StructuredBufferReadOnly:
                    {
                        DeviceBufferRange range = Util.GetBufferRange(resource, bufferOffset);
                        BindBuffer(range, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    }
                    case ResourceKind.StructuredBufferReadWrite:
                    {
                        DeviceBufferRange range = Util.GetBufferRange(resource, bufferOffset);
                        BindBuffer(range, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    }
                    default:
                        throw Illegal.Value<ResourceKind>();
                }
            }
        }

        /// <summary>
        /// Activates the compute resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="brsi">The brsi</param>
        private void ActivateComputeResourceSet(uint slot, BoundResourceSetInfo brsi)
        {
            Debug.Assert(ComputeEncoderActive);
            MTLResourceSet mtlRS = Util.AssertSubtype<ResourceSet, MTLResourceSet>(brsi.Set);
            MTLResourceLayout layout = mtlRS.Layout;
            uint dynamicOffsetIndex = 0;

            for (int i = 0; i < mtlRS.Resources.Length; i++)
            {
                MTLResourceLayout.ResourceBindingInfo bindingInfo = layout.GetBindingInfo(i);
                BindableResource resource = mtlRS.Resources[i];
                uint bufferOffset = 0;
                if (bindingInfo.DynamicBuffer)
                {
                    bufferOffset = brsi.Offsets.Get(dynamicOffsetIndex);
                    dynamicOffsetIndex += 1;
                }

                switch (bindingInfo.Kind)
                {
                    case ResourceKind.UniformBuffer:
                    {
                        DeviceBufferRange range = Util.GetBufferRange(resource, bufferOffset);
                        BindBuffer(range, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    }
                    case ResourceKind.TextureReadOnly:
                        TextureView texView = Util.GetTextureView(_gd, resource);
                        MTLTextureView mtlTexView = Util.AssertSubtype<TextureView, MTLTextureView>(texView);
                        BindTexture(mtlTexView, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    case ResourceKind.TextureReadWrite:
                        TextureView texViewRW = Util.GetTextureView(_gd, resource);
                        MTLTextureView mtlTexViewRW = Util.AssertSubtype<TextureView, MTLTextureView>(texViewRW);
                        BindTexture(mtlTexViewRW, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    case ResourceKind.Sampler:
                        MTLSampler mtlSampler = Util.AssertSubtype<BindableResource, MTLSampler>(resource);
                        BindSampler(mtlSampler, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    case ResourceKind.StructuredBufferReadOnly:
                    {
                        DeviceBufferRange range = Util.GetBufferRange(resource, bufferOffset);
                        BindBuffer(range, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    }
                    case ResourceKind.StructuredBufferReadWrite:
                    {
                        DeviceBufferRange range = Util.GetBufferRange(resource, bufferOffset);
                        BindBuffer(range, slot, bindingInfo.Slot, bindingInfo.Stages);
                        break;
                    }
                    default:
                        throw Illegal.Value<ResourceKind>();
                }
            }
        }

        /// <summary>
        /// Binds the buffer using the specified range
        /// </summary>
        /// <param name="range">The range</param>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        private void BindBuffer(DeviceBufferRange range, uint set, uint slot, ShaderStages stages)
        {
            MTLBuffer mtlBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(range.Buffer);
            uint baseBuffer = GetBufferBase(set, stages != ShaderStages.Compute);
            if (stages == ShaderStages.Compute)
            {
                _cce.setBuffer(mtlBuffer.DeviceBuffer, (UIntPtr)range.Offset, (UIntPtr)(slot + baseBuffer));
            }
            else
            {
                if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
                {
                    UIntPtr index = (UIntPtr)(_graphicsPipeline.ResourceBindingModel == ResourceBindingModel.Improved
                        ? slot + baseBuffer
                        : slot + _vertexBufferCount + baseBuffer);
                    _rce.setVertexBuffer(mtlBuffer.DeviceBuffer, (UIntPtr)range.Offset, index);
                }
                if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
                {
                    _rce.setFragmentBuffer(mtlBuffer.DeviceBuffer, (UIntPtr)range.Offset, (UIntPtr)(slot + baseBuffer));
                }
            }
        }

        /// <summary>
        /// Binds the texture using the specified mtl tex view
        /// </summary>
        /// <param name="mtlTexView">The mtl tex view</param>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        private void BindTexture(MTLTextureView mtlTexView, uint set, uint slot, ShaderStages stages)
        {
            uint baseTexture = GetTextureBase(set, stages != ShaderStages.Compute);
            if (stages == ShaderStages.Compute)
            {
                _cce.setTexture(mtlTexView.TargetDeviceTexture, (UIntPtr)(slot + baseTexture));
            }
            if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
            {
                _rce.setVertexTexture(mtlTexView.TargetDeviceTexture, (UIntPtr)(slot + baseTexture));
            }
            if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
            {
                _rce.setFragmentTexture(mtlTexView.TargetDeviceTexture, (UIntPtr)(slot + baseTexture));
            }
        }

        /// <summary>
        /// Binds the sampler using the specified mtl sampler
        /// </summary>
        /// <param name="mtlSampler">The mtl sampler</param>
        /// <param name="set">The set</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        private void BindSampler(MTLSampler mtlSampler, uint set, uint slot, ShaderStages stages)
        {
            uint baseSampler = GetSamplerBase(set, stages != ShaderStages.Compute);
            if (stages == ShaderStages.Compute)
            {
                _cce.setSamplerState(mtlSampler.DeviceSampler, (UIntPtr)(slot + baseSampler));
            }
            if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
            {
                _rce.setVertexSamplerState(mtlSampler.DeviceSampler, (UIntPtr)(slot + baseSampler));
            }
            if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
            {
                _rce.setFragmentSamplerState(mtlSampler.DeviceSampler, (UIntPtr)(slot + baseSampler));
            }
        }

        /// <summary>
        /// Gets the buffer base using the specified set
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private uint GetBufferBase(uint set, bool graphics)
        {
            MTLResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            uint ret = 0;
            for (int i = 0; i < set; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].BufferCount;
            }

            return ret;
        }

        /// <summary>
        /// Gets the texture base using the specified set
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private uint GetTextureBase(uint set, bool graphics)
        {
            MTLResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            uint ret = 0;
            for (int i = 0; i < set; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].TextureCount;
            }

            return ret;
        }

        /// <summary>
        /// Gets the sampler base using the specified set
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private uint GetSamplerBase(uint set, bool graphics)
        {
            MTLResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            uint ret = 0;
            for (int i = 0; i < set; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].SamplerCount;
            }

            return ret;
        }

        /// <summary>
        /// Describes whether this instance ensure render pass
        /// </summary>
        /// <returns>The bool</returns>
        private bool EnsureRenderPass()
        {
            Debug.Assert(_mtlFramebuffer != null);
            EnsureNoBlitEncoder();
            EnsureNoComputeEncoder();
            return RenderEncoderActive || BeginCurrentRenderPass();
        }

        /// <summary>
        /// Gets the value of the render encoder active
        /// </summary>
        private bool RenderEncoderActive => !_rce.IsNull;
        /// <summary>
        /// Gets the value of the blit encoder active
        /// </summary>
        private bool BlitEncoderActive => !_bce.IsNull;
        /// <summary>
        /// Gets the value of the compute encoder active
        /// </summary>
        private bool ComputeEncoderActive => !_cce.IsNull;

        /// <summary>
        /// Describes whether this instance begin current render pass
        /// </summary>
        /// <returns>The bool</returns>
        private bool BeginCurrentRenderPass()
        {
            if (!_mtlFramebuffer.IsRenderable)
            {
                return false;
            }

            MTLRenderPassDescriptor rpDesc = _mtlFramebuffer.CreateRenderPassDescriptor();
            for (uint i = 0; i < _clearColors.Length; i++)
            {
                if (_clearColors[i] != null)
                {
                    var attachment = rpDesc.colorAttachments[0];
                    attachment.loadAction = MTLLoadAction.Clear;
                    RgbaFloat c = _clearColors[i].Value;
                    attachment.clearColor = new MTLClearColor(c.R, c.G, c.B, c.A);
                    _clearColors[i] = null;
                }
            }

            if (_clearDepth != null)
            {
                MTLRenderPassDepthAttachmentDescriptor depthAttachment = rpDesc.depthAttachment;
                depthAttachment.loadAction = MTLLoadAction.Clear;
                depthAttachment.clearDepth = _clearDepth.Value.depth;

                if (FormatHelpers.IsStencilFormat(_mtlFramebuffer.DepthTarget.Value.Target.Format))
                {
                    MTLRenderPassStencilAttachmentDescriptor stencilAttachment = rpDesc.stencilAttachment;
                    stencilAttachment.loadAction = MTLLoadAction.Clear;
                    stencilAttachment.clearStencil = _clearDepth.Value.stencil;
                }

                _clearDepth = null;
            }

            using (NSAutoreleasePool.Begin())
            {
                _rce = _cb.renderCommandEncoderWithDescriptor(rpDesc);
                ObjectiveCRuntime.retain(_rce.NativePtr);
            }

            ObjectiveCRuntime.release(rpDesc.NativePtr);
            _currentFramebufferEverActive = true;

            return true;
        }

        /// <summary>
        /// Ensures the no render pass
        /// </summary>
        private void EnsureNoRenderPass()
        {
            if (RenderEncoderActive)
            {
                EndCurrentRenderPass();
            }

            Debug.Assert(!RenderEncoderActive);
        }

        /// <summary>
        /// Ends the current render pass
        /// </summary>
        private void EndCurrentRenderPass()
        {
            _rce.endEncoding();
            ObjectiveCRuntime.release(_rce.NativePtr);
            _rce = default(MTLRenderCommandEncoder);
            _graphicsPipelineChanged = true;
            Util.ClearArray(_graphicsResourceSetsActive);
            _viewportsChanged = true;
            _scissorRectsChanged = true;
        }

        /// <summary>
        /// Ensures the blit encoder
        /// </summary>
        private void EnsureBlitEncoder()
        {
            if (!BlitEncoderActive)
            {
                EnsureNoRenderPass();
                EnsureNoComputeEncoder();
                using (NSAutoreleasePool.Begin())
                {
                    _bce = _cb.blitCommandEncoder();
                    ObjectiveCRuntime.retain(_bce.NativePtr);
                }
            }

            Debug.Assert(BlitEncoderActive);
            Debug.Assert(!RenderEncoderActive);
            Debug.Assert(!ComputeEncoderActive);
        }

        /// <summary>
        /// Ensures the no blit encoder
        /// </summary>
        private void EnsureNoBlitEncoder()
        {
            if (BlitEncoderActive)
            {
                _bce.endEncoding();
                ObjectiveCRuntime.release(_bce.NativePtr);
                _bce = default(MTLBlitCommandEncoder);
            }

            Debug.Assert(!BlitEncoderActive);
        }

        /// <summary>
        /// Ensures the compute encoder
        /// </summary>
        private void EnsureComputeEncoder()
        {
            if (!ComputeEncoderActive)
            {
                EnsureNoBlitEncoder();
                EnsureNoRenderPass();

                using (NSAutoreleasePool.Begin())
                {
                    _cce = _cb.computeCommandEncoder();
                    ObjectiveCRuntime.retain(_cce.NativePtr);
                }
            }

            Debug.Assert(ComputeEncoderActive);
            Debug.Assert(!RenderEncoderActive);
            Debug.Assert(!BlitEncoderActive);
        }

        /// <summary>
        /// Ensures the no compute encoder
        /// </summary>
        private void EnsureNoComputeEncoder()
        {
            if (ComputeEncoderActive)
            {
                _cce.endEncoding();
                ObjectiveCRuntime.release(_cce.NativePtr);
                _cce = default(MTLComputeCommandEncoder);
                _computePipelineChanged = true;
                Util.ClearArray(_computeResourceSetsActive);
            }

            Debug.Assert(!ComputeEncoderActive);
        }

        /// <summary>
        /// Sets the index buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <param name="offset">The offset</param>
        private protected override void SetIndexBufferCore(DeviceBuffer buffer, IndexFormat format, uint offset)
        {
            _indexBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(buffer);
            _ibOffset = offset;
            _indexType = MTLFormats.VdToMTLIndexFormat(format);
        }

        /// <summary>
        /// Sets the vertex buffer core using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        private protected override void SetVertexBufferCore(uint index, DeviceBuffer buffer, uint offset)
        {
            Util.EnsureArrayMinimumSize(ref _vertexBuffers, index + 1);
            Util.EnsureArrayMinimumSize(ref _vbOffsets, index + 1);
            Util.EnsureArrayMinimumSize(ref _vertexBuffersActive, index + 1);
            if (_vertexBuffers[index] != buffer || _vbOffsets[index] != offset)
            {
                MTLBuffer mtlBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(buffer);
                _vertexBuffers[index] = mtlBuffer;
                _vbOffsets[index] = offset;
                _vertexBuffersActive[index] = false;
            }
        }

        /// <summary>
        /// Pushes the debug group core using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        private protected override void PushDebugGroupCore(string name)
        {
            NSString nsName = NSString.New(name);
            if (!_bce.IsNull)
            {
                _bce.pushDebugGroup(nsName);
            }
            else if (!_cce.IsNull)
            {
                _cce.pushDebugGroup(nsName);
            }
            else if (!_rce.IsNull)
            {
                _rce.pushDebugGroup(nsName);
            }

            ObjectiveCRuntime.release(nsName);
        }

        /// <summary>
        /// Pops the debug group core
        /// </summary>
        private protected override void PopDebugGroupCore()
        {
            if (!_bce.IsNull)
            {
                _bce.popDebugGroup();
            }
            else if (!_cce.IsNull)
            {
                _cce.popDebugGroup();
            }
            else if (!_rce.IsNull)
            {
                _rce.popDebugGroup();
            }
        }

        /// <summary>
        /// Inserts the debug marker core using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        private protected override void InsertDebugMarkerCore(string name)
        {
            NSString nsName = NSString.New(name);
            if (!_bce.IsNull)
            {
                _bce.insertDebugSignpost(nsName);
            }
            else if (!_cce.IsNull)
            {
                _cce.insertDebugSignpost(nsName);
            }
            else if (!_rce.IsNull)
            {
                _rce.insertDebugSignpost(nsName);
            }

            ObjectiveCRuntime.release(nsName);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                EnsureNoRenderPass();
                if (_cb.NativePtr != IntPtr.Zero)
                {
                    ObjectiveCRuntime.release(_cb.NativePtr);
                }
            }
        }
    }
}
