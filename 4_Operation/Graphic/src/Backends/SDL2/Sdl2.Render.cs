using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The sdl native class
    /// </summary>
    public static unsafe partial class Sdl2Native
    {
        /// <summary>
        /// The sdl createrenderer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Renderer SDL_CreateRenderer_t(SDL_Window SDL2Window, int index, uint flags);
        /// <summary>
        /// The sdl createrenderer
        /// </summary>
        private static SDL_CreateRenderer_t s_sdl_createRenderer = LoadFunction<SDL_CreateRenderer_t>("SDL_CreateRenderer");
        /// <summary>
        /// Sdls the create renderer using the specified sdl 2 window
        /// </summary>
        /// <param name="Sdl2Window">The sdl window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The sdl renderer</returns>
        public static SDL_Renderer SDL_CreateRenderer(SDL_Window Sdl2Window, int index, uint flags)
           => s_sdl_createRenderer(Sdl2Window, index, flags);

        /// <summary>
        /// The sdl destroyrenderer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyRenderer_t(SDL_Renderer renderer);
        /// <summary>
        /// The sdl destroyrenderer
        /// </summary>
        private static SDL_DestroyRenderer_t s_sdl_destroyRenderer = LoadFunction<SDL_DestroyRenderer_t>("SDL_DestroyRenderer");
        /// <summary>
        /// Sdls the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public static void SDL_DestroyRenderer(SDL_Renderer renderer)
           => s_sdl_destroyRenderer(renderer);

        /// <summary>
        /// The sdl setrenderdrawcolor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRenderDrawColor_t(SDL_Renderer renderer, byte r, byte g, byte b, byte a);
        /// <summary>
        /// The sdl setrenderdrawcolor
        /// </summary>
        private static SDL_SetRenderDrawColor_t s_sdl_setRenderDrawColor
            = LoadFunction<SDL_SetRenderDrawColor_t>("SDL_SetRenderDrawColor");
        /// <summary>
        /// Sdls the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        public static int SDL_SetRenderDrawColor(SDL_Renderer renderer, byte r, byte g, byte b, byte a)
            => s_sdl_setRenderDrawColor(renderer, r, g, b, a);

        /// <summary>
        /// The sdl renderclear
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderClear_t(SDL_Renderer renderer);
        /// <summary>
        /// The sdl renderclear
        /// </summary>
        private static SDL_RenderClear_t s_sdl_renderClear = LoadFunction<SDL_RenderClear_t>("SDL_RenderClear");
        /// <summary>
        /// Sdls the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        public static int SDL_RenderClear(SDL_Renderer renderer) => s_sdl_renderClear(renderer);

        /// <summary>
        /// The sdl renderfillrect
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderFillRect_t(SDL_Renderer renderer, void* rect);
        /// <summary>
        /// The sdl renderfillrect
        /// </summary>
        private static SDL_RenderFillRect_t s_sdl_renderFillRect = LoadFunction<SDL_RenderFillRect_t>("SDL_RenderFillRect");
        /// <summary>
        /// Sdls the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        public static int SDL_RenderFillRect(SDL_Renderer renderer, void* rect) => s_sdl_renderFillRect(renderer, rect);

        /// <summary>
        /// The sdl renderpresent
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderPresent_t(SDL_Renderer renderer);
        /// <summary>
        /// The sdl renderpresent
        /// </summary>
        private static SDL_RenderPresent_t s_sdl_renderPresent = LoadFunction<SDL_RenderPresent_t>("SDL_RenderPresent");
        /// <summary>
        /// Sdls the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        public static int SDL_RenderPresent(SDL_Renderer renderer) => s_sdl_renderPresent(renderer);

    }
}
