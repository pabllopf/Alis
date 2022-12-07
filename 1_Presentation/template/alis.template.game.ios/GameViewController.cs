// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameViewController.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Metal;
using MetalKit;
using MetalPerformanceShaders;
using UIKit;

namespace Alis.Template.Game.Ios
{
    /// <summary>
    ///     The game view controller class
    /// </summary>
    /// <seealso cref="UIViewController" />
    /// <seealso cref="IMTKViewDelegate" />
    /// <seealso cref="INSCoding" />
    public partial class GameViewController : UIViewController, IMTKViewDelegate, INSCoding
    {
        /// <summary>
        ///     The clock
        /// </summary>
        private Stopwatch clock;

        /// <summary>
        ///     The command queue
        /// </summary>
        private IMTLCommandQueue commandQueue;

        // renderer
        /// <summary>
        ///     The device
        /// </summary>
        private IMTLDevice device;

        // view
        /// <summary>
        ///     The mtk view
        /// </summary>
        private MTKView mtkView;

        /// <summary>
        ///     The blue
        /// </summary>
        private float red, green, blue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameViewController" /> class
        /// </summary>
        /// <param name="coder">The coder</param>
        [Export("initWithCoder:")]
        public GameViewController(NSCoder coder) : base(coder)
        {
        }


        /// <summary>
        ///     Draws the view
        /// </summary>
        /// <param name="view">The view</param>
        public void Draw(MTKView view)
        {
            view.ClearColor = new MTLClearColor(red, green, blue, 1.0f);

            // Create a new command buffer for each renderpass to the current drawable
            IMTLCommandBuffer commandBuffer = commandQueue.CommandBuffer();

            // Obtain a renderPassDescriptor generated from the view's drawable textures
            MTLRenderPassDescriptor renderPassDescriptor = view.CurrentRenderPassDescriptor;

            // Create a render command encoder so we can render into something
            IMTLRenderCommandEncoder commandEncoder = commandBuffer.CreateRenderCommandEncoder(renderPassDescriptor);

            commandEncoder.EndEncoding();

            ICAMetalDrawable drawable = view.CurrentDrawable;

            commandBuffer.PresentDrawable(drawable);

            commandBuffer.Commit();


            red += 0.01f;
            if (red >= 1.0f)
            {
                red -= 1.0f;
            }

            green += 0.02f;
            if (green >= 1.0f)
            {
                green -= 1.0f;
            }

            blue += 0.03f;
            if (blue >= 1.0f)
            {
                blue -= 1.0f;
            }


            /*
			var time = clock.ElapsedMilliseconds / 1000.0f;
			var viewProj = Matrix4x4.Multiply(this.view, this.proj);
			var worldViewProj = Matrix4x4.CreateRotationX(time) * Matrix4x4.CreateRotationY(time * 2) * Matrix4x4.CreateRotationZ(time * .7f) * viewProj;
			worldViewProj = Matrix4x4.Transpose(worldViewProj);
			
			int rawsize = Marshal.SizeOf<Matrix4x4>();
			var rawdata = new byte[rawsize];
			
			GCHandle pinnedUniforms = GCHandle.Alloc(worldViewProj, GCHandleType.Pinned);
			IntPtr ptr = pinnedUniforms.AddrOfPinnedObject();
			Marshal.Copy(ptr, rawdata, 0, rawsize);
			pinnedUniforms.Free();

			Marshal.Copy(rawdata, 0, constantBuffer.Contents + rawsize, rawsize);
			
			ICAMetalDrawable drawable = ((CAMetalLayer) view.Layer).NextDrawable();
			IMTLTexture texture = drawable.Texture;
			MTLRenderPassDescriptor renderPassDescriptor = view.CurrentRenderPassDescriptor;
			
			renderPassDescriptor.ColorAttachments[0].Texture = texture;
			renderPassDescriptor.ColorAttachments[0].LoadAction = MTLLoadAction.Clear;
			renderPassDescriptor.ColorAttachments[0].StoreAction = MTLStoreAction.Store;
			renderPassDescriptor.ColorAttachments[0].ClearColor = new MTLClearColor(red, green, blue, 1.0f);

			red += 0.01f;
			if (red >= 1.0f)
				red -= 1.0f;
			green += 0.02f;
			if (green >= 1.0f)
				green -= 1.0f;
			blue += 0.03f;
			if (blue >= 1.0f)
				blue -= 1.0f;
			
			IMTLCommandBuffer commandBuffer = commandQueue.CommandBuffer();
			IMTLRenderCommandEncoder renderEncoder = commandBuffer.CreateRenderCommandEncoder(renderPassDescriptor);
			renderEncoder.EndEncoding();
			
			commandBuffer.PresentDrawable (drawable);
			commandBuffer.Commit();
			//commandBuffer.WaitUntilCompleted();*/
        }

        /// <summary>
        ///     Drawables the size will change using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="size">The size</param>
        public void DrawableSizeWillChange(MTKView view, CGSize size)
        {
            // Called whenever view changes orientation or layout is changed
        }

        /// <summary>
        ///     Views the did load
        /// </summary>
        public override void ViewDidLoad()
        {
            // Set the view to use the default device
            device = MTLDevice.SystemDefault;

            if (device == null)
            {
                return;
            }

            // Create a new command queue
            commandQueue = device.CreateCommandQueue();

            // Setup view
            mtkView = (MTKView) View;
            mtkView.Delegate = this;
            mtkView.Device = device;

            mtkView.EnableSetNeedsDisplay = false;

            mtkView.SampleCount = 1;
            mtkView.DepthStencilPixelFormat = MTLPixelFormat.Depth32Float_Stencil8;
            mtkView.ColorPixelFormat = MTLPixelFormat.BGRA8Unorm;
            mtkView.PreferredFramesPerSecond = 60;

            mtkView.ClearColor = new MTLClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            bool deviceSupportsMPS = MPSKernel.Supports(mtkView.Device);
            if (!deviceSupportsMPS)
            {
                return;
            }

            MetalPerformanceShadersDisabledLabel.Hidden = true;


            clock = new Stopwatch();
            clock.Start();

            device.CreateBuffer(64, MTLResourceOptions.CpuCacheModeDefault);
        }
    }
}