// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplePriorityQueueTryExample.cs
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
    ///     Demonstrates the Try* methods to avoid exceptions in concurrent-style code.
    /// </summary>
    public static class SimplePriorityQueueTryExample
    {
        /// <summary>
        ///     Runs the example.
        /// </summary>
        public static void RunExample()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("low", 10);
            queue.Enqueue("high", 1);

            if (queue.TryFirst(out string first))
            {
                Logger.Info($"First item: {first}");
            }

            bool updated = queue.TryUpdatePriority("low", 0);
            Logger.Info($"TryUpdatePriority(low -> 0): {updated}");

            while (queue.TryDequeue(out string value))
            {
                Logger.Info($"Dequeued: {value}");
            }

            bool removedMissing = queue.TryRemove("missing");
            Logger.Info($"TryRemove(missing): {removedMissing}");
        }
    }
}

