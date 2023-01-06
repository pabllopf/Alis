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
using System.Collections.Generic;
using Alis.Core.Input.SDL2;

namespace Alis.Core.Input.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
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

            List<Sdl.SdlGameControllerButton> buttons = new List<Sdl.SdlGameControllerButton>((Sdl.SdlGameControllerButton[]) Enum.GetValues(typeof(Sdl.SdlGameControllerButton)));
            List<Sdl.SdlGameControllerAxis> axis = new List<Sdl.SdlGameControllerAxis>((Sdl.SdlGameControllerAxis[]) Enum.GetValues(typeof(Sdl.SdlGameControllerAxis)));

            List<Sdl.SdlKeycode> keys = new List<Sdl.SdlKeycode>((Sdl.SdlKeycode[]) Enum.GetValues(typeof(Sdl.SdlKeycode)));


            Sdl.SdlEvent sdlEvent;

            bool run = true;
            while (run)
            {
                Sdl.SDL_JoystickUpdate();

                while (Sdl.SDL_PollEvent(out sdlEvent) != 0)
                {
                    foreach (Sdl.SdlKeycode key in keys)
                    {
                        if ((sdlEvent.type == Sdl.SdlEventType.SdlKeydown) &&
                            (sdlEvent.key.keysym.sym == key))
                        {
                            Console.WriteLine($"Pressed key={key}");

                            if (sdlEvent.key.keysym.sym == Sdl.SdlKeycode.SdlkEscape)
                            {
                                Console.WriteLine("End program");
                                run = false;
                                break;
                            }
                        }
                    }

                    foreach (Sdl.SdlGameControllerButton button in buttons)
                    {
                        if ((sdlEvent.type == Sdl.SdlEventType.SdlJoybuttondown)
                            && (button == (Sdl.SdlGameControllerButton) sdlEvent.cbutton.button))
                        {
                            Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cdevice.which}'] Pressed button={button}");
                        }
                    }

                    foreach (Sdl.SdlGameControllerAxis axi in axis)
                    {
                        if ((sdlEvent.type == Sdl.SdlEventType.SdlJoyaxismotion)
                            && (axi == (Sdl.SdlGameControllerAxis) sdlEvent.caxis.axis))
                        {
                            Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cdevice.which}'] Pressed axi={axi}");
                        }
                    }
                }
            }
        }
    }
}