// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FfMegDlls.cs
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

namespace Alis.Extension.FFMeg.Properties
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class FfMegDlls
    {
        /// <summary>
        ///     The resource path
        /// </summary>
        private const string ResourcePath = "Alis.Extension.FFMeg.resources";

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
        internal static readonly Dictionary<PlatformInfo, string> FfMegDllBytes = new Dictionary<PlatformInfo, string>
        {
            {WinX86, $"{ResourcePath}.win_x64.win-x64_ffmpeg.zip"},
            {WinX64, $"{ResourcePath}.win_x64.win-x64_ffmpeg.zip"},
            {WinArm, $"{ResourcePath}.win_x64.win-x64_ffmpeg.zip"},
            {WinArm64, $"{ResourcePath}.win_x64.win-x64_ffmpeg.zip"},

            {LinuxX86, $"{ResourcePath}.linux_x64.linux-x64_ffmpeg.zip"},
            {LinuxX64, $"{ResourcePath}.linux_x64.linux-x64_ffmpeg.zip"},
            {LinuxArm, $"{ResourcePath}.linux_x64.linux-x64_ffmpeg.zip"},
            {LinuxArm64, $"{ResourcePath}.linux_x64.linux-x64_ffmpeg.zip"},

            {OsxX86, $"{ResourcePath}.osx_x64.osx-x64_ffmpeg.zip"},
            {OsxX64, $"{ResourcePath}.osx_x64.osx-x64_ffmpeg.zip"},
            {OsxArm64, $"{ResourcePath}.osx_x64.osx-x64_ffmpeg.zip"},
            {OsxArm, $"{ResourcePath}.osx_x64.osx-x64_ffmpeg.zip"}
        };

        /// <summary>
        ///     The osx arm64 sdl2
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> FfplayDllBytes = new Dictionary<PlatformInfo, string>
        {
            {WinX86, $"{ResourcePath}.win_x64.win-x64_ffplay.zip"},
            {WinX64, $"{ResourcePath}.win_x64.win-x64_ffplay.zip"},
            {WinArm, $"{ResourcePath}.win_x64.win-x64_ffplay.zip"},
            {WinArm64, $"{ResourcePath}.win_x64.win-x64_ffplay.zip"},

            {LinuxX86, $"{ResourcePath}.linux_x64.linux-x64_ffplay.zip"},
            {LinuxX64, $"{ResourcePath}.linux_x64.linux-x64_ffplay.zip"},
            {LinuxArm, $"{ResourcePath}.linux_x64.linux-x64_ffplay.zip"},
            {LinuxArm64, $"{ResourcePath}.linux_x64.linux-x64_ffplay.zip"},

            {OsxX86, $"{ResourcePath}.osx_x64.osx-x64_ffplay.zip"},
            {OsxX64, $"{ResourcePath}.osx_x64.osx-x64_ffplay.zip"},
            {OsxArm64, $"{ResourcePath}.osx_x64.osx-x64_ffplay.zip"},
            {OsxArm, $"{ResourcePath}.osx_x64.osx-x64_ffplay.zip"}
        };

        /// <summary>
        ///     The resource path
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> FfprobeDllBytes = new Dictionary<PlatformInfo, string>
        {
            {WinX86, $"{ResourcePath}.win_x64.win-x64_ffprobe.zip"},
            {WinX64, $"{ResourcePath}.win_x64.win-x64_ffprobe.zip"},
            {WinArm, $"{ResourcePath}.win_x64.win-x64_ffprobe.zip"},
            {WinArm64, $"{ResourcePath}.win_x64.win-x64_ffprobe.zip"},

            {LinuxX86, $"{ResourcePath}.linux_x64.linux-x64_ffprobe.zip"},
            {LinuxX64, $"{ResourcePath}.linux_x64.linux-x64_ffprobe.zip"},
            {LinuxArm, $"{ResourcePath}.linux_x64.linux-x64_ffprobe.zip"},
            {LinuxArm64, $"{ResourcePath}.linux_x64.linux-x64_ffprobe.zip"},

            {OsxX86, $"{ResourcePath}.osx_x64.osx-x64_ffprobe.zip"},
            {OsxX64, $"{ResourcePath}.osx_x64.osx-x64_ffprobe.zip"},
            {OsxArm64, $"{ResourcePath}.osx_x64.osx-x64_ffprobe.zip"},
            {OsxArm, $"{ResourcePath}.osx_x64.osx-x64_ffprobe.zip"}
        };
    }
}