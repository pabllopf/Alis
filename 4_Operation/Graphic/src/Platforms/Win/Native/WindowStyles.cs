#if WIN
using System;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// Window styles for Win32 window creation.
    /// </summary>
    [Flags]
    public enum WindowStyles : int
    {
        /// <summary>
        /// 
        /// </summary>
        OverlappedWindow = 0x00CF0000,
        
        /// <summary>
        /// 
        /// </summary>
        Visible = 0x10000000
    }
}

#endif