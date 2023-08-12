using System;

namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl swapchain class
    /// </summary>
    /// <seealso cref="Swapchain"/>
    internal class OpenGLSwapchain : Swapchain
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The framebuffer
        /// </summary>
        private readonly OpenGLSwapchainFramebuffer _framebuffer;
        /// <summary>
        /// The resize action
        /// </summary>
        private readonly Action<uint, uint> _resizeAction;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the framebuffer
        /// </summary>
        public override Framebuffer Framebuffer => _framebuffer;
        /// <summary>
        /// Gets or sets the value of the sync to vertical blank
        /// </summary>
        public override bool SyncToVerticalBlank { get => _gd.SyncToVerticalBlank; set => _gd.SyncToVerticalBlank = value; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; } = "OpenGL Context Swapchain";
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLSwapchain"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="framebuffer">The framebuffer</param>
        /// <param name="resizeAction">The resize action</param>
        public OpenGLSwapchain(
            OpenGLGraphicsDevice gd,
            OpenGLSwapchainFramebuffer framebuffer,
            Action<uint, uint> resizeAction)
        {
            _gd = gd;
            _framebuffer = framebuffer;
            _resizeAction = resizeAction;
        }

        /// <summary>
        /// Resizes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public override void Resize(uint width, uint height)
        {
            _framebuffer.Resize(width, height);
            _resizeAction?.Invoke(width, height);
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
