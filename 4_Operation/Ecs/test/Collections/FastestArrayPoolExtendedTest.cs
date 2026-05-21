

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for FastestArrayPool to validate advanced pooling scenarios,
    ///     memory reuse, and edge cases in buffer management.
    /// </summary>
    public class FastestArrayPoolExtendedTest
    {
        /// <summary>
        ///     Test that renting and returning arrays maintains pool consistency.
        /// </summary>
        [Fact]
        public void RentAndReturn_SingleArray_PoolReusesProperly()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array1 = pool.Rent(100);
            int[] array2;

            pool.Return(array1);
            array2 = pool.Rent(100);

            Assert.NotNull(array2);
            Assert.True(array2.Length >= 100);
        }

        /// <summary>
        ///     Test that arrays below minimum bucket size are not pooled.
        /// </summary>
        [Fact]
        public void Rent_BelowMinimumBucketSize_CreatesNewArray()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;

            int[] smallArray = pool.Rent(8);

            Assert.NotNull(smallArray);
            Assert.Equal(8, smallArray.Length);
        }

        /// <summary>
        ///     Test that renting increasingly larger arrays works correctly.
        /// </summary>
        [Fact]
        public void Rent_ProgressivelyLargerSizes_AllSuccessful()
        {
            FastestArrayPool<long> pool = FastestArrayPool<long>.Instance;
            int[] sizes = {16, 32, 64, 128, 256, 512, 1024};

            foreach (int size in sizes)
            {
                long[] array = pool.Rent(size);
                Assert.NotNull(array);
                Assert.True(array.Length >= size);
            }
        }

        /// <summary>
        ///     Test that ResizeArrayFromPool properly copies data and maintains content.
        /// </summary>
        [Fact]
        public void ResizeArrayFromPool_DataPreservation_ContentIntact()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] arr = {1, 2, 3, 4, 5};
            int[] originalCopy = (int[]) arr.Clone();

            FastestArrayPool<int>.ResizeArrayFromPool(ref arr, 200);

            for (int i = 0; i < originalCopy.Length; i++)
            {
                Assert.Equal(originalCopy[i], arr[i]);
            }

            Assert.True(arr.Length >= 200);
        }

        /// <summary>
        ///     Test that returning arrays with clear flag works for reference types.
        /// </summary>
        [Fact]
        public void Return_WithClearFlag_ReferencesCleared()
        {
            FastestArrayPool<string> pool = FastestArrayPool<string>.Instance;
            string[] array = pool.Rent(50);
            array[0] = "test";

            pool.Return(array, true);

            Assert.Null(array[0]);
        }

        /// <summary>
        ///     Test that multiple rental cycles work correctly without corruption.
        /// </summary>
        [Fact]
        public void MultipleCycles_RentReturnRentPattern_Consistent()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;

            for (int cycle = 0; cycle < 5; cycle++)
            {
                int[] arr = pool.Rent(100);
                for (int i = 0; i < 100; i++)
                {
                    arr[i] = i;
                }

                pool.Return(arr);

                int[] arr2 = pool.Rent(100);
                Assert.NotNull(arr2);
                Assert.True(arr2.Length >= 100);
                pool.Return(arr2);
            }
        }

        /// <summary>
        ///     Test that over-sized arrays (exceeding bucket capacity) are handled gracefully.
        /// </summary>
        [Fact]
        public void Rent_OversizedRequest_FallbackArray()
        {
            FastestArrayPool<short> pool = FastestArrayPool<short>.Instance;
            int hugeSize = int.MaxValue / 2;

            short[] array = pool.Rent(hugeSize);

            Assert.NotNull(array);
            Assert.True(array.Length >= hugeSize);
        }

        /// <summary>
        ///     Test that ValueType arrays work correctly through pooling cycles.
        /// </summary>
        [Fact]
        public void Rent_ValueTypeArray_ProperlyPooled()
        {
            FastestArrayPool<byte> pool = FastestArrayPool<byte>.Instance;

            byte[] arr1 = pool.Rent(256);
            arr1[0] = 255;
            pool.Return(arr1);

            byte[] arr2 = pool.Rent(256);

            Assert.NotNull(arr2);
            Assert.True(arr2.Length >= 256);
        }
    }
}