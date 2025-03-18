// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectPoolingBenchmark.cs
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

using Alis.Benchmark.ObjectPooling.Instancies;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ObjectPooling
{
    /// <summary>
    ///     The object pooling benchmark class
    /// </summary>
    [MemoryDiagnoser, Config(typeof(Config))]
    public class ObjectPoolingBenchmark
    {
        /// <summary>
        ///     The
        /// </summary>
        [Params(100)] public int N;

        /// <summary>
        ///     The object pool
        /// </summary>
        private ObjectPool<PooledObject> objectPool;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            objectPool = new ObjectPool<PooledObject>();
        }

        /// <summary>
        ///     Withouts the pooling
        /// </summary>
        [Benchmark]
        public void WithoutPooling()
        {
            for (int i = 0; i < N; i++)
            {
                PooledObject obj = new PooledObject();
                obj.Value = i;
            }
        }

        /// <summary>
        ///     Adds the pooling
        /// </summary>
        [Benchmark]
        public void WithPooling()
        {
            for (int i = 0; i < N; i++)
            {
                PooledObject obj = objectPool.Get();
                obj.Value = i;
                objectPool.Return(obj);
            }
        }
    }
}