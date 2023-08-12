using System.Collections.Generic;
using Vulkan;
using static Vulkan.VulkanNative;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk resource set class
    /// </summary>
    /// <seealso cref="ResourceSet"/>
    internal unsafe class VkResourceSet : ResourceSet
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The descriptor counts
        /// </summary>
        private readonly DescriptorResourceCounts _descriptorCounts;
        /// <summary>
        /// The descriptor allocation token
        /// </summary>
        private readonly DescriptorAllocationToken _descriptorAllocationToken;
        /// <summary>
        /// The resource ref count
        /// </summary>
        private readonly List<ResourceRefCount> _refCounts = new List<ResourceRefCount>();
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the descriptor set
        /// </summary>
        public VkDescriptorSet DescriptorSet => _descriptorAllocationToken.Set;

        /// <summary>
        /// The vk texture
        /// </summary>
        private readonly List<VkTexture> _sampledTextures = new List<VkTexture>();
        /// <summary>
        /// Gets the value of the sampled textures
        /// </summary>
        public List<VkTexture> SampledTextures => _sampledTextures;
        /// <summary>
        /// The vk texture
        /// </summary>
        private readonly List<VkTexture> _storageImages = new List<VkTexture>();
        /// <summary>
        /// Gets the value of the storage textures
        /// </summary>
        public List<VkTexture> StorageTextures => _storageImages;

        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }
        /// <summary>
        /// Gets the value of the ref counts
        /// </summary>
        public List<ResourceRefCount> RefCounts => _refCounts;

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkResourceSet"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public VkResourceSet(VkGraphicsDevice gd, ref ResourceSetDescription description)
            : base(ref description)
        {
            _gd = gd;
            RefCount = new ResourceRefCount(DisposeCore);
            VkResourceLayout vkLayout = Util.AssertSubtype<ResourceLayout, VkResourceLayout>(description.Layout);

            VkDescriptorSetLayout dsl = vkLayout.DescriptorSetLayout;
            _descriptorCounts = vkLayout.DescriptorResourceCounts;
            _descriptorAllocationToken = _gd.DescriptorPoolManager.Allocate(_descriptorCounts, dsl);

            BindableResource[] boundResources = description.BoundResources;
            uint descriptorWriteCount = (uint)boundResources.Length;
            VkWriteDescriptorSet* descriptorWrites = stackalloc VkWriteDescriptorSet[(int)descriptorWriteCount];
            VkDescriptorBufferInfo* bufferInfos = stackalloc VkDescriptorBufferInfo[(int)descriptorWriteCount];
            VkDescriptorImageInfo* imageInfos = stackalloc VkDescriptorImageInfo[(int)descriptorWriteCount];

            for (int i = 0; i < descriptorWriteCount; i++)
            {
                VkDescriptorType type = vkLayout.DescriptorTypes[i];

                descriptorWrites[i].sType = VkStructureType.WriteDescriptorSet;
                descriptorWrites[i].descriptorCount = 1;
                descriptorWrites[i].descriptorType = type;
                descriptorWrites[i].dstBinding = (uint)i;
                descriptorWrites[i].dstSet = _descriptorAllocationToken.Set;

                if (type == VkDescriptorType.UniformBuffer || type == VkDescriptorType.UniformBufferDynamic
                    || type == VkDescriptorType.StorageBuffer || type == VkDescriptorType.StorageBufferDynamic)
                {
                    DeviceBufferRange range = Util.GetBufferRange(boundResources[i], 0);
                    VkBuffer rangedVkBuffer = Util.AssertSubtype<DeviceBuffer, VkBuffer>(range.Buffer);
                    bufferInfos[i].buffer = rangedVkBuffer.DeviceBuffer;
                    bufferInfos[i].offset = range.Offset;
                    bufferInfos[i].range = range.SizeInBytes;
                    descriptorWrites[i].pBufferInfo = &bufferInfos[i];
                    _refCounts.Add(rangedVkBuffer.RefCount);
                }
                else if (type == VkDescriptorType.SampledImage)
                {
                    TextureView texView = Util.GetTextureView(_gd, boundResources[i]);
                    VkTextureView vkTexView = Util.AssertSubtype<TextureView, VkTextureView>(texView);
                    imageInfos[i].imageView = vkTexView.ImageView;
                    imageInfos[i].imageLayout = VkImageLayout.ShaderReadOnlyOptimal;
                    descriptorWrites[i].pImageInfo = &imageInfos[i];
                    _sampledTextures.Add(Util.AssertSubtype<Texture, VkTexture>(texView.Target));
                    _refCounts.Add(vkTexView.RefCount);
                }
                else if (type == VkDescriptorType.StorageImage)
                {
                    TextureView texView = Util.GetTextureView(_gd, boundResources[i]);
                    VkTextureView vkTexView = Util.AssertSubtype<TextureView, VkTextureView>(texView);
                    imageInfos[i].imageView = vkTexView.ImageView;
                    imageInfos[i].imageLayout = VkImageLayout.General;
                    descriptorWrites[i].pImageInfo = &imageInfos[i];
                    _storageImages.Add(Util.AssertSubtype<Texture, VkTexture>(texView.Target));
                    _refCounts.Add(vkTexView.RefCount);
                }
                else if (type == VkDescriptorType.Sampler)
                {
                    VkSampler sampler = Util.AssertSubtype<BindableResource, VkSampler>(boundResources[i]);
                    imageInfos[i].sampler = sampler.DeviceSampler;
                    descriptorWrites[i].pImageInfo = &imageInfos[i];
                    _refCounts.Add(sampler.RefCount);
                }
            }

            vkUpdateDescriptorSets(_gd.Device, descriptorWriteCount, descriptorWrites, 0, null);
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
                _gd.DescriptorPoolManager.Free(_descriptorAllocationToken, _descriptorCounts);
            }
        }
    }
}
