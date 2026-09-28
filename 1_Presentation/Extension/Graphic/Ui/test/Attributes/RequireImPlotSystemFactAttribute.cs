// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RequireImPlotSystemFactAttribute.cs
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
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Attributes
{

    /// <summary>
    ///     The require im plot system fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class RequireImPlotSystemFactAttribute : FactAttribute
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="RequireImPlotSystemFactAttribute"/> class
        /// </summary>
        /// <param name="requiresImPlot">if set to <c>true</c> skips when ImPlot exports are unavailable</param>
        public RequireImPlotSystemFactAttribute(bool requiresImPlot = true)
        {
            bool available = IsImPlotAvailable();
            if (requiresImPlot && !available)
            {
                Skip = "Test skipped because ImPlot is not available on this platform";
            }
            else if (!requiresImPlot && available)
            {
                Skip = "Test skipped because ImPlot is available on this platform";
            }
        }

        /// <summary>
        ///     Describes whether im plot is available by loading the cimgui library and probing
        ///     the ImPlot_CreateContext export.
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsImPlotAvailable()
        {
            if (!TryLoadCimgui(out IntPtr handle))
            {
                return false;
            }

            return NativeLibrary.TryGetExport(handle, "ImPlot_CreateContext", out _);
        }

        /// <summary>
        ///     Attempts to load the cimgui library by name, falling back to absolute path
        ///     resolution from the test assembly output directory.
        /// </summary>
        /// <param name="handle">The native library handle</param>
        /// <returns>The bool</returns>
        private static bool TryLoadCimgui(out IntPtr handle)
        {
            if (NativeLibrary.TryLoad("cimgui", out handle))
            {
                return true;
            }

            string assemblyDir = Path.GetDirectoryName(typeof(RequireImPlotSystemFactAttribute).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                Path.Combine(assemblyDir, "cimgui"),
                Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "cimgui.dylib"),
                Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out handle))
                {
                    return true;
                }
            }

            return false;
        }
    }
}