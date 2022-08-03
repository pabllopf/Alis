using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse buttons event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class MouseButtonEventArgs : EventArgs
    {
        /// <summary>Code of the button (see MouseButton enum)</summary>
        public Mouse.Button Button;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the mouse button arguments from a mouse button event
        /// </summary>
        /// <param name="e">Mouse button event</param>
        ////////////////////////////////////////////////////////////
        public MouseButtonEventArgs(MouseButtonEvent e)
        {
            Button = e.Button;
            X = e.X;
            Y = e.Y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[MouseButtonEventArgs]" +
                   " Button(" + Button + ")" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")";
        }
    }
}