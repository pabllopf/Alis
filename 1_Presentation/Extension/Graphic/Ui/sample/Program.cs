// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Extension.Graphic.Ui.Sample.Examples;

namespace Alis.Extension.Graphic.Ui.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            INativePlatform platform;
#if osxarm64 || osxarm || osxx64 || osx || osxarm || osxx64 || osx
            platform = new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif winx64 || winx86 || winarm64 || winarm || win
            platform = new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
            platform = new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            throw new Exception("Sistema operativo no soportado");
#endif

            IExample example = null;

            bool ok = platform.Initialize(800, 600, "C# + OpenGL Platform");
            if (!ok)
            {
                Logger.Info("No se pudo inicializar la ventana ni el contexto OpenGL. El programa se cerrará.");
                platform.Cleanup();
                return;
            }

            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);

            // Crear el ejemplo aquí, después de que el contexto nativo y GL estén listos
            example = new ImguiSample(platform);

            example.Initialize();
            platform.ShowWindow();
            platform.SetTitle("C# + OpenGL Platform - ImGui");

            bool running = true;
            while (running)
            {
                running = platform.PollEvents();
                if (platform.TryGetLastKeyPressed(out ConsoleKey key))
                {
                    Logger.Info($"Tecla pulsada: {key}");
                }

                example.Draw();
                platform.SwapBuffers();
                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Logger.Info($"OpenGL error tras flushBuffer: 0x{glError:X}");
                }
            }

            example.Cleanup();
            platform.Cleanup();
        }
    }
}