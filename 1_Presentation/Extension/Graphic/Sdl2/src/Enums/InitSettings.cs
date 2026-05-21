

using System;

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl init enum
    /// </summary>
    [Flags]
    public enum InitSettings : uint
    {
        /// <summary>
        ///     The sdl init timer
        /// </summary>
        InitTimer = 0x00000001,

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        InitAudio = 0x00000010,

        /// <summary>
        ///     The sdl init video
        /// </summary>
        InitVideo = 0x00000020,

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        InitJoystick = 0x00000200,

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        InitHaptic = 0x00001000,

        /// <summary>
        ///     The sdl init game controller
        /// </summary>
        InitGameController = 0x00002000,

        /// <summary>
        ///     The sdl init events
        /// </summary>
        InitEvents = 0x00004000,

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        InitSensor = 0x00008000,

        /// <summary>
        ///     The init everything sdl init
        /// </summary>
        InitEverything = InitTimer | InitAudio | InitVideo | InitJoystick | InitHaptic | InitGameController | InitEvents | InitSensor
    }
}