// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NoneUpdate.cs
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

using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The none update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    internal class NoneUpdate<TComp>(int cap) : ComponentStorage<TComp>(cap)
    {
        /// <summary>
        ///     Multithreadeds the run using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b)
        {
        }

        /// <summary>
        ///     Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void Run(World world, Archetype b)
        {
        }
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory" />
    public class NoneUpdateRunnerFactory<T> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<T>
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new NoneUpdate<T>(capacity);

        /// <summary>
        ///     Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<T>();

        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t</returns>
        ComponentStorage<T> IComponentStorageBaseFactory<T>.CreateStronglyTyped(int capacity) => new NoneUpdate<T>(capacity);
    }
}