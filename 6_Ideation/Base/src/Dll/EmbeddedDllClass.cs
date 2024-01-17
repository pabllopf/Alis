// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: EmbeddedDllClass.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Base.Dll
{
    /// <summary>
    ///     The embedded dll class
    /// </summary>
    public class EmbeddedDllClass : IEmbeddedDllClass
    {
        /// <summary>
        ///     Extracts the embedded dlls using the specified dll name
        /// </summary>
        /// <param name="dllName">The dll name</param>
        /// <param name="dllBytes">The dll bytes</param>
        /// <param name="assembly">The assembly</param>
        public void ExtractEmbeddedDlls(string dllName, Dictionary<(OSPlatform Platform, Architecture Arch), string> dllBytes, Assembly assembly)
        {
            string extension = GetDllExtension();
            
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string version = fvi.FileVersion.Replace(".","_");
            
            string dllPath = Path.Combine(Path.GetTempPath(), $"Alis_{version}");
            dllPath = Path.Combine(dllPath, $"{dllName}.{extension}");
            //string dllPath = Path.Combine(Path.GetTempPath(), $"{dllName}.{extension}");
            
            if (File.Exists(dllPath))
            {
                File.Delete(dllPath);
                Console.WriteLine($"Delete {dllPath}");
            }
            
            if (!File.Exists(dllPath))
            {
                OSPlatform currentPlatform = GetCurrentPlatform();
                Architecture currentArchitecture = RuntimeInformation.ProcessArchitecture;

                if (dllBytes.TryGetValue((currentPlatform, currentArchitecture), out string resourceName))
                {
                    ExtractZipFile(dllPath, $"{dllName}.{extension}", LoadResource(resourceName, assembly));
                    Console.WriteLine($"OSPlatform={currentPlatform} | Architecture={currentArchitecture} -> lib: {dllName} dir={dllPath}");
                }
            }
        }


        /// <summary>
        ///     Gets the dll extension
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        /// <returns>The string</returns>
        private static string GetDllExtension()
        {
            OSPlatform currentPlatform = GetCurrentPlatform();

            if (currentPlatform == OSPlatform.Windows)
            {
                return "dll";
            }

            if (currentPlatform == OSPlatform.OSX || currentPlatform == OSPlatform.Create("IOS"))
            {
                return "dylib";
            }

            if (currentPlatform == OSPlatform.Linux || currentPlatform == OSPlatform.Create("Android"))
            {
                return "so";
            }

            throw new PlatformNotSupportedException("Unsupported platform.");
        }

        /// <summary>
        ///     Gets the platform
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        /// <returns>The os platform</returns>
        public static OSPlatform GetCurrentPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }

            if (IsRunningOniOS())
            {
                return OSPlatform.Create("IOS");
            }

            if (IsRunningOnAndroid())
            {
                return OSPlatform.Create("Android");
            }

            throw new PlatformNotSupportedException("Unsupported platform.");
        }


        /// <summary>
        ///     Extracts the zip file using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <param name="fileName">The file name</param>
        /// <param name="zipData">The zip data</param>
        private static void ExtractZipFile(string filePath, string fileName, MemoryStream zipData)
        {
            using MemoryStream ms = zipData;
            using ZipArchive archive = new ZipArchive(ms);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (File.Exists(filePath))
                {
                    continue; // Skip if the file already exists
                }

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using Stream entryStream = entry.Open();
                using FileStream fs = File.Create(filePath);
                entryStream.CopyTo(fs);
            }
        }

        /// <summary>
        ///     Loads the resource using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <param name="assembly">The assembly</param>
        /// <returns>The memory stream</returns>
        private static MemoryStream LoadResource(string resourceName, Assembly assembly)
        {
            Console.WriteLine(@"Assembly where extract resource: " + assembly.FullName);
            string[] aResourceNames = assembly.GetManifestResourceNames();
            foreach (string aResourceName in aResourceNames)
            {
                if (aResourceName.Contains(resourceName))
                {
                    Console.WriteLine(@"Exits resource: " + aResourceName);
                }
            }

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            MemoryStream memoryStream = new MemoryStream();
            stream?.CopyTo(memoryStream);
            memoryStream.Position = 0;
            Console.WriteLine(@"Extract: " + resourceName);
            return memoryStream;
        }

        /// <summary>
        ///     Describes whether is running oni os
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsRunningOniOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && IsiOsSpecificConditionMet();

        /// <summary>
        ///     Describes whether is running on android
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsRunningOnAndroid() => IsAndroidSpecificConditionMet();

        /// <summary>
        ///     Describes whether isi os specific condition met
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsiOsSpecificConditionMet() => Assembly.Load("Xamarin.iOS") != null;

        /// <summary>
        ///     Describes whether is android specific condition met
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsAndroidSpecificConditionMet() => Assembly.Load("Xamarin.Android") != null;
    }
}