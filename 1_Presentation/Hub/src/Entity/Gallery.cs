// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gallery.cs
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

using System.Collections.Generic;

namespace Alis.App.Hub.Entity
{
    /// <summary>
    ///     The gallery class
    /// </summary>
    public class Gallery
    {
        /// <summary>
        ///     The items
        /// </summary>
        public List<GalleryItem> Items;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Gallery" /> class
        /// </summary>
        public Gallery()
        {
            Items = new List<GalleryItem>();

            string[] imageOptions = {"Hub_logo.bmp", "Hub_logo.bmp", "Hub_logo.bmp", "Hub_logo.bmp"};

            for (int i = 0; i < 10; i++)
            {
                string imagePath = imageOptions[i % imageOptions.Length];

                GalleryItem item = new GalleryItem(
                    imagePath,
                    $"Item {i + 1}",
                    $"Description for Item {i + 1}",
                    $"https://www.example.com/{i + 1}",
                    100, // Altura de la imagen
                    100 // Ancho de la imagen
                );

                Items.Add(item);
            }
        }
    }
}