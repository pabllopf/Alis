// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectMarshal.cs
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

using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Marshalling
{
    /// <summary>
    ///     Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can
    ///     result in corrupting scene state and segfaults.
    /// </summary>
    /// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
    public static class GameObjectMarshal
    {
        /// <summary>
        ///     Gets the <see cref="Scene" /> for an <see cref="GameObject" />. Does not check if the <see cref="GameObject" /> or
        ///     <see cref="Scene" /> is alive.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject" /> to get the <see cref="Scene" /> for.</param>
        /// <returns>The <see cref="Scene" /> the <paramref name="gameObject" /> belongs to, if it still exists.</returns>
        public static Scene GetWorld(GameObject gameObject) => GlobalWorldTables.Worlds.UnsafeIndexNoResize(gameObject.EntityID);

        /// <summary>
        ///     Gets the raw entityID from an <see cref="GameObject" />
        /// </summary>
        /// <returns>The integer entityID</returns>
        public static int EntityId(GameObject gameObject) => gameObject.EntityID;
    }
}