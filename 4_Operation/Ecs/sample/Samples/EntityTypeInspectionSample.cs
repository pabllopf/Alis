// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityTypeInspectionSample.cs
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
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The entity type inspection sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class EntityTypeInspectionSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "entity-type";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Entity Type Inspection";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Reads component type metadata from a live entity.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(7, 3.5f, "metadata");

            Console.WriteLine($"Entity type id: {entity.Type}");
            Console.WriteLine("Component types:");

            foreach (ComponentId componentType in entity.ComponentTypes)
            {
                Console.WriteLine($"- {componentType.ToString()}");
            }
        }
    }
}