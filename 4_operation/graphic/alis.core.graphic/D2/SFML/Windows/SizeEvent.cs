using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Size event parameters
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct SizeEvent
    {
        /// <summary>New width of the window</summary>
        public uint Width;

        /// <summary>New height of the window</summary>
        public uint Height;
    }
}