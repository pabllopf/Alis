using System.IO;
using Alis.Core.Graphic.Stb;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    /// The loader bmp class
    /// </summary>
    public class LoaderBmp
    {
        /// <summary>
        /// Loads the image using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="nrChannels">The nr channels</param>
        /// <returns>The void</returns>
        public static unsafe void* LoadImage(string filePath, ref int width, ref int height, ref int nrChannels)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StbImage.stbi__context stbiContext = new StbImage.stbi__context(stream);
                fixed (int* pWidth = &width, pHeight = &height, pNrChannels = &nrChannels)
                {
                    return StbImage.stbi__bmp_load(stbiContext, pWidth, pHeight, pNrChannels, 0, null);
                }
            }
        }
    }
}