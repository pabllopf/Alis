using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui platform monitor
    /// </summary>
    public struct ImGuiPlatformMonitor
    {
        /// <summary>
        /// The main pos
        /// </summary>
        public Vector2 MainPos;
        /// <summary>
        /// The main size
        /// </summary>
        public Vector2 MainSize;
        /// <summary>
        /// The work pos
        /// </summary>
        public Vector2 WorkPos;
        /// <summary>
        /// The work size
        /// </summary>
        public Vector2 WorkSize;
        /// <summary>
        /// The dpi scale
        /// </summary>
        public float DpiScale;
    }
}
