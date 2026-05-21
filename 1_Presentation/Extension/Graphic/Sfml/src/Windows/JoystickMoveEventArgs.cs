

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Joystick axis move event parameters
    /// </summary>
    public class JoystickMoveEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the joystick axis (see JoyAxis enum)
        /// </summary>
        public Joystick.Axis Axis { get; set; }

        /// <summary>
        ///     Gets or sets the index of the joystick which triggered the event
        /// </summary>
        public uint JoystickId { get; set; }

        /// <summary>
        ///     Gets or sets the current position of the axis
        /// </summary>
        public float Position { get; set; }

        /// <summary>
        ///     Construct the joystick move arguments from a joystick move event
        /// </summary>
        /// <param name="e">Joystick move event</param>
        public JoystickMoveEventArgs(JoystickMoveEvent e)
        {
            JoystickId = e.JoystickId;
            Axis = e.Axis;
            Position = e.Position;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[JoystickMoveEventArgs]" +
                                             " JoystickId(" + JoystickId + ")" +
                                             " Axis(" + Axis + ")" +
                                             " Position(" + Position + ")";
    }
}