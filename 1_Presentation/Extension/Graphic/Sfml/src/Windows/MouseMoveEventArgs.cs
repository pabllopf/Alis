

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Mouse move event parameters
    /// </summary>
    public class MouseMoveEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the mouse cursor
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the mouse cursor
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Construct the mouse move arguments from a mouse move event
        /// </summary>
        /// <param name="e">Mouse move event</param>
        public MouseMoveEventArgs(MouseMoveEvent e)
        {
            X = e.X;
            Y = e.Y;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[MouseMoveEventArgs]" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")";
    }
}