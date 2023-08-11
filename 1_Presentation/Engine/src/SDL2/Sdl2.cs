using NativeLibraryLoader;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NativeLibrary = NativeLibraryLoader.NativeLibrary;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The load sdl
        /// </summary>
        private static readonly NativeLibrary s_sdl2Lib = LoadSdl2();
        /// <summary>
        /// Loads the sdl 2
        /// </summary>
        /// <returns>The lib</returns>
        private static NativeLibrary LoadSdl2()
        {
            string[] names;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                names = new[] { "SDL2.dll" };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                names = new[]
                {
                    "libSDL2-2.0.so",
                    "libSDL2-2.0.so.0",
                    "libSDL2-2.0.so.1",
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                names = new[]
                {
                    "sdl2.dylib"
                };
            }
            else
            {
                Debug.WriteLine("Unknown SDL platform. Attempting to load \"SDL2\"");
                names = new[] { "SDL2.dll" };
            }

            NativeLibrary lib = new NativeLibrary(names);
            return lib;
        }

        /// <summary>
        /// Loads an SDL2 function by the given name.
        /// </summary>
        /// <typeparam name="T">The delegate type of the function to load.</typeparam>
        /// <param name="name">The name of the exported native function.</param>
        /// <returns>A delegate which can be used to invoke the native function.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when no function with the given name is exported by SDL2.
        /// </exception>
        public static T LoadFunction<T>(string name)
        {
            try
            {
                return s_sdl2Lib.LoadFunction<T>(name);
            }
            catch
            {
                Debug.WriteLine(
                    $"Unable to load SDL2 function \"{name}\". " +
                    $"Attempting to call this function will cause an exception to be thrown.");
                return default(T);
            }
        }

        /// <summary>
        /// The sdl geterror
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetError_t();
        /// <summary>
        /// The sdl geterror
        /// </summary>
        private static SDL_GetError_t s_sdl_getError = LoadFunction<SDL_GetError_t>("SDL_GetError");
        /// <summary>
        /// Sdls the get error
        /// </summary>
        /// <returns>The byte</returns>
        public static byte* SDL_GetError() => s_sdl_getError();

        /// <summary>
        /// The sdl clearerror
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_ClearError_t();
        /// <summary>
        /// The sdl clearerror
        /// </summary>
        private static SDL_ClearError_t s_sdl_clearError = LoadFunction<SDL_ClearError_t>("SDL_ClearError");
        /// <summary>
        /// Sdls the clear error
        /// </summary>
        /// <returns>The byte</returns>
        public static byte* SDL_ClearError() { s_sdl_clearError(); return null; }

        /// <summary>
        /// The sdl free
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_free_t(void* ptr);
        /// <summary>
        /// The sdl free
        /// </summary>
        private static SDL_free_t s_sdl_free = LoadFunction<SDL_free_t>("SDL_free");
        /// <summary>
        /// Sdls the free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public static void SDL_free(void* ptr) { s_sdl_free(ptr); }
    }
}
