// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomIndexOutOfRangeException.cs
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

namespace Alis.Core.Aspect.Math.Matrix;

/// <summary>
///     The custom index out of range exception class
/// </summary>
/// <seealso cref="Exception" />
public class CustomIndexOutOfRangeException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomIndexOutOfRangeException" /> class
    /// </summary>
    public CustomIndexOutOfRangeException()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomIndexOutOfRangeException" /> class
    /// </summary>
    /// <param name="invalidMatrixIndex">The invalid matrix index</param>
    public CustomIndexOutOfRangeException(string invalidMatrixIndex) : base(invalidMatrixIndex)
    {
    }
}