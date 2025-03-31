// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AlisEcs.cs
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

using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Operations;
using BenchmarkDotNet.Attributes;
using static Alis.Benchmark.EntityComponentSystem.Contexts.AlisBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    ///     The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        ///     The id
        /// </summary>
        private static readonly EntityType _entityAlisType = Entity.EntityTypeOf([Component<Component1>.ID], []);

        /// <summary>
        ///     The frent
        /// </summary>
        [Context] private readonly AlisBaseContext _alis;

        /// <summary>
        ///     Frents this instance
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis()
        {
            World world = _alis.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1>(default(Component1));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_Bulk()
        {
            World world = _alis.World;
            ChunkTuple<Component1> chunks = world.CreateMany<Component1>(EntityCount);

            for (int i = 0; i < chunks.Span.Length; i++)
            {
                chunks.Span[i] = new Component1();
            }
        }
    }
}