// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2NativeDllResolver.cs
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

using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Resolves the SDL2 native dependencies by explicit path on macOS, where bare-name dlopen
    ///     does not probe the application directory. Registered once per test-host via the module
    ///     initializer so the src assembly's DllImports bind to a loadable dylib.
    /// </summary>
    internal static class Sdl2NativeDllResolver
    {
        /// <summary>
        ///     The homebrew cellar library prefix
        /// </summary>
        private static readonly string CellarPrefix = "/opt/homebrew/lib/lib";

        /// <summary>
        ///     Registers the native library resolver for the Sdl2 src assembly.
        /// </summary>
        [ModuleInitializer]
        internal static void Initialize()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                NativeLibrary.SetDllImportResolver(typeof(SdlImage).Assembly, ResolveNativeLibrary);
            }
        }

        /// <summary>
        ///     Resolves the library name to a loadable dylib, preferring the redistributed copy in the
        ///     test output directory and falling back to the Homebrew cellar prefix.
        /// </summary>
        private static IntPtr ResolveNativeLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            foreach (string fileName in new[] { "lib" + libraryName + ".dylib", libraryName + ".dylib" })
            {
                string candidate = Path.Combine(AppContext.BaseDirectory, fileName);
                if (File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out IntPtr handle))
                {
                    return handle;
                }
            }

            string cellar = CellarPrefix + libraryName + ".dylib";
            if (File.Exists(cellar) && NativeLibrary.TryLoad(cellar, out IntPtr cellarHandle))
            {
                return cellarHandle;
            }

            return IntPtr.Zero;
        }
    }
}