using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for Unicode character callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="codePoint">The Unicode code point of the character.</param>
    /// <param name="mods">Bit field describing which modifier keys were held down.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CharModsCallback(Window window, uint codePoint, ModifierKeys mods);
}