// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlDlls.cs
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

namespace Alis.Core.Graphic.SFML
{
    /// <summary>
    ///     The sfml dlls class
    /// </summary>
    public static class SfmlDlls
    {
        /// <summary>
        ///     The osx arm64 sdl2
        /// </summary>
        public static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SfmlWindowDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeGraphic.win_x86_csfml_window},
            {(OSPlatform.Windows, Architecture.X64), NativeGraphic.win_x64_csfml_window},
            {(OSPlatform.Windows, Architecture.Arm), NativeGraphic.win_x86_csfml_window},
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphic.win_x64_csfml_window},

            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_csfml_window},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_csfml_window},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_csfml_window},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_csfml_window},

            {(OSPlatform.OSX, Architecture.X86), NativeGraphic.osx_x64_csfml_window},
            {(OSPlatform.OSX, Architecture.X64), NativeGraphic.osx_x64_csfml_window},
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphic.osx_arm64_csfml_window},
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphic.osx_arm64_csfml_window}
        };

        /// <summary>
        ///     The osx arm64 csfml system
        /// </summary>
        public static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SfmlSystemDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeGraphic.win_x86_csfml_system},
            {(OSPlatform.Windows, Architecture.X64), NativeGraphic.win_x64_csfml_system},
            {(OSPlatform.Windows, Architecture.Arm), NativeGraphic.win_x86_csfml_system},
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphic.win_x64_csfml_system},

            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_csfml_system},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_csfml_system},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_csfml_system},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_csfml_system},

            {(OSPlatform.OSX, Architecture.X86), NativeGraphic.osx_x64_csfml_system},
            {(OSPlatform.OSX, Architecture.X64), NativeGraphic.osx_x64_csfml_system},
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphic.osx_arm64_csfml_system},
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphic.osx_arm64_csfml_system}
        };

        /// <summary>
        ///     The osx arm64 csfml graphics
        /// </summary>
        public static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SfmlGraphicsDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            {(OSPlatform.Windows, Architecture.X86), NativeGraphic.win_x86_csfml_graphics},
            {(OSPlatform.Windows, Architecture.X64), NativeGraphic.win_x64_csfml_graphics},
            {(OSPlatform.Windows, Architecture.Arm), NativeGraphic.win_x86_csfml_graphics},
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphic.win_x64_csfml_graphics},

            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_csfml_graphics},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_csfml_graphics},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_csfml_graphics},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_csfml_graphics},

            {(OSPlatform.OSX, Architecture.X86), NativeGraphic.osx_x64_csfml_graphics},
            {(OSPlatform.OSX, Architecture.X64), NativeGraphic.osx_x64_csfml_graphics},
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphic.osx_arm64_csfml_graphics},
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphic.osx_arm64_csfml_graphics}
        };
    }
}