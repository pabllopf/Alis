

#if winx64 || winx86 || winarm64 || winarm || win
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        /// <summary>
        /// </summary>
        public int Left;

        /// <summary>
        /// </summary>
        public int Top;

        /// <summary>
        /// </summary>
        public int Right;

        /// <summary>
        /// </summary>
        public int Bottom;
    }
}

#endif