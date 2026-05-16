// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GetProgramInfoLogDel.cs
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

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     Returns the information log for a program object
    /// </summary>
    /// <param name="program">Specifies the program object whose information log is to be queried</param>
    /// <param name="maxLength">Specifies the maximum number of characters to write into infoLog</param>
    /// <param name="length">Returns the actual number of characters written into infoLog</param>
    /// <param name="infoLog">Returns the information log string</param>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void GetProgramInfoLogDel(uint program, int maxLength, [Out] int[] length, [Out] StringBuilder infoLog);
}