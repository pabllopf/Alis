using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    
    /// <summary>
    /// Keyboard event parameters
    /// </summary>
    
    public class KeyEventArgs : EventArgs
    {
        
        /// <summary>
        /// Construct the key arguments from a key event
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
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[KeyEventArgs]" +
                   " Code(" + Code + ")" +
                   " Alt(" + Alt + ")" +
                   " Control(" + Control + ")" +
                   " Shift(" + Shift + ")" +
                   " System(" + System + ")";
        }

        /// <summary>Code of the key (see KeyCode enum)</summary>
        public Keyboard.Key Code;

        /// <summary>Is the Alt modifier pressed?</summary>
        public bool Alt;

        /// <summary>Is the Control modifier pressed?</summary>
        public bool Control;

        /// <summary>Is the Shift modifier pressed?</summary>
        public bool Shift;

        /// <summary>Is the System modifier pressed?</summary>
        public bool System;
    }

    

    

    

    

    

    

    

    

    

    

    
}
