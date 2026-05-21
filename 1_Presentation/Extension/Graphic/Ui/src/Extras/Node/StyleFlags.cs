

using System;

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The style flags enum
    /// </summary>
    [Flags]
    public enum StyleFlags
    {
        /// <summary>
        ///     The none style flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The node outline style flags
        /// </summary>
        NodeOutline = 1,

        /// <summary>
        ///     The grid lines style flags
        /// </summary>
        GridLines = 4
    }
}