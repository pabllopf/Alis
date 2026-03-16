// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TryGetByTypeSample.cs
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
    ///     The try get by type sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class TryGetByTypeSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "tryget-type";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "TryGet Generic And Type";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Compares generic TryGet<T> with runtime TryGet(Type, out object).";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(42, "sample");

            if (entity.TryGet(out Ref<int> intRef))
            {
                Console.WriteLine($"TryGet<int>: {intRef.Value}");
            }

            if (entity.TryGet(typeof(string), out object text))
            {
                Console.WriteLine($"TryGet(typeof(string)): {text}");
            }

            bool hasVelocity = entity.TryGet(typeof(float), out object _);
            Console.WriteLine($"TryGet(typeof(float)) found value: {hasVelocity}");
        }
    }
}