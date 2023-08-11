using System.Collections.Generic;
using Vulkan;
using static Vulkan.VulkanNative;
using static Veldrid.Vk.VulkanUtil;
using System;
using System.Diagnostics;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vk framebuffer class
    /// </summary>
    /// <seealso cref="VkFramebufferBase"/>
    internal unsafe class VkFramebuffer : VkFramebufferBase
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The device framebuffer
        /// </summary>
        private readonly Vulkan.VkFramebuffer _deviceFramebuffer;
        /// <summary>
        /// The render pass no clear load
        /// </summary>
        private readonly VkRenderPass _renderPassNoClearLoad;
        /// <summary>
        /// The render pass no clear
        /// </summary>
        private readonly VkRenderPass _renderPassNoClear;
        /// <summary>
        /// The render pass clear
        /// </summary>
        private readonly VkRenderPass _renderPassClear;
        /// <summary>
        /// The vk image view
        /// </summary>
        private readonly List<VkImageView> _attachmentViews = new List<VkImageView>();
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the current framebuffer
        /// </summary>
        public override Vulkan.VkFramebuffer CurrentFramebuffer => _deviceFramebuffer;
        /// <summary>
        /// Gets the value of the renderpassnoclear init
        /// </summary>
        public override VkRenderPass RenderPassNoClear_Init => _renderPassNoClear;
        /// <summary>
        /// Gets the value of the renderpassnoclear load
        /// </summary>
        public override VkRenderPass RenderPassNoClear_Load => _renderPassNoClearLoad;
        /// <summary>
        /// Gets the value of the render pass clear
        /// </summary>
        public override VkRenderPass RenderPassClear => _renderPassClear;

        /// <summary>
        /// Gets the value of the renderable width
        /// </summary>
        public override uint RenderableWidth => Width;
        /// <summary>
        /// Gets the value of the renderable height
        /// </summary>
        public override uint RenderableHeight => Height;

        /// <summary>
        /// Gets the value of the attachment count
        /// </summary>
        public override uint AttachmentCount { get; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkFramebuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        /// <param name="isPresented">The is presented</param>
        public VkFramebuffer(VkGraphicsDevice gd, ref FramebufferDescription description, bool isPresented)
            : base(description.DepthTarget, description.ColorTargets)
        {
            _gd = gd;

            VkRenderPassCreateInfo renderPassCI = VkRenderPassCreateInfo.New();

            StackList<VkAttachmentDescription> attachments = new StackList<VkAttachmentDescription>();

            uint colorAttachmentCount = (uint)ColorTargets.Count;
            StackList<VkAttachmentReference> colorAttachmentRefs = new StackList<VkAttachmentReference>();
            for (int i = 0; i < colorAttachmentCount; i++)
            {
                VkTexture vkColorTex = Util.AssertSubtype<Texture, VkTexture>(ColorTargets[i].Target);
                VkAttachmentDescription colorAttachmentDesc = new VkAttachmentDescription();
                colorAttachmentDesc.format = vkColorTex.VkFormat;
                colorAttachmentDesc.samples = vkColorTex.VkSampleCount;
                colorAttachmentDesc.loadOp = VkAttachmentLoadOp.Load;
                colorAttachmentDesc.storeOp = VkAttachmentStoreOp.Store;
                colorAttachmentDesc.stencilLoadOp = VkAttachmentLoadOp.DontCare;
                colorAttachmentDesc.stencilStoreOp = VkAttachmentStoreOp.DontCare;
                colorAttachmentDesc.initialLayout = isPresented
                    ? VkImageLayout.PresentSrcKHR
                    : ((vkColorTex.Usage & TextureUsage.Sampled) != 0)
                        ? VkImageLayout.ShaderReadOnlyOptimal
                        : VkImageLayout.ColorAttachmentOptimal;
                colorAttachmentDesc.finalLayout = VkImageLayout.ColorAttachmentOptimal;
                attachments.Add(colorAttachmentDesc);

                VkAttachmentReference colorAttachmentRef = new VkAttachmentReference();
                colorAttachmentRef.attachment = (uint)i;
                colorAttachmentRef.layout = VkImageLayout.ColorAttachmentOptimal;
                colorAttachmentRefs.Add(colorAttachmentRef);
            }

            VkAttachmentDescription depthAttachmentDesc = new VkAttachmentDescription();
            VkAttachmentReference depthAttachmentRef = new VkAttachmentReference();
            if (DepthTarget != null)
            {
                VkTexture vkDepthTex = Util.AssertSubtype<Texture, VkTexture>(DepthTarget.Value.Target);
                bool hasStencil = FormatHelpers.IsStencilFormat(vkDepthTex.Format);
                depthAttachmentDesc.format = vkDepthTex.VkFormat;
                depthAttachmentDesc.samples = vkDepthTex.VkSampleCount;
                depthAttachmentDesc.loadOp = VkAttachmentLoadOp.Load;
                depthAttachmentDesc.storeOp = VkAttachmentStoreOp.Store;
                depthAttachmentDesc.stencilLoadOp = VkAttachmentLoadOp.DontCare;
                depthAttachmentDesc.stencilStoreOp = hasStencil
                    ? VkAttachmentStoreOp.Store
                    : VkAttachmentStoreOp.DontCare;
                depthAttachmentDesc.initialLayout = ((vkDepthTex.Usage & TextureUsage.Sampled) != 0)
                    ? VkImageLayout.ShaderReadOnlyOptimal
                    : VkImageLayout.DepthStencilAttachmentOptimal;
                depthAttachmentDesc.finalLayout = VkImageLayout.DepthStencilAttachmentOptimal;

                depthAttachmentRef.attachment = (uint)description.ColorTargets.Length;
                depthAttachmentRef.layout = VkImageLayout.DepthStencilAttachmentOptimal;
            }

            VkSubpassDescription subpass = new VkSubpassDescription();
            subpass.pipelineBindPoint = VkPipelineBindPoint.Graphics;
            if (ColorTargets.Count > 0)
            {
                subpass.colorAttachmentCount = colorAttachmentCount;
                subpass.pColorAttachments = (VkAttachmentReference*)colorAttachmentRefs.Data;
            }

            if (DepthTarget != null)
            {
                subpass.pDepthStencilAttachment = &depthAttachmentRef;
                attachments.Add(depthAttachmentDesc);
            }

            VkSubpassDependency subpassDependency = new VkSubpassDependency();
            subpassDependency.srcSubpass = SubpassExternal;
            subpassDependency.srcStageMask = VkPipelineStageFlags.ColorAttachmentOutput;
            subpassDependency.dstStageMask = VkPipelineStageFlags.ColorAttachmentOutput;
            subpassDependency.dstAccessMask = VkAccessFlags.ColorAttachmentRead | VkAccessFlags.ColorAttachmentWrite;

            renderPassCI.attachmentCount = attachments.Count;
            renderPassCI.pAttachments = (VkAttachmentDescription*)attachments.Data;
            renderPassCI.subpassCount = 1;
            renderPassCI.pSubpasses = &subpass;
            renderPassCI.dependencyCount = 1;
            renderPassCI.pDependencies = &subpassDependency;

            VkResult creationResult = vkCreateRenderPass(_gd.Device, ref renderPassCI, null, out _renderPassNoClear);
            CheckResult(creationResult);

            for (int i = 0; i < colorAttachmentCount; i++)
            {
                attachments[i].loadOp = VkAttachmentLoadOp.Load;
                attachments[i].initialLayout = VkImageLayout.ColorAttachmentOptimal;
            }
            if (DepthTarget != null)
            {
                attachments[attachments.Count - 1].loadOp = VkAttachmentLoadOp.Load;
                attachments[attachments.Count - 1].initialLayout = VkImageLayout.DepthStencilAttachmentOptimal;
                bool hasStencil = FormatHelpers.IsStencilFormat(DepthTarget.Value.Target.Format);
                if (hasStencil)
                {
                    attachments[attachments.Count - 1].stencilLoadOp = VkAttachmentLoadOp.Load;
                }

            }
            creationResult = vkCreateRenderPass(_gd.Device, ref renderPassCI, null, out _renderPassNoClearLoad);
            CheckResult(creationResult);


            // Load version

            if (DepthTarget != null)
            {
                attachments[attachments.Count - 1].loadOp = VkAttachmentLoadOp.Clear;
                attachments[attachments.Count - 1].initialLayout = VkImageLayout.Undefined;
                bool hasStencil = FormatHelpers.IsStencilFormat(DepthTarget.Value.Target.Format);
                if (hasStencil)
                {
                    attachments[attachments.Count - 1].stencilLoadOp = VkAttachmentLoadOp.Clear;
                }
            }

            for (int i = 0; i < colorAttachmentCount; i++)
            {
                attachments[i].loadOp = VkAttachmentLoadOp.Clear;
                attachments[i].initialLayout = VkImageLayout.Undefined;
            }

            creationResult = vkCreateRenderPass(_gd.Device, ref renderPassCI, null, out _renderPassClear);
            CheckResult(creationResult);

            VkFramebufferCreateInfo fbCI = VkFramebufferCreateInfo.New();
            uint fbAttachmentsCount = (uint)description.ColorTargets.Length;
            if (description.DepthTarget != null)
            {
                fbAttachmentsCount += 1;
            }

            VkImageView* fbAttachments = stackalloc VkImageView[(int)fbAttachmentsCount];
            for (int i = 0; i < colorAttachmentCount; i++)
            {
                VkTexture vkColorTarget = Util.AssertSubtype<Texture, VkTexture>(description.ColorTargets[i].Target);
                VkImageViewCreateInfo imageViewCI = VkImageViewCreateInfo.New();
                imageViewCI.image = vkColorTarget.OptimalDeviceImage;
                imageViewCI.format = vkColorTarget.VkFormat;
                imageViewCI.viewType = VkImageViewType.Image2D;
                imageViewCI.subresourceRange = new VkImageSubresourceRange(
                    VkImageAspectFlags.Color,
                    description.ColorTargets[i].MipLevel,
                    1,
                    description.ColorTargets[i].ArrayLayer,
                    1);
                VkImageView* dest = (fbAttachments + i);
                VkResult result = vkCreateImageView(_gd.Device, ref imageViewCI, null, dest);
                CheckResult(result);
                _attachmentViews.Add(*dest);
            }

            // Depth
            if (description.DepthTarget != null)
            {
                VkTexture vkDepthTarget = Util.AssertSubtype<Texture, VkTexture>(description.DepthTarget.Value.Target);
                bool hasStencil = FormatHelpers.IsStencilFormat(vkDepthTarget.Format);
                VkImageViewCreateInfo depthViewCI = VkImageViewCreateInfo.New();
                depthViewCI.image = vkDepthTarget.OptimalDeviceImage;
                depthViewCI.format = vkDepthTarget.VkFormat;
                depthViewCI.viewType = description.DepthTarget.Value.Target.ArrayLayers == 1
                    ? VkImageViewType.Image2D
                    : VkImageViewType.Image2DArray;
                depthViewCI.subresourceRange = new VkImageSubresourceRange(
                    hasStencil ? VkImageAspectFlags.Depth | VkImageAspectFlags.Stencil : VkImageAspectFlags.Depth,
                    description.DepthTarget.Value.MipLevel,
                    1,
                    description.DepthTarget.Value.ArrayLayer,
                    1);
                VkImageView* dest = (fbAttachments + (fbAttachmentsCount - 1));
                VkResult result = vkCreateImageView(_gd.Device, ref depthViewCI, null, dest);
                CheckResult(result);
                _attachmentViews.Add(*dest);
            }

            Texture dimTex;
            uint mipLevel;
            if (ColorTargets.Count > 0)
            {
                dimTex = ColorTargets[0].Target;
                mipLevel = ColorTargets[0].MipLevel;
            }
            else
            {
                Debug.Assert(DepthTarget != null);
                dimTex = DepthTarget.Value.Target;
                mipLevel = DepthTarget.Value.MipLevel;
            }

            Util.GetMipDimensions(
                dimTex,
                mipLevel,
                out uint mipWidth,
                out uint mipHeight,
                out _);

            fbCI.width = mipWidth;
            fbCI.height = mipHeight;

            fbCI.attachmentCount = fbAttachmentsCount;
            fbCI.pAttachments = fbAttachments;
            fbCI.layers = 1;
            fbCI.renderPass = _renderPassNoClear;

            creationResult = vkCreateFramebuffer(_gd.Device, ref fbCI, null, out _deviceFramebuffer);
            CheckResult(creationResult);

            if (DepthTarget != null)
            {
                AttachmentCount += 1;
            }
            AttachmentCount += (uint)ColorTargets.Count;
        }

        /// <summary>
        /// Transitions the to intermediate layout using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        public override void TransitionToIntermediateLayout(VkCommandBuffer cb)
        {
            for (int i = 0; i < ColorTargets.Count; i++)
            {
                FramebufferAttachment ca = ColorTargets[i];
                VkTexture vkTex = Util.AssertSubtype<Texture, VkTexture>(ca.Target);
                vkTex.SetImageLayout(ca.MipLevel, ca.ArrayLayer, VkImageLayout.ColorAttachmentOptimal);
            }
            if (DepthTarget != null)
            {
                VkTexture vkTex = Util.AssertSubtype<Texture, VkTexture>(DepthTarget.Value.Target);
                vkTex.SetImageLayout(
                    DepthTarget.Value.MipLevel,
                    DepthTarget.Value.ArrayLayer,
                    VkImageLayout.DepthStencilAttachmentOptimal);
            }
        }

        /// <summary>
        /// Transitions the to final layout using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        public override void TransitionToFinalLayout(VkCommandBuffer cb)
        {
            for (int i = 0; i < ColorTargets.Count; i++)
            {
                FramebufferAttachment ca = ColorTargets[i];
                VkTexture vkTex = Util.AssertSubtype<Texture, VkTexture>(ca.Target);
                if ((vkTex.Usage & TextureUsage.Sampled) != 0)
                {
                    vkTex.TransitionImageLayout(
                        cb,
                        ca.MipLevel, 1,
                        ca.ArrayLayer, 1,
                        VkImageLayout.ShaderReadOnlyOptimal);
                }
            }
            if (DepthTarget != null)
            {
                VkTexture vkTex = Util.AssertSubtype<Texture, VkTexture>(DepthTarget.Value.Target);
                if ((vkTex.Usage & TextureUsage.Sampled) != 0)
                {
                    vkTex.TransitionImageLayout(
                        cb,
                        DepthTarget.Value.MipLevel, 1,
                        DepthTarget.Value.ArrayLayer, 1,
                        VkImageLayout.ShaderReadOnlyOptimal);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
                _gd.SetResourceName(this, value);
            }
        }

        /// <summary>
        /// Disposes the core
        /// </summary>
        protected override void DisposeCore()
        {
            if (!_destroyed)
            {
                vkDestroyFramebuffer(_gd.Device, _deviceFramebuffer, null);
                vkDestroyRenderPass(_gd.Device, _renderPassNoClear, null);
                vkDestroyRenderPass(_gd.Device, _renderPassNoClearLoad, null);
                vkDestroyRenderPass(_gd.Device, _renderPassClear, null);
                foreach (VkImageView view in _attachmentViews)
                {
                    vkDestroyImageView(_gd.Device, view, null);
                }

                _destroyed = true;
            }
        }
    }
}
