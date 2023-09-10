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
using Alis.Core.Audio.Properties.win.x86;
#endif
#if X64
using Alis.Core.Audio.Properties.win.x64;
#endif
#if ARM
           using Alis.Core.Audio.Properties.win.arm;
#endif
#if ARM64
using Alis.Core.Audio.Properties.win.arm64;
#endif
#endif

#if OSX
#if X86
          
#endif
#if X64
using Alis.Core.Audio.Properties.osx.x64;    
#endif
#if ARM
          
#endif
#if ARM64
using Alis.Core.Audio.Properties.osx.arm64;
#endif
#endif

#if LINUX
    #if X86
using Alis.Core.Audio.Properties.linux.x86; 
    #endif
    #if X64
using Alis.Core.Audio.Properties.linux.x64;
    #endif
    #if ARM
              using Alis.Core.Audio.Properties.linux.arm;
    #endif
    #if ARM64
using Alis.Core.Audio.Properties.linux.arm64;
    #endif
#endif



namespace Alis.Core.Audio
{
    /// <summary>
    ///     The audio dlls class
    /// </summary>
    public static class AudioDlls
    {
        /// <summary>
        ///     The osx x64 csfml audio
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> CsfmlAudioDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
#if WIN
#if X86
          {(OSPlatform.Windows, Architecture.X86), NativeAudioWindowsX86SFML.win_x86_csfml_audio},
#endif
#if X64
            {(OSPlatform.Windows, Architecture.X64), NativeAudioWindowsX64SFML.win_x64_csfml_audio},
#endif
#if ARM
           {(OSPlatform.Windows, Architecture.Arm), NativeAudioWindowsARMSFML.win_arm_csfml_audio},
#endif
#if ARM64
            {(OSPlatform.Windows, Architecture.Arm64), NativeAudioWindowsARM64SFML.win_arm64_csfml_audio},
#endif
#endif
#if LINUX
#if X86
            {(OSPlatform.Linux, Architecture.X86), NativeAudioLinuxX86SFML.linux_x86_csfml_audio}, 
#endif
#if X64
            {(OSPlatform.Linux, Architecture.X64), NativeAudioLinuxX64SFML.linux_x64_csfml_audio},
#endif
#if ARM
            {(OSPlatform.Linux, Architecture.Arm), NativeAudioLinuxARMSFML.linux_arm_csfml_audio},  
#endif
#if ARM64
            {(OSPlatform.Linux, Architecture.Arm64), NativeAudioLinuxARM64SFML.linux_arm64_csfml_audio},
#endif
#endif
            
            
            
          

#if OSX
#if X86
          {(OSPlatform.OSX, Architecture.X86), NativeAudioOsxARM64.osx_x64_csfml_audio},
#endif
#if X64
           {(OSPlatform.OSX, Architecture.X64), NativeAudioOsxX64SFML.osx_x64_csfml_audio},
#endif
#if ARM
           {(OSPlatform.OSX, Architecture.Arm), NativeAudioOsxARM64.osx_arm64_csfml_audio},
#endif
#if ARM64
            {(OSPlatform.OSX, Architecture.Arm64), NativeAudioOsxARM64SFML.osx_arm64_csfml_audio}
#endif
#endif
        };
        
        /// <summary>
        /// The arch
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>  CsfmlSystemDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
        #if WIN
                        #if X86
                                   {(OSPlatform.Windows, Architecture.X86), NativeAudioWindowsX86SFML.win_x86_csfml_system},                                   
                        #endif
                        #if X64
                                {(OSPlatform.Windows, Architecture.X64), NativeAudioWindowsX64SFML.win_x64_csfml_system},            
                        #endif
                        #if ARM
                                             {(OSPlatform.Windows, Architecture.Arm), NativeAudioWindowsARMSFML.win_arm_csfml_system},                      
                        #endif
                        #if ARM64
                                 {(OSPlatform.Windows, Architecture.Arm64), NativeAudioWindowsARM64SFML.win_arm64_csfml_system},                              
                        #endif

        #endif

#if LINUX
#if X86
           {(OSPlatform.Linux, Architecture.X86), NativeAudioLinuxX86SFML.linux_x86_csfml_system},    
#endif
#if X64
            {(OSPlatform.Linux, Architecture.X64), NativeAudioLinuxX64SFML.linux_x64_csfml_system},
#endif
#if ARM
         {(OSPlatform.Linux, Architecture.Arm), NativeAudioLinuxARMSFML.linux_arm_csfml_system},     
#endif
#if ARM64
        {(OSPlatform.Linux, Architecture.Arm64), NativeAudioLinuxARM64SFML.linux_arm64_csfml_system},
#endif
#endif
            
        #if OSX
        #if X86
                    {(OSPlatform.OSX, Architecture.X86), NativeGraphicOsxARM64.osx_x64_csfml_system},
        #endif
        #if X64
                    {(OSPlatform.OSX, Architecture.X64), NativeAudioOsxX64SFML.osx_x64_csfml_system},
        #endif
        #if ARM
                    {(OSPlatform.OSX, Architecture.Arm), NativeGraphicOsxARM64.osx_arm64_csfml_system},
        #endif
        #if ARM64
                    {(OSPlatform.OSX, Architecture.Arm64), NativeAudioOsxARM64SFML.osx_arm64_csfml_system}
        #endif
        #endif
                };
    }
}