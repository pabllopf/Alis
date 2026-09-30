// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OpenAlModuleInitializer.cs
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
using Alis.Core.Audio.Players;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Registers a global DllImport resolver so the "openal32" native library used by
    ///     <see cref="OpenAl" /> resolves to the OpenAL implementation available on the
    ///     current platform. This makes the OpenAL tests deterministic on every OS.
    /// </summary>
    internal static class OpenAlModuleInitializer
    {
        /// <summary>
        ///     Registers the resolver when the test assembly is loaded.
        /// </summary>
        [ModuleInitializer]
        internal static void Initialize()
        {
            NativeLibrary.SetDllImportResolver(typeof(BrowserPlayer).Assembly, ResolveOpenAlLibrary);
        }

        /// <summary>
        ///     Resolves the "openal32" library name to a platform OpenAL implementation.
        /// </summary>
        /// <param name="libraryName">The library name requested by the DllImport.</param>
        /// <param name="assembly">The assembly requesting the library.</param>
        /// <param name="searchPath">The DllImport search path, if any.</param>
        /// <returns>The native library handle, or IntPtr.Zero when OpenAL is unavailable.</returns>
        private static IntPtr ResolveOpenAlLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName != "openal32")
            {
                return IntPtr.Zero;
            }

            if (NativeLibrary.TryLoad("/System/Library/Frameworks/OpenAL.framework/OpenAL", out IntPtr frameworkHandle))
            {
                return frameworkHandle;
            }

            string[] searchDirs =
            {
                "/opt/homebrew/opt/openal-soft/lib",
                "/opt/homebrew/lib",
                "/usr/local/lib",
                "/usr/lib"
            };

            string[] candidates = { "libopenal.1.dylib", "libopenal.dylib", "libopenal.so.1", "libopenal.so" };

            foreach (string dir in searchDirs)
            {
                foreach (string candidate in candidates)
                {
                    string path = Path.Combine(dir, candidate);
                    if (File.Exists(path) && NativeLibrary.TryLoad(path, out IntPtr handle))
                    {
                        return handle;
                    }
                }
            }

            return IntPtr.Zero;
        }
    }
}