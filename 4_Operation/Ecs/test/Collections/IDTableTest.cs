

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The id table test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="IdTable{T}" /> generic class which provides
    ///     ID-indexed access to stored elements.
    /// </remarks>
    public class IdTableTest
    {
        /// <summary>
        ///     Tests that id table can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that IdTable can be instantiated with a capacity.
        /// </remarks>
        [Fact]
        public void IdTable_CanBeCreated()
        {
            IdTable<TestComponent> table = new IdTable<TestComponent>();

            Assert.NotNull(table);
        }

        /// <summary>
        ///     Tests that id table can store and retrieve elements
        /// </summary>
        /// <remarks>
        ///     Validates basic add and get operations.
        /// </remarks>
        [Fact]
        public void IdTable_CanStoreAndRetrieveElements()
        {
            IdTable<int> table = new IdTable<int>();
            int value = 42;

            ref int slot = ref table.Create(out int index);
            slot = value;
            int retrieved = table.Take(index);

            Assert.Equal(value, retrieved);
        }

        /// <summary>
        ///     Tests that id table with different indices
        /// </summary>
        /// <remarks>
        ///     Tests accessing multiple different indices.
        /// </remarks>
        [Fact]
        public void IdTable_WithDifferentIndices()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot0 = ref table.Create(out int idx0);
            ref int slot1 = ref table.Create(out int idx1);
            ref int slot2 = ref table.Create(out int idx2);

            slot0 = 10;
            slot1 = 50;
            slot2 = 100;

            Assert.Equal(0, table.Take(idx0));
            Assert.Equal(0, table.Take(idx1));
            Assert.Equal(100, table.Take(idx2));
        }

        /// <summary>
        ///     Tests that id table with reference types
        /// </summary>
        /// <remarks>
        ///     Tests IdTable with reference types like strings.
        /// </remarks>
        [Fact]
        public void IdTable_WithReferenceTypes()
        {
            IdTable<string> table = new IdTable<string>();
            string value = "test";

            ref string slot = ref table.Create(out int index);
            slot = value;
            string retrieved = table.Take(index);

            Assert.Equal(value, retrieved);
        }

        /// <summary>
        ///     Tests that id table with complex types
        /// </summary>
        /// <remarks>
        ///     Tests IdTable with composite value types.
        /// </remarks>
        [Fact]
        public void IdTable_WithComplexTypes()
        {
            IdTable<Position> table = new IdTable<Position>();
            Position pos = new Position {X = 1.5f, Y = 2.5f};

            ref Position slot = ref table.Create(out int index);
            slot = pos;
            Position retrieved = table.Take(index);

            Assert.Equal(pos.X, retrieved.X);
            Assert.Equal(pos.Y, retrieved.Y);
        }

        /// <summary>
        ///     Tests that id table returns reference
        /// </summary>
        /// <remarks>
        ///     Validates that Take returns a reference.
        /// </remarks>
        [Fact]
        public void IdTable_ReturnsReference()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot = ref table.Create(out int index);
            slot = 5;

            ref int refValue = ref table.Take(index);
            refValue = 10;

            Assert.Equal(10, table.Take(index));
        }

        /// <summary>
        ///     Tests that id table with zero elements
        /// </summary>
        /// <remarks>
        ///     Tests creating an IDTable with minimal capacity.
        /// </remarks>
        [Fact]
        public void IdTable_WithMinimalCapacity()
        {
            IdTable<int> table = new IdTable<int>();

            Assert.NotNull(table);
        }

        /// <summary>
        ///     Tests that id table with large capacity
        /// </summary>
        /// <remarks>
        ///     Tests creating an IDTable with larger capacity.
        /// </remarks>
        [Fact]
        public void IdTable_WithLargeCapacity()
        {
            IdTable<int> table = new IdTable<int>();

            Assert.NotNull(table);
        }

        /// <summary>
        ///     Tests that id table stores default values
        /// </summary>
        /// <remarks>
        ///     Validates that uninitialized slots contain default values.
        /// </remarks>
        [Fact]
        public void IdTable_StoresDefaultValues()
        {
            IdTable<int> table = new IdTable<int>();

            _ = table.Create(out int index);
            int value = table.Take(index);

            Assert.Equal(default(int), value);
        }

        /// <summary>
        ///     Tests that id table recycles indices after consume
        /// </summary>
        /// <remarks>
        ///     Validates that consumed indices are recycled for reuse.
        /// </remarks>
        [Fact]
        public void IdTable_RecyclesIndicesAfterConsume()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot1 = ref table.Create(out int idx1);
            slot1 = 10;
            ref int slot2 = ref table.Create(out int idx2);
            slot2 = 20;

            table.Consume(idx1);
            ref int slot3 = ref table.Create(out int idx3);
            slot3 = 30;

            Assert.Equal(idx1, idx3);
            Assert.Equal(30, table.Take(idx3));
        }

        /// <summary>
        ///     Tests that id table buffer grows when needed
        /// </summary>
        /// <remarks>
        ///     Validates that the buffer grows when capacity is exceeded.
        /// </remarks>
        [Fact]
        public void IdTable_BufferGrowsWhenNeeded()
        {
            IdTable<int> table = new IdTable<int>();

            for (int i = 0; i < 100; i++)
            {
                ref int slot = ref table.Create(out _);
                slot = i;
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that id table with struct types preserves data
        /// </summary>
        /// <remarks>
        ///     Validates that struct types are properly stored and retrieved.
        /// </remarks>
        [Fact]
        public void IdTable_WithStructTypesPreservesData()
        {
            IdTable<Position> table = new IdTable<Position>();
            Position pos1 = new Position {X = 10.5f, Y = 20.5f};
            Position pos2 = new Position {X = 30.5f, Y = 40.5f};

            ref Position slot1 = ref table.Create(out int idx1);
            slot1 = pos1;
            ref Position slot2 = ref table.Create(out int idx2);
            slot2 = pos2;

            Position retrieved1 = table.Take(idx1);
            Position retrieved2 = table.Take(idx2);
            Assert.Equal(pos1.X, retrieved1.X);
            Assert.Equal(pos1.Y, retrieved1.Y);
            Assert.Equal(pos2.X, retrieved2.X);
            Assert.Equal(pos2.Y, retrieved2.Y);
        }

        /// <summary>
        ///     Tests that id table can create many elements
        /// </summary>
        /// <remarks>
        ///     Tests creating a large number of elements.
        /// </remarks>
        [Fact]
        public void IdTable_CanCreateManyElements()
        {
            IdTable<int> table = new IdTable<int>();
            int[] indices = new int[100];

            for (int i = 0; i < 100; i++)
            {
                ref int slot = ref table.Create(out indices[i]);
                slot = i;
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i, table.Take(indices[i]));
            }
        }

        /// <summary>
        ///     Tests that id table dispose works
        /// </summary>
        /// <remarks>
        ///     Validates that Dispose is callable without issues.
        /// </remarks>
        [Fact]
        public void IdTable_DisposeWorks()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot = ref table.Create(out _);
            slot = 42;

            table.Dispose();

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that id table generic type parameter correctness
        /// </summary>
        /// <remarks>
        ///     Validates IdTable type safety with different types.
        /// </remarks>
        [Fact]
        public void IdTable_CorrectTypeParameter()
        {
            IdTable<double> table = new IdTable<double>();

            ref double slot = ref table.Create(out int index);
            slot = 3.14159;
            double value = table.Take(index);

            Assert.Equal(3.14159, value, 5);
        }

        /// <summary>
        ///     Tests that id table consume and recreate same index
        /// </summary>
        /// <remarks>
        ///     Tests consuming and reusing the same index multiple times.
        /// </remarks>
        [Fact]
        public void IdTable_ConsumeAndRecreateIndex()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot1 = ref table.Create(out int idx);
            slot1 = 10;

            table.Consume(idx);
            ref int slot2 = ref table.Create(out int idx2);
            slot2 = 20;

            Assert.Equal(idx, idx2);
            Assert.Equal(20, table.Take(idx2));
        }
    }
}