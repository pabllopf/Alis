// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrameBase.cs
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

using Alis.Core.Graphic.SFML.Graphics;

namespace Alis.Core.Graphic
{
    /// <summary>
    ///     The frame base class
    /// </summary>
    public class FrameBase
    {
        /// <summary>
        ///     The file path
        /// </summary>
        private string filePath;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrameBase" /> class
        /// </summary>
        public FrameBase() => filePath = "";

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrameBase" /> class
        /// </summary>
        /// <param name="filePath">The file path</param>
        public FrameBase(string filePath)
        {
            this.filePath = filePath;
            Texture = new Texture(filePath);
        }

        /// <summary>
        ///     Gets or sets the value of the texture
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        ///     Sets the frame using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        public void SetFrame(string filePath)
        {
            this.filePath = filePath;
            Texture = new Texture(filePath);
        }
    }
}