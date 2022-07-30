using System;
using System.Numerics;
using Alis.Template.Game.Android;
using AppKit;
using CoreAnimation;
using Foundation;
using Metal;
using MetalKit;

namespace Alis.Template.Game.MacOs
{
    /// <summary>
    /// The game view controller class
    /// </summary>
    /// <seealso cref="NSViewController"/>
    /// <seealso cref="IMTKViewDelegate"/>
    public partial class GameViewController : NSViewController, IMTKViewDelegate
    {
        // view
        /// <summary>
        /// The mtk view
        /// </summary>
        MTKView mtkView;

        // renderer
        /// <summary>
        /// The device
        /// </summary>
        IMTLDevice device;
        /// <summary>
        /// The command queue
        /// </summary>
        IMTLCommandQueue commandQueue;
        /// <summary>
        /// The pipeline state
        /// </summary>
        IMTLRenderPipelineState pipelineState;
        /// <summary>
        /// The vertex buffer
        /// </summary>
        IMTLBuffer vertexBuffer;
        
        /// <summary>
        /// The view
        /// </summary>
        Matrix4x4 proj, view;

        /// <summary>
        /// The blue
        /// </summary>
        float red, green, blue;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewController"/> class
        /// </summary>
        /// <param name="coder">The coder</param>
        [Export ("initWithCoder:")]
        public GameViewController (NSCoder coder) : base (coder)
        {
        }


        /// <summary>
        /// Views the did load
        /// </summary>
        public override void ViewDidLoad()
        {
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

        /// <summary>
        /// Drawables the size will change using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="size">The size</param>
        public void DrawableSizeWillChange(MTKView view, CoreGraphics.CGSize size)
        {

        }

        /// <summary>
        /// Draws the view
        /// </summary>
        /// <param name="view">The view</param>
        public void Draw(MTKView view)
        {
            RenderManager.OnDrawFrame(view, commandQueue);
        }
        
    }
}
