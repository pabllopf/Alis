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
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Data.Dll
{
    /// <summary>
    ///     The embedded dll class
    /// </summary>
    public static class EmbeddedDllClass
    {
        /// <summary>
        ///     Extracts the embedded dlls using the specified dll name
        /// </summary>
        /// <param name="dllName">The dll name</param>
        /// <param name="dllType"></param>
        /// <param name="dllBytes">The dll bytes</param>
        /// <param name="assembly">The assembly</param>
        [ExcludeFromCodeCoverage]
        public static void ExtractEmbeddedDlls(string dllName, DllType dllType, Dictionary<PlatformInfo, string> dllBytes, Assembly assembly)
        {
            string extension = GetDllExtension(dllType);
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dllPath = Path.Combine(currentDirectory);
            
            if (!File.Exists(dllPath + "/" + dllName + extension))
            {
                OSPlatform currentPlatform = GetCurrentPlatform();
                Architecture currentArchitecture = RuntimeInformation.ProcessArchitecture;
                
                PlatformInfo platformInfo = new PlatformInfo(currentPlatform, currentArchitecture);
                
                if (dllBytes.TryGetValue(platformInfo, out string resourceName))
                {
                    ExtractZipFile(dllPath, LoadResource(resourceName, assembly));
                }
            }
        }
        
        /// <summary>
        ///     Gets the dll extension
        /// </summary>
        /// <param name="dllType"></param>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        /// <returns>The string</returns>
        internal static string GetDllExtension(DllType dllType)
        {
            OSPlatform currentPlatform = GetCurrentPlatform();
            
            if (dllType == DllType.Exe)
            {
                return GetExeExtension(currentPlatform);
            }
            
            if (dllType == DllType.Lib)
            {
                return GetLibExtension(currentPlatform);
            }
            
            throw new PlatformNotSupportedException("Unsupported platform.");
        }
        
        /// <summary>
        ///     Gets the exe extension using the specified current platform
        /// </summary>
        /// <param name="currentPlatform">The current platform</param>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        /// <returns>The string</returns>
        internal static string GetExeExtension(OSPlatform currentPlatform)
        {
            if (currentPlatform == OSPlatform.Windows)
            {
                return ".exe";
            }
            
            if (currentPlatform == OSPlatform.OSX || currentPlatform == OSPlatform.Create("IOS"))
            {
                return "";
            }
            
            if (currentPlatform == OSPlatform.Linux || currentPlatform == OSPlatform.Create("Android"))
            {
                return "";
            }
            
            throw new PlatformNotSupportedException("Unsupported platform.");
        }
        
        /// <summary>
        ///     Gets the lib extension using the specified current platform
        /// </summary>
        /// <param name="currentPlatform">The current platform</param>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        /// <returns>The string</returns>
        internal static string GetLibExtension(OSPlatform currentPlatform)
        {
            if (currentPlatform == OSPlatform.Windows)
            {
                return ".dll";
            }
            
            if (currentPlatform == OSPlatform.OSX || currentPlatform == OSPlatform.Create("IOS"))
            {
                return ".dylib";
            }
            
            if (currentPlatform == OSPlatform.Linux || currentPlatform == OSPlatform.Create("Android"))
            {
                return ".so";
            }
            
            throw new PlatformNotSupportedException("Unsupported platform.");
        }
        
        /// <summary>
        ///     Gets the platform
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        /// <returns>The os platform</returns>
        [ExcludeFromCodeCoverage]
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
        ///     Extracts the zip file using the specified file dir
        /// </summary>
        /// <param name="fileDir">The file dir</param>
        /// <param name="zipData">The zip data</param>
        internal static void ExtractZipFile(string fileDir, MemoryStream zipData)
        {
            using MemoryStream ms = zipData;
            using ZipArchive archive = new ZipArchive(ms);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (IsValidEntry(entry))
                {
                    ExtractEntry(fileDir, entry);
                }
            }
        }
        
        /// <summary>
        /// Describes whether is valid entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>The bool</returns>
        internal static bool IsValidEntry(ZipArchiveEntry entry)
        {
            return !string.IsNullOrEmpty(entry.Name) && !entry.FullName.Contains("__MACOSX");
        }
        
        /// <summary>
        /// Extracts the entry using the specified file dir
        /// </summary>
        /// <param name="fileDir">The file dir</param>
        /// <param name="entry">The entry</param>
        [ExcludeFromCodeCoverage]
        internal static void ExtractEntry(string fileDir, ZipArchiveEntry entry)
        {
            string destinationPath = Path.Combine(fileDir, entry.FullName);
            string canonicalDestinationPath = Path.GetFullPath(destinationPath);
            
            if (canonicalDestinationPath.StartsWith(fileDir, StringComparison.Ordinal))
            {
                ExtractFileFromEntry(canonicalDestinationPath, entry);
            }
        }
        
        /// <summary>
        /// Extracts the file from entry using the specified canonical destination path
        /// </summary>
        /// <param name="canonicalDestinationPath">The canonical destination path</param>
        /// <param name="entry">The entry</param>
        [ExcludeFromCodeCoverage]
        internal static void ExtractFileFromEntry(string canonicalDestinationPath, ZipArchiveEntry entry)
        {
            using Stream entryStream = entry.Open();
            using FileStream fs = File.Create(canonicalDestinationPath);
            entryStream.CopyTo(fs);
            SetFileReadPermission(canonicalDestinationPath);
        }
        
        /// <summary>
        ///     Sets the file read permission using the specified file path
        /// </summary>
        /// <param name="filePath">The file path</param>
        internal static void SetFileReadPermission(string filePath)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found", filePath);
                }
                
                using Process process = new Process();
                process.StartInfo.FileName = "/bin/chmod";
                process.StartInfo.Arguments = $"+x {filePath}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
            }
        }
        
        /// <summary>
        ///     Loads the resource using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <param name="assembly">The assembly</param>
        /// <returns>The memory stream</returns>
        
        internal static MemoryStream LoadResource(string resourceName, Assembly assembly)
        {
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            MemoryStream memoryStream = new MemoryStream();
            stream?.CopyTo(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        
        /// <summary>
        ///     Describes whether is running oni os
        /// </summary>
        /// <returns>The bool</returns>
        internal static bool IsRunningOniOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && IsiOsSpecificConditionMet();
        
        /// <summary>
        ///     Describes whether is running on android
        /// </summary>
        /// <returns>The bool</returns>
        internal static bool IsRunningOnAndroid() => IsAndroidSpecificConditionMet();
        
        /// <summary>
        ///     Describes whether isi os specific condition met
        /// </summary>
        /// <returns>The bool</returns>
        internal static bool IsiOsSpecificConditionMet()
        {
            try
            {
                return Assembly.Load(new AssemblyName("Xamarin.iOS")) != null;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
        
        /// <summary>
        ///     Describes whether is android specific condition met
        /// </summary>
        /// <returns>The bool</returns>
        internal static bool IsAndroidSpecificConditionMet()
        {
            try
            {
                return Assembly.Load(new AssemblyName("Mono.Android")) != null;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }
}