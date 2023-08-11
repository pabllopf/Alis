using System;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl framebuffer class
    /// </summary>
    /// <seealso cref="MTLFramebufferBase"/>
    internal class MTLFramebuffer : MTLFramebufferBase
    {
        /// <summary>
        /// Gets the value of the is renderable
        /// </summary>
        public override bool IsRenderable => true;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLFramebuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public MTLFramebuffer(MTLGraphicsDevice gd, ref FramebufferDescription description)
            : base(gd, ref description)
        {
        }

        /// <summary>
        /// Creates the render pass descriptor
        /// </summary>
        /// <returns>The ret</returns>
        public override MTLRenderPassDescriptor CreateRenderPassDescriptor()
        {
            MTLRenderPassDescriptor ret = MTLRenderPassDescriptor.New();
            for (int i = 0; i < ColorTargets.Count; i++)
            {
                FramebufferAttachment colorTarget = ColorTargets[i];
                MTLTexture mtlTarget = Util.AssertSubtype<Texture, MTLTexture>(colorTarget.Target);
                MTLRenderPassColorAttachmentDescriptor colorDescriptor = ret.colorAttachments[(uint)i];
                colorDescriptor.texture = mtlTarget.DeviceTexture;
                colorDescriptor.loadAction = MTLLoadAction.Load;
                colorDescriptor.slice = (UIntPtr)colorTarget.ArrayLayer;
                colorDescriptor.level = (UIntPtr)colorTarget.MipLevel;
            }

            if (DepthTarget != null)
            {
                MTLTexture mtlDepthTarget = Util.AssertSubtype<Texture, MTLTexture>(DepthTarget.Value.Target);
                MTLRenderPassDepthAttachmentDescriptor depthDescriptor = ret.depthAttachment;
                depthDescriptor.loadAction = MTLLoadAction.Load;
                depthDescriptor.storeAction = MTLStoreAction.Store;
                depthDescriptor.texture = mtlDepthTarget.DeviceTexture;
                depthDescriptor.slice = (UIntPtr)DepthTarget.Value.ArrayLayer;
                depthDescriptor.level = (UIntPtr)DepthTarget.Value.MipLevel;

                if (FormatHelpers.IsStencilFormat(mtlDepthTarget.Format))
                {
                    MTLRenderPassStencilAttachmentDescriptor stencilDescriptor = ret.stencilAttachment;
                    stencilDescriptor.loadAction = MTLLoadAction.Load;
                    stencilDescriptor.storeAction = MTLStoreAction.Store;
                    stencilDescriptor.texture = mtlDepthTarget.DeviceTexture;
                    stencilDescriptor.slice = (UIntPtr)DepthTarget.Value.ArrayLayer;
                }
            }

            return ret;
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
