using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse wheel scroll event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseWheelScrollEvent
    {
        /// <summary>Mouse Wheel which triggered the event</summary>
        public Mouse.Wheel Wheel;

        /// <summary>Scroll amount</summary>
        public float Delta;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;
    }
}