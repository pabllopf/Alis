// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Board.cs
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

namespace Alis.App.Engine.Hub
{
    /// <summary>
    /// The board class
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The grid
        /// </summary>
        private readonly bool[,] grid;
        /// <summary>
        /// The height
        /// </summary>
        private readonly int height;
        /// <summary>
        /// The width
        /// </summary>
        private readonly int width;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new bool[height, width];
        }

        // Verifica si hay espacio disponible en el tablero
        /// <summary>
        /// Describes whether this instance has space
        /// </summary>
        /// <returns>The bool</returns>
        public bool HasSpace()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!grid[y, x]) // Hay espacio vacío
                    {
                        return true;
                    }
                }
            }

            return false; // No hay espacio vacío
        }

        // Intenta colocar un item en el tablero, si es posible
        /// <summary>
        /// Describes whether this instance try place item
        /// </summary>
        /// <param name="itemWidth">The item width</param>
        /// <param name="itemHeight">The item height</param>
        /// <param name="position">The position</param>
        /// <returns>The bool</returns>
        public bool TryPlaceItem(int itemWidth, int itemHeight, out (int x, int y) position)
        {
            position = (-1, -1);

            // Buscar un espacio adecuado
            for (int y = 0; y <= height - itemHeight; y++)
            {
                for (int x = 0; x <= width - itemWidth; x++)
                {
                    if (CanPlaceItem(x, y, itemWidth, itemHeight))
                    {
                        // Colocar el item
                        PlaceItem(x, y, itemWidth, itemHeight);
                        position = (x, y);
                        return true;
                    }
                }
            }

            return false; // No se encontró espacio suficiente
        }

        // Verifica si se puede colocar un item en la posición dada
        /// <summary>
        /// Describes whether this instance can place item
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="itemWidth">The item width</param>
        /// <param name="itemHeight">The item height</param>
        /// <returns>The bool</returns>
        private bool CanPlaceItem(int x, int y, int itemWidth, int itemHeight)
        {
            for (int i = 0; i < itemHeight; i++)
            {
                for (int j = 0; j < itemWidth; j++)
                {
                    if (grid[y + i, x + j]) // Si ya está ocupado
                    {
                        return false;
                    }
                }
            }

            return true; // El espacio está libre
        }

        // Coloca un item en la posición dada
        /// <summary>
        /// Places the item using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="itemWidth">The item width</param>
        /// <param name="itemHeight">The item height</param>
        private void PlaceItem(int x, int y, int itemWidth, int itemHeight)
        {
            for (int i = 0; i < itemHeight; i++)
            {
                for (int j = 0; j < itemWidth; j++)
                {
                    grid[y + i, x + j] = true; // Marca la celda como ocupada
                }
            }
        }
    }
}