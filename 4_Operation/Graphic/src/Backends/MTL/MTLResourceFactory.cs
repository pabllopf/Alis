namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl resource factory class
    /// </summary>
    /// <seealso cref="ResourceFactory"/>
    internal class MTLResourceFactory : ResourceFactory
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly MTLGraphicsDevice _gd;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLResourceFactory"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        public MTLResourceFactory(MTLGraphicsDevice gd)
            : base(gd.Features)
        {
            _gd = gd;
        }

        /// <summary>
        /// Gets the value of the backend type
        /// </summary>
        public override GraphicsBackend BackendType => GraphicsBackend.Metal;

        /// <summary>
        /// Creates the command list using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The command list</returns>
        public override CommandList CreateCommandList(ref CommandListDescription description)
        {
            return new MTLCommandList(ref description, _gd);
        }

        /// <summary>
        /// Creates the compute pipeline using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        public override Pipeline CreateComputePipeline(ref ComputePipelineDescription description)
        {
            return new MTLPipeline(ref description, _gd);
        }

        /// <summary>
        /// Creates the framebuffer using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The framebuffer</returns>
        public override Framebuffer CreateFramebuffer(ref FramebufferDescription description)
        {
            return new MTLFramebuffer(_gd, ref description);
        }

        /// <summary>
        /// Creates the graphics pipeline core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        protected override Pipeline CreateGraphicsPipelineCore(ref GraphicsPipelineDescription description)
        {
            return new MTLPipeline(ref description, _gd);
        }

        /// <summary>
        /// Creates the resource layout using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource layout</returns>
        public override ResourceLayout CreateResourceLayout(ref ResourceLayoutDescription description)
        {
            return new MTLResourceLayout(ref description, _gd);
        }

        /// <summary>
        /// Creates the resource set using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource set</returns>
        public override ResourceSet CreateResourceSet(ref ResourceSetDescription description)
        {
            ValidationHelpers.ValidateResourceSet(_gd, ref description);
            return new MTLResourceSet(ref description, _gd);
        }

        /// <summary>
        /// Creates the sampler core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The sampler</returns>
        protected override Sampler CreateSamplerCore(ref SamplerDescription description)
        {
            return new MTLSampler(ref description, _gd);
        }

        /// <summary>
        /// Creates the shader core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The shader</returns>
        protected override Shader CreateShaderCore(ref ShaderDescription description)
        {
            return new MTLShader(ref description, _gd);
        }

        /// <summary>
        /// Creates the buffer core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The device buffer</returns>
        protected override DeviceBuffer CreateBufferCore(ref BufferDescription description)
        {
            return new MTLBuffer(ref description, _gd);
        }

        /// <summary>
        /// Creates the texture core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ref TextureDescription description)
        {
            return new MTLTexture(ref description, _gd);
        }

        /// <summary>
        /// Creates the texture core using the specified native texture
        /// </summary>
        /// <param name="nativeTexture">The native texture</param>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ulong nativeTexture, ref TextureDescription description)
        {
            return new MTLTexture(nativeTexture, ref description);
        }

        /// <summary>
        /// Creates the texture view core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture view</returns>
        protected override TextureView CreateTextureViewCore(ref TextureViewDescription description)
        {
            return new MTLTextureView(ref description, _gd);
        }

        /// <summary>
        /// Creates the fence using the specified signaled
        /// </summary>
        /// <param name="signaled">The signaled</param>
        /// <returns>The fence</returns>
        public override Fence CreateFence(bool signaled)
        {
            return new MTLFence(signaled);
        }

        /// <summary>
        /// Creates the swapchain using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The swapchain</returns>
        public override Swapchain CreateSwapchain(ref SwapchainDescription description)
        {
            return new MTLSwapchain(_gd, ref description);
        }
    }
}
