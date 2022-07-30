using System;
using Alis.Template.Game.Android;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Metal;
using MetalKit;
using MetalPerformanceShaders;
using UIKit;

namespace Alis.Template.Game.Ios {
	/// <summary>
	/// The game view controller class
	/// </summary>
	/// <seealso cref="UIViewController"/>
	/// <seealso cref="IMTKViewDelegate"/>
	/// <seealso cref="INSCoding"/>
	public partial class GameViewController : UIViewController, IMTKViewDelegate, INSCoding {
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
		/// The clock
		/// </summary>
		System.Diagnostics.Stopwatch clock;

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
		public override void ViewDidLoad ()
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

            bool deviceSupportsMPS = MPSKernel.Supports (mtkView.Device);
            if (!deviceSupportsMPS)
	            return;
            MetalPerformanceShadersDisabledLabel.Hidden = true;
            
            
            this.clock = new System.Diagnostics.Stopwatch();
            clock.Start();
            
            device.CreateBuffer(64, MTLResourceOptions.CpuCacheModeDefault);
            
		}
		
		
		

		/// <summary>
		/// Draws the view
		/// </summary>
		/// <param name="view">The view</param>
		public void Draw (MTKView view)
		{
            RenderManager.OnDrawFrame(view, commandQueue);
        }

		/// <summary>
		/// Drawables the size will change using the specified view
		/// </summary>
		/// <param name="view">The view</param>
		/// <param name="size">The size</param>
		public void DrawableSizeWillChange (MTKView view, CGSize size)
		{
			// Called whenever view changes orientation or layout is changed
		}
	}
}