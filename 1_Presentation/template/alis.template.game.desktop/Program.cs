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
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Game.Desktop
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The blue
        /// </summary>
        private static float red, green, blue;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings
            {
                Size = new Vector2i(800, 600),
                Title = "LearnOpenTK - Creating a Window",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible
            };

            GameWindowSettings gameWindowSettings = new GameWindowSettings();

            Window windows;

            using (windows = new Window(gameWindowSettings, nativeWindowSettings))
            {
                windows.RenderFrame += WindowsOnRenderFrame;
                Console.WriteLine("Version: " + GL.GetString(StringName.Version));
                windows.Run();
            }


            Console.WriteLine("pass");
        }

        /// <summary>
        ///     Windowses the on render frame using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        private static void WindowsOnRenderFrame(FrameEventArgs obj)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            OpenTK.Graphics.ES20.GL.ClearColor(red, green, blue, 1.0f);

            red += 0.01f;
            if (red >= 1.0f)
            {
                red -= 1.0f;
            }

            green += 0.02f;
            if (green >= 1.0f)
            {
                green -= 1.0f;
            }

            blue += 0.03f;
            if (blue >= 1.0f)
            {
                blue -= 1.0f;
            }
        }
    }
}