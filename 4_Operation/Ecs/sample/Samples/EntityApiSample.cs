// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityApiSample.cs
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
    ///     The entity api sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class EntityApiSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "entity-api";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Entity API";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Uses Has, Add, TryGet, Get and Deconstruct on a single entity.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(69, 3.14, 2.71f);

            Console.WriteLine($"IsAlive: {entity.IsAlive}");
            Console.WriteLine($"Has<int>: {entity.Has<int>()}");
            Console.WriteLine($"Has<bool>: {entity.Has<bool>()}");

            entity.Add("I like Alis");

            if (entity.TryGet(out Ref<string> text))
            {
                Console.WriteLine($"Current string: {text.Value}");
                text.Value = "Do you like Alis?";
            }

            Console.WriteLine($"String via Get<string>: {entity.Get<string>()}");

            entity.Deconstruct(out Ref<double> number, out Ref<int> integer, out Ref<float> floating, out Ref<string> message);
            number.Value = 4;
            message.Value = "Hello, ECS scene!";

            Console.WriteLine($"Updated values -> double: {number.Value}, int: {integer.Value}, float: {floating.Value}, string: {message.Value}");
        }
    }
}