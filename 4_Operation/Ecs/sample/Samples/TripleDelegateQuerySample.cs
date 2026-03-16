// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TripleDelegateQuerySample.cs
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
    ///     The triple delegate query sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class TripleDelegateQuerySample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "query-triple-delegate";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Triple Delegate Query";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Applies Delegate<T1,T2,T3> over entities with three components.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(1, 2f, 3d);
            scene.Create(10, 5f, 2d);

            scene.Query<With<int>, With<float>, With<double>>().Delegate((ref int a, ref float b, ref double c) =>
            {
                a += 1;
                b *= 2;
                c -= 1;
            });

            foreach (RefTuple<int, float, double> tuple in scene.Query<With<int>, With<float>, With<double>>().Enumerate<int, float, double>())
            {
                Console.WriteLine($"Values -> int={tuple.Item1.Value}, float={tuple.Item2.Value}, double={tuple.Item3.Value}");
            }
        }
    }
}