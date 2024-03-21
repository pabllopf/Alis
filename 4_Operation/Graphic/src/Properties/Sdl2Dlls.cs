// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2Dlls.cs
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
using Alis.Core.Aspect.Data.Dll;

namespace Alis.Core.Graphic.Properties
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class Sdl2Dlls
    {
        /// <summary>
        ///     The resource path
        /// </summary>
        private static readonly string ResourcePath = "Alis.Core.Graphic.resources";

        /// <summary>
        ///     The 86
        /// </summary>
        private static readonly PlatformInfo WinX86 = new PlatformInfo(OSPlatform.Windows, Architecture.X86);

        /// <summary>
        ///     The 64
        /// </summary>
        private static readonly PlatformInfo WinX64 = new PlatformInfo(OSPlatform.Windows, Architecture.X64);

        /// <summary>
        ///     The arm
        /// </summary>
        private static readonly PlatformInfo WinArm = new PlatformInfo(OSPlatform.Windows, Architecture.Arm);

        /// <summary>
        ///     The arm 64
        /// </summary>
        private static readonly PlatformInfo WinArm64 = new PlatformInfo(OSPlatform.Windows, Architecture.Arm64);

        /// <summary>
        ///     The 86
        /// </summary>
        private static readonly PlatformInfo LinuxX86 = new PlatformInfo(OSPlatform.Linux, Architecture.X86);

        /// <summary>
        ///     The 64
        /// </summary>
        private static readonly PlatformInfo LinuxX64 = new PlatformInfo(OSPlatform.Linux, Architecture.X64);

        /// <summary>
        ///     The arm
        /// </summary>
        private static readonly PlatformInfo LinuxArm = new PlatformInfo(OSPlatform.Linux, Architecture.Arm);

        /// <summary>
        ///     The arm 64
        /// </summary>
        private static readonly PlatformInfo LinuxArm64 = new PlatformInfo(OSPlatform.Linux, Architecture.Arm64);

        /// <summary>
        ///     The 86
        /// </summary>
        private static readonly PlatformInfo OsxX86 = new PlatformInfo(OSPlatform.OSX, Architecture.X86);

        /// <summary>
        ///     The 64
        /// </summary>
        private static readonly PlatformInfo OsxX64 = new PlatformInfo(OSPlatform.OSX, Architecture.X64);

        /// <summary>
        ///     The arm
        /// </summary>
        private static readonly PlatformInfo OsxArm = new PlatformInfo(OSPlatform.OSX, Architecture.Arm);

        /// <summary>
        ///     The arm 64
        /// </summary>
        private static readonly PlatformInfo OsxArm64 = new PlatformInfo(OSPlatform.OSX, Architecture.Arm64);

        /// <summary>
        ///     The osx arm64 sdl2
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> GlSdlDllBytes = new Dictionary<PlatformInfo, string>
        {
            {WinX86, $"{ResourcePath}.win_x86.win-x86_sdl2.zip"},
            {WinX64, $"{ResourcePath}.win_x64.win-x64_sdl2.zip"},
            {WinArm, $"{ResourcePath}.win_arm.win-arm_sdl2.zip"},
            {WinArm64, $"{ResourcePath}.win_arm64.win-arm64_sdl2.zip"},

            {LinuxX86, $"{ResourcePath}.linux_x86.linux-x86_sdl2.zip"},
            {LinuxX64, $"{ResourcePath}.linux_x64.linux-x64_sdl2.zip"},
            {LinuxArm, $"{ResourcePath}.linux_arm.linux-arm_sdl2.zip"},
            {LinuxArm64, $"{ResourcePath}.linux_arm64.linux-arm64_sdl2.zip"},

            {OsxX86, $"{ResourcePath}.osx_x86.osx-x86_sdl2.zip"},
            {OsxX64, $"{ResourcePath}.osx_x64.osx-x64_sdl2.zip"},
            {OsxArm64, $"{ResourcePath}.osx_arm64.osx-arm64_sdl2.zip"},
            {OsxArm, $"{ResourcePath}.osx_arm.osx-arm_sdl2.zip"}
        };

        /// <summary>
        ///     The sdl2 ttf
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> GlSdlTtfDllBytes = new Dictionary<PlatformInfo, string>
        {
            {WinX86, $"{ResourcePath}.win_x86.win-x86_sdl2_ttf.zip"},
            {WinX64, $"{ResourcePath}.win_x64.win-x64_sdl2_ttf.zip"},
            {WinArm64, $"{ResourcePath}.win_arm.win-arm_sdl2_ttf.zip"},
            {WinArm, $"{ResourcePath}.win_arm64.win-arm64_sdl2_ttf.zip"},

            {LinuxX86, $"{ResourcePath}.linux_x86.linux-x86_sdl2_ttf.zip"},
            {LinuxX64, $"{ResourcePath}.linux_x64.linux-x64_sdl2_ttf.zip"},
            {LinuxArm, $"{ResourcePath}.linux_arm.linux-arm_sdl2_ttf.zip"},
            {LinuxArm64, $"{ResourcePath}.linux_arm64.linux-arm64_sdl2_ttf.zip"},

            {OsxX86, $"{ResourcePath}.osx_x86.osx-x86_sdl2_ttf.zip"},
            {OsxX64, $"{ResourcePath}.osx_x64.osx-x64_sdl2_ttf.zip"},
            {OsxArm, $"{ResourcePath}.osx_arm.osx-arm_sdl2_ttf.zip"},
            {OsxArm64, $"{ResourcePath}.osx_arm64.osx-arm64_sdl2_ttf.zip"}
        };
    }
}