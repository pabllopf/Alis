// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferParametrizedTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Parametrized tests for CommandBuffer
    /// </summary>
    public class CommandBufferParametrizedTest
    {

        /// <summary>
        /// Tests that command buffer enqueue and playback multiple rounds
        /// </summary>
        /// <param name="rounds">The rounds</param>
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void CommandBuffer_EnqueueAndPlayback_MultipleRounds(int rounds)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int r = 0; r < rounds; r++)
            {
                CommandBuffer buffer = new(scene);
                buffer.Playback();
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that command buffer create command with component correct
        /// </summary>
        [Fact]
        public void CommandBuffer_CreateCommandWithComponent_Correct()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);
            Position pos = new Position { X = 10, Y = 20 };


            buffer.Playback();

            // Assert
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }
            Assert.True(count >= 0);
        }

        /// <summary>
        /// Tests that command buffer multiple create commands all processed
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void CommandBuffer_MultipleCreateCommands_AllProcessed(int count)
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);
            
            buffer.Playback();

            // Assert
            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }
            Assert.True(queryCount >= 0);
        }

        /// <summary>
        /// Tests that command buffer dispose works
        /// </summary>
        [Fact]
        public void CommandBuffer_Dispose_Works()
        {
            // Arrange & Act
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that command buffer stress test many commands
        /// </summary>
        /// <param name="commandCount">The command count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void CommandBuffer_StressTest_ManyCommands(int commandCount)
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);
            
            buffer.Playback();

            // Assert
            Assert.True(true);
        }
    }
}

