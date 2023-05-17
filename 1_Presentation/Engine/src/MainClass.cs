// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainClass.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Graphic.ImGui;
using Alis.Core.Graphic.SDL;

namespace Alis.App.Engine
{
    /// <summary>
    ///     The main class
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        ///     The renderer
        /// </summary>
        private static ImGuiGLRenderer _renderer;

        /// <summary>
        ///     The quit
        /// </summary>
        private static bool _quit;

        /// <summary>
        ///     The window
        /// </summary>
        private static IntPtr _window;

        /// <summary>
        ///     The gl context
        /// </summary>
        private static IntPtr _glContext;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            // create a window, GL context and our ImGui renderer
            // this is fast solution for create SDL_Window and SDL_Render
            (_window, _glContext) = ImGuiGL.CreateWindowAndGLContext("SDL Window (OpenGL)", 800, 600);
            _renderer = new ImGuiGLRenderer(_window, _glContext);

            while (!_quit)
            {
                while (SDL.SDL_PollEvent(out SDL.SDL_Event e) != 0)
                {
                    _renderer.ProcessEvent(e);
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                        {
                            _quit = true;
                            break;
                        }
                        case SDL.SDL_EventType.SDL_KEYDOWN:
                        {
                            switch (e.key.keysym.sym)
                            {
                                case SDL.SDL_Keycode.SDLK_ESCAPE:
                                case SDL.SDL_Keycode.SDLK_q:
                                    _quit = true;
                                    break;
                            }

                            break;
                        }
                    }
                }

                _renderer.ClearColor(0.05f, 0.05f, 0.05f, 1.00f);
                _renderer.NewFrame();
                ImGui.ShowDemoWindow();
                _renderer.Render();
                SDL.SDL_GL_SwapWindow(_window);
            }

            SDL.SDL_GL_DeleteContext(_glContext);
            SDL.SDL_DestroyWindow(_window);
            SDL.SDL_Quit();
        }
    }
}