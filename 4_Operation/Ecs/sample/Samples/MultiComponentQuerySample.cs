// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MultiComponentQuerySample.cs
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
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The multi component query sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class MultiComponentQuerySample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "multi-query";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Multi-Component Query";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Queries Position + Velocity at once and writes updated positions.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(new Position(0, 0), new Velocity(1, 1));
            scene.Create(new Position(10, 5), new Velocity(-1, 2));
            scene.Create(new Position(4, 8));

            foreach (RefTuple<Position, Velocity> tuple in scene.Query<With<Position>, With<Velocity>>().Enumerate<Position, Velocity>())
            {
                Ref<Position> position = tuple.Item1;
                Ref<Velocity> velocity = tuple.Item2;
                position.Value.X += velocity.Value.DX;
                position.Value.Y += velocity.Value.DY;
            }

            Console.WriteLine("Positions after query-based movement:");
            int index = 1;
            foreach (RefTuple<Position> tuple in scene.Query<With<Position>>().Enumerate<Position>())
            {
                Ref<Position> position = tuple.Item1;
                Console.WriteLine($"Entity {index++}: X={position.Value.X}, Y={position.Value.Y}");
            }
        }
    }
}