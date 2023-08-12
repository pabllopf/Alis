using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The sdl window registry class
    /// </summary>
    internal static class Sdl2WindowRegistry
    {
        /// <summary>
        /// The lock
        /// </summary>
        public static readonly object Lock = new object();
        /// <summary>
        /// The sdl window
        /// </summary>
        private static readonly Dictionary<uint, Sdl2Window> _eventsByWindowID
            = new Dictionary<uint, Sdl2Window>();
        /// <summary>
        /// The first init
        /// </summary>
        private static bool _firstInit;

        /// <summary>
        /// Registers the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void RegisterWindow(Sdl2Window window)
        {
            lock (Lock)
            {
                _eventsByWindowID.Add(window.WindowID, window);
                if (!_firstInit)
                {
                    _firstInit = true;
                    Sdl2Events.Subscribe(ProcessWindowEvent);
                }
            }
        }

        /// <summary>
        /// Removes the window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        public static void RemoveWindow(Sdl2Window window)
        {
            lock (Lock)
            {
                _eventsByWindowID.Remove(window.WindowID);
            }
        }

        /// <summary>
        /// Processes the window event using the specified ev
        /// </summary>
        /// <param name="ev">The ev</param>
        private static unsafe void ProcessWindowEvent(ref SDL_Event ev)
        {
            bool handled = false;
            uint windowID = 0;
            switch (ev.type)
            {
                case SDL_EventType.Quit:
                case SDL_EventType.Terminating:
                case SDL_EventType.WindowEvent:
                case SDL_EventType.KeyDown:
                case SDL_EventType.KeyUp:
                case SDL_EventType.TextEditing:
                case SDL_EventType.TextInput:
                case SDL_EventType.KeyMapChanged:
                case SDL_EventType.MouseMotion:
                case SDL_EventType.MouseButtonDown:
                case SDL_EventType.MouseButtonUp:
                case SDL_EventType.MouseWheel:
                    windowID = ev.windowID;
                    handled = true;
                    break;
                case SDL_EventType.DropBegin:
                case SDL_EventType.DropComplete:
                case SDL_EventType.DropFile:
                case SDL_EventType.DropText:
                    SDL_DropEvent dropEvent = Unsafe.As<SDL_Event, SDL_DropEvent>(ref ev);
                    windowID = dropEvent.windowID;
                    handled = true;
                    break;
                default:
                    handled = false;
                    break;
            }


            if (handled && _eventsByWindowID.TryGetValue(windowID, out Sdl2Window window))
            {
                window.AddEvent(ev);
            }
        }
    }
}
