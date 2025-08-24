using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Joystick buttons event parameters
    /// </summary>
    
    public class JoystickButtonEventArgs : EventArgs
    {
        
        /// <summary>
        /// Construct the joystick button arguments from a joystick button event
        /// </summary>
        /// <param name="e">Joystick button event</param>
        
        public JoystickButtonEventArgs(JoystickButtonEvent e)
        {
            JoystickId = e.JoystickId;
            Button = e.Button;
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[JoystickButtonEventArgs]" +
                   " JoystickId(" + JoystickId + ")" +
                   " Button(" + Button + ")";
        }

        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        /// <summary>Index of the button</summary>
        public uint Button;
    }
}