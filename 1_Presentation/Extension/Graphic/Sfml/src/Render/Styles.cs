using System;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Enumerate the string drawing styles
    /// </summary>
    [Flags]
    public enum Styles
    {
        /// <summary>Regular characters, no style</summary>
        Regular = 0,

        /// <summary>Bold characters</summary>
        Bold = 1 << 0,

        /// <summary>Italic characters</summary>
        Italic = 1 << 1,

        /// <summary>Underlined characters</summary>
        Underlined = 1 << 2,

        /// <summary>Strike through characters</summary>
        StrikeThrough = 1 << 3
    }
}