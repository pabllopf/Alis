

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui platform ime data
    /// </summary>
    public struct ImGuiPlatformImeData
    {
        /// <summary>
        ///     The want visible
        /// </summary>
        public byte WantVisible { get; set; }

        /// <summary>
        ///     The input pos
        /// </summary>
        public Vector2F InputPos { get; set; }

        /// <summary>
        ///     The input line height
        /// </summary>
        public float InputLineHeight { get; set; }
    }
}