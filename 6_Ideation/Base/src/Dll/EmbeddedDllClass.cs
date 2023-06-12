// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmbeddedDllClass.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Base.Dll
{
    /// <summary>
    /// The embedded dll class
    /// </summary>
    public static class EmbeddedDllClass
    {
        /// <summary>
        ///     Gets or sets the value of the current directory
        /// </summary>
        public static string CurrentDirectory { get; private set; } = "";

        /// <summary>
        ///     Extract DLLs from resources to temporary folder
        /// </summary>
        /// <param name="dllName">name of DLL file to create (including dll suffix)</param>
        /// <param name="resourceBytes">The resource name (fully qualified)</param>
        public static void ExtractEmbeddedDlls(string dllName, byte[] resourceBytes)
        {
            /*
            string extension = String.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                extension = $".dll";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                extension = IsRunningOniOS() ? $".dylib" : ".dylib";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                extension = IsRunningOnAndroid() ? $".so" : ".so";
            }
            else
            {
                throw new NotSupportedException("Unsupported platform. Plugins will not be loaded.");
            }*/

            Assembly assem = Assembly.GetExecutingAssembly();
            string[] names = assem.GetManifestResourceNames();
            AssemblyName an = assem.GetName();

            //string dirTemp = Path.Combine(Path.GetTempPath(), $"{an.Name}_{an.ProcessorArchitecture}_{an.Version}");

            string dirTemp = Environment.CurrentDirectory;

            if (!Directory.Exists(dirTemp))
            {
                Directory.CreateDirectory(dirTemp);
            }

            if (CurrentDirectory == "")
            {
                CurrentDirectory = Environment.CurrentDirectory;
            }

            //Directory.SetCurrentDirectory(dirTemp);

            //string dllPath = Path.Combine(dirTemp, $"{dllName}{extension}");
            
            string dllPath = Path.Combine(dirTemp, $"{dllName}");

            if (!File.Exists(dllPath))
            {
                File.WriteAllBytes(dllPath, resourceBytes);
            }

            Console.WriteLine($"dllPath={dllPath}");
        }
        
        /// <summary>
        ///     Describes whether this instance is running oni os
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsRunningOniOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && (RuntimeInformation.OSDescription.Contains("iPhone") || RuntimeInformation.OSDescription.Contains("iPad"));


        /// <summary>
        ///     Describes whether this instance is running on android
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsRunningOnAndroid() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && RuntimeInformation.OSDescription.Contains("Android");

        
    }
}