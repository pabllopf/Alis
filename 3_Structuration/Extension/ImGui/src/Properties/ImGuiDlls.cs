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

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class ImGuiDlls
    {
        /// <summary>
        ///     The arm
        /// </summary>
        internal static readonly Dictionary<PlatformInfo, string> PixelCImGuiDllBytes = new Dictionary<PlatformInfo, string>
        {
            {new PlatformInfo(OSPlatform.Windows, Architecture.X86), "Alis.App.Engine.resources.win_x86.win-x86_cimgui.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.X64), "Alis.App.Engine.resources.win_x64.win-x64_cimgui.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.Arm), "Alis.App.Engine.resources.win_arm.win-arm_cimgui.zip"},
            {new PlatformInfo(OSPlatform.Windows, Architecture.Arm64), "Alis.App.Engine.resources.win_arm64.win-arm64_cimgui.zip"},

            {new PlatformInfo(OSPlatform.Linux, Architecture.X86), "Alis.App.Engine.resources.linux_x86.linux-x86_cimgui.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.X64), "Alis.App.Engine.resources.linux_x64.linux-x64_cimgui.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.Arm), "Alis.App.Engine.resources.linux_arm.linux-arm_cimgui.zip"},
            {new PlatformInfo(OSPlatform.Linux, Architecture.Arm64), "Alis.App.Engine.resources.linux_arm64.linux-arm64_cimgui.zip"},

            {new PlatformInfo(OSPlatform.OSX, Architecture.X86), "Alis.App.Engine.resources.osx_arm64.osx-arm64_cimgui.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.X64), "Alis.App.Engine.resources.osx_arm64.osx-arm64_cimgui.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.Arm64), "Alis.App.Engine.resources.osx_arm64.osx-arm64_cimgui.zip"},
            {new PlatformInfo(OSPlatform.OSX, Architecture.Arm), "Alis.App.Engine.resources.osx_arm64.osx-arm64_cimgui.zip"}
        };
    }
}