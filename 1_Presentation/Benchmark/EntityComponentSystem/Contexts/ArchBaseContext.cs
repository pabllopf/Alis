// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchBaseContext.cs
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
using System.Runtime.InteropServices;
using Arch.Core;
using Arch.Core.Utils;
using Schedulers;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    namespace Arch_Components
    {
        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Component3
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }

    /// <summary>
    ///     The arch base context class
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class ArchBaseContext : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArchBaseContext" /> class
        /// </summary>
        public ArchBaseContext() => World = World.Create();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArchBaseContext" /> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="amount">The amount</param>
        public ArchBaseContext(ComponentType[] archetype, int amount)
        {
            JobScheduler = new JobScheduler(new JobScheduler.Config
            {
                ThreadPrefixName = "Arch.Samples",
                ThreadCount = 0,
                MaxExpectedConcurrentJobs = 64,
                StrictAllocationMode = false
            });

            World = World.Create();
            World.SharedJobScheduler = JobScheduler;
            World.Reserve(archetype, amount);

            for (int index = 0; index < amount; index++)
            {
                World.Create(archetype);
            }
        }

        /// <summary>
        ///     Gets the value of the scene
        /// </summary>
        public World World { get; }

        /// <summary>
        ///     Gets or sets the value of the job scheduler
        /// </summary>
        public JobScheduler JobScheduler { get; set; }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            World.Destroy(World);
            JobScheduler?.Dispose();
        }
    }
}