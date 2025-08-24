using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Joystick axis move event parameters
    /// </summary>
    
    public class JoystickMoveEventArgs : EventArgs
    {
        
        /// <summary>
        /// Construct the joystick move arguments from a joystick move event
        /// </summary>
        /// <param name="e">Joystick move event</param>
        
        public JoystickMoveEventArgs(JoystickMoveEvent e)
        {
            JoystickId = e.JoystickId;
            Axis = e.Axis;
            Position = e.Position;
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[JoystickMoveEventArgs]" +
                   " JoystickId(" + JoystickId + ")" +
                   " Axis(" + Axis + ")" +
                   " Position(" + Position + ")";
        }

        /// <summary>Index of the joystick which triggered the event</summary>
        public uint JoystickId;

        /// <summary>Joystick axis (see JoyAxis enum)</summary>
        public Joystick.Axis Axis;

        /// <summary>Current position of the axis</summary>
        public float Position;
    }
}