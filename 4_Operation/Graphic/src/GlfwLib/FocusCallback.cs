using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for window focus callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="focusing"><c>true</c> if window is gaining focus; otherise <c>false</c>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FocusCallback(Window window, bool focusing);
}