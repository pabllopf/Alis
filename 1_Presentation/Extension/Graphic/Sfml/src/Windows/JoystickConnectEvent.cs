using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Joystick connect event parameters
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct JoystickConnectEvent
    {
        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;
    }
}