using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using NativeLibrary = NativeLibraryLoader.NativeLibrary;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl graphics device class
    /// </summary>
    /// <seealso cref="GraphicsDevice"/>
    internal unsafe class MTLGraphicsDevice : GraphicsDevice
    {
        /// <summary>
        /// The get is supported
        /// </summary>
        private static readonly Lazy<bool> s_isSupported = new Lazy<bool>(GetIsSupported);
        /// <summary>
        /// The mtl graphics device
        /// </summary>
        private static readonly Dictionary<IntPtr, MTLGraphicsDevice> s_aotRegisteredBlocks
            = new Dictionary<IntPtr, MTLGraphicsDevice>();

        /// <summary>
        /// The device
        /// </summary>
        private readonly MTLDevice _device;
        /// <summary>
        /// The device name
        /// </summary>
        private readonly string _deviceName;
        /// <summary>
        /// The api version
        /// </summary>
        private readonly GraphicsApiVersion _apiVersion;
        /// <summary>
        /// The command queue
        /// </summary>
        private readonly MTLCommandQueue _commandQueue;
        /// <summary>
        /// The main swapchain
        /// </summary>
        private readonly MTLSwapchain _mainSwapchain;
        /// <summary>
        /// The supported sample counts
        /// </summary>
        private readonly bool[] _supportedSampleCounts;
        /// <summary>
        /// The metal info
        /// </summary>
        private BackendInfoMetal _metalInfo;

        /// <summary>
        /// The submitted commands lock
        /// </summary>
        private readonly object _submittedCommandsLock = new object();
        /// <summary>
        /// The mtl fence
        /// </summary>
        private readonly Dictionary<MTLCommandBuffer, MTLFence> _submittedCBs = new Dictionary<MTLCommandBuffer, MTLFence>();
        /// <summary>
        /// The latest submitted cb
        /// </summary>
        private MTLCommandBuffer _latestSubmittedCB;

        /// <summary>
        /// The reset events lock
        /// </summary>
        private readonly object _resetEventsLock = new object();
        /// <summary>
        /// The manual reset event
        /// </summary>
        private readonly List<ManualResetEvent[]> _resetEvents = new List<ManualResetEvent[]>();

        /// <summary>
        /// The unaligned buffer copy pipeline mac os name
        /// </summary>
        private const string UnalignedBufferCopyPipelineMacOSName = "MTL_UnalignedBufferCopy_macOS";
        /// <summary>
        /// The unaligned buffer copy pipelinei os name
        /// </summary>
        private const string UnalignedBufferCopyPipelineiOSName = "MTL_UnalignedBufferCopy_iOS";
        /// <summary>
        /// The unaligned buffer copy pipeline lock
        /// </summary>
        private readonly object _unalignedBufferCopyPipelineLock = new object();
        /// <summary>
        /// The lib system
        /// </summary>
        private readonly NativeLibrary _libSystem;
        /// <summary>
        /// The concrete global block
        /// </summary>
        private readonly IntPtr _concreteGlobalBlock;
        /// <summary>
        /// The unaligned buffer copy shader
        /// </summary>
        private MTLShader _unalignedBufferCopyShader;
        /// <summary>
        /// The unaligned buffer copy pipeline
        /// </summary>
        private MTLComputePipelineState _unalignedBufferCopyPipeline;
        /// <summary>
        /// The completion handler
        /// </summary>
        private MTLCommandBufferHandler _completionHandler;
        /// <summary>
        /// The completion handler func ptr
        /// </summary>
        private readonly IntPtr _completionHandlerFuncPtr;
        /// <summary>
        /// The completion block descriptor
        /// </summary>
        private readonly IntPtr _completionBlockDescriptor;
        /// <summary>
        /// The completion block literal
        /// </summary>
        private readonly IntPtr _completionBlockLiteral;

        /// <summary>
        /// Gets the value of the device
        /// </summary>
        public MTLDevice Device => _device;
        /// <summary>
        /// Gets the value of the command queue
        /// </summary>
        public MTLCommandQueue CommandQueue => _commandQueue;
        /// <summary>
        /// Gets the value of the metal features
        /// </summary>
        public MTLFeatureSupport MetalFeatures { get; }
        /// <summary>
        /// Gets the value of the resource binding model
        /// </summary>
        public ResourceBindingModel ResourceBindingModel { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLGraphicsDevice"/> class
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="swapchainDesc">The swapchain desc</param>
        public MTLGraphicsDevice(
            GraphicsDeviceOptions options,
            SwapchainDescription? swapchainDesc)
        {
            _device = MTLDevice.MTLCreateSystemDefaultDevice();
            _deviceName = _device.name;
            MetalFeatures = new MTLFeatureSupport(_device);

            int major = (int)MetalFeatures.MaxFeatureSet / 10000;
            int minor = (int)MetalFeatures.MaxFeatureSet % 10000;
            _apiVersion = new GraphicsApiVersion(major, minor, 0, 0);

            Features = new GraphicsDeviceFeatures(
                computeShader: true,
                geometryShader: false,
                tessellationShaders: false,
                multipleViewports: MetalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v3),
                samplerLodBias: false,
                drawBaseVertex: MetalFeatures.IsDrawBaseVertexInstanceSupported(),
                drawBaseInstance: MetalFeatures.IsDrawBaseVertexInstanceSupported(),
                drawIndirect: true,
                drawIndirectBaseInstance: true,
                fillModeWireframe: true,
                samplerAnisotropy: true,
                depthClipDisable: true,
                texture1D: true, // TODO: Should be macOS 10.11+ and iOS 11.0+.
                independentBlend: true,
                structuredBuffer: true,
                subsetTextureView: true,
                commandListDebugMarkers: true,
                bufferRangeBinding: true,
                shaderFloat64: false);
            ResourceBindingModel = options.ResourceBindingModel;

            _libSystem = new NativeLibrary("libSystem.dylib");
            _concreteGlobalBlock = _libSystem.LoadFunction("_NSConcreteGlobalBlock");
            if (MetalFeatures.IsMacOS)
            {
                _completionHandler = OnCommandBufferCompleted;
            }
            else
            {
                _completionHandler = OnCommandBufferCompleted_Static;
            }
            _completionHandlerFuncPtr = Marshal.GetFunctionPointerForDelegate<MTLCommandBufferHandler>(_completionHandler);
            _completionBlockDescriptor = Marshal.AllocHGlobal(Unsafe.SizeOf<BlockDescriptor>());
            BlockDescriptor* descriptorPtr = (BlockDescriptor*)_completionBlockDescriptor;
            descriptorPtr->reserved = 0;
            descriptorPtr->Block_size = (ulong)Unsafe.SizeOf<BlockDescriptor>();

            _completionBlockLiteral = Marshal.AllocHGlobal(Unsafe.SizeOf<BlockLiteral>());
            BlockLiteral* blockPtr = (BlockLiteral*)_completionBlockLiteral;
            blockPtr->isa = _concreteGlobalBlock;
            blockPtr->flags = 1 << 28 | 1 << 29;
            blockPtr->invoke = _completionHandlerFuncPtr;
            blockPtr->descriptor = descriptorPtr;

            if (!MetalFeatures.IsMacOS)
            {
                lock (s_aotRegisteredBlocks)
                {
                    s_aotRegisteredBlocks.Add(_completionBlockLiteral, this);
                }
            }

            ResourceFactory = new MTLResourceFactory(this);
            _commandQueue = _device.newCommandQueue();

            TextureSampleCount[] allSampleCounts = (TextureSampleCount[])Enum.GetValues(typeof(TextureSampleCount));
            _supportedSampleCounts = new bool[allSampleCounts.Length];
            for (int i = 0; i < allSampleCounts.Length; i++)
            {
                TextureSampleCount count = allSampleCounts[i];
                uint uintValue = FormatHelpers.GetSampleCountUInt32(count);
                if (_device.supportsTextureSampleCount((UIntPtr)uintValue))
                {
                    _supportedSampleCounts[i] = true;
                }
            }

            if (swapchainDesc != null)
            {
                SwapchainDescription desc = swapchainDesc.Value;
                _mainSwapchain = new MTLSwapchain(this, ref desc);
            }

            _metalInfo = new BackendInfoMetal(this);

            PostDeviceCreated();
        }

        /// <summary>
        /// Gets the value of the device name
        /// </summary>
        public override string DeviceName => _deviceName;

        /// <summary>
        /// Gets the value of the vendor name
        /// </summary>
        public override string VendorName => "Apple";

        /// <summary>
        /// Gets the value of the api version
        /// </summary>
        public override GraphicsApiVersion ApiVersion => _apiVersion;

        /// <summary>
        /// Gets the value of the backend type
        /// </summary>
        public override GraphicsBackend BackendType => GraphicsBackend.Metal;

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
        public override bool IsClipSpaceYInverted => false;

        /// <summary>
        /// Gets the value of the resource factory
        /// </summary>
        public override ResourceFactory ResourceFactory { get; }

        /// <summary>
        /// Gets the value of the main swapchain
        /// </summary>
        public override Swapchain MainSwapchain => _mainSwapchain;

        /// <summary>
        /// Gets the value of the features
        /// </summary>
        public override GraphicsDeviceFeatures Features { get; }

        /// <summary>
        /// Ons the command buffer completed using the specified block
        /// </summary>
        /// <param name="block">The block</param>
        /// <param name="cb">The cb</param>
        private void OnCommandBufferCompleted(IntPtr block, MTLCommandBuffer cb)
        {
            lock (_submittedCommandsLock)
            {
                if (_submittedCBs.TryGetValue(cb, out MTLFence fence))
                {
                    fence.Set();
                    _submittedCBs.Remove(cb);
                }

                if (_latestSubmittedCB.NativePtr == cb.NativePtr)
                {
                    _latestSubmittedCB = default(MTLCommandBuffer);
                }
            }

            ObjectiveCRuntime.release(cb.NativePtr);
        }

        // Xamarin AOT requires native callbacks be static.
        /// <summary>
        /// Ons the command buffer completed static using the specified block
        /// </summary>
        /// <param name="block">The block</param>
        /// <param name="cb">The cb</param>
        [MonoPInvokeCallback(typeof(MTLCommandBufferHandler))]
        private static void OnCommandBufferCompleted_Static(IntPtr block, MTLCommandBuffer cb)
        {
            lock (s_aotRegisteredBlocks)
            {
                if (s_aotRegisteredBlocks.TryGetValue(block, out MTLGraphicsDevice gd))
                {
                    gd.OnCommandBufferCompleted(block, cb);
                }
            }
        }

        /// <summary>
        /// Submits the commands core using the specified command list
        /// </summary>
        /// <param name="commandList">The command list</param>
        /// <param name="fence">The fence</param>
        private protected override void SubmitCommandsCore(CommandList commandList, Fence fence)
        {
            MTLCommandList mtlCL = Util.AssertSubtype<CommandList, MTLCommandList>(commandList);

            mtlCL.CommandBuffer.addCompletedHandler(_completionBlockLiteral);
            lock (_submittedCommandsLock)
            {
                if (fence != null)
                {
                    MTLFence mtlFence = Util.AssertSubtype<Fence, MTLFence>(fence);
                    _submittedCBs.Add(mtlCL.CommandBuffer, mtlFence);
                }

                _latestSubmittedCB = mtlCL.Commit();
            }
        }

        /// <summary>
        /// Gets the sample count limit using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="depthFormat">The depth format</param>
        /// <returns>The texture sample count</returns>
        public override TextureSampleCount GetSampleCountLimit(PixelFormat format, bool depthFormat)
        {
            for (int i = _supportedSampleCounts.Length - 1; i >= 0; i--)
            {
                if (_supportedSampleCounts[i])
                {
                    return (TextureSampleCount)i;
                }
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
            if (!MTLFormats.IsFormatSupported(format, usage, MetalFeatures))
            {
                properties = default(PixelFormatProperties);
                return false;
            }

            uint sampleCounts = 0;

            for (int i = 0; i < _supportedSampleCounts.Length; i++)
            {
                if (_supportedSampleCounts[i])
                {
                    sampleCounts |= (uint)(1 << i);
                }
            }

            MTLFeatureSet maxFeatureSet = MetalFeatures.MaxFeatureSet;
            uint maxArrayLayer = MTLFormats.GetMaxTextureVolume(maxFeatureSet);
            uint maxWidth;
            uint maxHeight;
            uint maxDepth;
            if (type == TextureType.Texture1D)
            {
                maxWidth = MTLFormats.GetMaxTexture1DWidth(maxFeatureSet);
                maxHeight = 1;
                maxDepth = 1;
            }
            else if (type == TextureType.Texture2D)
            {
                uint maxDimensions;
                if ((usage & TextureUsage.Cubemap) != 0)
                {
                    maxDimensions = MTLFormats.GetMaxTextureCubeDimensions(maxFeatureSet);
                }
                else
                {
                    maxDimensions = MTLFormats.GetMaxTexture2DDimensions(maxFeatureSet);
                }

                maxWidth = maxDimensions;
                maxHeight = maxDimensions;
                maxDepth = 1;
            }
            else if (type == TextureType.Texture3D)
            {
                maxWidth = maxArrayLayer;
                maxHeight = maxArrayLayer;
                maxDepth = maxArrayLayer;
                maxArrayLayer = 1;
            }
            else
            {
                throw Illegal.Value<TextureType>();
            }

            properties = new PixelFormatProperties(
                maxWidth,
                maxHeight,
                maxDepth,
                uint.MaxValue,
                maxArrayLayer,
                sampleCounts);
            return true;
        }

        /// <summary>
        /// Swaps the buffers core using the specified swapchain
        /// </summary>
        /// <param name="swapchain">The swapchain</param>
        private protected override void SwapBuffersCore(Swapchain swapchain)
        {
            MTLSwapchain mtlSC = Util.AssertSubtype<Swapchain, MTLSwapchain>(swapchain);
            IntPtr currentDrawablePtr = mtlSC.CurrentDrawable.NativePtr;
            if (currentDrawablePtr != IntPtr.Zero)
            {
                using (NSAutoreleasePool.Begin())
                {
                    MTLCommandBuffer submitCB = _commandQueue.commandBuffer();
                    submitCB.presentDrawable(currentDrawablePtr);
                    submitCB.commit();
                }
            }

            mtlSC.GetNextDrawable();
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
            var mtlBuffer = Util.AssertSubtype<DeviceBuffer, MTLBuffer>(buffer);
            void* destPtr = mtlBuffer.DeviceBuffer.contents();
            byte* destOffsetPtr = (byte*)destPtr + bufferOffsetInBytes;
            Unsafe.CopyBlock(destOffsetPtr, source.ToPointer(), sizeInBytes);
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
            MTLTexture mtlTex = Util.AssertSubtype<Texture, MTLTexture>(texture);
            if (mtlTex.StagingBuffer.IsNull)
            {
                Texture stagingTex = ResourceFactory.CreateTexture(new TextureDescription(
                    width, height, depth, 1, 1, texture.Format, TextureUsage.Staging, texture.Type));
                UpdateTexture(stagingTex, source, sizeInBytes, 0, 0, 0, width, height, depth, 0, 0);
                CommandList cl = ResourceFactory.CreateCommandList();
                cl.Begin();
                cl.CopyTexture(
                    stagingTex, 0, 0, 0, 0, 0,
                    texture, x, y, z, mipLevel, arrayLayer,
                    width, height, depth, 1);
                cl.End();
                SubmitCommands(cl);

                cl.Dispose();
                stagingTex.Dispose();
            }
            else
            {
                mtlTex.GetSubresourceLayout(mipLevel, arrayLayer, out uint dstRowPitch, out uint dstDepthPitch);
                ulong dstOffset = Util.ComputeSubresourceOffset(mtlTex, mipLevel, arrayLayer);
                uint srcRowPitch = FormatHelpers.GetRowPitch(width, texture.Format);
                uint srcDepthPitch = FormatHelpers.GetDepthPitch(srcRowPitch, height, texture.Format);
                Util.CopyTextureRegion(
                    source.ToPointer(),
                    0, 0, 0,
                    srcRowPitch, srcDepthPitch,
                    (byte*)mtlTex.StagingBuffer.contents() + dstOffset,
                    x, y, z,
                    dstRowPitch, dstDepthPitch,
                    width, height, depth,
                    texture.Format);
            }
        }

        /// <summary>
        /// Waits the for idle core
        /// </summary>
        private protected override void WaitForIdleCore()
        {
            MTLCommandBuffer lastCB = default(MTLCommandBuffer);
            lock (_submittedCommandsLock)
            {
                lastCB = _latestSubmittedCB;
                ObjectiveCRuntime.retain(lastCB.NativePtr);
            }

            if (lastCB.NativePtr != IntPtr.Zero && lastCB.status != MTLCommandBufferStatus.Completed)
            {
                lastCB.waitUntilCompleted();
            }

            ObjectiveCRuntime.release(lastCB.NativePtr);
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
            if (resource is MTLBuffer buffer)
            {
                return MapBuffer(buffer, mode);
            }
            else
            {
                MTLTexture texture = Util.AssertSubtype<MappableResource, MTLTexture>(resource);
                return MapTexture(texture, mode, subresource);
            }
        }

        /// <summary>
        /// Maps the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="mode">The mode</param>
        /// <returns>The mapped resource</returns>
        private MappedResource MapBuffer(MTLBuffer buffer, MapMode mode)
        {
            void* data = buffer.DeviceBuffer.contents();
            return new MappedResource(
                buffer,
                mode,
                (IntPtr)data,
                buffer.SizeInBytes,
                0,
                buffer.SizeInBytes,
                buffer.SizeInBytes);
        }

        /// <summary>
        /// Maps the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="mode">The mode</param>
        /// <param name="subresource">The subresource</param>
        /// <returns>The mapped resource</returns>
        private MappedResource MapTexture(MTLTexture texture, MapMode mode, uint subresource)
        {
            Debug.Assert(!texture.StagingBuffer.IsNull);
            void* data = texture.StagingBuffer.contents();
            Util.GetMipLevelAndArrayLayer(texture, subresource, out uint mipLevel, out uint arrayLayer);
            Util.GetMipDimensions(texture, mipLevel, out uint width, out uint height, out uint depth);
            uint subresourceSize = texture.GetSubresourceSize(mipLevel, arrayLayer);
            texture.GetSubresourceLayout(mipLevel, arrayLayer, out uint rowPitch, out uint depthPitch);
            ulong offset = Util.ComputeSubresourceOffset(texture, mipLevel, arrayLayer);
            byte* offsetPtr = (byte*)data + offset;
            return new MappedResource(texture, mode, (IntPtr)offsetPtr, subresourceSize, subresource, rowPitch, depthPitch);
        }

        /// <summary>
        /// Platforms the dispose
        /// </summary>
        protected override void PlatformDispose()
        {
            WaitForIdle();
            if (!_unalignedBufferCopyPipeline.IsNull)
            {
                _unalignedBufferCopyShader.Dispose();
                ObjectiveCRuntime.release(_unalignedBufferCopyPipeline.NativePtr);
            }
            _mainSwapchain?.Dispose();
            ObjectiveCRuntime.release(_commandQueue.NativePtr);
            ObjectiveCRuntime.release(_device.NativePtr);

            lock (s_aotRegisteredBlocks)
            {
                s_aotRegisteredBlocks.Remove(_completionBlockLiteral);
            }

            _libSystem.Dispose();
            Marshal.FreeHGlobal(_completionBlockDescriptor);
            Marshal.FreeHGlobal(_completionBlockLiteral);
        }

        /// <summary>
        /// Describes whether this instance get metal info
        /// </summary>
        /// <param name="info">The info</param>
        /// <returns>The bool</returns>
        public override bool GetMetalInfo(out BackendInfoMetal info)
        {
            info = _metalInfo;
            return true;
        }

        /// <summary>
        /// Unmaps the core using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="subresource">The subresource</param>
        protected override void UnmapCore(MappableResource resource, uint subresource)
        {
        }

        /// <summary>
        /// Describes whether this instance wait for fence
        /// </summary>
        /// <param name="fence">The fence</param>
        /// <param name="nanosecondTimeout">The nanosecond timeout</param>
        /// <returns>The bool</returns>
        public override bool WaitForFence(Fence fence, ulong nanosecondTimeout)
        {
            return Util.AssertSubtype<Fence, MTLFence>(fence).Wait(nanosecondTimeout);
        }

        /// <summary>
        /// Describes whether this instance wait for fences
        /// </summary>
        /// <param name="fences">The fences</param>
        /// <param name="waitAll">The wait all</param>
        /// <param name="nanosecondTimeout">The nanosecond timeout</param>
        /// <returns>The result</returns>
        public override bool WaitForFences(Fence[] fences, bool waitAll, ulong nanosecondTimeout)
        {
            int msTimeout;
            if (nanosecondTimeout == ulong.MaxValue)
            {
                msTimeout = -1;
            }
            else
            {
                msTimeout = (int)Math.Min(nanosecondTimeout / 1_000_000, int.MaxValue);
            }

            ManualResetEvent[] events = GetResetEventArray(fences.Length);
            for (int i = 0; i < fences.Length; i++)
            {
                events[i] = Util.AssertSubtype<Fence, MTLFence>(fences[i]).ResetEvent;
            }
            bool result;
            if (waitAll)
            {
                result = WaitHandle.WaitAll(events, msTimeout);
            }
            else
            {
                int index = WaitHandle.WaitAny(events, msTimeout);
                result = index != WaitHandle.WaitTimeout;
            }

            ReturnResetEventArray(events);

            return result;
        }

        /// <summary>
        /// Gets the reset event array using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <returns>The new array</returns>
        private ManualResetEvent[] GetResetEventArray(int length)
        {
            lock (_resetEventsLock)
            {
                for (int i = _resetEvents.Count - 1; i > 0; i--)
                {
                    ManualResetEvent[] array = _resetEvents[i];
                    if (array.Length == length)
                    {
                        _resetEvents.RemoveAt(i);
                        return array;
                    }
                }
            }

            ManualResetEvent[] newArray = new ManualResetEvent[length];
            return newArray;
        }

        /// <summary>
        /// Returns the reset event array using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        private void ReturnResetEventArray(ManualResetEvent[] array)
        {
            lock (_resetEventsLock)
            {
                _resetEvents.Add(array);
            }
        }

        /// <summary>
        /// Resets the fence using the specified fence
        /// </summary>
        /// <param name="fence">The fence</param>
        public override void ResetFence(Fence fence)
        {
            Util.AssertSubtype<Fence, MTLFence>(fence).Reset();
        }

        /// <summary>
        /// Describes whether is supported
        /// </summary>
        /// <returns>The bool</returns>
        internal static bool IsSupported() => s_isSupported.Value;

        /// <summary>
        /// Describes whether get is supported
        /// </summary>
        /// <returns>The result</returns>
        private static bool GetIsSupported()
        {
            bool result = false;
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    if (RuntimeInformation.OSDescription.Contains("Darwin"))
                    {
                        NSArray allDevices = MTLDevice.MTLCopyAllDevices();
                        result |= (ulong)allDevices.count > 0;
                        ObjectiveCRuntime.release(allDevices.NativePtr);
                    }
                    else
                    {
                        MTLDevice defaultDevice = MTLDevice.MTLCreateSystemDefaultDevice();
                        if (defaultDevice.NativePtr != IntPtr.Zero)
                        {
                            result = true;
                            ObjectiveCRuntime.release(defaultDevice.NativePtr);
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Gets the unaligned buffer copy pipeline
        /// </summary>
        /// <returns>The mtl compute pipeline state</returns>
        internal MTLComputePipelineState GetUnalignedBufferCopyPipeline()
        {
            lock (_unalignedBufferCopyPipelineLock)
            {
                if (_unalignedBufferCopyPipeline.IsNull)
                {
                    MTLComputePipelineDescriptor descriptor = MTLUtil.AllocInit<MTLComputePipelineDescriptor>(
                       nameof(MTLComputePipelineDescriptor));
                    MTLPipelineBufferDescriptor buffer0 = descriptor.buffers[0];
                    buffer0.mutability = MTLMutability.Mutable;
                    MTLPipelineBufferDescriptor buffer1 = descriptor.buffers[1];
                    buffer0.mutability = MTLMutability.Mutable;

                    Debug.Assert(_unalignedBufferCopyShader == null);
                    string name = MetalFeatures.IsMacOS ? UnalignedBufferCopyPipelineMacOSName : UnalignedBufferCopyPipelineiOSName;
                    using (Stream resourceStream = typeof(MTLGraphicsDevice).Assembly.GetManifestResourceStream(name))
                    {
                        byte[] data = new byte[resourceStream.Length];
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            resourceStream.CopyTo(ms);
                            ShaderDescription shaderDesc = new ShaderDescription(ShaderStages.Compute, data, "copy_bytes");
                            _unalignedBufferCopyShader = new MTLShader(ref shaderDesc, this);
                        }
                    }

                    descriptor.computeFunction = _unalignedBufferCopyShader.Function;
                    _unalignedBufferCopyPipeline = _device.newComputePipelineStateWithDescriptor(descriptor);
                    ObjectiveCRuntime.release(descriptor.NativePtr);
                }

                return _unalignedBufferCopyPipeline;
            }
        }

        /// <summary>
        /// Gets the uniform buffer min offset alignment core
        /// </summary>
        /// <returns>The uint</returns>
        internal override uint GetUniformBufferMinOffsetAlignmentCore() => MetalFeatures.IsMacOS ? 16u : 256u;
        /// <summary>
        /// Gets the structured buffer min offset alignment core
        /// </summary>
        /// <returns>The uint</returns>
        internal override uint GetStructuredBufferMinOffsetAlignmentCore() => 16u;
    }

    /// <summary>
    /// The mono invoke callback attribute class
    /// </summary>
    /// <seealso cref="Attribute"/>
    internal sealed class MonoPInvokeCallbackAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonoPInvokeCallbackAttribute"/> class
        /// </summary>
        /// <param name="t">The </param>
        public MonoPInvokeCallbackAttribute(Type t) { }
    }
}
