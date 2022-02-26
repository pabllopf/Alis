// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ALLoader.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Alis.Core.Audio.Native
{
    /// <summary>
    ///     Provides a base for ApiContext so that it can register dll intercepts.
    /// </summary>
    internal static class ALLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ALLoader"/> class
        /// </summary>
        static ALLoader()
        {
            RegisterDllResolver();
        }

        /// <summary>
        /// The open al library name container
        /// </summary>
        private static readonly OpenALLibraryNameContainer ALLibraryNameContainer = new OpenALLibraryNameContainer();

        /// <summary>
        /// The registered resolver
        /// </summary>
        private static bool RegisteredResolver;

        /// <summary>
        /// Registers the dll resolver
        /// </summary>
        internal static void RegisterDllResolver()
        {
            if (RegisteredResolver == false)
            {
                NativeLibrary.SetDllImportResolver(typeof(ALLoader).Assembly, ImportResolver);
                RegisteredResolver = true;
            }
        }

        /// <summary>
        /// Imports the resolver using the specified library name
        /// </summary>
        /// <param name="libraryName">The library name</param>
        /// <param name="assembly">The assembly</param>
        /// <param name="searchPath">The search path</param>
        /// <exception cref="DllNotFoundException">Could not load the dll '{libName}' (this load is intercepted, specified in DllImport as '{libraryName}').</exception>
        /// <returns>The int ptr</returns>
        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName == AL.AL.Lib || libraryName == ALC.ALC.Lib)
            {
                string libName = ALLibraryNameContainer.GetLibraryName();

                if (NativeLibrary.TryLoad(libName, assembly, searchPath, out IntPtr libHandle) == false)
                {
                    throw new DllNotFoundException(
                        $"Could not load the dll '{libName}' (this load is intercepted, specified in DllImport as '{libraryName}').");
                }

                return libHandle;
            }

            return NativeLibrary.Load(libraryName, assembly, searchPath);
        }
    }
}