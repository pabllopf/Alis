// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VeldridController.cs
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

using System.Numerics;
using System.Text;
using Alis.Core.Graphic.Backends;
using Alis.Core.Graphic.Backends.SDL2;
using Alis.Core.Graphic.Backends.Startup;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    /// The direct 11 controller class
    /// </summary>
    public class Direct3D11Controller
    {

        /// <summary>
        /// The graphics device
        /// </summary>
        private static GraphicsDevice _graphicsDevice;
        /// <summary>
        /// The factory
        /// </summary>
        private ResourceFactory factory;
        /// <summary>
        /// The command list
        /// </summary>
        private CommandList _commandList;
        
        /// <summary>
        /// The red
        /// </summary>
        int red = 0;
        /// <summary>
        /// The green
        /// </summary>
        int green = 0;
        /// <summary>
        /// The blue
        /// </summary>
        int blue = 0;

        /// <summary>
        /// Runs this instance
        /// </summary>
        /// <returns>The int</returns>
        public int Run()
        {
            WindowCreateInfo windowCI = new WindowCreateInfo()
            {
                X = 100,
                Y = 100,
                WindowWidth = 960,
                WindowHeight = 540,
                WindowTitle = "Veldrid Tutorial"
            };
            
            Sdl2Window window = VeldridStartup.CreateWindow(ref windowCI);

            GraphicsDeviceOptions options = new GraphicsDeviceOptions
            {
                PreferStandardClipSpaceYDirection = true,
                PreferDepthRangeZeroToOne = true
            };

            _graphicsDevice = VeldridStartup.CreateGraphicsDevice(window, options, GraphicsBackend.Direct3D11);
            factory = _graphicsDevice.ResourceFactory;
            _commandList = factory.CreateCommandList();

            var color = new RgbaFloat(red / 255f, green / 255f, blue / 255f, 1f);

            while (window.Exists)
            {
                window.PumpEvents();

                if (window.Exists)
                {
                    // Begin() must be called before commands can be issued.
                    _commandList.Begin();

                    // We want to render directly to the output window.
                    _commandList.SetFramebuffer(_graphicsDevice.SwapchainFramebuffer);

                    if (red < 255)
                    {
                        red++;
                    }
                    else if (green < 255)
                    {
                        green++;
                    }
                    else if (blue < 255)
                    {
                        blue++;
                    }
                    else
                    {
                        red = 0;
                        green = 0;
                        blue = 0;
                    }
                    
                    color = new RgbaFloat(red / 255f, green / 255f, blue / 255f, 1f);
                    
                    _commandList.ClearColorTarget(0, color);
                    
                    // End() must be called before commands can be submitted for execution.
                    _commandList.End();
                    _graphicsDevice.SubmitCommands(_commandList);

                    // Once commands have been submitted, the rendered image can be presented to the application window.
                    _graphicsDevice.SwapBuffers();
                }
            }

            return 0;
        }
    }
}