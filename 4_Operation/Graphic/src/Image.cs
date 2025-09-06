// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Image.cs
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

using System.IO;

namespace Alis.Core.Graphic
{
    /// <summary>
    ///     The sprite class
    /// </summary>
    public class Image
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Image" /> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="data">The data</param>
        private Image(int width, int height, byte[] data)
        {
            Width = width;
            Height = height;
            Data = data;
        }

        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        public int Width { get; }

        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        public int Height { get; }

        /// <summary>
        ///     Gets the value of the data
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        ///     Loads the path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The sprite</returns>
        public static Image Load(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                if (reader.ReadByte() != 'B' || reader.ReadByte() != 'M')
                {
                    return null;
                }

                reader.BaseStream.Seek(10, SeekOrigin.Begin);
                int pixelDataOffset = reader.ReadInt32();

                reader.BaseStream.Seek(18, SeekOrigin.Begin);
                int width = reader.ReadInt32();
                int height = reader.ReadInt32();

                reader.BaseStream.Seek(28, SeekOrigin.Begin);
                short bitsPerPixel = reader.ReadInt16();
                if ((bitsPerPixel != 24) && (bitsPerPixel != 32))
                {
                    return null;
                }

                int bytesPerPixel = bitsPerPixel / 8;
                int rowPadded = (width * bytesPerPixel + 3) & ~3;
                byte[] rawData = new byte[height * width * 4];

                reader.BaseStream.Seek(pixelDataOffset, SeekOrigin.Begin);

                for (int y = 0; y < height; y++)
                {
                    int row = y;
                    for (int x = 0; x < width; x++)
                    {
                        byte blue = reader.ReadByte();
                        byte green = reader.ReadByte();
                        byte red = reader.ReadByte();
                        byte alpha = bytesPerPixel == 4 ? reader.ReadByte() : (byte) 255;

                        int index = (row * width + x) * 4;
                        rawData[index + 0] = red;
                        rawData[index + 1] = green;
                        rawData[index + 2] = blue;
                        rawData[index + 3] = alpha;
                    }

                    int padding = rowPadded - width * bytesPerPixel;
                    if (padding > 0)
                    {
                        reader.BaseStream.Seek(padding, SeekOrigin.Current);
                    }
                }

                return new Image(width, height, rawData);
            }
        }
    }
}