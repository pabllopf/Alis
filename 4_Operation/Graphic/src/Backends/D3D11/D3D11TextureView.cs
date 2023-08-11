using Vortice.Direct3D11;
using System;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 texture view class
    /// </summary>
    /// <seealso cref="TextureView"/>
    internal class D3D11TextureView : TextureView
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the shader resource view
        /// </summary>
        public ID3D11ShaderResourceView ShaderResourceView { get; }
        /// <summary>
        /// Gets the value of the unordered access view
        /// </summary>
        public ID3D11UnorderedAccessView UnorderedAccessView { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11TextureView"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        /// <exception cref="NotSupportedException"></exception>
        public D3D11TextureView(D3D11GraphicsDevice gd, ref TextureViewDescription description)
            : base(ref description)
        {
            ID3D11Device device = gd.Device;
            D3D11Texture d3dTex = Util.AssertSubtype<Texture, D3D11Texture>(description.Target);
            ShaderResourceViewDescription srvDesc = D3D11Util.GetSrvDesc(
                d3dTex,
                description.BaseMipLevel,
                description.MipLevels,
                description.BaseArrayLayer,
                description.ArrayLayers,
                Format);
            ShaderResourceView = device.CreateShaderResourceView(d3dTex.DeviceTexture, srvDesc);

            if ((d3dTex.Usage & TextureUsage.Storage) == TextureUsage.Storage)
            {
                UnorderedAccessViewDescription uavDesc = new UnorderedAccessViewDescription();
                uavDesc.Format = D3D11Formats.GetViewFormat(d3dTex.DxgiFormat);

                if ((d3dTex.Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
                {
                    throw new NotSupportedException();
                }
                else if (d3dTex.Depth == 1)
                {
                    if (d3dTex.ArrayLayers == 1)
                    {
                        if (d3dTex.Type == TextureType.Texture1D)
                        {
                            uavDesc.ViewDimension = UnorderedAccessViewDimension.Texture1D;
                            uavDesc.Texture1D.MipSlice = (int)description.BaseMipLevel;
                        }
                        else
                        {
                            uavDesc.ViewDimension = UnorderedAccessViewDimension.Texture2D;
                            uavDesc.Texture2D.MipSlice = (int)description.BaseMipLevel;
                        }
                    }
                    else
                    {
                        if (d3dTex.Type == TextureType.Texture1D)
                        {
                            uavDesc.ViewDimension = UnorderedAccessViewDimension.Texture1DArray;
                            uavDesc.Texture1DArray.MipSlice = (int)description.BaseMipLevel;
                            uavDesc.Texture1DArray.FirstArraySlice = (int)description.BaseArrayLayer;
                            uavDesc.Texture1DArray.ArraySize = (int)description.ArrayLayers;
                        }
                        else
                        {
                            uavDesc.ViewDimension = UnorderedAccessViewDimension.Texture2DArray;
                            uavDesc.Texture2DArray.MipSlice = (int)description.BaseMipLevel;
                            uavDesc.Texture2DArray.FirstArraySlice = (int)description.BaseArrayLayer;
                            uavDesc.Texture2DArray.ArraySize = (int)description.ArrayLayers;
                        }
                    }
                }
                else
                {
                    uavDesc.ViewDimension = UnorderedAccessViewDimension.Texture3D;
                    uavDesc.Texture3D.MipSlice = (int)description.BaseMipLevel;

                    // Map the entire range of the 3D texture.
                    uavDesc.Texture3D.FirstWSlice = 0;
                    uavDesc.Texture3D.WSize = (int)d3dTex.Depth;
                }

                UnorderedAccessView = device.CreateUnorderedAccessView(d3dTex.DeviceTexture, uavDesc);
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
                if (ShaderResourceView != null)
                {
                    ShaderResourceView.DebugName = value + "_SRV";
                }
                if (UnorderedAccessView != null)
                {
                    UnorderedAccessView.DebugName = value + "_UAV";
                }
            }
        }

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
                ShaderResourceView?.Dispose();
                UnorderedAccessView?.Dispose();
                _disposed = true;
            }
        }
    }
}
