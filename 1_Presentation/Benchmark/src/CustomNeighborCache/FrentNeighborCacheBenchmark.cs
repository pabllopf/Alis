// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrentNeighborCacheBenchmark.cs
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

using Alis.Benchmark.CustomEcs.Components;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Core;

namespace Alis.Benchmark.CustomNeighborCache
{
    /// <summary>
    ///     The custom neighbor cache benchmark class
    /// </summary>
    public partial class CustomNeighborCacheBenchmark
    {
        /// <summary>
        ///     The id
        /// </summary>
        private static readonly EntityType _frentBaseType =
            Entity.EntityTypeOf([Component<Component16>.ID], []);

        /// <summary>
        ///     The frent entities
        /// </summary>
        private Entity[] _frentEntities;

        /// <summary>
        ///     The frent world
        /// </summary>
        private World _frentWorld;

        /// <summary>
        ///     Setup the frent
        /// </summary>
        private void SetupFrent()
        {
            _frentWorld = new World();
            _frentWorld.EnsureCapacity(_frentBaseType, EntityCount);

            _frentEntities = new Entity[EntityCount];
            for (int i = 0; i < EntityCount; i++)
            {
                _frentEntities[i] = _frentWorld.Create(default(Component16));
            }
        }

        /// <summary>
        ///     Disposes the frent
        /// </summary>
        private void DisposeFrent() => _frentWorld.Dispose();

        /// <summary>
        ///     Frents the neighbor add remove
        /// </summary>
        [Benchmark(Baseline = true)]
        public void Frent_Neighbor_AddRemove()
        {
            switch (Arity)
            {
                case 1: RunFrent1(); break;
                case 2: RunFrent2(); break;
                case 3: RunFrent3(); break;
                case 4: RunFrent4(); break;
                case 5: RunFrent5(); break;
                case 6: RunFrent6(); break;
                case 7: RunFrent7(); break;
                default: RunFrent8(); break;
            }
        }

        /// <summary>
        ///     Runs the frent 1
        /// </summary>
        private void RunFrent1()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1));
                entity.Remove<Component1>();
            }
        }

        /// <summary>
        ///     Runs the frent 2
        /// </summary>
        private void RunFrent2()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2));
                entity.Remove<Component1, Component2>();
            }
        }

        /// <summary>
        ///     Runs the frent 3
        /// </summary>
        private void RunFrent3()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3));
                entity.Remove<Component1, Component2, Component3>();
            }
        }

        /// <summary>
        ///     Runs the frent 4
        /// </summary>
        private void RunFrent4()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4));
                entity.Remove<Component1, Component2, Component3, Component4>();
            }
        }

        /// <summary>
        ///     Runs the frent 5
        /// </summary>
        private void RunFrent5()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5));
                entity.Remove<Component1, Component2, Component3, Component4, Component5>();
            }
        }

        /// <summary>
        ///     Runs the frent 6
        /// </summary>
        private void RunFrent6()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6>();
            }
        }

        /// <summary>
        ///     Runs the frent 7
        /// </summary>
        private void RunFrent7()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6), default(Component7));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6, Component7>();
            }
        }

        /// <summary>
        ///     Runs the frent 8
        /// </summary>
        private void RunFrent8()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6), default(Component7), default(Component8));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8>();
            }
        }
    }
}