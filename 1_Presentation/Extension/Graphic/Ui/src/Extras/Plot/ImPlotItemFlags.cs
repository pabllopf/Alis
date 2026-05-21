

using System;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot item flags enum
    /// </summary>
    [Flags]
    public enum ImPlotItemFlags
    {
        /// <summary>
        ///     The none im plot item flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no legend im plot item flags
        /// </summary>
        NoLegend = 1,

        /// <summary>
        ///     The no fit im plot item flags
        /// </summary>
        NoFit = 2
    }
}