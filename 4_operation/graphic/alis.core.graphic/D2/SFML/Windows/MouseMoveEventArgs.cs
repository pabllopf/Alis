using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse move event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class MouseMoveEventArgs : EventArgs
    {
        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the mouse move arguments from a mouse move event
        /// </summary>
        /// <param name="e">Mouse move event</param>
        ////////////////////////////////////////////////////////////
        public MouseMoveEventArgs(MouseMoveEvent e)
        {
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
            return "[MouseMoveEventArgs]" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")";
        }
    }
}