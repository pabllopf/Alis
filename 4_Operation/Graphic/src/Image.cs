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

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Resources;

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
        
  public static Image LoadImageFromResources(string resourceName)
  {
      var assembly = Assembly.GetExecutingAssembly();
      if (assembly == null)
          throw new InvalidOperationException("No assembly found.");
  
      using (Stream streamPack = assembly.GetManifestResourceStream($"assets.pak"))
      {
          if (streamPack == null)
              throw new FileNotFoundException("Resource file 'assets.pak' not found in embedded resources.");
  
          using (MemoryStream memPack = new MemoryStream())
          {
              streamPack.CopyTo(memPack);
              memPack.Position = 0;
  
              using (ZipArchive zip = new ZipArchive(memPack, ZipArchiveMode.Read))
              {
                  ZipArchiveEntry entry = zip.Entries.FirstOrDefault(e => e.FullName.Contains(resourceName));
                  if (entry == null)
                      throw new FileNotFoundException($"Resource '{resourceName}' not found in 'assets.pak'.");
  
                  using (Stream entryStream = entry.Open())
                  using (MemoryStream memImage = new MemoryStream())
                  {
                      entryStream.CopyTo(memImage);
                      memImage.Position = 0;
                      return LoadFromStream(memImage);
                  }
              }
          }
      }
  }
        private static Image LoadFromStream(Stream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                if (reader.ReadByte() != 'B' || reader.ReadByte() != 'M')
                {
                    throw new InvalidDataException("Not a valid BMP file (missing BM header)");
                }

                reader.BaseStream.Seek(10, SeekOrigin.Begin);
                int pixelDataOffset = reader.ReadInt32();

                reader.BaseStream.Seek(14, SeekOrigin.Begin);
                int headerSize = reader.ReadInt32();

                reader.BaseStream.Seek(18, SeekOrigin.Begin);
                int width = reader.ReadInt32();
                int height = reader.ReadInt32();
                
                reader.BaseStream.Seek(28, SeekOrigin.Begin);
                short bitsPerPixel = reader.ReadInt16();

                reader.BaseStream.Seek(30, SeekOrigin.Begin);
                int compression = reader.ReadInt32();

                int bytesPerPixel = bitsPerPixel / 8;
                int rowPadded = ((width * bitsPerPixel + 31) / 32) * 4;
                byte[] rawData = new byte[height * width * 4];

                // Leer paleta si existe
                int paletteSize = 0;
                byte[][] palette = null;
                if (bitsPerPixel == 8)
                {
                    paletteSize = 256;
                }
                else if (bitsPerPixel == 4)
                {
                    paletteSize = 16;
                }
                else if (bitsPerPixel == 1)
                {
                    paletteSize = 2;
                }
                if (paletteSize > 0)
                {
                    reader.BaseStream.Seek(headerSize + 14, SeekOrigin.Begin);
                    palette = new byte[paletteSize][];
                    for (int i = 0; i < paletteSize; i++)
                    {
                        byte blue = reader.ReadByte();
                        byte green = reader.ReadByte();
                        byte red = reader.ReadByte();
                        byte reserved = reader.ReadByte();
                        palette[i] = new byte[] { red, green, blue, 255 };
                    }
                }

                int[] bitfieldsMasks = null;
                if (compression == 3) {
                    // Las máscaras están justo después del header
                    reader.BaseStream.Seek(headerSize + 14, SeekOrigin.Begin);
                    bitfieldsMasks = new int[bitsPerPixel == 32 ? 4 : 3];
                    for (int i = 0; i < bitfieldsMasks.Length; i++) {
                        bitfieldsMasks[i] = reader.ReadInt32();
                    }
                    reader.BaseStream.Seek(pixelDataOffset, SeekOrigin.Begin);
                }

                // Soporte explícito para imágenes BMP de 24 bits (RGB)
                // Si bitsPerPixel == 24, se procesa como imagen RGB sin canal alfa
                // El canal alfa se establece en 255 por defecto
                if (compression == 0 || compression == 3) { // BI_RGB
                    LoadBmpRgb(reader, width, height, bitsPerPixel, rawData, palette, rowPadded, bytesPerPixel);
                } else if (compression == 1 && bitsPerPixel == 8) { // BI_RLE8
                    LoadBmpRle8(reader, width, height, bitsPerPixel, rawData, palette, rowPadded, bytesPerPixel);
                } else if (compression == 2 && bitsPerPixel == 4) { // BI_RLE4
                    LoadBmpRle4(reader, width, height, bitsPerPixel, rawData, palette, rowPadded, bytesPerPixel);
                } else {
                    throw new NotSupportedException($"Unsupported BMP compression type: {compression}");
                }

                return new Image(width, height, rawData);
            }
        }

        /// <summary>
        ///     Loads the path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The sprite</returns>
        public static Image Load(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return LoadFromStream(stream);
            }
        }

        // Métodos separados para cada tipo de BMP
        private static void LoadBmpRgb(BinaryReader reader, int width, int height, short bitsPerPixel, byte[] rawData, byte[][] palette, int rowPadded, int bytesPerPixel) {
            if (height < 0) {
                height = -height;
            }
            for (int y = 0; y < height; y++)
            {
                int row = y; // Corregido: siempre cargar de arriba hacia abajo
                if (bitsPerPixel == 24 || bitsPerPixel == 32)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte blue = reader.ReadByte();
                        byte green = reader.ReadByte();
                        byte red = reader.ReadByte();
                        byte alpha = bitsPerPixel == 32 ? reader.ReadByte() : (byte)255;
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
                else if (bitsPerPixel == 8 && palette != null)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte colorIndex = reader.ReadByte();
                        int index = (row * width + x) * 4;
                        rawData[index + 0] = palette[colorIndex][0];
                        rawData[index + 1] = palette[colorIndex][1];
                        rawData[index + 2] = palette[colorIndex][2];
                        rawData[index + 3] = palette[colorIndex][3];
                    }
                    int padding = rowPadded - width;
                    if (padding > 0)
                    {
                        reader.BaseStream.Seek(padding, SeekOrigin.Current);
                    }
                }
                else if (bitsPerPixel == 4 && palette != null)
                {
                    int pixels = 0;
                    for (int x = 0; x < width; x += 2)
                    {
                        byte b = reader.ReadByte();
                        for (int i = 0; i < 2 && (x + i) < width; i++)
                        {
                            byte colorIndex = (byte)((i == 0) ? (b >> 4) : (b & 0x0F));
                            int index = (row * width + x + i) * 4;
                            rawData[index + 0] = palette[colorIndex][0];
                            rawData[index + 1] = palette[colorIndex][1];
                            rawData[index + 2] = palette[colorIndex][2];
                            rawData[index + 3] = palette[colorIndex][3];
                            pixels++;
                        }
                    }
                    int padding = rowPadded - ((width + 1) / 2);
                    if (padding > 0)
                    {
                        reader.BaseStream.Seek(padding, SeekOrigin.Current);
                    }
                }
                else if (bitsPerPixel == 1 && palette != null)
                {
                    int pixels = 0;
                    for (int x = 0; x < width; x += 8)
                    {
                        byte b = reader.ReadByte();
                        for (int i = 0; i < 8 && (x + i) < width; i++)
                        {
                            byte colorIndex = (byte)((b >> (7 - i)) & 0x01);
                            int index = (row * width + x + i) * 4;
                            rawData[index + 0] = palette[colorIndex][0];
                            rawData[index + 1] = palette[colorIndex][1];
                            rawData[index + 2] = palette[colorIndex][2];
                            rawData[index + 3] = palette[colorIndex][3];
                            pixels++;
                        }
                    }
                    int padding = rowPadded - ((width + 7) / 8);
                    if (padding > 0)
                    {
                        reader.BaseStream.Seek(padding, SeekOrigin.Current);
                    }
                }
                else
                {
                    throw new NotSupportedException($"Unsupported bits per pixel: {bitsPerPixel}");
                }
            }
        }

        private static void LoadBmpRle8(BinaryReader reader, int width, int height, short bitsPerPixel, byte[] rawData, byte[][] palette, int rowPadded, int bytesPerPixel) {
            
            int x = 0, y = 0; // Corregido: empezar desde la primera fila
            while (reader.BaseStream.Position < reader.BaseStream.Length && y < height)
            {
                byte count = reader.ReadByte();
                byte value = reader.ReadByte();
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (x >= width)
                        {
                            x = 0;
                            y++;
                        }
                        int index = (y * width + x) * 4; // Corregido: filas de arriba hacia abajo
                        rawData[index + 0] = palette[value][0];
                        rawData[index + 1] = palette[value][1];
                        rawData[index + 2] = palette[value][2];
                        rawData[index + 3] = palette[value][3];
                        x++;
                    }
                }
                else
                {
                    if (value == 0) // End of line
                    {
                        x = 0;
                        y++;
                    }
                    else if (value == 1) // End of bitmap
                    {
                        break;
                    }
                    else if (value == 2) // Delta
                    {
                        byte dx = reader.ReadByte();
                        byte dy = reader.ReadByte();
                        x += dx;
                        y += dy;
                    }
                    else // Absolute mode
                    {
                        int absCount = value;
                        for (int i = 0; i < absCount; i++)
                        {
                            byte absValue = reader.ReadByte();
                            if (x >= width)
                            {
                                x = 0;
                                y++;
                            }
                            int index = (y * width + x) * 4;
                            rawData[index + 0] = palette[absValue][0];
                            rawData[index + 1] = palette[absValue][1];
                            rawData[index + 2] = palette[absValue][2];
                            rawData[index + 3] = palette[absValue][3];
                            x++;
                        }
                        if ((absCount & 1) == 1)
                        {
                            reader.ReadByte(); // Padding
                        }
                    }
                }
            }
        }

        private static void LoadBmpRle4(BinaryReader reader, int width, int height, short bitsPerPixel, byte[] rawData, byte[][] palette, int rowPadded, int bytesPerPixel) {
            if (height < 0) {
                height = -height;
            }
            
            int x = 0, y = 0; // Corregido: empezar desde la primera fila
            while (reader.BaseStream.Position < reader.BaseStream.Length && y < height)
            {
                byte count = reader.ReadByte();
                byte value = reader.ReadByte();
                if (count > 0)
                {
                    byte first = (byte)(value >> 4);
                    byte second = (byte)(value & 0x0F);
                    for (int i = 0; i < count; i++)
                    {
                        byte colorIndex = (byte)((i % 2 == 0) ? first : second);
                        if (x >= width)
                        {
                            x = 0;
                            y++;
                        }
                        int index = (y * width + x) * 4; // Corregido: filas de arriba hacia abajo
                        rawData[index + 0] = palette[colorIndex][0];
                        rawData[index + 1] = palette[colorIndex][1];
                        rawData[index + 2] = palette[colorIndex][2];
                        rawData[index + 3] = palette[colorIndex][3];
                        x++;
                    }
                }
                else
                {
                    if (value == 0) // End of line
                    {
                        x = 0;
                        y++;
                    }
                    else if (value == 1) // End of bitmap
                    {
                        break;
                    }
                    else if (value == 2) // Delta
                    {
                        byte dx = reader.ReadByte();
                        byte dy = reader.ReadByte();
                        x += dx;
                        y += dy;
                    }
                    else // Absolute mode
                    {
                        int absCount = value;
                        int pairs = (absCount + 1) / 2;
                        for (int i = 0; i < pairs; i++)
                        {
                            byte absValue = reader.ReadByte();
                            byte first = (byte)(absValue >> 4);
                            byte second = (byte)(absValue & 0x0F);
                            for (int j = 0; j < 2 && (i * 2 + j) < absCount; j++)
                            {
                                byte colorIndex = (j == 0) ? first : second;
                                if (x >= width)
                                {
                                    x = 0;
                                    y++;
                                }
                                int index = (y * width + x) * 4;
                                rawData[index + 0] = palette[colorIndex][0];
                                rawData[index + 1] = palette[colorIndex][1];
                                rawData[index + 2] = palette[colorIndex][2];
                                rawData[index + 3] = palette[colorIndex][3];
                                x++;
                            }
                        }
                        if (((absCount & 3) == 1) || ((absCount & 3) == 2))
                        {
                            reader.ReadByte(); // Padding
                        }
                    }
                }
            }
        }
    }
}
