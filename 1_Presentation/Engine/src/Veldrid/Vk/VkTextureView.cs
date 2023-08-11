using Vulkan;
using static Veldrid.Vk.VulkanUtil;
using static Vulkan.VulkanNative;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vk texture view class
    /// </summary>
    /// <seealso cref="TextureView"/>
    internal unsafe class VkTextureView : TextureView
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The image view
        /// </summary>
        private readonly VkImageView _imageView;
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the image view
        /// </summary>
        public VkImageView ImageView => _imageView;

        /// <summary>
        /// Gets the value of the target
        /// </summary>
        public new VkTexture Target => (VkTexture)base.Target;

        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkTextureView"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public VkTextureView(VkGraphicsDevice gd, ref TextureViewDescription description)
            : base(ref description)
        {
            _gd = gd;
            VkImageViewCreateInfo imageViewCI = VkImageViewCreateInfo.New();
            VkTexture tex = Util.AssertSubtype<Texture, VkTexture>(description.Target);
            imageViewCI.image = tex.OptimalDeviceImage;
            imageViewCI.format = VkFormats.VdToVkPixelFormat(Format, (Target.Usage & TextureUsage.DepthStencil) != 0);

            VkImageAspectFlags aspectFlags;
            if ((description.Target.Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil)
            {
                aspectFlags = VkImageAspectFlags.Depth;
            }
            else
            {
                aspectFlags = VkImageAspectFlags.Color;
            }

            imageViewCI.subresourceRange = new VkImageSubresourceRange(
                aspectFlags,
                description.BaseMipLevel,
                description.MipLevels,
                description.BaseArrayLayer,
                description.ArrayLayers);

            if ((tex.Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
            {
                imageViewCI.viewType = description.ArrayLayers == 1 ? VkImageViewType.ImageCube : VkImageViewType.ImageCubeArray;
                imageViewCI.subresourceRange.layerCount *= 6;
            }
            else
            {
                switch (tex.Type)
                {
                    case TextureType.Texture1D:
                        imageViewCI.viewType = description.ArrayLayers == 1
                            ? VkImageViewType.Image1D
                            : VkImageViewType.Image1DArray;
                        break;
                    case TextureType.Texture2D:
                        imageViewCI.viewType = description.ArrayLayers == 1
                            ? VkImageViewType.Image2D
                            : VkImageViewType.Image2DArray;
                        break;
                    case TextureType.Texture3D:
                        imageViewCI.viewType = VkImageViewType.Image3D;
                        break;
                }
            }

            vkCreateImageView(_gd.Device, ref imageViewCI, null, out _imageView);
            RefCount = new ResourceRefCount(DisposeCore);
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
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            RefCount.Decrement();
        }

        /// <summary>
        /// Disposes the core
        /// </summary>
        private void DisposeCore()
        {
            if (!_destroyed)
            {
                _destroyed = true;
                vkDestroyImageView(_gd.Device, ImageView, null);
            }
        }
    }
}
