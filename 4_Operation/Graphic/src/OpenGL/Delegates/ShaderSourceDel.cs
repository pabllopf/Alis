// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderSourceDel.cs
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
    ///     Sets the source code for a shader object, replacing any previously set source
    /// </summary>
    /// <param name="shader">Specifies the shader object whose source code is to be replaced</param>
    /// <param name="count">Specifies the number of strings in the source array</param>
    /// <param name="string">Specifies an array of strings containing the source code</param>
    /// <param name="length">Specifies an array with the length of each source string</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void ShaderSourceDel(uint shader, int count, string[] @string, int[] length);
}