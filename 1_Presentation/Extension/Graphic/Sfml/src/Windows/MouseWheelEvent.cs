using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Mouse wheel move event parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseWheelEvent
    {
        /// <summary>Scroll amount</summary>
        public int Delta;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;
    }
}