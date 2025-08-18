#if WIN

using System;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// Class styles for window registration.
    /// </summary>
    [Flags]
    public enum ClassStyles : uint
    {
        OwnDC = 0x0020
    }
}
#endif