// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   OpenALLibraryNameContainer.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Audio
{
    /// <summary>
    ///     Contains the library name of OpenAL.
    /// </summary>
    public class OpenALLibraryNameContainer
    {
        /// <summary>
        ///     Gets the library name to use on Windows.
        /// </summary>
        public string Windows => "openal32.dll";

        /// <summary>
        ///     Gets the library name to use on Linux.
        /// </summary>
        public string Linux => "libopenal.so.1";

        /// <summary>
        ///     Gets the library name to use on MacOS.
        /// </summary>
        public string MacOS => "/System/Library/Frameworks/OpenAL.framework/OpenAL";

        /// <summary>
        ///     Gets the library name to use on Android.
        /// </summary>
        public string Android => Linux;

        /// <summary>
        ///     Gets the library name to use on iOS.
        /// </summary>
        public string IOS => MacOS;

        /// <summary>
        ///     Gets the library name
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///     The library name couldn't be resolved for the given platform
        ///     ('{RuntimeInformation.OSDescription}').
        /// </exception>
        /// <returns>The string</returns>
        public string GetLibraryName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID")))
                {
                    return Android;
                }

                return Linux;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS")))
                {
                    return IOS;
                }

                return MacOS;
            }

            throw new NotSupportedException(
                $"The library name couldn't be resolved for the given platform ('{RuntimeInformation.OSDescription}').");
        }
    }
}