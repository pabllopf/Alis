

using System;

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes attribute flags enum
    /// </summary>
    [Flags]
    public enum ImNodesConfig
    {
        /// <summary>
        ///     The none im nodes attribute flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The enable link detach with drag click im nodes attribute flags
        /// </summary>
        EnableLinkDetachWithDragClick = 1,

        /// <summary>
        ///     The enable link creation on snap im nodes attribute flags
        /// </summary>
        EnableLinkCreationOnSnap = 2
    }
}