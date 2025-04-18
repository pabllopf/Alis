// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkTuple.9.cs
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

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    /// The chunk tuple
    /// </summary>
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        /// <summary>
        ///     An enumerator that can be used to enumerate individual <see cref="GameObject" /> instances.
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;

        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9)
        {
            comp1 = Span1;
            comp2 = Span2;
            comp3 = Span3;
            comp4 = Span4;
            comp5 = Span5;
            comp6 = Span6;
            comp7 = Span7;
            comp8 = Span8;
            comp9 = Span9;
        }
    }
}