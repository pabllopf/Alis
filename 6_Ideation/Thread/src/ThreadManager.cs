// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ThreadManager.cs
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

using System.Collections.Generic;
using System.Threading;

namespace Alis.Core.Aspect.Thread
{
    /// <summary>
    /// The thread manager class
    /// </summary>
    public class ThreadManager
    {
        /// <summary>
        /// The thread
        /// </summary>
        private readonly List<System.Threading.Thread> threads = new List<System.Threading.Thread>();

        /// <summary>
        /// Starts the thread using the specified task
        /// </summary>
        /// <param name="task">The task</param>
        public void StartThread(ThreadTask task)
        {
            System.Threading.Thread thread = new System.Threading.Thread(new ThreadStart(task.Execute));
            threads.Add(thread);
            thread.Start();
        }

        /// <summary>
        /// Stops the all threads
        /// </summary>
        public void StopAllThreads()
        {
            foreach (System.Threading.Thread thread in threads)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }

            threads.Clear();
        }
    }
}