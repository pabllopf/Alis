using System;
using System.Runtime.InteropServices;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl init
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_Init_t(SDLInitFlags flags);
        /// <summary>
        /// The sdl init
        /// </summary>
        private static SDL_Init_t s_sdl_init = LoadFunction<SDL_Init_t>("SDL_Init");

        /// <summary>
        /// Sdls the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        public static int SDL_Init(SDLInitFlags flags) => s_sdl_init(flags);
    }

    /// <summary>
    /// The sdl init flags enum
    /// </summary>
    public enum SDLInitFlags : uint
    {
        /// <summary>
        /// The timer sdl init flags
        /// </summary>
        Timer = 0x00000001u,
        /// <summary>
        /// The audio sdl init flags
        /// </summary>
        Audio = 0x00000010u,
        /// <summary>
        /// The video sdl init flags
        /// </summary>
        Video = 0x00000020u,
        /// <summary>
        /// The joystick sdl init flags
        /// </summary>
        Joystick = 0x00000200u,
        /// <summary>
        /// The haptic sdl init flags
        /// </summary>
        Haptic = 0x00001000u,
        /// <summary>
        /// The game controller sdl init flags
        /// </summary>
        GameController = 0x00002000u,
    }
}
