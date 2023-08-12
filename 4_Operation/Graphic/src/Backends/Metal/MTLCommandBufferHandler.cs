using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl command buffer handler
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MTLCommandBufferHandler(IntPtr block, MTLCommandBuffer buffer);
}