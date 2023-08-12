using Vortice.Direct3D11;

namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 util class
    /// </summary>
    internal static class D3D11Util
    {
        /// <summary>
        /// Computes the subresource using the specified mip level
        /// </summary>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="mipLevelCount">The mip level count</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <returns>The int</returns>
        public static int ComputeSubresource(uint mipLevel, uint mipLevelCount, uint arrayLayer)
        {
            return (int)((arrayLayer * mipLevelCount) + mipLevel);
        }

        /// <summary>
        /// Gets the srv desc using the specified tex
        /// </summary>
        /// <param name="tex">The tex</param>
        /// <param name="baseMipLevel">The base mip level</param>
        /// <param name="levelCount">The level count</param>
        /// <param name="baseArrayLayer">The base array layer</param>
        /// <param name="layerCount">The layer count</param>
        /// <param name="format">The format</param>
        /// <returns>The srv desc</returns>
        internal static ShaderResourceViewDescription GetSrvDesc(
            D3D11Texture tex,
            uint baseMipLevel,
            uint levelCount,
            uint baseArrayLayer,
            uint layerCount,
            PixelFormat format)
        {
            ShaderResourceViewDescription srvDesc = new ShaderResourceViewDescription();
            srvDesc.Format = D3D11Formats.GetViewFormat(
                D3D11Formats.ToDxgiFormat(format, (tex.Usage & TextureUsage.DepthStencil) != 0));

            if ((tex.Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
            {
                if (tex.ArrayLayers == 1)
                {
                    srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.TextureCube;
                    srvDesc.TextureCube.MostDetailedMip = (int)baseMipLevel;
                    srvDesc.TextureCube.MipLevels = (int)levelCount;
                }
                else
                {
                    srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.TextureCubeArray;
                    srvDesc.TextureCubeArray.MostDetailedMip = (int)baseMipLevel;
                    srvDesc.TextureCubeArray.MipLevels = (int)levelCount;
                    srvDesc.TextureCubeArray.First2DArrayFace = (int)baseArrayLayer;
                    srvDesc.TextureCubeArray.NumCubes = (int)tex.ArrayLayers;
                }
            }
            else if (tex.Depth == 1)
            {
                if (tex.ArrayLayers == 1)
                {
                    if (tex.Type == TextureType.Texture1D)
                    {
                        srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.Texture1D;
                        srvDesc.Texture1D.MostDetailedMip = (int)baseMipLevel;
                        srvDesc.Texture1D.MipLevels = (int)levelCount;
                    }
                    else
                    {
                        if (tex.SampleCount == TextureSampleCount.Count1)
                            srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.Texture2D;
                        else
                            srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.Texture2DMultisampled;
                        srvDesc.Texture2D.MostDetailedMip = (int)baseMipLevel;
                        srvDesc.Texture2D.MipLevels = (int)levelCount;
                    }
                }
                else
                {
                    if (tex.Type == TextureType.Texture1D)
                    {
                        srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.Texture1DArray;
                        srvDesc.Texture1DArray.MostDetailedMip = (int)baseMipLevel;
                        srvDesc.Texture1DArray.MipLevels = (int)levelCount;
                        srvDesc.Texture1DArray.FirstArraySlice = (int)baseArrayLayer;
                        srvDesc.Texture1DArray.ArraySize = (int)layerCount;
                    }
                    else
                    {
                        srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.Texture2DArray;
                        srvDesc.Texture2DArray.MostDetailedMip = (int)baseMipLevel;
                        srvDesc.Texture2DArray.MipLevels = (int)levelCount;
                        srvDesc.Texture2DArray.FirstArraySlice = (int)baseArrayLayer;
                        srvDesc.Texture2DArray.ArraySize = (int)layerCount;
                    }
                }
            }
            else
            {
                srvDesc.ViewDimension = Vortice.Direct3D.ShaderResourceViewDimension.Texture3D;
                srvDesc.Texture3D.MostDetailedMip = (int)baseMipLevel;
                srvDesc.Texture3D.MipLevels = (int)levelCount;
            }

            return srvDesc;
        }

        /// <summary>
        /// Gets the sync interval using the specified sync to v blank
        /// </summary>
        /// <param name="syncToVBlank">The sync to blank</param>
        /// <returns>The int</returns>
        internal static int GetSyncInterval(bool syncToVBlank)
        {
            return syncToVBlank ? 1 : 0;
        }
    }
}
