// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Sdl2Dlls.cs
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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;

namespace Alis.Core.Graphic.Properties
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class Sdl2Dlls
    {
        /// <summary>
        ///     The osx arm64 sdl2
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> GlSdlDllBytes = new Dictionary<PlatformInfo, string>
        {
            {new PlatformInfo(OSPlatform.Windows, Architecture.X86), "Alis.Core.Graphic.resources.win_x86.win-x86_sdl2.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.X64), "Alis.Core.Graphic.resources.win_x64.win-x64_sdl2.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.Arm), "Alis.Core.Graphic.resources.win_arm.win-arm_sdl2.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.Arm64), "Alis.Core.Graphic.resources.win_arm64.win-arm64_sdl2.zip"},

            {new PlatformInfo(OSPlatform.Linux, Architecture.X86), "Alis.Core.Graphic.resources.linux_x86.linux-x86_sdl2.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.X64), "Alis.Core.Graphic.resources.linux_x64.linux-x64_sdl2.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.Arm), "Alis.Core.Graphic.resources.linux_arm.linux-arm_sdl2.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.Arm64), "Alis.Core.Graphic.resources.linux_arm64.linux-arm64_sdl2.zip"},

            {new PlatformInfo(OSPlatform.OSX, Architecture.X86), "Alis.Core.Graphic.resources.osx_x64.osx-x64_sdl2.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.X64), "Alis.Core.Graphic.resources.osx_x64.osx-x64_sdl2.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.Arm64), "Alis.Core.Graphic.resources.osx_arm64.osx-arm64_sdl2.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.Arm), "Alis.Core.Graphic.resources.osx_arm64.osx-arm64_sdl2.zip"}
        };

        /// <summary>
        ///     The sdl2 ttf
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> GlSdlTtfDllBytes = new Dictionary<PlatformInfo, string>
        {
            {new PlatformInfo(OSPlatform.Windows, Architecture.X86), "Alis.Core.Graphic.resources.win_x86.win-x86_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.X64), "Alis.Core.Graphic.resources.win_x64.win-x64_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.Arm), "Alis.Core.Graphic.resources.win_arm.win-arm_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.Arm64), "Alis.Core.Graphic.resources.win_arm64.win-arm64_sdl2_ttf.zip"},

            {new PlatformInfo(OSPlatform.Linux, Architecture.X86), "Alis.Core.Graphic.resources.linux_x86.linux-x86_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.X64), "Alis.Core.Graphic.resources.linux_x64.linux-x64_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.Arm), "Alis.Core.Graphic.resources.linux_arm.linux-arm_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.Arm64), "Alis.Core.Graphic.resources.linux_arm64.linux-arm64_sdl2_ttf.zip"},

            {new PlatformInfo(OSPlatform.OSX, Architecture.X86), "Alis.Core.Graphic.resources.osx_x64.osx-x64_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.X64), "Alis.Core.Graphic.resources.osx_x64.osx-x64_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.Arm64), "Alis.Core.Graphic.resources.osx_arm64.osx-arm64_sdl2_ttf.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.Arm), "Alis.Core.Graphic.resources.osx_arm64.osx-arm64_sdl2_ttf.zip"}
        };
    }
}