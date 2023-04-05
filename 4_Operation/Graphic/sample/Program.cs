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
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Graphic.D2.SFML.Windows;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public class Program
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

            //string fileName = Environment.CurrentDirectory + "/Assets/menu.wav";
            //Music music = new Music(fileName);
            //music.Play();

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
    }
}