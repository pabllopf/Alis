using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticcondition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticCondition
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
        public ushort[] right_sat;

        /// <summary>
        ///     The left sat
        /// </summary>
        public ushort[] left_sat;

        /// <summary>
        ///     The right coeff
        /// </summary>
        public short[] right_coeff;

        /// <summary>
        ///     The left coeff
        /// </summary>
        public short[] left_coeff;

        /// <summary>
        ///     The deadband
        /// </summary>
        public ushort[] deadband ;
        /// <summary>
        ///     The center
        /// </summary>
        public short[] center;
    }
}