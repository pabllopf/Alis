using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Joystick buttons event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class JoystickButtonEventArgs : EventArgs
    {
        /// <summary>Index of the button</summary>
        public uint Button;

        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the joystick button arguments from a joystick button event
        /// </summary>
        /// <param name="e">Joystick button event</param>
        ////////////////////////////////////////////////////////////
        public JoystickButtonEventArgs(JoystickButtonEvent e)
        {
            JoystickId = e.JoystickId;
            Button = e.Button;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[JoystickButtonEventArgs]" +
                   " JoystickId(" + JoystickId + ")" +
                   " Button(" + Button + ")";
        }
    }
}