// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueExample.cs
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
using System;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     Demonstrates GenericPriorityQueue with a custom comparer and non-float priorities.
    /// </summary>
    public static class GenericPriorityQueueExample
    {
        /// <summary>
        ///     Runs the example.
        /// </summary>
        public static void RunExample()
        {
            GenericPriorityQueue<BuildTask, DateTime> queue =
                new GenericPriorityQueue<BuildTask, DateTime>(10, (left, right) => left.CompareTo(right));

            DateTime now = DateTime.UtcNow;
            queue.Enqueue(new BuildTask("Compile gameplay"), now.AddMinutes(20));
            queue.Enqueue(new BuildTask("Generate docs"), now.AddMinutes(10));
            queue.Enqueue(new BuildTask("Run tests"), now.AddMinutes(10));

            while (queue.Count > 0)
            {
                BuildTask next = queue.Dequeue();
                Logger.Info(next.Name);
            }
        }

        /// <summary>
        ///     Simple payload node used by this sample.
        /// </summary>
        public sealed class BuildTask : GenericPriorityQueueNode<DateTime>
        {
            public BuildTask(string name) => Name = name;

            public string Name { get; }
        }
    }
}

