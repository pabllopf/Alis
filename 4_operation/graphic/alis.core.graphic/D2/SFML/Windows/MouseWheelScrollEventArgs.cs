using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse wheel scroll event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class MouseWheelScrollEventArgs : EventArgs
    {
        /// <summary>Scroll amount</summary>
        public float Delta;

        /// <summary>Mouse Wheel which triggered the event</summary>
        public Mouse.Wheel Wheel;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the mouse wheel scroll arguments from a mouse wheel scroll event
        /// </summary>
        /// <param name="e">Mouse wheel scroll event</param>
        ////////////////////////////////////////////////////////////
        public MouseWheelScrollEventArgs(MouseWheelScrollEvent e)
        {
            Delta = e.Delta;
            Wheel = e.Wheel;
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
            return "[MouseWheelScrollEventArgs]" +
                   " Wheel(" + Wheel + ")" +
                   " Delta(" + Delta + ")" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")";
        }
    }
}