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
        public ushort[] right_sat = new ushort[3];

        /// <summary>
        ///     The left sat
        /// </summary>
        public ushort[] left_sat = new ushort[3];

        /// <summary>
        ///     The right coeff
        /// </summary>
        public short[] right_coeff = new short[3];

        /// <summary>
        ///     The left coeff
        /// </summary>
        public short[] left_coeff = new short[3];

        /// <summary>
        ///     The deadband
        /// </summary>
        public ushort[] deadband = new ushort[3];

        /// <summary>
        ///     The center
        /// </summary>
        public short[] center = new short[3];

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlHapticCondition"/> class
        /// </summary>
        public SdlHapticCondition()
        {
            type = 0;
            direction = default;
            length = 0;
            delay = 0;
            button = 0;
            interval = 0;
         right_sat = new ushort[3];

         left_sat = new ushort[3];

        right_coeff = new short[3];

        left_coeff = new short[3];

        deadband = new ushort[3];
        
        center = new short[3];
        }
    }
}