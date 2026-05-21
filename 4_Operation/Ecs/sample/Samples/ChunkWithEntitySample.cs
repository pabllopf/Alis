// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkWithEntitySample.cs
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
    ///     The chunk with entity sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class ChunkWithEntitySample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "chunk-entities";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Chunk Enumeration By Index";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Processes paired chunk spans using index-based access.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            scene.Create(new Position(0, 0), new Velocity(1, 0));
            scene.Create(new Position(2, 2), new Velocity(0, 1));
            scene.Create(new Position(5, 5), new Velocity(-1, -1));

            foreach (ChunkTuple<Position, Velocity> chunk in scene.Query<With<Position>, With<Velocity>>().EnumerateChunks<Position, Velocity>())
            {
                for (int localIndex = 0; localIndex < chunk.Span1.Length; localIndex++)
                {
                    chunk.Span1[localIndex].X += chunk.Span2[localIndex].DX;
                    chunk.Span1[localIndex].Y += chunk.Span2[localIndex].DY;
                    Console.WriteLine($"Chunk item {localIndex + 1}: X={chunk.Span1[localIndex].X}, Y={chunk.Span1[localIndex].Y}");
                }
            }
        }
    }
}