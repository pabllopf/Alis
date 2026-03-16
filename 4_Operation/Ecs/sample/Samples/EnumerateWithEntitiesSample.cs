// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerateWithEntitiesSample.cs
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
    ///     The enumerate with entities sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class EnumerateWithEntitiesSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "enumerate-with-entities";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Enumerate With Entities";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Iterates components and owning entities at the same time.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(5);
            scene.Create(7);
            scene.Create(9);

            foreach (var tuple in scene.Query<With<int>>().EnumerateWithEntities<int>())
            {
                Console.WriteLine($"Entity alive={tuple.GameObject.IsAlive}, value={tuple.Item1.Value}");
            }
        }
    }
}