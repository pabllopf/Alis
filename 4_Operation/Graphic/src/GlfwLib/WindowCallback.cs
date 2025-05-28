using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     Generic signature for window callbacks.
    /// </summary>
    /// <param name="window">The window handle.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WindowCallback(Window window);
}