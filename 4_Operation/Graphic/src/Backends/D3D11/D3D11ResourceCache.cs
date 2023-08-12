using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Vortice.Direct3D11;

namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 resource cache class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class D3D11ResourceCache : IDisposable
    {
        /// <summary>
        /// The device
        /// </summary>
        private readonly ID3D11Device _device;
        /// <summary>
        /// The lock
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// The id 11 blend state
        /// </summary>
        private readonly Dictionary<BlendStateDescription, ID3D11BlendState> _blendStates
            = new Dictionary<BlendStateDescription, ID3D11BlendState>();

        /// <summary>
        /// The id 11 depth stencil state
        /// </summary>
        private readonly Dictionary<DepthStencilStateDescription, ID3D11DepthStencilState> _depthStencilStates
            = new Dictionary<DepthStencilStateDescription, ID3D11DepthStencilState>();

        /// <summary>
        /// The id 11 rasterizer state
        /// </summary>
        private readonly Dictionary<D3D11RasterizerStateCacheKey, ID3D11RasterizerState> _rasterizerStates
            = new Dictionary<D3D11RasterizerStateCacheKey, ID3D11RasterizerState>();

        /// <summary>
        /// The id 11 input layout
        /// </summary>
        private readonly Dictionary<InputLayoutCacheKey, ID3D11InputLayout> _inputLayouts
            = new Dictionary<InputLayoutCacheKey, ID3D11InputLayout>();

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ResourceCache"/> class
        /// </summary>
        /// <param name="device">The device</param>
        public D3D11ResourceCache(ID3D11Device device)
        {
            _device = device;
        }

        /// <summary>
        /// Gets the pipeline resources using the specified blend desc
        /// </summary>
        /// <param name="blendDesc">The blend desc</param>
        /// <param name="dssDesc">The dss desc</param>
        /// <param name="rasterDesc">The raster desc</param>
        /// <param name="multisample">The multisample</param>
        /// <param name="vertexLayouts">The vertex layouts</param>
        /// <param name="vsBytecode">The vs bytecode</param>
        /// <param name="blendState">The blend state</param>
        /// <param name="depthState">The depth state</param>
        /// <param name="rasterState">The raster state</param>
        /// <param name="inputLayout">The input layout</param>
        public void GetPipelineResources(
            ref BlendStateDescription blendDesc,
            ref DepthStencilStateDescription dssDesc,
            ref RasterizerStateDescription rasterDesc,
            bool multisample,
            VertexLayoutDescription[] vertexLayouts,
            byte[] vsBytecode,
            out ID3D11BlendState blendState,
            out ID3D11DepthStencilState depthState,
            out ID3D11RasterizerState rasterState,
            out ID3D11InputLayout inputLayout)
        {
            lock (_lock)
            {
                blendState = GetBlendState(ref blendDesc);
                depthState = GetDepthStencilState(ref dssDesc);
                rasterState = GetRasterizerState(ref rasterDesc, multisample);
                inputLayout = GetInputLayout(vertexLayouts, vsBytecode);
            }
        }

        /// <summary>
        /// Gets the blend state using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The blend state</returns>
        private ID3D11BlendState GetBlendState(ref BlendStateDescription description)
        {
            Debug.Assert(Monitor.IsEntered(_lock));
            if (!_blendStates.TryGetValue(description, out ID3D11BlendState blendState))
            {
                blendState = CreateNewBlendState(ref description);
                BlendStateDescription key = description;
                key.AttachmentStates = (BlendAttachmentDescription[])key.AttachmentStates.Clone();
                _blendStates.Add(key, blendState);
            }

            return blendState;
        }

        /// <summary>
        /// Creates the new blend state using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The id 11 blend state</returns>
        private ID3D11BlendState CreateNewBlendState(ref BlendStateDescription description)
        {
            BlendAttachmentDescription[] attachmentStates = description.AttachmentStates;
            Vortice.Direct3D11.BlendDescription d3dBlendStateDesc = new Vortice.Direct3D11.BlendDescription();

            for (int i = 0; i < attachmentStates.Length; i++)
            {
                BlendAttachmentDescription state = attachmentStates[i];
                d3dBlendStateDesc.RenderTarget[i].IsBlendEnabled = state.BlendEnabled;
                d3dBlendStateDesc.RenderTarget[i].RenderTargetWriteMask = D3D11Formats.VdToD3D11ColorWriteEnable(state.ColorWriteMask.GetOrDefault());
                d3dBlendStateDesc.RenderTarget[i].SourceBlend = D3D11Formats.VdToD3D11Blend(state.SourceColorFactor);
                d3dBlendStateDesc.RenderTarget[i].DestinationBlend = D3D11Formats.VdToD3D11Blend(state.DestinationColorFactor);
                d3dBlendStateDesc.RenderTarget[i].BlendOperation = D3D11Formats.VdToD3D11BlendOperation(state.ColorFunction);
                d3dBlendStateDesc.RenderTarget[i].SourceBlendAlpha = D3D11Formats.VdToD3D11Blend(state.SourceAlphaFactor);
                d3dBlendStateDesc.RenderTarget[i].DestinationBlendAlpha = D3D11Formats.VdToD3D11Blend(state.DestinationAlphaFactor);
                d3dBlendStateDesc.RenderTarget[i].BlendOperationAlpha = D3D11Formats.VdToD3D11BlendOperation(state.AlphaFunction);
            }

            d3dBlendStateDesc.AlphaToCoverageEnable = description.AlphaToCoverageEnabled;
            d3dBlendStateDesc.IndependentBlendEnable = true;

            return _device.CreateBlendState(d3dBlendStateDesc);
        }

        /// <summary>
        /// Gets the depth stencil state using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The dss</returns>
        private ID3D11DepthStencilState GetDepthStencilState(ref DepthStencilStateDescription description)
        {
            Debug.Assert(Monitor.IsEntered(_lock));
            if (!_depthStencilStates.TryGetValue(description, out ID3D11DepthStencilState dss))
            {
                dss = CreateNewDepthStencilState(ref description);
                DepthStencilStateDescription key = description;
                _depthStencilStates.Add(key, dss);
            }

            return dss;
        }

        /// <summary>
        /// Creates the new depth stencil state using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The id 11 depth stencil state</returns>
        private ID3D11DepthStencilState CreateNewDepthStencilState(ref DepthStencilStateDescription description)
        {
            DepthStencilDescription dssDesc = new DepthStencilDescription
            {
                DepthFunc = D3D11Formats.VdToD3D11ComparisonFunc(description.DepthComparison),
                DepthEnable = description.DepthTestEnabled,
                DepthWriteMask = description.DepthWriteEnabled ? DepthWriteMask.All : DepthWriteMask.Zero,
                StencilEnable = description.StencilTestEnabled,
                FrontFace = ToD3D11StencilOpDesc(description.StencilFront),
                BackFace = ToD3D11StencilOpDesc(description.StencilBack),
                StencilReadMask = description.StencilReadMask,
                StencilWriteMask = description.StencilWriteMask
            };

            return _device.CreateDepthStencilState(dssDesc);
        }

        /// <summary>
        /// Returns the d 3 d 11 stencil op desc using the specified sbd
        /// </summary>
        /// <param name="sbd">The sbd</param>
        /// <returns>The depth stencil operation description</returns>
        private DepthStencilOperationDescription ToD3D11StencilOpDesc(StencilBehaviorDescription sbd)
        {
            return new DepthStencilOperationDescription
            {
                StencilFunc = D3D11Formats.VdToD3D11ComparisonFunc(sbd.Comparison),
                StencilPassOp = D3D11Formats.VdToD3D11StencilOperation(sbd.Pass),
                StencilFailOp = D3D11Formats.VdToD3D11StencilOperation(sbd.Fail),
                StencilDepthFailOp = D3D11Formats.VdToD3D11StencilOperation(sbd.DepthFail)
            };
        }

        /// <summary>
        /// Gets the rasterizer state using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="multisample">The multisample</param>
        /// <returns>The rasterizer state</returns>
        private ID3D11RasterizerState GetRasterizerState(ref RasterizerStateDescription description, bool multisample)
        {
            Debug.Assert(Monitor.IsEntered(_lock));
            D3D11RasterizerStateCacheKey key = new D3D11RasterizerStateCacheKey(description, multisample);
            if (!_rasterizerStates.TryGetValue(key, out ID3D11RasterizerState rasterizerState))
            {
                rasterizerState = CreateNewRasterizerState(ref key);
                _rasterizerStates.Add(key, rasterizerState);
            }

            return rasterizerState;
        }

        /// <summary>
        /// Creates the new rasterizer state using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The id 11 rasterizer state</returns>
        private ID3D11RasterizerState CreateNewRasterizerState(ref D3D11RasterizerStateCacheKey key)
        {
            RasterizerDescription rssDesc = new RasterizerDescription
            {
                CullMode = D3D11Formats.VdToD3D11CullMode(key.VeldridDescription.CullMode),
                FillMode = D3D11Formats.VdToD3D11FillMode(key.VeldridDescription.FillMode),
                DepthClipEnable = key.VeldridDescription.DepthClipEnabled,
                ScissorEnable = key.VeldridDescription.ScissorTestEnabled,
                FrontCounterClockwise = key.VeldridDescription.FrontFace == FrontFace.CounterClockwise,
                MultisampleEnable = key.Multisampled
            };

            return _device.CreateRasterizerState(rssDesc);
        }

        /// <summary>
        /// Gets the input layout using the specified vertex layouts
        /// </summary>
        /// <param name="vertexLayouts">The vertex layouts</param>
        /// <param name="vsBytecode">The vs bytecode</param>
        /// <returns>The input layout</returns>
        private ID3D11InputLayout GetInputLayout(VertexLayoutDescription[] vertexLayouts, byte[] vsBytecode)
        {
            Debug.Assert(Monitor.IsEntered(_lock));

            if (vsBytecode == null || vertexLayouts == null || vertexLayouts.Length == 0) { return null; }

            InputLayoutCacheKey tempKey = InputLayoutCacheKey.CreateTempKey(vertexLayouts);
            if (!_inputLayouts.TryGetValue(tempKey, out ID3D11InputLayout inputLayout))
            {
                inputLayout = CreateNewInputLayout(vertexLayouts, vsBytecode);
                InputLayoutCacheKey permanentKey = InputLayoutCacheKey.CreatePermanentKey(vertexLayouts);
                _inputLayouts.Add(permanentKey, inputLayout);
            }

            return inputLayout;
        }

        /// <summary>
        /// Creates the new input layout using the specified vertex layouts
        /// </summary>
        /// <param name="vertexLayouts">The vertex layouts</param>
        /// <param name="vsBytecode">The vs bytecode</param>
        /// <returns>The id 11 input layout</returns>
        private ID3D11InputLayout CreateNewInputLayout(VertexLayoutDescription[] vertexLayouts, byte[] vsBytecode)
        {
            int totalCount = 0;
            for (int i = 0; i < vertexLayouts.Length; i++)
            {
                totalCount += vertexLayouts[i].Elements.Length;
            }

            int element = 0; // Total element index across slots.
            InputElementDescription[] elements = new InputElementDescription[totalCount];
            SemanticIndices si = new SemanticIndices();
            for (int slot = 0; slot < vertexLayouts.Length; slot++)
            {
                VertexElementDescription[] elementDescs = vertexLayouts[slot].Elements;
                uint stepRate = vertexLayouts[slot].InstanceStepRate;
                int currentOffset = 0;
                for (int i = 0; i < elementDescs.Length; i++)
                {
                    VertexElementDescription desc = elementDescs[i];
                    elements[element] = new InputElementDescription(
                        GetSemanticString(desc.Semantic),
                        SemanticIndices.GetAndIncrement(ref si, desc.Semantic),
                        D3D11Formats.ToDxgiFormat(desc.Format),
                        desc.Offset != 0 ? (int)desc.Offset : currentOffset,
                        slot,
                        stepRate == 0 ? InputClassification.PerVertexData : InputClassification.PerInstanceData,
                        (int)stepRate);

                    currentOffset += (int)FormatSizeHelpers.GetSizeInBytes(desc.Format);
                    element += 1;
                }
            }

            return _device.CreateInputLayout(elements, vsBytecode);
        }

        /// <summary>
        /// Gets the semantic string using the specified semantic
        /// </summary>
        /// <param name="semantic">The semantic</param>
        /// <returns>The string</returns>
        private string GetSemanticString(VertexElementSemantic semantic)
        {
            switch (semantic)
            {
                case VertexElementSemantic.Position:
                    return "POSITION";
                case VertexElementSemantic.Normal:
                    return "NORMAL";
                case VertexElementSemantic.TextureCoordinate:
                    return "TEXCOORD";
                case VertexElementSemantic.Color:
                    return "COLOR";
                default:
                    throw Illegal.Value<VertexElementSemantic>();
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            foreach (KeyValuePair<BlendStateDescription, ID3D11BlendState> kvp in _blendStates)
            {
                kvp.Value.Dispose();
            }
            foreach (KeyValuePair<DepthStencilStateDescription, ID3D11DepthStencilState> kvp in _depthStencilStates)
            {
                kvp.Value.Dispose();
            }
            foreach (KeyValuePair<D3D11RasterizerStateCacheKey, ID3D11RasterizerState> kvp in _rasterizerStates)
            {
                kvp.Value.Dispose();
            }
            foreach (KeyValuePair<InputLayoutCacheKey, ID3D11InputLayout> kvp in _inputLayouts)
            {
                kvp.Value.Dispose();
            }
        }

        /// <summary>
        /// The semantic indices
        /// </summary>
        private struct SemanticIndices
        {
            /// <summary>
            /// The position
            /// </summary>
            private int _position;
            /// <summary>
            /// The tex coord
            /// </summary>
            private int _texCoord;
            /// <summary>
            /// The normal
            /// </summary>
            private int _normal;
            /// <summary>
            /// The color
            /// </summary>
            private int _color;

            /// <summary>
            /// Gets the and increment using the specified si
            /// </summary>
            /// <param name="si">The si</param>
            /// <param name="type">The type</param>
            /// <returns>The int</returns>
            public static int GetAndIncrement(ref SemanticIndices si, VertexElementSemantic type)
            {
                switch (type)
                {
                    case VertexElementSemantic.Position:
                        return si._position++;
                    case VertexElementSemantic.TextureCoordinate:
                        return si._texCoord++;
                    case VertexElementSemantic.Normal:
                        return si._normal++;
                    case VertexElementSemantic.Color:
                        return si._color++;
                    default:
                        throw Illegal.Value<VertexElementSemantic>();
                }
            }
        }

        /// <summary>
        /// The input layout cache key
        /// </summary>
        private struct InputLayoutCacheKey : IEquatable<InputLayoutCacheKey>
        {
            /// <summary>
            /// The vertex layouts
            /// </summary>
            public VertexLayoutDescription[] VertexLayouts;

            /// <summary>
            /// Creates the temp key using the specified original
            /// </summary>
            /// <param name="original">The original</param>
            /// <returns>The input layout cache key</returns>
            public static InputLayoutCacheKey CreateTempKey(VertexLayoutDescription[] original)
                => new InputLayoutCacheKey { VertexLayouts = original };

            /// <summary>
            /// Creates the permanent key using the specified original
            /// </summary>
            /// <param name="original">The original</param>
            /// <returns>The input layout cache key</returns>
            public static InputLayoutCacheKey CreatePermanentKey(VertexLayoutDescription[] original)
            {
                VertexLayoutDescription[] vertexLayouts = new VertexLayoutDescription[original.Length];
                for (int i = 0; i < original.Length; i++)
                {
                    vertexLayouts[i].Stride = original[i].Stride;
                    vertexLayouts[i].InstanceStepRate = original[i].InstanceStepRate;
                    vertexLayouts[i].Elements = (VertexElementDescription[])original[i].Elements.Clone();
                }

                return new InputLayoutCacheKey { VertexLayouts = vertexLayouts };
            }

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The bool</returns>
            public bool Equals(InputLayoutCacheKey other)
            {
                return Util.ArrayEqualsEquatable(VertexLayouts, other.VertexLayouts);
            }

            /// <summary>
            /// Gets the hash code
            /// </summary>
            /// <returns>The int</returns>
            public override int GetHashCode()
            {
                return HashHelper.Array(VertexLayouts);
            }
        }

        /// <summary>
        /// The 11 rasterizer state cache key
        /// </summary>
        private struct D3D11RasterizerStateCacheKey : IEquatable<D3D11RasterizerStateCacheKey>
        {
            /// <summary>
            /// The veldrid description
            /// </summary>
            public RasterizerStateDescription VeldridDescription;
            /// <summary>
            /// The multisampled
            /// </summary>
            public bool Multisampled;

            /// <summary>
            /// Initializes a new instance of the <see cref="D3D11RasterizerStateCacheKey"/> class
            /// </summary>
            /// <param name="veldridDescription">The veldrid description</param>
            /// <param name="multisampled">The multisampled</param>
            public D3D11RasterizerStateCacheKey(RasterizerStateDescription veldridDescription, bool multisampled)
            {
                VeldridDescription = veldridDescription;
                Multisampled = multisampled;
            }

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The bool</returns>
            public bool Equals(D3D11RasterizerStateCacheKey other)
            {
                return VeldridDescription.Equals(other.VeldridDescription)
                    && Multisampled.Equals(other.Multisampled);
            }

            /// <summary>
            /// Gets the hash code
            /// </summary>
            /// <returns>The int</returns>
            public override int GetHashCode()
            {
                return HashHelper.Combine(VeldridDescription.GetHashCode(), Multisampled.GetHashCode());
            }
        }
    }
}
