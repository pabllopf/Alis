// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontManager.cs
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

using Alis.Core.Aspect.Math.Definition;

namespace Alis.Core.Graphic.Ui
{
    /// <summary>
    ///     The font manager class
    /// </summary>
    public static class FontManager
    {
        /// <summary>
        ///     Gets the value of the default font
        /// </summary>
        public static Font DefaultFont { get; } = new Font("mono.bmp", 1, 1, "");

        /// <summary>
        ///     Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="foreColor">The fore color</param>
        /// <param name="backColor">The back color</param>
        public static void RenderText(string text, int x, int y, Color foreColor, Color backColor)
        {
            DefaultFont.RenderText(text, x, y, foreColor, backColor);
        }

        /// <summary>
        ///     Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public static void RenderText(string text, int x, int y)
        {
            DefaultFont.RenderText(text, x, y, Color.White, Color.Transparent);
        }
    }
}