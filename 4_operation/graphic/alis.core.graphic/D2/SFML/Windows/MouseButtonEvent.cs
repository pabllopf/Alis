using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Mouse buttons event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseButtonEvent
    {
        /// <summary>Code of the button (see MouseButton enum)</summary>
        public Mouse.Button Button;

        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;
    }
}