using Vulkan;
using static Vulkan.VulkanNative;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk sampler class
    /// </summary>
    /// <seealso cref="Sampler"/>
    internal unsafe class VkSampler : Sampler
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The sampler
        /// </summary>
        private readonly Vulkan.VkSampler _sampler;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the device sampler
        /// </summary>
        public Vulkan.VkSampler DeviceSampler => _sampler;

        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkSampler"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public VkSampler(VkGraphicsDevice gd, ref SamplerDescription description)
        {
            _gd = gd;
            VkFormats.GetFilterParams(description.Filter, out VkFilter minFilter, out VkFilter magFilter, out VkSamplerMipmapMode mipmapMode);

            VkSamplerCreateInfo samplerCI = new VkSamplerCreateInfo
            {
                sType = VkStructureType.SamplerCreateInfo,
                addressModeU = VkFormats.VdToVkSamplerAddressMode(description.AddressModeU),
                addressModeV = VkFormats.VdToVkSamplerAddressMode(description.AddressModeV),
                addressModeW = VkFormats.VdToVkSamplerAddressMode(description.AddressModeW),
                minFilter = minFilter,
                magFilter = magFilter,
                mipmapMode = mipmapMode,
                compareEnable = description.ComparisonKind != null,
                compareOp = description.ComparisonKind != null
                    ? VkFormats.VdToVkCompareOp(description.ComparisonKind.Value)
                    : VkCompareOp.Never,
                anisotropyEnable = description.Filter == SamplerFilter.Anisotropic,
                maxAnisotropy = description.MaximumAnisotropy,
                minLod = description.MinimumLod,
                maxLod = description.MaximumLod,
                mipLodBias = description.LodBias,
                borderColor = VkFormats.VdToVkSamplerBorderColor(description.BorderColor)
            };

            vkCreateSampler(_gd.Device, ref samplerCI, null, out _sampler);
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
            if (!_disposed)
            {
                vkDestroySampler(_gd.Device, _sampler, null);
                _disposed = true;
            }
        }
    }
}
