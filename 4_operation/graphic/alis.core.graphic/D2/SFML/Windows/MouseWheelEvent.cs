using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse wheel move event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    [Obsolete("MouseWheelEvent is deprecated, please use MouseWheelScrollEvent instead")]
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