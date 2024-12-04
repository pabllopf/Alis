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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Resource;

namespace Alis.App.Engine.Hub
{
    /// <summary>
    /// The gallery class
    /// </summary>
    public class Gallery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gallery"/> class
        /// </summary>
        public Gallery()
        {
            Random rand = new Random();
            string[] imageOptions = {"computer.png", "news.png", "cubes.png", "shop.png"};

            Items = new List<GalleryItem>();

            int containerWidth = 750; // Ancho total del espacio
            int containerHeight = 1500; // Altura total del espacio

            Board board = new Board(containerWidth, containerHeight); // Tablero para gestionar huecos

            // Primera vuelta: Generar cajas aleatorias de tamaño 200x200, 200x100, 100x200
            while (board.HasSpace())
            {
                int width = rand.Next(0, 2) == 0 ? 100 : rand.Next(0, 2) == 0 ? 200 : 100; // 100, 200, o 100
                int height = rand.Next(0, 2) == 0 ? 100 : rand.Next(0, 2) == 0 ? 200 : 100; // 100, 200, o 100

                if (board.TryPlaceItem(width, height, out (int x, int y) position))
                {
                    Items.Add(new GalleryItem(
                        GetRandomImagePath(imageOptions, rand),
                        $"Resource {Items.Count + 1}",
                        $"Description for resource {Items.Count + 1}",
                        $"http://example{Items.Count + 1}.com",
                        width,
                        height
                    ));
                }
                else
                {
                    break; // Salir si no se puede colocar más elementos
                }
            }

            // Segunda vuelta: Buscar huecos y rellenarlos con cajas de 100x100
            FillRemainingGaps(containerWidth, containerHeight, rand, imageOptions, board);

            // Tercera vuelta: Buscar huecos y rellenarlos con cajas de 50x50
            FillSmallRemainingGaps(containerWidth, containerHeight, rand, imageOptions, board);
        }

        /// <summary>
        /// Gets or sets the value of the items
        /// </summary>
        public List<GalleryItem> Items { get; set; }

        // Método para rellenar huecos con cajas de 100x100
        /// <summary>
        /// Fills the remaining gaps using the specified container width
        /// </summary>
        /// <param name="containerWidth">The container width</param>
        /// <param name="containerHeight">The container height</param>
        /// <param name="rand">The rand</param>
        /// <param name="imageOptions">The image options</param>
        /// <param name="board">The board</param>
        private void FillRemainingGaps(int containerWidth, int containerHeight, Random rand, string[] imageOptions, Board board)
        {
            // Seguir buscando huecos mientras haya espacio
            while (board.HasSpace())
            {
                // Intentar colocar una caja de 100x100 en el primer hueco encontrado
                if (board.TryPlaceItem(100, 100, out (int x, int y) position))
                {
                    Items.Add(new GalleryItem(
                        GetRandomImagePath(imageOptions, rand),
                        $"Resource {Items.Count + 1}",
                        $"Description for resource {Items.Count + 1}",
                        $"http://example{Items.Count + 1}.com",
                        100,
                        100
                    ));
                }
                else
                {
                    break; // Salir si no se puede colocar más cajas
                }
            }
        }

        // Método para rellenar huecos con cajas de 50x50
        /// <summary>
        /// Fills the small remaining gaps using the specified container width
        /// </summary>
        /// <param name="containerWidth">The container width</param>
        /// <param name="containerHeight">The container height</param>
        /// <param name="rand">The rand</param>
        /// <param name="imageOptions">The image options</param>
        /// <param name="board">The board</param>
        private void FillSmallRemainingGaps(int containerWidth, int containerHeight, Random rand, string[] imageOptions, Board board)
        {
            // Seguir buscando huecos mientras haya espacio
            while (board.HasSpace())
            {
                // Intentar colocar una caja de 50x50 en el primer hueco encontrado
                if (board.TryPlaceItem(50, 50, out (int x, int y) position))
                {
                    Items.Add(new GalleryItem(
                        GetRandomImagePath(imageOptions, rand),
                        $"Resource {Items.Count + 1}",
                        $"Description for resource {Items.Count + 1}",
                        $"http://example{Items.Count + 1}.com",
                        50,
                        50
                    ));
                }
                else
                {
                    break; // Salir si no se puede colocar más cajas
                }
            }
        }

        // Función para obtener una imagen aleatoria
        /// <summary>
        /// Gets the random image path using the specified image options
        /// </summary>
        /// <param name="imageOptions">The image options</param>
        /// <param name="rand">The rand</param>
        /// <returns>The string</returns>
        private static string GetRandomImagePath(string[] imageOptions, Random rand)
        {
            int index = rand.Next(imageOptions.Length);
            return AssetManager.Find(imageOptions[index]);
        }
    }

    // Clase que representa el tablero de la galería
}