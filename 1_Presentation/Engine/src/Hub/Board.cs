namespace Alis.App.Engine.Hub
{
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