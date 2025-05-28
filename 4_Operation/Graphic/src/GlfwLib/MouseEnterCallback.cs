using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for cursor enter/leave callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="entering"><c>true</c> if cursor is entering the window client area; otherwise <c>false</c>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MouseEnterCallback(Window window, bool entering);
}