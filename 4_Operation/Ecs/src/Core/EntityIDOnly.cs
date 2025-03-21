// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferItems.cs
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

namespace Alis.Core.Ecs.Core
{
    /// <summary>
    ///     The entity id only
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
//TODO: rename this?
    internal struct EntityIDOnly(int id, ushort version)
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal int ID = id;

        /// <summary>
        ///     The version
        /// </summary>
        internal ushort Version = version;

        /// <summary>
        ///     Returns the entity using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The entity</returns>
        internal Entity ToEntity(World world) => new Entity(world.ID, Version, ID);

        /// <summary>
        ///     Deconstructs the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="version">The version</param>
        internal void Deconstruct(out int id, out ushort version)
        {
            id = ID;
            version = Version;
        }

        /// <summary>
        ///     Sets the entity using the specified entity
        /// </summary>
        /// <param name="entity">The entity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetEntity(ref Entity entity)
        {
            entity.EntityVersion = Version;
            entity.EntityID = ID;
        }

        /// <summary>
        ///     Inits the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(Entity entity)
        {
            Version = entity.EntityVersion;
            ID = entity.EntityID;
        }

        /// <summary>
        ///     Inits the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(EntityIDOnly entity)
        {
            Version = entity.Version;
            ID = entity.ID;
        }
    }
}