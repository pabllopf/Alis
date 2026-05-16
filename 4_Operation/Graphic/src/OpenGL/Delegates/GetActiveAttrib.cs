// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetActiveAttrib.cs
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
using System.Text;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     Returns information about an active attribute variable in a program object
    /// </summary>
    /// <param name="program">Specifies the program object containing the attribute</param>
    /// <param name="index">Specifies the index of the attribute variable to query</param>
    /// <param name="bufSize">Specifies the maximum number of characters that may be written into name</param>
    /// <param name="length">Returns the actual number of characters written into name</param>
    /// <param name="size">Returns the size of the attribute variable</param>
    /// <param name="type">Returns the type of the attribute variable</param>
    /// <param name="name">Returns the name of the attribute variable</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void GetActiveAttrib(uint program, uint index, int bufSize, [Out] int[] length, [Out] int[] size, [Out] ActiveAttribType[] type, [Out] StringBuilder name);
}