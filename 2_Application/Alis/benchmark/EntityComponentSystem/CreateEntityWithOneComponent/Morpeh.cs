// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Morpeh.cs
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
using Scellecs.Morpeh;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    ///     The create gameObject with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        ///     The context
        /// </summary>
        [Context] private readonly MorpehBaseContext _context;

        /// <summary>
        ///     Morpehs the direct
        /// </summary>
        [BenchmarkCategory(Categories.Morpeh), Benchmark]
        public void Morpeh_Direct()
        {
            World world = _context.World;
            for (int i = 0; i < EntityCount; ++i)
            {
                world.CreateEntity().AddComponent<MorpehBaseContext.Component1>();
            }

            world.Commit();
        }

        /// <summary>
        ///     Morpehs the stash
        /// </summary>
        [BenchmarkCategory(Categories.Morpeh), Benchmark]
        public void Morpeh_Stash()
        {
            World world = _context.World;
            Stash<MorpehBaseContext.Component1> stash1 = world.GetStash<MorpehBaseContext.Component1>();
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = world.CreateEntity();
                stash1.Add(entity);
            }

            world.Commit();
        }
    }
}