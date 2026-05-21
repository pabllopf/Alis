// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnsureCapacitySample.cs
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

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The ensure capacity sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class EnsureCapacitySample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "ensure-capacity";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Ensure Capacity";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Preallocates archetype capacity before bulk creation.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            GameObject seed = scene.Create(0, 0f);
            scene.EnsureCapacity(seed.Type, 50);
            seed.Delete();

            for (int i = 0; i < 50; i++)
            {
                scene.Create(i, (float) i / 10);
            }

            Console.WriteLine($"Entity count after preallocated creation: {scene.EntityCount}");
        }
    }
}