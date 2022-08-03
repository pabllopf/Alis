using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Touch event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class TouchEventArgs : EventArgs
    {
        /// <summary>Index of the finger in case of multi-touch events</summary>
        public uint Finger;

        /// <summary>X position of the touch, relative to the left of the owner window</summary>
        public int X;

        /// <summary>Y position of the touch, relative to the top of the owner window</summary>
        public int Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the touch arguments from a touch event
        /// </summary>
        /// <param name="e">Touch event</param>
        ////////////////////////////////////////////////////////////
        public TouchEventArgs(TouchEvent e)
        {
            Finger = e.Finger;
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
            return "[TouchEventArgs]" +
                   " Finger(" + Finger + ")" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")";
        }
    }
}