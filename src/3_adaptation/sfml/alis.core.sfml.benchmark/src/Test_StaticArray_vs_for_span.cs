// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Test_StaticArray_vs_for_span.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using Alis.Core.Entities;
using Alis.Core.Sfml;
using BenchmarkDotNet.Attributes;

namespace Alis.Core.Benchmark
{
    /// <summary>
    ///     The test staticarray vs for span class
    /// </summary>
    public class Test_StaticArray_vs_for_span
    {
        /// <summary>
        ///     The array size
        /// </summary>
        [Params(10, 1_000, 100_000)] public int arraySize;

        /// <summary>
        ///     The components
        /// </summary>
        private Component[] components;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            components = new Component[arraySize];
            for (var i = 0; i < components.Length; i++) components[i] = new BoxCollider2D();
        }

        /// <summary>
        ///     Updates the with for span
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Update_With_For_Span()
        {
            var temp = components.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Update();
        }

        /// <summary>
        ///     Updates the array foreach
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Update_Array_Foreach() => Array.ForEach(components, i => i.Update());
    }
}