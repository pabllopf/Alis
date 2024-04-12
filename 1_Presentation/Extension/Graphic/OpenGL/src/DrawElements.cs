using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.OpenGL.Enums;

namespace Alis.Extension.Graphic.OpenGL
{
    /// <summary>
    ///     The draw elements
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DrawElements(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices);
}