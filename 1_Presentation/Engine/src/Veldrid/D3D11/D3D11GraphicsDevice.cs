using Vortice;
using Vortice.Direct3D11;
using Vortice.DXGI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Vortice.Mathematics;
using Vortice.Direct3D11.Debug;
using VorticeDXGI = Vortice.DXGI.DXGI;
using VorticeD3D11 = Vortice.Direct3D11.D3D11;
using Vortice.DXGI.Debug;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 graphics device class
    /// </summary>
    /// <seealso cref="GraphicsDevice"/>
    internal class D3D11GraphicsDevice : GraphicsDevice
    {
        /// <summary>
        /// The dxgi adapter
        /// </summary>
        private readonly IDXGIAdapter _dxgiAdapter;
        /// <summary>
        /// The device
        /// </summary>
        private readonly ID3D11Device _device;
        /// <summary>
        /// The device name
        /// </summary>
        private readonly string _deviceName;
        /// <summary>
        /// The vendor name
        /// </summary>
        private readonly string _vendorName;
        /// <summary>
        /// The api version
        /// </summary>
        private readonly GraphicsApiVersion _apiVersion;
        /// <summary>
        /// The device id
        /// </summary>
        private readonly int _deviceId;
        /// <summary>
        /// The immediate context
        /// </summary>
        private readonly ID3D11DeviceContext _immediateContext;
        /// <summary>
        /// The 3d 11 resource factory
        /// </summary>
        private readonly D3D11ResourceFactory _d3d11ResourceFactory;
        /// <summary>
        /// The main swapchain
        /// </summary>
        private readonly D3D11Swapchain _mainSwapchain;
        /// <summary>
        /// The supports concurrent resources
        /// </summary>
        private readonly bool _supportsConcurrentResources;
        /// <summary>
        /// The supports command lists
        /// </summary>
        private readonly bool _supportsCommandLists;
        /// <summary>
        /// The immediate context lock
        /// </summary>
        private readonly object _immediateContextLock = new object();
        /// <summary>
        /// The 3d 11 info
        /// </summary>
        private readonly BackendInfoD3D11 _d3d11Info;

        /// <summary>
        /// The mapped resource lock
        /// </summary>
        private readonly object _mappedResourceLock = new object();
        /// <summary>
        /// The mapped resource info
        /// </summary>
        private readonly Dictionary<MappedResourceCacheKey, MappedResourceInfo> _mappedResources
            = new Dictionary<MappedResourceCacheKey, MappedResourceInfo>();

        /// <summary>
        /// The staging resources lock
        /// </summary>
        private readonly object _stagingResourcesLock = new object();
        /// <summary>
        /// The 11 buffer
        /// </summary>
        private readonly List<D3D11Buffer> _availableStagingBuffers = new List<D3D11Buffer>();

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
        public override GraphicsBackend BackendType => GraphicsBackend.Direct3D11;

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
        public override ResourceFactory ResourceFactory => _d3d11ResourceFactory;

        /// <summary>
        /// Gets the value of the device
        /// </summary>
        public ID3D11Device Device => _device;

        /// <summary>
        /// Gets the value of the adapter
        /// </summary>
        public IDXGIAdapter Adapter => _dxgiAdapter;

        /// <summary>
        /// Gets the value of the is debug enabled
        /// </summary>
        public bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets the value of the supports concurrent resources
        /// </summary>
        public bool SupportsConcurrentResources => _supportsConcurrentResources;

        /// <summary>
        /// Gets the value of the supports command lists
        /// </summary>
        public bool SupportsCommandLists => _supportsCommandLists;

        /// <summary>
        /// Gets the value of the device id
        /// </summary>
        public int DeviceId => _deviceId;

        /// <summary>
        /// Gets the value of the main swapchain
        /// </summary>
        public override Swapchain MainSwapchain => _mainSwapchain;

        /// <summary>
        /// Gets the value of the features
        /// </summary>
        public override GraphicsDeviceFeatures Features { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11GraphicsDevice"/> class
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="d3D11DeviceOptions">The 11 device options</param>
        /// <param name="swapchainDesc">The swapchain desc</param>
        public D3D11GraphicsDevice(GraphicsDeviceOptions options, D3D11DeviceOptions d3D11DeviceOptions, SwapchainDescription? swapchainDesc)
            : this(MergeOptions(d3D11DeviceOptions, options), swapchainDesc)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11GraphicsDevice"/> class
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="swapchainDesc">The swapchain desc</param>
        public D3D11GraphicsDevice(D3D11DeviceOptions options, SwapchainDescription? swapchainDesc)
        {
            var flags = (DeviceCreationFlags)options.DeviceCreationFlags;
#if DEBUG
            flags |= DeviceCreationFlags.Debug;
#endif
            // If debug flag set but SDK layers aren't available we can't enable debug.
            if (0 != (flags & DeviceCreationFlags.Debug) && !Vortice.Direct3D11.D3D11.SdkLayersAvailable())
            {
                flags &= ~DeviceCreationFlags.Debug;
            }

            try
            {
                if (options.AdapterPtr != IntPtr.Zero)
                {
                    VorticeD3D11.D3D11CreateDevice(options.AdapterPtr,
                        Vortice.Direct3D.DriverType.Hardware,
                        flags,
                        new[]
                        {
                            Vortice.Direct3D.FeatureLevel.Level_11_1,
                            Vortice.Direct3D.FeatureLevel.Level_11_0,
                        },
                        out _device).CheckError();
                }
                else
                {
                    VorticeD3D11.D3D11CreateDevice(IntPtr.Zero,
                        Vortice.Direct3D.DriverType.Hardware,
                        flags,
                        new[]
                        {
                            Vortice.Direct3D.FeatureLevel.Level_11_1,
                            Vortice.Direct3D.FeatureLevel.Level_11_0,
                        },
                        out _device).CheckError();
                }
            }
            catch
            {
                VorticeD3D11.D3D11CreateDevice(IntPtr.Zero,
                    Vortice.Direct3D.DriverType.Hardware,
                    flags,
                    null,
                    out _device).CheckError();
            }

            using (IDXGIDevice dxgiDevice = _device.QueryInterface<IDXGIDevice>())
            {
                // Store a pointer to the DXGI adapter.
                // This is for the case of no preferred DXGI adapter, or fallback to WARP.
                dxgiDevice.GetAdapter(out _dxgiAdapter).CheckError();

                AdapterDescription desc = _dxgiAdapter.Description;
                _deviceName = desc.Description;
                _vendorName = "id:" + ((uint)desc.VendorId).ToString("x8");
                _deviceId = desc.DeviceId;
            }

            switch (_device.FeatureLevel)
            {
                case Vortice.Direct3D.FeatureLevel.Level_10_0:
                    _apiVersion = new GraphicsApiVersion(10, 0, 0, 0);
                    break;

                case Vortice.Direct3D.FeatureLevel.Level_10_1:
                    _apiVersion = new GraphicsApiVersion(10, 1, 0, 0);
                    break;

                case Vortice.Direct3D.FeatureLevel.Level_11_0:
                    _apiVersion = new GraphicsApiVersion(11, 0, 0, 0);
                    break;

                case Vortice.Direct3D.FeatureLevel.Level_11_1:
                    _apiVersion = new GraphicsApiVersion(11, 1, 0, 0);
                    break;

                case Vortice.Direct3D.FeatureLevel.Level_12_0:
                    _apiVersion = new GraphicsApiVersion(12, 0, 0, 0);
                    break;

                case Vortice.Direct3D.FeatureLevel.Level_12_1:
                    _apiVersion = new GraphicsApiVersion(12, 1, 0, 0);
                    break;

                case Vortice.Direct3D.FeatureLevel.Level_12_2:
                    _apiVersion = new GraphicsApiVersion(12, 2, 0, 0);
                    break;
            }

            if (swapchainDesc != null)
            {
                SwapchainDescription desc = swapchainDesc.Value;
                _mainSwapchain = new D3D11Swapchain(this, ref desc);
            }
            _immediateContext = _device.ImmediateContext;
            _device.CheckThreadingSupport(out _supportsConcurrentResources, out _supportsCommandLists);

            IsDebugEnabled = (flags & DeviceCreationFlags.Debug) != 0;

            Features = new GraphicsDeviceFeatures(
                computeShader: true,
                geometryShader: true,
                tessellationShaders: true,
                multipleViewports: true,
                samplerLodBias: true,
                drawBaseVertex: true,
                drawBaseInstance: true,
                drawIndirect: true,
                drawIndirectBaseInstance: true,
                fillModeWireframe: true,
                samplerAnisotropy: true,
                depthClipDisable: true,
                texture1D: true,
                independentBlend: true,
                structuredBuffer: true,
                subsetTextureView: true,
                commandListDebugMarkers: _device.FeatureLevel >= Vortice.Direct3D.FeatureLevel.Level_11_1,
                bufferRangeBinding: _device.FeatureLevel >= Vortice.Direct3D.FeatureLevel.Level_11_1,
                shaderFloat64: _device.CheckFeatureSupport<FeatureDataDoubles>(Vortice.Direct3D11.Feature.Doubles).DoublePrecisionFloatShaderOps);

            _d3d11ResourceFactory = new D3D11ResourceFactory(this);
            _d3d11Info = new BackendInfoD3D11(this);

            PostDeviceCreated();
        }

        /// <summary>
        /// Merges the options using the specified d 3 d 11 device options
        /// </summary>
        /// <param name="d3D11DeviceOptions">The 11 device options</param>
        /// <param name="options">The options</param>
        /// <returns>The 11 device options</returns>
        private static D3D11DeviceOptions MergeOptions(D3D11DeviceOptions d3D11DeviceOptions, GraphicsDeviceOptions options)
        {
            if (options.Debug)
            {
                d3D11DeviceOptions.DeviceCreationFlags |= (uint)DeviceCreationFlags.Debug;
            }

            return d3D11DeviceOptions;
        }

        /// <summary>
        /// Submits the commands core using the specified cl
        /// </summary>
        /// <param name="cl">The cl</param>
        /// <param name="fence">The fence</param>
        private protected override void SubmitCommandsCore(CommandList cl, Fence fence)
        {
            D3D11CommandList d3d11CL = Util.AssertSubtype<CommandList, D3D11CommandList>(cl);
            lock (_immediateContextLock)
            {
                if (d3d11CL.DeviceCommandList != null) // CommandList may have been reset in the meantime (resized swapchain).
                {
                    _immediateContext.ExecuteCommandList(d3d11CL.DeviceCommandList, false);
                    d3d11CL.OnCompleted();
                }
            }

            if (fence is D3D11Fence d3d11Fence)
            {
                d3d11Fence.Set();
            }
        }

        /// <summary>
        /// Swaps the buffers core using the specified swapchain
        /// </summary>
        /// <param name="swapchain">The swapchain</param>
        private protected override void SwapBuffersCore(Swapchain swapchain)
        {
            lock (_immediateContextLock)
            {
                D3D11Swapchain d3d11SC = Util.AssertSubtype<Swapchain, D3D11Swapchain>(swapchain);
                d3d11SC.DxgiSwapChain.Present(d3d11SC.SyncInterval, PresentFlags.None);
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
            Format dxgiFormat = D3D11Formats.ToDxgiFormat(format, depthFormat);
            if (CheckFormatMultisample(dxgiFormat, 32))
            {
                return TextureSampleCount.Count32;
            }
            else if (CheckFormatMultisample(dxgiFormat, 16))
            {
                return TextureSampleCount.Count16;
            }
            else if (CheckFormatMultisample(dxgiFormat, 8))
            {
                return TextureSampleCount.Count8;
            }
            else if (CheckFormatMultisample(dxgiFormat, 4))
            {
                return TextureSampleCount.Count4;
            }
            else if (CheckFormatMultisample(dxgiFormat, 2))
            {
                return TextureSampleCount.Count2;
            }

            return TextureSampleCount.Count1;
        }

        /// <summary>
        /// Describes whether this instance check format multisample
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="sampleCount">The sample count</param>
        /// <returns>The bool</returns>
        private bool CheckFormatMultisample(Format format, int sampleCount)
        {
            return _device.CheckMultisampleQualityLevels(format, sampleCount) != 0;
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
            if (D3D11Formats.IsUnsupportedFormat(format))
            {
                properties = default(PixelFormatProperties);
                return false;
            }

            Format dxgiFormat = D3D11Formats.ToDxgiFormat(format, (usage & TextureUsage.DepthStencil) != 0);
            FormatSupport fs = _device.CheckFormatSupport(dxgiFormat);

            if ((usage & TextureUsage.RenderTarget) != 0 && (fs & FormatSupport.RenderTarget) == 0
                || (usage & TextureUsage.DepthStencil) != 0 && (fs & FormatSupport.DepthStencil) == 0
                || (usage & TextureUsage.Sampled) != 0 && (fs & FormatSupport.ShaderSample) == 0
                || (usage & TextureUsage.Cubemap) != 0 && (fs & FormatSupport.TextureCube) == 0
                || (usage & TextureUsage.Storage) != 0 && (fs & FormatSupport.TypedUnorderedAccessView) == 0)
            {
                properties = default(PixelFormatProperties);
                return false;
            }

            const uint MaxTextureDimension = 16384;
            const uint MaxVolumeExtent = 2048;

            uint sampleCounts = 0;
            if (CheckFormatMultisample(dxgiFormat, 1)) { sampleCounts |= (1 << 0); }
            if (CheckFormatMultisample(dxgiFormat, 2)) { sampleCounts |= (1 << 1); }
            if (CheckFormatMultisample(dxgiFormat, 4)) { sampleCounts |= (1 << 2); }
            if (CheckFormatMultisample(dxgiFormat, 8)) { sampleCounts |= (1 << 3); }
            if (CheckFormatMultisample(dxgiFormat, 16)) { sampleCounts |= (1 << 4); }
            if (CheckFormatMultisample(dxgiFormat, 32)) { sampleCounts |= (1 << 5); }

            properties = new PixelFormatProperties(
                MaxTextureDimension,
                type == TextureType.Texture1D ? 1 : MaxTextureDimension,
                type != TextureType.Texture3D ? 1 : MaxVolumeExtent,
                uint.MaxValue,
                type == TextureType.Texture3D ? 1 : MaxVolumeExtent,
                sampleCounts);
            return true;
        }

        /// <summary>
        /// Maps the core using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="mode">The mode</param>
        /// <param name="subresource">The subresource</param>
        /// <exception cref="VeldridException">The given resource was already mapped with a different MapMode.</exception>
        /// <returns>The mapped resource</returns>
        protected override MappedResource MapCore(MappableResource resource, MapMode mode, uint subresource)
        {
            MappedResourceCacheKey key = new MappedResourceCacheKey(resource, subresource);
            lock (_mappedResourceLock)
            {
                if (_mappedResources.TryGetValue(key, out MappedResourceInfo info))
                {
                    if (info.Mode != mode)
                    {
                        throw new VeldridException("The given resource was already mapped with a different MapMode.");
                    }

                    info.RefCount += 1;
                    _mappedResources[key] = info;
                }
                else
                {
                    // No current mapping exists -- create one.

                    if (resource is D3D11Buffer buffer)
                    {
                        lock (_immediateContextLock)
                        {
                            MappedSubresource msr = _immediateContext.Map(
                                buffer.Buffer,
                                0,
                                D3D11Formats.VdToD3D11MapMode((buffer.Usage & BufferUsage.Dynamic) == BufferUsage.Dynamic, mode),
                                Vortice.Direct3D11.MapFlags.None);

                            info.MappedResource = new MappedResource(resource, mode, msr.DataPointer, buffer.SizeInBytes);
                            info.RefCount = 1;
                            info.Mode = mode;
                            _mappedResources.Add(key, info);
                        }
                    }
                    else
                    {
                        D3D11Texture texture = Util.AssertSubtype<MappableResource, D3D11Texture>(resource);
                        lock (_immediateContextLock)
                        {
                            Util.GetMipLevelAndArrayLayer(texture, subresource, out uint mipLevel, out uint arrayLayer);
                            _immediateContext.Map(
                                texture.DeviceTexture,
                                (int)mipLevel,
                                (int)arrayLayer,
                                D3D11Formats.VdToD3D11MapMode(false, mode),
                                Vortice.Direct3D11.MapFlags.None,
                                out int mipSize,
                                out MappedSubresource msr);

                            info.MappedResource = new MappedResource(
                                resource,
                                mode,
                                msr.DataPointer,
                                texture.Height * (uint)msr.RowPitch,
                                subresource,
                                (uint)msr.RowPitch,
                                (uint)msr.DepthPitch);
                            info.RefCount = 1;
                            info.Mode = mode;
                            _mappedResources.Add(key, info);
                        }
                    }
                }

                return info.MappedResource;
            }
        }

        /// <summary>
        /// Unmaps the core using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="subresource">The subresource</param>
        /// <exception cref="VeldridException">The given resource ({resource}) is not mapped.</exception>
        protected override void UnmapCore(MappableResource resource, uint subresource)
        {
            MappedResourceCacheKey key = new MappedResourceCacheKey(resource, subresource);
            bool commitUnmap;

            lock (_mappedResourceLock)
            {
                if (!_mappedResources.TryGetValue(key, out MappedResourceInfo info))
                {
                    throw new VeldridException($"The given resource ({resource}) is not mapped.");
                }

                info.RefCount -= 1;
                commitUnmap = info.RefCount == 0;
                if (commitUnmap)
                {
                    lock (_immediateContextLock)
                    {
                        if (resource is D3D11Buffer buffer)
                        {
                            _immediateContext.Unmap(buffer.Buffer, 0);
                        }
                        else
                        {
                            D3D11Texture texture = Util.AssertSubtype<MappableResource, D3D11Texture>(resource);
                            _immediateContext.Unmap(texture.DeviceTexture, (int)subresource);
                        }

                        bool result = _mappedResources.Remove(key);
                        Debug.Assert(result);
                    }
                }
                else
                {
                    _mappedResources[key] = info;
                }
            }
        }

        /// <summary>
        /// Updates the buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        private protected unsafe override void UpdateBufferCore(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes)
        {
            D3D11Buffer d3dBuffer = Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(buffer);
            if (sizeInBytes == 0)
            {
                return;
            }

            bool isDynamic = (buffer.Usage & BufferUsage.Dynamic) == BufferUsage.Dynamic;
            bool isStaging = (buffer.Usage & BufferUsage.Staging) == BufferUsage.Staging;
            bool isUniformBuffer = (buffer.Usage & BufferUsage.UniformBuffer) == BufferUsage.UniformBuffer;
            bool updateFullBuffer = bufferOffsetInBytes == 0 && sizeInBytes == buffer.SizeInBytes;
            bool useUpdateSubresource = (!isDynamic && !isStaging) && (!isUniformBuffer || updateFullBuffer);
            bool useMap = (isDynamic && updateFullBuffer) || isStaging;

            if (useUpdateSubresource)
            {
                Box? subregion = new Box((int)bufferOffsetInBytes, 0, 0, (int)(sizeInBytes + bufferOffsetInBytes), 1, 1);

                if (isUniformBuffer)
                {
                    subregion = null;
                }

                lock (_immediateContextLock)
                {
                    _immediateContext.UpdateSubresource(d3dBuffer.Buffer, 0, subregion, source, 0, 0);
                }
            }
            else if (useMap)
            {
                MappedResource mr = MapCore(buffer, MapMode.Write, 0);
                if (sizeInBytes < 1024)
                {
                    Unsafe.CopyBlock((byte*)mr.Data + bufferOffsetInBytes, source.ToPointer(), sizeInBytes);
                }
                else
                {
                    Buffer.MemoryCopy(
                        source.ToPointer(),
                        (byte*)mr.Data + bufferOffsetInBytes,
                        buffer.SizeInBytes,
                        sizeInBytes);
                }
                UnmapCore(buffer, 0);
            }
            else
            {
                D3D11Buffer staging = GetFreeStagingBuffer(sizeInBytes);
                UpdateBuffer(staging, 0, source, sizeInBytes);
                Box sourceRegion = new Box(0, 0, 0, (int)sizeInBytes, 1, 1);
                lock (_immediateContextLock)
                {
                    _immediateContext.CopySubresourceRegion(
                        d3dBuffer.Buffer, 0, (int)bufferOffsetInBytes, 0, 0,
                        staging.Buffer, 0,
                        sourceRegion);
                }

                lock (_stagingResourcesLock)
                {
                    _availableStagingBuffers.Add(staging);
                }
            }
        }

        /// <summary>
        /// Gets the free staging buffer using the specified size in bytes
        /// </summary>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <returns>The 11 buffer</returns>
        private D3D11Buffer GetFreeStagingBuffer(uint sizeInBytes)
        {
            lock (_stagingResourcesLock)
            {
                foreach (D3D11Buffer buffer in _availableStagingBuffers)
                {
                    if (buffer.SizeInBytes >= sizeInBytes)
                    {
                        _availableStagingBuffers.Remove(buffer);
                        return buffer;
                    }
                }
            }

            DeviceBuffer staging = ResourceFactory.CreateBuffer(
                new BufferDescription(sizeInBytes, BufferUsage.Staging));

            return Util.AssertSubtype<DeviceBuffer, D3D11Buffer>(staging);
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
        private protected unsafe override void UpdateTextureCore(
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
            D3D11Texture d3dTex = Util.AssertSubtype<Texture, D3D11Texture>(texture);
            bool useMap = (texture.Usage & TextureUsage.Staging) == TextureUsage.Staging;
            if (useMap)
            {
                uint subresource = texture.CalculateSubresource(mipLevel, arrayLayer);
                MappedResourceCacheKey key = new MappedResourceCacheKey(texture, subresource);
                MappedResource map = MapCore(texture, MapMode.Write, subresource);

                uint denseRowSize = FormatHelpers.GetRowPitch(width, texture.Format);
                uint denseSliceSize = FormatHelpers.GetDepthPitch(denseRowSize, height, texture.Format);

                Util.CopyTextureRegion(
                    source.ToPointer(),
                    0, 0, 0,
                    denseRowSize, denseSliceSize,
                    map.Data.ToPointer(),
                    x, y, z,
                    map.RowPitch, map.DepthPitch,
                    width, height, depth,
                    texture.Format);

                UnmapCore(texture, subresource);
            }
            else
            {
                int subresource = D3D11Util.ComputeSubresource(mipLevel, texture.MipLevels, arrayLayer);
                Box resourceRegion = new Box(
                    left: (int)x,
                    right: (int)(x + width),
                    top: (int)y,
                    front: (int)z,
                    bottom: (int)(y + height),
                    back: (int)(z + depth));

                uint srcRowPitch = FormatHelpers.GetRowPitch(width, texture.Format);
                uint srcDepthPitch = FormatHelpers.GetDepthPitch(srcRowPitch, height, texture.Format);
                lock (_immediateContextLock)
                {
                    _immediateContext.UpdateSubresource(
                        d3dTex.DeviceTexture,
                        subresource,
                        resourceRegion,
                        source,
                        (int)srcRowPitch,
                        (int)srcDepthPitch);
                }
            }
        }

        /// <summary>
        /// Describes whether this instance wait for fence
        /// </summary>
        /// <param name="fence">The fence</param>
        /// <param name="nanosecondTimeout">The nanosecond timeout</param>
        /// <returns>The bool</returns>
        public override bool WaitForFence(Fence fence, ulong nanosecondTimeout)
        {
            return Util.AssertSubtype<Fence, D3D11Fence>(fence).Wait(nanosecondTimeout);
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
                events[i] = Util.AssertSubtype<Fence, D3D11Fence>(fences[i]).ResetEvent;
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
        /// The reset events lock
        /// </summary>
        private readonly object _resetEventsLock = new object();
        /// <summary>
        /// The manual reset event
        /// </summary>
        private readonly List<ManualResetEvent[]> _resetEvents = new List<ManualResetEvent[]>();

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
            Util.AssertSubtype<Fence, D3D11Fence>(fence).Reset();
        }

        /// <summary>
        /// Gets the uniform buffer min offset alignment core
        /// </summary>
        /// <returns>The uint</returns>
        internal override uint GetUniformBufferMinOffsetAlignmentCore() => 256u;

        /// <summary>
        /// Gets the structured buffer min offset alignment core
        /// </summary>
        /// <returns>The uint</returns>
        internal override uint GetStructuredBufferMinOffsetAlignmentCore() => 16;

        /// <summary>
        /// Platforms the dispose
        /// </summary>
        protected override void PlatformDispose()
        {
            // Dispose staging buffers
            foreach (DeviceBuffer buffer in _availableStagingBuffers)
            {
                buffer.Dispose();
            }
            _availableStagingBuffers.Clear();

            _d3d11ResourceFactory.Dispose();
            _mainSwapchain?.Dispose();
            _immediateContext.Dispose();

            if (IsDebugEnabled)
            {
                uint refCount = _device.Release();
                if (refCount > 0)
                {
                    ID3D11Debug deviceDebug = _device.QueryInterfaceOrNull<ID3D11Debug>();
                    if (deviceDebug != null)
                    {
                        deviceDebug.ReportLiveDeviceObjects(ReportLiveDeviceObjectFlags.Summary | ReportLiveDeviceObjectFlags.Detail | ReportLiveDeviceObjectFlags.IgnoreInternal);
                        deviceDebug.Dispose();
                    }
                }

                _dxgiAdapter.Dispose();

                // Report live objects using DXGI if available (DXGIGetDebugInterface1 will fail on pre Windows 8 OS).
                if (VorticeDXGI.DXGIGetDebugInterface1(out IDXGIDebug1 dxgiDebug).Success)
                {
                    dxgiDebug.ReportLiveObjects(VorticeDXGI.DebugAll, ReportLiveObjectFlags.Summary | ReportLiveObjectFlags.IgnoreInternal);
                    dxgiDebug.Dispose();
                }
            }
            else
            {
                _device.Dispose();
                _dxgiAdapter.Dispose();
            }
        }

        /// <summary>
        /// Waits the for idle core
        /// </summary>
        private protected override void WaitForIdleCore()
        {
        }

        /// <summary>
        /// Describes whether this instance get d 3 d 11 info
        /// </summary>
        /// <param name="info">The info</param>
        /// <returns>The bool</returns>
        public override bool GetD3D11Info(out BackendInfoD3D11 info)
        {
            info = _d3d11Info;
            return true;
        }
    }
}
