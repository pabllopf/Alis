using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Joystick buttons event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickButtonEvent
    {
        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        /// <summary>Index of the button</summary>
        public uint Button;
    }
}