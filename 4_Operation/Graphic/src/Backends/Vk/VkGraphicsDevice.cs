using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Vulkan;
using static Alis.Core.Graphic.Backends.Vk.VulkanUtil;
using static Vulkan.VulkanNative;

namespace Alis.Core.Graphic.Backends.Vk
{
    /// <summary>
    /// The vk graphics device class
    /// </summary>
    /// <seealso cref="GraphicsDevice"/>
    internal unsafe class VkGraphicsDevice : GraphicsDevice
    {
        /// <summary>
        /// The name
        /// </summary>
        private static readonly FixedUtf8String s_name = "Veldrid-VkGraphicsDevice";
        /// <summary>
        /// The is thread safe
        /// </summary>
        private static readonly Lazy<bool> s_isSupported = new Lazy<bool>(CheckIsSupported, isThreadSafe: true);

        /// <summary>
        /// The instance
        /// </summary>
        private VkInstance _instance;
        /// <summary>
        /// The physical device
        /// </summary>
        private VkPhysicalDevice _physicalDevice;
        /// <summary>
        /// The device name
        /// </summary>
        private string _deviceName;
        /// <summary>
        /// The vendor name
        /// </summary>
        private string _vendorName;
        /// <summary>
        /// The api version
        /// </summary>
        private GraphicsApiVersion _apiVersion;
        /// <summary>
        /// The driver name
        /// </summary>
        private string _driverName;
        /// <summary>
        /// The driver info
        /// </summary>
        private string _driverInfo;
        /// <summary>
        /// The memory manager
        /// </summary>
        private VkDeviceMemoryManager _memoryManager;
        /// <summary>
        /// The physical device properties
        /// </summary>
        private VkPhysicalDeviceProperties _physicalDeviceProperties;
        /// <summary>
        /// The physical device features
        /// </summary>
        private VkPhysicalDeviceFeatures _physicalDeviceFeatures;
        /// <summary>
        /// The physical device mem properties
        /// </summary>
        private VkPhysicalDeviceMemoryProperties _physicalDeviceMemProperties;
        /// <summary>
        /// The device
        /// </summary>
        private VkDevice _device;
        /// <summary>
        /// The graphics queue index
        /// </summary>
        private uint _graphicsQueueIndex;
        /// <summary>
        /// The present queue index
        /// </summary>
        private uint _presentQueueIndex;
        /// <summary>
        /// The graphics command pool
        /// </summary>
        private VkCommandPool _graphicsCommandPool;
        /// <summary>
        /// The graphics command pool lock
        /// </summary>
        private readonly object _graphicsCommandPoolLock = new object();
        /// <summary>
        /// The graphics queue
        /// </summary>
        private VkQueue _graphicsQueue;
        /// <summary>
        /// The graphics queue lock
        /// </summary>
        private readonly object _graphicsQueueLock = new object();
        /// <summary>
        /// The debug callback handle
        /// </summary>
        private VkDebugReportCallbackEXT _debugCallbackHandle;
        /// <summary>
        /// The debug callback func
        /// </summary>
        private PFN_vkDebugReportCallbackEXT _debugCallbackFunc;
        /// <summary>
        /// The debug marker enabled
        /// </summary>
        private bool _debugMarkerEnabled;
        /// <summary>
        /// The set object name delegate
        /// </summary>
        private vkDebugMarkerSetObjectNameEXT_t _setObjectNameDelegate;
        /// <summary>
        /// The marker begin
        /// </summary>
        private vkCmdDebugMarkerBeginEXT_t _markerBegin;
        /// <summary>
        /// The marker end
        /// </summary>
        private vkCmdDebugMarkerEndEXT_t _markerEnd;
        /// <summary>
        /// The marker insert
        /// </summary>
        private vkCmdDebugMarkerInsertEXT_t _markerInsert;
        /// <summary>
        /// The vk filter
        /// </summary>
        private readonly ConcurrentDictionary<VkFormat, VkFilter> _filters = new ConcurrentDictionary<VkFormat, VkFilter>();
        /// <summary>
        /// The vulkan info
        /// </summary>
        private readonly BackendInfoVulkan _vulkanInfo;

        /// <summary>
        /// The shared command pool count
        /// </summary>
        private const int SharedCommandPoolCount = 4;
        /// <summary>
        /// The shared command pool
        /// </summary>
        private Stack<SharedCommandPool> _sharedGraphicsCommandPools = new Stack<SharedCommandPool>();
        /// <summary>
        /// The descriptor pool manager
        /// </summary>
        private VkDescriptorPoolManager _descriptorPoolManager;
        /// <summary>
        /// The standard validation supported
        /// </summary>
        private bool _standardValidationSupported;
        /// <summary>
        /// The khronos validation supported
        /// </summary>
        private bool _khronosValidationSupported;
        /// <summary>
        /// The standard clip direction
        /// </summary>
        private bool _standardClipYDirection;
        /// <summary>
        /// The get buffer memory requirements
        /// </summary>
        private vkGetBufferMemoryRequirements2_t _getBufferMemoryRequirements2;
        /// <summary>
        /// The get image memory requirements
        /// </summary>
        private vkGetImageMemoryRequirements2_t _getImageMemoryRequirements2;
        /// <summary>
        /// The get physical device properties
        /// </summary>
        private vkGetPhysicalDeviceProperties2_t _getPhysicalDeviceProperties2;
        /// <summary>
        /// The create metal surface ext
        /// </summary>
        private vkCreateMetalSurfaceEXT_t _createMetalSurfaceEXT;

        // Staging Resources
        /// <summary>
        /// The min staging buffer size
        /// </summary>
        private const uint MinStagingBufferSize = 64;
        /// <summary>
        /// The max staging buffer size
        /// </summary>
        private const uint MaxStagingBufferSize = 512;

        /// <summary>
        /// The staging resources lock
        /// </summary>
        private readonly object _stagingResourcesLock = new object();
        /// <summary>
        /// The vk texture
        /// </summary>
        private readonly List<VkTexture> _availableStagingTextures = new List<VkTexture>();
        /// <summary>
        /// The vk buffer
        /// </summary>
        private readonly List<VkBuffer> _availableStagingBuffers = new List<VkBuffer>();

        /// <summary>
        /// The vk texture
        /// </summary>
        private readonly Dictionary<VkCommandBuffer, VkTexture> _submittedStagingTextures
            = new Dictionary<VkCommandBuffer, VkTexture>();
        /// <summary>
        /// The vk buffer
        /// </summary>
        private readonly Dictionary<VkCommandBuffer, VkBuffer> _submittedStagingBuffers
            = new Dictionary<VkCommandBuffer, VkBuffer>();
        /// <summary>
        /// The shared command pool
        /// </summary>
        private readonly Dictionary<VkCommandBuffer, SharedCommandPool> _submittedSharedCommandPools
            = new Dictionary<VkCommandBuffer, SharedCommandPool>();

        /// <summary>
        /// Gets the value of the device name
        /// </summary>
        public override string DeviceName => _deviceName;

        /// <summary>
        /// Gets the value of the vendor name
        /// </summary>
        public override string VendorName => _vendorName;

        /// <summary>
        /// Gets the value of the api version
        /// </summary>
        public override GraphicsApiVersion ApiVersion => _apiVersion;

        /// <summary>
        /// Gets the value of the backend type
        /// </summary>
        public override GraphicsBackend BackendType => GraphicsBackend.Vulkan;

        /// <summary>
        /// Gets the value of the is uv origin top left
        /// </summary>
        public override bool IsUvOriginTopLeft => true;

        /// <summary>
        /// Gets the value of the is depth range zero to one
        /// </summary>
        public override bool IsDepthRangeZeroToOne => true;

        /// <summary>
        /// Gets the value of the is clip space y inverted
        /// </summary>
        public override bool IsClipSpaceYInverted => !_standardClipYDirection;

        /// <summary>
        /// Gets the value of the main swapchain
        /// </summary>
        public override Swapchain MainSwapchain => _mainSwapchain;

        /// <summary>
        /// Gets the value of the features
        /// </summary>
        public override GraphicsDeviceFeatures Features { get; }

        /// <summary>
        /// Describes whether this instance get vulkan info
        /// </summary>
        /// <param name="info">The info</param>
        /// <returns>The bool</returns>
        public override bool GetVulkanInfo(out BackendInfoVulkan info)
        {
            info = _vulkanInfo;
            return true;
        }

        /// <summary>
        /// Gets the value of the instance
        /// </summary>
        public VkInstance Instance => _instance;
        /// <summary>
        /// Gets the value of the device
        /// </summary>
        public VkDevice Device => _device;
        /// <summary>
        /// Gets the value of the physical device
        /// </summary>
        public VkPhysicalDevice PhysicalDevice => _physicalDevice;
        /// <summary>
        /// Gets the value of the physical device mem properties
        /// </summary>
        public VkPhysicalDeviceMemoryProperties PhysicalDeviceMemProperties => _physicalDeviceMemProperties;
        /// <summary>
        /// Gets the value of the graphics queue
        /// </summary>
        public VkQueue GraphicsQueue => _graphicsQueue;
        /// <summary>
        /// Gets the value of the graphics queue index
        /// </summary>
        public uint GraphicsQueueIndex => _graphicsQueueIndex;
        /// <summary>
        /// Gets the value of the present queue index
        /// </summary>
        public uint PresentQueueIndex => _presentQueueIndex;
        /// <summary>
        /// Gets the value of the driver name
        /// </summary>
        public string DriverName => _driverName;
        /// <summary>
        /// Gets the value of the driver info
        /// </summary>
        public string DriverInfo => _driverInfo;
        /// <summary>
        /// Gets the value of the memory manager
        /// </summary>
        public VkDeviceMemoryManager MemoryManager => _memoryManager;
        /// <summary>
        /// Gets the value of the descriptor pool manager
        /// </summary>
        public VkDescriptorPoolManager DescriptorPoolManager => _descriptorPoolManager;
        /// <summary>
        /// Gets the value of the marker begin
        /// </summary>
        public vkCmdDebugMarkerBeginEXT_t MarkerBegin => _markerBegin;
        /// <summary>
        /// Gets the value of the marker end
        /// </summary>
        public vkCmdDebugMarkerEndEXT_t MarkerEnd => _markerEnd;
        /// <summary>
        /// Gets the value of the marker insert
        /// </summary>
        public vkCmdDebugMarkerInsertEXT_t MarkerInsert => _markerInsert;
        /// <summary>
        /// Gets the value of the get buffer memory requirements 2
        /// </summary>
        public vkGetBufferMemoryRequirements2_t GetBufferMemoryRequirements2 => _getBufferMemoryRequirements2;
        /// <summary>
        /// Gets the value of the get image memory requirements 2
        /// </summary>
        public vkGetImageMemoryRequirements2_t GetImageMemoryRequirements2 => _getImageMemoryRequirements2;
        /// <summary>
        /// Gets the value of the create metal surface ext
        /// </summary>
        public vkCreateMetalSurfaceEXT_t CreateMetalSurfaceEXT => _createMetalSurfaceEXT;

