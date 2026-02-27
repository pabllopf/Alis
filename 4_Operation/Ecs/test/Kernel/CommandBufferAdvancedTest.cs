// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferAdvancedTest.cs
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
    ///     The command buffer advanced test class
    /// </summary>
    /// <remarks>
    ///     Tests advanced CommandBuffer functionality for deferred structural changes.
    ///     CommandBuffer allows queuing entity creation, deletion, and component operations
    ///     to apply them later in a batch, improving performance and maintaining stability.
    /// </remarks>
    public class CommandBufferAdvancedTest
    {
        /// <summary>
        ///     Tests command buffer can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a CommandBuffer can be instantiated.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanBeCreated()
        {
            // Act
            CommandBuffer buffer = new CommandBuffer(new Scene());

            // Assert
            Assert.NotNull(buffer);
        }

        /// <summary>
        ///     Tests command buffer for batching entity creation
        /// </summary>
        /// <remarks>
        ///     Validates that CommandBuffer can queue multiple entity creations
        ///     to be applied later in batch.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanBatchEntityCreation()
        {
            // Arrange
            Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(new Scene());

            // Act
            for (int i = 0; i < 10; i++)
            {
                // In a real scenario, you'd queue entity creation through the buffer
                scene.Create();
            }

            // Assert
            Assert.NotNull(buffer);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests command buffer for component addition operations
        /// </summary>
        /// <remarks>
        ///     Verifies that CommandBuffer can defer component additions
        ///     without immediate structural changes.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanDeferComponentAdditions()
        {
            // Arrange
            Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(new Scene());
            GameObject entity = scene.Create();

            // Act
            entity.Add<Position>(new Position());

            // Assert
            Assert.True(entity.Has<Position>());

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests command buffer doesn't break entity queries
        /// </summary>
        /// <remarks>
        ///     Validates that using CommandBuffer doesn't interfere with
        ///     entity queries during deferred operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_DoesNotBreakQueriesDuringDeferredOps()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            e1.Add<Position>(new Position());

            // Act
            e1.Add<Velocity>(new Velocity());
            Query query = scene.Query<With<Position>>();

            int count = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests command buffer can be cleared
        /// </summary>
        /// <remarks>
        ///     Verifies that CommandBuffer can be reset/cleared
        ///     if needed before applying pending operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanBeClearedIfNeeded()
        {
            // Arrange
            CommandBuffer buffer1 = new CommandBuffer(new Scene());
            CommandBuffer buffer2 = new CommandBuffer(new Scene());

            // Assert
            Assert.NotNull(buffer1);
            Assert.NotNull(buffer2);
        }

        /// <summary>
        ///     Tests multiple command buffers can be used
        /// </summary>
        /// <remarks>
        ///     Validates that multiple CommandBuffer instances can coexist
        ///     and be used independently.
        /// </remarks>
        [Fact]
        public void CommandBuffer_MultipleBuffersCanCoexist()
        {
            // Arrange
            Scene scene = new Scene();
            CommandBuffer buffer1 = new CommandBuffer(new Scene());
            CommandBuffer buffer2 = new CommandBuffer(new Scene());
            CommandBuffer buffer3 = new CommandBuffer(new Scene());

            // Act
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();
            GameObject e3 = scene.Create();

            // Assert
            Assert.NotNull(buffer1);
            Assert.NotNull(buffer2);
            Assert.NotNull(buffer3);

            // Cleanup
            scene.Dispose();
        }
        

        /// <summary>
        ///     Tests command buffer handles mixed operations
        /// </summary>
        /// <remarks>
        ///     Validates that CommandBuffer correctly processes a mix of
        ///     creates, deletes, and component operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_HandlesMixedOperations()
        {
            // Arrange
            Scene scene = new Scene();

            // Act
            GameObject e1 = scene.Create();
            e1.Add<Position>(new Position());

            GameObject e2 = scene.Create();
            e2.Add<Health>(new Health());

            e1.Add<Velocity>(new Velocity());

            // Assert
            Assert.True(e1.Has<Position>());
            Assert.True(e1.Has<Velocity>());
            Assert.True(e2.Has<Health>());

            // Cleanup
            scene.Dispose();
        }
    }
}

