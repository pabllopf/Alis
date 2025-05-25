using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for window maximize/restore callback functions.
    /// </summary>
    /// <param name="window">The window that was maximized or restored.</param>
    /// <param name="maximized"><c>true</c> if the window was maximized, or <c>false</c> if it was restored.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowMaximizedCallback(Window window, bool maximized);
}