using System.Collections.Generic;
using Vulkan;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vk framebuffer base class
    /// </summary>
    /// <seealso cref="Framebuffer"/>
    internal abstract class VkFramebufferBase : Framebuffer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VkFramebufferBase"/> class
        /// </summary>
        /// <param name="depthTexture">The depth texture</param>
        /// <param name="colorTextures">The color textures</param>
        public VkFramebufferBase(
            FramebufferAttachmentDescription? depthTexture,
            IReadOnlyList<FramebufferAttachmentDescription> colorTextures)
            : base(depthTexture, colorTextures)
        {
            RefCount = new ResourceRefCount(DisposeCore);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkFramebufferBase"/> class
        /// </summary>
        public VkFramebufferBase()
        {
            RefCount = new ResourceRefCount(DisposeCore);
        }

        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }

        /// <summary>
        /// Gets the value of the renderable width
        /// </summary>
        public abstract uint RenderableWidth { get; }
        /// <summary>
        /// Gets the value of the renderable height
        /// </summary>
        public abstract uint RenderableHeight { get; }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            RefCount.Decrement();
        }

        /// <summary>
        /// Disposes the core
        /// </summary>
        protected abstract void DisposeCore();

        /// <summary>
        /// Gets the value of the current framebuffer
        /// </summary>
        public abstract Vulkan.VkFramebuffer CurrentFramebuffer { get; }
        /// <summary>
        /// Gets the value of the renderpassnoclear init
        /// </summary>
        public abstract VkRenderPass RenderPassNoClear_Init { get; }
        /// <summary>
        /// Gets the value of the renderpassnoclear load
        /// </summary>
        public abstract VkRenderPass RenderPassNoClear_Load { get; }
        /// <summary>
        /// Gets the value of the render pass clear
        /// </summary>
        public abstract VkRenderPass RenderPassClear { get; }
        /// <summary>
        /// Gets the value of the attachment count
        /// </summary>
        public abstract uint AttachmentCount { get; }
        /// <summary>
        /// Transitions the to intermediate layout using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        public abstract void TransitionToIntermediateLayout(VkCommandBuffer cb);
        /// <summary>
        /// Transitions the to final layout using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        public abstract void TransitionToFinalLayout(VkCommandBuffer cb);
    }
}
