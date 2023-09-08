// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioDlls.cs
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
#if X86
         
#endif
#if X64
using Alis.Core.Graphic.Properties.win.x64;
#endif
#if ARM
           
#endif
#if ARM64
using Alis.Core.Audio.Properties;
using Alis.Core.Graphic.Properties.win.arm64;
#endif
#endif

#if OSX
#if X86
          
#endif
#if X64
           
#endif
#if ARM
          
#endif
#if ARM64
using Alis.App.Engine.Properties.osx.arm64;
#endif
#endif



namespace Alis.Core.Audio
{
    /// <summary>
    ///     The audio dlls class
    /// </summary>
    public static class AudioSDLDlls
    {
       
        /// <summary>
        ///     The osx arm64 sdl2 mixer
        /// </summary>
        public static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SdlAudioDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
#if WIN
#if X86
          {(OSPlatform.Windows, Architecture.X86), NativeAudioWindowsX64SFML.win_x86_sdl2_mixer},
#endif
#if X64
            {(OSPlatform.Windows, Architecture.X64), NativeGraphicWindowsX64.win_x64_sdl2_mixer},
#endif
#if ARM
         {(OSPlatform.Windows, Architecture.Arm), NativeAudioWindowsX64SFML.win_x86_sdl2_mixer},
#endif
#if ARM64
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphicWindowsARM64.win_arm64_sdl2_mixer},
#endif
#endif

#if LINUX
            {(OSPlatform.Linux, Architecture.X86), NativeAudio.linux_x86_sdl2_mixer},
            {(OSPlatform.Linux, Architecture.X64), NativeAudio.linux_x64_sdl2_mixer},
            {(OSPlatform.Linux, Architecture.Arm), NativeAudio.linux_arm64_sdl2_mixer},
            {(OSPlatform.Linux, Architecture.Arm64), NativeAudio.linux_arm64_sdl2_mixer},
#endif
#if OSX
#if X86
          {(OSPlatform.OSX, Architecture.X86), NativeAudioOsxARM64.osx_x64_sdl2_mixer},
#endif
#if X64
           {(OSPlatform.OSX, Architecture.X64), NativeAudioOsxARM64.osx_x64_sdl2_mixer},
#endif
#if ARM
           {(OSPlatform.OSX, Architecture.Arm), NativeAudioOsxARM64.osx_arm64_sdl2_mixer},
#endif
#if ARM64
#if AudioBackendSDL || AudioBackendAll
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphicOsxARM64.osx_arm64_sdl2_mixer}
#endif
#endif
#endif
        };

        /// <summary>
        ///     The win x64 openal32
        /// </summary>
        public static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> OpenalAudioDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
#if WIN
#if X86
           {(OSPlatform.Windows, Architecture.X86), NativeAudioWindowsX64SFML.win_x86_openal32},
#endif
#if X64
            {(OSPlatform.Windows, Architecture.X64), NativeGraphicWindowsX64.win_x64_openal32},
#endif
#if ARM
         {(OSPlatform.Windows, Architecture.Arm), NativeAudioWindowsX64SFML.win_x86_openal32},
#endif
#if ARM64
            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphicWindowsARM64.win_arm64_openal32}
#endif
#endif
        };
    }
}