using static Veldrid.MetalBindings.ObjectiveCRuntime;
using System;
using System.Runtime.InteropServices;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl command buffer
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCommandBuffer
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Renders the command encoder with descriptor using the specified desc
        /// </summary>
        /// <param name="desc">The desc</param>
        /// <returns>The mtl render command encoder</returns>
        public MTLRenderCommandEncoder renderCommandEncoderWithDescriptor(MTLRenderPassDescriptor desc)
        {
            return new MTLRenderCommandEncoder(
                IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, desc.NativePtr));
        }

        /// <summary>
        /// Presents the drawable using the specified drawable
        /// </summary>
        /// <param name="drawable">The drawable</param>
        public void presentDrawable(IntPtr drawable) => objc_msgSend(NativePtr, sel_presentDrawable, drawable);

        /// <summary>
        /// Commits this instance
        /// </summary>
        public void commit() => objc_msgSend(NativePtr, sel_commit);

        /// <summary>
        /// Blits the command encoder
        /// </summary>
        /// <returns>The mtl blit command encoder</returns>
        public MTLBlitCommandEncoder blitCommandEncoder()
            => objc_msgSend<MTLBlitCommandEncoder>(NativePtr, sel_blitCommandEncoder);

        /// <summary>
        /// Computes the command encoder
        /// </summary>
        /// <returns>The mtl compute command encoder</returns>
        public MTLComputeCommandEncoder computeCommandEncoder()
            => objc_msgSend<MTLComputeCommandEncoder>(NativePtr, sel_computeCommandEncoder);

        /// <summary>
        /// Waits the until completed
        /// </summary>
        public void waitUntilCompleted() => objc_msgSend(NativePtr, sel_waitUntilCompleted);

        /// <summary>
        /// Adds the completed handler using the specified block
        /// </summary>
        /// <param name="block">The block</param>
        public void addCompletedHandler(MTLCommandBufferHandler block)
            => objc_msgSend(NativePtr, sel_addCompletedHandler, block);
        /// <summary>
        /// Adds the completed handler using the specified block
        /// </summary>
        /// <param name="block">The block</param>
        public void addCompletedHandler(IntPtr block)
            => objc_msgSend(NativePtr, sel_addCompletedHandler, block);

        /// <summary>
        /// Gets the value of the status
        /// </summary>
        public MTLCommandBufferStatus status => (MTLCommandBufferStatus)uint_objc_msgSend(NativePtr, sel_status);

        /// <summary>
        /// The sel rendercommandencoderwithdescriptor
        /// </summary>
        private static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        /// <summary>
        /// The sel presentdrawable
        /// </summary>
        private static readonly Selector sel_presentDrawable = "presentDrawable:";
        /// <summary>
        /// The sel commit
        /// </summary>
        private static readonly Selector sel_commit = "commit";
        /// <summary>
        /// The sel blitcommandencoder
        /// </summary>
        private static readonly Selector sel_blitCommandEncoder = "blitCommandEncoder";
        /// <summary>
        /// The sel computecommandencoder
        /// </summary>
        private static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        /// <summary>
        /// The sel waituntilcompleted
        /// </summary>
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        /// <summary>
        /// The sel addcompletedhandler
        /// </summary>
        private static readonly Selector sel_addCompletedHandler = "addCompletedHandler:";
        /// <summary>
        /// The sel status
        /// </summary>
        private static readonly Selector sel_status = "status";
    }
}