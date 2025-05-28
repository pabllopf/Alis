using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for window iconify/restore callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="focusing"><c>true</c> if window is iconified; otherwise <c>false</c> if restoring.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void IconifyCallback(IntPtr window, bool focusing);
}