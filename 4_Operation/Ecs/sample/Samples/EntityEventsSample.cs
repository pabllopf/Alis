// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityEventsSample.cs
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
    ///     The entity events sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class EntityEventsSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "entity-identity";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Entity Identity";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Compares live entities with GameObject.Null and checks liveness.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(10);

            Console.WriteLine($"Entity is null: {entity.IsNull}");
            Console.WriteLine($"GameObject.Null is null: {GameObject.Null.IsNull}");
            Console.WriteLine($"Entity equals GameObject.Null: {entity == GameObject.Null}");

            Console.WriteLine($"Entity alive before delete: {entity.IsAlive}");
            entity.Delete();
            Console.WriteLine($"Entity alive after delete: {entity.IsAlive}");
        }
    }
}