// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlController.cs
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Sdl = Alis.Core.Graphic.Sdl2.Sdl;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.Sdl2Image.Sample
{
    /// <summary>
    ///     The sdl controller class
    /// </summary>
    public static class SdlController
    {
        /// <summary>
        ///     The width
        /// </summary>
        private const int Width = 640;

        /// <summary>
        ///     The height
        /// </summary>
        private const int Height = 480;
        
        /// <summary>
        ///     The running
        /// </summary>
        private static bool _running = true;

        /// <summary>
        ///     The sdl event
        /// </summary>
        private static Event _sdlEvent;

        /// <summary>
        ///     Runs
        /// </summary>
        public static void Run()
        {
            if (Sdl.Init(InitSettings.InitEverything) < 0)
            {
                Logger.Exception($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Init all");
            }

            // GET VERSION SDL2
            Version versionSdl2 = Sdl.GetVersion();
            Logger.Info($"SDL2 VERSION {versionSdl2.major}.{versionSdl2.minor}.{versionSdl2.patch}");

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "direct3d");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "opengl");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "opengl");
            }

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowResizable | WindowSettings.WindowShown;

            // Creates a new SDL window at the center of the screen with the given width and height.
            IntPtr window = Sdl.CreateWindow("Sample", (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, Width, Height, flags);

            // Check if the window was created successfully.
            if (window == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the renderer. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Window created");
            }

            // Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
            IntPtr renderer = Sdl.CreateRenderer(
                window,
                -1,
                Renderers.SdlRendererAccelerated);

            if (renderer == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the renderer. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Renderer created");
            }

            // Initialize SDL2_image
            SdlImage.Init(ImgInitFlags.ImgInitPng);

            // Load the PNG image
            IntPtr image = SdlImage.LoadImg(AssetManager.Find("test_image.png"));
            if (image == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue loading the image. {SdlImage.GetError()}");
            }
            else
            {
                Logger.Info("Image loaded");
            }

            // Create a texture from the image
            IntPtr texture = Sdl.CreateTextureFromSurface(renderer, image);
            if (texture == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the texture. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Texture created");
            }

            while (_running)
            {
                Sdl.JoystickUpdate();

                while (Sdl.PollEvent(out _sdlEvent) != 0)
                {
                    switch (_sdlEvent.type)
                    {
                        case EventType.Quit:
                            _running = false;
                            break;
                        case EventType.Keydown:
                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Escape)
                            {
                                _running = false;
                            }

                            break;
                    }
                }

                // Sets the color that the screen will be cleared with.
                Sdl.SetRenderDrawColor(renderer, 0, 0, 0, 255);

                // Clears the current render surface.
                Sdl.RenderClear(renderer);

                // Render the texture
                Sdl.RenderCopy(renderer, texture, IntPtr.Zero, IntPtr.Zero);

                // Present the rendered image
                Sdl.RenderPresent(renderer);

                Thread.Sleep(1000 / 60);
            }

            // Clean up
            Sdl.DestroyTexture(texture);
            Sdl.DestroyRenderer(renderer);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
        }
    }
}