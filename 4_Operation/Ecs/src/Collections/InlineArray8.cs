// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InlineArray8.cs
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



namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The inline array
    /// </summary>
    internal struct InlineArray8<T>
    {
        /// <summary>
        ///     The
        /// </summary>
        public T _0;

        /// <summary>
        ///     The
        /// </summary>
        public T _1;

        /// <summary>
        ///     The
        /// </summary>
        public T _2;

        /// <summary>
        ///     The
        /// </summary>
        public T _3;

        /// <summary>
        ///     The
        /// </summary>
        public T _4;

        /// <summary>
        ///     The
        /// </summary>
        public T _5;

        /// <summary>
        ///     The
        /// </summary>
        public T _6;

        /// <summary>
        ///     The
        /// </summary>
        public T _7;

        /// <summary>
        ///     Gets the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T Get(ref InlineArray8<T> array, int index) => ref System.Runtime.CompilerServices.Unsafe.Add(ref array._0, index);
    }
}