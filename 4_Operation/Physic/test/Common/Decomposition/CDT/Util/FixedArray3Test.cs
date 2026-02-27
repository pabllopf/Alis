// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray3Test.cs
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

using System.Linq;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Util;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The fixed array 3 test class
    /// </summary>
    public class FixedArray3Test
    {
        /// <summary>
        ///     Tests that default constructor should initialize with null values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithNullValues()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            Assert.Null(array[0]);
            Assert.Null(array[1]);
            Assert.Null(array[2]);
        }

        /// <summary>
        ///     Tests that indexer should set and get value at index zero
        /// </summary>
        [Fact]
        public void Indexer_ShouldSetAndGetValueAtIndexZero()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            array[0] = "test";
            
            Assert.Equal("test", array[0]);
        }

        /// <summary>
        ///     Tests that indexer should set and get value at index one
        /// </summary>
        [Fact]
        public void Indexer_ShouldSetAndGetValueAtIndexOne()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            array[1] = "value";
            
            Assert.Equal("value", array[1]);
        }

        /// <summary>
        ///     Tests that indexer should set and get value at index two
        /// </summary>
        [Fact]
        public void Indexer_ShouldSetAndGetValueAtIndexTwo()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            array[2] = "data";
            
            Assert.Equal("data", array[2]);
        }

        /// <summary>
        ///     Tests that indexer should throw exception for negative index
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowException_ForNegativeIndex()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[-1]);
        }

        /// <summary>
        ///     Tests that indexer should throw exception for index greater than two
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowException_ForIndexGreaterThanTwo()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[3]);
        }

        /// <summary>
        ///     Tests that contains should return true when value present
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnTrue_WhenValuePresent()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "test";
            
            bool result = array.Contains("test");
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that contains should return false when value not present
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnFalse_WhenValueNotPresent()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "test";
            
            bool result = array.Contains("missing");
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that index of should return correct index
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[1] = "value";
            
            int index = array.IndexOf("value");
            
            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that index of should return negative one when value not found
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnNegativeOne_WhenValueNotFound()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "test";
            
            int index = array.IndexOf("missing");
            
            Assert.Equal(-1, index);
        }

        /// <summary>
        ///     Tests that clear should set all values to null
        /// </summary>
        [Fact]
        public void Clear_ShouldSetAllValuesToNull()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "a";
            array[1] = "b";
            array[2] = "c";
            
            array.Clear();
            
            Assert.Null(array[0]);
            Assert.Null(array[1]);
            Assert.Null(array[2]);
        }

        /// <summary>
        ///     Tests that clear with value should clear specific value
        /// </summary>
        [Fact]
        public void ClearWithValue_ShouldClearSpecificValue()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "test";
            array[1] = "other";
            array[2] = "test";
            
            array.Clear("test");
            
            Assert.Null(array[0]);
            Assert.Equal("other", array[1]);
            Assert.Null(array[2]);
        }

        /// <summary>
        ///     Tests that get enumerator should enumerate all values
        /// </summary>
        [Fact]
        public void GetEnumerator_ShouldEnumerateAllValues()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "first";
            array[1] = "second";
            array[2] = "third";
            
            var values = array.ToList();
            
            Assert.Equal(3, values.Count);
            Assert.Equal("first", values[0]);
            Assert.Equal("second", values[1]);
            Assert.Equal("third", values[2]);
        }

        /// <summary>
        ///     Tests that fixed array should be value type
        /// </summary>
        [Fact]
        public void FixedArray_ShouldBeValueType()
        {
            FixedArray3<string> array1 = new FixedArray3<string>();
            array1[0] = "test";
            FixedArray3<string> array2 = array1;
            
            array2[0] = "modified";
            
            Assert.NotEqual(array1[0], array2[0]);
        }

        /// <summary>
        ///     Tests that fixed array should support foreach iteration
        /// </summary>
        [Fact]
        public void FixedArray_ShouldSupportForeachIteration()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "a";
            array[1] = null;
            array[2] = "c";
            
            int nonNullCount = 0;
            foreach (string value in array)
            {
                if (value != null) nonNullCount++;
            }
            
            Assert.Equal(2, nonNullCount);
        }

        /// <summary>
        ///     Tests that fixed array should work with reference types
        /// </summary>
        [Fact]
        public void FixedArray_ShouldWorkWithReferenceTypes()
        {
            FixedArray3<TriangulationPoint> array = new FixedArray3<TriangulationPoint>();
            TriangulationPoint point = new TriangulationPoint(5, 10);
            
            array[0] = point;
            
            Assert.Equal(point, array[0]);
        }

        /// <summary>
        ///     Tests that index of should return first occurrence
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnFirstOccurrence()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "unique";
            array[1] = "test";
            array[2] = "test";
            
            int index = array.IndexOf("test");
            
            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that contains should work with null values
        /// </summary>
        [Fact]
        public void Contains_ShouldWorkWithNullValues()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            array[0] = "test";
            array[1] = null;
            array[2] = "data";
            
            bool result = array.Contains(null);
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that indexer set should throw exception for invalid index
        /// </summary>
        [Fact]
        public void IndexerSet_ShouldThrowException_ForInvalidIndex()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[5] = "value");
        }

        /// <summary>
        ///     Tests that fixed array should implement i enumerable
        /// </summary>
        [Fact]
        public void FixedArray_ShouldImplementIEnumerable()
        {
            FixedArray3<string> array = new FixedArray3<string>();
            
            Assert.IsAssignableFrom<System.Collections.Generic.IEnumerable<string>>(array);
        }

        /// <summary>
        ///     Tests that fixed array should support class constraint
        /// </summary>
        [Fact]
        public void FixedArray_ShouldSupportClassConstraint()
        {
            FixedArray3<object> array = new FixedArray3<object>();
            array[0] = new object();
            
            Assert.NotNull(array[0]);
        }
    }
}

