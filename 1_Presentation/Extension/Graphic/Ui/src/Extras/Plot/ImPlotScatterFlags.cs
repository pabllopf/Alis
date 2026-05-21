

using System;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot scatter flags enum
    /// </summary>
    [Flags]
    public enum ImPlotScatterFlags
    {
        /// <summary>
        ///     The none im plot scatter flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no clip im plot scatter flags
        /// </summary>
        NoClip = 1024
    }
}