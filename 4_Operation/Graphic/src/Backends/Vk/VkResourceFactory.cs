using Vulkan;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk resource factory class
    /// </summary>
    /// <seealso cref="ResourceFactory"/>
    internal class VkResourceFactory : ResourceFactory
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The device
        /// </summary>
        private readonly VkDevice _device;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkResourceFactory"/> class
        /// </summary>
        /// <param name="vkGraphicsDevice">The vk graphics device</param>
        public VkResourceFactory(VkGraphicsDevice vkGraphicsDevice)
            : base (vkGraphicsDevice.Features)
        {
            _gd = vkGraphicsDevice;
            _device = vkGraphicsDevice.Device;
        }

        /// <summary>
        /// Gets the value of the backend type
        /// </summary>
        public override GraphicsBackend BackendType => GraphicsBackend.Vulkan;

        /// <summary>
        /// Creates the command list using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The command list</returns>
        public override CommandList CreateCommandList(ref CommandListDescription description)
        {
            return new VkCommandList(_gd, ref description);
        }

        /// <summary>
        /// Creates the framebuffer using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The framebuffer</returns>
        public override Framebuffer CreateFramebuffer(ref FramebufferDescription description)
        {
            return new VkFramebuffer(_gd, ref description, false);
        }

        /// <summary>
        /// Creates the graphics pipeline core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        protected override Pipeline CreateGraphicsPipelineCore(ref GraphicsPipelineDescription description)
        {
            return new VkPipeline(_gd, ref description);
        }

        /// <summary>
        /// Creates the compute pipeline using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        public override Pipeline CreateComputePipeline(ref ComputePipelineDescription description)
        {
            return new VkPipeline(_gd, ref description);
        }

        /// <summary>
        /// Creates the resource layout using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource layout</returns>
        public override ResourceLayout CreateResourceLayout(ref ResourceLayoutDescription description)
        {
            return new VkResourceLayout(_gd, ref description);
        }

        /// <summary>
        /// Creates the resource set using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource set</returns>
        public override ResourceSet CreateResourceSet(ref ResourceSetDescription description)
        {
            ValidationHelpers.ValidateResourceSet(_gd, ref description);
            return new VkResourceSet(_gd, ref description);
        }

        /// <summary>
        /// Creates the sampler core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The sampler</returns>
        protected override Sampler CreateSamplerCore(ref SamplerDescription description)
        {
            return new VkSampler(_gd, ref description);
        }

        /// <summary>
        /// Creates the shader core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The shader</returns>
        protected override Shader CreateShaderCore(ref ShaderDescription description)
        {
            return new VkShader(_gd, ref description);
        }

        /// <summary>
        /// Creates the texture core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ref TextureDescription description)
        {
            return new VkTexture(_gd, ref description);
        }

        /// <summary>
        /// Creates the texture core using the specified native texture
        /// </summary>
        /// <param name="nativeTexture">The native texture</param>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ulong nativeTexture, ref TextureDescription description)
        {
            return new VkTexture(
                _gd,
                description.Width, description.Height,
                description.MipLevels, description.ArrayLayers,
                VkFormats.VdToVkPixelFormat(description.Format, (description.Usage & TextureUsage.DepthStencil) != 0),
                description.Usage,
                description.SampleCount,
                nativeTexture);
        }

        /// <summary>
        /// Creates the texture view core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture view</returns>
        protected override TextureView CreateTextureViewCore(ref TextureViewDescription description)
        {
            return new VkTextureView(_gd, ref description);
        }

        /// <summary>
        /// Creates the buffer core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The device buffer</returns>
        protected override DeviceBuffer CreateBufferCore(ref BufferDescription description)
        {
            return new VkBuffer(_gd, description.SizeInBytes, description.Usage);
        }

        /// <summary>
        /// Creates the fence using the specified signaled
        /// </summary>
        /// <param name="signaled">The signaled</param>
        /// <returns>The fence</returns>
        public override Fence CreateFence(bool signaled)
        {
            return new VkFence(_gd, signaled);
        }

        /// <summary>
        /// Creates the swapchain using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The swapchain</returns>
        public override Swapchain CreateSwapchain(ref SwapchainDescription description)
        {
            return new VkSwapchain(_gd, ref description);
        }
    }
}
