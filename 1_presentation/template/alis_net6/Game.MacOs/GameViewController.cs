using System;
using System.Runtime.InteropServices;
using AppKit;
using Foundation;
using Metal;
using MetalKit;
using System.Numerics;
using CoreAnimation;

namespace DrawCube
{
    public partial class GameViewController : NSViewController, IMTKViewDelegate
    {
        // view
        MTKView mtkView;

        // renderer
        IMTLDevice device;
        IMTLCommandQueue commandQueue;
        IMTLRenderPipelineState pipelineState;
        IMTLBuffer vertexBuffer;
        
        Matrix4x4 proj, view;

        float red, green, blue;
        
        [Export ("initWithCoder:")]
        public GameViewController (NSCoder coder) : base (coder)
        {
        }


        public override void ViewDidLoad()
        {
            Game.exampleshareclass.print();
            
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
            
        }

        public void DrawableSizeWillChange(MTKView view, CoreGraphics.CGSize size)
        {

        }

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
                red -= 1.0f;
            green += 0.02f;
            if (green >= 1.0f)
                green -= 1.0f;
            blue += 0.03f;
            if (blue >= 1.0f)
                blue -= 1.0f;

        }
        
    }
}
