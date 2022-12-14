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
using Alis.Core.Graphic.D2.SFML.Graphics;
using Alis.Core.Graphic.D2.SFML.Windows;
using SkiaSharp;


namespace Alis.Template.Game.Desktop
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The blue
        /// </summary>
        private static float red;

        /// <summary>
        ///     The blue
        /// </summary>
        private static float green;

        /// <summary>
        ///     The blue
        /// </summary>
        private static float blue;

        /// <summary>
        /// The run
        /// </summary>
        private static bool run;
        
        /// <summary>
        /// The fill color
        /// </summary>
        private static SKColorF _fillColor;

        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            RenderWindow renderWindow;
            run = true;
            
            int width = 800;
            int height = 600;
            
            renderWindow = new RenderWindow(new VideoMode((uint) width, (uint) height), "test");

            renderWindow.SetFramerateLimit(60);
            
            renderWindow.Closed += RenderWindowOnClosed;

            //SKAutoCanvasRestore ag;
            
            SKBitmap bitmap = new SKBitmap(width, height);
            
            SKCanvas canvas = new SKCanvas(bitmap);

            canvas.DrawColor(SKColors.Chocolate);
            
            byte[] arry = bitmap.GetPixelSpan().ToArray();
            
            Image image = new Image((uint)bitmap.Width, (uint)bitmap.Height, arry);

            Texture texture = new Texture(image);

            Sprite sprite = new Sprite(texture);
            
            while (run)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear();
                
                red += 0.01f;
                if (red >= 1.0f)
                {
                    red -= 1.0f;
                }

                green += 0.02f;
                if (green >= 1.0f)
                {
                    green -= 1.0f;
                }

                blue += 0.03f;
                if (blue >= 1.0f)
                {
                    blue -= 1.0f;
                }
            
                // change the background color
                _fillColor = new SKColorF(red, green, blue);
            
                // clear the view with the specified background color
                canvas.DrawColor(_fillColor);
                
                image = new Image((uint)bitmap.Width, (uint)bitmap.Height, bitmap.GetPixelSpan().ToArray());
                texture = new Texture(image);
                sprite = new Sprite(texture);
                
                renderWindow.Draw(sprite);
                renderWindow.Display();
            }
            
            renderWindow.Close();
        }
        
        /// <summary>
        /// Renders the window on closed using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void RenderWindowOnClosed(object sender, EventArgs e)
        {
            run = false;
        }
    }
}