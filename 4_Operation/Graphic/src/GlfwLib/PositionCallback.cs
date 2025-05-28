using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for cursor position callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="x">The new cursor x-coordinate, relative to the left edge of the client area.</param>
    /// <param name="y">The new cursor y-coordinate, relative to the left edge of the client area.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void PositionCallback(Window window, double x, double y);
}