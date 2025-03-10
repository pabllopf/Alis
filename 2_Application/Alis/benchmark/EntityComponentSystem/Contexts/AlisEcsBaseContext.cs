// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AlisEcsBaseContext.cs
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
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.System;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
     namespace Alis_Components
    {
        /// <summary>
        /// The component
        /// </summary>
        internal class Component1 : AComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        internal class Component2 : AComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        internal class Component3 : AComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }
    }

    /// <summary>
    /// The arch base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class AlisEcsBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public VideoGame VideoGame { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchBaseContext"/> class
        /// </summary>
        public AlisEcsBaseContext()
        {
            VideoGame = VideoGame.Create().Build();
        }
        
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}