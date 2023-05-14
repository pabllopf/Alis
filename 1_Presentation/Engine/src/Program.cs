//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Program.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------

/*
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.App.Engine
{
    /// <summary>Run the engine</summary>
    public class Program
    {
        /// <summary>Mains the specified arguments.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Return -1 or 0</returns>
        [STAThread]
        public static int Main(string[] args)
        {
            return new Engine(args).Start();
        }
    }
}
*/

using System;
using Alis.Core.Graphic.ImGui;
using static Alis.Core.Graphic.SDL.SDL;
using ImGui = Alis.Core.Graphic.ImGui.ImGui.ImGui;

namespace Alis.App.Engine
{
    /// <summary>
    /// The main class
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// The renderer
        /// </summary>
        static ImGuiGLRenderer _renderer;
        /// <summary>
        /// The quit
        /// </summary>
        static bool _quit;
        /// <summary>
        /// The window
        /// </summary>
        static IntPtr _window;
        /// <summary>
        /// The gl context
        /// </summary>
        static IntPtr _glContext;

        /// <summary>
        /// Main the args
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
                while (SDL_PollEvent(out var e) != 0)
                {
                    _renderer.ProcessEvent(e);
                    switch (e.type)
                    {
                        case SDL_EventType.SDL_QUIT:
                        {
                            _quit = true;
                            break;
                        }
                        case SDL_EventType.SDL_KEYDOWN:
                        {
                            switch (e.key.keysym.sym)
                            {
                                case SDL_Keycode.SDLK_ESCAPE:
                                case SDL_Keycode.SDLK_q:
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
                SDL_GL_SwapWindow(_window);
            }

            SDL_GL_DeleteContext(_glContext);
            SDL_DestroyWindow(_window);
            SDL_Quit();
        }
    }
}