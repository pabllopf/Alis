using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The im nodes io
    /// </summary>
    public struct ImNodesIo
    {
        /// <summary>
        /// The emulate three button mouse
        /// </summary>
        public EmulateThreeButtonMouse EmulateThreeButtonMouse;
        /// <summary>
        /// The link detach with modifier click
        /// </summary>
        public LinkDetachWithModifierClick LinkDetachWithModifierClick;
        /// <summary>
        /// The multiple select modifier
        /// </summary>
        public MultipleSelectModifier MultipleSelectModifier;
        /// <summary>
        /// The alt mouse button
        /// </summary>
        public int AltMouseButton;
        /// <summary>
        /// The auto panning speed
        /// </summary>
        public float AutoPanningSpeed;
    }
}
