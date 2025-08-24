using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// Text event parameters
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct TextEvent
    {
        /// <summary>UTF-32 value of the character</summary>
        public uint Unicode;
    }
}