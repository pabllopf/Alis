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

namespace Alis.Core.Graphic.Sample
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
        private static void Main(string[] args)
        {
            int run = 1;
            while (run == 1)
            {
                Console.WriteLine(@"Select backend graphic system ('sfml' | 'sdl' | 'direct11' | 'metal' | 'opengl' | 'opengles' | 'vulkan')");
                string os = Console.ReadLine();
                switch (os)
                {
                    case "sfml":
                        SfmlController sfmlController = new SfmlController();
                        run = sfmlController.Run();
                        break;

                    case "sdl":
                        SdlController sdlController = new SdlController();
                        run = sdlController.Run();
                        break;
                    
                    case "direct11":
                        Direct3D11Controller direct3D11Controller = new Direct3D11Controller();
                        run = direct3D11Controller.Run();
                        break;
                    
                    case "metal":
                        MetalController metalController = new MetalController();
                        run = metalController.Run();
                        break;
                    
                    case "opengl":
                        OpenGLController openglController = new OpenGLController();
                        run = openglController.Run();
                        break;
                    
                    case "opengles":
                        OpenGlesController openglesController = new OpenGlesController();
                        run = openglesController.Run();
                        break;
                    
                    case "vulkan":
                        VulkanController vulkanController = new VulkanController();
                        run = vulkanController.Run();
                        break;
                }
            }
        }
    }
}