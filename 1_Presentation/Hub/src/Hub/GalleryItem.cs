// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GalleryItem.cs
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

namespace Alis.App.Hub.Hub
{
    /// <summary>
    ///     The gallery item class
    /// </summary>
    public class GalleryItem
    {
        // Constructor para inicializar los valores
        /// <summary>
        ///     Initializes a new instance of the <see cref="GalleryItem" /> class
        /// </summary>
        /// <param name="imagePath">The image path</param>
        /// <param name="title">The title</param>
        /// <param name="description">The description</param>
        /// <param name="url">The url</param>
        /// <param name="height">The height</param>
        /// <param name="width">The width</param>
        public GalleryItem(string imagePath, string title, string description, string url, int height, int width)
        {
            ImagePath = imagePath;
            Title = title;
            Description = description;
            Url = url;
            Height = height;
            Width = width;
        }

        /// <summary>
        ///     Gets or sets the value of the image path
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        ///     Gets or sets the value of the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the value of the url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        public int Width { get; set; }
    }
}