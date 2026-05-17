// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeNeighborCache.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     A 4-way set-associative cache mapping source archetype IDs to destination archetypes.
    /// </summary>
    /// <remarks>
    ///     Stores both the ushort destination archetype ID (backward-compat) and the direct
    ///     <see cref="Archetype" /> reference so the hot hit-path skips the WorldArchetypeTable lookup entirely.
    ///     Round-robin (LRU-approx) eviction. Total size ~52 bytes (fits in one cache line).
    /// </remarks>
    internal struct ArchetypeNeighborCache
    {
        /// <summary>
        ///     The
        /// </summary>
        private ushort _k0, _k1, _k2, _k3;

        /// <summary>
        ///     The
        /// </summary>
        private ushort _v0, _v1, _v2, _v3;

        /// <summary>
        ///     The arch
        /// </summary>
        private Archetype _arch0, _arch1, _arch2, _arch3;

        // Round-robin insertion slot (0-3)
        /// <summary>
        ///     The next index
        /// </summary>
        private int _nextIndex;

        /// <summary>Returns the slot index (0-3) for <paramref name="value" />, or 32 on miss.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Traverse(ushort value)
        {
            if (value == _k0)
            {
                return 0;
            }

            if (value == _k1)
            {
                return 1;
            }

            if (value == _k2)
            {
                return 2;
            }

            if (value == _k3)
            {
                return 3;
            }

            return 32;
        }

        /// <summary>
        ///     Returns the cached <see cref="Archetype" /> for <paramref name="key" /> directly,
        ///     or <see langword="null" /> on a miss. Eliminates the WorldArchetypeTable lookup on the hot path.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Archetype TraverseArchetype(ushort key)
        {
            if (key == _k0)
            {
                return _arch0;
            }

            if (key == _k1)
            {
                return _arch1;
            }

            if (key == _k2)
            {
                return _arch2;
            }

            if (key == _k3)
            {
                return _arch3;
            }

            return null;
        }

        /// <summary>Returns the destination archetype ID stored at <paramref name="index" />.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Lookup(int index)
        {
            return index switch
            {
                0 => _v0,
                1 => _v1,
                2 => _v2,
                _ => _v3
            };
        }

        /// <summary>Stores a key→value mapping (ushort only, no direct Archetype reference).</summary>
        public void Set(ushort key, ushort value)
        {
            int slot = _nextIndex;
            switch (slot)
            {
                case 0:
                    _k0 = key;
                    _v0 = value;
                    _arch0 = null;
                    break;
                case 1:
                    _k1 = key;
                    _v1 = value;
                    _arch1 = null;
                    break;
                case 2:
                    _k2 = key;
                    _v2 = value;
                    _arch2 = null;
                    break;
                default:
                    _k3 = key;
                    _v3 = value;
                    _arch3 = null;
                    break;
            }

            _nextIndex = (slot + 1) & 3;
        }

        /// <summary>
        ///     Stores a key→archetype mapping. The destination archetype ID is derived from
        ///     <paramref name="archetype" /> and the reference is cached for the fast hit path.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(ushort key, Archetype archetype)
        {
            ushort value = archetype.Id.RawIndex;
            int slot = _nextIndex;
            switch (slot)
            {
                case 0:
                    _k0 = key;
                    _v0 = value;
                    _arch0 = archetype;
                    break;
                case 1:
                    _k1 = key;
                    _v1 = value;
                    _arch1 = archetype;
                    break;
                case 2:
                    _k2 = key;
                    _v2 = value;
                    _arch2 = archetype;
                    break;
                default:
                    _k3 = key;
                    _v3 = value;
                    _arch3 = archetype;
                    break;
            }

            _nextIndex = (slot + 1) & 3;
        }
    }
}