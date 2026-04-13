// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StablePriorityQueueExample.cs
// 
//  Author:Pablo Perdomo Falcon
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

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     Demonstrates FIFO behavior for equal priorities in StablePriorityQueue.
    /// </summary>
    public static class StablePriorityQueueExample
    {
        /// <summary>
        ///     Runs the example.
        /// </summary>
        public static void RunExample()
        {
            StablePriorityQueue<Job> queue = new StablePriorityQueue<Job>(10);

            Job first = new Job("first", "Generate thumbnails");
            Job second = new Job("second", "Upload metadata");
            Job third = new Job("third", "Send notifications");

            queue.Enqueue(first, 5f);
            queue.Enqueue(second, 5f);
            queue.Enqueue(third, 5f);

            while (queue.Count > 0)
            {
                Job next = queue.Dequeue();
                Logger.Info($"[{next.Id}] {next.Description}");
            }
        }

        /// <summary>
        ///     Simple payload node used by this sample.
        /// </summary>
        public sealed class Job : StablePriorityQueueNode
        {
            public Job(string id, string description)
            {
                Id = id;
                Description = description;
            }

            public string Id { get; }

            public string Description { get; }
        }
    }
}

