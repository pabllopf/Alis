

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Mouse wheel event parameters
    /// </summary>
    public class MouseWheelEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the scroll amount
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        ///     Gets or sets the X coordinate of the mouse cursor
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the mouse cursor
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Construct the mouse wheel arguments from a mouse wheel event
        /// </summary>
        /// <param name="e">Mouse wheel event</param>
        public MouseWheelEventArgs(MouseWheelEvent e)
        {
            Delta = e.Delta;
            X = e.X;
            Y = e.Y;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[MouseWheelEventArgs]" +
                                             " Delta(" + Delta + ")" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")";
    }
}