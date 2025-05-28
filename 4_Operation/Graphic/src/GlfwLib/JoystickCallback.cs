using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Enums;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for joystick configuration callback functions.
    /// </summary>
    /// <param name="joystick">The joystick that was connected or disconnected.</param>
    /// <param name="status">The connection status.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void JoystickCallback(Joystick joystick, ConnectionStatus status);
}