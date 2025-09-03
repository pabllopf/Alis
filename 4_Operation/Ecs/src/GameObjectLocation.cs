// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLocation.cs
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

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject location
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct GameObjectLocation
    {
        //128 bits
        /// <summary>
        ///     The archetype
        /// </summary>
        internal Archetype Archetype;

        /// <summary>
        ///     The index
        /// </summary>
        internal int Index;

        /// <summary>
        ///     The flags
        /// </summary>
        internal GameObjectFlags Flags;

        /// <summary>
        ///     The version
        /// </summary>
        internal ushort Version;

        /// <summary>
        ///     Gets the value of the archetype id
        /// </summary>
        internal readonly ArchetypeID ArchetypeId => Archetype.Id;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectLocation" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="index">The index</param>
        public GameObjectLocation(Archetype archetype, int index)
        {
            Archetype = archetype;
            Index = index;
            Flags = GameObjectFlags.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectLocation" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        public GameObjectLocation(Archetype archetype, int index, GameObjectFlags flags)
        {
            Archetype = archetype;
            Index = index;
            Flags = flags;
        }

        /// <summary>
        ///     Gets the value of the default
        /// </summary>
        public static GameObjectLocation Default { get; } = new GameObjectLocation(null!, int.MaxValue);

        /// <summary>
        ///     Hases the event using the specified gameObject flags
        /// </summary>
        /// <param name="entityFlags">The gameObject flags</param>
        /// <returns>The res</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool HasEvent(GameObjectFlags entityFlags)
        {
            bool res = (Flags & entityFlags) != GameObjectFlags.None;
            return res;
        }

        /// <summary>
        ///     Hases the event flag using the specified gameObject flags
        /// </summary>
        /// <param name="entityFlags">The gameObject flags</param>
        /// <param name="target">The target</param>
        /// <returns>The res</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEventFlag(GameObjectFlags entityFlags, GameObjectFlags target)
        {
            bool res = (entityFlags & target) != GameObjectFlags.None;
            return res;
        }
    }
}