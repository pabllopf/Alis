using System;
using System.Collections.Generic;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl swapchain framebuffer class
    /// </summary>
    /// <seealso cref="Framebuffer"/>
    internal class OpenGLSwapchainFramebuffer : Framebuffer
    {
        /// <summary>
        /// The depth format
        /// </summary>
        private readonly PixelFormat? _depthFormat;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public override uint Width => _colorTexture.Width;
        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public override uint Height => _colorTexture.Height;

        /// <summary>
        /// Gets the value of the output description
        /// </summary>
        public override OutputDescription OutputDescription { get; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// The color texture
        /// </summary>
        private readonly OpenGLPlaceholderTexture _colorTexture;
        /// <summary>
        /// The depth texture
        /// </summary>
        private readonly OpenGLPlaceholderTexture _depthTexture;

        /// <summary>
        /// The color targets
        /// </summary>
        private readonly FramebufferAttachment[] _colorTargets;
        /// <summary>
        /// The depth target
        /// </summary>
        private readonly FramebufferAttachment? _depthTarget;

        /// <summary>
        /// Gets the value of the color targets
        /// </summary>
        public override IReadOnlyList<FramebufferAttachment> ColorTargets => _colorTargets;
        /// <summary>
        /// Gets the value of the depth target
        /// </summary>
        public override FramebufferAttachment? DepthTarget => _depthTarget;

        /// <summary>
        /// Gets the value of the disable srgb conversion
        /// </summary>
        public bool DisableSrgbConversion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLSwapchainFramebuffer"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="colorFormat">The color format</param>
        /// <param name="depthFormat">The depth format</param>
        /// <param name="disableSrgbConversion">The disable srgb conversion</param>
        internal OpenGLSwapchainFramebuffer(
            uint width, uint height,
            PixelFormat colorFormat,
            PixelFormat? depthFormat,
            bool disableSrgbConversion)
        {
            _depthFormat = depthFormat;
            // This is wrong, but it's not really used.
            OutputAttachmentDescription? depthDesc = _depthFormat != null
                ? new OutputAttachmentDescription(_depthFormat.Value)
                : (OutputAttachmentDescription?)null;
            OutputDescription = new OutputDescription(
                depthDesc,
                new OutputAttachmentDescription(colorFormat));

            _colorTexture = new OpenGLPlaceholderTexture(
                width,
                height,
                colorFormat,
                TextureUsage.RenderTarget,
                TextureSampleCount.Count1);
            _colorTargets = new[] { new FramebufferAttachment(_colorTexture, 0) };

            if (_depthFormat != null)
            {
                _depthTexture = new OpenGLPlaceholderTexture(
                    width,
                    height,
                    depthFormat.Value,
                    TextureUsage.DepthStencil,
                    TextureSampleCount.Count1);
                _depthTarget = new FramebufferAttachment(_depthTexture, 0);
            }

            OutputDescription = OutputDescription.CreateFromFramebuffer(this);

            DisableSrgbConversion = disableSrgbConversion;
        }

        /// <summary>
        /// Resizes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void Resize(uint width, uint height)
        {
            _colorTexture.Resize(width, height);
            _depthTexture?.Resize(width, height);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            _disposed = true;
        }
    }
}
