

#if osxarm64 || osxarm || osxx64 || osx



namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Represents a native Core Graphics point.
    /// </summary>
    internal struct CGPoint
    {
        /// <summary>
        ///     The horizontal coordinate.
        /// </summary>
        public double X;

        /// <summary>
        ///     The vertical coordinate.
        /// </summary>
        public double Y;
    }
}
#endif