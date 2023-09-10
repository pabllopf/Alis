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



#if WIN
    #if X86
                                                 
    #endif
    #if X64
        using Alis.Core.Graphic.Properties.win.x64;              
    #endif
    #if ARM
                                               
    #endif
    #if ARM64
using Alis.Core.Graphic.Properties.win.arm64;                               
    #endif
#endif

#if OSX
    #if X86
                                                     
    #endif
    #if X64
            using Alis.Core.Graphic.Properties.osx.x64;                    
    #endif
    #if ARM
                                                   
    #endif
    #if ARM64
              using Alis.Core.Graphic.Properties.osx.arm64;                                     
    #endif
#endif


#if LINUX
    #if X86
        using Alis.Core.Graphic.Properties.linux.x86;
    #endif
    #if X64
        using Alis.Core.Graphic.Properties.linux.x64;              
    #endif
    #if ARM
        using Alis.Core.Graphic.Properties.linux.arm;                                       
    #endif
    #if ARM64
        using Alis.Core.Graphic.Properties.linux.arm64;                             
    #endif
#endif



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
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SfmlWindowDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            #if WIN
                #if X86
                         {(OSPlatform.Windows, Architecture.X86), NativeGraphicWindowsX64SFML.win_x86_csfml_window},                                    
                #endif
                #if X64
            {(OSPlatform.Windows, Architecture.X64), NativeGraphicWindowsX64SFML.win_x64_csfml_window},        
                #endif
                #if ARM
                             {(OSPlatform.Windows, Architecture.Arm), NativeGraphicWindowsX64SFML.win_x86_csfml_window},                              
                #endif
                #if ARM64
                      {(OSPlatform.Windows, Architecture.Arm64), NativeGraphicWindowsX64SFML.win_x64_csfml_window},                                      
                #endif
            #endif

            
#if LINUX
#if X86
             {(OSPlatform.Linux, Architecture.X86), NativeGraphicLinuxX86SFML.linux_x86_csfml_window},                                        
#endif
#if X64
            {(OSPlatform.Linux, Architecture.X64), NativeGraphicLinuxX64SFML.linux_x64_csfml_window},             
#endif
#if ARM
         {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_csfml_window},                                          
#endif
#if ARM64
          {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_csfml_window},                                  
#endif
#endif
#if OSX
#if X86
             {(OSPlatform.OSX, Architecture.X86), NativeGraphicOsxARM64.osx_x64_csfml_window},
#endif
#if X64
            {(OSPlatform.OSX, Architecture.X64), NativeGraphicOsxX64SFML.osx_x64_csfml_window},
#endif
#if ARM
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphicOsxARM64.osx_arm64_csfml_window},
#endif
#if ARM64
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphicOsxARM64SFML.osx_arm64_csfml_window}
#endif
#endif
        };

        /// <summary>
        ///     The osx arm64 csfml system
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SfmlSystemDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            #if WIN
                #if X86
                           {(OSPlatform.Windows, Architecture.X86), NativeGraphicWindowsX64SFML.win_x86_csfml_system},                                   
                #endif
                #if X64
            {(OSPlatform.Windows, Architecture.X64), NativeGraphicWindowsX64SFML.win_x64_csfml_system},            
                #endif
                #if ARM
                                     {(OSPlatform.Windows, Architecture.Arm), NativeGraphicWindowsX64SFML.win_x86_csfml_system},                      
                #endif
                #if ARM64
                         {(OSPlatform.Windows, Architecture.Arm64), NativeGraphicWindowsX64SFML.win_x64_csfml_system},                              
                #endif

            #endif

#if LINUX
#if X86
        {(OSPlatform.Linux, Architecture.X86), NativeGraphicLinuxX86SFML.linux_x86_csfml_system},
#endif
#if X64
            {(OSPlatform.Linux, Architecture.X64), NativeGraphicLinuxX64SFML.linux_x64_csfml_system},     
#endif
#if ARM
         {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_csfml_system},                
#endif
#if ARM64
       {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_csfml_system},                         
#endif
#endif
            
            
           
            

            
#if OSX
#if X86
            {(OSPlatform.OSX, Architecture.X86), NativeGraphicOsxARM64.osx_x64_csfml_system},
#endif
#if X64
            {(OSPlatform.OSX, Architecture.X64), NativeGraphicOsxX64SFML.osx_x64_csfml_system},
#endif
#if ARM
            {(OSPlatform.OSX, Architecture.Arm), NativeGraphicOsxARM64.osx_arm64_csfml_system},
#endif
#if ARM64
            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphicOsxARM64SFML.osx_arm64_csfml_system}
#endif
#endif
        };

        /// <summary>
        ///     The osx arm64 csfml graphics
        /// </summary>
        internal static readonly Dictionary<(OSPlatform Platform, Architecture Arch), byte[]> SfmlGraphicsDllBytes = new Dictionary<(OSPlatform Platform, Architecture Arch), byte[]>
        {
            #if WIN
                #if X86
                            {(OSPlatform.Windows, Architecture.X86), NativeGraphicWindowsX64SFML.win_x86_csfml_graphics},                  
                #endif
                #if X64
                            {(OSPlatform.Windows, Architecture.X64), NativeGraphicWindowsX64SFML.win_x64_csfml_graphics},
                #endif
                #if ARM
                            {(OSPlatform.Windows, Architecture.Arm), NativeGraphicWindowsX64SFML.win_x86_csfml_graphics},           
                #endif
                #if ARM64
                            {(OSPlatform.Windows, Architecture.Arm64), NativeGraphicWindowsX64SFML.win_x64_csfml_graphics},            
                #endif
    
            #endif
#if LINUX
#if X86
        {(OSPlatform.Linux, Architecture.X86), NativeGraphicLinuxX86SFML.linux_x86_csfml_graphics},
#endif
#if X64
            {(OSPlatform.Linux, Architecture.X64), NativeGraphicLinuxX64SFML.linux_x64_csfml_graphics},      
#endif
#if ARM
         {(OSPlatform.Linux, Architecture.Arm), NativeGraphic.linux_arm64_csfml_graphics},                                      
#endif
#if ARM64
        {(OSPlatform.Linux, Architecture.Arm64), NativeGraphic.linux_arm64_csfml_graphics},                     
#endif
#endif
            #if OSX
                #if X86
                             {(OSPlatform.OSX, Architecture.X86), NativeGraphicOsxARM64.osx_x64_csfml_graphics},
                #endif
                #if X64
                            {(OSPlatform.OSX, Architecture.X64), NativeGraphicOsxX64SFML.osx_x64_csfml_graphics},
                #endif
                #if ARM
                            {(OSPlatform.OSX, Architecture.Arm), NativeGraphicOsxARM64.osx_arm64_csfml_graphics},
                #endif
                #if ARM64
                            {(OSPlatform.OSX, Architecture.Arm64), NativeGraphicOsxARM64SFML.osx_arm64_csfml_graphics}
                #endif
            #endif
        };
    }
}