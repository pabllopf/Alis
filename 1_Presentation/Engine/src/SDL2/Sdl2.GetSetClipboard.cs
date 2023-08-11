using System.Runtime.InteropServices;
using System.Text;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl getclipboardtext
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetClipboardText_t();
        /// <summary>
        /// The sdl getclipboardtext
        /// </summary>
        private static SDL_GetClipboardText_t s_sdl_getClipboardText = LoadFunction<SDL_GetClipboardText_t>("SDL_GetClipboardText");
        /// <summary>
        /// Sdls the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetClipboardText() => Utilities.GetString(s_sdl_getClipboardText());

        /// <summary>
        /// The sdl setclipboardtext
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetClipboardText_t(byte* text);
        /// <summary>
        /// The sdl setclipboardtext
        /// </summary>
        private static SDL_SetClipboardText_t s_sdl_setClipboardText = LoadFunction<SDL_SetClipboardText_t>("SDL_SetClipboardText");
        /// <summary>
        /// Sdls the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        public static int SDL_SetClipboardText(string text)
        {
            int maxBytes = Encoding.UTF8.GetMaxByteCount(text.Length);
            byte* utf8Bytes = stackalloc byte[maxBytes + 1];
            fixed (char* textPtr = text)
            {
                int encodedBytes = Encoding.UTF8.GetBytes(textPtr, text.Length, utf8Bytes, maxBytes);
                utf8Bytes[encodedBytes] = 0;
            }

            return s_sdl_setClipboardText(utf8Bytes);
        }
    }
}
