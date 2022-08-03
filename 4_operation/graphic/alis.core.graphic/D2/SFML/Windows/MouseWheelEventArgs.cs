using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse wheel event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [Obsolete("MouseWheelEventArgs is deprecated, please use MouseWheelScrollEventArgs instead")]
    public class MouseWheelEventArgs : EventArgs
    {
        /// <summary>Scroll amount</summary>
        public int Delta;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the mouse wheel arguments from a mouse wheel event
        /// </summary>
        /// <param name="e">Mouse wheel event</param>
        ////////////////////////////////////////////////////////////
        public MouseWheelEventArgs(MouseWheelEvent e)
        {
            Delta = e.Delta;
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
            return "[MouseWheelEventArgs]" +
                   " Delta(" + Delta + ")" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")";
        }
    }
}