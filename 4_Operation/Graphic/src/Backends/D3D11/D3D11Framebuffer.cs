using System;
using Vortice.Direct3D11;

namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 framebuffer class
    /// </summary>
    /// <seealso cref="Framebuffer"/>
    internal class D3D11Framebuffer : Framebuffer
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
        /// Gets the value of the render target views
        /// </summary>
        public ID3D11RenderTargetView[] RenderTargetViews { get; }
        /// <summary>
        /// Gets the value of the depth stencil view
        /// </summary>
        public ID3D11DepthStencilView DepthStencilView { get; }

        // Only non-null if this is the Framebuffer for a Swapchain.
        /// <summary>
        /// Gets or sets the value of the swapchain
        /// </summary>
        internal D3D11Swapchain Swapchain { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Framebuffer"/> class
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="description">The description</param>
        public D3D11Framebuffer(ID3D11Device device, ref FramebufferDescription description)
            : base(description.DepthTarget, description.ColorTargets)
        {
            if (description.DepthTarget != null)
            {
                D3D11Texture d3dDepthTarget = Util.AssertSubtype<Texture, D3D11Texture>(description.DepthTarget.Value.Target);
                DepthStencilViewDescription dsvDesc = new DepthStencilViewDescription()
                {
                    Format = D3D11Formats.GetDepthFormat(d3dDepthTarget.Format),
                };
                if (d3dDepthTarget.ArrayLayers == 1)
                {
                    if (d3dDepthTarget.SampleCount == TextureSampleCount.Count1)
                    {
                        dsvDesc.ViewDimension = DepthStencilViewDimension.Texture2D;
                        dsvDesc.Texture2D.MipSlice = (int)description.DepthTarget.Value.MipLevel;
                    }
                    else
                    {
                        dsvDesc.ViewDimension = DepthStencilViewDimension.Texture2DMultisampled;
                    }
                }
                else
                {
                    if (d3dDepthTarget.SampleCount == TextureSampleCount.Count1)
                    {
                        dsvDesc.ViewDimension = DepthStencilViewDimension.Texture2DArray;
                        dsvDesc.Texture2DArray.FirstArraySlice = (int)description.DepthTarget.Value.ArrayLayer;
                        dsvDesc.Texture2DArray.ArraySize = 1;
                        dsvDesc.Texture2DArray.MipSlice = (int)description.DepthTarget.Value.MipLevel;
                    }
                    else
                    {
                        dsvDesc.ViewDimension = DepthStencilViewDimension.Texture2DMultisampledArray;
                        dsvDesc.Texture2DMSArray.FirstArraySlice = (int)description.DepthTarget.Value.ArrayLayer;
                        dsvDesc.Texture2DMSArray.ArraySize = 1;
                    }
                }

                DepthStencilView = device.CreateDepthStencilView(d3dDepthTarget.DeviceTexture, dsvDesc);
            }

            if (description.ColorTargets != null && description.ColorTargets.Length > 0)
            {
                RenderTargetViews = new ID3D11RenderTargetView[description.ColorTargets.Length];
                for (int i = 0; i < RenderTargetViews.Length; i++)
                {
                    D3D11Texture d3dColorTarget = Util.AssertSubtype<Texture, D3D11Texture>(description.ColorTargets[i].Target);
                    RenderTargetViewDescription rtvDesc = new RenderTargetViewDescription
                    {
                        Format = D3D11Formats.ToDxgiFormat(d3dColorTarget.Format, false),
                    };
                    if (d3dColorTarget.ArrayLayers > 1 || (d3dColorTarget.Usage & TextureUsage.Cubemap) != 0)
                    {
                        if (d3dColorTarget.SampleCount == TextureSampleCount.Count1)
                        {
                            rtvDesc.ViewDimension = RenderTargetViewDimension.Texture2DArray;
                            rtvDesc.Texture2DArray = new Texture2DArrayRenderTargetView
                            {
                                ArraySize = 1,
                                FirstArraySlice = (int)description.ColorTargets[i].ArrayLayer,
                                MipSlice = (int)description.ColorTargets[i].MipLevel
                            };
                        }
                        else
                        {
                            rtvDesc.ViewDimension = RenderTargetViewDimension.Texture2DMultisampledArray;
                            rtvDesc.Texture2DMSArray = new Texture2DMultisampledArrayRenderTargetView
                            {
                                ArraySize = 1,
                                FirstArraySlice = (int)description.ColorTargets[i].ArrayLayer
                            };
                        }
                    }
                    else
                    {
                        if (d3dColorTarget.SampleCount == TextureSampleCount.Count1)
                        {
                            rtvDesc.ViewDimension = RenderTargetViewDimension.Texture2D;
                            rtvDesc.Texture2D.MipSlice = (int)description.ColorTargets[i].MipLevel;
                        }
                        else
                        {
                            rtvDesc.ViewDimension = RenderTargetViewDimension.Texture2DMultisampled;
                        }
                    }
                    RenderTargetViews[i] = device.CreateRenderTargetView(d3dColorTarget.DeviceTexture, rtvDesc);
                }
            }
            else
            {
                RenderTargetViews = Array.Empty<ID3D11RenderTargetView>();
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
                for (int i = 0; i < RenderTargetViews.Length; i++)
                {
                    RenderTargetViews[i].DebugName = value + "_RTV" + i;
                }
                if (DepthStencilView != null)
                {
                    DepthStencilView.DebugName = value + "_DSV";
                }
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                DepthStencilView?.Dispose();
                foreach (ID3D11RenderTargetView rtv in RenderTargetViews)
                {
                    rtv.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
