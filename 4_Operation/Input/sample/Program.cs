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
using SDL2;

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
            SDL.SDL_SetHint(SDL.SDL_HINT_XINPUT_ENABLED, "0");
            SDL.SDL_SetHint(SDL.SDL_HINT_JOYSTICK_THREAD, "1");
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);


            for (int i = 0; i < SDL.SDL_NumJoysticks(); i++)
            {
                IntPtr myJoystick = SDL.SDL_JoystickOpen(i);
                if (myJoystick == IntPtr.Zero)
                {
                    Console.WriteLine("Ooops, something fishy's goin' on here!" + SDL.SDL_GetError());
                }
                else
                {
                    Console.WriteLine($"[SDL_JoystickName_id = '{i}'] \n" +
                                      $"SDL_JoystickName={SDL.SDL_JoystickName(myJoystick)} \n" +
                                      $"SDL_JoystickNumAxes={SDL.SDL_JoystickNumAxes(myJoystick)} \n" +
                                      $"SDL_JoystickNumButtons={SDL.SDL_JoystickNumButtons(myJoystick)}");
                }
                
            }
            
            List<SDL.SDL_GameControllerButton> buttons = new List<SDL.SDL_GameControllerButton>((SDL.SDL_GameControllerButton[]) Enum.GetValues(typeof(SDL.SDL_GameControllerButton)));
            List<SDL.SDL_GameControllerAxis> axis = new List<SDL.SDL_GameControllerAxis>((SDL.SDL_GameControllerAxis[]) Enum.GetValues(typeof(SDL.SDL_GameControllerAxis)));
            
            List<SDL.SDL_Keycode> keys = new List<SDL.SDL_Keycode>((SDL.SDL_Keycode[]) Enum.GetValues(typeof(SDL.SDL_Keycode)));

            
            SDL.SDL_Event sdlEvent;

            bool run = true;
            while (run)
            {
                SDL.SDL_JoystickUpdate();
                
                while (SDL.SDL_PollEvent(out sdlEvent) != 0)
                {
                    foreach (SDL.SDL_Keycode key in keys)
                    {
                        if (sdlEvent.type == SDL.SDL_EventType.SDL_KEYDOWN &&
                            sdlEvent.key.keysym.sym == key)
                        {
                            Console.WriteLine($"Pressed key={key}");
                            
                            if (sdlEvent.key.keysym.sym == SDL.SDL_Keycode.SDLK_ESCAPE)
                            {
                                Console.WriteLine("End program");
                                run = false;
                                break;
                            }
                        }
                    }
                    
                    foreach (SDL.SDL_GameControllerButton button in buttons)
                    {
                        if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYBUTTONDOWN 
                            && button == (SDL.SDL_GameControllerButton) sdlEvent.cbutton.button)
                        {
                            Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cdevice.which}'] Pressed button={button}");
                        }
                    }

                    foreach (SDL.SDL_GameControllerAxis axi in axis)
                    {
                        if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYAXISMOTION 
                            && axi ==  (SDL.SDL_GameControllerAxis) sdlEvent.caxis.axis)
                        {
                            Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cdevice.which}'] Pressed axi={axi}");
                        }
                    }
                    
                    
                }
            }
            
        }
    }
}