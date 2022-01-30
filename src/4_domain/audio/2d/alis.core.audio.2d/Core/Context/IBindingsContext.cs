// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   IBindingsContext.cs
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

namespace Alis.Core.Audio.Core.Context
{
    /// <summary>
    ///     Provides methods for querying available functions in a bindings context.
    /// </summary>
    public interface IBindingsContext
    {
        /// <summary>
        ///     Retrieves an unmanaged function pointer to the specified function on the specified bindings context.
        /// </summary>
        /// <param name="procName">An ASCII-encoded string that defines the name of the function.</param>
        /// <returns>
        ///     A <see cref="System.IntPtr" /> that contains the address of procName or IntPtr.Zero,
        ///     if the function is not supported by the drivers.
        /// </returns>
        /// <remarks>
        ///     Note: some drivers are known to return non-zero values for unsupported functions.
        ///     Typical values include 1 and 2 - inheritors are advised to check for and ignore these
        ///     values.
        /// </remarks>
        IntPtr GetProcAddress(string procName);
    }
}