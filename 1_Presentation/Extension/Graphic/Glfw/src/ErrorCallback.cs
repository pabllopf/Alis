

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Function signature for receiving error callbacks.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">A pointer to the UTF-8 encoded (null-terminated) error message.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorCallback(ErrorCode code, IntPtr message);
}