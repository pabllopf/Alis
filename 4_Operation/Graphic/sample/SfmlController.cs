// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlController.cs
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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Graphic.SFML.Graphics;
using Alis.Core.Graphic.SFML.Windows;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    ///     The sfml controller class
    /// </summary>
    public class SfmlController
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
        ///     The axis
        /// </summary>
        public readonly List<Axis> Axis = new List<Axis>((Axis[]) Enum.GetValues(typeof(Axis)));

        /// <summary>
        ///     The key
        /// </summary>
        public readonly List<Key> Keys = new List<Key>((Key[]) Enum.GetValues(typeof(Key)));

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
            VideoMode mode = new VideoMode(Width, Height);
            RenderWindow window = new RenderWindow(mode, "Sample");

            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(60);

            window.Closed += (sender, args) => window.Close();

            // Configura los eventos de input
            window.KeyPressed += OnKeyPressed;
            window.MouseButtonPressed += OnMouseButtonPressed;
            window.JoystickButtonPressed += OnJoystickButtonPressed;
            window.JoystickConnected += WindowOnJoystickConnected;
            window.JoystickDisconnected += WindowOnJoystickDisconnected;
            window.JoystickMoved += WindowOnJoystickMoved;

            InitJoystick();

            while (window.IsOpen)
            {
                Joystick.Update();

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    break;
                }

                for (int index = 0; index < Keys.Count - 7; index++)
                {
                    Key key = Keys[index];
                    if (Keyboard.IsKeyPressed(key))
                    {
                        Console.WriteLine($" {key}");
                    }
                }

                window.DispatchEvents();
                window.Clear(new Color(_red, _green, _blue));
                window.Display();

                RenderColors();
            }

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
        private void WindowOnJoystickDisconnected(object sender, JoystickConnectEventArgs e)
        {
            Console.WriteLine($"WindowOnJoystickDisconnected: {e.JoystickId}");
        }

        /// <summary>
        ///     Windows the on joystick connected using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void WindowOnJoystickConnected(object sender, JoystickConnectEventArgs e)
        {
            Console.WriteLine($"WindowOnJoystickConnected: {e.JoystickId}");
        }

        /// <summary>
        ///     Ons the joystick button pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnJoystickButtonPressed(object sender, JoystickButtonEventArgs e)
        {
            Console.WriteLine($"Tecla mando presionada: {e.Button} {e.JoystickId}");
        }


        /// <summary>
        ///     Ons the key pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"Tecla presionada: {e.Code}");
        }

        /// <summary>
        ///     Ons the mouse button pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine($"Botón del mouse presionado: {e.Button}");
        }

        /// <summary>
        ///     Inits the joystick
        /// </summary>
        public void InitJoystick()
        {
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
        }

        /// <summary>
        ///     Updatecontrollerses
        /// </summary>
        public void Updatecontrollers()
        {
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
                    foreach (Axis axisId in Axis)
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
        }
    }
}