using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Keyboard event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyEvent
    {
        /// <summary>Code of the key (see KeyCode enum)</summary>
        public Keyboard.Key Code;

        /// <summary>Is the Alt modifier pressed?</summary>
        public int Alt;

        /// <summary>Is the Control modifier pressed?</summary>
        public int Control;

        /// <summary>Is the Shift modifier pressed?</summary>
        public int Shift;

        /// <summary>Is the System modifier pressed?</summary>
        public int System;
    }
}