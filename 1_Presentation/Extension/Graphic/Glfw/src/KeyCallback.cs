

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     This is the function signature for keyboard key callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="key">The keyboard key that was pressed or released.</param>
    /// <param name="scanCode">The system-specific scancode of the key.</param>
    /// <param name="state">The state of the key.</param>
    /// <param name="mods">	Bit field describing which modifier keys were held down.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void KeyCallback(Window window, Keys key, int scanCode, InputState state, ModifierKeys mods);
}