using System;
using System.Collections.Generic;
using Vulkan;
using static Vulkan.VulkanNative;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk swapchain framebuffer class
    /// </summary>
    /// <seealso cref="VkFramebufferBase"/>
    internal unsafe class VkSwapchainFramebuffer : VkFramebufferBase
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The swapchain
        /// </summary>
        private readonly VkSwapchain _swapchain;
        /// <summary>
        /// The surface
        /// </summary>
        private readonly VkSurfaceKHR _surface;
        /// <summary>
        /// The depth format
        /// </summary>
        private readonly PixelFormat? _depthFormat;
        /// <summary>
        /// The current image index
        /// </summary>
        private uint _currentImageIndex;

        /// <summary>
        /// The sc framebuffers
        /// </summary>
        private VkFramebuffer[] _scFramebuffers;
        /// <summary>
        /// The sc images
        /// </summary>
        private VkImage[] _scImages;
        /// <summary>
        /// The sc image format
        /// </summary>
        private VkFormat _scImageFormat;
        /// <summary>
        /// The sc extent
        /// </summary>
        private VkExtent2D _scExtent;
        /// <summary>
        /// The sc color textures
        /// </summary>
        private FramebufferAttachment[][] _scColorTextures;

        /// <summary>
        /// The depth attachment
        /// </summary>
        private FramebufferAttachment? _depthAttachment;
        /// <summary>
        /// The desired width
        /// </summary>
        private uint _desiredWidth;
        /// <summary>
        /// The desired height
        /// </summary>
        private uint _desiredHeight;
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The output description
        /// </summary>
        private OutputDescription _outputDescription;

        /// <summary>
        /// Gets the value of the current framebuffer
        /// </summary>
        public override Vulkan.VkFramebuffer CurrentFramebuffer => _scFramebuffers[(int)_currentImageIndex].CurrentFramebuffer;

        /// <summary>
        /// Gets the value of the renderpassnoclear init
        /// </summary>
        public override VkRenderPass RenderPassNoClear_Init => _scFramebuffers[0].RenderPassNoClear_Init;
        /// <summary>
        /// Gets the value of the renderpassnoclear load
        /// </summary>
        public override VkRenderPass RenderPassNoClear_Load => _scFramebuffers[0].RenderPassNoClear_Load;
        /// <summary>
        /// Gets the value of the render pass clear
        /// </summary>
        public override VkRenderPass RenderPassClear => _scFramebuffers[0].RenderPassClear;

        /// <summary>
        /// Gets the value of the color targets
        /// </summary>
        public override IReadOnlyList<FramebufferAttachment> ColorTargets => _scColorTextures[(int)_currentImageIndex];

        /// <summary>
        /// Gets the value of the depth target
        /// </summary>
        public override FramebufferAttachment? DepthTarget => _depthAttachment;

        /// <summary>
        /// Gets the value of the renderable width
        /// </summary>
        public override uint RenderableWidth => _scExtent.width;
        /// <summary>
        /// Gets the value of the renderable height
        /// </summary>
        public override uint RenderableHeight => _scExtent.height;

        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public override uint Width => _desiredWidth;
        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public override uint Height => _desiredHeight;

        /// <summary>
        /// Gets the value of the image index
        /// </summary>
        public uint ImageIndex => _currentImageIndex;

        /// <summary>
        /// Gets the value of the output description
        /// </summary>
        public override OutputDescription OutputDescription => _outputDescription;

        /// <summary>
        /// Gets the value of the attachment count
        /// </summary>
        public override uint AttachmentCount { get; }

        /// <summary>
        /// Gets the value of the swapchain
        /// </summary>
        public VkSwapchain Swapchain => _swapchain;

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkSwapchainFramebuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="swapchain">The swapchain</param>
        /// <param name="surface">The surface</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depthFormat">The depth format</param>
        public VkSwapchainFramebuffer(
            VkGraphicsDevice gd,
            VkSwapchain swapchain,
            VkSurfaceKHR surface,
            uint width,
            uint height,
            PixelFormat? depthFormat)
            : base()
        {
            _gd = gd;
            _swapchain = swapchain;
            _surface = surface;
            _depthFormat = depthFormat;

            AttachmentCount = depthFormat.HasValue ? 2u : 1u; // 1 Color + 1 Depth
        }

        /// <summary>
        /// Sets the image index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        internal void SetImageIndex(uint index)
        {
            _currentImageIndex = index;
        }

        /// <summary>
        /// Sets the new swapchain using the specified device swapchain
        /// </summary>
        /// <param name="deviceSwapchain">The device swapchain</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="surfaceFormat">The surface format</param>
        /// <param name="swapchainExtent">The swapchain extent</param>
        internal void SetNewSwapchain(
            VkSwapchainKHR deviceSwapchain,
            uint width,
            uint height,
            VkSurfaceFormatKHR surfaceFormat,
            VkExtent2D swapchainExtent)
        {
            _desiredWidth = width;
            _desiredHeight = height;

            // Get the images
            uint scImageCount = 0;
            VkResult result = vkGetSwapchainImagesKHR(_gd.Device, deviceSwapchain, ref scImageCount, null);
            CheckResult(result);
            if (_scImages == null)
            {
                _scImages = new VkImage[(int)scImageCount];
            }
            result = vkGetSwapchainImagesKHR(_gd.Device, deviceSwapchain, ref scImageCount, out _scImages[0]);
            CheckResult(result);

            _scImageFormat = surfaceFormat.format;
            _scExtent = swapchainExtent;

            CreateDepthTexture();
            CreateFramebuffers();

            _outputDescription = OutputDescription.CreateFromFramebuffer(this);
        }

        /// <summary>
        /// Destroys the swapchain framebuffers
        /// </summary>
        private void DestroySwapchainFramebuffers()
        {
            if (_scFramebuffers != null)
            {
                for (int i = 0; i < _scFramebuffers.Length; i++)
                {
                    _scFramebuffers[i]?.Dispose();
                    _scFramebuffers[i] = null;
                }
                Array.Clear(_scFramebuffers, 0, _scFramebuffers.Length);
            }
        }

        /// <summary>
        /// Creates the depth texture
        /// </summary>
        private void CreateDepthTexture()
        {
            if (_depthFormat.HasValue)
            {
                _depthAttachment?.Target.Dispose();
                VkTexture depthTexture = (VkTexture)_gd.ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                    Math.Max(1, _scExtent.width),
                    Math.Max(1, _scExtent.height),
                    1,
                    1,
                    _depthFormat.Value,
                    TextureUsage.DepthStencil));
                _depthAttachment = new FramebufferAttachment(depthTexture, 0);
            }
        }

        /// <summary>
        /// Creates the framebuffers
        /// </summary>
        private void CreateFramebuffers()
        {
            if (_scFramebuffers != null)
            {
                for (int i = 0; i < _scFramebuffers.Length; i++)
                {
                    _scFramebuffers[i]?.Dispose();
                    _scFramebuffers[i] = null;
                }
                Array.Clear(_scFramebuffers, 0, _scFramebuffers.Length);
            }

            Util.EnsureArrayMinimumSize(ref _scFramebuffers, (uint)_scImages.Length);
            Util.EnsureArrayMinimumSize(ref _scColorTextures, (uint)_scImages.Length);
            for (uint i = 0; i < _scImages.Length; i++)
            {
                VkTexture colorTex = new VkTexture(
                    _gd,
                    Math.Max(1, _scExtent.width),
                    Math.Max(1, _scExtent.height),
                    1,
                    1,
                    _scImageFormat,
                    TextureUsage.RenderTarget,
                    TextureSampleCount.Count1,
                    _scImages[i]);
                FramebufferDescription desc = new FramebufferDescription(_depthAttachment?.Target, colorTex);
                VkFramebuffer fb = new VkFramebuffer(_gd, ref desc, true);
                _scFramebuffers[i] = fb;
                _scColorTextures[i] = new FramebufferAttachment[] { new FramebufferAttachment(colorTex, 0) };
            }
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
                vkTex.SetImageLayout(0, ca.ArrayLayer, VkImageLayout.ColorAttachmentOptimal);
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
                vkTex.TransitionImageLayout(cb, 0, 1, ca.ArrayLayer, 1, VkImageLayout.PresentSrcKHR);
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
                _destroyed = true;
                _depthAttachment?.Target.Dispose();
                DestroySwapchainFramebuffers();
            }
        }
    }
}
