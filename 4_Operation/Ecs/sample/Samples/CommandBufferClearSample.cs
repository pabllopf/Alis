// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferClearSample.cs
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
    ///     The command buffer clear sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class CommandBufferClearSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "command-buffer-clear";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Command Buffer Clear";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Queues commands, clears the buffer, and inspects playback behavior.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(12);

            buffer.AddComponent(entity, "queued but cleared");
            buffer.RemoveComponent<int>(entity);

            Console.WriteLine($"Has buffered changes before Clear: {buffer.HasBufferItems}");
            buffer.Clear();
            Console.WriteLine($"Has buffered changes after Clear:  {buffer.HasBufferItems}");

            bool applied = buffer.Playback();
            Console.WriteLine($"Playback applied changes: {applied}");
            Console.WriteLine($"Entity still has int: {entity.Has<int>()}");
            Console.WriteLine($"Entity has string: {entity.Has<string>()}");
            Console.WriteLine("Use this sample to validate buffer semantics in your current ECS version.");
        }
    }
}