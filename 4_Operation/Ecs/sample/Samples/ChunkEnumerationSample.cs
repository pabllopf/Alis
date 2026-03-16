// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkEnumerationSample.cs
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
using Alis.Core.Ecs.Sample.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The chunk enumeration sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class ChunkEnumerationSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "chunk-query";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Chunk Enumeration";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Updates component data in chunks using EnumerateChunks.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(new Position(0, 0), new Velocity(1, 2));
            scene.Create(new Position(3, 4), new Velocity(2, 3));
            scene.Create(new Position(8, 9), new Velocity(-1, 1));

            foreach (ChunkTuple<Position, Velocity> chunk in scene.Query<With<Position>, With<Velocity>>().EnumerateChunks<Position, Velocity>())
            {
                Span<Position> positions = chunk.Span1;
                Span<Velocity> velocities = chunk.Span2;

                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i].X += velocities[i].DX;
                    positions[i].Y += velocities[i].DY;
                }
            }

            Console.WriteLine("Positions after chunk update:");
            foreach (RefTuple<Position> tuple in scene.Query<With<Position>>().Enumerate<Position>())
            {
                Console.WriteLine($"X={tuple.Item1.Value.X}, Y={tuple.Item1.Value.Y}");
            }
        }
    }
}