using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Resource;

namespace Alis.App.Engine.Hub
{
    public class Gallery
    {
        public List<GalleryItem> Items { get; set; }

        public Gallery()
        {
            Random rand = new Random();
            string[] imageOptions = { "computer.png", "news.png", "cubes.png", "shop.png" };

            Items = new List<GalleryItem>();

            int containerWidth = 750;  // Ancho total del espacio
            int containerHeight = 1500; // Altura total del espacio

            var board = new Board(containerWidth, containerHeight); // Tablero para gestionar huecos

            // Primera vuelta: Generar cajas aleatorias de tamaño 200x200, 200x100, 100x200
            while (board.HasSpace())
            {
                int width = rand.Next(0, 2) == 0 ? 100 : (rand.Next(0, 2) == 0 ? 200 : 100); // 100, 200, o 100
                int height = rand.Next(0, 2) == 0 ? 100 : (rand.Next(0, 2) == 0 ? 200 : 100); // 100, 200, o 100

                if (board.TryPlaceItem(width, height, out var position))
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

        // Método para rellenar huecos con cajas de 100x100
        private void FillRemainingGaps(int containerWidth, int containerHeight, Random rand, string[] imageOptions, Board board)
        {
            // Seguir buscando huecos mientras haya espacio
            while (board.HasSpace())
            {
                // Intentar colocar una caja de 100x100 en el primer hueco encontrado
                if (board.TryPlaceItem(100, 100, out var position))
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
        private void FillSmallRemainingGaps(int containerWidth, int containerHeight, Random rand, string[] imageOptions, Board board)
        {
            // Seguir buscando huecos mientras haya espacio
            while (board.HasSpace())
            {
                // Intentar colocar una caja de 50x50 en el primer hueco encontrado
                if (board.TryPlaceItem(50, 50, out var position))
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
        private static string GetRandomImagePath(string[] imageOptions, Random rand)
        {
            int index = rand.Next(imageOptions.Length);
            return AssetManager.Find(imageOptions[index]);
        }
    }

    // Clase que representa el tablero de la galería
    public class Board
    {
        private bool[,] grid;
        private int width;
        private int height;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new bool[height, width];
        }

        // Verifica si hay espacio disponible en el tablero
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
