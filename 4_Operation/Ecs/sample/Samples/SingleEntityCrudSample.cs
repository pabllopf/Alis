// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SingleEntityCrudSample.cs
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
    ///     The single entity crud sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class SingleEntityCrudSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "entity-crud";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Single Entity CRUD";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Shows create, read, update, add, remove and delete operations on one entity.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(1, "player");

            Console.WriteLine($"Initial -> int={entity.Get<int>()}, string={entity.Get<string>()}");

            entity.Set(typeof(int), 99);
            entity.Add(3.5f);
            Console.WriteLine($"After update -> int={entity.Get<int>()}, float={entity.Get<float>()}");

            entity.Remove<string>();
            Console.WriteLine($"Has<string> after remove: {entity.Has<string>()}");

            entity.Delete();
            Console.WriteLine($"IsAlive after delete: {entity.IsAlive}");
        }
    }
}