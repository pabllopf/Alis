using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Joystick axis move event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickMoveEvent
    {
        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        /// <summary>Joystick axis (see JoyAxis enum)</summary>
        public Joystick.Axis Axis;

        /// <summary>Current position of the axis</summary>
        public float Position;
    }
}