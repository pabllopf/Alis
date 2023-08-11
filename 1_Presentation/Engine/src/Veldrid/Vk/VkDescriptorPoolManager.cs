using System;
using System.Collections.Generic;
using System.Diagnostics;
using Vulkan;
using static Vulkan.VulkanNative;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vk descriptor pool manager class
    /// </summary>
    internal class VkDescriptorPoolManager
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The pool info
        /// </summary>
        private readonly List<PoolInfo> _pools = new List<PoolInfo>();
        /// <summary>
        /// The lock
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="VkDescriptorPoolManager"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        public VkDescriptorPoolManager(VkGraphicsDevice gd)
        {
            _gd = gd;
            _pools.Add(CreateNewPool());
        }

        /// <summary>
        /// Allocates the counts
        /// </summary>
        /// <param name="counts">The counts</param>
        /// <param name="setLayout">The set layout</param>
        /// <returns>The descriptor allocation token</returns>
        public unsafe DescriptorAllocationToken Allocate(DescriptorResourceCounts counts, VkDescriptorSetLayout setLayout)
        {
            lock (_lock)
            {
                VkDescriptorPool pool = GetPool(counts);
                VkDescriptorSetAllocateInfo dsAI = VkDescriptorSetAllocateInfo.New();
                dsAI.descriptorSetCount = 1;
                dsAI.pSetLayouts = &setLayout;
                dsAI.descriptorPool = pool;
                VkResult result = vkAllocateDescriptorSets(_gd.Device, ref dsAI, out VkDescriptorSet set);
                VulkanUtil.CheckResult(result);

                return new DescriptorAllocationToken(set, pool);
            }
        }

        /// <summary>
        /// Frees the token
        /// </summary>
        /// <param name="token">The token</param>
        /// <param name="counts">The counts</param>
        public void Free(DescriptorAllocationToken token, DescriptorResourceCounts counts)
        {
            lock (_lock)
            {
                foreach (PoolInfo poolInfo in _pools)
                {
                    if (poolInfo.Pool == token.Pool)
                    {
                        poolInfo.Free(_gd.Device, token, counts);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the pool using the specified counts
        /// </summary>
        /// <param name="counts">The counts</param>
        /// <returns>The vk descriptor pool</returns>
        private VkDescriptorPool GetPool(DescriptorResourceCounts counts)
        {
            lock (_lock)
            {
                foreach (PoolInfo poolInfo in _pools)
                {
                    if (poolInfo.Allocate(counts))
                    {
                        return poolInfo.Pool;
                    }
                }

                PoolInfo newPool = CreateNewPool();
                _pools.Add(newPool);
                bool result = newPool.Allocate(counts);
                Debug.Assert(result);
                return newPool.Pool;
            }
        }

        /// <summary>
        /// Creates the new pool
        /// </summary>
        /// <returns>The pool info</returns>
        private unsafe PoolInfo CreateNewPool()
        {
            uint totalSets = 1000;
            uint descriptorCount = 100;
            uint poolSizeCount = 7;
            VkDescriptorPoolSize* sizes = stackalloc VkDescriptorPoolSize[(int)poolSizeCount];
            sizes[0].type = VkDescriptorType.UniformBuffer;
            sizes[0].descriptorCount = descriptorCount;
            sizes[1].type = VkDescriptorType.SampledImage;
            sizes[1].descriptorCount = descriptorCount;
            sizes[2].type = VkDescriptorType.Sampler;
            sizes[2].descriptorCount = descriptorCount;
            sizes[3].type = VkDescriptorType.StorageBuffer;
            sizes[3].descriptorCount = descriptorCount;
            sizes[4].type = VkDescriptorType.StorageImage;
            sizes[4].descriptorCount = descriptorCount;
            sizes[5].type = VkDescriptorType.UniformBufferDynamic;
            sizes[5].descriptorCount = descriptorCount;
            sizes[6].type = VkDescriptorType.StorageBufferDynamic;
            sizes[6].descriptorCount = descriptorCount;

            VkDescriptorPoolCreateInfo poolCI = VkDescriptorPoolCreateInfo.New();
            poolCI.flags = VkDescriptorPoolCreateFlags.FreeDescriptorSet;
            poolCI.maxSets = totalSets;
            poolCI.pPoolSizes = sizes;
            poolCI.poolSizeCount = poolSizeCount;

            VkResult result = vkCreateDescriptorPool(_gd.Device, ref poolCI, null, out VkDescriptorPool descriptorPool);
            VulkanUtil.CheckResult(result);

            return new PoolInfo(descriptorPool, totalSets, descriptorCount);
        }

        /// <summary>
        /// Destroys the all
        /// </summary>
        internal unsafe void DestroyAll()
        {
            foreach (PoolInfo poolInfo in _pools)
            {
                vkDestroyDescriptorPool(_gd.Device, poolInfo.Pool, null);
            }
        }

        /// <summary>
        /// The pool info class
        /// </summary>
        private class PoolInfo
        {
            /// <summary>
            /// The pool
            /// </summary>
            public readonly VkDescriptorPool Pool;

            /// <summary>
            /// The remaining sets
            /// </summary>
            public uint RemainingSets;

            /// <summary>
            /// The uniform buffer count
            /// </summary>
            public uint UniformBufferCount;
            /// <summary>
            /// The uniform buffer dynamic count
            /// </summary>
            public uint UniformBufferDynamicCount;
            /// <summary>
            /// The sampled image count
            /// </summary>
            public uint SampledImageCount;
            /// <summary>
            /// The sampler count
            /// </summary>
            public uint SamplerCount;
            /// <summary>
            /// The storage buffer count
            /// </summary>
            public uint StorageBufferCount;
            /// <summary>
            /// The storage buffer dynamic count
            /// </summary>
            public uint StorageBufferDynamicCount;
            /// <summary>
            /// The storage image count
            /// </summary>
            public uint StorageImageCount;

            /// <summary>
            /// Initializes a new instance of the <see cref="PoolInfo"/> class
            /// </summary>
            /// <param name="pool">The pool</param>
            /// <param name="totalSets">The total sets</param>
            /// <param name="descriptorCount">The descriptor count</param>
            public PoolInfo(VkDescriptorPool pool, uint totalSets, uint descriptorCount)
            {
                Pool = pool;
                RemainingSets = totalSets;
                UniformBufferCount = descriptorCount;
                UniformBufferDynamicCount = descriptorCount;
                SampledImageCount = descriptorCount;
                SamplerCount = descriptorCount;
                StorageBufferCount = descriptorCount;
                StorageBufferDynamicCount = descriptorCount;
                StorageImageCount = descriptorCount;
            }

            /// <summary>
            /// Describes whether this instance allocate
            /// </summary>
            /// <param name="counts">The counts</param>
            /// <returns>The bool</returns>
            internal bool Allocate(DescriptorResourceCounts counts)
            {
                if (RemainingSets > 0
                    && UniformBufferCount >= counts.UniformBufferCount
                    && UniformBufferDynamicCount >= counts.UniformBufferDynamicCount
                    && SampledImageCount >= counts.SampledImageCount
                    && SamplerCount >= counts.SamplerCount
                    && StorageBufferCount >= counts.SamplerCount
                    && StorageBufferDynamicCount >= counts.StorageBufferDynamicCount
                    && StorageImageCount >= counts.StorageImageCount)
                {
                    RemainingSets -= 1;
                    UniformBufferCount -= counts.UniformBufferCount;
                    UniformBufferDynamicCount -= counts.UniformBufferDynamicCount;
                    SampledImageCount -= counts.SampledImageCount;
                    SamplerCount -= counts.SamplerCount;
                    StorageBufferCount -= counts.StorageBufferCount;
                    StorageBufferDynamicCount -= counts.StorageBufferDynamicCount;
                    StorageImageCount -= counts.StorageImageCount;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Frees the device
            /// </summary>
            /// <param name="device">The device</param>
            /// <param name="token">The token</param>
            /// <param name="counts">The counts</param>
            internal void Free(VkDevice device, DescriptorAllocationToken token, DescriptorResourceCounts counts)
            {
                VkDescriptorSet set = token.Set;
                vkFreeDescriptorSets(device, Pool, 1, ref set);

                RemainingSets += 1;

                UniformBufferCount += counts.UniformBufferCount;
                SampledImageCount += counts.SampledImageCount;
                SamplerCount += counts.SamplerCount;
                StorageBufferCount += counts.StorageBufferCount;
                StorageImageCount += counts.StorageImageCount;
            }
        }
    }

    /// <summary>
    /// The descriptor allocation token
    /// </summary>
    internal struct DescriptorAllocationToken
    {
        /// <summary>
        /// The set
        /// </summary>
        public readonly VkDescriptorSet Set;
        /// <summary>
        /// The pool
        /// </summary>
        public readonly VkDescriptorPool Pool;

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptorAllocationToken"/> class
        /// </summary>
        /// <param name="set">The set</param>
        /// <param name="pool">The pool</param>
        public DescriptorAllocationToken(VkDescriptorSet set, VkDescriptorPool pool)
        {
            Set = set;
            Pool = pool;
        }
    }
}
