using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Joystick connection/disconnection event parameters
    /// </summary>
    
    public class JoystickConnectEventArgs : EventArgs
    {
        
        /// <summary>
        /// Construct the joystick connect arguments from a joystick connect event
        /// </summary>
        /// <param name="e">Joystick button event</param>
        
        public JoystickConnectEventArgs(JoystickConnectEvent e)
        {
            JoystickId = e.JoystickId;
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[JoystickConnectEventArgs]" +
                   " JoystickId(" + JoystickId + ")";
        }

        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;
    }
}