

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    ///     ShowWindow commands.
    /// </summary>
    [Flags]
    public enum ShowWindowCommand
    {
        /// <summary>
        /// </summary>
        Hide = 0,

        /// <summary>
        /// </summary>
        Show = 5
    }
}

#endif