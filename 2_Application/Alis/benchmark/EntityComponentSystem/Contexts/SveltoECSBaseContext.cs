// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SveltoECSBaseContext.cs
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
using Svelto.ECS;
using Svelto.ECS.Schedulers;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    ///     The svelto ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class SveltoECSBaseContext : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SveltoECSBaseContext" /> class
        /// </summary>
        public SveltoECSBaseContext()
        {
            Scheduler = new SimpleEntitiesSubmissionScheduler();
            Root = new EnginesRoot(Scheduler);
            Factory = Root.GenerateEntityFactory();
        }

        /// <summary>
        ///     Gets the value of the group
        /// </summary>
        public static ExclusiveGroup Group { get; } = new();

        /// <summary>
        ///     Gets the value of the scheduler
        /// </summary>
        public SimpleEntitiesSubmissionScheduler Scheduler { get; }

        /// <summary>
        ///     Gets the value of the root
        /// </summary>
        public EnginesRoot Root { get; }

        /// <summary>
        ///     Gets the value of the factory
        /// </summary>
        public IEntityFactory Factory { get; }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            Root.Dispose();
            Scheduler.Dispose();
        }

        /// <summary>
        ///     The component
        /// </summary>
        public struct Component1 : IEntityComponent
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        public struct Component2 : IEntityComponent
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        public struct Component3 : IEntityComponent
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }
}