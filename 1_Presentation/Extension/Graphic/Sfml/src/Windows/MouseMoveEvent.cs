using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Mouse move event parameters
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseMoveEvent
    {
        /// <summary>X coordinate of the mouse cursor</summary>
        public int X;

        /// <summary>Y coordinate of the mouse cursor</summary>
        public int Y;
    }
}