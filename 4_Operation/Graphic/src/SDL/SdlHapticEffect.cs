using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl hapticeffect
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SdlHapticEffect
    {
        /// <summary>
        ///     The type
        /// </summary>
        [FieldOffset(0)] public ushort type;

        /// <summary>
        ///     The constant
        /// </summary>
        [FieldOffset(0)] public SdlHapticConstant constant;

        /// <summary>
        ///     The periodic
        /// </summary>
        [FieldOffset(0)] public SdlHapticPeriodic periodic;

        /// <summary>
        ///     The condition
        /// </summary>
        [FieldOffset(0)] public SdlHapticCondition condition;

        /// <summary>
        ///     The ramp
        /// </summary>
        [FieldOffset(0)] public SdlHapticRamp ramp;

        /// <summary>
        ///     The leftright
        /// </summary>
        [FieldOffset(0)] public SdlHapticLeftRight leftright;

        /// <summary>
        ///     The custom
        /// </summary>
        [FieldOffset(0)] public SdlHapticCustom custom;
    }
}