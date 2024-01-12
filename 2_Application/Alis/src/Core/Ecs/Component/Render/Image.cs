// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Image.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;

namespace Alis.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The image class
    /// </summary>
    public class Image
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Image" /> class
        /// </summary>
        public Image()
        {
            Logger.Trace();
            Path = "";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Image" /> class
        /// </summary>
        /// <param name="path">The path</param>
        public Image(string path)
        {
            Logger.Trace();
            Path = path;
            //Load Texture:
            Texture = SdlImage.ImgLoadTexture(VideoGame.Instance.GraphicManager.Renderer, path);

            // get the size of sprite.Image.Texture
            Sdl.QueryTexture(Texture, out _, out _, out int w, out int h);
            Size = new Vector2(w, h);
        }

        /// <summary>
        ///     Gets or sets the value of the path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///     Gets or sets the value of the texture
        /// </summary>
        public IntPtr Texture { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        public Vector2 Size { get; set; }
    }
}