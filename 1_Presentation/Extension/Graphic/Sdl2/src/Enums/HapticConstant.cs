

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The haptic constant enum
    /// </summary>
    public enum HapticConstant : ushort
    {
        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        HapticConstant = 1 << 0,

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        HapticSine = 1 << 1,

        /// <summary>
        ///     The sdl haptic left right
        /// </summary>
        HapticLeftRight = 1 << 2,

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        HapticTriangle = 1 << 3,

        /// <summary>
        ///     The sdl haptic saw tooth up
        /// </summary>
        HapticSawToothUp = 1 << 4,

        /// <summary>
        ///     The sdl haptic saw tooth down
        /// </summary>
        HapticSawToothDown = 1 << 5,

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        HapticSpring = 1 << 7,

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        HapticDamper = 1 << 8,

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        HapticInertia = 1 << 9,

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        HapticFriction = 1 << 10,

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        HapticCustom = 1 << 11,

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        HapticGain = 1 << 12,

        /// <summary>
        ///     The sdl haptic auto center
        /// </summary>
        HapticAutoCenter = 1 << 13,

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        HapticStatus = 1 << 14,

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        HapticPauseVar = 1 << 15
    }
}