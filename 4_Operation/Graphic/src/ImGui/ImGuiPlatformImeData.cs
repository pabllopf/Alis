using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui platform ime data
    /// </summary>
    public struct ImGuiPlatformImeData
    {
        /// <summary>
        /// The want visible
        /// </summary>
        public byte WantVisible;
        /// <summary>
        /// The input pos
        /// </summary>
        public Vector2 InputPos;
        /// <summary>
        /// The input line height
        /// </summary>
        public float InputLineHeight;
    }
}
