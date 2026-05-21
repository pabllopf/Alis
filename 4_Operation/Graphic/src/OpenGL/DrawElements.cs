

using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The draw elements
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DrawElements(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices);
}