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
        OverlappedWindow = 0x00CF0000,
        Visible = 0x10000000
    }
}

#endif