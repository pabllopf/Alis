using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl command queue
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCommandQueue
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Commands the buffer
        /// </summary>
        /// <returns>The mtl command buffer</returns>
        public MTLCommandBuffer commandBuffer() => objc_msgSend<MTLCommandBuffer>(NativePtr, sel_commandBuffer);

        /// <summary>
        /// Inserts the debug capture boundary
        /// </summary>
        public void insertDebugCaptureBoundary() => objc_msgSend(NativePtr, sel_insertDebugCaptureBoundary);

        /// <summary>
        /// The sel commandbuffer
        /// </summary>
        private static readonly Selector sel_commandBuffer = "commandBuffer";
        /// <summary>
        /// The sel insertdebugcaptureboundary
        /// </summary>
        private static readonly Selector sel_insertDebugCaptureBoundary = "insertDebugCaptureBoundary";
    }
}