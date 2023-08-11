using System;
using System.Collections.Generic;
using System.Diagnostics;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl pipeline class
    /// </summary>
    /// <seealso cref="Pipeline"/>
    internal class MTLPipeline : Pipeline
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// The specialized functions
        /// </summary>
        private List<MTLFunction> _specializedFunctions;

        /// <summary>
        /// Gets the value of the render pipeline state
        /// </summary>
        public MTLRenderPipelineState RenderPipelineState { get; }
        /// <summary>
        /// Gets the value of the compute pipeline state
        /// </summary>
        public MTLComputePipelineState ComputePipelineState { get; }
        /// <summary>
        /// Gets the value of the primitive type
        /// </summary>
        public MTLPrimitiveType PrimitiveType { get; }
        /// <summary>
        /// Gets the value of the resource layouts
        /// </summary>
        public new MTLResourceLayout[] ResourceLayouts { get; }
        /// <summary>
        /// Gets the value of the resource binding model
        /// </summary>
        public ResourceBindingModel ResourceBindingModel { get; }
        /// <summary>
        /// Gets the value of the vertex buffer count
        /// </summary>
        public uint VertexBufferCount { get; }
        /// <summary>
        /// Gets the value of the non vertex buffer count
        /// </summary>
        public uint NonVertexBufferCount { get; }
        /// <summary>
        /// Gets the value of the cull mode
        /// </summary>
        public MTLCullMode CullMode { get; }
        /// <summary>
        /// Gets the value of the front face
        /// </summary>
        public MTLWinding FrontFace { get; }
        /// <summary>
        /// Gets the value of the fill mode
        /// </summary>
        public MTLTriangleFillMode FillMode { get; }
        /// <summary>
        /// Gets the value of the depth stencil state
        /// </summary>
        public MTLDepthStencilState DepthStencilState { get; }
        /// <summary>
        /// Gets the value of the depth clip mode
        /// </summary>
        public MTLDepthClipMode DepthClipMode { get; }
        /// <summary>
        /// Gets the value of the is compute pipeline
        /// </summary>
        public override bool IsComputePipeline { get; }
        /// <summary>
        /// Gets the value of the scissor test enabled
        /// </summary>
        public bool ScissorTestEnabled { get; }
        /// <summary>
        /// Gets the value of the threads per threadgroup
        /// </summary>
        public MTLSize ThreadsPerThreadgroup { get; } = new MTLSize(1, 1, 1);
        /// <summary>
        /// Gets the value of the has stencil
        /// </summary>
        public bool HasStencil { get; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Gets the value of the stencil reference
        /// </summary>
        public uint StencilReference { get; }
        /// <summary>
        /// Gets the value of the blend color
        /// </summary>
        public RgbaFloat BlendColor { get; }
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLPipeline"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        public MTLPipeline(ref GraphicsPipelineDescription description, MTLGraphicsDevice gd)
            : base(ref description)
        {
            PrimitiveType = MTLFormats.VdToMTLPrimitiveTopology(description.PrimitiveTopology);
            ResourceLayouts = new MTLResourceLayout[description.ResourceLayouts.Length];
            NonVertexBufferCount = 0;
            for (int i = 0; i < ResourceLayouts.Length; i++)
            {
                ResourceLayouts[i] = Util.AssertSubtype<ResourceLayout, MTLResourceLayout>(description.ResourceLayouts[i]);
                NonVertexBufferCount += ResourceLayouts[i].BufferCount;
            }
            ResourceBindingModel = description.ResourceBindingModel ?? gd.ResourceBindingModel;

            CullMode = MTLFormats.VdToMTLCullMode(description.RasterizerState.CullMode);
            FrontFace = MTLFormats.VdVoMTLFrontFace(description.RasterizerState.FrontFace);
            FillMode = MTLFormats.VdToMTLFillMode(description.RasterizerState.FillMode);
            ScissorTestEnabled = description.RasterizerState.ScissorTestEnabled;

            MTLRenderPipelineDescriptor mtlDesc = MTLRenderPipelineDescriptor.New();
            foreach (Shader shader in description.ShaderSet.Shaders)
            {
                MTLShader mtlShader = Util.AssertSubtype<Shader, MTLShader>(shader);
                MTLFunction specializedFunction;

                if (mtlShader.HasFunctionConstants)
                {
                    // Need to create specialized MTLFunction.
                    MTLFunctionConstantValues constantValues = CreateConstantValues(description.ShaderSet.Specializations);
                    specializedFunction = mtlShader.Library.newFunctionWithNameConstantValues(mtlShader.EntryPoint, constantValues);
                    AddSpecializedFunction(specializedFunction);
                    ObjectiveCRuntime.release(constantValues.NativePtr);

                    Debug.Assert(specializedFunction.NativePtr != IntPtr.Zero, "Failed to create specialized MTLFunction");
                }
                else
                {
                    specializedFunction = mtlShader.Function;
                }

                if (shader.Stage == ShaderStages.Vertex)
                {
                    mtlDesc.vertexFunction = specializedFunction;
                }
                else if (shader.Stage == ShaderStages.Fragment)
                {
                    mtlDesc.fragmentFunction = specializedFunction;
                }
            }

            // Vertex layouts
            VertexLayoutDescription[] vdVertexLayouts = description.ShaderSet.VertexLayouts;
            MTLVertexDescriptor vertexDescriptor = mtlDesc.vertexDescriptor;

            for (uint i = 0; i < vdVertexLayouts.Length; i++)
            {
                uint layoutIndex = ResourceBindingModel == ResourceBindingModel.Improved
                    ? NonVertexBufferCount + i
                    : i;
                MTLVertexBufferLayoutDescriptor mtlLayout = vertexDescriptor.layouts[layoutIndex];
                mtlLayout.stride = (UIntPtr)vdVertexLayouts[i].Stride;
                uint stepRate = vdVertexLayouts[i].InstanceStepRate;
                mtlLayout.stepFunction = stepRate == 0 ? MTLVertexStepFunction.PerVertex : MTLVertexStepFunction.PerInstance;
                mtlLayout.stepRate = (UIntPtr)Math.Max(1, stepRate);
            }

            uint element = 0;
            for (uint i = 0; i < vdVertexLayouts.Length; i++)
            {
                uint offset = 0;
                VertexLayoutDescription vdDesc = vdVertexLayouts[i];
                for (uint j = 0; j < vdDesc.Elements.Length; j++)
                {
                    VertexElementDescription elementDesc = vdDesc.Elements[j];
                    MTLVertexAttributeDescriptor mtlAttribute = vertexDescriptor.attributes[element];
                    mtlAttribute.bufferIndex = (UIntPtr)(ResourceBindingModel == ResourceBindingModel.Improved
                        ? NonVertexBufferCount + i
                        : i);
                    mtlAttribute.format = MTLFormats.VdToMTLVertexFormat(elementDesc.Format);
                    mtlAttribute.offset = elementDesc.Offset != 0 ? (UIntPtr)elementDesc.Offset : (UIntPtr)offset;
                    offset += FormatSizeHelpers.GetSizeInBytes(elementDesc.Format);
                    element += 1;
                }
            }

            VertexBufferCount = (uint)vdVertexLayouts.Length;

            // Outputs
            OutputDescription outputs = description.Outputs;
            BlendStateDescription blendStateDesc = description.BlendState;
            BlendColor = blendStateDesc.BlendFactor;

            if (outputs.SampleCount != TextureSampleCount.Count1)
            {
                mtlDesc.sampleCount = (UIntPtr)FormatHelpers.GetSampleCountUInt32(outputs.SampleCount);
            }

            if (outputs.DepthAttachment != null)
            {
                PixelFormat depthFormat = outputs.DepthAttachment.Value.Format;
                MTLPixelFormat mtlDepthFormat = MTLFormats.VdToMTLPixelFormat(depthFormat, true);
                mtlDesc.depthAttachmentPixelFormat = mtlDepthFormat;
                if ((FormatHelpers.IsStencilFormat(depthFormat)))
                {
                    HasStencil = true;
                    mtlDesc.stencilAttachmentPixelFormat = mtlDepthFormat;
                }
            }
            for (uint i = 0; i < outputs.ColorAttachments.Length; i++)
            {
                BlendAttachmentDescription attachmentBlendDesc = blendStateDesc.AttachmentStates[i];
                MTLRenderPipelineColorAttachmentDescriptor colorDesc = mtlDesc.colorAttachments[i];
                colorDesc.pixelFormat = MTLFormats.VdToMTLPixelFormat(outputs.ColorAttachments[i].Format, false);
                colorDesc.blendingEnabled = attachmentBlendDesc.BlendEnabled;
                colorDesc.writeMask = MTLFormats.VdToMTLColorWriteMask(attachmentBlendDesc.ColorWriteMask.GetOrDefault());
                colorDesc.alphaBlendOperation = MTLFormats.VdToMTLBlendOp(attachmentBlendDesc.AlphaFunction);
                colorDesc.sourceAlphaBlendFactor = MTLFormats.VdToMTLBlendFactor(attachmentBlendDesc.SourceAlphaFactor);
                colorDesc.destinationAlphaBlendFactor = MTLFormats.VdToMTLBlendFactor(attachmentBlendDesc.DestinationAlphaFactor);

                colorDesc.rgbBlendOperation = MTLFormats.VdToMTLBlendOp(attachmentBlendDesc.ColorFunction);
                colorDesc.sourceRGBBlendFactor = MTLFormats.VdToMTLBlendFactor(attachmentBlendDesc.SourceColorFactor);
                colorDesc.destinationRGBBlendFactor = MTLFormats.VdToMTLBlendFactor(attachmentBlendDesc.DestinationColorFactor);
            }

            mtlDesc.alphaToCoverageEnabled = blendStateDesc.AlphaToCoverageEnabled;

            RenderPipelineState = gd.Device.newRenderPipelineStateWithDescriptor(mtlDesc);
            ObjectiveCRuntime.release(mtlDesc.NativePtr);

            if (outputs.DepthAttachment != null)
            {
                MTLDepthStencilDescriptor depthDescriptor = MTLUtil.AllocInit<MTLDepthStencilDescriptor>(
                    nameof(MTLDepthStencilDescriptor));
                depthDescriptor.depthCompareFunction = MTLFormats.VdToMTLCompareFunction(
                    description.DepthStencilState.DepthComparison);
                depthDescriptor.depthWriteEnabled = description.DepthStencilState.DepthWriteEnabled;

                bool stencilEnabled = description.DepthStencilState.StencilTestEnabled;
                if (stencilEnabled)
                {
                    StencilReference = description.DepthStencilState.StencilReference;

                    StencilBehaviorDescription vdFrontDesc = description.DepthStencilState.StencilFront;
                    MTLStencilDescriptor front = MTLUtil.AllocInit<MTLStencilDescriptor>(nameof(MTLStencilDescriptor));
                    front.readMask = stencilEnabled ? description.DepthStencilState.StencilReadMask : 0u;
                    front.writeMask = stencilEnabled ? description.DepthStencilState.StencilWriteMask : 0u;
                    front.depthFailureOperation = MTLFormats.VdToMTLStencilOperation(vdFrontDesc.DepthFail);
                    front.stencilFailureOperation = MTLFormats.VdToMTLStencilOperation(vdFrontDesc.Fail);
                    front.depthStencilPassOperation = MTLFormats.VdToMTLStencilOperation(vdFrontDesc.Pass);
                    front.stencilCompareFunction = MTLFormats.VdToMTLCompareFunction(vdFrontDesc.Comparison);
                    depthDescriptor.frontFaceStencil = front;

                    StencilBehaviorDescription vdBackDesc = description.DepthStencilState.StencilBack;
                    MTLStencilDescriptor back = MTLUtil.AllocInit<MTLStencilDescriptor>(nameof(MTLStencilDescriptor));
                    back.readMask = stencilEnabled ? description.DepthStencilState.StencilReadMask : 0u;
                    back.writeMask = stencilEnabled ? description.DepthStencilState.StencilWriteMask : 0u;
                    back.depthFailureOperation = MTLFormats.VdToMTLStencilOperation(vdBackDesc.DepthFail);
                    back.stencilFailureOperation = MTLFormats.VdToMTLStencilOperation(vdBackDesc.Fail);
                    back.depthStencilPassOperation = MTLFormats.VdToMTLStencilOperation(vdBackDesc.Pass);
                    back.stencilCompareFunction = MTLFormats.VdToMTLCompareFunction(vdBackDesc.Comparison);
                    depthDescriptor.backFaceStencil = back;

                    ObjectiveCRuntime.release(front.NativePtr);
                    ObjectiveCRuntime.release(back.NativePtr);
                }

                DepthStencilState = gd.Device.newDepthStencilStateWithDescriptor(depthDescriptor);
                ObjectiveCRuntime.release(depthDescriptor.NativePtr);
            }

            DepthClipMode = description.DepthStencilState.DepthTestEnabled ? MTLDepthClipMode.Clip : MTLDepthClipMode.Clamp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLPipeline"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        public MTLPipeline(ref ComputePipelineDescription description, MTLGraphicsDevice gd)
            : base(ref description)
        {
            IsComputePipeline = true;
            ResourceLayouts = new MTLResourceLayout[description.ResourceLayouts.Length];
            for (int i = 0; i < ResourceLayouts.Length; i++)
            {
                ResourceLayouts[i] = Util.AssertSubtype<ResourceLayout, MTLResourceLayout>(description.ResourceLayouts[i]);
            }

            ThreadsPerThreadgroup = new MTLSize(
                description.ThreadGroupSizeX,
                description.ThreadGroupSizeY,
                description.ThreadGroupSizeZ);

            MTLComputePipelineDescriptor mtlDesc = MTLUtil.AllocInit<MTLComputePipelineDescriptor>(
                nameof(MTLComputePipelineDescriptor));
            MTLShader mtlShader = Util.AssertSubtype<Shader, MTLShader>(description.ComputeShader);
            MTLFunction specializedFunction;
            if (mtlShader.HasFunctionConstants)
            {
                // Need to create specialized MTLFunction.
                MTLFunctionConstantValues constantValues = CreateConstantValues(description.Specializations);
                specializedFunction = mtlShader.Library.newFunctionWithNameConstantValues(mtlShader.EntryPoint, constantValues);
                AddSpecializedFunction(specializedFunction);
                ObjectiveCRuntime.release(constantValues.NativePtr);

                Debug.Assert(specializedFunction.NativePtr != IntPtr.Zero, "Failed to create specialized MTLFunction");
            }
            else
            {
                specializedFunction = mtlShader.Function;
            }

            mtlDesc.computeFunction = specializedFunction;
            MTLPipelineBufferDescriptorArray buffers = mtlDesc.buffers;
            uint bufferIndex = 0;
            foreach (MTLResourceLayout layout in ResourceLayouts)
            {
                foreach (ResourceLayoutElementDescription rle in layout.Description.Elements)
                {
                    ResourceKind kind = rle.Kind;
                    if (kind == ResourceKind.UniformBuffer
                        || kind == ResourceKind.StructuredBufferReadOnly)
                    {
                        MTLPipelineBufferDescriptor bufferDesc = buffers[bufferIndex];
                        bufferDesc.mutability = MTLMutability.Immutable;
                        bufferIndex += 1;
                    }
                    else if (kind == ResourceKind.StructuredBufferReadWrite)
                    {
                        MTLPipelineBufferDescriptor bufferDesc = buffers[bufferIndex];
                        bufferDesc.mutability = MTLMutability.Mutable;
                        bufferIndex += 1;
                    }
                }
            }

            ComputePipelineState = gd.Device.newComputePipelineStateWithDescriptor(mtlDesc);

            ObjectiveCRuntime.release(mtlDesc.NativePtr);
        }

        /// <summary>
        /// Creates the constant values using the specified specializations
        /// </summary>
        /// <param name="specializations">The specializations</param>
        /// <returns>The ret</returns>
        private unsafe MTLFunctionConstantValues CreateConstantValues(SpecializationConstant[] specializations)
        {
            MTLFunctionConstantValues ret = MTLFunctionConstantValues.New();
            if (specializations != null)
            {
                foreach (SpecializationConstant sc in specializations)
                {
                    MTLDataType mtlType = MTLFormats.VdVoMTLShaderConstantType(sc.Type);
                    ret.setConstantValuetypeatIndex(&sc.Data, mtlType, (UIntPtr)sc.ID);
                }
            }

            return ret;
        }

        /// <summary>
        /// Adds the specialized function using the specified function
        /// </summary>
        /// <param name="function">The function</param>
        private void AddSpecializedFunction(MTLFunction function)
        {
            if (_specializedFunctions == null) { _specializedFunctions = new List<MTLFunction>(); }
            _specializedFunctions.Add(function);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                if (RenderPipelineState.NativePtr != IntPtr.Zero)
                {
                    ObjectiveCRuntime.release(RenderPipelineState.NativePtr);
                }
                else
                {
                    Debug.Assert(ComputePipelineState.NativePtr != IntPtr.Zero);
                    ObjectiveCRuntime.release(ComputePipelineState.NativePtr);
                }

                if (_specializedFunctions != null)
                {
                    foreach (MTLFunction function in _specializedFunctions)
                    {
                        ObjectiveCRuntime.release(function.NativePtr);
                    }
                    _specializedFunctions.Clear();
                }

                _disposed = true;
            }
        }
    }
}
