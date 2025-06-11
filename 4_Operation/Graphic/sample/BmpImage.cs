using System;
using System.IO;

namespace Alis.Core.Graphic.Utility.Image
{
    public class BmpImage
    {
        public int Width { get; }
        public int Height { get; }
        public byte[] Data { get; }

        private BmpImage(int width, int height, byte[] data)
        {
            Width = width;
            Height = height;
            Data = data;
        }

        public static BmpImage Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                if (reader.ReadByte() != 'B' || reader.ReadByte() != 'M') return null;

                reader.BaseStream.Seek(10, SeekOrigin.Begin);
                int pixelDataOffset = reader.ReadInt32();

                reader.BaseStream.Seek(18, SeekOrigin.Begin);
                int width = reader.ReadInt32();
                int height = reader.ReadInt32();

                reader.BaseStream.Seek(28, SeekOrigin.Begin);
                short bitsPerPixel = reader.ReadInt16();
                if (bitsPerPixel != 24 && bitsPerPixel != 32) return null;

                int bytesPerPixel = bitsPerPixel / 8;
                int rowPadded = (width * bytesPerPixel + 3) & ~3;
                byte[] rawData = new byte[height * width * 4];

                reader.BaseStream.Seek(pixelDataOffset, SeekOrigin.Begin);

                for (int y = 0; y < height; y++)
                {
                    int row = height - 1 - y;
                    for (int x = 0; x < width; x++)
                    {
                        byte blue = reader.ReadByte();
                        byte green = reader.ReadByte();
                        byte red = reader.ReadByte();
                        byte alpha = (bytesPerPixel == 4) ? reader.ReadByte() : (byte)255;

                        int index = (row * width + x) * 4;
                        rawData[index + 0] = red;
                        rawData[index + 1] = green;
                        rawData[index + 2] = blue;
                        rawData[index + 3] = alpha;
                    }

                    int padding = rowPadded - (width * bytesPerPixel);
                    if (padding > 0)
                    {
                        reader.BaseStream.Seek(padding, SeekOrigin.Current);
                    }
                }

                return new BmpImage(width, height, rawData);
            }
        }
    }
}
