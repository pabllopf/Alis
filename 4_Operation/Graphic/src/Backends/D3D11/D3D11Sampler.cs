using System;
using Vortice.Direct3D11;
using Vortice.Mathematics;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 sampler class
    /// </summary>
    /// <seealso cref="Sampler"/>
    internal class D3D11Sampler : Sampler
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the device sampler
        /// </summary>
        public ID3D11SamplerState DeviceSampler { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Sampler"/> class
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="description">The description</param>
        public D3D11Sampler(ID3D11Device device, ref SamplerDescription description)
        {
            ComparisonFunction comparision = description.ComparisonKind == null ? ComparisonFunction.Never : D3D11Formats.VdToD3D11ComparisonFunc(description.ComparisonKind.Value);
            Vortice.Direct3D11.SamplerDescription samplerStateDesc = new Vortice.Direct3D11.SamplerDescription
            {
                AddressU = D3D11Formats.VdToD3D11AddressMode(description.AddressModeU),
                AddressV = D3D11Formats.VdToD3D11AddressMode(description.AddressModeV),
                AddressW = D3D11Formats.VdToD3D11AddressMode(description.AddressModeW),
                Filter = D3D11Formats.ToD3D11Filter(description.Filter, description.ComparisonKind.HasValue),
                MinLOD = description.MinimumLod,
                MaxLOD = description.MaximumLod,
                MaxAnisotropy = (int)description.MaximumAnisotropy,
                ComparisonFunction = comparision,
                MipLODBias = description.LodBias,
                BorderColor = ToRawColor4(description.BorderColor)
            };

            DeviceSampler = device.CreateSamplerState(samplerStateDesc);
        }

        /// <summary>
        /// Returns the raw color 4 using the specified border color
        /// </summary>
        /// <param name="borderColor">The border color</param>
        /// <returns>The color</returns>
        private static Color4 ToRawColor4(SamplerBorderColor borderColor)
        {
            switch (borderColor)
            {
                case SamplerBorderColor.TransparentBlack:
                    return new Color4(0, 0, 0, 0);
                case SamplerBorderColor.OpaqueBlack:
                    return new Color4(0, 0, 0, 1);
                case SamplerBorderColor.OpaqueWhite:
                    return new Color4(1, 1, 1, 1);
                default:
                    throw Illegal.Value<SamplerBorderColor>();
            }
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
                DeviceSampler.DebugName = value;
            }
        }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => DeviceSampler.NativePointer == IntPtr.Zero;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            DeviceSampler.Dispose();
        }
    }
}
