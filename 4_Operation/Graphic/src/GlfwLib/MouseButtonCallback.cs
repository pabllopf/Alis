using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for mouse button callback functions.
    /// </summary>
    /// <param name="window">The window handle.</param>
    /// <param name="button">TThe mouse button that was pressed or released.</param>
    /// <param name="state">The state.</param>
    /// <param name="modifiers">Flags describing which modifier keys were held down.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MouseButtonCallback(Window window, MouseButton button, InputState state,
        ModifierKeys modifiers);
}