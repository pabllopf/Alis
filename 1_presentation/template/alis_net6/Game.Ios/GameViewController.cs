using System;
using System.Runtime.InteropServices;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Metal;
using MetalKit;
using MetalPerformanceShaders;
using UIKit;

namespace MetalPerformanceShadersHelloWorld {
	public partial class GameViewController : UIViewController, IMTKViewDelegate, INSCoding {
		// view
		MTKView mtkView;

		// renderer
		IMTLDevice device;
		IMTLCommandQueue commandQueue;

		System.Diagnostics.Stopwatch clock;

		float red, green, blue;
		
		[Export ("initWithCoder:")]
		public GameViewController (NSCoder coder) : base (coder)
		{
		}

		public override void ViewDidLoad ()
		{
#pragma warning disable CA1416
			Game.exampleshareclass.print();
#pragma warning restore CA1416
			
			// Set the view to use the default device
            device = MTLDevice.SystemDefault;

            if (device == null)
            {
                Console.WriteLine("Metal is not supported on this device");
                return;
            }

            // Create a new command queue
            commandQueue = device.CreateCommandQueue();
            
            // Setup view
            mtkView = (MTKView)View;
            mtkView.Delegate = this;
            mtkView.Device = device;
            
            mtkView.EnableSetNeedsDisplay = false;

            mtkView.SampleCount = 1;
            mtkView.DepthStencilPixelFormat = MTLPixelFormat.Depth32Float_Stencil8;
            mtkView.ColorPixelFormat = MTLPixelFormat.BGRA8Unorm;
            mtkView.PreferredFramesPerSecond = 60;

            mtkView.ClearColor = new MTLClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            bool deviceSupportsMPS = MPSKernel.Supports (mtkView.Device);
            if (!deviceSupportsMPS)
	            return;
            MetalPerformanceShadersDisabledLabel.Hidden = true;
            
            
            this.clock = new System.Diagnostics.Stopwatch();
            clock.Start();
            
            device.CreateBuffer(64, MTLResourceOptions.CpuCacheModeDefault);
            
		}
		
		
		

		public void Draw (MTKView view)
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
				red -= 1.0f;
			green += 0.02f;
			if (green >= 1.0f)
				green -= 1.0f;
			blue += 0.03f;
			if (blue >= 1.0f)
				blue -= 1.0f;
			
			
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

		public void DrawableSizeWillChange (MTKView view, CGSize size)
		{
			// Called whenever view changes orientation or layout is changed
		}
	}
}