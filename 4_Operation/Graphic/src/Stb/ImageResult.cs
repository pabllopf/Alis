// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageResult.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The image result class
    /// </summary>
    public
        class ImageResult
    {
        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the source comp
        /// </summary>
        public ColorComponents SourceComp { get; set; }

        /// <summary>
        ///     Gets or sets the value of the comp
        /// </summary>
        public ColorComponents Comp { get; set; }

        /// <summary>
        ///     Gets or sets the value of the data
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        ///     Creates the result using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>The image</returns>
        internal static unsafe ImageResult FromResult(byte* result, int width, int height, ColorComponents comp,
            ColorComponents req_comp)
        {
            if (result == null)
                throw new InvalidOperationException(StbImage.stbi__g_failure_reason);

            ImageResult image = new ImageResult
            {
                Width = width,
                Height = height,
                SourceComp = comp,
                Comp = req_comp == ColorComponents.Default ? comp : req_comp
            };

            // Convert to array
            image.Data = new byte[width * height * (int) image.Comp];
            Marshal.Copy(new IntPtr(result), image.Data, 0, image.Data.Length);

            return image;
        }

        /// <summary>
        ///     Creates the stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="requiredComponents">The required components</param>
        /// <returns>The image result</returns>
        public static unsafe ImageResult FromStream(Stream stream,
            ColorComponents requiredComponents = ColorComponents.Default)
        {
            byte* result = null;

            try
            {
                int x, y, comp;

                StbImage.stbi__context context = new StbImage.stbi__context(stream);

                result = StbImage.stbi__load_and_postprocess_8bit(context, &x, &y, &comp, (int) requiredComponents);

                return FromResult(result, x, y, (ColorComponents) comp, requiredComponents);
            }
            finally
            {
                if (result != null)
                    CRuntime.free(result);
            }
        }

        /// <summary>
        ///     Creates the memory using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="requiredComponents">The required components</param>
        /// <returns>The image result</returns>
        public static ImageResult FromMemory(byte[] data, ColorComponents requiredComponents = ColorComponents.Default)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                return FromStream(stream, requiredComponents);
            }
        }
    }
}