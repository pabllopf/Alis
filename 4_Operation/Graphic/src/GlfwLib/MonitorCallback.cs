using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for monitor configuration callback functions.
    /// </summary>
    /// <param name="monitor">The monitor that was connected or disconnected.</param>
    /// <param name="status">The connection status.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MonitorCallback(Monitor monitor, ConnectionStatus status);
}