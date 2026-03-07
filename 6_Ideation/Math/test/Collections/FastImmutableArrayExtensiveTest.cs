using Alis.Core.Aspect.Math.Collections;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    /// Comprehensive unit tests for FastImmutableArray collection type.
    /// Tests immutability, performance, and edge cases.
    /// </summary>
    public class FastImmutableArrayExtensiveTest
    {
        
        

        /// <summary>
        /// Tests that create from enumerable succeeds
        /// </summary>
        [Fact]
        public void Create_FromEnumerable_Succeeds()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var array = new FastImmutableArray<int>(source);
            
            Assert.Equal(5, array.Length);
            Assert.Equal(source, array);
        }

        /// <summary>
        /// Tests that create from enumerable null values succeeds
        /// </summary>
        [Fact]
        public void Create_FromEnumerable_NullValues_Succeeds()
        {
            var source = new string[] { "a", null, "c" };
            var array = new FastImmutableArray<string>(source);
            
            Assert.Equal(3, array.Length);
        }

        /// <summary>
        /// Tests that create with different sizes
        /// </summary>
        /// <param name="size">The size</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Create_WithDifferentSizes(int size)
        {
            var source = Enumerable.Range(0, size).ToArray();
            var array = new FastImmutableArray<int>(source);
            
            Assert.Equal(size, array.Length);
        }

        

        

 

        /// <summary>
        /// Tests that enumeration iterates all elements
        /// </summary>
        [Fact]
        public void Enumeration_IteratesAllElements()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var array = new FastImmutableArray<int>(source);
            var result = new List<int>();
            
            foreach (var item in array)
            {
                result.Add(item);
            }
            
            Assert.Equal(source, result);
        }

        /// <summary>
        /// Tests that enumeration multiple enumeration succeeds
        /// </summary>
        [Fact]
        public void Enumeration_MultipleEnumeration_Succeeds()
        {
            var source = new[] { 1, 2, 3 };
            var array = new FastImmutableArray<int>(source);
            
            var first = array.ToList();
            var second = array.ToList();
            
            Assert.Equal(first, second);
        }

        
        

        

        /// <summary>
        /// Tests that index access valid index returns element
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(4, 5)]
        public void IndexAccess_ValidIndex_ReturnsElement(int index, int expected)
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var array = new FastImmutableArray<int>(source);
            
            Assert.Equal(expected, array[index]);
        }

        /// <summary>
        /// Tests that index access invalid index throws exception
        /// </summary>
        /// <param name="index">The index</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        [InlineData(100)]
        public void IndexAccess_InvalidIndex_ThrowsException(int index)
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var array = new FastImmutableArray<int>(source);
            
            Assert.Throws<IndexOutOfRangeException>(() => array[index]);
        }

        

        

        /// <summary>
        /// Tests that count returns correct value
        /// </summary>
        /// <param name="size">The size</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void Count_ReturnsCorrectValue(int size)
        {
            var source = Enumerable.Range(0, size).ToArray();
            var array = new FastImmutableArray<int>(source);
            
            Assert.Equal(size, array.Length);
        }

        

        

        /// <summary>
        /// Tests that linq where filtered correctly
        /// </summary>
        [Fact]
        public void Linq_Where_FilteredCorrectly()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var array = new FastImmutableArray<int>(source);
            
            var result = array.Where(x => x > 2).ToList();
            
            Assert.Equal(3, result.Count);
            Assert.Equal(new[] { 3, 4, 5 }, result);
        }

        /// <summary>
        /// Tests that linq select transformed correctly
        /// </summary>
        [Fact]
        public void Linq_Select_TransformedCorrectly()
        {
            var source = new[] { 1, 2, 3 };
            var array = new FastImmutableArray<int>(source);
            
            var result = array.Select(x => x * 2).ToList();
            
            Assert.Equal(new[] { 2, 4, 6 }, result);
        }

        /// <summary>
        /// Tests that linq first or default returns element
        /// </summary>
        [Fact]
        public void Linq_FirstOrDefault_ReturnsElement()
        {
            var source = new[] { 1, 2, 3 };
            var array = new FastImmutableArray<int>(source);
            
            var result = array.FirstOrDefault();
            
            Assert.Equal(1, result);
        }

        
    }
}
