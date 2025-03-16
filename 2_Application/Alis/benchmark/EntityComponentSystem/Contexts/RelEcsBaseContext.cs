// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RelEcsBaseContext.cs
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
using RelEcs;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    ///     The rel ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class RelEcsBaseContext : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RelEcsBaseContext" /> class
        /// </summary>
        public RelEcsBaseContext() => World = new World();

        /// <summary>
        ///     Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            // World.Destroy();
        }

        /// <summary>
        ///     The component class
        /// </summary>
        public sealed class Component1
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component class
        /// </summary>
        public sealed class Component2
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component class
        /// </summary>
        public sealed class Component3
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }
}