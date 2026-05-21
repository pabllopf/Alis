

#if osxarm64 || osxarm || osxx64 || osx
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     The ns rect
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NsRect
    {
        /// <summary>
        ///     The
        /// </summary>
        public double x;

        /// <summary>
        ///     The
        /// </summary>
        public double y;

        /// <summary>
        ///     The width
        /// </summary>
        public double width;

        /// <summary>
        ///     The height
        /// </summary>
        public double height;
    }
}

#endif