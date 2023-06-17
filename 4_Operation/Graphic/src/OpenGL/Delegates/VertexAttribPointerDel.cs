using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The vertex attrib pointer del
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void VertexAttribPointerDel(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer);
}