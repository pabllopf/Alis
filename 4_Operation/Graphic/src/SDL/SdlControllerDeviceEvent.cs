using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl controllerdeviceevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlControllerDeviceEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The which
        /// </summary>
        public int which; /* joystick id for ADDED,
						 * else instance id
						 */
    }
}