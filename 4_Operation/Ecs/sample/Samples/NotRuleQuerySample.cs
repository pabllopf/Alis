// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NotRuleQuerySample.cs
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
    ///     The not rule query sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class NotRuleQuerySample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "query-not";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Query With Not Rule";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Filters entities with int but without bool using Not<T>.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(1);
            scene.Create(2, true);
            scene.Create(3);
            scene.Create(4, false);

            Console.WriteLine("Entities that match With<int> + Not<bool>:");
            foreach (RefTuple<int> tuple in scene.Query<With<int>, Not<bool>>().Enumerate<int>())
            {
                Console.WriteLine($"Value: {tuple.Item1.Value}");
            }
        }
    }
}