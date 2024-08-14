// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplePriorityQueueExample.cs
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

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     The simple priority queue example class
    /// </summary>
    public static class SimplePriorityQueueExample
    {
        /// <summary>
        ///     Runs the example
        /// </summary>
        public static void RunExample()
        {
            //First, we create the priority queue.
            SimplePriorityQueue<string> priorityQueue = new SimplePriorityQueue<string>();
            
            //Now, let's add them all to the queue (in some arbitrary order)!
            priorityQueue.Enqueue("4 - Joseph", 4);
            priorityQueue.Enqueue("2 - Tyler", 0); //Note: Priority = 0 right now!
            priorityQueue.Enqueue("1 - Jason", 1);
            priorityQueue.Enqueue("4 - Ryan", 4);
            priorityQueue.Enqueue("3 - Valerie", 3);
            
            //Change one of the string's priority to 2.  Since this string is already in the priority queue, we call UpdatePriority() to do this
            priorityQueue.UpdatePriority("2 - Tyler", 2);
            
            //Finally, we'll dequeue all the strings and print them out
            while (priorityQueue.Count != 0)
            {
                string nextUser = priorityQueue.Dequeue();
                Logger.Info(nextUser);
            }
            
            //Output:
            //1 - Jason
            //2 - Tyler
            //3 - Valerie
            //4 - Joseph
            //4 - Ryan
            
            //Notice that when two strings with the same priority were enqueued, they were dequeued in the same order that they were enqueued.
        }
    }
}