// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TypeBasedAccessSample.cs
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
    ///     The type based access sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class TypeBasedAccessSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "type-access";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Type-Based Access";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Uses AddAs, Get(Type), Set(Type) and Remove(Type) for runtime workflows.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.AddAs(typeof(int), 10);
            entity.AddAs(typeof(string), "dynamic value");

            object valueBefore = entity.Get(typeof(int));
            Console.WriteLine($"Value before Set(Type): {valueBefore}");

            entity.Set(typeof(int), 500);
            object valueAfter = entity.Get(typeof(int));
            Console.WriteLine($"Value after Set(Type): {valueAfter}");

            entity.Remove(typeof(string));
            Console.WriteLine($"Has<string> after Remove(Type): {entity.Has<string>()}");
        }
    }
}