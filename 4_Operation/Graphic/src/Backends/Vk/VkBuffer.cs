using Vulkan;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;
using static Vulkan.VulkanNative;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk buffer class
    /// </summary>
    /// <seealso cref="DeviceBuffer"/>
    internal unsafe class VkBuffer : DeviceBuffer
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The device buffer
        /// </summary>
        private readonly Vulkan.VkBuffer _deviceBuffer;
        /// <summary>
        /// The memory
        /// </summary>
        private readonly VkMemoryBlock _memory;
        /// <summary>
        /// The buffer memory requirements
        /// </summary>
        private readonly VkMemoryRequirements _bufferMemoryRequirements;
        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Gets the value of the size in bytes
        /// </summary>
        public override uint SizeInBytes { get; }
        /// <summary>
        /// Gets the value of the usage
        /// </summary>
        public override BufferUsage Usage { get; }

        /// <summary>
        /// Gets the value of the device buffer
        /// </summary>
        public Vulkan.VkBuffer DeviceBuffer => _deviceBuffer;
        /// <summary>
        /// Gets the value of the memory
        /// </summary>
        public VkMemoryBlock Memory => _memory;

        /// <summary>
        /// Gets the value of the buffer memory requirements
        /// </summary>
        public VkMemoryRequirements BufferMemoryRequirements => _bufferMemoryRequirements;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkBuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <param name="usage">The usage</param>
        /// <param name="callerMember">The caller member</param>
        public VkBuffer(VkGraphicsDevice gd, uint sizeInBytes, BufferUsage usage, string callerMember = null)
        {
            _gd = gd;
            SizeInBytes = sizeInBytes;
            Usage = usage;

            VkBufferUsageFlags vkUsage = VkBufferUsageFlags.TransferSrc | VkBufferUsageFlags.TransferDst;
            if ((usage & BufferUsage.VertexBuffer) == BufferUsage.VertexBuffer)
            {
                vkUsage |= VkBufferUsageFlags.VertexBuffer;
            }
            if ((usage & BufferUsage.IndexBuffer) == BufferUsage.IndexBuffer)
            {
                vkUsage |= VkBufferUsageFlags.IndexBuffer;
            }
            if ((usage & BufferUsage.UniformBuffer) == BufferUsage.UniformBuffer)
            {
                vkUsage |= VkBufferUsageFlags.UniformBuffer;
            }
            if ((usage & BufferUsage.StructuredBufferReadWrite) == BufferUsage.StructuredBufferReadWrite
                || (usage & BufferUsage.StructuredBufferReadOnly) == BufferUsage.StructuredBufferReadOnly)
            {
                vkUsage |= VkBufferUsageFlags.StorageBuffer;
            }
            if ((usage & BufferUsage.IndirectBuffer) == BufferUsage.IndirectBuffer)
            {
                vkUsage |= VkBufferUsageFlags.IndirectBuffer;
            }

            VkBufferCreateInfo bufferCI = VkBufferCreateInfo.New();
            bufferCI.size = sizeInBytes;
            bufferCI.usage = vkUsage;
            VkResult result = vkCreateBuffer(gd.Device, ref bufferCI, null, out _deviceBuffer);
            CheckResult(result);

            bool prefersDedicatedAllocation;
            if (_gd.GetBufferMemoryRequirements2 != null)
            {
                VkBufferMemoryRequirementsInfo2KHR memReqInfo2 = VkBufferMemoryRequirementsInfo2KHR.New();
                memReqInfo2.buffer = _deviceBuffer;
                VkMemoryRequirements2KHR memReqs2 = VkMemoryRequirements2KHR.New();
                VkMemoryDedicatedRequirementsKHR dedicatedReqs = VkMemoryDedicatedRequirementsKHR.New();
                memReqs2.pNext = &dedicatedReqs;
                _gd.GetBufferMemoryRequirements2(_gd.Device, &memReqInfo2, &memReqs2);
                _bufferMemoryRequirements = memReqs2.memoryRequirements;
                prefersDedicatedAllocation = dedicatedReqs.prefersDedicatedAllocation || dedicatedReqs.requiresDedicatedAllocation;
            }
            else
            {
                vkGetBufferMemoryRequirements(gd.Device, _deviceBuffer, out _bufferMemoryRequirements);
                prefersDedicatedAllocation = false;
            }

            var isStaging = (usage & BufferUsage.Staging) == BufferUsage.Staging;
            var hostVisible = isStaging || (usage & BufferUsage.Dynamic) == BufferUsage.Dynamic;

            VkMemoryPropertyFlags memoryPropertyFlags =
                hostVisible
                ? VkMemoryPropertyFlags.HostVisible | VkMemoryPropertyFlags.HostCoherent
                : VkMemoryPropertyFlags.DeviceLocal;
            if (isStaging)
            {
                // Use "host cached" memory for staging when available, for better performance of GPU -> CPU transfers
                var hostCachedAvailable = TryFindMemoryType(
                    gd.PhysicalDeviceMemProperties,
                    _bufferMemoryRequirements.memoryTypeBits,
                    memoryPropertyFlags | VkMemoryPropertyFlags.HostCached,
                    out _);
                if (hostCachedAvailable)
                {
                    memoryPropertyFlags |= VkMemoryPropertyFlags.HostCached;
                }
            }

            VkMemoryBlock memoryToken = gd.MemoryManager.Allocate(
                gd.PhysicalDeviceMemProperties,
                _bufferMemoryRequirements.memoryTypeBits,
                memoryPropertyFlags,
                hostVisible,
                _bufferMemoryRequirements.size,
                _bufferMemoryRequirements.alignment,
                prefersDedicatedAllocation,
                VkImage.Null,
                _deviceBuffer);
            _memory = memoryToken;
            result = vkBindBufferMemory(gd.Device, _deviceBuffer, _memory.DeviceMemory, _memory.Offset);
            CheckResult(result);

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
                vkDestroyBuffer(_gd.Device, _deviceBuffer, null);
                _gd.MemoryManager.Free(Memory);
            }
        }
    }
}
