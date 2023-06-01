using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl dollargestureevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlDollarGestureEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The touch id
        /// </summary>
        public long touchId; // SDL_TouchID

        /// <summary>
        ///     The gesture id
        /// </summary>
        public long gestureId; // SDL_GestureID

        /// <summary>
        ///     The num fingers
        /// </summary>
        public uint numFingers;

        /// <summary>
        ///     The error
        /// </summary>
        public float error;

        /// <summary>
        ///     The
        /// </summary>
        public float x;

        /// <summary>
        ///     The
        /// </summary>
        public float y;
    }
}