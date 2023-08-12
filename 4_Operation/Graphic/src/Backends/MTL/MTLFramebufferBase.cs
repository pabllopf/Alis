using Alis.Core.Graphic.Backends.Metal;

namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl framebuffer base class
    /// </summary>
    /// <seealso cref="Framebuffer"/>
    internal abstract class MTLFramebufferBase : Framebuffer
    {
        /// <summary>
        /// Creates the render pass descriptor
        /// </summary>
        /// <returns>The mtl render pass descriptor</returns>
        public abstract MTLRenderPassDescriptor CreateRenderPassDescriptor();
        /// <summary>
        /// Gets the value of the is renderable
        /// </summary>
        public abstract bool IsRenderable { get; }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLFramebufferBase"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public MTLFramebufferBase(MTLGraphicsDevice gd, ref FramebufferDescription description)
            : base(description.DepthTarget, description.ColorTargets)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLFramebufferBase"/> class
        /// </summary>
        public MTLFramebufferBase()
        {
        }
    }
}