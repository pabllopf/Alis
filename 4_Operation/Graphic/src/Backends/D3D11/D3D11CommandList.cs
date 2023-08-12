using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Vortice;
using Vortice.Direct3D11;
using Vortice.Mathematics;

namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 command list class
    /// </summary>
    /// <seealso cref="CommandList"/>
    internal class D3D11CommandList : CommandList
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly D3D11GraphicsDevice _gd;
        /// <summary>
        /// The context
        /// </summary>
        private readonly ID3D11DeviceContext _context;
        /// <summary>
        /// The context
        /// </summary>
        private readonly ID3D11DeviceContext1 _context1;
        /// <summary>
        /// The uda
        /// </summary>
        private readonly ID3DUserDefinedAnnotation _uda;
        /// <summary>
        /// The begun
        /// </summary>
        private bool _begun;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// The command list
        /// </summary>
        private ID3D11CommandList _commandList;

        /// <summary>
        /// The viewport
        /// </summary>
        private Viewport[] _viewports = new Viewport[0];
        /// <summary>
        /// The raw rect
        /// </summary>
        private RawRect[] _scissors = new RawRect[0];
        /// <summary>
        /// The viewports changed
        /// </summary>
        private bool _viewportsChanged;
        /// <summary>
        /// The scissor rects changed
        /// </summary>
        private bool _scissorRectsChanged;

        /// <summary>
        /// The num vertex bindings
        /// </summary>
        private uint _numVertexBindings = 0;
        /// <summary>
        /// The id 11 buffer
        /// </summary>
        private ID3D11Buffer[] _vertexBindings = new ID3D11Buffer[1];
        /// <summary>
        /// The vertex strides
        /// </summary>
        private int[] _vertexStrides;
        /// <summary>
        /// The vertex offsets
        /// </summary>
        private int[] _vertexOffsets = new int[1];

        // Cached pipeline State
        /// <summary>
        /// The ib
        /// </summary>
        private DeviceBuffer _ib;
        /// <summary>
        /// The ib offset
        /// </summary>
        private uint _ibOffset;
        /// <summary>
        /// The blend state
        /// </summary>
        private ID3D11BlendState _blendState;
        /// <summary>
        /// The blend factor
        /// </summary>
        private Color4 _blendFactor;
        /// <summary>
        /// The depth stencil state
        /// </summary>
        private ID3D11DepthStencilState _depthStencilState;
        /// <summary>
        /// The stencil reference
        /// </summary>
        private uint _stencilReference;
        /// <summary>
        /// The rasterizer state
        /// </summary>
        private ID3D11RasterizerState _rasterizerState;
        /// <summary>
        /// The primitive topology
        /// </summary>
        private Vortice.Direct3D.PrimitiveTopology _primitiveTopology;
        /// <summary>
        /// The input layout
        /// </summary>
        private ID3D11InputLayout _inputLayout;
        /// <summary>
        /// The vertex shader
        /// </summary>
        private ID3D11VertexShader _vertexShader;
        /// <summary>
        /// The geometry shader
        /// </summary>
        private ID3D11GeometryShader _geometryShader;
        /// <summary>
        /// The hull shader
        /// </summary>
        private ID3D11HullShader _hullShader;
        /// <summary>
        /// The domain shader
        /// </summary>
        private ID3D11DomainShader _domainShader;
        /// <summary>
        /// The pixel shader
        /// </summary>
        private ID3D11PixelShader _pixelShader;

        /// <summary>
        /// The graphics pipeline
        /// </summary>
        private new D3D11Pipeline _graphicsPipeline;
        /// <summary>
        /// The bound resource set info
        /// </summary>
        private BoundResourceSetInfo[] _graphicsResourceSets = new BoundResourceSetInfo[1];
        // Resource sets are invalidated when a new resource set is bound with an incompatible SRV or UAV.
        /// <summary>
        /// The invalidated graphics resource sets
        /// </summary>
        private bool[] _invalidatedGraphicsResourceSets = new bool[1];

        /// <summary>
        /// The compute pipeline
        /// </summary>
        private new D3D11Pipeline _computePipeline;
        /// <summary>
        /// The bound resource set info
        /// </summary>
        private BoundResourceSetInfo[] _computeResourceSets = new BoundResourceSetInfo[1];
        // Resource sets are invalidated when a new resource set is bound with an incompatible SRV or UAV.
        /// <summary>
        /// The invalidated compute resource sets
        /// </summary>
        private bool[] _invalidatedComputeResourceSets = new bool[1];
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The vertex bindings changed
        /// </summary>
        private bool _vertexBindingsChanged;
        /// <summary>
        /// The id 11 buffer
        /// </summary>
        private ID3D11Buffer[] _cbOut = new ID3D11Buffer[1];
        /// <summary>
        /// The first const ref
        /// </summary>
        private int[] _firstConstRef = new int[1];
        /// <summary>
        /// The num consts ref
        /// </summary>
        private int[] _numConstsRef = new int[1];

        // Cached resources
        /// <summary>
        /// The max cached uniform buffers
        /// </summary>
        private const int MaxCachedUniformBuffers = 15;
        /// <summary>
        /// The max cached uniform buffers
        /// </summary>
        private readonly D3D11BufferRange[] _vertexBoundUniformBuffers = new D3D11BufferRange[MaxCachedUniformBuffers];
        /// <summary>
        /// The max cached uniform buffers
        /// </summary>
        private readonly D3D11BufferRange[] _fragmentBoundUniformBuffers = new D3D11BufferRange[MaxCachedUniformBuffers];
        /// <summary>
        /// The max cached texture views
        /// </summary>
        private const int MaxCachedTextureViews = 16;
        /// <summary>
        /// The max cached texture views
        /// </summary>
        private readonly D3D11TextureView[] _vertexBoundTextureViews = new D3D11TextureView[MaxCachedTextureViews];
        /// <summary>
        /// The max cached texture views
        /// </summary>
        private readonly D3D11TextureView[] _fragmentBoundTextureViews = new D3D11TextureView[MaxCachedTextureViews];
        /// <summary>
        /// The max cached samplers
        /// </summary>
        private const int MaxCachedSamplers = 4;
        /// <summary>
        /// The max cached samplers
        /// </summary>
        private readonly D3D11Sampler[] _vertexBoundSamplers = new D3D11Sampler[MaxCachedSamplers];
        /// <summary>
        /// The max cached samplers
        /// </summary>
        private readonly D3D11Sampler[] _fragmentBoundSamplers = new D3D11Sampler[MaxCachedSamplers];

        /// <summary>
        /// The bound texture info
        /// </summary>
        private readonly Dictionary<Texture, List<BoundTextureInfo>> _boundSRVs = new Dictionary<Texture, List<BoundTextureInfo>>();
        /// <summary>
        /// The bound texture info
        /// </summary>
        private readonly Dictionary<Texture, List<BoundTextureInfo>> _boundUAVs = new Dictionary<Texture, List<BoundTextureInfo>>();
        /// <summary>
        /// The bound texture info
        /// </summary>
        private readonly List<List<BoundTextureInfo>> _boundTextureInfoPool = new List<List<BoundTextureInfo>>(20);

        /// <summary>
        /// The max ua vs
        /// </summary>
        private const int MaxUAVs = 8;
        /// <summary>
        /// The max ua vs
        /// </summary>
        private readonly List<(DeviceBuffer, int)> _boundComputeUAVBuffers = new List<(DeviceBuffer, int)>(MaxUAVs);
        /// <summary>
        /// The max ua vs
        /// </summary>
        private readonly List<(DeviceBuffer, int)> _boundOMUAVBuffers = new List<(DeviceBuffer, int)>(MaxUAVs);

        /// <summary>
        /// The 11 buffer
        /// </summary>
        private readonly List<D3D11Buffer> _availableStagingBuffers = new List<D3D11Buffer>();
        /// <summary>
        /// The 11 buffer
        /// </summary>
        private readonly List<D3D11Buffer> _submittedStagingBuffers = new List<D3D11Buffer>();

        /// <summary>
        /// The 11 swapchain
        /// </summary>
        private readonly List<D3D11Swapchain> _referencedSwapchains = new List<D3D11Swapchain>();

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11CommandList"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public D3D11CommandList(D3D11GraphicsDevice gd, ref CommandListDescription description)
            : base(ref description, gd.Features, gd.UniformBufferMinOffsetAlignment, gd.StructuredBufferMinOffsetAlignment)
        {
            _gd = gd;
            _context = gd.Device.CreateDeferredContext();
            _context1 = _context.QueryInterfaceOrNull<ID3D11DeviceContext1>();
            _uda = _context.QueryInterfaceOrNull<ID3DUserDefinedAnnotation>();
        }

        /// <summary>
        /// Gets the value of the device command list
        /// </summary>
        public ID3D11CommandList DeviceCommandList => _commandList;

        /// <summary>
        /// Gets the value of the device context
        /// </summary>
        internal ID3D11DeviceContext DeviceContext => _context;

        /// <summary>
        /// Gets the value of the d 3 d 11 framebuffer
        /// </summary>
        private D3D11Framebuffer D3D11Framebuffer => Util.AssertSubtype<Framebuffer, D3D11Framebuffer>(_framebuffer);

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Begins this instance
        /// </summary>
        public override void Begin()
        {
            _commandList?.Dispose();
            _commandList = null;
            ClearState();
            _begun = true;
        }

        /// <summary>
        /// Clears the state
        /// </summary>
        private void ClearState()
        {
            ClearCachedState();
            _context.ClearState();
            ResetManagedState();
        }

        /// <summary>
        /// Resets the managed state
        /// </summary>
        private void ResetManagedState()
        {
            _numVertexBindings = 0;
            Util.ClearArray(_vertexBindings);
            _vertexStrides = null;
            Util.ClearArray(_vertexOffsets);

            _framebuffer = null;

            Util.ClearArray(_viewports);
            Util.ClearArray(_scissors);
            _viewportsChanged = false;
            _scissorRectsChanged = false;

            _ib = null;
            _graphicsPipeline = null;
            _blendState = null;
            _depthStencilState = null;
            _rasterizerState = null;
            _primitiveTopology = Vortice.Direct3D.PrimitiveTopology.Undefined;
            _inputLayout = null;
            _vertexShader = null;
            _geometryShader = null;
            _hullShader = null;
            _domainShader = null;
            _pixelShader = null;

            ClearSets(_graphicsResourceSets);

            Util.ClearArray(_vertexBoundUniformBuffers);
            Util.ClearArray(_vertexBoundTextureViews);
            Util.ClearArray(_vertexBoundSamplers);

            Util.ClearArray(_fragmentBoundUniformBuffers);
            Util.ClearArray(_fragmentBoundTextureViews);
            Util.ClearArray(_fragmentBoundSamplers);

            _computePipeline = null;
            ClearSets(_computeResourceSets);

            foreach (KeyValuePair<Texture, List<BoundTextureInfo>> kvp in _boundSRVs)
            {
                List<BoundTextureInfo> list = kvp.Value;
                list.Clear();
                PoolBoundTextureList(list);
            }
            _boundSRVs.Clear();

            foreach (KeyValuePair<Texture, List<BoundTextureInfo>> kvp in _boundUAVs)
            {
                List<BoundTextureInfo> list = kvp.Value;
                list.Clear();
                PoolBoundTextureList(list);
            }
            _boundUAVs.Clear();
        }

        /// <summary>
        /// Clears the sets using the specified bound sets
        /// </summary>
        /// <param name="boundSets">The bound sets</param>
        private void ClearSets(BoundResourceSetInfo[] boundSets)
        {
            foreach (BoundResourceSetInfo boundSetInfo in boundSets)
            {
                boundSetInfo.Offsets.Dispose();
            }
            Util.ClearArray(boundSets);
        }

        /// <summary>
        /// Ends this instance
        /// </summary>
        /// <exception cref="VeldridException">Invalid use of End().</exception>
        public override void End()
        {
            if (_commandList != null)
            {
                throw new VeldridException("Invalid use of End().");
            }

            _context.FinishCommandList(false, out _commandList).CheckError();
            _commandList.DebugName = _name;
            ResetManagedState();
            _begun = false;
        }

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            if (_commandList != null)
            {
                _commandList.Dispose();
                _commandList = null;
            }
            else if (_begun)
            {
                _context.ClearState();
                _context.FinishCommandList(false, out _commandList);
                _commandList.Dispose();
                _commandList = null;
            }

            ResetManagedState();
            _begun = false;
        }

        /// <summary>
        /// Sets the index buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <param name="offset">The offset</param>
        private protected override void SetIndexBufferCore(DeviceBuffer buffer, IndexFormat format, uint offset)
        {
            if (_ib != buffer || _ibOffset != offset)
            {
                _ib = buffer;
                _ibOffset = offset;
                D3D11Buffer d3d11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(buffer);
                UnbindUAVBuffer(buffer);
                _context.IASetIndexBuffer(d3d11Buffer.Buffer, D3D11Formats.ToDxgiFormat(format), (int)offset);
            }
        }

        /// <summary>
        /// Sets the pipeline core using the specified pipeline
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        private protected override void SetPipelineCore(Pipeline pipeline)
        {
            if (!pipeline.IsComputePipeline && _graphicsPipeline != pipeline)
            {
                D3D11Pipeline d3dPipeline = Util.AssertSubtype<Pipeline, D3D11Pipeline>(pipeline);
                _graphicsPipeline = d3dPipeline;
                ClearSets(_graphicsResourceSets); // Invalidate resource set bindings -- they may be invalid.
                Util.ClearArray(_invalidatedGraphicsResourceSets);

                ID3D11BlendState blendState = d3dPipeline.BlendState;
                Color4 blendFactor = d3dPipeline.BlendFactor;
                if (_blendState != blendState || _blendFactor != blendFactor)
                {
                    _blendState = blendState;
                    _blendFactor = blendFactor;
                    _context.OMSetBlendState(blendState, blendFactor);
                }

                ID3D11DepthStencilState depthStencilState = d3dPipeline.DepthStencilState;
                uint stencilReference = d3dPipeline.StencilReference;
                if (_depthStencilState != depthStencilState || _stencilReference != stencilReference)
                {
                    _depthStencilState = depthStencilState;
                    _stencilReference = stencilReference;
                    _context.OMSetDepthStencilState(depthStencilState, (int)stencilReference);
                }

                ID3D11RasterizerState rasterizerState = d3dPipeline.RasterizerState;
                if (_rasterizerState != rasterizerState)
                {
                    _rasterizerState = rasterizerState;
                    _context.RSSetState(rasterizerState);
                }

                Vortice.Direct3D.PrimitiveTopology primitiveTopology = d3dPipeline.PrimitiveTopology;
                if (_primitiveTopology != primitiveTopology)
                {
                    _primitiveTopology = primitiveTopology;
                    _context.IASetPrimitiveTopology(primitiveTopology);
                }

                ID3D11InputLayout inputLayout = d3dPipeline.InputLayout;
                if (_inputLayout != inputLayout)
                {
                    _inputLayout = inputLayout;
                    _context.IASetInputLayout(inputLayout);
                }

                ID3D11VertexShader vertexShader = d3dPipeline.VertexShader;
                if (_vertexShader != vertexShader)
                {
                    _vertexShader = vertexShader;
                    _context.VSSetShader(vertexShader);
                }

                ID3D11GeometryShader geometryShader = d3dPipeline.GeometryShader;
                if (_geometryShader != geometryShader)
                {
                    _geometryShader = geometryShader;
                    _context.GSSetShader(geometryShader);
                }

                ID3D11HullShader hullShader = d3dPipeline.HullShader;
                if (_hullShader != hullShader)
                {
                    _hullShader = hullShader;
                    _context.HSSetShader(hullShader);
                }

                ID3D11DomainShader domainShader = d3dPipeline.DomainShader;
                if (_domainShader != domainShader)
                {
                    _domainShader = domainShader;
                    _context.DSSetShader(domainShader);
                }

                ID3D11PixelShader pixelShader = d3dPipeline.PixelShader;
                if (_pixelShader != pixelShader)
                {
                    _pixelShader = pixelShader;
                    _context.PSSetShader(pixelShader);
                }

                _vertexStrides = d3dPipeline.VertexStrides;
                if (_vertexStrides != null)
                {
                    int vertexStridesCount = _vertexStrides.Length;
                    Util.EnsureArrayMinimumSize(ref _vertexBindings, (uint)vertexStridesCount);
                    Util.EnsureArrayMinimumSize(ref _vertexOffsets, (uint)vertexStridesCount);
                }

                Util.EnsureArrayMinimumSize(ref _graphicsResourceSets, (uint)d3dPipeline.ResourceLayouts.Length);
                Util.EnsureArrayMinimumSize(ref _invalidatedGraphicsResourceSets, (uint)d3dPipeline.ResourceLayouts.Length);
            }
            else if (pipeline.IsComputePipeline && _computePipeline != pipeline)
            {
                D3D11Pipeline d3dPipeline = Util.AssertSubtype<Pipeline, D3D11Pipeline>(pipeline);
                _computePipeline = d3dPipeline;
                ClearSets(_computeResourceSets); // Invalidate resource set bindings -- they may be invalid.
                Util.ClearArray(_invalidatedComputeResourceSets);

                ID3D11ComputeShader computeShader = d3dPipeline.ComputeShader;
                _context.CSSetShader(computeShader);
                Util.EnsureArrayMinimumSize(ref _computeResourceSets, (uint)d3dPipeline.ResourceLayouts.Length);
                Util.EnsureArrayMinimumSize(ref _invalidatedComputeResourceSets, (uint)d3dPipeline.ResourceLayouts.Length);
            }
        }

        /// <summary>
        /// Sets the graphics resource set core using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetsCount">The dynamic offsets count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        protected override void SetGraphicsResourceSetCore(uint slot, ResourceSet rs, uint dynamicOffsetsCount, ref uint dynamicOffsets)
        {
            if (_graphicsResourceSets[slot].Equals(rs, dynamicOffsetsCount, ref dynamicOffsets))
            {
                return;
            }

            _graphicsResourceSets[slot].Offsets.Dispose();
            _graphicsResourceSets[slot] = new BoundResourceSetInfo(rs, dynamicOffsetsCount, ref dynamicOffsets);
            ActivateResourceSet(slot, _graphicsResourceSets[slot], true);
        }

        /// <summary>
        /// Sets the compute resource set core using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="set">The set</param>
        /// <param name="dynamicOffsetsCount">The dynamic offsets count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        protected override void SetComputeResourceSetCore(uint slot, ResourceSet set, uint dynamicOffsetsCount, ref uint dynamicOffsets)
        {
            if (_computeResourceSets[slot].Equals(set, dynamicOffsetsCount, ref dynamicOffsets))
            {
                return;
            }

            _computeResourceSets[slot].Offsets.Dispose();
            _computeResourceSets[slot] = new BoundResourceSetInfo(set, dynamicOffsetsCount, ref dynamicOffsets);
            ActivateResourceSet(slot, _computeResourceSets[slot], false);
        }

        /// <summary>
        /// Activates the resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="brsi">The brsi</param>
        /// <param name="graphics">The graphics</param>
        private void ActivateResourceSet(uint slot, BoundResourceSetInfo brsi, bool graphics)
        {
            D3D11ResourceSet d3d11RS = Util.AssertSubtype<ResourceSet, D3D11ResourceSet>(brsi.Set);

            int cbBase = GetConstantBufferBase(slot, graphics);
            int uaBase = GetUnorderedAccessBase(slot, graphics);
            int textureBase = GetTextureBase(slot, graphics);
            int samplerBase = GetSamplerBase(slot, graphics);

            D3D11ResourceLayout layout = d3d11RS.Layout;
            BindableResource[] resources = d3d11RS.Resources;
            uint dynamicOffsetIndex = 0;
            for (int i = 0; i < resources.Length; i++)
            {
                BindableResource resource = resources[i];
                uint bufferOffset = 0;
                if (layout.IsDynamicBuffer(i))
                {
                    bufferOffset = brsi.Offsets.Get(dynamicOffsetIndex);
                    dynamicOffsetIndex += 1;
                }
                D3D11ResourceLayout.ResourceBindingInfo rbi = layout.GetDeviceSlotIndex(i);
                switch (rbi.Kind)
                {
                    case ResourceKind.UniformBuffer:
                        {
                            D3D11BufferRange range = GetBufferRange(resource, bufferOffset);
                            BindUniformBuffer(range, cbBase + rbi.Slot, rbi.Stages);
                            break;
                        }
                    case ResourceKind.StructuredBufferReadOnly:
                        {
                            D3D11BufferRange range = GetBufferRange(resource, bufferOffset);
                            BindStorageBufferView(range, textureBase + rbi.Slot, rbi.Stages);
                            break;
                        }
                    case ResourceKind.StructuredBufferReadWrite:
                        {
                            D3D11BufferRange range = GetBufferRange(resource, bufferOffset);
                            ID3D11UnorderedAccessView uav = range.Buffer.GetUnorderedAccessView(range.Offset, range.Size);
                            BindUnorderedAccessView(null, range.Buffer, uav, uaBase + rbi.Slot, rbi.Stages, slot);
                            break;
                        }
                    case ResourceKind.TextureReadOnly:
                        TextureView texView = Util.GetTextureView(_gd, resource);
                        D3D11TextureView d3d11TexView = Util.AssertSubtype<TextureView, D3D11TextureView>(texView);
                        UnbindUAVTexture(d3d11TexView.Target);
                        BindTextureView(d3d11TexView, textureBase + rbi.Slot, rbi.Stages, slot);
                        break;
                    case ResourceKind.TextureReadWrite:
                        TextureView rwTexView = Util.GetTextureView(_gd, resource);
                        D3D11TextureView d3d11RWTexView = Util.AssertSubtype<TextureView, D3D11TextureView>(rwTexView);
                        UnbindSRVTexture(d3d11RWTexView.Target);
                        BindUnorderedAccessView(d3d11RWTexView.Target, null, d3d11RWTexView.UnorderedAccessView, uaBase + rbi.Slot, rbi.Stages, slot);
                        break;
                    case ResourceKind.Sampler:
                        D3D11Sampler sampler = Util.AssertSubtype<BindableResource, D3D11Sampler>(resource);
                        BindSampler(sampler, samplerBase + rbi.Slot, rbi.Stages);
                        break;
                    default: throw Illegal.Value<ResourceKind>();
                }
            }
        }

        /// <summary>
        /// Gets the buffer range using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="additionalOffset">The additional offset</param>
        /// <exception cref="VeldridException">Unexpected resource type used in a buffer type slot: {resource.GetType().Name}</exception>
        /// <returns>The 11 buffer range</returns>
        private D3D11BufferRange GetBufferRange(BindableResource resource, uint additionalOffset)
        {
            if (resource is D3D11Buffer d3d11Buff)
            {
                return new D3D11BufferRange(d3d11Buff, additionalOffset, d3d11Buff.SizeInBytes);
            }
            else if (resource is DeviceBufferRange range)
            {
                return new D3D11BufferRange(
                    Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(range.Buffer),
                    range.Offset + additionalOffset,
                    range.SizeInBytes);
            }
            else
            {
                throw new VeldridException($"Unexpected resource type used in a buffer type slot: {resource.GetType().Name}");
            }
        }

        /// <summary>
        /// Unbinds the srv texture using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        private void UnbindSRVTexture(Texture target)
        {
            if (_boundSRVs.TryGetValue(target, out List<BoundTextureInfo> btis))
            {
                foreach (BoundTextureInfo bti in btis)
                {
                    BindTextureView(null, bti.Slot, bti.Stages, 0);

                    if ((bti.Stages & ShaderStages.Compute) == ShaderStages.Compute)
                    {
                        _invalidatedComputeResourceSets[bti.ResourceSet] = true;
                    }
                    else
                    {
                        _invalidatedGraphicsResourceSets[bti.ResourceSet] = true;
                    }
                }

                bool result = _boundSRVs.Remove(target);
                Debug.Assert(result);

                btis.Clear();
                PoolBoundTextureList(btis);
            }
        }

        /// <summary>
        /// Pools the bound texture list using the specified btis
        /// </summary>
        /// <param name="btis">The btis</param>
        private void PoolBoundTextureList(List<BoundTextureInfo> btis)
        {
            _boundTextureInfoPool.Add(btis);
        }

        /// <summary>
        /// Unbinds the uav texture using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        private void UnbindUAVTexture(Texture target)
        {
            if (_boundUAVs.TryGetValue(target, out List<BoundTextureInfo> btis))
            {
                foreach (BoundTextureInfo bti in btis)
                {
                    BindUnorderedAccessView(null, null, null, bti.Slot, bti.Stages, bti.ResourceSet);
                    if ((bti.Stages & ShaderStages.Compute) == ShaderStages.Compute)
                    {
                        _invalidatedComputeResourceSets[bti.ResourceSet] = true;
                    }
                    else
                    {
                        _invalidatedGraphicsResourceSets[bti.ResourceSet] = true;
                    }
                }

                bool result = _boundUAVs.Remove(target);
                Debug.Assert(result);

                btis.Clear();
                PoolBoundTextureList(btis);
            }
        }

        /// <summary>
        /// Gets the constant buffer base using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private int GetConstantBufferBase(uint slot, bool graphics)
        {
            D3D11ResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            int ret = 0;
            for (int i = 0; i < slot; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].UniformBufferCount;
            }

            return ret;
        }

        /// <summary>
        /// Gets the unordered access base using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private int GetUnorderedAccessBase(uint slot, bool graphics)
        {
            D3D11ResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            int ret = 0;
            for (int i = 0; i < slot; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].StorageBufferCount;
            }

            return ret;
        }

        /// <summary>
        /// Gets the texture base using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private int GetTextureBase(uint slot, bool graphics)
        {
            D3D11ResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            int ret = 0;
            for (int i = 0; i < slot; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].TextureCount;
            }

            return ret;
        }

        /// <summary>
        /// Gets the sampler base using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="graphics">The graphics</param>
        /// <returns>The ret</returns>
        private int GetSamplerBase(uint slot, bool graphics)
        {
            D3D11ResourceLayout[] layouts = graphics ? _graphicsPipeline.ResourceLayouts : _computePipeline.ResourceLayouts;
            int ret = 0;
            for (int i = 0; i < slot; i++)
            {
                Debug.Assert(layouts[i] != null);
                ret += layouts[i].SamplerCount;
            }

            return ret;
        }

        /// <summary>
        /// Sets the vertex buffer core using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        private protected override void SetVertexBufferCore(uint index, DeviceBuffer buffer, uint offset)
        {
            D3D11Buffer d3d11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(buffer);
            if (_vertexBindings[index] != d3d11Buffer.Buffer || _vertexOffsets[index] != offset)
            {
                _vertexBindingsChanged = true;
                UnbindUAVBuffer(buffer);
                _vertexBindings[index] = d3d11Buffer.Buffer;
                _vertexOffsets[index] = (int)offset;
                _numVertexBindings = Math.Max((index + 1), _numVertexBindings);
            }
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
            PreDrawCommand();

            if (instanceCount == 1 && instanceStart == 0)
            {
                _context.Draw((int)vertexCount, (int)vertexStart);
            }
            else
            {
                _context.DrawInstanced((int)vertexCount, (int)instanceCount, (int)vertexStart, (int)instanceStart);
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
            PreDrawCommand();

            Debug.Assert(_ib != null);
            if (instanceCount == 1 && instanceStart == 0)
            {
                _context.DrawIndexed((int)indexCount, (int)indexStart, vertexOffset);
            }
            else
            {
                _context.DrawIndexedInstanced((int)indexCount, (int)instanceCount, (int)indexStart, vertexOffset, (int)instanceStart);
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
            PreDrawCommand();

            D3D11Buffer d3d11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(indirectBuffer);
            int currentOffset = (int)offset;
            for (uint i = 0; i < drawCount; i++)
            {
                _context.DrawInstancedIndirect(d3d11Buffer.Buffer, currentOffset);
                currentOffset += (int)stride;
            }
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
            PreDrawCommand();

            D3D11Buffer d3d11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(indirectBuffer);
            int currentOffset = (int)offset;
            for (uint i = 0; i < drawCount; i++)
            {
                _context.DrawIndexedInstancedIndirect(d3d11Buffer.Buffer, currentOffset);
                currentOffset += (int)stride;
            }
        }

        /// <summary>
        /// Pres the draw command
        /// </summary>
        private void PreDrawCommand()
        {
            FlushViewports();
            FlushScissorRects();
            FlushVertexBindings();

            int graphicsResourceCount = _graphicsPipeline.ResourceLayouts.Length;
            for (uint i = 0; i < graphicsResourceCount; i++)
            {
                if (_invalidatedGraphicsResourceSets[i])
                {
                    _invalidatedGraphicsResourceSets[i] = false;
                    ActivateResourceSet(i, _graphicsResourceSets[i], true);
                }
            }
        }

        /// <summary>
        /// Dispatches the group count x
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        public override void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            PreDispatchCommand();

            _context.Dispatch((int)groupCountX, (int)groupCountY, (int)groupCountZ);
        }

        /// <summary>
        /// Dispatches the indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        protected override void DispatchIndirectCore(DeviceBuffer indirectBuffer, uint offset)
        {
            PreDispatchCommand();
            D3D11Buffer d3d11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(indirectBuffer);
            _context.DispatchIndirect(d3d11Buffer.Buffer, (int)offset);
        }

        /// <summary>
        /// Pres the dispatch command
        /// </summary>
        private void PreDispatchCommand()
        {
            int computeResourceCount = _computePipeline.ResourceLayouts.Length;
            for (uint i = 0; i < computeResourceCount; i++)
            {
                if (_invalidatedComputeResourceSets[i])
                {
                    _invalidatedComputeResourceSets[i] = false;
                    ActivateResourceSet(i, _computeResourceSets[i], false);
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
            D3D11Texture d3d11Source = Util.AssertSubtype<Texture, D3D11Texture>(source);
            D3D11Texture d3d11Destination = Util.AssertSubtype<Texture, D3D11Texture>(destination);
            _context.ResolveSubresource(
                d3d11Destination.DeviceTexture,
                0,
                d3d11Source.DeviceTexture,
                0,
                d3d11Destination.DxgiFormat);
        }

        /// <summary>
        /// Flushes the viewports
        /// </summary>
        private void FlushViewports()
        {
            if (_viewportsChanged)
            {
                _viewportsChanged = false;
                _context.RSSetViewports(_viewports);
            }
        }

        /// <summary>
        /// Flushes the scissor rects
        /// </summary>
        private void FlushScissorRects()
        {
            if (_scissorRectsChanged)
            {
                _scissorRectsChanged = false;
                if (_scissors.Length > 0)
                {
                    // Because this array is resized using Util.EnsureMinimumArraySize, this might set more scissor rectangles
                    // than are actually needed, but this is okay -- extras are essentially ignored and should be harmless.
                    _context.RSSetScissorRects(_scissors);
                }
            }
        }

        /// <summary>
        /// Flushes the vertex bindings
        /// </summary>
        private unsafe void FlushVertexBindings()
        {
            if (_vertexBindingsChanged)
            {
                _context.IASetVertexBuffers(
                    0, (int)_numVertexBindings,
                    _vertexBindings,
                    _vertexStrides,
                    _vertexOffsets);

                _vertexBindingsChanged = false;
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
            Util.EnsureArrayMinimumSize(ref _scissors, index + 1);
            _scissors[index] = new RawRect((int)x, (int)y, (int)(x + width), (int)(y + height));
        }

        /// <summary>
        /// Sets the viewport using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        public override void SetViewport(uint index, ref Viewport viewport)
        {
            _viewportsChanged = true;
            Util.EnsureArrayMinimumSize(ref _viewports, index + 1);
            _viewports[index] = viewport;
        }

        /// <summary>
        /// Binds the texture view using the specified tex view
        /// </summary>
        /// <param name="texView">The tex view</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        /// <param name="resourceSet">The resource set</param>
        private void BindTextureView(D3D11TextureView texView, int slot, ShaderStages stages, uint resourceSet)
        {
            ID3D11ShaderResourceView srv = texView?.ShaderResourceView ?? null;
            if (srv != null)
            {
                if (!_boundSRVs.TryGetValue(texView.Target, out List<BoundTextureInfo> list))
                {
                    list = GetNewOrCachedBoundTextureInfoList();
                    _boundSRVs.Add(texView.Target, list);
                }
                list.Add(new BoundTextureInfo { Slot = slot, Stages = stages, ResourceSet = resourceSet });
            }

            if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
            {
                bool bind = false;
                if (slot < MaxCachedUniformBuffers)
                {
                    if (_vertexBoundTextureViews[slot] != texView)
                    {
                        _vertexBoundTextureViews[slot] = texView;
                        bind = true;
                    }
                }
                else
                {
                    bind = true;
                }
                if (bind)
                {
                    _context.VSSetShaderResource(slot, srv);
                }
            }
            if ((stages & ShaderStages.Geometry) == ShaderStages.Geometry)
            {
                _context.GSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.TessellationControl) == ShaderStages.TessellationControl)
            {
                _context.HSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.TessellationEvaluation) == ShaderStages.TessellationEvaluation)
            {
                _context.DSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
            {
                bool bind = false;
                if (slot < MaxCachedUniformBuffers)
                {
                    if (_fragmentBoundTextureViews[slot] != texView)
                    {
                        _fragmentBoundTextureViews[slot] = texView;
                        bind = true;
                    }
                }
                else
                {
                    bind = true;
                }
                if (bind)
                {
                    _context.PSSetShaderResource(slot, srv);
                }
            }
            if ((stages & ShaderStages.Compute) == ShaderStages.Compute)
            {
                _context.CSSetShaderResource(slot, srv);
            }
        }

        /// <summary>
        /// Gets the new or cached bound texture info list
        /// </summary>
        /// <returns>A list of bound texture info</returns>
        private List<BoundTextureInfo> GetNewOrCachedBoundTextureInfoList()
        {
            if (_boundTextureInfoPool.Count > 0)
            {
                int index = _boundTextureInfoPool.Count - 1;
                List<BoundTextureInfo> ret = _boundTextureInfoPool[index];
                _boundTextureInfoPool.RemoveAt(index);
                return ret;
            }

            return new List<BoundTextureInfo>();
        }

        /// <summary>
        /// Binds the storage buffer view using the specified range
        /// </summary>
        /// <param name="range">The range</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        private void BindStorageBufferView(D3D11BufferRange range, int slot, ShaderStages stages)
        {
            bool compute = (stages & ShaderStages.Compute) != 0;
            UnbindUAVBuffer(range.Buffer);

            ID3D11ShaderResourceView srv = range.Buffer.GetShaderResourceView(range.Offset, range.Size);

            if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
            {
                _context.VSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.Geometry) == ShaderStages.Geometry)
            {
                _context.GSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.TessellationControl) == ShaderStages.TessellationControl)
            {
                _context.HSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.TessellationEvaluation) == ShaderStages.TessellationEvaluation)
            {
                _context.DSSetShaderResource(slot, srv);
            }
            if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
            {
                _context.PSSetShaderResource(slot, srv);
            }
            if (compute)
            {
                _context.CSSetShaderResource(slot, srv);
            }
        }

        /// <summary>
        /// Binds the uniform buffer using the specified range
        /// </summary>
        /// <param name="range">The range</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        private void BindUniformBuffer(D3D11BufferRange range, int slot, ShaderStages stages)
        {
            if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
            {
                bool bind = false;
                if (slot < MaxCachedUniformBuffers)
                {
                    if (!_vertexBoundUniformBuffers[slot].Equals(range))
                    {
                        _vertexBoundUniformBuffers[slot] = range;
                        bind = true;
                    }
                }
                else
                {
                    bind = true;
                }
                if (bind)
                {
                    if (range.IsFullRange)
                    {
                        _context.VSSetConstantBuffer(slot, range.Buffer.Buffer);
                    }
                    else
                    {
                        PackRangeParams(range);
                        if (!_gd.SupportsCommandLists)
                        {
                            _context.VSUnsetConstantBuffer(slot);
                        }
                        _context1.VSSetConstantBuffers1(slot, 1, _cbOut, _firstConstRef, _numConstsRef);
                    }
                }
            }
            if ((stages & ShaderStages.Geometry) == ShaderStages.Geometry)
            {
                if (range.IsFullRange)
                {
                    _context.GSSetConstantBuffer(slot, range.Buffer.Buffer);
                }
                else
                {
                    PackRangeParams(range);
                    if (!_gd.SupportsCommandLists)
                    {
                        _context.GSUnsetConstantBuffer(slot);
                    }
                    _context1.GSSetConstantBuffers1(slot, 1, _cbOut, _firstConstRef, _numConstsRef);
                }
            }
            if ((stages & ShaderStages.TessellationControl) == ShaderStages.TessellationControl)
            {
                if (range.IsFullRange)
                {
                    _context.HSSetConstantBuffer(slot, range.Buffer.Buffer);
                }
                else
                {
                    PackRangeParams(range);
                    if (!_gd.SupportsCommandLists)
                    {
                        _context.HSUnsetConstantBuffer(slot);
                    }
                    _context1.HSSetConstantBuffers1(slot, 1, _cbOut, _firstConstRef, _numConstsRef);
                }
            }
            if ((stages & ShaderStages.TessellationEvaluation) == ShaderStages.TessellationEvaluation)
            {
                if (range.IsFullRange)
                {
                    _context.DSSetConstantBuffer(slot, range.Buffer.Buffer);
                }
                else
                {
                    PackRangeParams(range);
                    if (!_gd.SupportsCommandLists)
                    {
                        _context.DSUnsetConstantBuffer(slot);
                    }
                    _context1.DSSetConstantBuffers1(slot, 1, _cbOut, _firstConstRef, _numConstsRef);
                }
            }
            if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
            {
                bool bind = false;
                if (slot < MaxCachedUniformBuffers)
                {
                    if (!_fragmentBoundUniformBuffers[slot].Equals(range))
                    {
                        _fragmentBoundUniformBuffers[slot] = range;
                        bind = true;
                    }
                }
                else
                {
                    bind = true;
                }
                if (bind)
                {
                    if (range.IsFullRange)
                    {
                        _context.PSSetConstantBuffer(slot, range.Buffer.Buffer);
                    }
                    else
                    {
                        PackRangeParams(range);
                        if (!_gd.SupportsCommandLists)
                        {
                            _context.PSUnsetConstantBuffer(slot);
                        }
                        _context1.PSSetConstantBuffers1(slot, 1, _cbOut, _firstConstRef, _numConstsRef);
                    }
                }
            }
            if ((stages & ShaderStages.Compute) == ShaderStages.Compute)
            {
                if (range.IsFullRange)
                {
                    _context.CSSetConstantBuffer(slot, range.Buffer.Buffer);
                }
                else
                {
                    PackRangeParams(range);
                    if (!_gd.SupportsCommandLists)
                    {
                        _context.CSSetConstantBuffer(slot, (ID3D11Buffer)null);
                    }
                    _context1.CSSetConstantBuffers1(slot, 1, _cbOut, _firstConstRef, _numConstsRef);
                }
            }
        }

        /// <summary>
        /// Packs the range params using the specified range
        /// </summary>
        /// <param name="range">The range</param>
        private void PackRangeParams(D3D11BufferRange range)
        {
            _cbOut[0] = range.Buffer.Buffer;
            _firstConstRef[0] = (int)range.Offset / 16;
            uint roundedSize = range.Size < 256 ? 256u : range.Size;
            _numConstsRef[0] = (int)roundedSize / 16;
        }

        /// <summary>
        /// Binds the unordered access view using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="uav">The uav</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        /// <param name="resourceSet">The resource set</param>
        private void BindUnorderedAccessView(
            Texture texture,
            DeviceBuffer buffer,
            ID3D11UnorderedAccessView uav,
            int slot,
            ShaderStages stages,
            uint resourceSet)
        {
            bool compute = stages == ShaderStages.Compute;
            Debug.Assert(compute || ((stages & ShaderStages.Compute) == 0));
            Debug.Assert(texture == null || buffer == null);

            if (texture != null && uav != null)
            {
                if (!_boundUAVs.TryGetValue(texture, out List<BoundTextureInfo> list))
                {
                    list = GetNewOrCachedBoundTextureInfoList();
                    _boundUAVs.Add(texture, list);
                }
                list.Add(new BoundTextureInfo { Slot = slot, Stages = stages, ResourceSet = resourceSet });
            }

            int baseSlot = 0;
            if (!compute && _fragmentBoundSamplers != null)
            {
                baseSlot = _framebuffer.ColorTargets.Count;
            }
            int actualSlot = baseSlot + slot;

            if (buffer != null)
            {
                TrackBoundUAVBuffer(buffer, actualSlot, compute);
            }

            if (compute)
            {
                _context.CSSetUnorderedAccessView(actualSlot, uav);
            }
            else
            {
                _context.OMSetUnorderedAccessView(actualSlot, uav);
            }
        }

        /// <summary>
        /// Tracks the bound uav buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="slot">The slot</param>
        /// <param name="compute">The compute</param>
        private void TrackBoundUAVBuffer(DeviceBuffer buffer, int slot, bool compute)
        {
            List<(DeviceBuffer, int)> list = compute ? _boundComputeUAVBuffers : _boundOMUAVBuffers;
            list.Add((buffer, slot));
        }

        /// <summary>
        /// Unbinds the uav buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        private void UnbindUAVBuffer(DeviceBuffer buffer)
        {
            UnbindUAVBufferIndividual(buffer, false);
            UnbindUAVBufferIndividual(buffer, true);
        }

        /// <summary>
        /// Unbinds the uav buffer individual using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="compute">The compute</param>
        private void UnbindUAVBufferIndividual(DeviceBuffer buffer, bool compute)
        {
            List<(DeviceBuffer, int)> list = compute ? _boundComputeUAVBuffers : _boundOMUAVBuffers;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1 == buffer)
                {
                    int slot = list[i].Item2;
                    if (compute)
                    {
                        _context.CSUnsetUnorderedAccessView(slot);
                    }
                    else
                    {
                        _context.OMUnsetUnorderedAccessView(slot);
                    }

                    list.RemoveAt(i);
                    i -= 1;
                }
            }
        }

        /// <summary>
        /// Binds the sampler using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="slot">The slot</param>
        /// <param name="stages">The stages</param>
        private void BindSampler(D3D11Sampler sampler, int slot, ShaderStages stages)
        {
            if ((stages & ShaderStages.Vertex) == ShaderStages.Vertex)
            {
                bool bind = false;
                if (slot < MaxCachedSamplers)
                {
                    if (_vertexBoundSamplers[slot] != sampler)
                    {
                        _vertexBoundSamplers[slot] = sampler;
                        bind = true;
                    }
                }
                else
                {
                    bind = true;
                }
                if (bind)
                {
                    _context.VSSetSampler(slot, sampler.DeviceSampler);
                }
            }
            if ((stages & ShaderStages.Geometry) == ShaderStages.Geometry)
            {
                _context.GSSetSampler(slot, sampler.DeviceSampler);
            }
            if ((stages & ShaderStages.TessellationControl) == ShaderStages.TessellationControl)
            {
                _context.HSSetSampler(slot, sampler.DeviceSampler);
            }
            if ((stages & ShaderStages.TessellationEvaluation) == ShaderStages.TessellationEvaluation)
            {
                _context.DSSetSampler(slot, sampler.DeviceSampler);
            }
            if ((stages & ShaderStages.Fragment) == ShaderStages.Fragment)
            {
                bool bind = false;
                if (slot < MaxCachedSamplers)
                {
                    if (_fragmentBoundSamplers[slot] != sampler)
                    {
                        _fragmentBoundSamplers[slot] = sampler;
                        bind = true;
                    }
                }
                else
                {
                    bind = true;
                }
                if (bind)
                {
                    _context.PSSetSampler(slot, sampler.DeviceSampler);
                }
            }
            if((stages & ShaderStages.Compute) == ShaderStages.Compute)
            {
                _context.CSSetSampler(slot, sampler.DeviceSampler);
            }
        }

        /// <summary>
        /// Sets the framebuffer core using the specified fb
        /// </summary>
        /// <param name="fb">The fb</param>
        protected override void SetFramebufferCore(Framebuffer fb)
        {
            D3D11Framebuffer d3dFB = Util.AssertSubtype<Framebuffer, D3D11Framebuffer>(fb);
            if (d3dFB.Swapchain != null)
            {
                d3dFB.Swapchain.AddCommandListReference(this);
                _referencedSwapchains.Add(d3dFB.Swapchain);
            }

            for (int i = 0; i < fb.ColorTargets.Count; i++)
            {
                UnbindSRVTexture(fb.ColorTargets[i].Target);
            }

            _context.OMSetRenderTargets(d3dFB.RenderTargetViews, d3dFB.DepthStencilView);
        }

        /// <summary>
        /// Clears the color target core using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        private protected override void ClearColorTargetCore(uint index, RgbaFloat clearColor)
        {
            _context.ClearRenderTargetView(D3D11Framebuffer.RenderTargetViews[index], new Color4(clearColor.R, clearColor.G, clearColor.B, clearColor.A));
        }

        /// <summary>
        /// Clears the depth stencil core using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <param name="stencil">The stencil</param>
        private protected override void ClearDepthStencilCore(float depth, byte stencil)
        {
            _context.ClearDepthStencilView(D3D11Framebuffer.DepthStencilView, DepthStencilClearFlags.Depth | DepthStencilClearFlags.Stencil, depth, stencil);
        }

        /// <summary>
        /// Updates the buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        private protected unsafe override void UpdateBufferCore(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes)
        {
            D3D11Buffer d3dBuffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(buffer);
            if (sizeInBytes == 0)
            {
                return;
            }

            bool isDynamic = (buffer.Usage & BufferUsage.Dynamic) == BufferUsage.Dynamic;
            bool isStaging = (buffer.Usage & BufferUsage.Staging) == BufferUsage.Staging;
            bool isUniformBuffer = (buffer.Usage & BufferUsage.UniformBuffer) == BufferUsage.UniformBuffer;
            bool useMap = isDynamic;
            bool updateFullBuffer = bufferOffsetInBytes == 0 && sizeInBytes == buffer.SizeInBytes;
            bool useUpdateSubresource = !isDynamic && !isStaging && (!isUniformBuffer || updateFullBuffer);

            if (useUpdateSubresource)
            {
                Box? subregion = new Box((int)bufferOffsetInBytes, 0, 0, (int)(sizeInBytes + bufferOffsetInBytes), 1, 1);
                if (isUniformBuffer)
                {
                    subregion = null;
                }

                if (bufferOffsetInBytes == 0)
                {
                    _context.UpdateSubresource(d3dBuffer.Buffer, 0, subregion, source, 0, 0);
                }
                else
                {
                    UpdateSubresource_Workaround(d3dBuffer.Buffer, 0, subregion.Value, source);
                }
            }
            else if (useMap && updateFullBuffer) // Can only update full buffer with WriteDiscard.
            {
                MappedSubresource msb = _context.Map(
                     d3dBuffer.Buffer,
                     0,
                     D3D11Formats.VdToD3D11MapMode(isDynamic, MapMode.Write),
                     MapFlags.None);
                if (sizeInBytes < 1024)
                {
                    Unsafe.CopyBlock(msb.DataPointer.ToPointer(), source.ToPointer(), sizeInBytes);
                }
                else
                {
                    Buffer.MemoryCopy(source.ToPointer(), msb.DataPointer.ToPointer(), buffer.SizeInBytes, sizeInBytes);
                }
                _context.Unmap(d3dBuffer.Buffer, 0);
            }
            else
            {
                D3D11Buffer staging = GetFreeStagingBuffer(sizeInBytes);
                _gd.UpdateBuffer(staging, 0, source, sizeInBytes);
                CopyBuffer(staging, 0, buffer, bufferOffsetInBytes, sizeInBytes);
                _submittedStagingBuffers.Add(staging);
            }
        }

        /// <summary>
        /// Updates the subresource workaround using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="subresource">The subresource</param>
        /// <param name="region">The region</param>
        /// <param name="data">The data</param>
        private unsafe void UpdateSubresource_Workaround(
            ID3D11Resource resource,
            int subresource,
            Box region,
            IntPtr data)
        {
            bool needWorkaround = !_gd.SupportsCommandLists;
            void* pAdjustedSrcData = data.ToPointer();
            if (needWorkaround)
            {
                Debug.Assert(region.Top == 0 && region.Front == 0);
                pAdjustedSrcData = (byte*)data - region.Left;
            }

            _context.UpdateSubresource(resource, subresource, region, (IntPtr)pAdjustedSrcData, 0, 0);
        }


        /// <summary>
        /// Gets the free staging buffer using the specified size in bytes
        /// </summary>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <returns>The 11 buffer</returns>
        private D3D11Buffer GetFreeStagingBuffer(uint sizeInBytes)
        {
            foreach (D3D11Buffer buffer in _availableStagingBuffers)
            {
                if (buffer.SizeInBytes >= sizeInBytes)
                {
                    _availableStagingBuffers.Remove(buffer);
                    return buffer;
                }
            }

            DeviceBuffer staging = _gd.ResourceFactory.CreateBuffer(
                new BufferDescription(sizeInBytes, BufferUsage.Staging));

            return Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(staging);
        }

        /// <summary>
        /// Copies the buffer core using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destination">The destination</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        protected override void CopyBufferCore(DeviceBuffer source, uint sourceOffset, DeviceBuffer destination, uint destinationOffset, uint sizeInBytes)
        {
            D3D11Buffer srcD3D11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(source);
            D3D11Buffer dstD3D11Buffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(destination);

            Box region = new Box((int)sourceOffset, 0, 0, (int)(sourceOffset + sizeInBytes), 1, 1);

            _context.CopySubresourceRegion(dstD3D11Buffer.Buffer, 0, (int)destinationOffset, 0, 0, srcD3D11Buffer.Buffer, 0, region);
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
            D3D11Texture srcD3D11Texture = Util.AssertSubtype<Texture, D3D11Texture>(source);
            D3D11Texture dstD3D11Texture = Util.AssertSubtype<Texture, D3D11Texture>(destination);

            uint blockSize = FormatHelpers.IsCompressedFormat(source.Format) ? 4u : 1u;
            uint clampedWidth = Math.Max(blockSize, width);
            uint clampedHeight = Math.Max(blockSize, height);

            Box? region = null;
            if (srcX != 0 || srcY != 0 || srcZ != 0
                || clampedWidth != source.Width || clampedHeight != source.Height || depth != source.Depth)
            {
                region = new Box(
                    (int)srcX,
                    (int)srcY,
                    (int)srcZ,
                    (int)(srcX + clampedWidth),
                    (int)(srcY + clampedHeight),
                    (int)(srcZ + depth));
            }

            for (uint i = 0; i < layerCount; i++)
            {
                int srcSubresource = D3D11Util.ComputeSubresource(srcMipLevel, source.MipLevels, srcBaseArrayLayer + i);
                int dstSubresource = D3D11Util.ComputeSubresource(dstMipLevel, destination.MipLevels, dstBaseArrayLayer + i);

                _context.CopySubresourceRegion(
                    dstD3D11Texture.DeviceTexture,
                    dstSubresource,
                    (int)dstX,
                    (int)dstY,
                    (int)dstZ,
                    srcD3D11Texture.DeviceTexture,
                    srcSubresource,
                    region);
            }
        }

        /// <summary>
        /// Generates the mipmaps core using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        private protected override void GenerateMipmapsCore(Texture texture)
        {
            TextureView fullTexView = texture.GetFullTextureView(_gd);
            D3D11TextureView d3d11View = Util.AssertSubtype<TextureView, D3D11TextureView>(fullTexView);
            ID3D11ShaderResourceView srv = d3d11View.ShaderResourceView;
            _context.GenerateMips(srv);
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
                _context.DebugName = value;
            }
        }

        /// <summary>
        /// Ons the completed
        /// </summary>
        internal void OnCompleted()
        {
            _commandList.Dispose();
            _commandList = null;

            foreach (D3D11Swapchain sc in _referencedSwapchains)
            {
                sc.RemoveCommandListReference(this);
            }
            _referencedSwapchains.Clear();

            foreach (D3D11Buffer buffer in _submittedStagingBuffers)
            {
                _availableStagingBuffers.Add(buffer);
            }

            _submittedStagingBuffers.Clear();
        }

        /// <summary>
        /// Pushes the debug group core using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        private protected override void PushDebugGroupCore(string name)
        {
            _uda?.BeginEvent(name);
        }

        /// <summary>
        /// Pops the debug group core
        /// </summary>
        private protected override void PopDebugGroupCore()
        {
            _uda?.EndEvent();
        }

        /// <summary>
        /// Inserts the debug marker core using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        private protected override void InsertDebugMarkerCore(string name)
        {
            _uda?.SetMarker(name);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _uda?.Dispose();
                DeviceCommandList?.Dispose();
                _context1?.Dispose();
                _context.Dispose();

                foreach (BoundResourceSetInfo boundGraphicsSet in _graphicsResourceSets)
                {
                    boundGraphicsSet.Offsets.Dispose();
                }
                foreach (BoundResourceSetInfo boundComputeSet in _computeResourceSets)
                {
                    boundComputeSet.Offsets.Dispose();
                }

                foreach (D3D11Buffer buffer in _availableStagingBuffers)
                {
                    buffer.Dispose();
                }
                _availableStagingBuffers.Clear();

                _disposed = true;
            }
        }

        /// <summary>
        /// The bound texture info
        /// </summary>
        private struct BoundTextureInfo
        {
            /// <summary>
            /// The slot
            /// </summary>
            public int Slot;
            /// <summary>
            /// The stages
            /// </summary>
            public ShaderStages Stages;
            /// <summary>
            /// The resource set
            /// </summary>
            public uint ResourceSet;
        }

        /// <summary>
        /// The 11 buffer range
        /// </summary>
        private struct D3D11BufferRange : IEquatable<D3D11BufferRange>
        {
            /// <summary>
            /// The buffer
            /// </summary>
            public readonly D3D11Buffer Buffer;
            /// <summary>
            /// The offset
            /// </summary>
            public readonly uint Offset;
            /// <summary>
            /// The size
            /// </summary>
            public readonly uint Size;

            /// <summary>
            /// Gets the value of the is full range
            /// </summary>
            public bool IsFullRange => Offset == 0 && Size == Buffer.SizeInBytes;

            /// <summary>
            /// Initializes a new instance of the <see cref="D3D11BufferRange"/> class
            /// </summary>
            /// <param name="buffer">The buffer</param>
            /// <param name="offset">The offset</param>
            /// <param name="size">The size</param>
            public D3D11BufferRange(D3D11Buffer buffer, uint offset, uint size)
            {
                Buffer = buffer;
                Offset = offset;
                Size = size;
            }

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The bool</returns>
            public bool Equals(D3D11BufferRange other)
            {
                return Buffer == other.Buffer && Offset.Equals(other.Offset) && Size.Equals(other.Size);
            }
        }
    }
}
