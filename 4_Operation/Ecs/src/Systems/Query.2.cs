// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Query.2.cs
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

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T1, T2>.QueryEnumerable Enumerate<T1, T2>() => new QueryEnumerator<T1, T2>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for
        ///     use in foreach loops.
        /// </summary>
        public QueryEnumerable<T1, T2> EnumerateWithEntities<T1, T2>() => new QueryEnumerable<T1, T2>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T1, T2>.QueryEnumerable EnumerateChunks<T1, T2>() => new ChunkQueryEnumerator<T1, T2>.QueryEnumerable(this);
    }
}