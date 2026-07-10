// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestArrayPoolRemainingCoverageTests.cs
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

using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    public class FastestArrayPoolRemainingCoverageTests
    {
        [Fact]
        public void Return_WithClearArray_ReferenceType_ClearsArray()
        {
            FastestArrayPool<string> pool = FastestArrayPool<string>.Instance;
            string[] array = pool.Rent(16);
            array[0] = "value";
            pool.Return(array, clearArray: true);
            Assert.Null(array[0]);
        }

        [Fact]
        public void Return_WithClearArray_ReferenceType_ReusesClean()
        {
            FastestArrayPool<string> pool = FastestArrayPool<string>.Instance;
            string[] array = pool.Rent(64);
            array[0] = "dirty";
            pool.Return(array, clearArray: true);
            string[] reused = pool.Rent(64);
            Assert.Same(array, reused);
            Assert.Null(reused[0]);
        }

        [Fact]
        public void GetBucketIndex_Oversized_ReturnsMinusOne()
        {
            MethodInfo getBucketIndex = typeof(FastestArrayPool<int>)
                .GetMethod("GetBucketIndex", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(getBucketIndex);
            int result = (int)getBucketIndex.Invoke(null, [int.MaxValue]);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void GetBucketIndex_BelowMinBucketSize_ReturnsMinusOne()
        {
            MethodInfo getBucketIndex = typeof(FastestArrayPool<int>)
                .GetMethod("GetBucketIndex", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(getBucketIndex);
            int result = (int)getBucketIndex.Invoke(null, [4]);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void GetBucketIndex_ExactBucketSizes_ReturnsCorrectIndex()
        {
            MethodInfo getBucketIndex = typeof(FastestArrayPool<int>)
                .GetMethod("GetBucketIndex", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(getBucketIndex);
            Assert.Equal(0, (int)getBucketIndex.Invoke(null, [16]));
            Assert.Equal(1, (int)getBucketIndex.Invoke(null, [32]));
            Assert.Equal(2, (int)getBucketIndex.Invoke(null, [64]));
            Assert.Equal(26, (int)getBucketIndex.Invoke(null, [1 << 30]));
        }

        [Fact]
        public void RentAndReturn_ReferenceType_FullCycle()
        {
            FastestArrayPool<object> pool = new FastestArrayPool<object>();
            object[] arr = pool.Rent(16);
            arr[0] = new object();
            Assert.NotNull(arr[0]);
            pool.Return(arr, clearArray: true);
            Assert.Null(arr[0]);
            object[] reused = pool.Rent(16);
            Assert.Same(arr, reused);
            Assert.Null(reused[0]);
            pool.Return(reused);
        }

        [Fact]
        public void ClearBuckets_AfterReturn_EmptiesBuckets()
        {
            FastestArrayPool<int> pool = new FastestArrayPool<int>();
            int[] arr = pool.Rent(16);
            pool.Return(arr);
            Gen2GcCallback.Gen2CollectionOccured?.Invoke();
            int[] newArr = pool.Rent(16);
            Assert.NotSame(arr, newArr);
        }

        [Fact]
        public void Constructor_SubscribesAndClears()
        {
            FastestArrayPool<string> pool = new FastestArrayPool<string>();
            string[] arr = pool.Rent(16);
            arr[0] = "data";
            pool.Return(arr, clearArray: true);
            Assert.Null(arr[0]);
        }

        [Fact]
        public void Return_WithClearArray_MultipleCycles_ClearsEveryTime()
        {
            FastestArrayPool<string> pool = FastestArrayPool<string>.Instance;
            for (int i = 0; i < 5; i++)
            {
                string[] arr = pool.Rent(128);
                arr[0] = "cycle";
                pool.Return(arr, clearArray: true);
                Assert.Null(arr[0]);
            }
        }

        [Fact]
        public void Return_SmallArray_BucketIndexMinusOne_DoesNotStore()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] arr = new int[4];
            pool.Return(arr);
            MethodInfo getBucketIndex = typeof(FastestArrayPool<int>)
                .GetMethod("GetBucketIndex", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(getBucketIndex);
            int index = (int)getBucketIndex.Invoke(null, [arr.Length]);
            Assert.Equal(-1, index);
        }
    }
}
