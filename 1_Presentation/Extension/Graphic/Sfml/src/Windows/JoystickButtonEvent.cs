using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Joystick buttons event parameters
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickButtonEvent
    {
        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        /// <summary>Index of the button</summary>
        public uint Button;
    }
}