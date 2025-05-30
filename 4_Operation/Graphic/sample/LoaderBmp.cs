// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoaderBmp.cs
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
using Alis.Core.Graphic.Stb;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    ///     The loader bmp class
    /// </summary>
    public class LoaderBmp
    {
        /// <summary>
        ///     Loads the image using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="nrChannels">The nr channels</param>
        /// <returns>The void</returns>
        public static IntPtr LoadImage(string filePath, ref int width, ref int height, ref int nrChannels)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StbImage.StbiContext stbiContext = new StbImage.StbiContext(stream);

                // Llamada al método con referencias en lugar de punteros
                return StbImage.Stbibmpload(stbiContext, out width, out height, out nrChannels, 0, out StbiResultInfo output);
            }
        }
    }
}