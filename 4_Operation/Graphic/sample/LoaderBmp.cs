using System.IO;
using Alis.Core.Graphic.Stb;

namespace Alis.Core.Graphic.Sample
{
    public class LoaderBmp
    {
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