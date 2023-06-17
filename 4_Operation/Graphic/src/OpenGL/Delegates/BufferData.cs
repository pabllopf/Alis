using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The buffer data
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage);
}