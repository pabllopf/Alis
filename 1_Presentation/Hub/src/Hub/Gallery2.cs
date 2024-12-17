// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gallery2.cs
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
using Alis.Core.Aspect.Data.Resource;

namespace Alis.App.Hub.Hub
{
    /// <summary>
    /// The gallery class
    /// </summary>
    public class Gallery2
    {
        /// <summary>
        /// The items
        /// </summary>
        public List<GalleryItem> Items;

        // Método para generar una lista de 10 elementos de tipo GalleryItem
        /// <summary>
        /// Initializes a new instance of the <see cref="Gallery2"/> class
        /// </summary>
        public Gallery2()
        {
            Items = new List<GalleryItem>();
            Random random = new Random();

            // Lista de posibles imágenes
            string[] imageOptions = {"computer.png", "news.png", "cubes.png", "shop.png"};

            // Generar 10 elementos de la galería
            for (int i = 0; i < 10; i++)
            {
                // Seleccionar una imagen aleatoria
                string imagePath = AssetManager.Find(imageOptions[random.Next(imageOptions.Length)]);

                // Crear un nuevo GalleryItem con datos aleatorios
                GalleryItem item = new GalleryItem(
                    imagePath,
                    $"Item {i + 1}",
                    $"Description for Item {i + 1}",
                    $"https://www.example.com/{i + 1}",
                    100, // Altura de la imagen
                    100 // Ancho de la imagen
                );

                // Agregar el item a la lista
                Items.Add(item);
            }
        }
    }
}