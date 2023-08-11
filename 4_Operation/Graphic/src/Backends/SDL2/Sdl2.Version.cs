using System.Runtime.InteropServices;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl getversion
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetVersion_t(SDL_version* version);
        /// <summary>
        /// The sdl getversion
        /// </summary>
        private static SDL_GetVersion_t s_getVersion = LoadFunction<SDL_GetVersion_t>("SDL_GetVersion");
        /// <summary>
        /// Sdls the get version using the specified version
        /// </summary>
        /// <param name="version">The version</param>
        public static void SDL_GetVersion(SDL_version* version) => s_getVersion(version);
    }

    /// <summary>
    /// The sdl version
    /// </summary>
    public struct SDL_version
    {
        /// <summary>
        /// The major
        /// </summary>
        public byte major;
        /// <summary>
        /// The minor
        /// </summary>
        public byte minor;
        /// <summary>
        /// The patch
        /// </summary>
        public byte patch;
    }
}
