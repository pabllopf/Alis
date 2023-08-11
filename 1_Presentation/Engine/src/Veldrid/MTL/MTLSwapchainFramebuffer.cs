using System;
using System.Collections.Generic;
using System.Diagnostics;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl swapchain framebuffer class
    /// </summary>
    /// <seealso cref="MTLFramebufferBase"/>
    internal class MTLSwapchainFramebuffer : MTLFramebufferBase
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly MTLGraphicsDevice _gd;
        /// <summary>
        /// The placeholder texture
        /// </summary>
        private readonly MTLPlaceholderTexture _placeholderTexture;
        /// <summary>
        /// The depth texture
        /// </summary>
        private MTLTexture _depthTexture;
        /// <summary>
        /// The parent swapchain
        /// </summary>
        private readonly MTLSwapchain _parentSwapchain;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public override uint Width => _placeholderTexture.Width;
        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public override uint Height => _placeholderTexture.Height;

        /// <summary>
        /// Gets the value of the output description
        /// </summary>
        public override OutputDescription OutputDescription { get; }

        /// <summary>
        /// The color targets
        /// </summary>
        private readonly FramebufferAttachment[] _colorTargets;
        /// <summary>
        /// The depth target
        /// </summary>
        private readonly FramebufferAttachment? _depthTarget;
        /// <summary>
        /// The depth format
        /// </summary>
        private readonly PixelFormat? _depthFormat;

        /// <summary>
        /// Gets the value of the color targets
        /// </summary>
        public override IReadOnlyList<FramebufferAttachment> ColorTargets => _colorTargets;
        /// <summary>
        /// Gets the value of the depth target
        /// </summary>
        public override FramebufferAttachment? DepthTarget => _depthTarget;

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLSwapchainFramebuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="parent">The parent</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depthFormat">The depth format</param>
        /// <param name="colorFormat">The color format</param>
        public MTLSwapchainFramebuffer(
            MTLGraphicsDevice gd,
            MTLSwapchain parent,
            uint width,
            uint height,
            PixelFormat? depthFormat,
            PixelFormat colorFormat)
            : base()
        {
            _gd = gd;
            _parentSwapchain = parent;

            OutputAttachmentDescription? depthAttachment = null;
            if (depthFormat != null)
            {
                _depthFormat = depthFormat;
                depthAttachment = new OutputAttachmentDescription(depthFormat.Value);
                RecreateDepthTexture(width, height);
                _depthTarget = new FramebufferAttachment(_depthTexture, 0);
            }
            OutputAttachmentDescription colorAttachment = new OutputAttachmentDescription(colorFormat);

            OutputDescription = new OutputDescription(depthAttachment, colorAttachment);
            _placeholderTexture = new MTLPlaceholderTexture(colorFormat);
            _placeholderTexture.Resize(width, height);
            _colorTargets = new[] { new FramebufferAttachment(_placeholderTexture, 0) };
        }

        /// <summary>
        /// Recreates the depth texture using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void RecreateDepthTexture(uint width, uint height)
        {
            Debug.Assert(_depthFormat.HasValue);
            if (_depthTexture != null)
            {
                _depthTexture.Dispose();
            }

            _depthTexture = Util.AssertSubtype<Texture, MTLTexture>(
                _gd.ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                    width, height, 1, 1, _depthFormat.Value, TextureUsage.DepthStencil)));
        }

        /// <summary>
        /// Resizes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void Resize(uint width, uint height)
        {
            _placeholderTexture.Resize(width, height);

            if (_depthFormat.HasValue)
            {
                RecreateDepthTexture(width, height);
            }
        }

        /// <summary>
        /// Gets the value of the is renderable
        /// </summary>
        public override bool IsRenderable => !_parentSwapchain.CurrentDrawable.IsNull;

        /// <summary>
        /// Creates the render pass descriptor
        /// </summary>
        /// <returns>The ret</returns>
        public override MTLRenderPassDescriptor CreateRenderPassDescriptor()
        {
            MTLRenderPassDescriptor ret = MTLRenderPassDescriptor.New();
            var color0 = ret.colorAttachments[0];
            color0.texture = _parentSwapchain.CurrentDrawable.texture;
            color0.loadAction = MTLLoadAction.Load;

            if (_depthTarget != null)
            {
                var depthAttachment = ret.depthAttachment;
                depthAttachment.texture = _depthTexture.DeviceTexture;
                depthAttachment.loadAction = MTLLoadAction.Load;
            }

            return ret;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            _depthTexture?.Dispose();
            _disposed = true;
        }
    }
}
