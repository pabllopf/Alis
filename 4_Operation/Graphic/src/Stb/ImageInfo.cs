// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageInfo.cs
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

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The image info
    /// </summary>
    public
        struct ImageInfo
    {
        /// <summary>
        ///     The width
        /// </summary>
        public int Width;

        /// <summary>
        ///     The height
        /// </summary>
        public int Height;

        /// <summary>
        ///     The color components
        /// </summary>
        public ColorComponents ColorComponents;

        /// <summary>
        ///     The bits per channel
        /// </summary>
        public int BitsPerChannel;


        /// <summary>
        ///     Creates the stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The image info</returns>
        public static ImageInfo? FromStream(Stream stream)
        {
            int width = 0, height = 0, comp = 0;
            StbImage.StbiContext context = new StbImage.StbiContext(stream);
        
            bool is16Bit = StbImage.Stbiis16Main(context) == 1;
            StbImage.Stbirewind(context);
        
            int infoResult = StbImage.Stbiinfomain(context, out width, out height, out comp);
            StbImage.Stbirewind(context);
        
            if (infoResult == 0)
            {
                return null;
            }
        
            return new ImageInfo
            {
                Width = width,
                Height = height,
                ColorComponents = (ColorComponents)comp,
                BitsPerChannel = is16Bit ? 16 : 8
            };
        }
    }
}