        /// <summary>
        /// The submitted fences lock
        /// </summary>
        private readonly object _submittedFencesLock = new object();
        /// <summary>
        /// The vk fence
        /// </summary>
        private readonly ConcurrentQueue<Vulkan.VkFence> _availableSubmissionFences = new ConcurrentQueue<Vulkan.VkFence>();
        /// <summary>
        /// The fence submission info
        /// </summary>
        private readonly List<FenceSubmissionInfo> _submittedFences = new List<FenceSubmissionInfo>();
        /// <summary>
        /// The main swapchain
        /// </summary>
        private readonly VkSwapchain _mainSwapchain;

        /// <summary>
        /// The fixed utf string
        /// </summary>
        private readonly List<FixedUtf8String> _surfaceExtensions = new List<FixedUtf8String>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VkGraphicsDevice"/> class
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="scDesc">The sc desc</param>
        public VkGraphicsDevice(GraphicsDeviceOptions options, SwapchainDescription? scDesc)
            : this(options, scDesc, new VulkanDeviceOptions()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkGraphicsDevice"/> class
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="scDesc">The sc desc</param>
        /// <param name="vkOptions">The vk options</param>
        public VkGraphicsDevice(GraphicsDeviceOptions options, SwapchainDescription? scDesc, VulkanDeviceOptions vkOptions)
        {
            CreateInstance(options.Debug, vkOptions);

            VkSurfaceKHR surface = VkSurfaceKHR.Null;
            if (scDesc != null)
            {
                surface = VkSurfaceUtil.CreateSurface(this, _instance, scDesc.Value.Source);
            }

            CreatePhysicalDevice();
            CreateLogicalDevice(surface, options.PreferStandardClipSpaceYDirection, vkOptions);

            _memoryManager = new VkDeviceMemoryManager(
                _device,
                _physicalDevice,
                _physicalDeviceProperties.limits.bufferImageGranularity,
                _getBufferMemoryRequirements2,
                _getImageMemoryRequirements2);

            Features = new GraphicsDeviceFeatures(
                computeShader: true,
                geometryShader: _physicalDeviceFeatures.geometryShader,
                tessellationShaders: _physicalDeviceFeatures.tessellationShader,
                multipleViewports: _physicalDeviceFeatures.multiViewport,
                samplerLodBias: true,
                drawBaseVertex: true,
                drawBaseInstance: true,
                drawIndirect: true,
                drawIndirectBaseInstance: _physicalDeviceFeatures.drawIndirectFirstInstance,
                fillModeWireframe: _physicalDeviceFeatures.fillModeNonSolid,
                samplerAnisotropy: _physicalDeviceFeatures.samplerAnisotropy,
                depthClipDisable: _physicalDeviceFeatures.depthClamp,
                texture1D: true,
                independentBlend: _physicalDeviceFeatures.independentBlend,
                structuredBuffer: true,
                subsetTextureView: true,
                commandListDebugMarkers: _debugMarkerEnabled,
                bufferRangeBinding: true,
                shaderFloat64: _physicalDeviceFeatures.shaderFloat64);

            ResourceFactory = new VkResourceFactory(this);

            if (scDesc != null)
            {
                SwapchainDescription desc = scDesc.Value;
                _mainSwapchain = new VkSwapchain(this, ref desc, surface);
            }

            CreateDescriptorPool();
            CreateGraphicsCommandPool();
            for (int i = 0; i < SharedCommandPoolCount; i++)
            {
                _sharedGraphicsCommandPools.Push(new SharedCommandPool(this, true));
            }

            _vulkanInfo = new BackendInfoVulkan(this);

            PostDeviceCreated();
        }

        /// <summary>
        /// Gets the value of the resource factory
        /// </summary>
        public override ResourceFactory ResourceFactory { get; }

        /// <summary>
        /// Submits the commands core using the specified cl
        /// </summary>
        /// <param name="cl">The cl</param>
        /// <param name="fence">The fence</param>
        private protected override void SubmitCommandsCore(CommandList cl, Fence fence)
        {
            SubmitCommandList(cl, 0, null, 0, null, fence);
        }

        /// <summary>
        /// Submits the command list using the specified cl
        /// </summary>
        /// <param name="cl">The cl</param>
        /// <param name="waitSemaphoreCount">The wait semaphore count</param>
        /// <param name="waitSemaphoresPtr">The wait semaphores ptr</param>
        /// <param name="signalSemaphoreCount">The signal semaphore count</param>
        /// <param name="signalSemaphoresPtr">The signal semaphores ptr</param>
        /// <param name="fence">The fence</param>
        private void SubmitCommandList(
            CommandList cl,
            uint waitSemaphoreCount,
            VkSemaphore* waitSemaphoresPtr,
            uint signalSemaphoreCount,
            VkSemaphore* signalSemaphoresPtr,
            Fence fence)
        {
            VkCommandList vkCL = Util.AssertSubtype<CommandList, VkCommandList>(cl);
            VkCommandBuffer vkCB = vkCL.CommandBuffer;

            vkCL.CommandBufferSubmitted(vkCB);
            SubmitCommandBuffer(vkCL, vkCB, waitSemaphoreCount, waitSemaphoresPtr, signalSemaphoreCount, signalSemaphoresPtr, fence);
        }

        /// <summary>
        /// Submits the command buffer using the specified vk cl
        /// </summary>
        /// <param name="vkCL">The vk cl</param>
        /// <param name="vkCB">The vk cb</param>
        /// <param name="waitSemaphoreCount">The wait semaphore count</param>
        /// <param name="waitSemaphoresPtr">The wait semaphores ptr</param>
        /// <param name="signalSemaphoreCount">The signal semaphore count</param>
        /// <param name="signalSemaphoresPtr">The signal semaphores ptr</param>
        /// <param name="fence">The fence</param>
        private void SubmitCommandBuffer(
            VkCommandList vkCL,
            VkCommandBuffer vkCB,
            uint waitSemaphoreCount,
            VkSemaphore* waitSemaphoresPtr,
            uint signalSemaphoreCount,
            VkSemaphore* signalSemaphoresPtr,
            Fence fence)
        {
            CheckSubmittedFences();

            bool useExtraFence = fence != null;
            VkSubmitInfo si = VkSubmitInfo.New();
            si.commandBufferCount = 1;
            si.pCommandBuffers = &vkCB;
            VkPipelineStageFlags waitDstStageMask = VkPipelineStageFlags.ColorAttachmentOutput;
            si.pWaitDstStageMask = &waitDstStageMask;

            si.pWaitSemaphores = waitSemaphoresPtr;
            si.waitSemaphoreCount = waitSemaphoreCount;
            si.pSignalSemaphores = signalSemaphoresPtr;
            si.signalSemaphoreCount = signalSemaphoreCount;

            Vulkan.VkFence vkFence = Vulkan.VkFence.Null;
            Vulkan.VkFence submissionFence = Vulkan.VkFence.Null;
            if (useExtraFence)
            {
                vkFence = Util.AssertSubtype<Fence, VkFence>(fence).DeviceFence;
                submissionFence = GetFreeSubmissionFence();
            }
            else
            {
                vkFence = GetFreeSubmissionFence();
                submissionFence = vkFence;
            }

            lock (_graphicsQueueLock)
            {
                VkResult result = vkQueueSubmit(_graphicsQueue, 1, ref si, vkFence);
                CheckResult(result);
                if (useExtraFence)
                {
                    result = vkQueueSubmit(_graphicsQueue, 0, null, submissionFence);
                    CheckResult(result);
                }
            }

            lock (_submittedFencesLock)
            {
                _submittedFences.Add(new FenceSubmissionInfo(submissionFence, vkCL, vkCB));
            }
        }

        /// <summary>
        /// Checks the submitted fences
        /// </summary>
        private void CheckSubmittedFences()
        {
            lock (_submittedFencesLock)
            {
                for (int i = 0; i < _submittedFences.Count; i++)
                {
                    FenceSubmissionInfo fsi = _submittedFences[i];
                    if (vkGetFenceStatus(_device, fsi.Fence) == VkResult.Success)
                    {
                        CompleteFenceSubmission(fsi);
                        _submittedFences.RemoveAt(i);
                        i -= 1;
                    }
                    else
                    {
                        break; // Submissions are in order; later submissions cannot complete if this one hasn't.
                    }
                }
            }
        }

        /// <summary>
        /// Completes the fence submission using the specified fsi
        /// </summary>
        /// <param name="fsi">The fsi</param>
        private void CompleteFenceSubmission(FenceSubmissionInfo fsi)
        {
            Vulkan.VkFence fence = fsi.Fence;
            VkCommandBuffer completedCB = fsi.CommandBuffer;
            fsi.CommandList?.CommandBufferCompleted(completedCB);
            VkResult resetResult = vkResetFences(_device, 1, ref fence);
            CheckResult(resetResult);
            ReturnSubmissionFence(fence);
            lock (_stagingResourcesLock)
            {
                if (_submittedStagingTextures.TryGetValue(completedCB, out VkTexture stagingTex))
                {
                    _submittedStagingTextures.Remove(completedCB);
                    _availableStagingTextures.Add(stagingTex);
                }
                if (_submittedStagingBuffers.TryGetValue(completedCB, out VkBuffer stagingBuffer))
                {
                    _submittedStagingBuffers.Remove(completedCB);
                    if (stagingBuffer.SizeInBytes <= MaxStagingBufferSize)
                    {
                        _availableStagingBuffers.Add(stagingBuffer);
                    }
                    else
                    {
                        stagingBuffer.Dispose();
                    }
                }
                if (_submittedSharedCommandPools.TryGetValue(completedCB, out SharedCommandPool sharedPool))
                {
                    _submittedSharedCommandPools.Remove(completedCB);
                    lock (_graphicsCommandPoolLock)
                    {
                        if (sharedPool.IsCached)
                        {
                            _sharedGraphicsCommandPools.Push(sharedPool);
                        }
                        else
                        {
                            sharedPool.Destroy();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the submission fence using the specified fence
        /// </summary>
        /// <param name="fence">The fence</param>
        private void ReturnSubmissionFence(Vulkan.VkFence fence)
        {
            _availableSubmissionFences.Enqueue(fence);
        }

        /// <summary>
        /// Gets the free submission fence
        /// </summary>
        /// <returns>The vulkan vk fence</returns>
        private Vulkan.VkFence GetFreeSubmissionFence()
        {
            if (_availableSubmissionFences.TryDequeue(out Vulkan.VkFence availableFence))
            {
                return availableFence;
            }
            else
            {
                VkFenceCreateInfo fenceCI = VkFenceCreateInfo.New();
                VkResult result = vkCreateFence(_device, ref fenceCI, null, out Vulkan.VkFence newFence);
                CheckResult(result);
                return newFence;
            }
        }

        /// <summary>
        /// Swaps the buffers core using the specified swapchain
        /// </summary>
        /// <param name="swapchain">The swapchain</param>
        private protected override void SwapBuffersCore(Swapchain swapchain)
        {
            VkSwapchain vkSC = Util.AssertSubtype<Swapchain, VkSwapchain>(swapchain);
            VkSwapchainKHR deviceSwapchain = vkSC.DeviceSwapchain;
            VkPresentInfoKHR presentInfo = VkPresentInfoKHR.New();
            presentInfo.swapchainCount = 1;
            presentInfo.pSwapchains = &deviceSwapchain;
            uint imageIndex = vkSC.ImageIndex;
            presentInfo.pImageIndices = &imageIndex;

            object presentLock = vkSC.PresentQueueIndex == _graphicsQueueIndex ? _graphicsQueueLock : vkSC;
            lock (presentLock)
            {
                vkQueuePresentKHR(vkSC.PresentQueue, ref presentInfo);
                if (vkSC.AcquireNextImage(_device, VkSemaphore.Null, vkSC.ImageAvailableFence))
                {
                    Vulkan.VkFence fence = vkSC.ImageAvailableFence;
                    vkWaitForFences(_device, 1, ref fence, true, ulong.MaxValue);
                    vkResetFences(_device, 1, ref fence);
                }
            }
        }

        /// <summary>
        /// Sets the resource name using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="name">The name</param>
        internal void SetResourceName(DeviceResource resource, string name)
        {
            if (_debugMarkerEnabled)
            {
                switch (resource)
                {
                    case VkBuffer buffer:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.BufferEXT, buffer.DeviceBuffer.Handle, name);
                        break;
                    case VkCommandList commandList:
                        SetDebugMarkerName(
                            VkDebugReportObjectTypeEXT.CommandBufferEXT,
                            (ulong)commandList.CommandBuffer.Handle,
                            string.Format("{0}_CommandBuffer", name));
                        SetDebugMarkerName(
                            VkDebugReportObjectTypeEXT.CommandPoolEXT,
                            commandList.CommandPool.Handle,
                            string.Format("{0}_CommandPool", name));
                        break;
                    case VkFramebuffer framebuffer:
                        SetDebugMarkerName(
                            VkDebugReportObjectTypeEXT.FramebufferEXT,
                            framebuffer.CurrentFramebuffer.Handle,
                            name);
                        break;
                    case VkPipeline pipeline:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.PipelineEXT, pipeline.DevicePipeline.Handle, name);
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.PipelineLayoutEXT, pipeline.PipelineLayout.Handle, name);
                        break;
                    case VkResourceLayout resourceLayout:
                        SetDebugMarkerName(
                            VkDebugReportObjectTypeEXT.DescriptorSetLayoutEXT,
                            resourceLayout.DescriptorSetLayout.Handle,
                            name);
                        break;
                    case VkResourceSet resourceSet:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.DescriptorSetEXT, resourceSet.DescriptorSet.Handle, name);
                        break;
                    case VkSampler sampler:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.SamplerEXT, sampler.DeviceSampler.Handle, name);
                        break;
                    case VkShader shader:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.ShaderModuleEXT, shader.ShaderModule.Handle, name);
                        break;
                    case VkTexture tex:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.ImageEXT, tex.OptimalDeviceImage.Handle, name);
                        break;
                    case VkTextureView texView:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.ImageViewEXT, texView.ImageView.Handle, name);
                        break;
                    case VkFence fence:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.FenceEXT, fence.DeviceFence.Handle, name);
                        break;
                    case VkSwapchain sc:
                        SetDebugMarkerName(VkDebugReportObjectTypeEXT.SwapchainKHREXT, sc.DeviceSwapchain.Handle, name);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the debug marker name using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="target">The target</param>
        /// <param name="name">The name</param>
        private void SetDebugMarkerName(VkDebugReportObjectTypeEXT type, ulong target, string name)
        {
            Debug.Assert(_setObjectNameDelegate != null);

            VkDebugMarkerObjectNameInfoEXT nameInfo = VkDebugMarkerObjectNameInfoEXT.New();
            nameInfo.objectType = type;
            nameInfo.@object = target;

            int byteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8Ptr = stackalloc byte[byteCount + 1];
            fixed (char* namePtr = name)
            {
                Encoding.UTF8.GetBytes(namePtr, name.Length, utf8Ptr, byteCount);
            }
            utf8Ptr[byteCount] = 0;

            nameInfo.pObjectName = utf8Ptr;
            VkResult result = _setObjectNameDelegate(_device, &nameInfo);
            CheckResult(result);
        }

