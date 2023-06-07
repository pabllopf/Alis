using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl mousewheelevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlMouseWheelEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;

        /// <summary>
        ///     The which
        /// </summary>
        public uint which;

        /// <summary>
        ///     The
        /// </summary>
        public int x; /* amount scrolled horizontally */

        /// <summary>
        ///     The
        /// </summary>
        public int y; /* amount scrolled vertically */

        /// <summary>
        ///     The direction
        /// </summary>
        public uint direction; /* Set to one of the SDL_MOUSEWHEEL_* defines */

        /// <summary>
        ///     The precise
        /// </summary>
        public float preciseX; /* Requires >= 2.0.18 */

        /// <summary>
        ///     The precise
        /// </summary>
        public float preciseY; /* Requires >= 2.0.18 */
    }
}