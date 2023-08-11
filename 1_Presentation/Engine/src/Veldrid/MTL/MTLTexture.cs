using System;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl texture class
    /// </summary>
    /// <seealso cref="Texture"/>
    internal class MTLTexture : Texture
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The native MTLTexture object. This property is only valid for non-staging Textures.
        /// </summary>
        public MetalBindings.MTLTexture DeviceTexture { get; }
        /// <summary>
        /// The staging MTLBuffer object. This property is only valid for staging Textures.
        /// </summary>
        public MetalBindings.MTLBuffer StagingBuffer { get; }

        /// <summary>
        /// Gets the value of the format
        /// </summary>
        public override PixelFormat Format { get; }

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
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;
        /// <summary>
        /// Gets the value of the mtl pixel format
        /// </summary>
        public MTLPixelFormat MTLPixelFormat { get; }
        /// <summary>
        /// Gets the value of the mtl texture type
        /// </summary>
        public MTLTextureType MTLTextureType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLTexture"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="_gd">The gd</param>
        public MTLTexture(ref TextureDescription description, MTLGraphicsDevice _gd)
        {
            Width = description.Width;
            Height = description.Height;
            Depth = description.Depth;
            ArrayLayers = description.ArrayLayers;
            MipLevels = description.MipLevels;
            Format = description.Format;
            Usage = description.Usage;
            Type = description.Type;
            SampleCount = description.SampleCount;
            bool isDepth = (Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil;

            MTLPixelFormat = MTLFormats.VdToMTLPixelFormat(Format, isDepth);
            MTLTextureType = MTLFormats.VdToMTLTextureType(
                    Type,
                    ArrayLayers,
                    SampleCount != TextureSampleCount.Count1,
                    (Usage & TextureUsage.Cubemap) != 0);
            if (Usage != TextureUsage.Staging)
            {
                MTLTextureDescriptor texDescriptor = MTLTextureDescriptor.New();
                texDescriptor.width = (UIntPtr)Width;
                texDescriptor.height = (UIntPtr)Height;
                texDescriptor.depth = (UIntPtr)Depth;
                texDescriptor.mipmapLevelCount = (UIntPtr)MipLevels;
                texDescriptor.arrayLength = (UIntPtr)ArrayLayers;
                texDescriptor.sampleCount = (UIntPtr)FormatHelpers.GetSampleCountUInt32(SampleCount);
                texDescriptor.textureType = MTLTextureType;
                texDescriptor.pixelFormat = MTLPixelFormat;
                texDescriptor.textureUsage = MTLFormats.VdToMTLTextureUsage(Usage);
                texDescriptor.storageMode = MTLStorageMode.Private;

                DeviceTexture = _gd.Device.newTextureWithDescriptor(texDescriptor);
                ObjectiveCRuntime.release(texDescriptor.NativePtr);
            }
            else
            {
                uint blockSize = FormatHelpers.IsCompressedFormat(Format) ? 4u : 1u;
                uint totalStorageSize = 0;
                for (uint level = 0; level < MipLevels; level++)
                {
                    Util.GetMipDimensions(this, level, out uint levelWidth, out uint levelHeight, out uint levelDepth);
                    uint storageWidth = Math.Max(levelWidth, blockSize);
                    uint storageHeight = Math.Max(levelHeight, blockSize);
                    totalStorageSize += levelDepth * FormatHelpers.GetDepthPitch(
                        FormatHelpers.GetRowPitch(levelWidth, Format),
                        levelHeight,
                        Format);
                }
                totalStorageSize *= ArrayLayers;

                StagingBuffer = _gd.Device.newBufferWithLengthOptions(
                    (UIntPtr)totalStorageSize,
                    MTLResourceOptions.StorageModeShared);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLTexture"/> class
        /// </summary>
        /// <param name="nativeTexture">The native texture</param>
        /// <param name="description">The description</param>
        public MTLTexture(ulong nativeTexture, ref TextureDescription description)
        {
            DeviceTexture = new MetalBindings.MTLTexture((IntPtr)nativeTexture);
            Width = description.Width;
            Height = description.Height;
            Depth = description.Depth;
            ArrayLayers = description.ArrayLayers;
            MipLevels = description.MipLevels;
            Format = description.Format;
            Usage = description.Usage;
            Type = description.Type;
            SampleCount = description.SampleCount;
            bool isDepth = (Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil;

            MTLPixelFormat = MTLFormats.VdToMTLPixelFormat(Format, isDepth);
            MTLTextureType = MTLFormats.VdToMTLTextureType(
                    Type,
                    ArrayLayers,
                    SampleCount != TextureSampleCount.Count1,
                    (Usage & TextureUsage.Cubemap) != 0);
        }

        /// <summary>
        /// Gets the subresource size using the specified mip level
        /// </summary>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <returns>The uint</returns>
        internal uint GetSubresourceSize(uint mipLevel, uint arrayLayer)
        {
            uint blockSize = FormatHelpers.IsCompressedFormat(Format) ? 4u : 1u;
            Util.GetMipDimensions(this, mipLevel, out uint width, out uint height, out uint depth);
            uint storageWidth = Math.Max(blockSize, width);
            uint storageHeight = Math.Max(blockSize, height);
            return depth * FormatHelpers.GetDepthPitch(
                FormatHelpers.GetRowPitch(storageWidth, Format),
                storageHeight,
                Format);
        }

        /// <summary>
        /// Gets the subresource layout using the specified mip level
        /// </summary>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <param name="rowPitch">The row pitch</param>
        /// <param name="depthPitch">The depth pitch</param>
        internal void GetSubresourceLayout(uint mipLevel, uint arrayLayer, out uint rowPitch, out uint depthPitch)
        {
            uint blockSize = FormatHelpers.IsCompressedFormat(Format) ? 4u : 1u;
            Util.GetMipDimensions(this, mipLevel, out uint mipWidth, out uint mipHeight, out uint mipDepth);
            uint storageWidth = Math.Max(blockSize, mipWidth);
            uint storageHeight = Math.Max(blockSize, mipHeight);
            rowPitch = FormatHelpers.GetRowPitch(storageWidth, Format);
            depthPitch = FormatHelpers.GetDepthPitch(rowPitch, storageHeight, Format);
        }

        /// <summary>
        /// Disposes the core
        /// </summary>
        private protected override void DisposeCore()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (!StagingBuffer.IsNull)
                {
                    ObjectiveCRuntime.release(StagingBuffer.NativePtr);
                }
                else
                {
                    ObjectiveCRuntime.release(DeviceTexture.NativePtr);
                }
            }
        }
    }
}
