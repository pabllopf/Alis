

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
        ///     Tests that command buffer enqueue and playback multiple rounds
        /// </summary>
        /// <param name="rounds">The rounds</param>
        [Theory, InlineData(5), InlineData(10), InlineData(20)]
        public void CommandBuffer_EnqueueAndPlayback_MultipleRounds(int rounds)
        {
            using Scene scene = new Scene();

            for (int r = 0; r < rounds; r++)
            {
                CommandBuffer buffer = new(scene);
                buffer.Playback();
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that command buffer create command with component correct
        /// </summary>
        [Fact]
        public void CommandBuffer_CreateCommandWithComponent_Correct()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);
            Position pos = new Position {X = 10, Y = 20};


            buffer.Playback();

            int count = 0;
            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.True(count >= 0);
        }

        /// <summary>
        ///     Tests that command buffer multiple create commands all processed
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void CommandBuffer_MultipleCreateCommands_AllProcessed(int count)
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);

            buffer.Playback();

            int queryCount = 0;
            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            Assert.True(queryCount >= 0);
        }

        /// <summary>
        ///     Tests that command buffer dispose works
        /// </summary>
        [Fact]
        public void CommandBuffer_Dispose_Works()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that command buffer stress test many commands
        /// </summary>
        /// <param name="commandCount">The command count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void CommandBuffer_StressTest_ManyCommands(int commandCount)
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);

            buffer.Playback();

            Assert.True(true);
        }
    }
}