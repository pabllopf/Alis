// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BulkDeleteByQuerySample.cs
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
    ///     The bulk delete by query sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class BulkDeleteByQuerySample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "bulk-delete-query";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Bulk Delete By Query";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Finds entities with a query and deletes a subset.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            for (int i = 1; i <= 8; i++)
            {
                scene.Create(i);
            }

            Console.WriteLine($"Initial entity count: {scene.EntityCount}");

            foreach (var tuple in scene.Query<With<int>>().EnumerateWithEntities<int>())
            {
                if (tuple.Item1.Value % 2 == 0)
                {
                    tuple.GameObject.Delete();
                }
            }

            scene.Update();

            Console.WriteLine($"Entity count after deleting even values: {scene.EntityCount}");
            Console.Write("Remaining values: ");
            foreach (RefTuple<int> tuple in scene.Query<With<int>>().Enumerate<int>())
            {
                Console.Write($"{tuple.Item1.Value} ");
            }

            Console.WriteLine();
        }
    }
}