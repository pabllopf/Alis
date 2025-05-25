using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for window content scale callback functions.
    /// </summary>
    /// <param name="window">The window whose content scale changed.</param>
    /// <param name="xScale">The new x-axis content scale of the window.</param>
    /// <param name="yScale">The new y-axis content scale of the window.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowContentsScaleCallback(Window window, float xScale, float yScale);
}