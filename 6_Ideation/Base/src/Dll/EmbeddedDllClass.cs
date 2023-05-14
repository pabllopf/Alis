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

namespace Alis.Core.Aspect.Base.Dll
{
    /// <summary>
    ///     A class used by managed classes to managed unmanaged DLLs.
    ///     This will extract and load DLLs from embedded binary resources.
    ///     This can be used with pinvoke, as well as manually loading DLLs your own way. If you use pinvoke, you don't need to
    ///     load the DLLs, just
    ///     extract them. When the DLLs are extracted, the %PATH% environment variable is updated to point to the temporary
    ///     folder.
    ///     To Use
    ///     <list type="">
    ///         <item>
    ///             Add all of the DLLs as binary file resources to the project Propeties. Double click
    ///             Properties/Resources.resx,
    ///             Add Resource, Add Existing File. The resource name will be similar but not exactly the same as the DLL file
    ///             name.
    ///         </item>
    ///         <item>
    ///             In a static constructor of your application, call EmbeddedDllClass.ExtractEmbeddedDlls() for each DLL
    ///             that is needed
    ///         </item>
    ///         <example>
    ///             EmbeddedDllClass.ExtractEmbeddedDlls("libFrontPanel-pinv.dll", Properties.Resources.libFrontPanel_pinv);
    ///         </example>
    ///         <item>
    ///             Optional: In a static constructor of your application, call EmbeddedDllClass.LoadDll() to load the DLLs
    ///             you have extracted. This is not necessary for pinvoke
    ///         </item>
    ///         <example>
    ///             EmbeddedDllClass.LoadDll("myscrewball.dll");
    ///         </example>
    ///         <item>Continue using standard Pinvoke methods for the desired functions in the DLL</item>
    ///     </list>
    /// </summary>
    public static class EmbeddedDllClass
    {
        /// <summary>
        /// Gets or sets the value of the current directory
        /// </summary>
        public static string CurrentDirectory { get; private set; } = "";

        /// <summary>
        ///     Extract DLLs from resources to temporary folder
        /// </summary>
        /// <param name="dllName">name of DLL file to create (including dll suffix)</param>
        /// <param name="resourceBytes">The resource name (fully qualified)</param>
        public static void ExtractEmbeddedDlls(string dllName, byte[] resourceBytes)
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            string[] names = assem.GetManifestResourceNames();
            AssemblyName an = assem.GetName();
            
            string dirTemp =  Path.Combine(Path.GetTempPath(), string.Format("{0}.{1}.{2}", an.Name, an.ProcessorArchitecture, an.Version));
            
            if(!Directory.Exists(dirTemp))
            {
                Directory.CreateDirectory(dirTemp);
            }

            if (CurrentDirectory == "")
            {
                CurrentDirectory = Environment.CurrentDirectory;
            }
            
            Directory.SetCurrentDirectory(dirTemp);
            
            string dllPath = Path.Combine(dirTemp, dllName);
            if (File.Exists(dllPath))
            {
                File.Delete(dllPath);
            }
            
            File.WriteAllBytes(dllPath, resourceBytes);
            
            Console.WriteLine($"dllPath={dllPath}");
        }
    }
}