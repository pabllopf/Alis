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
        private const int WIDTH = 640;

        /// <summary>
        ///     The height
        /// </summary>
        private const int HEIGHT = 480;

        /// <summary>
        ///     The title
        /// </summary>
        private const string TITLE = "Alis.Core.Graphic.Sample";

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
            VideoMode mode = new VideoMode(WIDTH, HEIGHT);
            RenderWindow window = new RenderWindow(mode, TITLE);

            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(60);

            window.Closed += (sender, args) => window.Close();

            //string fileName = Environment.CurrentDirectory + "/Assets/menu.wav";
            //Music music = new Music(fileName);
            //music.Play();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(new Color(_red, _green, _blue));
                window.Display();

                _red += 1;
                if (_red >= 100)
                    _red -= 1;
                _green += 2;
                if (_green >= 100)
                    _green -= 1;
                _blue += 3;
                if (_blue >= 100)
                    _blue -= 1;
            }
        }
    }
}