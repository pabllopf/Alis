using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for Unicode character callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="codePoint">The Unicode code point of the character.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CharCallback(Window window, uint codePoint);
}