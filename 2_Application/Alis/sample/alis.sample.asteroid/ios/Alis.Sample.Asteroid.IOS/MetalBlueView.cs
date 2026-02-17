using System;
using CoreGraphics;
using UIKit;
using Metal;
using MetalKit;
using Foundation;

namespace Alis.Sample.Asteroid.IOS
{
    // Vista Metal mínima que pinta el fondo azul
    public class MetalBlueView : MTKView
    {
        public MetalBlueView(CGRect frame) : base(frame, MTLDevice.SystemDefault)
        {
            Initialize();
        }
        public MetalBlueView(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        void Initialize()
        {
            Device = MTLDevice.SystemDefault;
            if (Device != null)
            {
                ClearColor = new MTLClearColor(0, 0, 1, 1); // Azul
                EnableSetNeedsDisplay = true;
                Paused = false;
            }
        }
        public override void Draw(CGRect rect)
        {
            if (Device == null) return;
            var commandQueue = Device.CreateCommandQueue();
            if (commandQueue == null) return;
            using var commandBuffer = commandQueue.CommandBuffer();
            var renderPass = CurrentRenderPassDescriptor;
            if (renderPass != null && CurrentDrawable != null)
            {
                using var encoder = commandBuffer.CreateRenderCommandEncoder(renderPass);
                encoder.EndEncoding();
                commandBuffer.PresentDrawable(CurrentDrawable);
            }
            commandBuffer.Commit();
        }
    }
}
