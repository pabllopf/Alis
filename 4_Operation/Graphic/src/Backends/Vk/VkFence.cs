using Vulkan;
using static Vulkan.VulkanNative;

namespace Veldrid.Vk
{
    /// <summary>
    /// The vk fence class
    /// </summary>
    /// <seealso cref="Fence"/>
    internal unsafe class VkFence : Fence
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The fence
        /// </summary>
        private Vulkan.VkFence _fence;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The destroyed
        /// </summary>
        private bool _destroyed;

        /// <summary>
        /// Gets the value of the device fence
        /// </summary>
        public Vulkan.VkFence DeviceFence => _fence;

        /// <summary>
        /// Initializes a new instance of the <see cref="VkFence"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="signaled">The signaled</param>
        public VkFence(VkGraphicsDevice gd, bool signaled)
        {
            _gd = gd;
            VkFenceCreateInfo fenceCI = VkFenceCreateInfo.New();
            fenceCI.flags = signaled ? VkFenceCreateFlags.Signaled : VkFenceCreateFlags.None;
            VkResult result = vkCreateFence(_gd.Device, ref fenceCI, null, out _fence);
            VulkanUtil.CheckResult(result);
        }

        /// <summary>
        /// Resets this instance
        /// </summary>
        public override void Reset()
        {
            _gd.ResetFence(this);
        }

        /// <summary>
        /// Gets the value of the signaled
        /// </summary>
        public override bool Signaled => vkGetFenceStatus(_gd.Device, _fence) == VkResult.Success;
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _destroyed;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                _name = value; _gd.SetResourceName(this, value);
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_destroyed)
            {
                vkDestroyFence(_gd.Device, _fence, null);
                _destroyed = true;
            }
        }
    }
}
