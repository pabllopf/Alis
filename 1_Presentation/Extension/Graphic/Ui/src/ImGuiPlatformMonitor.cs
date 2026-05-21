

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui platform monitor
    /// </summary>
    public struct ImGuiPlatformMonitor
    {
        /// <summary>
        ///     The main pos
        /// </summary>
        public Vector2F MainPos { get; set; }

        /// <summary>
        ///     The main size
        /// </summary>
        public Vector2F MainSize { get; set; }

        /// <summary>
        ///     The work pos
        /// </summary>
        public Vector2F WorkPos { get; set; }

        /// <summary>
        ///     The work size
        /// </summary>
        public Vector2F WorkSize { get; set; }

        /// <summary>
        ///     The dpi scale
        /// </summary>
        public float DpiScale { get; set; }
    }
}