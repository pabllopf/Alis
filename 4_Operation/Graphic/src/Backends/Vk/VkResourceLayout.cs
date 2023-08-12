using Vulkan;
using static Vulkan.VulkanNative;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk resource layout class
    /// </summary>
    /// <seealso cref="ResourceLayout"/>
    internal unsafe class VkResourceLayout : ResourceLayout
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The dsl
        /// </summary>
        private readonly VkDescriptorSetLayout _dsl;
        /// <summary>
        /// The descriptor types
        /// </summary>
        private readonly VkDescriptorType[] _descriptorTypes;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the descriptor set layout
        /// </summary>
        public VkDescriptorSetLayout DescriptorSetLayout => _dsl;
        /// <summary>
        /// Gets the value of the descriptor types
        /// </summary>
        public VkDescriptorType[] DescriptorTypes => _descriptorTypes;
        /// <summary>
        /// Gets the value of the descriptor resource counts
        /// </summary>
        public DescriptorResourceCounts DescriptorResourceCounts { get; }
        /// <summary>
        /// Gets the value of the dynamic buffer count
        /// </summary>
        public new int DynamicBufferCount { get; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkResourceLayout"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public VkResourceLayout(VkGraphicsDevice gd, ref ResourceLayoutDescription description)
            : base(ref description)
        {
            _gd = gd;
            VkDescriptorSetLayoutCreateInfo dslCI = VkDescriptorSetLayoutCreateInfo.New();
            ResourceLayoutElementDescription[] elements = description.Elements;
            _descriptorTypes = new VkDescriptorType[elements.Length];
            VkDescriptorSetLayoutBinding* bindings = stackalloc VkDescriptorSetLayoutBinding[elements.Length];

            uint uniformBufferCount = 0;
            uint uniformBufferDynamicCount = 0;
            uint sampledImageCount = 0;
            uint samplerCount = 0;
            uint storageBufferCount = 0;
            uint storageBufferDynamicCount = 0;
            uint storageImageCount = 0;

            for (uint i = 0; i < elements.Length; i++)
            {
                bindings[i].binding = i;
                bindings[i].descriptorCount = 1;
                VkDescriptorType descriptorType = VkFormats.VdToVkDescriptorType(elements[i].Kind, elements[i].Options);
                bindings[i].descriptorType = descriptorType;
                bindings[i].stageFlags = VkFormats.VdToVkShaderStages(elements[i].Stages);
                if ((elements[i].Options & ResourceLayoutElementOptions.DynamicBinding) != 0)
                {
                    DynamicBufferCount += 1;
                }

                _descriptorTypes[i] = descriptorType;

                switch (descriptorType)
                {
                    case VkDescriptorType.Sampler:
                        samplerCount += 1;
                        break;
                    case VkDescriptorType.SampledImage:
                        sampledImageCount += 1;
                        break;
                    case VkDescriptorType.StorageImage:
                        storageImageCount += 1;
                        break;
                    case VkDescriptorType.UniformBuffer:
                        uniformBufferCount += 1;
                        break;
                    case VkDescriptorType.UniformBufferDynamic:
                        uniformBufferDynamicCount += 1;
                        break;
                    case VkDescriptorType.StorageBuffer:
                        storageBufferCount += 1;
                        break;
                    case VkDescriptorType.StorageBufferDynamic:
                        storageBufferDynamicCount += 1;
                        break;
                }
            }

            DescriptorResourceCounts = new DescriptorResourceCounts(
                uniformBufferCount,
                uniformBufferDynamicCount,
                sampledImageCount,
                samplerCount,
                storageBufferCount,
                storageBufferDynamicCount,
                storageImageCount);

            dslCI.bindingCount = (uint)elements.Length;
            dslCI.pBindings = bindings;

            VkResult result = vkCreateDescriptorSetLayout(_gd.Device, ref dslCI, null, out _dsl);
            CheckResult(result);
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
            if (!_disposed)
            {
                _disposed = true;
                vkDestroyDescriptorSetLayout(_gd.Device, _dsl, null);
            }
        }
    }
}
