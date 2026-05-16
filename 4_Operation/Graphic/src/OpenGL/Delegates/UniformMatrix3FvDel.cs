// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UniformMatrix3FvDel.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     Sets a 3x3 matrix uniform value for the current program at the specified location
    /// </summary>
    /// <param name="location">Specifies the location of the uniform variable to modify</param>
    /// <param name="count">Specifies the number of matrices to be modified</param>
    /// <param name="transpose">Specifies whether to transpose the matrix values</param>
    /// <param name="value">Specifies an array of float values representing the matrix</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void UniformMatrix3FvDel(int location, int count, bool transpose, float[] value);
}