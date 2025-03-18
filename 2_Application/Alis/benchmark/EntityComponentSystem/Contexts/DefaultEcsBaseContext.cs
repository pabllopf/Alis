// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DefaultEcsBaseContext.cs
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
using DefaultEcs;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    ///     The default ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class DefaultEcsBaseContext : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultEcsBaseContext" /> class
        /// </summary>
        public DefaultEcsBaseContext() => World = new World();

        /// <summary>
        ///     Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            World.Dispose();
        }

        /// <summary>
        ///     The component
        /// </summary>
        public struct Component1
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        public struct Component2
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        public struct Component3
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }
}