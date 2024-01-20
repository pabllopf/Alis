// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Image.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Graphic.Sdl2;

namespace Alis.Core.Graphic
{
    /// <summary>
    ///     The image class
    /// </summary>
    public class Image
    {
        /// <summary>
        ///     The path
        /// </summary>
        private readonly string path;

        /// <summary>
        ///     The is loaded
        /// </summary>
        private bool isLoaded;

        /// <summary>
        ///     The native pointer
        /// </summary>
        private IntPtr nativePointer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Image" /> class
        /// </summary>
        /// <param name="path">The path</param>
        public Image(string path)
        {
            this.path = path;
            isLoaded = false;
        }

        /// <summary>
        ///     Loads this instance
        /// </summary>
        /// <exception cref="FileNotFoundException">The image file does not exist</exception>
        private void Load()
        {
            if (isLoaded)
            {
                return;
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The image file does not exist");
            }

            nativePointer = Sdl.LoadBmp("Assets/tile000.bmp");
            isLoaded = true;
        }

        /// <summary>
        ///     Gets the native pointer
        /// </summary>
        /// <returns>The native pointer</returns>
        public IntPtr GetNativePointer()
        {
            if (!isLoaded)
            {
                Load();
            }

            return nativePointer;
        }
        
    }
}