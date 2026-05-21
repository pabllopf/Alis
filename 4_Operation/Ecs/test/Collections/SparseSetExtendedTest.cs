

using System;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for SparseSet generic class to validate storage,
    ///     retrieval, and sparse index patterns with values.
    /// </summary>
    public class SparseSetExtendedTest
    {
        /// <summary>
        ///     Test that SparseSet stores and retrieves values correctly by index.
        /// </summary>
        [Fact]
        public void Index_SetAndGet_StoresAndRetrievesCorrectly()
        {
            SparseSet<int> set = new SparseSet<int>();

            ref int value = ref set[5];
            value = 42;

            Assert.Equal(42, set[5]);
        }

        /// <summary>
        ///     Test that SparseSet handles multiple sequential inserts.
        /// </summary>
        [Fact]
        public void Index_MultipleSequentialInserts_AllAccessible()
        {
            SparseSet<string> set = new SparseSet<string>();

            for (int i = 0; i < 50; i++)
            {
                ref string str = ref set[i];
                str = $"Value_{i}";
            }

            for (int i = 0; i < 50; i++)
            {
                Assert.Equal($"Value_{i}", set[i]);
            }
        }

        /// <summary>
        ///     Test that SparseSet handles sparse index access patterns.
        /// </summary>
        [Fact]
        public void Index_SparseAccess_AllIndexesAccessible()
        {
            SparseSet<long> set = new SparseSet<long>();
            int[] indices = {5, 50, 500, 5000};

            for (int i = 0; i < indices.Length; i++)
            {
                ref long val = ref set[indices[i]];
                val = (long) indices[i] * 100;
            }

            for (int i = 0; i < indices.Length; i++)
            {
                Assert.Equal((long) indices[i] * 100, set[indices[i]]);
            }
        }

        /// <summary>
        ///     Test that SparseSet properly grows as needed.
        /// </summary>
        [Fact]
        public void Index_LargeIndex_BufferExpands()
        {
            SparseSet<int> set = new SparseSet<int>();

            ref int value = ref set[1000];
            value = 999;

            Assert.Equal(999, set[1000]);
        }

        /// <summary>
        ///     Test that SparseSet works with value types.
        /// </summary>
        [Fact]
        public void Index_ValueType_StoresAndRetrievesCorrectly()
        {
            SparseSet<Guid> set = new SparseSet<Guid>();
            Guid guid = Guid.NewGuid();

            ref Guid refGuid = ref set[10];
            refGuid = guid;

            Assert.Equal(guid, set[10]);
        }

        /// <summary>
        ///     Test that SparseSet with reference types maintains proper references.
        /// </summary>
        [Fact]
        public void Index_ReferenceType_MaintainsReferences()
        {
            SparseSet<object> set = new SparseSet<object>();
            var obj1 = new {ID = 1};
            var obj2 = new {ID = 2};

            ref object ref1 = ref set[0];
            ref1 = obj1;
            ref object ref2 = ref set[10];
            ref2 = obj2;

            Assert.Same(obj1, set[0]);
            Assert.Same(obj2, set[10]);
        }

        /// <summary>
        ///     Test that SparseSet maintains data across multiple accesses.
        /// </summary>
        [Fact]
        public void MultipleAccesses_SameIndex_DataConsistent()
        {
            SparseSet<int> set = new SparseSet<int>();
            ref int value = ref set[5];
            value = 100;

            int read1 = set[5];
            int read2 = set[5];

            Assert.Equal(100, read1);
            Assert.Equal(100, read2);
        }

        /// <summary>
        ///     Test that SparseSet can clear and be reused.
        /// </summary>
        [Fact]
        public void Clear_AfterInserts_CanReuseSet()
        {
            SparseSet<int> set = new SparseSet<int>();
            for (int i = 0; i < 20; i++)
            {
                ref int val = ref set[i];
                val = i;
            }

            for (int i = 0; i < 20; i++)
            {
                ref int val = ref set[i + 100];
                val = i + 100;
            }

            for (int i = 0; i < 20; i++)
            {
                Assert.Equal(i + 100, set[i + 100]);
            }
        }

        /// <summary>
        ///     Test that SparseSet handles alternating sparse and sequential access.
        /// </summary>
        [Fact]
        public void MixedAccess_SparseAndSequential_ConsistentState()
        {
            SparseSet<string> set = new SparseSet<string>();

            for (int i = 0; i < 5; i++)
            {
                ref string str = ref set[i];
                str = $"Seq_{i}";
            }

            int[] sparseIndices = {100, 500, 1000};
            for (int i = 0; i < sparseIndices.Length; i++)
            {
                ref string str = ref set[sparseIndices[i]];
                str = $"Sparse_{i}";
            }

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal($"Seq_{i}", set[i]);
            }

            for (int i = 0; i < sparseIndices.Length; i++)
            {
                Assert.Equal($"Sparse_{i}", set[sparseIndices[i]]);
            }
        }

        /// <summary>
        ///     Test that SparseSet properly initializes default values.
        /// </summary>
        [Fact]
        public void Index_UninitiallizedAccess_HasDefaultValue()
        {
            SparseSet<int> set = new SparseSet<int>();

            int value = set[100]; // Access uninitialized index

            Assert.Equal(0, value); // Default value for int
        }
    }
}