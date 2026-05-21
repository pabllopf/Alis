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


using System;
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Execution;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The thread manager test class
    /// </summary>
    public class ThreadManagerTest
    {
        /// <summary>
        ///     Tests that constructor with default configuration creates valid manager
        /// </summary>
        [Fact]
        public void Constructor_WithDefaultConfiguration_CreatesValidManager()
        {
            using (ThreadManager manager = new ThreadManager())
            {
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }

        /// <summary>
        ///     Tests that constructor with custom configuration creates valid manager
        /// </summary>
        [Fact]
        public void Constructor_WithCustomConfiguration_CreatesValidManager()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfigurationBuilder()
                .WithParallelExecution(true)
                .WithMaxDegreeOfParallelism(4)
                .Build();

            using (ThreadManager manager = new ThreadManager(config))
            {
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }

        /// <summary>
        ///     Tests that constructor with null configuration throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ThreadManager(null));
        }

        /// <summary>
        ///     Tests that parallel executor property returns valid executor
        /// </summary>
        [Fact]
        public void ParallelExecutor_ReturnsValidExecutor()
        {
            using (ThreadManager manager = new ThreadManager())
            {
                ParallelUpdateExecutor executor = manager.ParallelExecutor;

                Assert.NotNull(executor);
            }
        }


        /// <summary>
        ///     Tests that dispose can be called multiple times safely
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            ThreadManager manager = new ThreadManager();

            manager.Dispose();
            manager.Dispose();
            manager.Dispose();

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that manager can execute parallel work
        /// </summary>
        [Fact]
        public void ThreadManager_CanExecuteParallelWork()
        {
            using (ThreadManager manager = new ThreadManager())
            {
                int[] data = new int[1000];

                manager.ParallelExecutor.ExecuteUpdate(data.Length, (start, length) =>
                {
                    for (int i = start; i < start + length; i++)
                    {
                        data[i] = i * 2;
                    }
                }, true, 64);

                for (int i = 0; i < data.Length; i++)
                {
                    Assert.Equal(i * 2, data[i]);
                }
            }
        }

        /// <summary>
        ///     Tests that manager with disabled parallelism works
        /// </summary>
        [Fact]
        public void ThreadManager_WithDisabledParallelism_ExecutesSequentially()
        {
            ParallelExtensionConfiguration config = new ParallelExtensionConfigurationBuilder()
                .WithParallelExecution(false)
                .Build();

            using (ThreadManager manager = new ThreadManager(config))
            {
                int[] data = new int[100];

                manager.ParallelExecutor.ExecuteUpdate(data.Length, (start, length) =>
                {
                    for (int i = start; i < start + length; i++)
                    {
                        data[i] = i;
                    }
                });

                for (int i = 0; i < data.Length; i++)
                {
                    Assert.Equal(i, data[i]);
                }
            }
        }
    }
}