

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     The ns point
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NsPoint
    {
        /// <summary>
        ///     The
        /// </summary>
        public double X;

        /// <summary>
        ///     The
        /// </summary>
        public double Y;
    }
}