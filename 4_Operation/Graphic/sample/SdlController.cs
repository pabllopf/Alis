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
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf;
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
        ///     The sdl game controller axis
        /// </summary>
        private static readonly List<GameControllerAxis> Axis = new List<GameControllerAxis>((GameControllerAxis[]) Enum.GetValues(typeof(GameControllerAxis)));

        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        private static readonly List<GameControllerButton> Buttons = new List<GameControllerButton>((GameControllerButton[]) Enum.GetValues(typeof(GameControllerButton)));

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _green;

        /// <summary>
        ///     The sdl keycode
        /// </summary>
        private static List<KeyCode> _keys = new List<KeyCode>((KeyCode[]) Enum.GetValues(typeof(KeyCode)));

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
        ///     The texture font
        /// </summary>
        private static IntPtr _textureFont1;

        /// <summary>
        ///     The dst rect font
        /// </summary>
        private static RectangleI _dstRectFont1;

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
            Console.WriteLine($"SDL2 VERSION {versionSdl2.major}.{versionSdl2.minor}.{versionSdl2.patch}");

            /*
            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlContextFlags, (int) SdlGlContext.SdlGlContextForwardCompatibleFlag);
            Sdl.GlSetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlContextMajorVersion, 3);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlContextMinorVersion, 2);

            Sdl.GlSetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlDoubleBuffer, 1);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlDepthSize, 24);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlAlphaSize, 8);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.GlSetSwapInterval(1);*/

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

            SdlTtf.Init();
            Console.WriteLine($"SDL_TTF Version: {SdlTtf.GetVersion().major}.{SdlTtf.GetVersion().minor}.{SdlTtf.GetVersion().patch}");

            Console.WriteLine("Platform: " + EmbeddedDllClass.GetCurrentPlatform());
            Console.WriteLine("Processor: " + RuntimeInformation.ProcessArchitecture);

            int outlineSize = 1;

            // Load the font
            IntPtr font = SdlTtf.OpenFont(AssetManager.Find("FontSample.otf"), 55);

            // Load the font
            IntPtr fontOutline = SdlTtf.OpenFont(AssetManager.Find("FontSample.otf"), 55);

            // define outline font
            SdlTtf.SetFontOutline(font, outlineSize);

            // define style font
            SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleNormal);

            // Pixels to render the text
            IntPtr bgSurface = SdlTtf.RenderTextBlended(
                fontOutline,
                "0123456789",
                new Color(255, 255, 255, 255));

            IntPtr fgSurface = SdlTtf.RenderTextBlended(
                font,
                "0123456789",
                new Color(84, 52, 68, 255));

            // get size fg_surface
            //SDL_QueryTexture(fg_surface, NULL, NULL, &w, &h); :
            Sdl.QueryTexture(fgSurface, out _, out _, out int wOut, out int hOut);

            //SDL_Rect rect = {OUTLINE_SIZE, OUTLINE_SIZE, fg_surface->w, fg_surface->h};
            RectangleI rect = new RectangleI(0, 0, wOut, hOut);

            //SDL_SetSurfaceBlendMode(fg_surface, SDL_BLENDMODE_BLEND); :
            Sdl.SetSurfaceBlendMode(fgSurface, BlendModes.BlendModeBlend);

            //SDL_BlitSurface(fg_surface, NULL, bg_surface, &rect);
            Sdl.BlitSurface(fgSurface, IntPtr.Zero, bgSurface, ref rect);

            // Create a texture from the surface
            _textureFont1 = Sdl.CreateTextureFromSurface(renderer, bgSurface);

            // Get the width and height of the texture
            Sdl.QueryTexture(_textureFont1, out _, out _, out int textureWidth, out int textureHeight);

            // Create a destination intPtr dstRect
            _dstRectFont1 = new RectangleI(0, 0, textureWidth, textureHeight);

            IntPtr icon = Sdl.LoadBmp(AssetManager.Find("logo.bmp"));
            Sdl.SetWindowIcon(window, icon);

            Sdlinput();

            // Rectangle to be drawn outline.
            RectangleI rectBorder = new RectangleI
            {
                x = 0,
                y = 0,
                w = 50,
                h = 50
            };

            // Rectangle to be drawn filled.
            RectangleI rectFilled = new RectangleI
            {
                x = 200,
                y = 200,
                w = 100,
                h = 100
            };

            RectangleI tileRectangleI = new RectangleI
            {
                x = 0,
                y = 0,
                w = 32,
                h = 64
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
                            if (_sdlEvent.key.keySym.sym == KeyCode.Escape)
                            {
                                _running = false;
                            }

                            if (_sdlEvent.key.keySym.sym == KeyCode.Up)
                            {
                                rectBorder.y -= 10;
                            }

                            if (_sdlEvent.key.keySym.sym == KeyCode.Down)
                            {
                                rectBorder.y += 10;
                            }

                            if (_sdlEvent.key.keySym.sym == KeyCode.Left)
                            {
                                rectBorder.x -= 10;
                            }

                            if (_sdlEvent.key.keySym.sym == KeyCode.Right)
                            {
                                rectBorder.x += 10;
                            }

                            Console.WriteLine(_sdlEvent.key.keySym.sym + " was pressed");
                            break;
                    }

                    foreach (GameControllerButton button in Buttons)
                    {
                        if ((_sdlEvent.type == EventType.JoyButtonDown)
                            && (button == (GameControllerButton) _sdlEvent.cButton.button))
                        {
                            Console.WriteLine($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed button={button}");
                        }
                    }

                    foreach (GameControllerAxis axi in Axis)
                    {
                        if ((_sdlEvent.type == EventType.JoyAxisMotion)
                            && (axi == (GameControllerAxis) _sdlEvent.cAxis.axis))
                        {
                            Console.WriteLine($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed axi={axi}");
                        }
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

                Sdl.RenderCopy(renderer, _textureFont1, IntPtr.Zero, ref _dstRectFont1);

                Sdl.RenderCopy(renderer, textureTile, IntPtr.Zero, ref tileRectangleI);

                Sdl.RenderDrawRects(renderer, new[] {rectBorder, rectFilled}, 2);


                // draw a line
                Sdl.SetRenderDrawColor(renderer, 255, 0, 0, 255);
                Sdl.RenderDrawLine(renderer, 0, 0, 100, 100);

                // Switches out the currently presented render surface with the one we just did work on.
                Sdl.RenderPresent(renderer);
            }

            Sdl.DestroyRenderer(renderer);
            Sdl.DestroyWindow(window);
            //Sdl.FreeSurface(imageTile);
            //Sdl.DestroyTexture(textureTile);
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
                    Console.WriteLine(@"Ooops, something fishy's goin' on here!" + Sdl.GetError());
                }
                else
                {
                    Console.WriteLine($"[SDL_JoystickName_id = '{i}'] \n" +
                                      $"SDL_JoystickName={Sdl.JoystickName(myJoystick)} \n" +
                                      $"SDL_JoystickNumAxes={Sdl.JoystickNumAxes(myJoystick)} \n" +
                                      $"SDL_JoystickNumButtons={Sdl.JoystickNumButtons(myJoystick)}");
                }
            }
        }
    }
}