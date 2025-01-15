// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlatformDetector.cs
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

using System.Runtime.InteropServices;

namespace Alis.Extension.Plugin
{
    /// <summary>
    ///     The platform detector class
    /// </summary>
    /// <seealso cref="IPlatformDetector" />
    public class PlatformDetector : IPlatformDetector
    {
        /// <summary>
        ///     Describes whether this instance is windows
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        ///     Describes whether this instance is osx
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsOsx() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        ///     Describes whether this instance is linux
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        ///     Describes whether this instance isi os
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsiOs() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && (RuntimeInformation.OSDescription.Contains("iPhone") || RuntimeInformation.OSDescription.Contains("iPad"));

        /// <summary>
        ///     Describes whether this instance is android
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsAndroid() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && RuntimeInformation.OSDescription.Contains("Android");
    }
}