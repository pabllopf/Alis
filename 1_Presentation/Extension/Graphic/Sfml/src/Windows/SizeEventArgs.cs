

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Size event parameters
    /// </summary>
    public class SizeEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the new height of the window
        /// </summary>
        public uint Height { get; set; }

        /// <summary>
        ///     Gets or sets the new width of the window
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        ///     Construct the size arguments from a size event
        /// </summary>
        /// <param name="e">Size event</param>
        public SizeEventArgs(SizeEvent e)
        {
            Width = e.Width;
            Height = e.Height;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[SizeEventArgs]" +
                                             " Width(" + Width + ")" +
                                             " Height(" + Height + ")";
    }
}