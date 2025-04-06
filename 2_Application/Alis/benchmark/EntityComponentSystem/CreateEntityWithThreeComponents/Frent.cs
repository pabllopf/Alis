// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Frent.cs
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
using BenchmarkDotNet.Attributes;
using Frent;

using Frent.Systems;
using static Alis.Benchmark.EntityComponentSystem.Contexts.FrentBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    ///     The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        ///     The id
        /// </summary>
        private static readonly EntityType _entityType = Entity.EntityTypeOf([Component<Component1>.ID, Component<Component2>.ID, Component<Component3>.ID], []);

        /// <summary>
        ///     The frent
        /// </summary>
        [Context] private readonly FrentBaseContext _frent;

        /// <summary>
        ///     Frents this instance
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent()
        {
            World world = _frent.World;
            world.EnsureCapacity(_entityType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1, Component2, Component3>(default(Component1), default(Component2), default(Component3));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_Bulk()
        {
            World world = _frent.World;
            ChunkTuple<Component1, Component2, Component3> chunks = world.CreateMany<Component1, Component2, Component3>(EntityCount);

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