        /// <summary>
        /// Creates the instance using the specified debug
        /// </summary>
        /// <param name="debug">The debug</param>
        /// <param name="options">The options</param>
        /// <exception cref="VeldridException">The required instance extension was not available: {requiredExt}</exception>
        private void CreateInstance(bool debug, VulkanDeviceOptions options)
        {
            HashSet<string> availableInstanceLayers = new HashSet<string>(EnumerateInstanceLayers());
            HashSet<string> availableInstanceExtensions = new HashSet<string>(GetInstanceExtensions());

            VkInstanceCreateInfo instanceCI = VkInstanceCreateInfo.New();
            VkApplicationInfo applicationInfo = new VkApplicationInfo();
            applicationInfo.apiVersion = new VkVersion(1, 0, 0);
            applicationInfo.applicationVersion = new VkVersion(1, 0, 0);
            applicationInfo.engineVersion = new VkVersion(1, 0, 0);
            applicationInfo.pApplicationName = s_name;
            applicationInfo.pEngineName = s_name;

            instanceCI.pApplicationInfo = &applicationInfo;

            StackList<IntPtr, Size64Bytes> instanceExtensions = new StackList<IntPtr, Size64Bytes>();
            StackList<IntPtr, Size64Bytes> instanceLayers = new StackList<IntPtr, Size64Bytes>();

            if (availableInstanceExtensions.Contains(CommonStrings.VK_KHR_portability_subset))
            {
                _surfaceExtensions.Add(CommonStrings.VK_KHR_portability_subset);
            }

            if (availableInstanceExtensions.Contains(CommonStrings.VK_KHR_SURFACE_EXTENSION_NAME))
            {
                _surfaceExtensions.Add(CommonStrings.VK_KHR_SURFACE_EXTENSION_NAME);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (availableInstanceExtensions.Contains(CommonStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME))
                {
                    _surfaceExtensions.Add(CommonStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME);
                }
            }
            else if (
#if NET5_0_OR_GREATER
                OperatingSystem.IsAndroid() ||
#endif
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (availableInstanceExtensions.Contains(CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME))
                {
                    _surfaceExtensions.Add(CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME);
                }
                if (availableInstanceExtensions.Contains(CommonStrings.VK_KHR_XLIB_SURFACE_EXTENSION_NAME))
                {
                    _surfaceExtensions.Add(CommonStrings.VK_KHR_XLIB_SURFACE_EXTENSION_NAME);
                }
                if (availableInstanceExtensions.Contains(CommonStrings.VK_KHR_WAYLAND_SURFACE_EXTENSION_NAME))
                {
                    _surfaceExtensions.Add(CommonStrings.VK_KHR_WAYLAND_SURFACE_EXTENSION_NAME);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (availableInstanceExtensions.Contains(CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME))
                {
                    _surfaceExtensions.Add(CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME);
                }
                else // Legacy MoltenVK extensions
                {
                    if (availableInstanceExtensions.Contains(CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME))
                    {
                        _surfaceExtensions.Add(CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME);
                    }
                    if (availableInstanceExtensions.Contains(CommonStrings.VK_MVK_IOS_SURFACE_EXTENSION_NAME))
                    {
                        _surfaceExtensions.Add(CommonStrings.VK_MVK_IOS_SURFACE_EXTENSION_NAME);
                    }
                }
            }

            foreach (var ext in _surfaceExtensions)
            {
                instanceExtensions.Add(ext);
            }

            bool hasDeviceProperties2 = availableInstanceExtensions.Contains(CommonStrings.VK_KHR_get_physical_device_properties2);
            if (hasDeviceProperties2)
            {
                instanceExtensions.Add(CommonStrings.VK_KHR_get_physical_device_properties2);
            }

            string[] requestedInstanceExtensions = options.InstanceExtensions ?? Array.Empty<string>();
            List<FixedUtf8String> tempStrings = new List<FixedUtf8String>();
            foreach (string requiredExt in requestedInstanceExtensions)
            {
                if (!availableInstanceExtensions.Contains(requiredExt))
                {
                    throw new VeldridException($"The required instance extension was not available: {requiredExt}");
                }

                FixedUtf8String utf8Str = new FixedUtf8String(requiredExt);
                instanceExtensions.Add(utf8Str);
                tempStrings.Add(utf8Str);
            }

            bool debugReportExtensionAvailable = false;
            if (debug)
            {
                if (availableInstanceExtensions.Contains(CommonStrings.VK_EXT_DEBUG_REPORT_EXTENSION_NAME))
                {
                    debugReportExtensionAvailable = true;
                    instanceExtensions.Add(CommonStrings.VK_EXT_DEBUG_REPORT_EXTENSION_NAME);
                }
                if (availableInstanceLayers.Contains(CommonStrings.StandardValidationLayerName))
                {
                    _standardValidationSupported = true;
                    instanceLayers.Add(CommonStrings.StandardValidationLayerName);
                }
                if (availableInstanceLayers.Contains(CommonStrings.KhronosValidationLayerName))
                {
                    _khronosValidationSupported = true;
                    instanceLayers.Add(CommonStrings.KhronosValidationLayerName);
                }
            }

            instanceCI.enabledExtensionCount = instanceExtensions.Count;
            instanceCI.ppEnabledExtensionNames = (byte**)instanceExtensions.Data;

            instanceCI.enabledLayerCount = instanceLayers.Count;
            if (instanceLayers.Count > 0)
            {
                instanceCI.ppEnabledLayerNames = (byte**)instanceLayers.Data;
            }

            VkResult result = vkCreateInstance(ref instanceCI, null, out _instance);
            CheckResult(result);

            if (HasSurfaceExtension(CommonStrings.VK_EXT_METAL_SURFACE_EXTENSION_NAME))
            {
                _createMetalSurfaceEXT = GetInstanceProcAddr<vkCreateMetalSurfaceEXT_t>("vkCreateMetalSurfaceEXT");
            }

            if (debug && debugReportExtensionAvailable)
            {
                EnableDebugCallback();
            }

            if (hasDeviceProperties2)
            {
                _getPhysicalDeviceProperties2 = GetInstanceProcAddr<vkGetPhysicalDeviceProperties2_t>("vkGetPhysicalDeviceProperties2")
                    ?? GetInstanceProcAddr<vkGetPhysicalDeviceProperties2_t>("vkGetPhysicalDeviceProperties2KHR");
            }

            foreach (FixedUtf8String tempStr in tempStrings)
            {
                tempStr.Dispose();
            }
        }

        /// <summary>
        /// Describes whether this instance has surface extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The bool</returns>
        public bool HasSurfaceExtension(FixedUtf8String extension)
        {
            return _surfaceExtensions.Contains(extension);
        }

        /// <summary>
        /// Enables the debug callback using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        public void EnableDebugCallback(VkDebugReportFlagsEXT flags = VkDebugReportFlagsEXT.WarningEXT | VkDebugReportFlagsEXT.ErrorEXT)
        {
            Debug.WriteLine("Enabling Vulkan Debug callbacks.");
            _debugCallbackFunc = DebugCallback;
            IntPtr debugFunctionPtr = Marshal.GetFunctionPointerForDelegate(_debugCallbackFunc);
            VkDebugReportCallbackCreateInfoEXT debugCallbackCI = VkDebugReportCallbackCreateInfoEXT.New();
            debugCallbackCI.flags = flags;
            debugCallbackCI.pfnCallback = debugFunctionPtr;
            IntPtr createFnPtr;
            using (FixedUtf8String debugExtFnName = "vkCreateDebugReportCallbackEXT")
            {
                createFnPtr = vkGetInstanceProcAddr(_instance, debugExtFnName);
            }
            if (createFnPtr == IntPtr.Zero)
            {
                return;
            }

            vkCreateDebugReportCallbackEXT_d createDelegate = Marshal.GetDelegateForFunctionPointer<vkCreateDebugReportCallbackEXT_d>(createFnPtr);
            VkResult result = createDelegate(_instance, &debugCallbackCI, IntPtr.Zero, out _debugCallbackHandle);
            CheckResult(result);
        }

        /// <summary>
        /// Debugs the callback using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="objectType">The object type</param>
        /// <param name="object">The object</param>
        /// <param name="location">The location</param>
        /// <param name="messageCode">The message code</param>
        /// <param name="pLayerPrefix">The layer prefix</param>
        /// <param name="pMessage">The message</param>
        /// <param name="pUserData">The user data</param>
        /// <exception cref="VeldridException"></exception>
        /// <returns>The uint</returns>
        private uint DebugCallback(
            uint flags,
            VkDebugReportObjectTypeEXT objectType,
            ulong @object,
            UIntPtr location,
            int messageCode,
            byte* pLayerPrefix,
            byte* pMessage,
            void* pUserData)
        {
            string message = Util.GetString(pMessage);
            VkDebugReportFlagsEXT debugReportFlags = (VkDebugReportFlagsEXT)flags;

#if DEBUG
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
#endif

            string fullMessage = $"[{debugReportFlags}] ({objectType}) {message}";

            if (debugReportFlags == VkDebugReportFlagsEXT.ErrorEXT)
            {
                throw new VeldridException("A Vulkan validation error was encountered: " + fullMessage);
            }

            Console.WriteLine(fullMessage);
            return 0;
        }

        /// <summary>
        /// Creates the physical device
        /// </summary>
        /// <exception cref="InvalidOperationException">No physical devices exist.</exception>
        private void CreatePhysicalDevice()
        {
            uint deviceCount = 0;
            vkEnumeratePhysicalDevices(_instance, ref deviceCount, null);
            if (deviceCount == 0)
            {
                throw new InvalidOperationException("No physical devices exist.");
            }

            VkPhysicalDevice[] physicalDevices = new VkPhysicalDevice[deviceCount];
            vkEnumeratePhysicalDevices(_instance, ref deviceCount, ref physicalDevices[0]);
            // Just use the first one.
            _physicalDevice = physicalDevices[0];

            vkGetPhysicalDeviceProperties(_physicalDevice, out _physicalDeviceProperties);
            fixed (byte* utf8NamePtr = _physicalDeviceProperties.deviceName)
            {
                _deviceName = Encoding.UTF8.GetString(utf8NamePtr, (int)MaxPhysicalDeviceNameSize).TrimEnd('\0');
            }

            _vendorName = "id:" + _physicalDeviceProperties.vendorID.ToString("x8");
            _apiVersion = GraphicsApiVersion.Unknown;
            _driverInfo = "version:" + _physicalDeviceProperties.driverVersion.ToString("x8");

            vkGetPhysicalDeviceFeatures(_physicalDevice, out _physicalDeviceFeatures);

            vkGetPhysicalDeviceMemoryProperties(_physicalDevice, out _physicalDeviceMemProperties);
        }

        /// <summary>
        /// Gets the device extension properties
        /// </summary>
        /// <returns>The props</returns>
        public VkExtensionProperties[] GetDeviceExtensionProperties()
        {
            uint propertyCount = 0;
            VkResult result = vkEnumerateDeviceExtensionProperties(_physicalDevice, (byte*)null, &propertyCount, null);
            CheckResult(result);
            VkExtensionProperties[] props = new VkExtensionProperties[(int)propertyCount];
            fixed (VkExtensionProperties* properties = props)
            {
                result = vkEnumerateDeviceExtensionProperties(_physicalDevice, (byte*)null, &propertyCount, properties);
                CheckResult(result);
            }
            return props;
        }

        /// <summary>
        /// Creates the logical device using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="preferStandardClipY">The prefer standard clip</param>
        /// <param name="options">The options</param>
        /// <exception cref="VeldridException">The following Vulkan device extensions were not available: {missingList}</exception>
        private void CreateLogicalDevice(VkSurfaceKHR surface, bool preferStandardClipY, VulkanDeviceOptions options)
        {
            GetQueueFamilyIndices(surface);

            HashSet<uint> familyIndices = new HashSet<uint> { _graphicsQueueIndex, _presentQueueIndex };
            VkDeviceQueueCreateInfo* queueCreateInfos = stackalloc VkDeviceQueueCreateInfo[familyIndices.Count];
            uint queueCreateInfosCount = (uint)familyIndices.Count;

            int i = 0;
            foreach (uint index in familyIndices)
            {
                VkDeviceQueueCreateInfo queueCreateInfo = VkDeviceQueueCreateInfo.New();
                queueCreateInfo.queueFamilyIndex = _graphicsQueueIndex;
                queueCreateInfo.queueCount = 1;
                float priority = 1f;
                queueCreateInfo.pQueuePriorities = &priority;
                queueCreateInfos[i] = queueCreateInfo;
                i += 1;
            }

            VkPhysicalDeviceFeatures deviceFeatures = _physicalDeviceFeatures;

            VkExtensionProperties[] props = GetDeviceExtensionProperties();

            HashSet<string> requiredInstanceExtensions = new HashSet<string>(options.DeviceExtensions ?? Array.Empty<string>());

            bool hasMemReqs2 = false;
            bool hasDedicatedAllocation = false;
            bool hasDriverProperties = false;
            IntPtr[] activeExtensions = new IntPtr[props.Length];
            uint activeExtensionCount = 0;

            fixed (VkExtensionProperties* properties = props)
            {
                for (int property = 0; property < props.Length; property++)
                {
                    string extensionName = Util.GetString(properties[property].extensionName);
                    if (extensionName == "VK_EXT_debug_marker")
                    {
                        activeExtensions[activeExtensionCount++] = CommonStrings.VK_EXT_DEBUG_MARKER_EXTENSION_NAME;
                        requiredInstanceExtensions.Remove(extensionName);
                        _debugMarkerEnabled = true;
                    }
                    else if (extensionName == "VK_KHR_swapchain")
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                        requiredInstanceExtensions.Remove(extensionName);
                    }
                    else if (preferStandardClipY && extensionName == "VK_KHR_maintenance1")
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                        requiredInstanceExtensions.Remove(extensionName);
                        _standardClipYDirection = true;
                    }
                    else if (extensionName == "VK_KHR_get_memory_requirements2")
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                        requiredInstanceExtensions.Remove(extensionName);
                        hasMemReqs2 = true;
                    }
                    else if (extensionName == "VK_KHR_dedicated_allocation")
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                        requiredInstanceExtensions.Remove(extensionName);
                        hasDedicatedAllocation = true;
                    }
                    else if (extensionName == "VK_KHR_driver_properties")
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                        requiredInstanceExtensions.Remove(extensionName);
                        hasDriverProperties = true;
                    }
                    else if (extensionName == CommonStrings.VK_KHR_portability_subset)
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                        requiredInstanceExtensions.Remove(extensionName);
                    }
                    else if (requiredInstanceExtensions.Remove(extensionName))
                    {
                        activeExtensions[activeExtensionCount++] = (IntPtr)properties[property].extensionName;
                    }
                }
            }

            if (requiredInstanceExtensions.Count != 0)
            {
                string missingList = string.Join(", ", requiredInstanceExtensions);
                throw new VeldridException(
                    $"The following Vulkan device extensions were not available: {missingList}");
            }

            VkDeviceCreateInfo deviceCreateInfo = VkDeviceCreateInfo.New();
            deviceCreateInfo.queueCreateInfoCount = queueCreateInfosCount;
            deviceCreateInfo.pQueueCreateInfos = queueCreateInfos;

            deviceCreateInfo.pEnabledFeatures = &deviceFeatures;

            StackList<IntPtr> layerNames = new StackList<IntPtr>();
            if (_standardValidationSupported)
            {
                layerNames.Add(CommonStrings.StandardValidationLayerName);
            }
            if (_khronosValidationSupported)
            {
                layerNames.Add(CommonStrings.KhronosValidationLayerName);
            }
            deviceCreateInfo.enabledLayerCount = layerNames.Count;
            deviceCreateInfo.ppEnabledLayerNames = (byte**)layerNames.Data;

            fixed (IntPtr* activeExtensionsPtr = activeExtensions)
            {
                deviceCreateInfo.enabledExtensionCount = activeExtensionCount;
                deviceCreateInfo.ppEnabledExtensionNames = (byte**)activeExtensionsPtr;

                VkResult result = vkCreateDevice(_physicalDevice, ref deviceCreateInfo, null, out _device);
                CheckResult(result);
            }

            vkGetDeviceQueue(_device, _graphicsQueueIndex, 0, out _graphicsQueue);

            if (_debugMarkerEnabled)
            {
                _setObjectNameDelegate = Marshal.GetDelegateForFunctionPointer<vkDebugMarkerSetObjectNameEXT_t>(
                    GetInstanceProcAddr("vkDebugMarkerSetObjectNameEXT"));
                _markerBegin = Marshal.GetDelegateForFunctionPointer<vkCmdDebugMarkerBeginEXT_t>(
                    GetInstanceProcAddr("vkCmdDebugMarkerBeginEXT"));
                _markerEnd = Marshal.GetDelegateForFunctionPointer<vkCmdDebugMarkerEndEXT_t>(
                    GetInstanceProcAddr("vkCmdDebugMarkerEndEXT"));
                _markerInsert = Marshal.GetDelegateForFunctionPointer<vkCmdDebugMarkerInsertEXT_t>(
                    GetInstanceProcAddr("vkCmdDebugMarkerInsertEXT"));
            }
            if (hasDedicatedAllocation && hasMemReqs2)
            {
                _getBufferMemoryRequirements2 = GetDeviceProcAddr<vkGetBufferMemoryRequirements2_t>("vkGetBufferMemoryRequirements2")
                    ?? GetDeviceProcAddr<vkGetBufferMemoryRequirements2_t>("vkGetBufferMemoryRequirements2KHR");
                _getImageMemoryRequirements2 = GetDeviceProcAddr<vkGetImageMemoryRequirements2_t>("vkGetImageMemoryRequirements2")
                    ?? GetDeviceProcAddr<vkGetImageMemoryRequirements2_t>("vkGetImageMemoryRequirements2KHR");
            }
            if (_getPhysicalDeviceProperties2 != null && hasDriverProperties)
            {
                VkPhysicalDeviceProperties2KHR deviceProps = VkPhysicalDeviceProperties2KHR.New();
                VkPhysicalDeviceDriverProperties driverProps = VkPhysicalDeviceDriverProperties.New();

                deviceProps.pNext = &driverProps;
                _getPhysicalDeviceProperties2(_physicalDevice, &deviceProps);

                string driverName = Encoding.UTF8.GetString(
                    driverProps.driverName, VkPhysicalDeviceDriverProperties.DriverNameLength).TrimEnd('\0');

                string driverInfo = Encoding.UTF8.GetString(
                    driverProps.driverInfo, VkPhysicalDeviceDriverProperties.DriverInfoLength).TrimEnd('\0');

                VkConformanceVersion conforming = driverProps.conformanceVersion;
                _apiVersion = new GraphicsApiVersion(conforming.major, conforming.minor, conforming.subminor, conforming.patch);
                _driverName = driverName;
                _driverInfo = driverInfo;
            }
        }

        /// <summary>
        /// Gets the instance proc addr using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        private IntPtr GetInstanceProcAddr(string name)
        {
            int byteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8Ptr = stackalloc byte[byteCount + 1];

            fixed (char* namePtr = name)
            {
                Encoding.UTF8.GetBytes(namePtr, name.Length, utf8Ptr, byteCount);
            }
            utf8Ptr[byteCount] = 0;

            return vkGetInstanceProcAddr(_instance, utf8Ptr);
        }

        /// <summary>
        /// Gets the instance proc addr using the specified name
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="name">The name</param>
        /// <returns>The</returns>
        private T GetInstanceProcAddr<T>(string name)
        {
            IntPtr funcPtr = GetInstanceProcAddr(name);
            if (funcPtr != IntPtr.Zero)
            {
                return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
            }
            return default;
        }

        /// <summary>
        /// Gets the device proc addr using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        private IntPtr GetDeviceProcAddr(string name)
        {
            int byteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8Ptr = stackalloc byte[byteCount + 1];

            fixed (char* namePtr = name)
            {
                Encoding.UTF8.GetBytes(namePtr, name.Length, utf8Ptr, byteCount);
            }
            utf8Ptr[byteCount] = 0;

            return vkGetDeviceProcAddr(_device, utf8Ptr);
        }

        /// <summary>
        /// Gets the device proc addr using the specified name
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="name">The name</param>
        /// <returns>The</returns>
        private T GetDeviceProcAddr<T>(string name)
        {
            IntPtr funcPtr = GetDeviceProcAddr(name);
            if (funcPtr != IntPtr.Zero)
            {
                return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
            }
            return default;
        }

        /// <summary>
        /// Gets the queue family indices using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        private void GetQueueFamilyIndices(VkSurfaceKHR surface)
        {
            uint queueFamilyCount = 0;
            vkGetPhysicalDeviceQueueFamilyProperties(_physicalDevice, ref queueFamilyCount, null);
            VkQueueFamilyProperties[] qfp = new VkQueueFamilyProperties[queueFamilyCount];
            vkGetPhysicalDeviceQueueFamilyProperties(_physicalDevice, ref queueFamilyCount, out qfp[0]);

            bool foundGraphics = false;
            bool foundPresent = surface == VkSurfaceKHR.Null;

            for (uint i = 0; i < qfp.Length; i++)
            {
                if ((qfp[i].queueFlags & VkQueueFlags.Graphics) != 0)
                {
                    _graphicsQueueIndex = i;
                    foundGraphics = true;
                }

                if (!foundPresent)
                {
                    vkGetPhysicalDeviceSurfaceSupportKHR(_physicalDevice, i, surface, out VkBool32 presentSupported);
                    if (presentSupported)
                    {
                        _presentQueueIndex = i;
                        foundPresent = true;
                    }
                }

                if (foundGraphics && foundPresent)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Creates the descriptor pool
        /// </summary>
        private void CreateDescriptorPool()
        {
            _descriptorPoolManager = new VkDescriptorPoolManager(this);
        }

        /// <summary>
        /// Creates the graphics command pool
        /// </summary>
        private void CreateGraphicsCommandPool()
        {
            VkCommandPoolCreateInfo commandPoolCI = VkCommandPoolCreateInfo.New();
            commandPoolCI.flags = VkCommandPoolCreateFlags.ResetCommandBuffer;
            commandPoolCI.queueFamilyIndex = _graphicsQueueIndex;
            VkResult result = vkCreateCommandPool(_device, ref commandPoolCI, null, out _graphicsCommandPool);
            CheckResult(result);
        }

        /// <summary>
        /// Maps the core using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="mode">The mode</param>
        /// <param name="subresource">The subresource</param>
        /// <returns>The mapped resource</returns>
        protected override MappedResource MapCore(MappableResource resource, MapMode mode, uint subresource)
        {
            VkMemoryBlock memoryBlock = default(VkMemoryBlock);
            IntPtr mappedPtr = IntPtr.Zero;
            uint sizeInBytes;
            uint offset = 0;
            uint rowPitch = 0;
            uint depthPitch = 0;
            if (resource is VkBuffer buffer)
            {
                memoryBlock = buffer.Memory;
                sizeInBytes = buffer.SizeInBytes;
            }
            else
            {
                VkTexture texture = Util.AssertSubtype<MappableResource, VkTexture>(resource);
                VkSubresourceLayout layout = texture.GetSubresourceLayout(subresource);
                memoryBlock = texture.Memory;
                sizeInBytes = (uint)layout.size;
                offset = (uint)layout.offset;
                rowPitch = (uint)layout.rowPitch;
                depthPitch = (uint)layout.depthPitch;
            }

            if (memoryBlock.DeviceMemory.Handle != 0)
            {
                if (memoryBlock.IsPersistentMapped)
                {
                    mappedPtr = (IntPtr)memoryBlock.BlockMappedPointer;
                }
                else
                {
                    mappedPtr = _memoryManager.Map(memoryBlock);
                }
            }

            byte* dataPtr = (byte*)mappedPtr.ToPointer() + offset;
            return new MappedResource(
                resource,
                mode,
                (IntPtr)dataPtr,
                sizeInBytes,
                subresource,
                rowPitch,
                depthPitch);
        }

        /// <summary>
        /// Unmaps the core using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="subresource">The subresource</param>
        protected override void UnmapCore(MappableResource resource, uint subresource)
        {
            VkMemoryBlock memoryBlock = default(VkMemoryBlock);
            if (resource is VkBuffer buffer)
            {
                memoryBlock = buffer.Memory;
            }
            else
            {
                VkTexture tex = Util.AssertSubtype<MappableResource, VkTexture>(resource);
                memoryBlock = tex.Memory;
            }

            if (memoryBlock.DeviceMemory.Handle != 0 && !memoryBlock.IsPersistentMapped)
            {
                vkUnmapMemory(_device, memoryBlock.DeviceMemory);
            }
        }

        /// <summary>
        /// Platforms the dispose
        /// </summary>
        protected override void PlatformDispose()
        {
            Debug.Assert(_submittedFences.Count == 0);
            foreach (Vulkan.VkFence fence in _availableSubmissionFences)
            {
                vkDestroyFence(_device, fence, null);
            }

            _mainSwapchain?.Dispose();
            if (_debugCallbackFunc != null)
            {
                _debugCallbackFunc = null;
                FixedUtf8String debugExtFnName = "vkDestroyDebugReportCallbackEXT";
                IntPtr destroyFuncPtr = vkGetInstanceProcAddr(_instance, debugExtFnName);
                vkDestroyDebugReportCallbackEXT_d destroyDel
                    = Marshal.GetDelegateForFunctionPointer<vkDestroyDebugReportCallbackEXT_d>(destroyFuncPtr);
                destroyDel(_instance, _debugCallbackHandle, null);
            }

            _descriptorPoolManager.DestroyAll();
            vkDestroyCommandPool(_device, _graphicsCommandPool, null);

            Debug.Assert(_submittedStagingTextures.Count == 0);
            foreach (VkTexture tex in _availableStagingTextures)
            {
                tex.Dispose();
            }

            Debug.Assert(_submittedStagingBuffers.Count == 0);
            foreach (VkBuffer buffer in _availableStagingBuffers)
            {
                buffer.Dispose();
            }

            lock (_graphicsCommandPoolLock)
            {
                while (_sharedGraphicsCommandPools.Count > 0)
                {
                    SharedCommandPool sharedPool = _sharedGraphicsCommandPools.Pop();
                    sharedPool.Destroy();
                }
            }

            _memoryManager.Dispose();

            VkResult result = vkDeviceWaitIdle(_device);
            CheckResult(result);
            vkDestroyDevice(_device, null);
            vkDestroyInstance(_instance, null);
        }

        /// <summary>
        /// Waits the for idle core
        /// </summary>
        private protected override void WaitForIdleCore()
        {
            lock (_graphicsQueueLock)
            {
                vkQueueWaitIdle(_graphicsQueue);
            }

            CheckSubmittedFences();
        }

        /// <summary>
        /// Gets the sample count limit using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="depthFormat">The depth format</param>
        /// <returns>The texture sample count</returns>
        public override TextureSampleCount GetSampleCountLimit(PixelFormat format, bool depthFormat)
        {
            VkImageUsageFlags usageFlags = VkImageUsageFlags.Sampled;
            usageFlags |= depthFormat ? VkImageUsageFlags.DepthStencilAttachment : VkImageUsageFlags.ColorAttachment;

            vkGetPhysicalDeviceImageFormatProperties(
                _physicalDevice,
                VkFormats.VdToVkPixelFormat(format),
                VkImageType.Image2D,
                VkImageTiling.Optimal,
                usageFlags,
                VkImageCreateFlags.None,
                out VkImageFormatProperties formatProperties);

            VkSampleCountFlags vkSampleCounts = formatProperties.sampleCounts;
            if ((vkSampleCounts & VkSampleCountFlags.Count32) == VkSampleCountFlags.Count32)
            {
                return TextureSampleCount.Count32;
            }
            else if ((vkSampleCounts & VkSampleCountFlags.Count16) == VkSampleCountFlags.Count16)
            {
                return TextureSampleCount.Count16;
            }
            else if ((vkSampleCounts & VkSampleCountFlags.Count8) == VkSampleCountFlags.Count8)
            {
                return TextureSampleCount.Count8;
            }
            else if ((vkSampleCounts & VkSampleCountFlags.Count4) == VkSampleCountFlags.Count4)
            {
                return TextureSampleCount.Count4;
            }
            else if ((vkSampleCounts & VkSampleCountFlags.Count2) == VkSampleCountFlags.Count2)
            {
                return TextureSampleCount.Count2;
            }

            return TextureSampleCount.Count1;
        }

        /// <summary>
        /// Describes whether this instance get pixel format support core
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="usage">The usage</param>
        /// <param name="properties">The properties</param>
        /// <returns>The bool</returns>
        private protected override bool GetPixelFormatSupportCore(
            PixelFormat format,
            TextureType type,
            TextureUsage usage,
            out PixelFormatProperties properties)
        {
            VkFormat vkFormat = VkFormats.VdToVkPixelFormat(format, (usage & TextureUsage.DepthStencil) != 0);
            VkImageType vkType = VkFormats.VdToVkTextureType(type);
            VkImageTiling tiling = usage == TextureUsage.Staging ? VkImageTiling.Linear : VkImageTiling.Optimal;
            VkImageUsageFlags vkUsage = VkFormats.VdToVkTextureUsage(usage);

            VkResult result = vkGetPhysicalDeviceImageFormatProperties(
                _physicalDevice,
                vkFormat,
                vkType,
                tiling,
                vkUsage,
                VkImageCreateFlags.None,
                out VkImageFormatProperties vkProps);

            if (result == VkResult.ErrorFormatNotSupported)
            {
                properties = default(PixelFormatProperties);
                return false;
            }
            CheckResult(result);

            properties = new PixelFormatProperties(
               vkProps.maxExtent.width,
               vkProps.maxExtent.height,
               vkProps.maxExtent.depth,
               vkProps.maxMipLevels,
               vkProps.maxArrayLayers,
               (uint)vkProps.sampleCounts);
            return true;
        }

        /// <summary>
        /// Gets the format filter using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The filter</returns>
        internal VkFilter GetFormatFilter(VkFormat format)
        {
            if (!_filters.TryGetValue(format, out VkFilter filter))
            {
                vkGetPhysicalDeviceFormatProperties(_physicalDevice, format, out VkFormatProperties vkFormatProps);
                filter = (vkFormatProps.optimalTilingFeatures & VkFormatFeatureFlags.SampledImageFilterLinear) != 0
                    ? VkFilter.Linear
                    : VkFilter.Nearest;
                _filters.TryAdd(format, filter);
            }

            return filter;
        }

        /// <summary>
        /// Updates the buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        private protected override void UpdateBufferCore(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes)
        {
            VkBuffer vkBuffer = Util.AssertSubtype<DeviceBuffer, VkBuffer>(buffer);
            VkBuffer copySrcVkBuffer = null;
            IntPtr mappedPtr;
            byte* destPtr;
            bool isPersistentMapped = vkBuffer.Memory.IsPersistentMapped;
            if (isPersistentMapped)
            {
                mappedPtr = (IntPtr)vkBuffer.Memory.BlockMappedPointer;
                destPtr = (byte*)mappedPtr + bufferOffsetInBytes;
            }
            else
            {
                copySrcVkBuffer = GetFreeStagingBuffer(sizeInBytes);
                mappedPtr = (IntPtr)copySrcVkBuffer.Memory.BlockMappedPointer;
                destPtr = (byte*)mappedPtr;
            }

            Unsafe.CopyBlock(destPtr, source.ToPointer(), sizeInBytes);

            if (!isPersistentMapped)
            {
                SharedCommandPool pool = GetFreeCommandPool();
                VkCommandBuffer cb = pool.BeginNewCommandBuffer();

                VkBufferCopy copyRegion = new VkBufferCopy
                {
                    dstOffset = bufferOffsetInBytes,
                    size = sizeInBytes
                };
                vkCmdCopyBuffer(cb, copySrcVkBuffer.DeviceBuffer, vkBuffer.DeviceBuffer, 1, ref copyRegion);

                pool.EndAndSubmit(cb);
                lock (_stagingResourcesLock)
                {
                    _submittedStagingBuffers.Add(cb, copySrcVkBuffer);
                }
            }
        }

        /// <summary>
        /// Gets the free command pool
        /// </summary>
        /// <returns>The shared pool</returns>
        private SharedCommandPool GetFreeCommandPool()
        {
            SharedCommandPool sharedPool = null;
            lock (_graphicsCommandPoolLock)
            {
                if (_sharedGraphicsCommandPools.Count > 0)
                    sharedPool = _sharedGraphicsCommandPools.Pop();
            }

            if (sharedPool == null)
                sharedPool = new SharedCommandPool(this, false);

            return sharedPool;
        }

        /// <summary>
        /// Maps the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="numBytes">The num bytes</param>
        /// <returns>The int ptr</returns>
        private IntPtr MapBuffer(VkBuffer buffer, uint numBytes)
        {
            if (buffer.Memory.IsPersistentMapped)
            {
                return (IntPtr)buffer.Memory.BlockMappedPointer;
            }
            else
            {
                void* mappedPtr;
                VkResult result = vkMapMemory(Device, buffer.Memory.DeviceMemory, buffer.Memory.Offset, numBytes, 0, &mappedPtr);
                CheckResult(result);
                return (IntPtr)mappedPtr;
            }
        }

        /// <summary>
        /// Unmaps the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        private void UnmapBuffer(VkBuffer buffer)
        {
            if (!buffer.Memory.IsPersistentMapped)
            {
                vkUnmapMemory(Device, buffer.Memory.DeviceMemory);
            }
        }

        /// <summary>
        /// Updates the texture core using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        private protected override void UpdateTextureCore(
            Texture texture,
            IntPtr source,
            uint sizeInBytes,
            uint x,
            uint y,
            uint z,
            uint width,
            uint height,
            uint depth,
            uint mipLevel,
            uint arrayLayer)
        {
            VkTexture vkTex = Util.AssertSubtype<Texture, VkTexture>(texture);
            bool isStaging = (vkTex.Usage & TextureUsage.Staging) != 0;
            if (isStaging)
            {
                VkMemoryBlock memBlock = vkTex.Memory;
                uint subresource = texture.CalculateSubresource(mipLevel, arrayLayer);
                VkSubresourceLayout layout = vkTex.GetSubresourceLayout(subresource);
                byte* imageBasePtr = (byte*)memBlock.BlockMappedPointer + layout.offset;

                uint srcRowPitch = FormatHelpers.GetRowPitch(width, texture.Format);
                uint srcDepthPitch = FormatHelpers.GetDepthPitch(srcRowPitch, height, texture.Format);
                Util.CopyTextureRegion(
                    source.ToPointer(),
                    0, 0, 0,
                    srcRowPitch, srcDepthPitch,
                    imageBasePtr,
                    x, y, z,
                    (uint)layout.rowPitch, (uint)layout.depthPitch,
                    width, height, depth,
                    texture.Format);
            }
            else
            {
                VkTexture stagingTex = GetFreeStagingTexture(width, height, depth, texture.Format);
                UpdateTexture(stagingTex, source, sizeInBytes, 0, 0, 0, width, height, depth, 0, 0);
                SharedCommandPool pool = GetFreeCommandPool();
                VkCommandBuffer cb = pool.BeginNewCommandBuffer();
                VkCommandList.CopyTextureCore_VkCommandBuffer(
                    cb,
                    stagingTex, 0, 0, 0, 0, 0,
                    texture, x, y, z, mipLevel, arrayLayer,
                    width, height, depth, 1);
                lock (_stagingResourcesLock)
                {
                    _submittedStagingTextures.Add(cb, stagingTex);
                }
                pool.EndAndSubmit(cb);
            }
        }

        /// <summary>
        /// Gets the free staging texture using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The new tex</returns>
        private VkTexture GetFreeStagingTexture(uint width, uint height, uint depth, PixelFormat format)
        {
            uint totalSize = FormatHelpers.GetRegionSize(width, height, depth, format);
            lock (_stagingResourcesLock)
            {
                for (int i = 0; i < _availableStagingTextures.Count; i++)
                {
                    VkTexture tex = _availableStagingTextures[i];
                    if (tex.Memory.Size >= totalSize)
                    {
                        _availableStagingTextures.RemoveAt(i);
                        tex.SetStagingDimensions(width, height, depth, format);
                        return tex;
                    }
                }
            }

            uint texWidth = Math.Max(256, width);
            uint texHeight = Math.Max(256, height);
            VkTexture newTex = (VkTexture)ResourceFactory.CreateTexture(TextureDescription.Texture3D(
                texWidth, texHeight, depth, 1, format, TextureUsage.Staging));
            newTex.SetStagingDimensions(width, height, depth, format);

            return newTex;
        }

        /// <summary>
        /// Gets the free staging buffer using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The new buffer</returns>
        private VkBuffer GetFreeStagingBuffer(uint size)
        {
            lock (_stagingResourcesLock)
            {
                for (int i = 0; i < _availableStagingBuffers.Count; i++)
                {
                    VkBuffer buffer = _availableStagingBuffers[i];
                    if (buffer.SizeInBytes >= size)
                    {
                        _availableStagingBuffers.RemoveAt(i);
                        return buffer;
                    }
                }
            }

            uint newBufferSize = Math.Max(MinStagingBufferSize, size);
            VkBuffer newBuffer = (VkBuffer)ResourceFactory.CreateBuffer(
                new BufferDescription(newBufferSize, BufferUsage.Staging));
            return newBuffer;
        }

        /// <summary>
        /// Resets the fence using the specified fence
        /// </summary>
        /// <param name="fence">The fence</param>
        public override void ResetFence(Fence fence)
        {
            Vulkan.VkFence vkFence = Util.AssertSubtype<Fence, VkFence>(fence).DeviceFence;
            vkResetFences(_device, 1, ref vkFence);
        }

        /// <summary>
        /// Describes whether this instance wait for fence
        /// </summary>
        /// <param name="fence">The fence</param>
        /// <param name="nanosecondTimeout">The nanosecond timeout</param>
        /// <returns>The bool</returns>
        public override bool WaitForFence(Fence fence, ulong nanosecondTimeout)
        {
            Vulkan.VkFence vkFence = Util.AssertSubtype<Fence, VkFence>(fence).DeviceFence;
            VkResult result = vkWaitForFences(_device, 1, ref vkFence, true, nanosecondTimeout);
            return result == VkResult.Success;
        }

        /// <summary>
        /// Describes whether this instance wait for fences
        /// </summary>
        /// <param name="fences">The fences</param>
        /// <param name="waitAll">The wait all</param>
        /// <param name="nanosecondTimeout">The nanosecond timeout</param>
        /// <returns>The bool</returns>
        public override bool WaitForFences(Fence[] fences, bool waitAll, ulong nanosecondTimeout)
        {
            int fenceCount = fences.Length;
            Vulkan.VkFence* fencesPtr = stackalloc Vulkan.VkFence[fenceCount];
            for (int i = 0; i < fenceCount; i++)
            {
                fencesPtr[i] = Util.AssertSubtype<Fence, VkFence>(fences[i]).DeviceFence;
            }

            VkResult result = vkWaitForFences(_device, (uint)fenceCount, fencesPtr, waitAll, nanosecondTimeout);
            return result == VkResult.Success;
        }

        /// <summary>
        /// Describes whether is supported
        /// </summary>
        /// <returns>The bool</returns>
        internal static bool IsSupported()
        {
            return s_isSupported.Value;
        }

        /// <summary>
        /// Describes whether check is supported
        /// </summary>
        /// <returns>The bool</returns>
        private static bool CheckIsSupported()
        {
            if (!IsVulkanLoaded())
            {
                return false;
            }

            VkInstanceCreateInfo instanceCI = VkInstanceCreateInfo.New();
            VkApplicationInfo applicationInfo = new VkApplicationInfo();
            applicationInfo.apiVersion = new VkVersion(1, 0, 0);
            applicationInfo.applicationVersion = new VkVersion(1, 0, 0);
            applicationInfo.engineVersion = new VkVersion(1, 0, 0);
            applicationInfo.pApplicationName = s_name;
            applicationInfo.pEngineName = s_name;

            instanceCI.pApplicationInfo = &applicationInfo;

            VkResult result = vkCreateInstance(ref instanceCI, null, out VkInstance testInstance);
            if (result != VkResult.Success)
            {
                return false;
            }

            uint physicalDeviceCount = 0;
            result = vkEnumeratePhysicalDevices(testInstance, ref physicalDeviceCount, null);
            if (result != VkResult.Success || physicalDeviceCount == 0)
            {
                vkDestroyInstance(testInstance, null);
                return false;
            }

            vkDestroyInstance(testInstance, null);

            HashSet<string> instanceExtensions = new HashSet<string>(GetInstanceExtensions());
            if (!instanceExtensions.Contains(CommonStrings.VK_KHR_SURFACE_EXTENSION_NAME))
            {
                return false;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return instanceExtensions.Contains(CommonStrings.VK_KHR_WIN32_SURFACE_EXTENSION_NAME);
            }
#if NET5_0_OR_GREATER
            else if (OperatingSystem.IsAndroid())
            {
                return instanceExtensions.Contains(CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME);
            }
#endif
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (RuntimeInformation.OSDescription.Contains("Unix")) // Android
                {
                    return instanceExtensions.Contains(CommonStrings.VK_KHR_ANDROID_SURFACE_EXTENSION_NAME);
                }
                else
                {
                    return instanceExtensions.Contains(CommonStrings.VK_KHR_XLIB_SURFACE_EXTENSION_NAME);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (RuntimeInformation.OSDescription.Contains("Darwin")) // macOS
                {
                    return instanceExtensions.Contains(CommonStrings.VK_MVK_MACOS_SURFACE_EXTENSION_NAME);
                }
                else // iOS
                {
                    return instanceExtensions.Contains(CommonStrings.VK_MVK_IOS_SURFACE_EXTENSION_NAME);
                }
            }

            return false;
        }

        /// <summary>
        /// Clears the color texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="color">The color</param>
        internal void ClearColorTexture(VkTexture texture, VkClearColorValue color)
        {
            uint effectiveLayers = texture.ArrayLayers;
            if ((texture.Usage & TextureUsage.Cubemap) != 0)
            {
                effectiveLayers *= 6;
            }
            VkImageSubresourceRange range = new VkImageSubresourceRange(
                 VkImageAspectFlags.Color,
                 0,
                 texture.MipLevels,
                 0,
                 effectiveLayers);
            SharedCommandPool pool = GetFreeCommandPool();
            VkCommandBuffer cb = pool.BeginNewCommandBuffer();
            texture.TransitionImageLayout(cb, 0, texture.MipLevels, 0, effectiveLayers, VkImageLayout.TransferDstOptimal);
            vkCmdClearColorImage(cb, texture.OptimalDeviceImage, VkImageLayout.TransferDstOptimal, &color, 1, &range);
            VkImageLayout colorLayout = texture.IsSwapchainTexture ? VkImageLayout.PresentSrcKHR : VkImageLayout.ColorAttachmentOptimal;
            texture.TransitionImageLayout(cb, 0, texture.MipLevels, 0, effectiveLayers, colorLayout);
            pool.EndAndSubmit(cb);
        }

        /// <summary>
        /// Clears the depth texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="clearValue">The clear value</param>
        internal void ClearDepthTexture(VkTexture texture, VkClearDepthStencilValue clearValue)
        {
            uint effectiveLayers = texture.ArrayLayers;
            if ((texture.Usage & TextureUsage.Cubemap) != 0)
            {
                effectiveLayers *= 6;
            }
            VkImageAspectFlags aspect = FormatHelpers.IsStencilFormat(texture.Format)
                ? VkImageAspectFlags.Depth | VkImageAspectFlags.Stencil
                : VkImageAspectFlags.Depth;
            VkImageSubresourceRange range = new VkImageSubresourceRange(
                aspect,
                0,
                texture.MipLevels,
                0,
                effectiveLayers);
            SharedCommandPool pool = GetFreeCommandPool();
            VkCommandBuffer cb = pool.BeginNewCommandBuffer();
            texture.TransitionImageLayout(cb, 0, texture.MipLevels, 0, effectiveLayers, VkImageLayout.TransferDstOptimal);
            vkCmdClearDepthStencilImage(
                cb,
                texture.OptimalDeviceImage,
                VkImageLayout.TransferDstOptimal,
                &clearValue,
                1,
                &range);
            texture.TransitionImageLayout(cb, 0, texture.MipLevels, 0, effectiveLayers, VkImageLayout.DepthStencilAttachmentOptimal);
            pool.EndAndSubmit(cb);
        }

        /// <summary>
        /// Gets the uniform buffer min offset alignment core
        /// </summary>
        /// <returns>The uint</returns>
        internal override uint GetUniformBufferMinOffsetAlignmentCore()
            => (uint)_physicalDeviceProperties.limits.minUniformBufferOffsetAlignment;

        /// <summary>
        /// Gets the structured buffer min offset alignment core
        /// </summary>
        /// <returns>The uint</returns>
        internal override uint GetStructuredBufferMinOffsetAlignmentCore()
            => (uint)_physicalDeviceProperties.limits.minStorageBufferOffsetAlignment;

        /// <summary>
        /// Transitions the image layout using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="layout">The layout</param>
        internal void TransitionImageLayout(VkTexture texture, VkImageLayout layout)
        {
            SharedCommandPool pool = GetFreeCommandPool();
            VkCommandBuffer cb = pool.BeginNewCommandBuffer();
            texture.TransitionImageLayout(cb, 0, texture.MipLevels, 0, texture.ActualArrayLayers, layout);
            pool.EndAndSubmit(cb);
        }

        /// <summary>
        /// The shared command pool class
        /// </summary>
        private class SharedCommandPool
        {
            /// <summary>
            /// The gd
            /// </summary>
            private readonly VkGraphicsDevice _gd;
            /// <summary>
            /// The pool
            /// </summary>
            private readonly VkCommandPool _pool;
            /// <summary>
            /// The cb
            /// </summary>
            private readonly VkCommandBuffer _cb;

            /// <summary>
            /// Gets the value of the is cached
            /// </summary>
            public bool IsCached { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="SharedCommandPool"/> class
            /// </summary>
            /// <param name="gd">The gd</param>
            /// <param name="isCached">The is cached</param>
            public SharedCommandPool(VkGraphicsDevice gd, bool isCached)
            {
                _gd = gd;
                IsCached = isCached;

                VkCommandPoolCreateInfo commandPoolCI = VkCommandPoolCreateInfo.New();
                commandPoolCI.flags = VkCommandPoolCreateFlags.Transient | VkCommandPoolCreateFlags.ResetCommandBuffer;
                commandPoolCI.queueFamilyIndex = _gd.GraphicsQueueIndex;
                VkResult result = vkCreateCommandPool(_gd.Device, ref commandPoolCI, null, out _pool);
                CheckResult(result);

                VkCommandBufferAllocateInfo allocateInfo = VkCommandBufferAllocateInfo.New();
                allocateInfo.commandBufferCount = 1;
                allocateInfo.level = VkCommandBufferLevel.Primary;
                allocateInfo.commandPool = _pool;
                result = vkAllocateCommandBuffers(_gd.Device, ref allocateInfo, out _cb);
                CheckResult(result);
            }

            /// <summary>
            /// Begins the new command buffer
            /// </summary>
            /// <returns>The cb</returns>
            public VkCommandBuffer BeginNewCommandBuffer()
            {
                VkCommandBufferBeginInfo beginInfo = VkCommandBufferBeginInfo.New();
                beginInfo.flags = VkCommandBufferUsageFlags.OneTimeSubmit;
                VkResult result = vkBeginCommandBuffer(_cb, ref beginInfo);
                CheckResult(result);

                return _cb;
            }

            /// <summary>
            /// Ends the and submit using the specified cb
            /// </summary>
            /// <param name="cb">The cb</param>
            public void EndAndSubmit(VkCommandBuffer cb)
            {
                VkResult result = vkEndCommandBuffer(cb);
                CheckResult(result);
                _gd.SubmitCommandBuffer(null, cb, 0, null, 0, null, null);
                lock (_gd._stagingResourcesLock)
                {
                    _gd._submittedSharedCommandPools.Add(cb, this);
                }
            }

            /// <summary>
            /// Destroys this instance
            /// </summary>
            internal void Destroy()
            {
                vkDestroyCommandPool(_gd.Device, _pool, null);
            }
        }

        /// <summary>
        /// The fence submission info
        /// </summary>
        private struct FenceSubmissionInfo
        {
            /// <summary>
            /// The fence
            /// </summary>
            public Vulkan.VkFence Fence;
            /// <summary>
            /// The command list
            /// </summary>
            public VkCommandList CommandList;
            /// <summary>
            /// The command buffer
            /// </summary>
            public VkCommandBuffer CommandBuffer;
            /// <summary>
            /// Initializes a new instance of the <see cref="FenceSubmissionInfo"/> class
            /// </summary>
            /// <param name="fence">The fence</param>
            /// <param name="commandList">The command list</param>
            /// <param name="commandBuffer">The command buffer</param>
            public FenceSubmissionInfo(Vulkan.VkFence fence, VkCommandList commandList, VkCommandBuffer commandBuffer)
            {
                Fence = fence;
                CommandList = commandList;
                CommandBuffer = commandBuffer;
            }
        }
    }

    /// <summary>
    /// The vkcreatedebugreportcallbackext
    /// </summary>
    internal unsafe delegate VkResult vkCreateDebugReportCallbackEXT_d(
        VkInstance instance,
        VkDebugReportCallbackCreateInfoEXT* createInfo,
        IntPtr allocatorPtr,
        out VkDebugReportCallbackEXT ret);

    /// <summary>
    /// The vkdestroydebugreportcallbackext
    /// </summary>
    internal unsafe delegate void vkDestroyDebugReportCallbackEXT_d(
        VkInstance instance,
        VkDebugReportCallbackEXT callback,
        VkAllocationCallbacks* pAllocator);

    /// <summary>
    /// The vkdebugmarkersetobjectnameext
    /// </summary>
    internal unsafe delegate VkResult vkDebugMarkerSetObjectNameEXT_t(VkDevice device, VkDebugMarkerObjectNameInfoEXT* pNameInfo);
    /// <summary>
    /// The vkcmddebugmarkerbeginext
    /// </summary>
    internal unsafe delegate void vkCmdDebugMarkerBeginEXT_t(VkCommandBuffer commandBuffer, VkDebugMarkerMarkerInfoEXT* pMarkerInfo);
    /// <summary>
    /// The vkcmddebugmarkerendext
    /// </summary>
    internal unsafe delegate void vkCmdDebugMarkerEndEXT_t(VkCommandBuffer commandBuffer);
    /// <summary>
    /// The vkcmddebugmarkerinsertext
    /// </summary>
    internal unsafe delegate void vkCmdDebugMarkerInsertEXT_t(VkCommandBuffer commandBuffer, VkDebugMarkerMarkerInfoEXT* pMarkerInfo);

    /// <summary>
    /// The vkgetbuffermemoryrequirements2
    /// </summary>
    internal unsafe delegate void vkGetBufferMemoryRequirements2_t(VkDevice device, VkBufferMemoryRequirementsInfo2KHR* pInfo, VkMemoryRequirements2KHR* pMemoryRequirements);
    /// <summary>
    /// The vkgetimagememoryrequirements2
    /// </summary>
    internal unsafe delegate void vkGetImageMemoryRequirements2_t(VkDevice device, VkImageMemoryRequirementsInfo2KHR* pInfo, VkMemoryRequirements2KHR* pMemoryRequirements);

    /// <summary>
    /// The vkgetphysicaldeviceproperties2
    /// </summary>
    internal unsafe delegate void vkGetPhysicalDeviceProperties2_t(VkPhysicalDevice physicalDevice, void* properties);

    // VK_EXT_metal_surface

    /// <summary>
    /// The vkcreatemetalsurfaceext
    /// </summary>
    internal unsafe delegate VkResult vkCreateMetalSurfaceEXT_t(
        VkInstance instance,
        VkMetalSurfaceCreateInfoEXT* pCreateInfo,
        VkAllocationCallbacks* pAllocator,
        VkSurfaceKHR* pSurface);

    /// <summary>
    /// The vk metal surface create info ext
    /// </summary>
    internal unsafe struct VkMetalSurfaceCreateInfoEXT
    {
        /// <summary>
        /// The vk structure type
        /// </summary>
        public const VkStructureType VK_STRUCTURE_TYPE_METAL_SURFACE_CREATE_INFO_EXT = (VkStructureType)1000217000;

        /// <summary>
        /// The type
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// The next
        /// </summary>
        public void* pNext;
        /// <summary>
        /// The flags
        /// </summary>
        public uint flags;
        /// <summary>
        /// The layer
        /// </summary>
        public void* pLayer;
    }

    /// <summary>
    /// The vk physical device driver properties
    /// </summary>
    internal unsafe struct VkPhysicalDeviceDriverProperties
    {
        /// <summary>
        /// The driver name length
        /// </summary>
        public const int DriverNameLength = 256;
        /// <summary>
        /// The driver info length
        /// </summary>
        public const int DriverInfoLength = 256;
        /// <summary>
        /// The vk structure type
        /// </summary>
        public const VkStructureType VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES = (VkStructureType)1000196000;

        /// <summary>
        /// The type
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// The next
        /// </summary>
        public void* pNext;
        /// <summary>
        /// The driver id
        /// </summary>
        public VkDriverId driverID;
        /// <summary>
        /// The driver name length
        /// </summary>
        public fixed byte driverName[DriverNameLength];
        /// <summary>
        /// The driver info length
        /// </summary>
        public fixed byte driverInfo[DriverInfoLength];
        /// <summary>
        /// The conformance version
        /// </summary>
        public VkConformanceVersion conformanceVersion;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The vk physical device driver properties</returns>
        public static VkPhysicalDeviceDriverProperties New()
        {
            return new VkPhysicalDeviceDriverProperties() { sType = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES };
        }
    }

    /// <summary>
    /// The vk driver id enum
    /// </summary>
    internal enum VkDriverId
    {
    }

    /// <summary>
    /// The vk conformance version
    /// </summary>
    internal struct VkConformanceVersion
    {
        /// <summary>
        /// The major
        /// </summary>
        public byte major;
        /// <summary>
        /// The minor
        /// </summary>
        public byte minor;
        /// <summary>
        /// The subminor
        /// </summary>
        public byte subminor;
        /// <summary>
        /// The patch
        /// </summary>
        public byte patch;
    }
}
