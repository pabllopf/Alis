using System.Collections.Generic;
using static Alis.Core.Graphic.Backends.SDL2.Sdl2Native;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The sdl events class
    /// </summary>
    public static class Sdl2Events
    {
        /// <summary>
        /// The lock
        /// </summary>
        private static readonly object s_lock = new object();
        /// <summary>
        /// The sdl event handler
        /// </summary>
        private static readonly List<SDLEventHandler> s_processors = new List<SDLEventHandler>();
        /// <summary>
        /// Subscribes the processor
        /// </summary>
        /// <param name="processor">The processor</param>
        public static void Subscribe(SDLEventHandler processor)
        {
            lock (s_lock)
            {
                s_processors.Add(processor);
            }
        }

        /// <summary>
        /// Unsubscribes the processor
        /// </summary>
        /// <param name="processor">The processor</param>
        public static void Unsubscribe(SDLEventHandler processor)
        {
            lock (s_lock)
            {
                s_processors.Remove(processor);
            }
        }

        /// <summary>
        /// Pumps the SDL2 event loop, and calls all registered event processors for each event.
        /// </summary>
        public static unsafe void ProcessEvents()
        {
            lock (s_lock)
            {
                SDL_Event ev;
                while (SDL_PollEvent(&ev) == 1)
                {
                    foreach (SDLEventHandler processor in s_processors)
                    {
                        processor(ref ev);
                    }
                }
            }
        }
    }
}
