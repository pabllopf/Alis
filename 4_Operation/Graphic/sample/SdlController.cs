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
using Alis.Core.Graphic.SDL;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    ///     The sdl controller class
    /// </summary>
    public class SdlController
    {
        /// <summary>
        ///     The blue
        /// </summary>
        private byte _blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private byte _green;

        /// <summary>
        ///     The blue
        /// </summary>
        private byte _red;

        /// <summary>
        ///     The sdl game controller axis
        /// </summary>
        private List<SdlGameControllerAxis> axis = new List<SdlGameControllerAxis>((SdlGameControllerAxis[]) Enum.GetValues(typeof(SdlGameControllerAxis)));

        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        private List<SdlGameControllerButton> buttons = new List<SdlGameControllerButton>((SdlGameControllerButton[]) Enum.GetValues(typeof(SdlGameControllerButton)));

        /// <summary>
        ///     The sdl keycode
        /// </summary>
        private List<SdlKeycode> keys = new List<SdlKeycode>((SdlKeycode[]) Enum.GetValues(typeof(SdlKeycode)));

        /// <summary>
        ///     The running
        /// </summary>
        private bool running = true;

        /// <summary>
        ///     The sdl event
        /// </summary>
        private SdlEvent sdlEvent;

        /// <summary>
        ///     The width
        /// </summary>
        private const int Width = 640;

        /// <summary>
        ///     The height
        /// </summary>
        private const int Height = 480;

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public int Run()
        {
            // Initilizes SDL.
            if (Sdl.SDL_Init(Sdl.SdlInitEverything) < 0)
            {
                Console.WriteLine($"There was an issue initializing SDL. {Sdl.SDL_GetError()}");
            }

            // Create a new window given a title, size, and passes it a flag indicating it should be shown.
            IntPtr window = Sdl.SDL_CreateWindow(
                "SDL .NET 6 Tutorial",
                Sdl.SdlWindowposUndefined,
                Sdl.SdlWindowposUndefined,
                Width,
                Height,
                SdlWindowFlags.SdlWindowShown);

            if (window == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the window. {Sdl.SDL_GetError()}");
            }

            // Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
            IntPtr renderer = Sdl.SDL_CreateRenderer(
                window,
                -1,
                SdlRendererFlags.SdlRendererAccelerated |
                SdlRendererFlags.SdlRendererPresentvsync);

            if (renderer == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the renderer. {Sdl.SDL_GetError()}");
            }

            Sdlinput();

            while (running)
            {
                UpdateInput();

                RenderColors();

                // Sets the color that the screen will be cleared with.
                Sdl.SDL_SetRenderDrawColor(renderer, _red, _green, _blue, 255);

                // Clears the current render surface.
                Sdl.SDL_RenderClear(renderer);

                // Switches out the currently presented render surface with the one we just did work on.
                Sdl.SDL_RenderPresent(renderer);
            }

            Sdl.SDL_DestroyRenderer(renderer);
            Sdl.SDL_DestroyWindow(window);
            Sdl.SDL_Quit();
            return 0;
        }

        /// <summary>
        ///     Renders the colors
        /// </summary>
        private void RenderColors()
        {
            _red += 1;
            if (_red >= 100)
            {
                _red -= 1;
            }

            _green += 2;
            if (_green >= 100)
            {
                _green -= 1;
            }

            _blue += 3;
            if (_blue >= 100)
            {
                _blue -= 1;
            }
        }


        /// <summary>
        ///     Sdlinputs
        /// </summary>
        private void Sdlinput()
        {
            Sdl.SDL_SetHint(Sdl.SdlHintXinputEnabled, "0");
            Sdl.SDL_SetHint(Sdl.SdlHintJoystickThread, "1");
            Sdl.SDL_Init(Sdl.SdlInitEverything);


            for (int i = 0; i < Sdl.SDL_NumJoysticks(); i++)
            {
                IntPtr myJoystick = Sdl.SDL_JoystickOpen(i);
                if (myJoystick == IntPtr.Zero)
                {
                    Console.WriteLine("Ooops, something fishy's goin' on here!" + Sdl.SDL_GetError());
                }
                else
                {
                    Console.WriteLine($"[SDL_JoystickName_id = '{i}'] \n" +
                                      $"SDL_JoystickName={Sdl.SDL_JoystickName(myJoystick)} \n" +
                                      $"SDL_JoystickNumAxes={Sdl.SDL_JoystickNumAxes(myJoystick)} \n" +
                                      $"SDL_JoystickNumButtons={Sdl.SDL_JoystickNumButtons(myJoystick)}");
                }
            }
        }

        /// <summary>
        ///     Updates the input
        /// </summary>
        public void UpdateInput()
        {
            Sdl.SDL_JoystickUpdate();

            while (Sdl.SDL_PollEvent(out sdlEvent) != 0)
            {
                switch (sdlEvent.type)
                {
                    case SdlEventType.SdlQuit:
                        running = false;
                        break;
                    case SdlEventType.SdlKeydown:
                        if (sdlEvent.key.keysym.sym == SdlKeycode.SdlkEscape)
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine(sdlEvent.key.keysym.sym + " was pressed");
                        }

                        break;
                }
                /*
                foreach (SdlKeycode key in keys)
                {
                    if ((sdlEvent.type == SdlEventType.SdlKeydown) &&
                        (sdlEvent.key.keysym.sym == key))
                    {
                        Console.WriteLine($"Pressed key={key}");

                        if (sdlEvent.key.keysym.sym == SdlKeycode.SdlkEscape)
                        {
                            Console.WriteLine("End program");
                            running = false;
                            break;
                        }
                    }
                }*/

                foreach (SdlGameControllerButton button in buttons)
                {
                    if ((sdlEvent.type == SdlEventType.SdlJoybuttondown)
                        && (button == (SdlGameControllerButton) sdlEvent.cbutton.button))
                    {
                        Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cdevice.which}'] Pressed button={button}");
                    }
                }

                foreach (SdlGameControllerAxis axi in axis)
                {
                    if ((sdlEvent.type == SdlEventType.SdlJoyaxismotion)
                        && (axi == (SdlGameControllerAxis) sdlEvent.caxis.axis))
                    {
                        Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cdevice.which}'] Pressed axi={axi}");
                    }
                }
            }
        }
    }
}