// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Tag.cs
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
using System.Collections.Generic;
using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Holds the static <see cref="TagId" /> instance for the type <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The type of tag this class has info about</typeparam>
    public class Tag<T>
    {
        /// <summary>
        ///     The static tag ID instance
        /// </summary>
        public static readonly TagId Id = Tag.GetTagId(typeof(T));
    }

//this entirely piggybacks on top of component
/// <summary>
///     The tag class
/// </summary>
public class Tag
    {
        /// <summary>
        ///     The existing tag ds
        /// </summary>
        private static readonly Dictionary<Type, TagId> ExistingTagIDs = [];

        /// <summary>
        ///     The create
        /// </summary>
        internal static FastestStack<Type> TagTable = FastestStack<Type>.Create(4);

        /// <summary>
        ///     The next tag id
        /// </summary>
        private static int _nextTagId = -1;

        //initalize default(TagID) to point to disable
        /// <summary>
        ///     Initializes a new instance of the <see cref="Tag" /> class
        /// </summary>
        static Tag()
        {
            GetTagId(typeof(Disable));
        }

        /// <summary>
        ///     Gets the tag id using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="Exception">Exceeded max tag count of 65535</exception>
        /// <returns>The tag id</returns>
        internal static TagId GetTagId(Type type)
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                if (ExistingTagIDs.TryGetValue(type, out TagId tagId))
                {
                    return tagId;
                }

                int id = Interlocked.Increment(ref _nextTagId);

                if (id == ushort.MaxValue)
                {
                    throw new Exception("Exceeded max tag count of 65535");
                }

                TagId newId = new TagId((ushort) id);
                ExistingTagIDs[type] = newId;
                TagTable.Push(type);

                GlobalWorldTables.GrowComponentTagTableIfNeeded(newId.RawValue);

                return newId;
            }
        }
    }
}