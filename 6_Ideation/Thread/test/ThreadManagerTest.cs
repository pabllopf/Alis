// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ThreadManagerTest.cs
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

using System.Threading;
using Xunit;

namespace Alis.Core.Aspect.Thread.Test
{
    /// <summary>
    ///     The thread manager test class
    /// </summary>
    public class ThreadManagerTest
    {
        /// <summary>
        ///     Tests that start thread should start new thread
        /// </summary>
        [Fact]
        public void StartThread_ShouldStartNewThread()
        {
            // Arrange
            ThreadManager threadManager = new ThreadManager();
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadTask threadTask = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(10); // Task that sleeps for 1 second
                }
            }, cts.Token);

            // Act
            threadManager.StartThread(threadTask);

            //wait 1s
            System.Threading.Thread.Sleep(100);

            Assert.Equal(1, threadManager.GetThreadCount());

            // stop the thread
            threadManager.StopAllThreads();

            // Assert
            Assert.Equal(0, threadManager.GetThreadCount());
        }

        /// <summary>
        ///     Tests that stop all threads should stop all threads
        /// </summary>
        [Fact]
        public void StopAllThreads_ShouldStopAllThreads()
        {
            // Arrange
            ThreadManager threadManager = new ThreadManager();
            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask threadTask1 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(15); // Task that sleeps for 1 second
                }
            }, cts1.Token);

            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask threadTask2 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(120); // Task that sleeps for 1 second
                }
            }, cts2.Token);

            // Act
            threadManager.StartThread(threadTask1);
            threadManager.StartThread(threadTask2);

            System.Threading.Thread.Sleep(10); // Wait for threads to start

            threadManager.StopAllThreads();

            // Assert
            Assert.Equal(0, threadManager.GetThreadCount());
        }


        /// <summary>
        ///     Tests that get thread count should return correct count
        /// </summary>
        [Fact]
        public void GetThreadCount_ShouldReturnCorrectCount()
        {
            // Arrange
            ThreadManager threadManager = new ThreadManager();
            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask threadTask1 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(12); // Task that sleeps for 1 second
                }
            }, cts1.Token);

            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask threadTask2 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts2.Token);

            // Act
            threadManager.StartThread(threadTask1);
            threadManager.StartThread(threadTask2);

            // wait the threads to end
            System.Threading.Thread.Sleep(19);

            Assert.Equal(2, threadManager.GetThreadCount());

            //end the threads
            threadManager.StopAllThreads();

            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.Equal(0, threadManager.GetThreadCount());
        }

        /// <summary>
        ///     Tests that start thread v 2 should start new thread
        /// </summary>
        [Fact]
        public void StartThread_v2_ShouldStartNewThread()
        {
            // Arrange
            ThreadManager manager = new ThreadManager();
            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask threadTask2 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts2.Token);

            // Act
            manager.StartThread(threadTask2);

            //wait 1s
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.Equal(1, manager.GetThreadCount());

            // stop the thread
            manager.StopAllThreads();

            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.Equal(0, manager.GetThreadCount());
        }

        /// <summary>
        ///     Tests that stop thread should stop specific thread
        /// </summary>
        [Fact]
        public void StopThread_ShouldStopSpecificThread()
        {
            // Arrange
            ThreadManager manager = new ThreadManager();
            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask threadTask2 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts2.Token);

            // Act
            manager.StartThread(threadTask2);

            // Act
            manager.StopThread(threadTask2);

            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.Equal(0, manager.GetThreadCount());
        }

        /// <summary>
        ///     Tests that stop all threads v 2 should stop all threads
        /// </summary>
        [Fact]
        public void StopAllThreads_v2_ShouldStopAllThreads()
        {
            // Arrange
            ThreadManager manager = new ThreadManager();

            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask threadTask1 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts1.Token);

            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask threadTask2 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts2.Token);

            manager.StartThread(threadTask1);
            manager.StartThread(threadTask2);

            // Act
            manager.StopAllThreads();

            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.Equal(0, manager.GetThreadCount());
        }

        /// <summary>
        ///     Tests that get thread count should return correct thread count
        /// </summary>
        [Fact]
        public void GetThreadCount_ShouldReturnCorrectThreadCount()
        {
            // Arrange
            ThreadManager manager = new ThreadManager();

            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask threadTask1 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts1.Token);

            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask threadTask2 = new ThreadTask(token =>
            {
                while (!token.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(13); // Task that sleeps for 1 second
                }
            }, cts2.Token);

            manager.StartThread(threadTask1);
            manager.StartThread(threadTask2);

            Assert.Equal(2, manager.GetThreadCount());

            // Act
            manager.StopThread(threadTask1);
            manager.StopThread(threadTask2);

            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.Equal(0, manager.GetThreadCount());
        }
    }
}