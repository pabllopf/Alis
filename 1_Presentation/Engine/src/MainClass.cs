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
        private static ImGuiGlRenderer _renderer;

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
            (_window, _glContext) = ImGuiGl.CreateWindowAndGlContext("SDL Window (OpenGL)", 800, 600);
            _renderer = new ImGuiGlRenderer(_window, _glContext);

            while (!_quit)
            {
                while (Sdl.SDL_PollEvent(out SdlEvent e) != 0)
                {
                    _renderer.ProcessEvent(e);
                    switch (e.type)
                    {
                        case SdlEventType.SdlQuit:
                        {
                            _quit = true;
                            break;
                        }
                        case SdlEventType.SdlKeydown:
                        {
                            switch (e.key.keysym.sym)
                            {
                                case SdlKeycode.SdlkEscape:
                                case SdlKeycode.SdlkQ:
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
                Sdl.SDL_GL_SwapWindow(_window);
            }

            Sdl.SDL_GL_DeleteContext(_glContext);
            Sdl.SDL_DestroyWindow(_window);
            Sdl.SDL_Quit();
        }
    }
}