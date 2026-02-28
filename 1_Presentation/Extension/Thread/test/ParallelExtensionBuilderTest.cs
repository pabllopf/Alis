// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExtensionBuilderTest.cs
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

using Alis.Extension.Thread.Builder;
using Alis.Extension.Thread.Integration;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel extension builder test class
    /// </summary>
    public class ParallelExtensionBuilderTest
    {
        /// <summary>
        ///     Tests that build manager creates valid manager
        /// </summary>
        [Fact]
        public void BuildManager_CreatesValidManager()
        {
            // Arrange
            ParallelExtensionBuilder builder = ParallelExtensionBuilder.Create();

            // Act
            using (ThreadManager manager = builder
                       .EnableParallelExecution()
                       .WithMaxThreads(4)
                       .BuildManager())
            {
                // Assert
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }

        /// <summary>
        ///     Tests that build parallelizer creates valid parallelizer
        /// </summary>
        [Fact]
        public void BuildParallelizer_CreatesValidParallelizer()
        {
            // Arrange
            ParallelExtensionBuilder builder = ParallelExtensionBuilder.Create();

            // Act
            ComponentUpdateParallelizer parallelizer = builder
                .EnableParallelExecution()
                .WithAutoThreadCount()
                .BuildParallelizer();

            // Assert
            Assert.NotNull(parallelizer);
        }

        /// <summary>
        ///     Tests that fluent interface works correctly
        /// </summary>
        [Fact]
        public void FluentInterface_WorksCorrectly()
        {
            // Arrange & Act
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .EnableParallelExecution()
                       .WithMaxThreads(2)
                       .WithMinBatchSize(32)
                       .BuildManager())
            {
                // Assert
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }

        /// <summary>
        ///     Tests that disable parallel execution creates manager with disabled parallelism
        /// </summary>
        [Fact]
        public void DisableParallelExecution_CreatesManagerWithDisabledParallelism()
        {
            // Arrange & Act
            using (ThreadManager manager = ParallelExtensionBuilder.Create()
                       .DisableParallelExecution()
                       .BuildManager())
            {
                // Assert
                Assert.NotNull(manager);
                Assert.NotNull(manager.ParallelExecutor);
            }
        }
    }
}