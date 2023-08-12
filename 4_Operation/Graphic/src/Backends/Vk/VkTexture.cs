using System.Diagnostics;
using Vulkan;
using static Vulkan.VulkanNative;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk texture class
    /// </summary>
    /// <seealso cref="Texture"/>
    internal unsafe class VkTexture : Texture
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The optimal image
        /// </summary>
        private readonly VkImage _optimalImage;
        /// <summary>
        /// The memory block
        /// </summary>
        private readonly VkMemoryBlock _memoryBlock;
        /// <summary>
        /// The staging buffer
        /// </summary>
        private readonly Vulkan.VkBuffer _stagingBuffer;
        /// <summary>
        /// The format
        /// </summary>
        private PixelFormat _format; // Static for regular images -- may change for shared staging images
        /// <summary>
        /// The actual image array layers
        /// </summary>
        private readonly uint _actualImageArrayLayers;
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;

        // Immutable except for shared staging Textures.
        /// <summary>
        /// The width
        /// </summary>
        private uint _width;
        /// <summary>
        /// The height
        /// </summary>
        private uint _height;
        /// <summary>
        /// The depth
        /// </summary>
        private uint _depth;

        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public override uint Width => _width;

        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public override uint Height => _height;

        /// <summary>
        /// Gets the value of the depth
        /// </summary>
        public override uint Depth => _depth;

        /// <summary>
        /// Gets the value of the format
        /// </summary>
        public override PixelFormat Format => _format;

        /// <summary>
        /// Gets the value of the mip levels
        /// </summary>
        public override uint MipLevels { get; }

        /// <summary>
        /// Gets the value of the array layers
        /// </summary>
        public override uint ArrayLayers { get; }
        /// <summary>
        /// Gets the value of the actual array layers
        /// </summary>
        public uint ActualArrayLayers => _actualImageArrayLayers;

        /// <summary>
        /// Gets the value of the usage
        /// </summary>
        public override TextureUsage Usage { get; }

        /// <summary>
        /// Gets the value of the type
        /// </summary>
        public override TextureType Type { get; }

        /// <summary>
        /// Gets the value of the sample count
        /// </summary>
        public override TextureSampleCount SampleCount { get; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Gets the value of the optimal device image
        /// </summary>
        public VkImage OptimalDeviceImage => _optimalImage;
        /// <summary>
        /// Gets the value of the staging buffer
        /// </summary>
        public Vulkan.VkBuffer StagingBuffer => _stagingBuffer;
        /// <summary>
        /// Gets the value of the memory
        /// </summary>
        public VkMemoryBlock Memory => _memoryBlock;

        /// <summary>
        /// Gets the value of the vk format
        /// </summary>
        public VkFormat VkFormat { get; }
        /// <summary>
        /// Gets the value of the vk sample count
        /// </summary>
        public VkSampleCountFlags VkSampleCount { get; }

        /// <summary>
        /// The image layouts
        /// </summary>
        private VkImageLayout[] _imageLayouts;
        /// <summary>
        /// The is swapchain texture
        /// </summary>
        private bool _isSwapchainTexture;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }
        /// <summary>
        /// Gets the value of the is swapchain texture
        /// </summary>
        public bool IsSwapchainTexture => _isSwapchainTexture;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkTexture"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        internal VkTexture(VkGraphicsDevice gd, ref TextureDescription description)
        {
            _gd = gd;
            _width = description.Width;
            _height = description.Height;
            _depth = description.Depth;
            MipLevels = description.MipLevels;
            ArrayLayers = description.ArrayLayers;
            bool isCubemap = ((description.Usage) & TextureUsage.Cubemap) == TextureUsage.Cubemap;
            _actualImageArrayLayers = isCubemap
                ? 6 * ArrayLayers
                : ArrayLayers;
            _format = description.Format;
            Usage = description.Usage;
            Type = description.Type;
            SampleCount = description.SampleCount;
            VkSampleCount = VkFormats.VdToVkSampleCount(SampleCount);
            VkFormat = VkFormats.VdToVkPixelFormat(Format, (description.Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil);

            bool isStaging = (Usage & TextureUsage.Staging) == TextureUsage.Staging;

            if (!isStaging)
            {
                VkImageCreateInfo imageCI = VkImageCreateInfo.New();
                imageCI.mipLevels = MipLevels;
                imageCI.arrayLayers = _actualImageArrayLayers;
                imageCI.imageType = VkFormats.VdToVkTextureType(Type);
                imageCI.extent.width = Width;
                imageCI.extent.height = Height;
                imageCI.extent.depth = Depth;
                imageCI.initialLayout = VkImageLayout.Preinitialized;
                imageCI.usage = VkFormats.VdToVkTextureUsage(Usage);
                imageCI.tiling = isStaging ? VkImageTiling.Linear : VkImageTiling.Optimal;
                imageCI.format = VkFormat;
                imageCI.flags = VkImageCreateFlags.MutableFormat;

                imageCI.samples = VkSampleCount;
                if (isCubemap)
                {
                    imageCI.flags |= VkImageCreateFlags.CubeCompatible;
                }

                uint subresourceCount = MipLevels * _actualImageArrayLayers * Depth;
                VkResult result = vkCreateImage(gd.Device, ref imageCI, null, out _optimalImage);
                CheckResult(result);

                VkMemoryRequirements memoryRequirements;
                bool prefersDedicatedAllocation;
                if (_gd.GetImageMemoryRequirements2 != null)
                {
                    VkImageMemoryRequirementsInfo2KHR memReqsInfo2 = VkImageMemoryRequirementsInfo2KHR.New();
                    memReqsInfo2.image = _optimalImage;
                    VkMemoryRequirements2KHR memReqs2 = VkMemoryRequirements2KHR.New();
                    VkMemoryDedicatedRequirementsKHR dedicatedReqs = VkMemoryDedicatedRequirementsKHR.New();
                    memReqs2.pNext = &dedicatedReqs;
                    _gd.GetImageMemoryRequirements2(_gd.Device, &memReqsInfo2, &memReqs2);
                    memoryRequirements = memReqs2.memoryRequirements;
                    prefersDedicatedAllocation = dedicatedReqs.prefersDedicatedAllocation || dedicatedReqs.requiresDedicatedAllocation;
                }
                else
                {
                    vkGetImageMemoryRequirements(gd.Device, _optimalImage, out memoryRequirements);
                    prefersDedicatedAllocation = false;
                }

                VkMemoryBlock memoryToken = gd.MemoryManager.Allocate(
                    gd.PhysicalDeviceMemProperties,
                    memoryRequirements.memoryTypeBits,
                    VkMemoryPropertyFlags.DeviceLocal,
                    false,
                    memoryRequirements.size,
                    memoryRequirements.alignment,
                    prefersDedicatedAllocation,
                    _optimalImage,
                    Vulkan.VkBuffer.Null);
                _memoryBlock = memoryToken;
                result = vkBindImageMemory(gd.Device, _optimalImage, _memoryBlock.DeviceMemory, _memoryBlock.Offset);
                CheckResult(result);

                _imageLayouts = new VkImageLayout[subresourceCount];
                for (int i = 0; i < _imageLayouts.Length; i++)
                {
                    _imageLayouts[i] = VkImageLayout.Preinitialized;
                }
            }
            else // isStaging
            {
                uint depthPitch = FormatHelpers.GetDepthPitch(
                    FormatHelpers.GetRowPitch(Width, Format),
                    Height,
                    Format);
                uint stagingSize = depthPitch * Depth;
                for (uint level = 1; level < MipLevels; level++)
                {
                    Util.GetMipDimensions(this, level, out uint mipWidth, out uint mipHeight, out uint mipDepth);

                    depthPitch = FormatHelpers.GetDepthPitch(
                        FormatHelpers.GetRowPitch(mipWidth, Format),
                        mipHeight,
                        Format);

                    stagingSize += depthPitch * mipDepth;
                }
                stagingSize *= ArrayLayers;

                VkBufferCreateInfo bufferCI = VkBufferCreateInfo.New();
                bufferCI.usage = VkBufferUsageFlags.TransferSrc | VkBufferUsageFlags.TransferDst;
                bufferCI.size = stagingSize;
                VkResult result = vkCreateBuffer(_gd.Device, ref bufferCI, null, out _stagingBuffer);
                CheckResult(result);

                VkMemoryRequirements bufferMemReqs;
                bool prefersDedicatedAllocation;
                if (_gd.GetBufferMemoryRequirements2 != null)
                {
                    VkBufferMemoryRequirementsInfo2KHR memReqInfo2 = VkBufferMemoryRequirementsInfo2KHR.New();
                    memReqInfo2.buffer = _stagingBuffer;
                    VkMemoryRequirements2KHR memReqs2 = VkMemoryRequirements2KHR.New();
                    VkMemoryDedicatedRequirementsKHR dedicatedReqs = VkMemoryDedicatedRequirementsKHR.New();
                    memReqs2.pNext = &dedicatedReqs;
                    _gd.GetBufferMemoryRequirements2(_gd.Device, &memReqInfo2, &memReqs2);
                    bufferMemReqs = memReqs2.memoryRequirements;
                    prefersDedicatedAllocation = dedicatedReqs.prefersDedicatedAllocation || dedicatedReqs.requiresDedicatedAllocation;
                }
                else
                {
                    vkGetBufferMemoryRequirements(gd.Device, _stagingBuffer, out bufferMemReqs);
                    prefersDedicatedAllocation = false;
                }

                // Use "host cached" memory when available, for better performance of GPU -> CPU transfers
                var propertyFlags = VkMemoryPropertyFlags.HostVisible | VkMemoryPropertyFlags.HostCoherent | VkMemoryPropertyFlags.HostCached;
                if (!TryFindMemoryType(_gd.PhysicalDeviceMemProperties, bufferMemReqs.memoryTypeBits, propertyFlags, out _))
                {
                    propertyFlags ^= VkMemoryPropertyFlags.HostCached;
                }
                _memoryBlock = _gd.MemoryManager.Allocate(
                    _gd.PhysicalDeviceMemProperties,
                    bufferMemReqs.memoryTypeBits,
                    propertyFlags,
                    true,
                    bufferMemReqs.size,
                    bufferMemReqs.alignment,
                    prefersDedicatedAllocation,
                    VkImage.Null,
                    _stagingBuffer);

                result = vkBindBufferMemory(_gd.Device, _stagingBuffer, _memoryBlock.DeviceMemory, _memoryBlock.Offset);
                CheckResult(result);
            }

            ClearIfRenderTarget();
            TransitionIfSampled();
            RefCount = new ResourceRefCount(RefCountedDispose);
        }

        // Used to construct Swapchain textures.
        /// <summary>
        /// Initializes a new instance of the <see cref="VkTexture"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="mipLevels">The mip levels</param>
        /// <param name="arrayLayers">The array layers</param>
        /// <param name="vkFormat">The vk format</param>
        /// <param name="usage">The usage</param>
        /// <param name="sampleCount">The sample count</param>
        /// <param name="existingImage">The existing image</param>
        internal VkTexture(
            VkGraphicsDevice gd,
            uint width,
            uint height,
            uint mipLevels,
            uint arrayLayers,
            VkFormat vkFormat,
            TextureUsage usage,
            TextureSampleCount sampleCount,
            VkImage existingImage)
        {
            Debug.Assert(width > 0 && height > 0);
            _gd = gd;
            MipLevels = mipLevels;
            _width = width;
            _height = height;
            _depth = 1;
            VkFormat = vkFormat;
            _format = VkFormats.VkToVdPixelFormat(VkFormat);
            ArrayLayers = arrayLayers;
            Usage = usage;
            Type = TextureType.Texture2D;
            SampleCount = sampleCount;
            VkSampleCount = VkFormats.VdToVkSampleCount(sampleCount);
            _optimalImage = existingImage;
            _imageLayouts = new[] { VkImageLayout.Undefined };
            _isSwapchainTexture = true;

            ClearIfRenderTarget();
            RefCount = new ResourceRefCount(DisposeCore);
        }

        /// <summary>
        /// Clears the if render target
        /// </summary>
        private void ClearIfRenderTarget()
        {
            // If the image is going to be used as a render target, we need to clear the data before its first use.
            if ((Usage & TextureUsage.RenderTarget) != 0)
            {
                _gd.ClearColorTexture(this, new VkClearColorValue(0, 0, 0, 0));
            }
            else if ((Usage & TextureUsage.DepthStencil) != 0)
            {
                _gd.ClearDepthTexture(this, new VkClearDepthStencilValue(0, 0));
            }
        }

        /// <summary>
        /// Transitions the if sampled
        /// </summary>
        private void TransitionIfSampled()
        {
            if ((Usage & TextureUsage.Sampled) != 0)
            {
                _gd.TransitionImageLayout(this, VkImageLayout.ShaderReadOnlyOptimal);
            }
        }

        /// <summary>
        /// Gets the subresource layout using the specified subresource
        /// </summary>
        /// <param name="subresource">The subresource</param>
        /// <returns>The vk subresource layout</returns>
        internal VkSubresourceLayout GetSubresourceLayout(uint subresource)
        {
            bool staging = _stagingBuffer.Handle != 0;
            Util.GetMipLevelAndArrayLayer(this, subresource, out uint mipLevel, out uint arrayLayer);
            if (!staging)
            {
                VkImageAspectFlags aspect = (Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil
                  ? (VkImageAspectFlags.Depth | VkImageAspectFlags.Stencil)
                  : VkImageAspectFlags.Color;
                VkImageSubresource imageSubresource = new VkImageSubresource
                {
                    arrayLayer = arrayLayer,
                    mipLevel = mipLevel,
                    aspectMask = aspect,
                };

                vkGetImageSubresourceLayout(_gd.Device, _optimalImage, ref imageSubresource, out VkSubresourceLayout layout);
                return layout;
            }
            else
            {
                uint blockSize = FormatHelpers.IsCompressedFormat(Format) ? 4u : 1u;
                Util.GetMipDimensions(this, mipLevel, out uint mipWidth, out uint mipHeight, out uint mipDepth);
                uint rowPitch = FormatHelpers.GetRowPitch(mipWidth, Format);
                uint depthPitch = FormatHelpers.GetDepthPitch(rowPitch, mipHeight, Format);

                VkSubresourceLayout layout = new VkSubresourceLayout()
                {
                    rowPitch = rowPitch,
                    depthPitch = depthPitch,
                    arrayPitch = depthPitch,
                    size = depthPitch,
                };
                layout.offset = Util.ComputeSubresourceOffset(this, mipLevel, arrayLayer);

                return layout;
            }
        }

        /// <summary>
        /// Transitions the image layout using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        /// <param name="baseMipLevel">The base mip level</param>
        /// <param name="levelCount">The level count</param>
        /// <param name="baseArrayLayer">The base array layer</param>
        /// <param name="layerCount">The layer count</param>
        /// <param name="newLayout">The new layout</param>
        internal void TransitionImageLayout(
            VkCommandBuffer cb,
            uint baseMipLevel,
            uint levelCount,
            uint baseArrayLayer,
            uint layerCount,
            VkImageLayout newLayout)
        {
            if (_stagingBuffer != Vulkan.VkBuffer.Null)
            {
                return;
            }

            VkImageLayout oldLayout = _imageLayouts[CalculateSubresource(baseMipLevel, baseArrayLayer)];
#if DEBUG
            for (uint level = 0; level < levelCount; level++)
            {
                for (uint layer = 0; layer < layerCount; layer++)
                {
                    if (_imageLayouts[CalculateSubresource(baseMipLevel + level, baseArrayLayer + layer)] != oldLayout)
                    {
                        throw new VeldridException("Unexpected image layout.");
                    }
                }
            }
#endif
            if (oldLayout != newLayout)
            {
                VkImageAspectFlags aspectMask;
                if ((Usage & TextureUsage.DepthStencil) != 0)
                {
                    aspectMask = FormatHelpers.IsStencilFormat(Format)
                        ? VkImageAspectFlags.Depth | VkImageAspectFlags.Stencil
                        : VkImageAspectFlags.Depth;
                }
                else
                {
                    aspectMask = VkImageAspectFlags.Color;
                }
                VulkanUtil.TransitionImageLayout(
                    cb,
                    OptimalDeviceImage,
                    baseMipLevel,
                    levelCount,
                    baseArrayLayer,
                    layerCount,
                    aspectMask,
                    _imageLayouts[CalculateSubresource(baseMipLevel, baseArrayLayer)],
                    newLayout);

                for (uint level = 0; level < levelCount; level++)
                {
                    for (uint layer = 0; layer < layerCount; layer++)
                    {
                        _imageLayouts[CalculateSubresource(baseMipLevel + level, baseArrayLayer + layer)] = newLayout;
                    }
                }
            }
        }

        /// <summary>
        /// Transitions the image layout nonmatching using the specified cb
        /// </summary>
        /// <param name="cb">The cb</param>
        /// <param name="baseMipLevel">The base mip level</param>
        /// <param name="levelCount">The level count</param>
        /// <param name="baseArrayLayer">The base array layer</param>
        /// <param name="layerCount">The layer count</param>
        /// <param name="newLayout">The new layout</param>
        internal void TransitionImageLayoutNonmatching(
            VkCommandBuffer cb,
            uint baseMipLevel,
            uint levelCount,
            uint baseArrayLayer,
            uint layerCount,
            VkImageLayout newLayout)
        {
            if (_stagingBuffer != Vulkan.VkBuffer.Null)
            {
                return;
            }

            for (uint level = baseMipLevel; level < baseMipLevel + levelCount; level++)
            {
                for (uint layer = baseArrayLayer; layer < baseArrayLayer + layerCount; layer++)
                {
                    uint subresource = CalculateSubresource(level, layer);
                    VkImageLayout oldLayout = _imageLayouts[subresource];

                    if (oldLayout != newLayout)
                    {
                        VkImageAspectFlags aspectMask;
                        if ((Usage & TextureUsage.DepthStencil) != 0)
                        {
                            aspectMask = FormatHelpers.IsStencilFormat(Format)
                                ? VkImageAspectFlags.Depth | VkImageAspectFlags.Stencil
                                : VkImageAspectFlags.Depth;
                        }
                        else
                        {
                            aspectMask = VkImageAspectFlags.Color;
                        }
                        VulkanUtil.TransitionImageLayout(
                            cb,
                            OptimalDeviceImage,
                            level,
                            1,
                            layer,
                            1,
                            aspectMask,
                            oldLayout,
                            newLayout);

                        _imageLayouts[subresource] = newLayout;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the image layout using the specified mip level
        /// </summary>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <returns>The vk image layout</returns>
        internal VkImageLayout GetImageLayout(uint mipLevel, uint arrayLayer)
        {
            return _imageLayouts[CalculateSubresource(mipLevel, arrayLayer)];
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
        /// Sets the staging dimensions using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        internal void SetStagingDimensions(uint width, uint height, uint depth, PixelFormat format)
        {
            Debug.Assert(_stagingBuffer != Vulkan.VkBuffer.Null);
            Debug.Assert(Usage == TextureUsage.Staging);
            _width = width;
            _height = height;
            _depth = depth;
            _format = format;
        }

        /// <summary>
        /// Disposes the core
        /// </summary>
        private protected override void DisposeCore()
        {
            RefCount.Decrement();
        }

        /// <summary>
        /// Refs the counted dispose
        /// </summary>
        private void RefCountedDispose()
        {
            if (!_destroyed)
            {
                base.Dispose();

                _destroyed = true;

                bool isStaging = (Usage & TextureUsage.Staging) == TextureUsage.Staging;
                if (isStaging)
                {
                    vkDestroyBuffer(_gd.Device, _stagingBuffer, null);
                }
                else
                {
                    vkDestroyImage(_gd.Device, _optimalImage, null);
                }

                if (_memoryBlock.DeviceMemory.Handle != 0)
                {
                    _gd.MemoryManager.Free(_memoryBlock);
                }
            }
        }

        /// <summary>
        /// Sets the image layout using the specified mip level
        /// </summary>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <param name="layout">The layout</param>
        internal void SetImageLayout(uint mipLevel, uint arrayLayer, VkImageLayout layout)
        {
            _imageLayouts[CalculateSubresource(mipLevel, arrayLayer)] = layout;
        }
    }
}
