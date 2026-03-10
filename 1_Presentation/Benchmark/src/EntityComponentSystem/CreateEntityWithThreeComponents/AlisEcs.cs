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
using Alis.Core.Ecs.Systems;
using BenchmarkDotNet.Attributes;
using static Alis.Benchmark.EntityComponentSystem.Contexts.AlisBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    ///     The create gameObject with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        ///     The id
        /// </summary>
        private static readonly GameObjectType _entityAlisType = GameObject.EntityTypeOf([Component<Component1>.Id, Component<Component2>.Id, Component<Component3>.Id]);

        /// <summary>
        ///     The alis
        /// </summary>
        [Context] private readonly AlisBaseContext _alis;

        /// <summary>
        ///     Frents this instance
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis()
        {
            Scene scene = _alis.Scene;
            scene.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                scene.Create(default(Component1), default(Component2), default(Component3));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_Bulk()
        {
            Scene scene = _alis.Scene;
            ChunkTuple<Component1, Component2, Component3> chunks = scene.CreateMany<Component1, Component2, Component3>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
            }
        }
    }
}