using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticramp
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlHapticRamp
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

        // Ramp
        /// <summary>
        ///     The start
        /// </summary>
        public short start;

        /// <summary>
        ///     The end
        /// </summary>
        public short end;

        // Envelope
        /// <summary>
        ///     The attack length
        /// </summary>
        public ushort attack_length;

        /// <summary>
        ///     The attack level
        /// </summary>
        public ushort attack_level;

        /// <summary>
        ///     The fade length
        /// </summary>
        public ushort fade_length;

        /// <summary>
        ///     The fade level
        /// </summary>
        public ushort fade_level;
    }
}