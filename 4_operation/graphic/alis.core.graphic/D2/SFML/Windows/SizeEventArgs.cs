using System;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Size event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class SizeEventArgs : EventArgs
    {
        /// <summary>New height of the window</summary>
        public uint Height;

        /// <summary>New width of the window</summary>
        public uint Width;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the size arguments from a size event
        /// </summary>
        /// <param name="e">Size event</param>
        ////////////////////////////////////////////////////////////
        public SizeEventArgs(SizeEvent e)
        {
            Width = e.Width;
            Height = e.Height;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[SizeEventArgs]" +
                   " Width(" + Width + ")" +
                   " Height(" + Height + ")";
        }
    }
}