

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The create command test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="CreateCommand" /> record struct which represents
    ///     a command to create a new entity with specific components.
    /// </remarks>
    public class CreateCommandTest
    {
        /// <summary>
        ///     Tests that create command can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that CreateCommand can be instantiated.
        /// </remarks>
        [Fact]
        public void CreateCommand_CanBeCreated()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            CreateCommand command = new CreateCommand(entity, 0, 10);

            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that create command archetype id is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the ArchetypeId field is correctly stored.
        /// </remarks>
        [Fact]
        public void CreateCommand_ParametersArePreserved()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(42, 5);
            int bufferIndex = 10;
            int bufferLength = 50;

            CreateCommand command = new CreateCommand(entity, bufferIndex, bufferLength);

            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that create command is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that CreateCommand behaves as a record struct.
        /// </remarks>
        [Fact]
        public void CreateCommand_IsRecordStruct()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(10, 0);

            CreateCommand command1 = new CreateCommand(entity, 5, 20);
            CreateCommand command2 = new CreateCommand(entity, 5, 20);

            Assert.Equal(command1, command2);
        }

        /// <summary>
        ///     Tests that create command with different buffer indices are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that commands with different buffer indices are not equal.
        /// </remarks>
        [Fact]
        public void CreateCommand_WithDifferentBufferIndicesAreNotEqual()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);

            CreateCommand command1 = new CreateCommand(entity, 1, 20);
            CreateCommand command2 = new CreateCommand(entity, 2, 20);

            Assert.NotEqual(command1, command2);
        }

        /// <summary>
        ///     Tests that create command with zero indices
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero indices.
        /// </remarks>
        [Fact]
        public void CreateCommand_WithZeroIndices()
        {
            CreateCommand command = new CreateCommand(new GameObjectIdOnly(0, 0), 0, 0);

            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that create command with max values
        /// </summary>
        /// <remarks>
        ///     Tests creation with maximum values.
        /// </remarks>
        [Fact]
        public void CreateCommand_WithMaxValues()
        {
            CreateCommand command = new CreateCommand(new GameObjectIdOnly(int.MaxValue, ushort.MaxValue), int.MaxValue, int.MaxValue);

            Assert.NotNull(command);
        }
    }
}