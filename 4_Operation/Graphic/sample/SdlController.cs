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
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Sdl = Alis.Core.Graphic.Sdl2.Sdl;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Core.Graphic.Sample
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
        ///     The blue
        /// </summary>
        private static byte _blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _green;
        
        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _red;

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

            IntPtr icon = Sdl.LoadBmp(AssetManager.Find("logo.bmp"));
            Sdl.SetWindowIcon(window, icon);

            Sdlinput();

            // Rectangle to be drawn outline.
            RectangleI rectBorder = new RectangleI
            {
                X = 0,
                Y = 0,
                W = 50,
                H = 50
            };

            // Rectangle to be drawn filled.
            RectangleI rectFilled = new RectangleI
            {
                X = 200,
                Y = 200,
                W = 100,
                H = 100
            };

            RectangleI tileRectangleI = new RectangleI
            {
                X = 0,
                Y = 0,
                W = 32,
                H = 64
            };

            // Load the image from the specified path.
            IntPtr imageTilePtr = Sdl.LoadBmp("Assets/tile000.bmp");

            // Create a new texture from the image.
            IntPtr textureTile = Sdl.CreateTextureFromSurface(renderer, imageTilePtr);
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

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Up)
                            {
                                rectBorder.Y -= 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Down)
                            {
                                rectBorder.Y += 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Left)
                            {
                                rectBorder.X -= 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Right)
                            {
                                rectBorder.X += 10;
                            }

                            Logger.Info(_sdlEvent.key.KeySym.sym + " was pressed");
                            break;
                    }
                }


                RenderColors();

                // Sets the color that the screen will be cleared with.
                Sdl.SetRenderDrawColor(renderer, _red, _green, _blue, 255);

                // Clears the current render surface.
                Sdl.RenderClear(renderer);

                // Sets the color that the rectangle will be drawn with.
                Sdl.SetRenderDrawColor(renderer, 255, 255, 255, 255);
                // Draws a rectangle outline.
                //Sdl.RenderDrawRect(renderer, ref rectBorder);

                // Sets the color that the rectangle will be drawn with.
                Sdl.SetRenderDrawColor(renderer, 0, 0, 0, 255);

                // Draws a filled rectangle.
                //Sdl.RenderFillRect(renderer, ref rectFilled);

                Sdl.RenderCopy(renderer, textureTile, IntPtr.Zero, ref tileRectangleI);

                Sdl.RenderDrawRects(renderer, new[] {rectBorder, rectFilled}, 2);
                
                // draw a line
                Sdl.SetRenderDrawColor(renderer, 255, 0, 0, 255);
                Sdl.RenderDrawLine(renderer, 0, 0, 100, 100);

                Sdl.RenderPresent(renderer);


                Thread.Sleep(1000 / 60);
            }

            Sdl.DestroyRenderer(renderer);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
        }

        /// <summary>
        ///     Renders the colors
        /// </summary>
        private static void RenderColors()
        {
            if (_red < 255)
            {
                _red++;
            }
            else if (_green < 255)
            {
                _green++;
            }
            else if (_blue < 255)
            {
                _blue++;
            }
            else
            {
                _red = 0;
                _green = 0;
                _blue = 0;
            }
        }


        /// <summary>
        ///     Sdlinputs
        /// </summary>
        private static void Sdlinput()
        {
            Sdl.SetHint(Hint.HintXInputEnabled, "0");
            Sdl.SetHint(Hint.SdlHintJoystickThread, "1");

            for (int i = 0; i < Sdl.NumJoysticks(); i++)
            {
                IntPtr myJoystick = Sdl.JoystickOpen(i);
                if (myJoystick == IntPtr.Zero)
                {
                    Logger.Info(@"Ooops, something fishy's goin' on here!" + Sdl.GetError());
                }
                else
                {
                    Logger.Info($"[SDL_JoystickName_id = '{i}'] \n" +
                                $"SDL_JoystickName={Sdl.JoystickName(myJoystick)} \n" +
                                $"SDL_JoystickNumAxes={Sdl.JoystickNumAxes(myJoystick)} \n" +
                                $"SDL_JoystickNumButtons={Sdl.JoystickNumButtons(myJoystick)}");
                }
            }
        }
    }
}