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



#if WIN
    #if  X64
    using Alis.Core.Graphic.Properties.win.x64;
    #endif
    #if ARM64
using Alis.Core.Graphic.Properties;
    using Alis.Core.Graphic.Properties.win.arm64;
    #endif
    #if ARM
                 
    #endif
    #if X86
                 
    #endif
#endif

#if OSX
#if ARM64
using Alis.App.Engine.Properties.osx.arm64;
#endif
#if X64
using Alis.Core.Graphic.Properties.osx.x64;
#endif
    
#endif

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im gui dlls class
    /// </summary>
    public static class ImGuiDlls
    {
        /// <summary>
        ///     The osx arm64 cimgui
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> ImGuiDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
#if WIN
#if X64
            {(OSPlatform.Windows, Architecture.X64), NativeGraphicWindowsX64.win_x64_cimgui},
#endif
#if X86
            {(OSPlatform.Windows, Architecture.X86), NativeGraphicWindowsX64.win_x86_cimgui},
#endif
#if ARM
             {(OSPlatform.Windows, Architecture.Arm), NativeGraphicWindowsX64.win_x86_cimgui},
#endif
#if ARM64
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphicWindowsARM64.win_arm64_cimgui},
#endif
#endif
#if LINUX
            {(OSPlatform.Linux, Architecture.X86), NativeGraphic.linux_x86_cimgui},
            {(OSPlatform.Linux, Architecture.X64), NativeGraphic.linux_x64_cimgui},
            {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_cimgui},
            {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_cimgui},
#endif
#if OSX
#if X86
            {(OSPlatform.OSX, Architecture.X86), NativeGraphicOsxARM64.osx_x64_cimgui},
#endif
#if X64
            {(OSPlatform.OSX, Architecture.X64), NativeGraphicOsxX64.osx_x64_cimgui},
#endif
#if ARM
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphicOsxARM64.osx_arm64_cimgui},
#endif
#if ARM64
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphicOsxARM64.osx_arm64_cimgui}
#endif
            
            
            
            
#endif
        };
    }
}