using System;
using Alis.Core.Graphic.Backends.Metal;

namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl sampler class
    /// </summary>
    /// <seealso cref="Sampler"/>
    internal class MTLSampler : Sampler
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the device sampler
        /// </summary>
        public MTLSamplerState DeviceSampler { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLSampler"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        public MTLSampler(ref SamplerDescription description, MTLGraphicsDevice gd)
        {
            MTLFormats.GetMinMagMipFilter(
                description.Filter,
                out MTLSamplerMinMagFilter min,
                out MTLSamplerMinMagFilter mag,
                out MTLSamplerMipFilter mip);

            MTLSamplerDescriptor mtlDesc = MTLSamplerDescriptor.New();
            mtlDesc.sAddressMode = MTLFormats.VdToMTLAddressMode(description.AddressModeU);
            mtlDesc.tAddressMode = MTLFormats.VdToMTLAddressMode(description.AddressModeV);
            mtlDesc.rAddressMode = MTLFormats.VdToMTLAddressMode(description.AddressModeW);
            mtlDesc.minFilter = min;
            mtlDesc.magFilter = mag;
            mtlDesc.mipFilter = mip;
            if (gd.MetalFeatures.IsMacOS)
            {
                mtlDesc.borderColor = MTLFormats.VdToMTLBorderColor(description.BorderColor);
            }
            if (description.ComparisonKind != null)
            {
                mtlDesc.compareFunction = MTLFormats.VdToMTLCompareFunction(description.ComparisonKind.Value);
            }
            mtlDesc.lodMinClamp = description.MinimumLod;
            mtlDesc.lodMaxClamp = description.MaximumLod;
            mtlDesc.maxAnisotropy = (UIntPtr)(Math.Max(1, description.MaximumAnisotropy));
            DeviceSampler = gd.Device.newSamplerStateWithDescriptor(mtlDesc);
            ObjectiveCRuntime.release(mtlDesc.NativePtr);
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                ObjectiveCRuntime.release(DeviceSampler.NativePtr);
            }
        }
    }
}
