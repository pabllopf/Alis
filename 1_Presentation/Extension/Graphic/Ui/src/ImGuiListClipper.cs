

using System;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui list clipper
    /// </summary>
    public struct ImGuiListClipper
    {
        /// <summary>
        ///     The display start
        /// </summary>
        public int DisplayStart { get; set; }

        /// <summary>
        ///     The display end
        /// </summary>
        public int DisplayEnd { get; set; }

        /// <summary>
        ///     The items count
        /// </summary>
        public int ItemsCount { get; set; }

        /// <summary>
        ///     The items height
        /// </summary>
        public float ItemsHeight { get; set; }

        /// <summary>
        ///     The start pos
        /// </summary>
        public float StartPosY { get; set; }

        /// <summary>
        ///     The temp data
        /// </summary>
        public IntPtr TempData { get; set; }
    }
}