

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Touch event parameters
    /// </summary>
    public class TouchEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the index of the finger in case of multi-touch events
        /// </summary>
        public uint Finger { get; set; }

        /// <summary>
        ///     Gets or sets the X position of the touch, relative to the left of the owner window
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y position of the touch, relative to the top of the owner window
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Construct the touch arguments from a touch event
        /// </summary>
        /// <param name="e">Touch event</param>
        public TouchEventArgs(TouchEvent e)
        {
            Finger = e.Finger;
            X = e.X;
            Y = e.Y;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[TouchEventArgs]" +
                                             " Finger(" + Finger + ")" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")";
    }
}