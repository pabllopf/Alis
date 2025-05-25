using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
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