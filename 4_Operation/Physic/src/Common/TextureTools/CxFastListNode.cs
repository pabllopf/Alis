// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CxFastListNode.cs
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

namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The cx fast list node class
    /// </summary>
    internal class CxFastListNode<T>
    {
        /// <summary>
        ///     The elt
        /// </summary>
        internal readonly T _elt;

        /// <summary>
        ///     The next
        /// </summary>
        internal CxFastListNode<T> _next;

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="obj">The obj</param>
        public CxFastListNode(T obj) => _elt = obj;

        /// <summary>
        ///     Elems this instance
        /// </summary>
        /// <returns>The</returns>
        public T Elem() => _elt;

        /// <summary>
        ///     Nexts this instance
        /// </summary>
        /// <returns>A cx fast list node of t</returns>
        public CxFastListNode<T> Next() => _next;
    }
}