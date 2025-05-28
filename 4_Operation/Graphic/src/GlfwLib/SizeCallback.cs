using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for window size callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="width">The new width, in screen coordinates, of the window.</param>
    /// <param name="height">The new height, in screen coordinates, of the window.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SizeCallback(Window window, int width, int height);
}