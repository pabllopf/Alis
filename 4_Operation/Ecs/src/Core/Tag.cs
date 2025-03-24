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
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Core
{
    /// <summary>
    ///     Holds the static <see cref="TagID" /> instance for the type <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The type of tag this class has info about</typeparam>
    public class Tag<T>
    {
        /// <summary>
        ///     The static tag ID instance
        /// </summary>
        public static readonly TagID ID = Tag.GetTagID(typeof(T));
    }

//this entirely piggybacks on top of component
/// <summary>
///     The tag class
/// </summary>
internal class Tag
    {
        /// <summary>
        ///     The existing tag ds
        /// </summary>
        private static readonly Dictionary<Type, TagID> ExistingTagIDs = [];

        /// <summary>
        ///     The create
        /// </summary>
        internal static FastStack<Type> TagTable = FastStack<Type>.Create(4);

        /// <summary>
        ///     The next tag id
        /// </summary>
        private static int _nextTagID = -1;

        //initalize default(TagID) to point to disable
        /// <summary>
        ///     Initializes a new instance of the <see cref="Tag" /> class
        /// </summary>
        static Tag() => GetTagID(typeof(Disable));

        /// <summary>
        ///     Gets the tag id using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="Exception">Exceeded max tag count of 65535</exception>
        /// <returns>The tag id</returns>
        internal static TagID GetTagID(Type type)
        {
            lock (GlobalWorldTables.BufferChangeLock)
            {
                if (ExistingTagIDs.TryGetValue(type, out TagID tagID))
                {
                    return tagID;
                }

                int id = Interlocked.Increment(ref _nextTagID);

                if (id == ushort.MaxValue)
                {
                    throw new Exception("Exceeded max tag count of 65535");
                }

                TagID newID = new TagID((ushort) id);
                ExistingTagIDs[type] = newID;
                TagTable.Push(type);

                GlobalWorldTables.GrowComponentTagTableIfNeeded(newID.RawValue);

                return newID;
            }
        }
    }
}