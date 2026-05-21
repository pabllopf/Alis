

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     This is the function signature for monitor configuration callback functions.
    /// </summary>
    /// <param name="monitor">The monitor that was connected or disconnected.</param>
    /// <param name="status">The connection status.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MonitorCallback(Monitor monitor, ConnectionStatus status);
}