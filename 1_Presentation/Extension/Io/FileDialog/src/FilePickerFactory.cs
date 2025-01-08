// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerFactory.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Dll;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Factory class for creating the right file picker implementation.
    /// </summary>
    public static class FilePickerFactory
    {
        /// <summary>
        ///     Creates the file picker
        /// </summary>
        /// <exception cref="NotSupportedException">This platform is not supported.</exception>
        /// <returns>The file picker</returns>
        public static IFilePicker CreateFilePicker()
        {
            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                return new MacFilePicker();
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                return new WindowsFilePicker();
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                return new LinuxFilePicker();
            }

            throw new NotSupportedException("This platform is not supported.");
        }
    }
}