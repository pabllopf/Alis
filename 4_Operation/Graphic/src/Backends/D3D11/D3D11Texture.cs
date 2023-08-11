using System;
using System.Diagnostics;
using Vortice.Direct3D11;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 texture class
    /// </summary>
    /// <seealso cref="Texture"/>
    internal class D3D11Texture : Texture
    {
        /// <summary>
        /// The device
        /// </summary>
        private readonly ID3D11Device _device;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public override uint Width { get; }
        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public override uint Height { get; }
        /// <summary>
        /// Gets the value of the depth
        /// </summary>
        public override uint Depth { get; }
        /// <summary>
        /// Gets the value of the mip levels
        /// </summary>
        public override uint MipLevels { get; }
        /// <summary>
        /// Gets the value of the array layers
        /// </summary>
        public override uint ArrayLayers { get; }
        /// <summary>
        /// Gets the value of the format
        /// </summary>
        public override PixelFormat Format { get; }
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
        public override bool IsDisposed => DeviceTexture.NativePointer == IntPtr.Zero;

        /// <summary>
        /// Gets the value of the device texture
        /// </summary>
        public ID3D11Resource DeviceTexture { get; }
        /// <summary>
        /// Gets the value of the dxgi format
        /// </summary>
        public Vortice.DXGI.Format DxgiFormat { get; }
        /// <summary>
        /// Gets the value of the typeless dxgi format
        /// </summary>
        public Vortice.DXGI.Format TypelessDxgiFormat { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture"/> class
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="description">The description</param>
        public D3D11Texture(ID3D11Device device, ref TextureDescription description)
        {
            _device = device;
            Width = description.Width;
            Height = description.Height;
            Depth = description.Depth;
            MipLevels = description.MipLevels;
            ArrayLayers = description.ArrayLayers;
            Format = description.Format;
            Usage = description.Usage;
            Type = description.Type;
            SampleCount = description.SampleCount;

            DxgiFormat = D3D11Formats.ToDxgiFormat(
                description.Format,
                (description.Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil);
            TypelessDxgiFormat = D3D11Formats.GetTypelessFormat(DxgiFormat);

            CpuAccessFlags cpuFlags = CpuAccessFlags.None;
            ResourceUsage resourceUsage = ResourceUsage.Default;
            BindFlags bindFlags = BindFlags.None;
            ResourceOptionFlags optionFlags = ResourceOptionFlags.None;

            if ((description.Usage & TextureUsage.RenderTarget) == TextureUsage.RenderTarget)
            {
                bindFlags |= BindFlags.RenderTarget;
            }
            if ((description.Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil)
            {
                bindFlags |= BindFlags.DepthStencil;
            }
            if ((description.Usage & TextureUsage.Sampled) == TextureUsage.Sampled)
            {
                bindFlags |= BindFlags.ShaderResource;
            }
            if ((description.Usage & TextureUsage.Storage) == TextureUsage.Storage)
            {
                bindFlags |= BindFlags.UnorderedAccess;
            }
            if ((description.Usage & TextureUsage.Staging) == TextureUsage.Staging)
            {
                cpuFlags = CpuAccessFlags.Read | CpuAccessFlags.Write;
                resourceUsage = ResourceUsage.Staging;
            }

            if ((description.Usage & TextureUsage.GenerateMipmaps) != 0)
            {
                bindFlags |= BindFlags.RenderTarget | BindFlags.ShaderResource;
                optionFlags |= ResourceOptionFlags.GenerateMips;
            }

            int arraySize = (int)description.ArrayLayers;
            if ((description.Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
            {
                optionFlags |= ResourceOptionFlags.TextureCube;
                arraySize *= 6;
            }

            int roundedWidth = (int)description.Width;
            int roundedHeight = (int)description.Height;
            if (FormatHelpers.IsCompressedFormat(description.Format))
            {
                roundedWidth = ((roundedWidth + 3) / 4) * 4;
                roundedHeight = ((roundedHeight + 3) / 4) * 4;
            }

            if (Type == TextureType.Texture1D)
            {
                Texture1DDescription desc1D = new Texture1DDescription()
                {
                    Width = roundedWidth,
                    MipLevels = (int)description.MipLevels,
                    ArraySize = arraySize,
                    Format = TypelessDxgiFormat,
                    BindFlags = bindFlags,
                    CPUAccessFlags = cpuFlags,
                    Usage = resourceUsage,
                    MiscFlags= optionFlags,
                };

                DeviceTexture = device.CreateTexture1D(desc1D);
            }
            else if (Type == TextureType.Texture2D)
            {
                Texture2DDescription deviceDescription = new Texture2DDescription()
                {
                    Width = roundedWidth,
                    Height = roundedHeight,
                    MipLevels = (int)description.MipLevels,
                    ArraySize = arraySize,
                    Format = TypelessDxgiFormat,
                    BindFlags = bindFlags,
                    CPUAccessFlags = cpuFlags,
                    Usage = resourceUsage,
                    SampleDescription = new Vortice.DXGI.SampleDescription((int)FormatHelpers.GetSampleCountUInt32(SampleCount), 0),
                    MiscFlags = optionFlags,
                };

                DeviceTexture = device.CreateTexture2D(deviceDescription);
            }
            else
            {
                Debug.Assert(Type == TextureType.Texture3D);
                Texture3DDescription desc3D = new Texture3DDescription()
                {
                    Width = roundedWidth,
                    Height = roundedHeight,
                    Depth = (int)description.Depth,
                    MipLevels = (int)description.MipLevels,
                    Format = TypelessDxgiFormat,
                    BindFlags = bindFlags,
                    CPUAccessFlags = cpuFlags,
                    Usage = resourceUsage,
                    MiscFlags = optionFlags,
                };

                DeviceTexture = device.CreateTexture3D(desc3D);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture"/> class
        /// </summary>
        /// <param name="existingTexture">The existing texture</param>
        /// <param name="type">The type</param>
        /// <param name="format">The format</param>
        public D3D11Texture(ID3D11Texture2D existingTexture, TextureType type, PixelFormat format)
        {
            _device = existingTexture.Device;
            DeviceTexture = existingTexture;
            Width = (uint)existingTexture.Description.Width;
            Height = (uint)existingTexture.Description.Height;
            Depth = 1;
            MipLevels = (uint)existingTexture.Description.MipLevels;
            ArrayLayers = (uint)existingTexture.Description.ArraySize;
            Format = format;
            SampleCount = FormatHelpers.GetSampleCount((uint)existingTexture.Description.SampleDescription.Count);
            Type = type;
            Usage = D3D11Formats.GetVdUsage(
                existingTexture.Description.BindFlags,
                existingTexture.Description.CPUAccessFlags,
                existingTexture.Description.MiscFlags);

            DxgiFormat = D3D11Formats.ToDxgiFormat(
                format,
                (Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil);
            TypelessDxgiFormat = D3D11Formats.GetTypelessFormat(DxgiFormat);
        }

        /// <summary>
        /// Creates the full texture view using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <returns>The texture view</returns>
        private protected override TextureView CreateFullTextureView(GraphicsDevice gd)
        {
            TextureViewDescription desc = new TextureViewDescription(this);
            D3D11GraphicsDevice d3d11GD = Util.AssertSubtype<GraphicsDevice, D3D11GraphicsDevice>(gd);
            return new D3D11TextureView(d3d11GD, ref desc);
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
                DeviceTexture.DebugName = value;
            }
        }

        /// <summary>
        /// Disposes the core
        /// </summary>
        private protected override void DisposeCore()
        {
            DeviceTexture.Dispose();
        }
    }
}
