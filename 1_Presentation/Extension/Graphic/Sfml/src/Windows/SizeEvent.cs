using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Size event parameters
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct SizeEvent
    {
        /// <summary>New width of the window</summary>
        public uint Width;

        /// <summary>New height of the window</summary>
        public uint Height;
    }
}