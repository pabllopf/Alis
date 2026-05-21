

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
        public readonly List<GalleryItem> Items;

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