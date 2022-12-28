// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomRender.cs
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

using SkiaSharp;

namespace Alis.Core.Graphic.D2.SKIA
{
    /// <summary>
    ///     The custom render class
    /// </summary>
    public static class CustomRender
    {
        /// <summary>
        ///     The blue
        /// </summary>
        private static float red, green, blue;

        /// <summary>
        ///     The fill color
        /// </summary>
        private static SKColorF _fillColor;

        /// <summary>
        ///     Updates the e surface
        /// </summary>
        /// <param name="surfaceCanvas">The surface canvas</param>
        public static void Update(SKCanvas surfaceCanvas)
        {
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
            surfaceCanvas.DrawColor(_fillColor);
        }
    }
}