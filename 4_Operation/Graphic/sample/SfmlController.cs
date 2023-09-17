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
using System.Linq;
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
        ///     The width
        /// </summary>
        private const int Width = 640;

        /// <summary>
        ///     The height
        /// </summary>
        private const int Height = 480;

        /// <summary>
        ///     The axis
        /// </summary>
        private readonly List<Axis> axis = new List<Axis>((Axis[]) Enum.GetValues(typeof(Axis)));

        /// <summary>
        ///     The key
        /// </summary>
        private readonly List<Key> keys = new List<Key>((Key[]) Enum.GetValues(typeof(Key)));

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
        ///     Runs this instance
        /// </summary>
        public int Run()
        {
            VideoMode mode = new VideoMode(Width, Height);
            RenderWindow window = new RenderWindow(mode, "Sample");

            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(60);

            Window.Closed += (sender, args) => window.Close();
            Window.KeyPressed += OnKeyPressed;
            Window.MouseButtonPressed += OnMouseButtonPressed;
            Window.JoystickButtonPressed += OnJoystickButtonPressed;
            Window.JoystickConnected += WindowOnJoystickConnected;
            Window.JoystickDisconnected += WindowOnJoystickDisconnected;
            Window.JoystickMoved += WindowOnJoystickMoved;

            InitJoystick();

            while (window.IsOpen)
            {
                Joystick.Update();

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    break;
                }

                for (int index = 0; index < keys.Count - 7; index++)
                {
                    Key key = keys[index];
                    if (Keyboard.IsKeyPressed(key))
                    {
                        Console.WriteLine($@" {key}");
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
            Console.WriteLine($@"WindowOnJoystickMoved: {e.Axis} {e.JoystickId} {e.Position}");
        }

        /// <summary>
        ///     Windows the on joystick disconnected using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void WindowOnJoystickDisconnected(object sender, JoystickConnectEventArgs e)
        {
            Console.WriteLine($@"WindowOnJoystickDisconnected: {e.JoystickId}");
        }

        /// <summary>
        ///     Windows the on joystick connected using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void WindowOnJoystickConnected(object sender, JoystickConnectEventArgs e)
        {
            Console.WriteLine($@"WindowOnJoystickConnected: {e.JoystickId}");
        }

        /// <summary>
        ///     Ons the joystick button pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnJoystickButtonPressed(object sender, JoystickButtonEventArgs e)
        {
            Console.WriteLine($@"OnJoystickButtonPressed: {e.Button} {e.JoystickId}");
        }
        
        /// <summary>
        ///     Ons the key pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine($@"Key pressed: {e.Code}");
        }

        /// <summary>
        ///     Ons the mouse button pressed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine($@"Mouse pressed: {e.Button}");
        }

        /// <summary>
        ///     Inits the joystick
        /// </summary>
        private void InitJoystick()
        {
            Joystick.Update();
            for (uint i = 0; i < Joystick.Count; i++)
            {
                Identification identification = Joystick.GetIdentification(i);
                Console.Write($@"[SPACE {i}] Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");

                Console.Write(Joystick.IsConnected(i) ? @" [CONNECTED] " : @" [DISCONNECTED] ");

                uint maxButton = Joystick.GetButtonCount(i);
                Console.WriteLine($@"    Max buttons='{maxButton}'");

                for (uint j = 0; j < maxButton; j++)
                {
                    Console.WriteLine($@"    - [Button {j}]");
                    if (Joystick.IsButtonPressed(i, j))
                    {
                        Console.WriteLine($@"    [ButtonPressed] Button = '{j}' | Controller = '{i}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
                    }
                }
            }
        }
        
        /// <summary>
        /// Updates the controller
        /// </summary>
        public void UpdateController()
        {
            foreach (uint controllerId in Enumerable.Range(0, (int) Joystick.Count))
            {
                if (!Joystick.IsConnected(controllerId))
                {
                    continue;
                }

                Identification identification = Joystick.GetIdentification(controllerId);

                LogPressedButtons(controllerId, identification);
                LogMovedAxes(controllerId, identification);
            }
        }

        /// <summary>
        /// Logs the pressed buttons using the specified controller id
        /// </summary>
        /// <param name="controllerId">The controller id</param>
        /// <param name="identification">The identification</param>
        private void LogPressedButtons(uint controllerId, Identification identification)
        {
            for (uint buttonId = 0; buttonId < 32; buttonId++)
            {
                if (Joystick.IsButtonPressed(controllerId, buttonId))
                {
                    LogButtonPressed(controllerId, identification, buttonId);
                }
            }
        }

        /// <summary>
        /// Logs the moved axes using the specified controller id
        /// </summary>
        /// <param name="controllerId">The controller id</param>
        /// <param name="identification">The identification</param>
        private void LogMovedAxes(uint controllerId, Identification identification)
        {
            float tolerance = 50.0f;
            foreach (Axis axisId in axis)
            {
                if (Joystick.HasAxis(controllerId, axisId))
                {
                    float axisPosition = Joystick.GetAxisPosition(controllerId, axisId);
                    if (Math.Abs(axisPosition) > tolerance)
                    {
                        LogAxisMoved(controllerId, identification, axisId, axisPosition);
                    }
                }
            }
        }

        /// <summary>
        /// Logs the button pressed using the specified controller id
        /// </summary>
        /// <param name="controllerId">The controller id</param>
        /// <param name="identification">The identification</param>
        /// <param name="buttonId">The button id</param>
        private void LogButtonPressed(uint controllerId, Identification identification, uint buttonId)
        {
            Console.WriteLine($@"[ButtonPressed] Button = '{buttonId}' | Controller = '{controllerId}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
        }

        /// <summary>
        /// Logs the axis moved using the specified controller id
        /// </summary>
        /// <param name="controllerId">The controller id</param>
        /// <param name="identification">The identification</param>
        /// <param name="axisId">The axis id</param>
        /// <param name="axisPosition">The axis position</param>
        private void LogAxisMoved(uint controllerId, Identification identification, Axis axisId, float axisPosition)
        {
            Console.WriteLine($@"[AxisMoved] AxisId = '{axisId}' | valueAxis = '{axisPosition}' | Controller = '{controllerId}' | Name = '{identification.Name}' | ProductId='{identification.ProductId}' | VendorId='{identification.VendorId}'");
        }


    }
}