// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Uniform4F.cs
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
    ///     Sets four float uniform values for the current program at the specified location
    /// </summary>
    /// <param name="location">Specifies the location of the uniform variable to modify</param>
    /// <param name="v0">Specifies the first float value to assign</param>
    /// <param name="v1">Specifies the second float value to assign</param>
    /// <param name="v2">Specifies the third float value to assign</param>
    /// <param name="v3">Specifies the fourth float value to assign</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void Uniform4F(int location, float v0, float v1, float v2, float v3);
}