

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes io
    /// </summary>
    public struct ImNodesIo
    {
        /// <summary>
        ///     The emulate three button mouse
        /// </summary>
        public EmulateThreeButtonMouse ThreeButtonMouse { get; set; }

        /// <summary>
        ///     The link detach with modifier click
        /// </summary>
        public LinkDetachWithModifierClick DetachWithModifierClick { get; set; }

        /// <summary>
        ///     The multiple select modifier
        /// </summary>
        public MultipleSelectModifier SelectModifier { get; set; }

        /// <summary>
        ///     The alt mouse button
        /// </summary>
        public int AltMouseButton { get; set; }

        /// <summary>
        ///     The auto panning speed
        /// </summary>
        public float AutoPanningSpeed { get; set; }
    }
}