

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     Class styles for window registration.
    /// </summary>
    [Flags]
    public enum ClassStyles : uint
    {
        /// <summary>
        /// </summary>
        OwnDC = 0x0020
    }
}
#endif