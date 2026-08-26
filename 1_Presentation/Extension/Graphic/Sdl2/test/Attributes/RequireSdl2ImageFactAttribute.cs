// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CsfmlAudioFactAttribute.cs
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
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Attributes
{
    /// <summary>
    ///     The require sdl2 image fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class RequireSdl2ImageFactAttribute : FactAttribute
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RequireSdl2ImageFactAttribute"/> class
        /// </summary>
        public RequireSdl2ImageFactAttribute()
        {
            if (!TryLoadSfmlLibrary("sdl2_image"))
            {
                Skip = "Test skipped because its not platform";
            }
        }

        /// <summary>
        ///     Attempts to load the specified SDL2_image library by name and verifies that
        ///     it is fully functional by resolving a known export symbol. Only name-based
        ///     resolution is used because the native DllImports resolve the library by name.
        /// </summary>
        private static bool TryLoadSfmlLibrary(string name)
        {
            return TryLoadAndVerify(name);
        }

        /// <summary>
        ///     Attempts to load a native library and verify it is fully functional by resolving
        ///     a known export symbol. This catches cases where the library file exists but has
        ///     unresolvable transitive dependencies.
        /// </summary>
        private static bool TryLoadAndVerify(string pathOrName)
        {
            if (!NativeLibrary.TryLoad(pathOrName, out IntPtr handle))
                return false;

            bool verified = NativeLibrary.TryGetExport(handle, "IMG_Linked_Version", out _);
            if (!verified)
            {
                NativeLibrary.Free(handle);
            }

            return verified;
        }
    }
}