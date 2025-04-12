// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Query.12.cs
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


namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    /// The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.QueryEnumerable Enumerate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>() => new(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        public EntityQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.QueryEnumerable EnumerateWithEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>() => new(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>() => new(this);
    }
}