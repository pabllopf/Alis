using System;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Text event parameters
    /// </summary>
    
    public class TextEventArgs : EventArgs
    {
        
        /// <summary>
        /// Construct the text arguments from a text event
        /// </summary>
        /// <param name="e">Text event</param>
        
        public TextEventArgs(TextEvent e)
        {
            Unicode = Char.ConvertFromUtf32((int)e.Unicode);
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[TextEventArgs]" +
                   " Unicode(" + Unicode + ")";
        }

        /// <summary>UTF-16 value of the character</summary>
        public string Unicode;
    }
}