using System;

namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl resource factory class
    /// </summary>
    /// <seealso cref="ResourceFactory"/>
    internal class OpenGLResourceFactory : ResourceFactory
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The pool
        /// </summary>
        private readonly StagingMemoryPool _pool;

        /// <summary>
        /// Gets the value of the backend type
        /// </summary>
        public override GraphicsBackend BackendType => _gd.BackendType;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLResourceFactory"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        public unsafe OpenGLResourceFactory(OpenGLGraphicsDevice gd)
            : base(gd.Features)
        {
            _gd = gd;
            _pool = gd.StagingMemoryPool;
        }

        /// <summary>
        /// Creates the command list using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The command list</returns>
        public override CommandList CreateCommandList(ref CommandListDescription description)
        {
            return new OpenGLCommandList(_gd, ref description);
        }

        /// <summary>
        /// Creates the framebuffer using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The framebuffer</returns>
        public override Framebuffer CreateFramebuffer(ref FramebufferDescription description)
        {
            return new OpenGLFramebuffer(_gd, ref description);
        }

        /// <summary>
        /// Creates the graphics pipeline core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        protected override Pipeline CreateGraphicsPipelineCore(ref GraphicsPipelineDescription description)
        {
            return new OpenGLPipeline(_gd, ref description);
        }

        /// <summary>
        /// Creates the compute pipeline using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        public override Pipeline CreateComputePipeline(ref ComputePipelineDescription description)
        {
            OpenGLPipeline pipeline = new OpenGLPipeline(_gd, ref description);
            _gd.EnsureResourceInitialized(pipeline);
            return pipeline;
        }

        /// <summary>
        /// Creates the resource layout using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource layout</returns>
        public override ResourceLayout CreateResourceLayout(ref ResourceLayoutDescription description)
        {
            return new OpenGLResourceLayout(ref description);
        }

        /// <summary>
        /// Creates the resource set using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource set</returns>
        public override ResourceSet CreateResourceSet(ref ResourceSetDescription description)
        {
            ValidationHelpers.ValidateResourceSet(_gd, ref description);
            return new OpenGLResourceSet(ref description);
        }

        /// <summary>
        /// Creates the sampler core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The sampler</returns>
        protected override Sampler CreateSamplerCore(ref SamplerDescription description)
        {
            return new OpenGLSampler(_gd, ref description);
        }

        /// <summary>
        /// Creates the shader core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The shader</returns>
        protected override Shader CreateShaderCore(ref ShaderDescription description)
        {
            StagingBlock stagingBlock = _pool.Stage(description.ShaderBytes);
            OpenGLShader shader = new OpenGLShader(_gd, description.Stage, stagingBlock, description.EntryPoint);
            _gd.EnsureResourceInitialized(shader);
            return shader;
        }

        /// <summary>
        /// Creates the texture core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ref TextureDescription description)
        {
            return new OpenGLTexture(_gd, ref description);
        }

        /// <summary>
        /// Creates the texture core using the specified native texture
        /// </summary>
        /// <param name="nativeTexture">The native texture</param>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ulong nativeTexture, ref TextureDescription description)
        {
            return new OpenGLTexture(_gd, (uint)nativeTexture, ref description);
        }

        /// <summary>
        /// Creates the texture view core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture view</returns>
        protected override TextureView CreateTextureViewCore(ref TextureViewDescription description)
        {
            return new OpenGLTextureView(_gd, ref description);
        }

        /// <summary>
        /// Creates the buffer core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The device buffer</returns>
        protected override DeviceBuffer CreateBufferCore(ref BufferDescription description)
        {
            return new OpenGLBuffer(
                _gd,
                description.SizeInBytes,
                description.Usage);
        }

        /// <summary>
        /// Creates the fence using the specified signaled
        /// </summary>
        /// <param name="signaled">The signaled</param>
        /// <returns>The fence</returns>
        public override Fence CreateFence(bool signaled)
        {
            return new OpenGLFence(signaled);
        }

        /// <summary>
        /// Creates the swapchain using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <exception cref="NotSupportedException">OpenGL does not support creating Swapchain objects.</exception>
        /// <returns>The swapchain</returns>
        public override Swapchain CreateSwapchain(ref SwapchainDescription description)
        {
            throw new NotSupportedException("OpenGL does not support creating Swapchain objects.");
        }
    }
}
