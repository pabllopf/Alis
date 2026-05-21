// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleGameLoopSample.cs
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
using System.Threading;
using Alis.Core.Ecs.Sample.Components;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The simple game loop sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class SimpleGameLoopSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "simple-game";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Simple Game Loop";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Runs a tiny update loop with Position and Velocity components.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            GameObject player = scene.Create(new Position(4, 2), new Velocity(1, 0));

            for (int frame = 0; frame < 10; frame++)
            {
                scene.Update();
                Position framePosition = player.Get<Position>();
                Console.WriteLine($"Frame {frame + 1}: X={framePosition.X}, Y={framePosition.Y}");
                Thread.Sleep(40);
            }

            Position finalPosition = player.Get<Position>();
            Console.WriteLine($"Final player position: X={finalPosition.X}, Y={finalPosition.Y}");
        }
    }
}