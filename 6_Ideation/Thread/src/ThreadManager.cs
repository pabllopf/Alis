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
using System.Threading.Tasks;

namespace Alis.Core.Aspect.Thread
{
    /// <summary>
    /// The thread manager class
    /// </summary>
    public class ThreadManager
    {
        /// <summary>
        /// The cancellation token source
        /// </summary>
        private Dictionary<ThreadTask, CancellationTokenSource> threadTokens = new Dictionary<ThreadTask, CancellationTokenSource>();
        
        /// <summary>
        /// Starts the thread using the specified thread task
        /// </summary>
        /// <param name="threadTask">The thread task</param>
        public void StartThread(ThreadTask threadTask)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            threadTokens.Add(threadTask, cts);
            Task.Run(() => threadTask.Execute(cts.Token), cts.Token);
        }

        /// <summary>
        /// Stops the thread using the specified thread task
        /// </summary>
        /// <param name="threadTask">The thread task</param>
        public void StopThread(ThreadTask threadTask)
        {
            if (threadTokens.TryGetValue(threadTask, out CancellationTokenSource cts))
            {
                cts.Cancel();
                threadTokens.Remove(threadTask);
            }
        }

        /// <summary>
        /// Stops the all threads
        /// </summary>
        public void StopAllThreads()
        {
            foreach (CancellationTokenSource cts in threadTokens.Values)
            {
                cts.Cancel();
            }
            threadTokens.Clear();
        }

        /// <summary>
        /// Gets the thread count
        /// </summary>
        /// <returns>The int</returns>
        public int GetThreadCount()
        {
            return threadTokens.Count;
        }
    }
}