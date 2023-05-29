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
using Alis.Core.Graphic.SDL;
using Alis.Core.Graphic.SFML.Graphics;
using Alis.Core.Graphic.SFML.Windows;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
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
        ///     The title
        /// </summary>
        private const string Title = "Alis.Core.Graphic.Sample";

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _red, _green, _blue;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            VideoMode mode = new VideoMode(Width, Height);
            RenderWindow window = new RenderWindow(mode, Title);

            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(60);

            window.Closed += (sender, args) => window.Close();
            
            List<Key> keys = new List<Key>((Key[]) Enum.GetValues(typeof(Key)));

            List<Axis> axis = new List<Axis>((Axis[]) Enum.GetValues(typeof(Axis)));


            Joystick.Update();
            for (uint i = 0; i < Joystick.Count; i++)
            {
                Joystick.Identification identification = Joystick.GetIdentification(i);
                Console.Write($"[SPACE {i}] Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");

                if (Joystick.IsConnected(i))
                {
                    Console.Write(" [CONNECTED] ");
                }
                else
                {
                    Console.Write(" [DISCONNECTED] ");
                }

                Console.Write("\n");

                uint maxbutton = Joystick.GetButtonCount(i);
                Console.WriteLine($"    Maxbuttons='{maxbutton}'");

                for (uint j = 0; j < maxbutton; j++)
                {
                    Console.WriteLine($"    - [Button {j}]");
                    if (Joystick.IsButtonPressed(i, j))
                    {
                        Console.WriteLine($"    [ButtonPressed] Button = '{j}' | Controller = '{i}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
                    }
                }

                Console.Write("\n");
            }


            while (window.IsOpen)
            {
                window.DispatchEvents();
                Joystick.Update();

                for (int index = 0; index < keys.Count - 7; index++)
                {
                    Key key = keys[index];
                    if (Keyboard.IsKeyPressed(key))
                    {
                        Console.WriteLine($" {key}");
                    }
                }

                for (uint i = 0; i < Joystick.Count; i++)
                {
                    if (Joystick.IsConnected(i))
                    {
                        Joystick.Identification identification = Joystick.GetIdentification(i);
                        //uint maxbutton = Joystick.GetButtonCount(i);
                        for (uint j = 0; j < 32; j++)
                        {
                            if (Joystick.IsButtonPressed(i, j))
                            {
                                Console.WriteLine($"    [ButtonPressed] Button = '{j}' | Controller = '{i}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
                            }
                        }


                        float tolerencie = 50.0f;
                        foreach (Axis axisId in axis)
                        {
                            if (Joystick.HasAxis(i, axisId))
                            {
                                if (Joystick.GetAxisPosition(i, axisId) > tolerencie || Joystick.GetAxisPosition(i, axisId) < -tolerencie)
                                {
                                    Console.WriteLine($"    [ButtonPressed] AxisId = '{axisId}' | valueAxi = '{Joystick.GetAxisPosition(i, axisId)}' | Controller = '{i}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
                                }
                            }
                        }


                        //Console.WriteLine($"    [ButtonPressed] AxisId = '{Axis.PovX}' | valueAxi = '{Joystick.GetAxisPosition(i, Axis.PovX)}' | Controller = '{i}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
                    }
                }

                window.Clear(new Color(_red, _green, _blue));
                window.Display();


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
        }

        /// <summary>
        ///     Sdlinputs
        /// </summary>
        private static void Sdlinput()
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


        /// <summary>
        ///     Sfmlinputs
        /// </summary>
        public static void Sfmlinput()
        {
            // Crea una ventana vacía (sin bordes ni contenido)
            ContextSettings contextSettings = new ContextSettings {DepthBits = 0, StencilBits = 0};
            RenderWindow window = new RenderWindow(new VideoMode(1, 1), "Input Example", Styles.None, contextSettings);
            window.SetActive(false);

            // Configura los eventos de input
            window.KeyPressed += OnKeyPressed;
            window.MouseButtonPressed += OnMouseButtonPressed;
            window.JoystickButtonPressed += OnJoystickButtonPressed;
            window.JoystickConnected += WindowOnJoystickConnected;
            window.JoystickDisconnected += WindowOnJoystickDisconnected;
            window.JoystickMoved += WindowOnJoystickMoved;

            while (true)
            {
                // Procesa los eventos
                window.DispatchEvents();

                // Realiza cualquier lógica de juego aquí

                // Salir del bucle si se presiona la tecla Escape
                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    break;
                }
            }
        }

        /// <summary>
        ///     Windows the on joystick moved using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void WindowOnJoystickMoved(object sender, JoystickMoveEventArgs e)
        {
            Console.WriteLine($"WindowOnJoystickMoved: {e.Axis} {e.JoystickId} {e.Position}");
        }

        /// <summary>
        ///     Windows the on joystick disconnected using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void WindowOnJoystickDisconnected(object sender, JoystickConnectEventArgs e)
        {
            Console.WriteLine($"WindowOnJoystickDisconnected: {e.JoystickId}");
        }

        /// <summary>
        ///     Windows the on joystick connected using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void WindowOnJoystickConnected(object sender, JoystickConnectEventArgs e)
        {
            Console.WriteLine($"WindowOnJoystickConnected: {e.JoystickId}");
        }

        /// <summary>
        ///     Ons the joystick button pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnJoystickButtonPressed(object sender, JoystickButtonEventArgs e)
        {
            Console.WriteLine($"Tecla mando presionada: {e.Button} {e.JoystickId}");
        }


        /// <summary>
        ///     Ons the key pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"Tecla presionada: {e.Code}");
        }

        /// <summary>
        ///     Ons the mouse button pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine($"Botón del mouse presionado: {e.Button}");
        }
    }
}