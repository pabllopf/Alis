// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleWindow.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Sample
{
    /// <summary>
    ///     The simple window class
    /// </summary>
    internal class SimpleWindow
    {
        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            VideoMode mode = new VideoMode(800, 600);
            RenderWindow window = new RenderWindow(mode, "SFML works!");
            window.KeyPressed += Window_KeyPressed;

            CircleShape circle = new CircleShape(100f)
            {
                FillColor = Color.Blue
            };

            // Start the game loop
            while (window.IsOpen)
            {
                // Process events
                window.DispatchEvents();
                window.Draw(circle);

                // Finally, display the rendered frame on screen
                window.Display();
            }
        }

        /// <summary>
        ///     Function called when a key is pressed
        /// </summary>
        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window) sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}