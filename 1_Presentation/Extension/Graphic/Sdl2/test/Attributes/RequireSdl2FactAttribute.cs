// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RequireSdl2FactAttribute.cs
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

using System.IO;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Attributes
{
    /// <summary>
    ///     The require sdl2 fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class RequireSdl2FactAttribute : FactAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RequireSdl2FactAttribute"/> class
        /// </summary>
        public RequireSdl2FactAttribute()
        {
            if (!TryLoadSdl2Library("sdl2"))
            {
                Skip = "Test skipped because its not platform";
            }
        }

        /// <summary>
        ///     Attempts to load the specified SDL2 library by name, falling back to
        ///     absolute path resolution from the test assembly output directory.
        /// </summary>
        private static bool TryLoadSdl2Library(string name)
        {
            if (NativeLibrary.TryLoad(name, out _))
                return true;

            string assemblyDir = Path.GetDirectoryName(typeof(RequireSdl2FactAttribute).Assembly.Location);
            if (assemblyDir == null)
                return false;

            string[] searchDirs = new[]
            {
                assemblyDir,
                "/opt/homebrew/lib",
                "/usr/local/lib",
                "/usr/lib",
                "/usr/lib/x86_64-linux-gnu",
                "/usr/lib/aarch64-linux-gnu"
            };

            foreach (string dir in searchDirs)
            {
                string[] candidates = new[]
                {
                    Path.Combine(dir, name),
                    Path.Combine(dir, "lib" + name),
                    Path.Combine(dir, "lib" + name + ".dylib"),
                    Path.Combine(dir, "lib" + name + ".so")
                };

                foreach (string candidate in candidates)
                {
                    if (File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                        return true;
                }
            }

            return false;
        }
    }
}
