using Vortice.Direct3D11;
using System.Diagnostics;
using System;
using Vortice.Mathematics;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 pipeline class
    /// </summary>
    /// <seealso cref="Pipeline"/>
    internal class D3D11Pipeline : Pipeline
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the blend state
        /// </summary>
        public ID3D11BlendState BlendState { get; }
        /// <summary>
        /// Gets the value of the blend factor
        /// </summary>
        public Color4 BlendFactor { get; }
        /// <summary>
        /// Gets the value of the depth stencil state
        /// </summary>
        public ID3D11DepthStencilState DepthStencilState { get; }
        /// <summary>
        /// Gets the value of the stencil reference
        /// </summary>
        public uint StencilReference { get; }
        /// <summary>
        /// Gets the value of the rasterizer state
        /// </summary>
        public ID3D11RasterizerState RasterizerState { get; }
        /// <summary>
        /// Gets the value of the primitive topology
        /// </summary>
        public Vortice.Direct3D.PrimitiveTopology PrimitiveTopology { get; }
        /// <summary>
        /// Gets the value of the input layout
        /// </summary>
        public ID3D11InputLayout InputLayout { get; }
        /// <summary>
        /// Gets the value of the vertex shader
        /// </summary>
        public ID3D11VertexShader VertexShader { get; }
        /// <summary>
        /// Gets the value of the geometry shader
        /// </summary>
        public ID3D11GeometryShader GeometryShader { get; } // May be null.
        /// <summary>
        /// Gets the value of the hull shader
        /// </summary>
        public ID3D11HullShader HullShader { get; } // May be null.
        /// <summary>
        /// Gets the value of the domain shader
        /// </summary>
        public ID3D11DomainShader DomainShader { get; } // May be null.
        /// <summary>
        /// Gets the value of the pixel shader
        /// </summary>
        public ID3D11PixelShader PixelShader { get; }
        /// <summary>
        /// Gets the value of the compute shader
        /// </summary>
        public ID3D11ComputeShader ComputeShader { get; }
        /// <summary>
        /// Gets the value of the resource layouts
        /// </summary>
        public new D3D11ResourceLayout[] ResourceLayouts { get; }
        /// <summary>
        /// Gets the value of the vertex strides
        /// </summary>
        public int[] VertexStrides { get; }

        /// <summary>
        /// Gets the value of the is compute pipeline
        /// </summary>
        public override bool IsComputePipeline { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Pipeline"/> class
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="description">The description</param>
        public D3D11Pipeline(D3D11ResourceCache cache, ref GraphicsPipelineDescription description)
            : base(ref description)
        {
            byte[] vsBytecode = null;
            Shader[] stages = description.ShaderSet.Shaders;
            for (int i = 0; i < description.ShaderSet.Shaders.Length; i++)
            {
                if (stages[i].Stage == ShaderStages.Vertex)
                {
                    D3D11Shader d3d11VertexShader = ((D3D11Shader)stages[i]);
                    VertexShader = (ID3D11VertexShader)d3d11VertexShader.DeviceShader;
                    vsBytecode = d3d11VertexShader.Bytecode;
                }
                if (stages[i].Stage == ShaderStages.Geometry)
                {
                    GeometryShader = (ID3D11GeometryShader)((D3D11Shader)stages[i]).DeviceShader;
                }
                if (stages[i].Stage == ShaderStages.TessellationControl)
                {
                    HullShader = (ID3D11HullShader)((D3D11Shader)stages[i]).DeviceShader;
                }
                if (stages[i].Stage == ShaderStages.TessellationEvaluation)
                {
                    DomainShader = (ID3D11DomainShader)((D3D11Shader)stages[i]).DeviceShader;
                }
                if (stages[i].Stage == ShaderStages.Fragment)
                {
                    PixelShader = (ID3D11PixelShader)((D3D11Shader)stages[i]).DeviceShader;
                }
                if (stages[i].Stage == ShaderStages.Compute)
                {
                    ComputeShader = (ID3D11ComputeShader)((D3D11Shader)stages[i]).DeviceShader;
                }
            }

            cache.GetPipelineResources(
                ref description.BlendState,
                ref description.DepthStencilState,
                ref description.RasterizerState,
                description.Outputs.SampleCount != TextureSampleCount.Count1,
                description.ShaderSet.VertexLayouts,
                vsBytecode,
                out ID3D11BlendState blendState,
                out ID3D11DepthStencilState depthStencilState,
                out ID3D11RasterizerState rasterizerState,
                out ID3D11InputLayout inputLayout);

            BlendState = blendState;
            BlendFactor = new Color4(description.BlendState.BlendFactor.ToVector4());
            DepthStencilState = depthStencilState;
            StencilReference = description.DepthStencilState.StencilReference;
            RasterizerState = rasterizerState;
            PrimitiveTopology = D3D11Formats.VdToD3D11PrimitiveTopology(description.PrimitiveTopology);

            ResourceLayout[] genericLayouts = description.ResourceLayouts;
            ResourceLayouts = new D3D11ResourceLayout[genericLayouts.Length];
            for (int i = 0; i < ResourceLayouts.Length; i++)
            {
                ResourceLayouts[i] = Util.AssertSubtype<ResourceLayout, D3D11ResourceLayout>(genericLayouts[i]);
            }

            Debug.Assert(vsBytecode != null || ComputeShader != null);
            if (vsBytecode != null && description.ShaderSet.VertexLayouts.Length > 0)
            {
                InputLayout = inputLayout;
                int numVertexBuffers = description.ShaderSet.VertexLayouts.Length;
                VertexStrides = new int[numVertexBuffers];
                for (int i = 0; i < numVertexBuffers; i++)
                {
                    VertexStrides[i] = (int)description.ShaderSet.VertexLayouts[i].Stride;
                }
            }
            else
            {
                VertexStrides = Array.Empty<int>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Pipeline"/> class
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="description">The description</param>
        public D3D11Pipeline(D3D11ResourceCache cache, ref ComputePipelineDescription description)
            : base(ref description)
        {
            IsComputePipeline = true;
            ComputeShader = (ID3D11ComputeShader)((D3D11Shader)description.ComputeShader).DeviceShader;
            ResourceLayout[] genericLayouts = description.ResourceLayouts;
            ResourceLayouts = new D3D11ResourceLayout[genericLayouts.Length];
            for (int i = 0; i < ResourceLayouts.Length; i++)
            {
                ResourceLayouts[i] = Util.AssertSubtype<ResourceLayout, D3D11ResourceLayout>(genericLayouts[i]);
            }
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            _disposed = true;
        }
    }
}
