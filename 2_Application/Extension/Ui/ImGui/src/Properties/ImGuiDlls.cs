// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDlls.cs
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
using Alis.Core.Aspect.Base.Dll;

namespace Alis.Extension.Graphic.ImGui.Properties
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class ImGuiDlls
    {
        /// <summary>
        ///     The resource path
        /// </summary>
        private static readonly string ResourcePath = "Alis.Extension.ImGui.resources";

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
        ///     The arm
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> ImGuiDllBytes = new Dictionary<PlatformInfo, string>
        {
            {WinX86, $"{ResourcePath}.win_x86.win-x86_cimgui.zip"},
            {WinX64, $"{ResourcePath}.win_x64.win-x64_cimgui.zip"},
            {WinArm, $"{ResourcePath}.win_arm.win-arm_cimgui.zip"},
            {WinArm64, $"{ResourcePath}.win_arm64.win-arm64_cimgui.zip"},

            {LinuxX86, $"{ResourcePath}.linux_x86.linux-x86_cimgui.zip"},
            {LinuxX64, $"{ResourcePath}.linux_x64.linux-x64_cimgui.zip"},
            {LinuxArm, $"{ResourcePath}.linux_arm.linux-arm_cimgui.zip"},
            {LinuxArm64, $"{ResourcePath}.linux_arm64.linux-arm64_cimgui.zip"},

            {OsxX86, $"{ResourcePath}.osx_x86.osx-x86_cimgui.zip"},
            {OsxX64, $"{ResourcePath}.osx_x64.osx-x64_cimgui.zip"},
            {OsxArm64, $"{ResourcePath}.osx_arm64.osx-arm64_cimgui.zip"},
            {OsxArm, $"{ResourcePath}.osx_arm.osx-arm_cimgui.zip"}
        };
    }
}