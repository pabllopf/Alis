// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BulkCreateAndMutateSample.cs
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
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The bulk create and mutate sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class BulkCreateAndMutateSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "bulk-create-mutate";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Bulk Create And Mutate";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Creates many entities quickly and mutates all of them with a query.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            ChunkTuple<int> chunk = scene.CreateMany<int>(20);
            for (int i = 0; i < chunk.Span.Length; i++)
            {
                chunk.Span[i] = i;
            }

            scene.Query<With<int>>().Delegate((ref int value) => value *= 3);

            int sum = 0;
            foreach (RefTuple<int> tuple in scene.Query<With<int>>().Enumerate<int>())
            {
                sum += tuple.Item1.Value;
            }

            Console.WriteLine($"Entity count: {scene.EntityCount}");
            Console.WriteLine($"Sum after multiply by 3: {sum}");
        }
    }
}