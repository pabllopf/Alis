using Vortice.Direct3D11;
using System;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 resource factory class
    /// </summary>
    /// <seealso cref="ResourceFactory"/>
    /// <seealso cref="IDisposable"/>
    internal class D3D11ResourceFactory : ResourceFactory, IDisposable
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly D3D11GraphicsDevice _gd;
        /// <summary>
        /// The device
        /// </summary>
        private readonly ID3D11Device _device;
        /// <summary>
        /// The cache
        /// </summary>
        private readonly D3D11ResourceCache _cache;

        /// <summary>
        /// Gets the value of the backend type
        /// </summary>
        public override GraphicsBackend BackendType => GraphicsBackend.Direct3D11;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ResourceFactory"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        public D3D11ResourceFactory(D3D11GraphicsDevice gd)
            : base(gd.Features)
        {
            _gd = gd;
            _device = gd.Device;
            _cache = new D3D11ResourceCache(_device);
        }

        /// <summary>
        /// Creates the command list using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The command list</returns>
        public override CommandList CreateCommandList(ref CommandListDescription description)
        {
            return new D3D11CommandList(_gd, ref description);
        }

        /// <summary>
        /// Creates the framebuffer using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The framebuffer</returns>
        public override Framebuffer CreateFramebuffer(ref FramebufferDescription description)
        {
            return new D3D11Framebuffer(_device, ref description);
        }

        /// <summary>
        /// Creates the graphics pipeline core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        protected override Pipeline CreateGraphicsPipelineCore(ref GraphicsPipelineDescription description)
        {
            return new D3D11Pipeline(_cache, ref description);
        }

        /// <summary>
        /// Creates the compute pipeline using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The pipeline</returns>
        public override Pipeline CreateComputePipeline(ref ComputePipelineDescription description)
        {
            return new D3D11Pipeline(_cache, ref description);
        }

        /// <summary>
        /// Creates the resource layout using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource layout</returns>
        public override ResourceLayout CreateResourceLayout(ref ResourceLayoutDescription description)
        {
            return new D3D11ResourceLayout(ref description);
        }

        /// <summary>
        /// Creates the resource set using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The resource set</returns>
        public override ResourceSet CreateResourceSet(ref ResourceSetDescription description)
        {
            ValidationHelpers.ValidateResourceSet(_gd, ref description);
            return new D3D11ResourceSet(ref description);
        }

        /// <summary>
        /// Creates the sampler core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The sampler</returns>
        protected override Sampler CreateSamplerCore(ref SamplerDescription description)
        {
            return new D3D11Sampler(_device, ref description);
        }

        /// <summary>
        /// Creates the shader core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The shader</returns>
        protected override Shader CreateShaderCore(ref ShaderDescription description)
        {
            return new D3D11Shader(_device, description);
        }

        /// <summary>
        /// Creates the texture core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ref TextureDescription description)
        {
            return new D3D11Texture(_device, ref description);
        }

        /// <summary>
        /// Creates the texture core using the specified native texture
        /// </summary>
        /// <param name="nativeTexture">The native texture</param>
        /// <param name="description">The description</param>
        /// <returns>The texture</returns>
        protected override Texture CreateTextureCore(ulong nativeTexture, ref TextureDescription description)
        {
            ID3D11Texture2D existingTexture = new ID3D11Texture2D((IntPtr)nativeTexture);
            return new D3D11Texture(existingTexture, description.Type, description.Format);
        }

        /// <summary>
        /// Creates the texture view core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The texture view</returns>
        protected override TextureView CreateTextureViewCore(ref TextureViewDescription description)
        {
            return new D3D11TextureView(_gd, ref description);
        }

        /// <summary>
        /// Creates the buffer core using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The device buffer</returns>
        protected override DeviceBuffer CreateBufferCore(ref BufferDescription description)
        {
            return new D3D11Buffer(
                _device,
                description.SizeInBytes,
                description.Usage,
                description.StructureByteStride,
                description.RawBuffer);
        }

        /// <summary>
        /// Creates the fence using the specified signaled
        /// </summary>
        /// <param name="signaled">The signaled</param>
        /// <returns>The fence</returns>
        public override Fence CreateFence(bool signaled)
        {
            return new D3D11Fence(signaled);
        }

        /// <summary>
        /// Creates the swapchain using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The swapchain</returns>
        public override Swapchain CreateSwapchain(ref SwapchainDescription description)
        {
            return new D3D11Swapchain(_gd, ref description);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _cache.Dispose();
        }
    }
}
