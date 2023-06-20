// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlDlls.cs
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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Properties;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class SdlDlls
    {
        /// <summary>
        ///     The osx arm64 sdl2
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SdlDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeGraphic.win_x86_sdl2},
            {(OSPlatform.Windows, Architecture.X64), NativeGraphic.win_x64_sdl2},
            {(OSPlatform.Windows, Architecture.Arm), NativeGraphic.win_x86_sdl2},
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphic.win_x64_sdl2},

            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_sdl2},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_sdl2},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_sdl2},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_sdl2},

            {(OSPlatform.OSX, Architecture.X86), NativeGraphic.osx_x64_sdl2},
            {(OSPlatform.OSX, Architecture.X64), NativeGraphic.osx_x64_sdl2},
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphic.osx_arm64_sdl2},
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphic.osx_arm64_sdl2}
        };

        /// <summary>
        ///     The sdl2 image
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SdlImageDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeGraphic.win_x86_sdl2_image},
            {(OSPlatform.Windows, Architecture.X64), NativeGraphic.win_x64_sdl2_image},
            {(OSPlatform.Windows, Architecture.Arm), NativeGraphic.win_x86_sdl2_image},
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphic.win_x64_sdl2_image},

            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_sdl2_image},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_sdl2_image},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_sdl2_image},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_sdl2_image},

            {(OSPlatform.OSX, Architecture.X86), NativeGraphic.osx_x64_sdl2_image},
            {(OSPlatform.OSX, Architecture.X64), NativeGraphic.osx_x64_sdl2_image},
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphic.osx_arm64_sdl2_image},
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphic.osx_arm64_sdl2_image}
        };

        /// <summary>
        ///     The sdl2 ttf
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SdlTtfDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeGraphic.win_x86_sdl2_ttf},
            {(OSPlatform.Windows, Architecture.X64), NativeGraphic.win_x64_sdl2_ttf},
            {(OSPlatform.Windows, Architecture.Arm), NativeGraphic.win_x86_sdl2_ttf},
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphic.win_x64_sdl2_ttf},

            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_sdl2_ttf},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_sdl2_ttf},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_sdl2_ttf},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_sdl2_ttf},

            {(OSPlatform.OSX, Architecture.X86), NativeGraphic.osx_x64_sdl2_ttf},
            {(OSPlatform.OSX, Architecture.X64), NativeGraphic.osx_x64_sdl2_ttf},
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphic.osx_arm64_sdl2_ttf},
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphic.osx_arm64_sdl2_ttf}
        };
    }
}