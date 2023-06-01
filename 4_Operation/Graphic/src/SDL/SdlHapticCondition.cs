using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticcondition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SdlHapticCondition
    {
        // Header
        /// <summary>
        ///     The type
        /// </summary>
        public ushort type;

        /// <summary>
        ///     The direction
        /// </summary>
        public SdlHapticDirection direction;

        // Replay
        /// <summary>
        ///     The length
        /// </summary>
        public uint length;

        /// <summary>
        ///     The delay
        /// </summary>
        public ushort delay;

        // Trigger
        /// <summary>
        ///     The button
        /// </summary>
        public ushort button;

        /// <summary>
        ///     The interval
        /// </summary>
        public ushort interval;

        // Condition
        /// <summary>
        ///     The right sat
        /// </summary>
        public fixed ushort right_sat[3];

        /// <summary>
        ///     The left sat
        /// </summary>
        public fixed ushort left_sat[3];

        /// <summary>
        ///     The right coeff
        /// </summary>
        public fixed short right_coeff[3];

        /// <summary>
        ///     The left coeff
        /// </summary>
        public fixed short left_coeff[3];

        /// <summary>
        ///     The deadband
        /// </summary>
        public fixed ushort deadband[3];

        /// <summary>
        ///     The center
        /// </summary>
        public fixed short center[3];
    }
}