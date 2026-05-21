

using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Keyboard event parameters
    /// </summary>
    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets whether the Alt modifier is pressed
        /// </summary>
        public bool Alt { get; set; }

        /// <summary>
        ///     Gets or sets the code of the key (see KeyCode enum)
        /// </summary>
        public Keyboard.Key Code { get; set; }

        /// <summary>
        ///     Gets or sets whether the Control modifier is pressed
        /// </summary>
        public bool Control { get; set; }

        /// <summary>
        ///     Gets or sets whether the Shift modifier is pressed
        /// </summary>
        public bool Shift { get; set; }

        /// <summary>
        ///     Gets or sets whether the System modifier is pressed
        /// </summary>
        public bool System { get; set; }

        /// <summary>
        ///     Construct the key arguments from a key event
        /// </summary>
        /// <param name="e">Key event</param>
        public KeyEventArgs(KeyEvent e)
        {
            Code = e.Code;
            Alt = e.Alt != 0;
            Control = e.Control != 0;
            Shift = e.Shift != 0;
            System = e.System != 0;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[KeyEventArgs]" +
                                             " Code(" + Code + ")" +
                                             " Alt(" + Alt + ")" +
                                             " Control(" + Control + ")" +
                                             " Shift(" + Shift + ")" +
                                             " System(" + System + ")";
    }
}