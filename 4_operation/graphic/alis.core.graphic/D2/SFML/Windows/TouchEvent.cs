using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Touch event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct TouchEvent
    {
        /// <summary>Index of the finger in case of multi-touch events</summary>
        public uint Finger;

        /// <summary>X position of the touch, relative to the left of the owner window</summary>
        public int X;

        /// <summary>Y position of the touch, relative to the top of the owner window</summary>
        public int Y;
    }
}