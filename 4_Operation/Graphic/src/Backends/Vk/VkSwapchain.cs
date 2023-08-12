using System;
using System.Linq;
using Vulkan;
using static Vulkan.VulkanNative;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk swapchain class
    /// </summary>
    /// <seealso cref="Swapchain"/>
    internal unsafe class VkSwapchain : Swapchain
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly VkGraphicsDevice _gd;
        /// <summary>
        /// The surface
        /// </summary>
        private readonly VkSurfaceKHR _surface;
        /// <summary>
        /// The device swapchain
        /// </summary>
        private VkSwapchainKHR _deviceSwapchain;
        /// <summary>
        /// The framebuffer
        /// </summary>
        private readonly VkSwapchainFramebuffer _framebuffer;
        /// <summary>
        /// The image available fence
        /// </summary>
        private Vulkan.VkFence _imageAvailableFence;
        /// <summary>
        /// The present queue index
        /// </summary>
        private readonly uint _presentQueueIndex;
        /// <summary>
        /// The present queue
        /// </summary>
        private readonly VkQueue _presentQueue;
        /// <summary>
        /// The sync to blank
        /// </summary>
        private bool _syncToVBlank;
        /// <summary>
        /// The swapchain source
        /// </summary>
        private readonly SwapchainSource _swapchainSource;
        /// <summary>
        /// The color srgb
        /// </summary>
        private readonly bool _colorSrgb;
        /// <summary>
        /// The new sync to blank
        /// </summary>
        private bool? _newSyncToVBlank;
        /// <summary>
        /// The current image index
        /// </summary>
        private uint _currentImageIndex;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get => _name; set { _name = value; _gd.SetResourceName(this, value); } }
        /// <summary>
        /// Gets the value of the framebuffer
        /// </summary>
        public override Framebuffer Framebuffer => _framebuffer;
        /// <summary>
        /// Gets or sets the value of the sync to vertical blank
        /// </summary>
        public override bool SyncToVerticalBlank
        {
            get => _newSyncToVBlank ?? _syncToVBlank;
            set
            {
                if (_syncToVBlank != value)
                {
                    _newSyncToVBlank = value;
                }
            }
        }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Gets the value of the device swapchain
        /// </summary>
        public VkSwapchainKHR DeviceSwapchain => _deviceSwapchain;
        /// <summary>
        /// Gets the value of the image index
        /// </summary>
        public uint ImageIndex => _currentImageIndex;
        /// <summary>
        /// Gets the value of the image available fence
        /// </summary>
        public Vulkan.VkFence ImageAvailableFence => _imageAvailableFence;
        /// <summary>
        /// Gets the value of the surface
        /// </summary>
        public VkSurfaceKHR Surface => _surface;
        /// <summary>
        /// Gets the value of the present queue
        /// </summary>
        public VkQueue PresentQueue => _presentQueue;
        /// <summary>
        /// Gets the value of the present queue index
        /// </summary>
        public uint PresentQueueIndex => _presentQueueIndex;
        /// <summary>
        /// Gets the value of the ref count
        /// </summary>
        public ResourceRefCount RefCount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkSwapchain"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public VkSwapchain(VkGraphicsDevice gd, ref SwapchainDescription description) : this(gd, ref description, VkSurfaceKHR.Null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkSwapchain"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        /// <param name="existingSurface">The existing surface</param>
        /// <exception cref="VeldridException">The system does not support presenting the given Vulkan surface.</exception>
        public VkSwapchain(VkGraphicsDevice gd, ref SwapchainDescription description, VkSurfaceKHR existingSurface)
        {
            _gd = gd;
            _syncToVBlank = description.SyncToVerticalBlank;
            _swapchainSource = description.Source;
            _colorSrgb = description.ColorSrgb;

            if (existingSurface == VkSurfaceKHR.Null)
            {
                _surface = VkSurfaceUtil.CreateSurface(gd, gd.Instance, _swapchainSource);
            }
            else
            {
                _surface = existingSurface;
            }

            if (!GetPresentQueueIndex(out _presentQueueIndex))
            {
                throw new VeldridException($"The system does not support presenting the given Vulkan surface.");
            }
            vkGetDeviceQueue(_gd.Device, _presentQueueIndex, 0, out _presentQueue);

            _framebuffer = new VkSwapchainFramebuffer(gd, this, _surface, description.Width, description.Height, description.DepthFormat);

            CreateSwapchain(description.Width, description.Height);

            VkFenceCreateInfo fenceCI = VkFenceCreateInfo.New();
            fenceCI.flags = VkFenceCreateFlags.None;
            vkCreateFence(_gd.Device, ref fenceCI, null, out _imageAvailableFence);

            AcquireNextImage(_gd.Device, VkSemaphore.Null, _imageAvailableFence);
            vkWaitForFences(_gd.Device, 1, ref _imageAvailableFence, true, ulong.MaxValue);
            vkResetFences(_gd.Device, 1, ref _imageAvailableFence);

            RefCount = new ResourceRefCount(DisposeCore);
        }

        /// <summary>
        /// Resizes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public override void Resize(uint width, uint height)
        {
            RecreateAndReacquire(width, height);
        }

        /// <summary>
        /// Describes whether this instance acquire next image
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="semaphore">The semaphore</param>
        /// <param name="fence">The fence</param>
        /// <exception cref="VeldridException">Could not acquire next image from the Vulkan swapchain.</exception>
        /// <returns>The bool</returns>
        public bool AcquireNextImage(VkDevice device, VkSemaphore semaphore, Vulkan.VkFence fence)
        {
            if (_newSyncToVBlank != null)
            {
                _syncToVBlank = _newSyncToVBlank.Value;
                _newSyncToVBlank = null;
                RecreateAndReacquire(_framebuffer.Width, _framebuffer.Height);
                return false;
            }

            VkResult result = vkAcquireNextImageKHR(
                device,
                _deviceSwapchain,
                ulong.MaxValue,
                semaphore,
                fence,
                ref _currentImageIndex);
            _framebuffer.SetImageIndex(_currentImageIndex);
            if (result == VkResult.ErrorOutOfDateKHR || result == VkResult.SuboptimalKHR)
            {
                CreateSwapchain(_framebuffer.Width, _framebuffer.Height);
                return false;
            }
            else if (result != VkResult.Success)
            {
                throw new VeldridException("Could not acquire next image from the Vulkan swapchain.");
            }

            return true;
        }

        /// <summary>
        /// Recreates the and reacquire using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void RecreateAndReacquire(uint width, uint height)
        {
            if (CreateSwapchain(width, height))
            {
                if (AcquireNextImage(_gd.Device, VkSemaphore.Null, _imageAvailableFence))
                {
                    vkWaitForFences(_gd.Device, 1, ref _imageAvailableFence, true, ulong.MaxValue);
                    vkResetFences(_gd.Device, 1, ref _imageAvailableFence);
                }
            }
        }

        /// <summary>
        /// Describes whether this instance create swapchain
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <exception cref="VeldridException">The Swapchain's underlying surface has been lost.</exception>
        /// <exception cref="VeldridException">Unable to create an sRGB Swapchain for this surface.</exception>
        /// <returns>The bool</returns>
        private bool CreateSwapchain(uint width, uint height)
        {
            // Obtain the surface capabilities first -- this will indicate whether the surface has been lost.
            VkResult result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(_gd.PhysicalDevice, _surface, out VkSurfaceCapabilitiesKHR surfaceCapabilities);
            if (result == VkResult.ErrorSurfaceLostKHR)
            {
                throw new VeldridException($"The Swapchain's underlying surface has been lost.");
            }

            if (surfaceCapabilities.minImageExtent.width == 0 && surfaceCapabilities.minImageExtent.height == 0
                && surfaceCapabilities.maxImageExtent.width == 0 && surfaceCapabilities.maxImageExtent.height == 0)
            {
                return false;
            }

            if (_deviceSwapchain != VkSwapchainKHR.Null)
            {
                _gd.WaitForIdle();
            }

            _currentImageIndex = 0;
            uint surfaceFormatCount = 0;
            result = vkGetPhysicalDeviceSurfaceFormatsKHR(_gd.PhysicalDevice, _surface, ref surfaceFormatCount, null);
            CheckResult(result);
            VkSurfaceFormatKHR[] formats = new VkSurfaceFormatKHR[surfaceFormatCount];
            result = vkGetPhysicalDeviceSurfaceFormatsKHR(_gd.PhysicalDevice, _surface, ref surfaceFormatCount, out formats[0]);
            CheckResult(result);

            VkFormat desiredFormat = _colorSrgb
                ? VkFormat.B8g8r8a8Srgb
                : VkFormat.B8g8r8a8Unorm;

            VkSurfaceFormatKHR surfaceFormat = new VkSurfaceFormatKHR();
            if (formats.Length == 1 && formats[0].format == VkFormat.Undefined)
            {
                surfaceFormat = new VkSurfaceFormatKHR { colorSpace = VkColorSpaceKHR.SrgbNonlinearKHR, format = desiredFormat };
            }
            else
            {
                foreach (VkSurfaceFormatKHR format in formats)
                {
                    if (format.colorSpace == VkColorSpaceKHR.SrgbNonlinearKHR && format.format == desiredFormat)
                    {
                        surfaceFormat = format;
                        break;
                    }
                }
                if (surfaceFormat.format == VkFormat.Undefined)
                {
                    if (_colorSrgb && surfaceFormat.format != VkFormat.R8g8b8a8Srgb)
                    {
                        throw new VeldridException($"Unable to create an sRGB Swapchain for this surface.");
                    }

                    surfaceFormat = formats[0];
                }
            }

            uint presentModeCount = 0;
            result = vkGetPhysicalDeviceSurfacePresentModesKHR(_gd.PhysicalDevice, _surface, ref presentModeCount, null);
            CheckResult(result);
            VkPresentModeKHR[] presentModes = new VkPresentModeKHR[presentModeCount];
            result = vkGetPhysicalDeviceSurfacePresentModesKHR(_gd.PhysicalDevice, _surface, ref presentModeCount, out presentModes[0]);
            CheckResult(result);

            VkPresentModeKHR presentMode = VkPresentModeKHR.FifoKHR;

            if (_syncToVBlank)
            {
                if (presentModes.Contains(VkPresentModeKHR.FifoRelaxedKHR))
                {
                    presentMode = VkPresentModeKHR.FifoRelaxedKHR;
                }
            }
            else
            {
                if (presentModes.Contains(VkPresentModeKHR.MailboxKHR))
                {
                    presentMode = VkPresentModeKHR.MailboxKHR;
                }
                else if (presentModes.Contains(VkPresentModeKHR.ImmediateKHR))
                {
                    presentMode = VkPresentModeKHR.ImmediateKHR;
                }
            }

            uint maxImageCount = surfaceCapabilities.maxImageCount == 0 ? uint.MaxValue : surfaceCapabilities.maxImageCount;
            uint imageCount = Math.Min(maxImageCount, surfaceCapabilities.minImageCount + 1);

            VkSwapchainCreateInfoKHR swapchainCI = VkSwapchainCreateInfoKHR.New();
            swapchainCI.surface = _surface;
            swapchainCI.presentMode = presentMode;
            swapchainCI.imageFormat = surfaceFormat.format;
            swapchainCI.imageColorSpace = surfaceFormat.colorSpace;
            uint clampedWidth = Util.Clamp(width, surfaceCapabilities.minImageExtent.width, surfaceCapabilities.maxImageExtent.width);
            uint clampedHeight = Util.Clamp(height, surfaceCapabilities.minImageExtent.height, surfaceCapabilities.maxImageExtent.height);
            swapchainCI.imageExtent = new VkExtent2D { width = clampedWidth, height = clampedHeight };
            swapchainCI.minImageCount = imageCount;
            swapchainCI.imageArrayLayers = 1;
            swapchainCI.imageUsage = VkImageUsageFlags.ColorAttachment | VkImageUsageFlags.TransferDst;

            FixedArray2<uint> queueFamilyIndices = new FixedArray2<uint>(_gd.GraphicsQueueIndex, _gd.PresentQueueIndex);

            if (_gd.GraphicsQueueIndex != _gd.PresentQueueIndex)
            {
                swapchainCI.imageSharingMode = VkSharingMode.Concurrent;
                swapchainCI.queueFamilyIndexCount = 2;
                swapchainCI.pQueueFamilyIndices = &queueFamilyIndices.First;
            }
            else
            {
                swapchainCI.imageSharingMode = VkSharingMode.Exclusive;
                swapchainCI.queueFamilyIndexCount = 0;
            }

            swapchainCI.preTransform = VkSurfaceTransformFlagsKHR.IdentityKHR;
            swapchainCI.compositeAlpha = VkCompositeAlphaFlagsKHR.OpaqueKHR;
            swapchainCI.clipped = true;

            VkSwapchainKHR oldSwapchain = _deviceSwapchain;
            swapchainCI.oldSwapchain = oldSwapchain;

            result = vkCreateSwapchainKHR(_gd.Device, ref swapchainCI, null, out _deviceSwapchain);
            CheckResult(result);
            if (oldSwapchain != VkSwapchainKHR.Null)
            {
                vkDestroySwapchainKHR(_gd.Device, oldSwapchain, null);
            }

            _framebuffer.SetNewSwapchain(_deviceSwapchain, width, height, surfaceFormat, swapchainCI.imageExtent);
            return true;
        }

        /// <summary>
        /// Describes whether this instance get present queue index
        /// </summary>
        /// <param name="queueFamilyIndex">The queue family index</param>
        /// <returns>The bool</returns>
        private bool GetPresentQueueIndex(out uint queueFamilyIndex)
        {
            uint graphicsQueueIndex = _gd.GraphicsQueueIndex;
            uint presentQueueIndex = _gd.PresentQueueIndex;

            if (QueueSupportsPresent(graphicsQueueIndex, _surface))
            {
                queueFamilyIndex = graphicsQueueIndex;
                return true;
            }
            else if (graphicsQueueIndex != presentQueueIndex && QueueSupportsPresent(presentQueueIndex, _surface))
            {
                queueFamilyIndex = presentQueueIndex;
                return true;
            }

            queueFamilyIndex = 0;
            return false;
        }

        /// <summary>
        /// Describes whether this instance queue supports present
        /// </summary>
        /// <param name="queueFamilyIndex">The queue family index</param>
        /// <param name="surface">The surface</param>
        /// <returns>The supported</returns>
        private bool QueueSupportsPresent(uint queueFamilyIndex, VkSurfaceKHR surface)
        {
            VkResult result = vkGetPhysicalDeviceSurfaceSupportKHR(
                _gd.PhysicalDevice,
                queueFamilyIndex,
                surface,
                out VkBool32 supported);
            CheckResult(result);
            return supported;
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
            vkDestroyFence(_gd.Device, _imageAvailableFence, null);
            _framebuffer.Dispose();
            vkDestroySwapchainKHR(_gd.Device, _deviceSwapchain, null);
            vkDestroySurfaceKHR(_gd.Instance, _surface, null);

            _disposed = true;
        }
    }
}
