

using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui size callback data
    /// </summary>
    public struct ImGuiSizeCallbackData
    {
        /// <summary>
        ///     The user data
        /// </summary>
        public IntPtr UserData { get; set; }

        /// <summary>
        ///     The pos
        /// </summary>
        public Vector2F Pos { get; set; }

        /// <summary>
        ///     The current size
        /// </summary>
        public Vector2F CurrentSize { get; set; }

        /// <summary>
        ///     The desired size
        /// </summary>
        public Vector2F DesiredSize { get; set; }
    }
}