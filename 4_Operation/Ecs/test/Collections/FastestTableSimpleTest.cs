

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Simple tests for FastestTable to validate dynamic resizing behavior.
    /// </summary>
    public class FastestTableSimpleTest
    {
        /// <summary>
        ///     Test that FastestTable automatically expands when accessing beyond capacity.
        /// </summary>
        [Fact]
        public void Index_BeyondCapacity_AutomaticallyExpands()
        {
            FastestTable<int> table = new FastestTable<int>(10);

            ref int value = ref table[100];
            value = 42;

            Assert.Equal(42, table[100]);
            Assert.True(table._buffer.Length > 100);
        }

        /// <summary>
        ///     Test that FastestTable handles consecutive reads and writes correctly.
        /// </summary>
        [Fact]
        public void ReadWrite_ConsecutiveOperations_DataConsistent()
        {
            FastestTable<string> table = new FastestTable<string>(50);

            for (int i = 0; i < 100; i++)
            {
                ref string str = ref table[i];
                str = $"Value_{i}";
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.Equal($"Value_{i}", table[i]);
            }
        }

        /// <summary>
        ///     Test that FastestTable properly handles sparse index access.
        /// </summary>
        [Fact]
        public void Index_SparseAccess_AllIndexesAccessible()
        {
            FastestTable<long> table = new FastestTable<long>(10);
            int[] sparseIndices = {5, 50, 500, 5000};

            for (int i = 0; i < sparseIndices.Length; i++)
            {
                ref long val = ref table[sparseIndices[i]];
                val = (long) sparseIndices[i] * 100;
            }

            for (int i = 0; i < sparseIndices.Length; i++)
            {
                Assert.Equal((long) sparseIndices[i] * 100, table[sparseIndices[i]]);
            }
        }

        /// <summary>
        ///     Test that FastestTable.Empty works correctly.
        /// </summary>
        [Fact]
        public void Empty_DefaultTable_HasEmptyBuffer()
        {
            FastestTable<int> emptyTable = FastestTable<int>.Empty;

            Assert.NotNull(emptyTable._buffer);
            Assert.Equal(0, emptyTable._buffer.Length);
        }

        /// <summary>
        ///     Test that FastestTable with reference types maintains proper references.
        /// </summary>
        [Fact]
        public void Index_ReferenceType_MaintainsReferenceIntegrity()
        {
            FastestTable<object> table = new FastestTable<object>(10);
            var obj1 = new {ID = 1};
            var obj2 = new {ID = 2};

            ref object ref1 = ref table[0];
            ref1 = obj1;
            ref object ref2 = ref table[10];
            ref2 = obj2;

            Assert.Same(obj1, table[0]);
            Assert.Same(obj2, table[10]);
        }
    }
}