// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectIdOnly.cs
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

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     The gameObject id only
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct GameObjectIdOnly(int id, ushort version)
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
        ///     Returns the gameObject using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The gameObject</returns>
        internal GameObject ToEntity(Scene scene) => new GameObject(scene.Id, Version, ID);

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
        ///     Sets the gameObject using the specified gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetEntity(ref GameObject gameObject)
        {
            gameObject.EntityVersion = Version;
            gameObject.EntityID = ID;
        }

        /// <summary>
        ///     Inits the gameObject
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(GameObject gameObject)
        {
            Version = gameObject.EntityVersion;
            ID = gameObject.EntityID;
        }

        /// <summary>
        ///     Inits the gameObject
        /// </summary>
        /// <param name="entity">The gameObject</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Init(GameObjectIdOnly entity)
        {
            Version = entity.Version;
            ID = entity.ID;
        }
    }
}