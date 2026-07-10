using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    public class FastestArrayPoolClearBucketsTest
    {
        [Fact]
        public void ClearBuckets_AfterReturningArrays_RentStillWorks()
        {
            FastestArrayPool<int> pool = new FastestArrayPool<int>();

            int[] arr16 = pool.Rent(16);
            int[] arr32 = pool.Rent(32);
            pool.Return(arr16);
            pool.Return(arr32);

            Gen2GcCallback.Gen2CollectionOccured?.Invoke();

            int[] newArr = pool.Rent(16);
            Assert.NotNull(newArr);
            Assert.True(newArr.Length >= 16);
        }

        [Fact]
        public void ClearBuckets_WithNoReturnedArrays_RentStillWorks()
        {
            FastestArrayPool<int> pool = new FastestArrayPool<int>();

            Gen2GcCallback.Gen2CollectionOccured?.Invoke();

            int[] arr = pool.Rent(100);
            Assert.NotNull(arr);
            Assert.True(arr.Length >= 100);
        }

        [Fact]
        public void Constructor_SubscribesToGen2Event_AndClearBucketsSafe()
        {
            FastestArrayPool<int> pool = new FastestArrayPool<int>();
            int[] arr = pool.Rent(64);
            pool.Return(arr);

            Gen2GcCallback.Gen2CollectionOccured?.Invoke();

            int[] newArr = pool.Rent(64);
            Assert.NotNull(newArr);
        }
    }
}
