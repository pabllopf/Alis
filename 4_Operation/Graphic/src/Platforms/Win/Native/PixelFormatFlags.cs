#if WIN

using System;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// Pixel format flags for OpenGL context.
    /// </summary>
    [Flags]
    public enum PixelFormatFlags : uint
    {
        /// <summary>
        /// 
        /// </summary>
        DrawToWindow = 0x00000004,
        
        /// <summary>
        /// 
        /// </summary>
        SupportOpenGL = 0x00000020,
        
        /// <summary>
        /// 
        /// </summary>
        DoubleBuffer = 0x00000001
    }
}
#endif