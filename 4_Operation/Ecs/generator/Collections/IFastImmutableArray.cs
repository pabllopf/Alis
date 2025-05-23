// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFastImmutableArray.cs
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

namespace Alis.Core.Ecs.Generator.Collections
{
    /// <summary>
    ///     An internal non-generic interface implemented by <see cref="FastImmutableArray" />
    ///     that allows for recognition of an <see cref="FastImmutableArray{T}" /> instance and access
    ///     to its underlying array, without actually knowing the type of value
    ///     stored in it.
    /// </summary>
    /// <remarks>
    ///     Casting to this interface requires a boxed instance of the <see cref="FastImmutableArray{T}" /> struct,
    ///     and as such should be avoided. This interface is useful, however, where the value
    ///     is already boxed and we want to try to reuse immutable arrays instead of copying them.
    ///     ** This interface is INTENTIONALLY INTERNAL, as it gives access to the inner array.  **
    /// </remarks>
    internal interface IFastImmutableArray
    {
        /// <summary>
        ///     Gets an untyped reference to the array.
        /// </summary>
        Array Array { get; }
    }
}