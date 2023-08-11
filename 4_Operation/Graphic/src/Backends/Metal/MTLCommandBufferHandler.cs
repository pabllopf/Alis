using System;
using System.Runtime.InteropServices;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl command buffer handler
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MTLCommandBufferHandler(IntPtr block, MTLCommandBuffer buffer);
}