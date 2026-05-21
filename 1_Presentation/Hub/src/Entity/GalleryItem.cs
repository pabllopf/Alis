

namespace Alis.App.Hub.Entity
{
    /// <summary>
    ///     The gallery item class
    /// </summary>
    public class GalleryItem
    {
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